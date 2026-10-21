using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Services.Primitives;
using EficazFramework.SPED.Utilities.XML;

namespace EficazFramework.SPED.Services.CTe;

public class CTeService : SoapServiceBase
{
    /// <summary>
    /// Efetua a consulta de protocolo de CT-e / CT-eOS
    /// </summary>
    /// <param name="chave">Chave da CT-e ou CT-eOS para consulta</param>
    /// <param name="ambiente">Produção ou Homologação</param>
    public async Task<Schemas.CTe.RetornoConsultaSituacaoCTe> ConsultaSituacaoAsync(
        string chave,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
    {
        //! validações iniciais:
        if (chave.Length != 44)
            throw new ArgumentException("A chave informada não é válida");

        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


        //! montagem dos argumentos:
        string uf = ((Schemas.NFe.OrgaoIBGE)int.Parse(chave[..2])).ToString();


        //! execução:
        var request = new Contracts.CteConsultaCTRequest();
        var dados = new Schemas.CTe.PedidoConsultaSituacaoCTe()
        {
            Ambiente = ambiente,
            Chave = chave,
            versao = Schemas.CTe.VersaoServicoConsulta.Versao_4_00
        };
        request.cteDadosMsg = dados.SerializeToXMLDocument().DocumentElement;
        return await ExecuteAsync<SoapClients.CteConsultaSoapClient, Schemas.CTe.RetornoConsultaSituacaoCTe>(request, uf); ;
    }



    /// <summary>
    /// Executa a chamada ao WebService de recepção de eventos (CTeRecepcaoEventoV4) para um CT-e
    /// </summary>
    /// <param name="cnpjCpf">CNPJ ou CPF do autor do evento (tomador do serviço)</param>
    /// <param name="chave">Chave do CT-e</param>
    /// <param name="tpEvento">Prestação do Serviço em Desacordo ou seu cancelamento</param>
    /// <param name="observacao">Observações do tomador (15 a 255 caracteres). Obrigatório para <see cref="Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo"/></param>
    /// <param name="protocoloEvento">Protocolo do evento a ser cancelado. Obrigatório para <see cref="Schemas.CTe.CodigoEvento.CancelamentoPrestacaoServicoDesacordo"/></param>
    /// <param name="sequencial">Número sequencial do evento (1 a 999)</param>
    public async Task<Schemas.CTe.RetornoEvento> EnvioEventoAsync(
        string cnpjCpf,
        string chave,
        Schemas.CTe.CodigoEvento tpEvento,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao,
        string observacao = null,
        string protocoloEvento = null,
        int sequencial = 1)
    {
        //! validações iniciais:
        if (chave?.Length != 44)
            throw new ArgumentException("A chave informada não é válida");

        if (!cnpjCpf.IsValidCNPJ() && !cnpjCpf.IsValidCPF())
            throw new ArgumentException("O CNPJ ou CPF informado para o autor do evento não é válido");

        if (sequencial is < 1 or > 999)
            throw new ArgumentOutOfRangeException(nameof(sequencial), "O número sequencial do evento deve estar entre 1 e 999.");

        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


        //! montagem dos argumentos:
        var uf = (Schemas.NFe.OrgaoIBGE)int.Parse(chave[..2]);

        Schemas.CTe.DetalheEvento detalhe = tpEvento switch
        {
            Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo when observacao?.Length is >= 15 and <= 255
                => new Schemas.CTe.evPrestDesacordo { Observacoes = observacao },
            Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo
                => throw new ArgumentException("A observação é obrigatória e deve conter de 15 a 255 caracteres.", nameof(observacao)),
            Schemas.CTe.CodigoEvento.CancelamentoPrestacaoServicoDesacordo when !string.IsNullOrWhiteSpace(protocoloEvento)
                => new Schemas.CTe.evCancPrestDesacordo { ProtocoloEventoDesacordo = protocoloEvento },
            Schemas.CTe.CodigoEvento.CancelamentoPrestacaoServicoDesacordo
                => throw new ArgumentException("O protocolo do evento a ser cancelado é obrigatório.", nameof(protocoloEvento)),
            _ => throw new NotSupportedException($"O evento {(int)tpEvento} não é suportado pelo Eficaz Framework.")
        };


        //! montagem e assinatura do evento:
        var evento = new Schemas.CTe.Evento
        {
            versao = "4.00",
            infEvento = new()
            {
                cOrgao = uf,
                tpAmb = ambiente,
                CNPJ_CPF = cnpjCpf,
                ItemElementName = cnpjCpf.IsValidCNPJ() ? Schemas.CTe.PersonalidadeJuridica7.CNPJ : Schemas.CTe.PersonalidadeJuridica7.CPF,
                chCTe = chave,
                dhEvento = DateTime.Now,
                tpEvento = ((int)tpEvento).ToString(),
                nSeqEvento = sequencial.ToString(),
                Id = $"ID{(int)tpEvento}{chave}{sequencial:000}",
                detEvento = new()
                {
                    versaoEvento = "4.00",
                    Any = detalhe.ToXElement()
                }
            }
        };

        XmlDocument eventoXml = new();
        eventoXml.LoadXml(evento.Serialize().RemoveW3CNamespaces());
        Certificado.SignXml(eventoXml, "eventoCTe", "infEvento", false, false);


        //! execução:
        var request = new Contracts.CTeRecepcaoEventoV4Request { cteDadosMsg = eventoXml.DocumentElement };
        return await ExecuteAsync<SoapClients.CTeRecepcaoEventoV4SoapClient, Schemas.CTe.RetornoEvento>(request, uf.ToString(), ambiente.ToString());
    }



    /// <summary>
    /// Executa o serviço de distribuição de DF-e e visa retornar as informações sobre CT-e dos últimos 90 dias. <br/>
    /// Pode incluir: CT-e completo, resumo de CT-e e/ou eventos do CT-e.
    /// </summary>
    /// <param name="uf">Utilizar a UF do destinatário até que se conheça a real aplicação deste parâmetro</param>
    /// <param name="cnpjCpf">CNPJ ou CPF do interessado pela busca</param>
    /// <param name="ultimoNsu">NSU para início das buscas, ou 0 para mais antigo possível</param>
    public async Task<Schemas.CTe.RetornoDistribuicaoDFe> DistribuicaoDFeAsync(
        Schemas.NFe.OrgaoIBGE uf,
        string cnpjCpf,
        int ultimoNsu = 0,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
    {
        //! validações iniciais:
        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


        //! execução:
        var request = new Contracts.CTeDistribuicaoDFeRequest();
        Schemas.CTe.PedidoDistribuicaoDFe dados = new()
        {
            Ambiente = ambiente,
            CNPJ_CPF = cnpjCpf,
            ItemElementName = cnpjCpf.IsValidCNPJ() ? Schemas.CTe.PersonalidadeJuridica7.CNPJ : Schemas.CTe.PersonalidadeJuridica7.CPF,
            UF_Autor = uf,
            versao = Schemas.CTe.VersaoServicoDistribuicaoDF.Versao1_00,
            NSUObject = new Schemas.CTe.distDFeIntDistNSU { ultNSU = $"{ultimoNsu:000000000000000}" },
        };
        request.cteDistDFeInteresse = new() { cteDadosMsg = dados.SerializeToXMLDocument().DocumentElement };
        return await ExecuteAsync<SoapClients.CTeDistribuicaoDFeSoapClient, Schemas.CTe.RetornoDistribuicaoDFe>(request); ;
    }
}
