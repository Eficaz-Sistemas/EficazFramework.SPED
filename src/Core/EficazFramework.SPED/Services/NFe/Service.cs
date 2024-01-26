using EficazFramework.SPED.Services.Primitives;

namespace EficazFramework.SPED.Services.NFe;

public class NFeService : SoapServiceBase
{
    /// <summary>
    /// Efetua a consulta de protocolo de NF-e / NFC-e na versão 4.00
    /// </summary>
    /// <param name="chave">Chave da NF-e ou NFC-e para consulta</param>
    /// <param name="ambiente">Produção ou Homologação</param>
    public async Task<Schemas.NFe.RetornoConsultaSituacaoNFe> ConsultaProtocolo4Async(string chave, Schemas.NFe.Ambiente ambiente = Schemas.NFe.Ambiente.Producao)
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
        var xml = new XmlDocument();
        xml.LoadXml(dados.Serialize());
        var node = xml.DocumentElement;
        request.nfeDadosMsg = node;
        return await ExecuteAsync<SoapClients.NFeConsultaProtocolo4SoapClient, Schemas.NFe.RetornoConsultaSituacaoNFe>(request, uf, modelo); ;
    }
}
