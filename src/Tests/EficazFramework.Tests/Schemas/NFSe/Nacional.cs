using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Schemas.NFSe.Nacional;
using EficazFramework.SPED.Tests;

namespace EficazFramework.SPED.Schemas.NFSe;

public class NFSeNacional : BaseXmlTest<Nacional.NFSe>
{
    [Test]
    public async Task Read()
    {
        Nacional.NFSe instance = await ReadAsync(Resources.Schemas.XML.NFSe_Nacional_1_0_1);
        instance.Should().NotBeNull();

        instance.Chave.Should().Be("NFS3510000004900099000019700000000000006010200049010");
        instance.InfNFSe.LocalEmissao.Should().Be("FRANCA");
        instance.InfNFSe.LocalPrestacao.Should().Be("Franca");
        instance.InfNFSe.Numero.Should().Be(113);
        instance.InfNFSe.LocalIncidenciaCodigo.Should().Be("3516200");
        instance.InfNFSe.LocalIncidenciaNome.Should().Be("Franca");
        instance.InfNFSe.TributacaoNacional.Should().Be("Contabilidade, inclusive serviços técnicos e auxiliares.");
        instance.InfNFSe.VersaoAplicativoGerador.Should().Be("SilTecnologia_v1.00");
        instance.InfNFSe.ambGer.Should().Be(AmbienteGerador.Prefeitura);
        instance.InfNFSe.tpEmis.Should().Be(TipoEmissao.LeiauteMunicipal);
        instance.InfNFSe.cStat.Should().Be("100");
        instance.InfNFSe.DataHoraProcessamento.Should().Be(new DateTimeOffset(new DateTime(2026, 01, 10)));
        instance.InfNFSe.NumeroSequencial.Should().Be("27644971");
        
        instance.InfNFSe.Emitente.Should().NotBeNull();
        instance.InfNFSe.Emitente.CNPJ.Should().Be("11222333000144");
        instance.InfNFSe.Emitente.InscricaoMunicipal.Should().Be("117915");
        instance.InfNFSe.Emitente.RazaoSocialNome.Should().Be("ORGANIZAÇÃO CONTÁBIL");
        instance.InfNFSe.Emitente.EnderecoNacional.Should().NotBeNull();
        instance.InfNFSe.Emitente.EnderecoNacional.Logradouro.Should().Be("14400-000 - Rua da Nota, 1215   SALA 80");
        instance.InfNFSe.Emitente.EnderecoNacional.Numero.Should().Be("0");
        instance.InfNFSe.Emitente.EnderecoNacional.Bairro.Should().Be("Centro");
        instance.InfNFSe.Emitente.EnderecoNacional.MunicipioCodigo.Should().Be("3516200");
        instance.InfNFSe.Emitente.EnderecoNacional.UF.Should().Be("SP");
        instance.InfNFSe.Emitente.EnderecoNacional.CEP.Should().Be("14400000");
        instance.InfNFSe.Emitente.Telefone.Should().Be("9912345678");
        instance.InfNFSe.Emitente.EMail.Should().Be("admin@fakemail.com");

    }

    //[Test]
    //public async Task ParseLote()
    //{
    //    var folder = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Samples", "NFseNacional");
    //    if (Directory.Exists(folder))
    //    {
    //        var files = Directory.GetFiles(folder, "*.xml");
    //        foreach (var file in files)
    //        {
    //            Console.WriteLine($"Processing file: {file}");
    //            var doc = await ReadAsync(await File.ReadAllTextAsync(file));
    //            doc.Should().NotBeNull();
    //            Console.WriteLine($"✅ Parsed document type: {doc.DocumentType}. Chave: {doc.Chave}");

    //        }
    //    }
    //    else
    //    {
    //        Assert.Fail($"Test folder does not exist: {folder}");
    //    }
    //}
}