using Microsoft.VisualBasic;

namespace EficazFramework.SPED.Services.NFe;

public class AutorizacaoTests : BaseNFeTests
{
    /// <summary>
    /// NOTA: É esperado que este teste resulte sempre em rejeição por duplicidade,
    /// pois sempre tentará enviar a mesma NFe (chave, número, etc). <br/><br/>
    /// Tal fato pode ser compreendido como sucesso, no contexto de que os textes são de 
    /// comunicação e schema do XML enviado.
    /// </summary>
    [Test]
    public async Task AutorizacaoSincronoAsync()
    {
        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificadoAutorizacao; // aqui estamos fazendo algumas mudanças para usar outro certificado
        var result = await client.Autoriza4Async(Schemas.Mock.NFe.PreencheNFeFake(), $"{1:000000000}", Schemas.NFe.Ambiente.Homologacao);
        result.Should().NotBeNull();    
        //result.ChaveNFe.Should().Be(chave);
        //result.Ambiente.Should().Be(ambiente);
        //result.RetornoCodigo.Should().Be(resultadoCodigo);
        //result.ProtocoloNFe.Should().NotBeNull();
        //result.ProtocoloNFe.InformacoesProtocolo.Should().NotBeNull();
        //result.ProtocoloNFe.InformacoesProtocolo.Ambiente.Should().Be(ambiente);
        //result.ProtocoloNFe.InformacoesProtocolo.ChaveNFe.Should().Be(chave);
    }





    /// <summary>
    /// Define o certificado digital a ser utilizado nas requests.
    /// </summary>
    /// <returns></returns>
    internal Func<Utilities.IcpBrasilX509Certificate2> InstanciaCertificadoAutorizacao => () =>
    {
        string path = Configuration["SSL:NFEAUTH:CertificatePath"];
        if (!string.IsNullOrEmpty(path) && Path.Exists(path))
            return new Utilities.IcpBrasilX509Certificate2(path, Configuration["SSL:NFEAUTH:CertificatePassword"]);

        return new Utilities.IcpBrasilX509Certificate2(Resources.Certificados.WayneEnterprisesInc, "1234");
    };

}
