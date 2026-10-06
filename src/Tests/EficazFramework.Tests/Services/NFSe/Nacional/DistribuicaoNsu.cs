namespace EficazFramework.SPED.Services.NFSe.Nacional;
#nullable enable

public class DistribuicaoNsuTests : BaseNFseTests
{
    [Test]
    [TestCase((long)0, null, null)]
    [TestCase((long)0, "10608025000126", false)]
    [TestCase((long)0, "10608025000126", true)]
    public async Task ConsultarDfePorNsuAsync(long nsu, string? cnpj, bool? lote)
    {
        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificadoAutorizacao;

        var result = await client.ConsultarDfePorNsuAsync(
            nsu: nsu,
            cnpjConsulta: cnpj,
            lote: lote,
            ambiente: Schemas.NFSe.Nacional.Ambiente.Homologacao);

        result.Should().NotBeNull();
        Console.WriteLine($"StatusCode: {result.StatusCode}");
        Console.WriteLine($"StatusProcessamento: {result.StatusProcessamento}");
        Console.WriteLine($"VersaoAplicativo: {result.VersaoAplicativo}");
        Console.WriteLine($"DataHoraProcessamento: {result.DataHoraProcessamento}");
        Console.WriteLine($"Itens LoteDFe: {result.LoteDFe?.Count ?? 0}");

        if (result.LoteDFe != null)
        {
            foreach (var item in result.LoteDFe)
            {
                Console.WriteLine($"  - NSU: {item.NSU}, Chave: {item.ChaveAcesso}, TipoDoc: {item.TipoDocumento}, Evento: {item.TipoEvento}");
                if (!string.IsNullOrWhiteSpace(item.ArquivoXml))
                {
                    item.XmlDocumento.Should().NotBeNullOrWhiteSpace();
                    Console.WriteLine($"    XML Descompactado (tamanho): {item.XmlDocumento?.Length} chars");
                }
            }
        }

        if (result.Alertas != null)
        {
            foreach (var alerta in result.Alertas)
                Console.WriteLine($"  [Alerta] {alerta.Codigo} - {alerta.Descricao} ({alerta.Complemento})");
        }

        if (result.Erros != null)
        {
            foreach (var erro in result.Erros)
                Console.WriteLine($"  [Erro] {erro.Codigo} - {erro.Descricao} ({erro.Complemento})");
        }

        result.StatusCode.Should().BeOneOf(200, 400, 404);
        if (result.StatusCode == 200)
        {
            result.Sucesso.Should().BeTrue();
            result.StatusProcessamento.Should().NotBeNull();
        }
    }

    /// <summary>
    /// Define o certificado digital a ser utilizado nas requests.
    /// </summary>
    internal Func<Utilities.IcpBrasilX509Certificate2> InstanciaCertificadoAutorizacao => () =>
    {
        string path = Configuration["SSL:NFEAUTH:CertificatePath"]!;
        if (!string.IsNullOrEmpty(path) && Path.Exists(path))
            return new Utilities.IcpBrasilX509Certificate2(path, Configuration["SSL:NFEAUTH:CertificatePassword"]!);

        return new Utilities.IcpBrasilX509Certificate2(Resources.Certificados.WayneEnterprisesInc, "1234");
    };
}
