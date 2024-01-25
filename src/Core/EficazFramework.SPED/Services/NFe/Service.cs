using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Services.Primitives;

namespace EficazFramework.SPED.Services.NFe;

public class NFeService : SoapServiceBase
{

    /// <summary>
    /// Efetua a consulta de protocolo de NF-e / NFC-e
    /// </summary>
    /// <param name="chave">Chave da NF-e ou NFC-e para consulta</param>
    /// <param name="ambiente">Produção ou Homologação</param>
    public async Task<string> ConsultaProtocoloAsync(string chave, Ambiente ambiente = Ambiente.Producao)
    {
        //! validações iniciais:
        if (chave.Length != 44)
            throw new ArgumentException("A chave informada não é válida");

        if (!ValidaCertificado())
            throw new ArgumentNullException("Certificado", "Nenhum certificado digital foi fornecido para a requisição.");


        //! montagem dos argumentos:
        string uf = ((OrgaoIBGE)int.Parse(chave[..2])).ToString();
        string modelo = chave[20..22];


        //! execução:
        var request = new Contracts.nfeConsultaNFRequest();
        var dados = new Schemas.NFe.PedidoConsultaSituacaoNFe()
        {
            Ambiente = ambiente,
            ChaveNFe = chave,
            Versao = VersaoServicoConsSitNFe.Versao_4_00
        };
        var xml = new XmlDocument();
        xml.LoadXml(dados.Serialize());
        var node = xml.DocumentElement;
        Debug.WriteLine(node.OuterXml);
        var teste = await ExecuteAsync<SoapClients.NFeConsultaProtocolo4SoapClient>(request, uf.ToString(), modelo); ;
        return "todo";
    }
}
