using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Services.Primitives;
using EficazFramework.SPED.Utilities.XML;
using System.Net;

namespace EficazFramework.SPED.Services.NFe;

public class NFeService : SoapServiceBase
{
    /// <summary>
    /// Efetua a transmissão de NF-e / NFC-e na versão 4.00 para autorização.
    /// NOTA: No nomento, opera apenas no modelo síncroni, com um único documento por lote
    /// </summary>
    /// <param name="chave">Chave da NF-e ou NFC-e para consulta</param>
    /// <param name="ambiente">Produção ou Homologação</param>
    public async Task<Schemas.NFe.RetornoAutorizacaoNFe> Autoriza4Async(
        Schemas.NFe.NFe nfe,
        string identificadorLote,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
    {
        //! validações iniciais:
        if (nfe.Chave.Length != 44)
            throw new ArgumentException("A chave informada não é válida");

        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


        //! montagem dos argumentos:
        string uf = ((Schemas.NFe.OrgaoIBGE)int.Parse(nfe.Chave[..2])).ToString();
        string modelo = nfe.Chave[20..22];


        //! Assinatura
        XmlDocument nfeXml = new();
        nfeXml.LoadXml(nfe.Serialize().RemoveW3CNamespaces());
        Certificado.SignXml(nfeXml, "NFe", "infNFe", false, false);


        //! execução:
        var request = new Contracts.nfeAutorizacaoLoteRequest();
        var dados = new Schemas.NFe.PedidoAutorizacaoNFe()
        {
            IdentificadorLote = identificadorLote,
            IndicadorAutorizacao = Schemas.NFe.IndicadorAutorizacao.Sincrono,
            Versao = "4.00"
        };
        XmlDocument dadosXml = new();
        dadosXml.LoadXml(dados.Serialize().RemoveW3CNamespaces());
        dadosXml.GetElementsByTagName("enviNFe").Item(0).AppendChild(dadosXml.ImportNode(nfeXml.DocumentElement, true));

        request.nfeDadosMsg = dadosXml.DocumentElement;

        var result =  await ExecuteAsync<SoapClients.NFeAutorizacao4SoapClient, Schemas.NFe.RetornoAutorizacaoNFe>(request, uf, modelo, ambiente.ToString());
        return result;
    }



    /// <summary>
    /// Efetua a consulta de cadastro de contribuintes, na versão 4.00
    /// </summary>
    /// <param name="cnpjCpfIe">CNPJ, CPF ou Inscrição Estadual para pesquisa</param>
    /// <param name="documento">Informa qual tipo de documento o número fornecido em <paramref name="cnpjCpfIe"/> corresponde</param>
    /// <param name="uf">Estado do contribuinte pesquisado</param>
    public async Task<Schemas.NFe.RetornoConsultaCadastro> ConsultaCadastro4Async(
        string cnpjCpfIe,
        Schemas.NFe.TipoPesquisaCadastro documento,
        Schemas.NFe.OrgaoIBGE uf)
    {
        //! validações iniciais:
        if (!cnpjCpfIe.IsValidCNPJ() && !cnpjCpfIe.IsValidCPF())
            throw new ArgumentException("O CNPJ ou CPF informado para buscas não é válido");

        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


        //! execução:
        var request = new Contracts.consultaCadastroRequest();
        var dados = new Schemas.NFe.PedidoConsultaCadastro()
        {
            Informacoes = new()
            {
                Item = cnpjCpfIe,
                ItemElementName = documento,
                UF = uf.ToString()
            }
        };
        request.nfeDadosMsg = dados.SerializeToXMLDocument().DocumentElement;
        return await ExecuteAsync<SoapClients.CadConsultaCadastro4SoapClient, Schemas.NFe.RetornoConsultaCadastro>(request, uf.ToString()); ;
    }



    /// <summary>
    /// Efetua a consulta de protocolo de NF-e / NFC-e na versão 4.00
    /// </summary>
    /// <param name="chave">Chave da NF-e ou NFC-e para consulta</param>
    /// <param name="ambiente">Produção ou Homologação</param>
    public async Task<Schemas.NFe.RetornoConsultaSituacaoNFe> ConsultaProtocolo4Async(
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
        string modelo = chave[20..22];


        //! execução:
        var request = new Contracts.nfeConsultaNFRequest();
        var dados = new Schemas.NFe.PedidoConsultaSituacaoNFe()
        {
            Ambiente = ambiente,
            ChaveNFe = chave,
            Versao = Schemas.NFe.VersaoServicoConsSitNFe.Versao_4_00
        };
        request.nfeDadosMsg = dados.SerializeToXMLDocument().DocumentElement;
        return await ExecuteAsync<SoapClients.NFeConsultaProtocolo4SoapClient, Schemas.NFe.RetornoConsultaSituacaoNFe>(request, uf, modelo); ;
    }



    /// <summary>
    /// Executa o serviço de distribuição de DF-e e visa retornar as informações sobre NF-e dos últimos 90 dias. <br/>
    /// Pode incluir: NF-e completa, resumo de NF-e e/ou eventos da NF-e.
    /// </summary>
    /// <param name="uf">Utilizar a UF do destinatário até que se conheça a real aplicação deste parâmetro</param>
    /// <param name="cnpjCpf">CNPJ ou CPF do interessado pela busca</param>
    /// <param name="ultimoNsu">NSU para início das buscas, ou 0 para mais antigo possível</param>
    /// <param name="chave">Pesquisar por uma chave em particular</param>
    public async Task<Schemas.NFe.RetornoDistribuicaoDFe> DistribuicaoDFeAsync(
        Schemas.NFe.OrgaoIBGE uf,
        string cnpjCpf,
        int ultimoNsu = 0,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao,
        string chave = null)
    {
        //! validações iniciais:
        if (!string.IsNullOrEmpty(chave) && chave.Length != 44)
            throw new ArgumentException("A chave informada não é válida");

        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


        //! execução:
        var request = new Contracts.NFeDistribuicaoDFeRequest();
        Schemas.NFe.PedidoDistribuicaoDFe dados = new()
        {
            Ambiente = ambiente,
            CNPJ_CPF = cnpjCpf,
            ItemElementName = cnpjCpf.IsValidCNPJ() ? Schemas.NFe.PersonalidadeJuridica.CNPJ : Schemas.NFe.PersonalidadeJuridica.CPF,
            UF_Autor = uf,
            versao = Schemas.NFe.VersaoServicoDistribuicaoDF.Versao1_01,
            NSUObject = string.IsNullOrEmpty(chave) ? new Schemas.NFe.distDFeIntDistNSU { ultNSU = $"{ultimoNsu:000000000000000}" } : null,
            consChNFe = !string.IsNullOrEmpty(chave) ? new Schemas.NFe.distDFeIntconsChNFe { chNFe = chave } : null
        };
        request.nfeDistDFeInteresse = new() { nfeDadosMsg = dados.SerializeToXMLDocument().DocumentElement };
        return await ExecuteAsync<SoapClients.NFeDistribuicaoDFeSoapClient, Schemas.NFe.RetornoDistribuicaoDFe>(request); ;
    }



    /// <summary>
    /// Executa a chamada ao WebService de envio de eventos para uma NF-e
    /// </summary>
    /// <param name="cnpjCpf">CNPJ ou CPF do Autor do Evento</param>
    /// <param name="chave">Informar chave da NF-e</param>
    /// <param name="tpEvento">Cancelamento, Ciência, Confirmação, Recusa, etc.</param>
    /// <param name="justificativa">Utilize este parâmetro para eventos de Cancelamento, Operação Não Realizada, etc</param>
    public async Task<Schemas.NFe.RetornoEnvioEvento> EnvioEventoAsync(
        string cnpjCpf,
        string chave,
        Schemas.NFe.CodigoEvento tpEvento,
        Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao,
        string justificativa = null)
    {
        //! validações iniciais:
        if (!string.IsNullOrEmpty(chave) && chave.Length != 44)
            throw new ArgumentException("A chave informada não é válida");

        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


        //! execução
        var request = new Contracts.RecepcaoEvento4Request();
        Schemas.NFe.Evento evento = new()
        {
            InformacaoEvento = new()
            {
                Ambiente = ambiente,
                ChaveNFe = chave,
                CNPJ_CPF = cnpjCpf,
                PersonalidadeJuridica = cnpjCpf.IsValidCNPJ() ? Schemas.NFe.PersonalidadeJuridica.CNPJ : Schemas.NFe.PersonalidadeJuridica.CPF,
                EventoDetalhes = new()
                {
                    Versao = Schemas.NFe.VersaoServicoEvento.Versao_1_00,
                    Justificativa = justificativa
                },
                EventoCodigo = tpEvento,
                EventoData = DateTime.Now,
                EventoNumeroSequencial = "1",
                Orgao = Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS,
                EventoVersao = "1.00",
            },
            Versao = "1.00"
        };
        XmlDocument eventoXml = new();
        eventoXml.LoadXml(evento.Serialize().RemoveW3CNamespaces());
        Certificado.SignXml(eventoXml, "evento", "infEvento", false, false);

        Schemas.NFe.PedidoEnvioEvento dados = new()
        {
            Lote = "000000000000001",
            Versao = "1.00"
        };
        XmlDocument dadosXml = new();
        dadosXml.LoadXml(dados.Serialize().RemoveW3CNamespaces());
        dadosXml.GetElementsByTagName("envEvento").Item(0).AppendChild(dadosXml.ImportNode(eventoXml.DocumentElement, true));

        request.nfeDadosMsg = dadosXml.DocumentElement;
        return await ExecuteAsync<SoapClients.RecepcaoEvento4SoapClient, Schemas.NFe.RetornoEnvioEvento>(request); ;
    }
}
