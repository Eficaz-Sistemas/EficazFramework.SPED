using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;

namespace EficazFrameworkCore.SPED.Schemas;

internal class EFD_ICMS_IPI
{
    [Test]
    public async Task Read()
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(Resources.Schemas.EFD_ICMS_IPI.layout2020);
        writer.Flush();
        stream.Position = 0;

        EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = new();
        await escrituracao.LeArquivo(stream);
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
        // ... cooming soon ...
    }
}
