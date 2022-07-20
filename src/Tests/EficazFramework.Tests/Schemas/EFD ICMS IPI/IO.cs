using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

internal class IO
{
    private static async Task<EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao> ReadInternal()
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(Resources.Schemas.EFD_ICMS_IPI.layout2020);
        writer.Flush();
        stream.Position = 0;

        EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = new();
        await escrituracao.LeArquivo(stream);
        return escrituracao;

    }

    [Test]
    public async Task Read()
    {
        EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = await ReadInternal();
        escrituracao.Should().NotBeNull();

        // Bloco O
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0001").Should().Be(1);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0005").Should().Be(1);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0100").Should().Be(1);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0150").Should().Be(41);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0190").Should().Be(5);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0200").Should().Be(65);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0400").Should().Be(7);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0460").Should().Be(1);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0990").Should().Be(1);
        // Bloco B
        escrituracao.Blocos["B"].Registros.Count(reg => reg.Codigo == "B001").Should().Be(1);
        escrituracao.Blocos["B"].Registros.Count(reg => reg.Codigo == "B990").Should().Be(1);
        // Bloco C
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C001").Should().Be(1);
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C100").Should().Be(4536);
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C170").Should().Be(229);
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C190").Should().Be(4627);
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C195").Should().Be(6);
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C197").Should().Be(6);
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C500").Should().Be(1);
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C590").Should().Be(1);
        escrituracao.Blocos["C"].Registros.Count(reg => reg.Codigo == "C990").Should().Be(1);
        // Bloco D
        escrituracao.Blocos["D"].Registros.Count(reg => reg.Codigo == "D001").Should().Be(1);
        escrituracao.Blocos["D"].Registros.Count(reg => reg.Codigo == "D990").Should().Be(1);
        // Bloco E
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E001").Should().Be(1);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E100").Should().Be(1);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E111").Should().Be(1);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E113").Should().Be(1);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E115").Should().Be(2);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E116").Should().Be(2);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E990").Should().Be(1);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E300").Should().Be(1);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E310").Should().Be(1);
        escrituracao.Blocos["E"].Registros.Count(reg => reg.Codigo == "E990").Should().Be(1);
        // Bloco G
        escrituracao.Blocos["G"].Registros.Count(reg => reg.Codigo == "G001").Should().Be(1);
        escrituracao.Blocos["G"].Registros.Count(reg => reg.Codigo == "G990").Should().Be(1);
        // Bloco H
        escrituracao.Blocos["H"].Registros.Count(reg => reg.Codigo == "H001").Should().Be(1);
        escrituracao.Blocos["H"].Registros.Count(reg => reg.Codigo == "H990").Should().Be(1);
        // Bloco I
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1001").Should().Be(1);
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1010").Should().Be(1);
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1300").Should().Be(150);
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1310").Should().Be(150);
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1320").Should().Be(240);
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1350").Should().Be(4);
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1360").Should().Be(6);
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1370").Should().Be(8);
        escrituracao.Blocos["1"].Registros.Count(reg => reg.Codigo == "1990").Should().Be(1);
        // Bloco K
        escrituracao.Blocos["K"].Registros.Count(reg => reg.Codigo == "K001").Should().Be(1);
        escrituracao.Blocos["K"].Registros.Count(reg => reg.Codigo == "K990").Should().Be(1);

    }
}
