using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Services.Primitives;
using EficazFramework.SPED.Utilities.XML;

namespace EficazFramework.SPED.Services.CTe;

public class CTeService : SoapServiceBase
{
    ///// <summary>
    ///// Efetua a consulta de protocolo de CT-e / CT-eOS
    ///// </summary>
    ///// <param name="chave">Chave da CT-e ou CT-eOS para consulta</param>
    ///// <param name="ambiente">Produção ou Homologação</param>
    //public async Task<Schemas.NFe.RetornoConsultaSituacaoNFe> ConsultaProtocolo4Async(
    //    string chave,
    //    Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
    //{
    //    //! validações iniciais:
    //    if (chave.Length != 44)
    //        throw new ArgumentException("A chave informada não é válida");

    //    if (!ValidaCertificado())
    //        throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


    //    //! montagem dos argumentos:
    //    string uf = ((Schemas.NFe.OrgaoIBGE)int.Parse(chave[..2])).ToString();
    //    string modelo = chave[20..22];


    //    //! execução:
    //    var request = new Contracts.nfeConsultaNFRequest();
    //    var dados = new Schemas.NFe.PedidoConsultaSituacaoNFe()
    //    {
    //        Ambiente = ambiente,
    //        ChaveNFe = chave,
    //        Versao = Schemas.NFe.VersaoServicoConsSitNFe.Versao_4_00
    //    };
    //    request.nfeDadosMsg = dados.SerializeToXMLDocument().DocumentElement;
    //    return await ExecuteAsync<SoapClients.NFeConsultaProtocolo4SoapClient, Schemas.NFe.RetornoConsultaSituacaoNFe>(request, uf, modelo); ;
    //}



    ///// <summary>
    ///// Executa a chamada ao WebService de envio de eventos para um CT-e
    ///// </summary>
    ///// <param name="cnpjCpf">CNPJ ou CPF do Autor do Evento</param>
    ///// <param name="chave">Informar chave da NF-e</param>
    ///// <param name="tpEvento">Cancelamento, Ciência, Confirmação, Recusa, etc.</param>
    ///// <param name="justificativa">Utilize este parâmetro para eventos de Cancelamento, Operação Não Realizada, etc</param>
    //public async Task<Schemas.NFe.RetornoEnvioEvento> EnvioEventoAsync(
    //    string cnpjCpf,
    //    string chave,
    //    Schemas.NFe.CodigoEvento tpEvento,
    //    Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao,
    //    string justificativa = null)
    //{
    //    //! validações iniciais:
    //    if (!string.IsNullOrEmpty(chave) && chave.Length != 44)
    //        throw new ArgumentException("A chave informada não é válida");

    //    if (!ValidaCertificado())
    //        throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


    //    //! execução
    //    var request = new Contracts.RecepcaoEvento4Request();
    //    Schemas.NFe.Evento evento = new()
    //    {
    //        InformacaoEvento = new()
    //        {
    //            Ambiente = ambiente,
    //            ChaveNFe = chave,
    //            CNPJ_CPF = cnpjCpf,
    //            PersonalidadeJuridica = cnpjCpf.IsValidCNPJ() ? Schemas.NFe.PersonalidadeJuridica.CNPJ : Schemas.NFe.PersonalidadeJuridica.CPF,
    //            EventoDetalhes = new()
    //            {
    //                Versao = Schemas.NFe.VersaoServicoEvento.Versao_1_00,
    //                Justificativa = justificativa
    //            },
    //            EventoCodigo = tpEvento,
    //            EventoData = DateTime.Now,
    //            EventoNumeroSequencial = "1",
    //            Orgao = Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS,
    //            EventoVersao = "1.00",
    //        },
    //        Versao = "1.00"
    //    };
    //    XmlDocument eventoXml = new();
    //    eventoXml.LoadXml(evento.Serialize().RemoveW3CNamespaces());
    //    Certificado.SignXml(eventoXml, "evento", "infEvento", false, false);

    //    Schemas.NFe.PedidoEnvioEvento dados = new()
    //    {
    //        Lote = "000000000000001",
    //        Versao = "1.00"
    //    };
    //    XmlDocument dadosXml = new();
    //    dadosXml.LoadXml(dados.Serialize().RemoveW3CNamespaces());
    //    dadosXml.GetElementsByTagName("envEvento").Item(0).AppendChild(dadosXml.ImportNode(eventoXml.DocumentElement, true));

    //    request.nfeDadosMsg = dadosXml.DocumentElement;
    //    return await ExecuteAsync<SoapClients.RecepcaoEvento4SoapClient, Schemas.NFe.RetornoEnvioEvento>(request); ;
    //}



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
