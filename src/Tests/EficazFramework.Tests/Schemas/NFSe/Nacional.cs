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
        instance.InfNFSe.xLocEmi.Should().Be("FRANCA");
        instance.InfNFSe.xLocPrestacao.Should().Be("Franca");
        instance.InfNFSe.nNFSe.Should().Be(113);
        instance.InfNFSe.cLocIncid.Should().Be("3516200");
        instance.InfNFSe.xLocIncid.Should().Be("Franca");
        instance.InfNFSe.xTribNac.Should().Be("Contabilidade, inclusive serviços técnicos e auxiliares.");
        instance.InfNFSe.verAplic.Should().Be("SilTecnologia_v1.00");
        instance.InfNFSe.ambGer.Should().Be(AmbienteGerador.Prefeitura);
        instance.InfNFSe.tpEmis.Should().Be(TipoEmissao.LeiauteMunicipal);
        instance.InfNFSe.cStat.Should().Be("100");
        instance.InfNFSe.dhProc.Should().Be(new DateTimeOffset(new DateTime(2026, 01, 10)));
        instance.InfNFSe.nDFSe.Should().Be("27644971");
        
        instance.InfNFSe.emit.Should().NotBeNull();
        instance.InfNFSe.emit.CNPJ.Should().Be("11222333000144");
        instance.InfNFSe.emit.IM.Should().Be("117915");
        instance.InfNFSe.emit.xNome.Should().Be("ORGANIZAÇÃO CONTÁBIL");
        instance.InfNFSe.emit.enderNac.Should().NotBeNull();
        instance.InfNFSe.emit.enderNac.xLgr.Should().Be("14400-000 - Rua da Nota, 1215   SALA 80");
        instance.InfNFSe.emit.enderNac.nro.Should().Be("0");
        instance.InfNFSe.emit.enderNac.xBairro.Should().Be("Centro");
        instance.InfNFSe.emit.enderNac.cMun.Should().Be("3516200");
        instance.InfNFSe.emit.enderNac.UF.Should().Be("SP");
        instance.InfNFSe.emit.enderNac.CEP.Should().Be("14400000");
        instance.InfNFSe.emit.fone.Should().Be("9912345678");
        instance.InfNFSe.emit.email.Should().Be("admin@fakemail.com");

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