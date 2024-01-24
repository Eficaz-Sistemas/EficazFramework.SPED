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
    public async Task<object> ConsultaProtocoloAsync(string chave, Ambiente ambiente = Ambiente.Producao)
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
        var teste = await ExecuteAsync<SoapClients.NfeConsultaProtocolo4>(null, modelo, uf.ToString());
       return "todo";
    }
}
