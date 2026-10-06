using Microsoft.VisualBasic;
#nullable enable

namespace EficazFramework.SPED.Services.NFSe.Nacional;

public class AutorizacaoTests : BaseNFseTests
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
        var dps = Schemas.Mock.NFSe.PreencheNFSeNacionalDpsFake();
        Console.WriteLine($"DPS string: {Environment.NewLine}{dps.Serialize()}");
        var result = await client.EmitirDpsAsync(dps, Schemas.NFSe.Nacional.Ambiente.Homologacao);
        result.Should().NotBeNull();
        foreach (var erro in result.Erros ?? [])
        {
            Console.WriteLine($"Erro: {erro.Codigo} - {erro.Descricao}");
        };
        result.TipoAmbiente.Should().Be(Schemas.NFSe.Nacional.Ambiente.Homologacao);
        //result.StatusCode.Should().Be(201);
        //result.ChaveAcesso.Should().NotBeNull();
        //result.Erros.Should().BeNullOrEmpty();
    }

    /// <summary>
    /// Define o certificado digital a ser utilizado nas requests.
    /// </summary>
    /// <returns></returns>
    internal Func<Utilities.IcpBrasilX509Certificate2> InstanciaCertificadoAutorizacao => () =>
        {
            string path = Configuration["SSL:NFEAUTH:CertificatePath"]!;
            if (!string.IsNullOrEmpty(path) && Path.Exists(path))
                return new Utilities.IcpBrasilX509Certificate2(path, Configuration["SSL:NFEAUTH:CertificatePassword"]!);

            return new Utilities.IcpBrasilX509Certificate2(Resources.Certificados.WayneEnterprisesInc, "1234");
        };
}
