using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;

namespace EficazFramework.SPED.Schemas.LCDPR.BaseTests;

internal class IO
{
    private static async Task<EficazFramework.SPED.Schemas.LCDPR.Escrituracao> ReadInternal()
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(Resources.Schemas.LCDPR.v0013);
        writer.Flush();
        stream.Position = 0;

        EficazFramework.SPED.Schemas.LCDPR.Escrituracao escrituracao = new();
        await escrituracao.LeArquivo(stream);
        return escrituracao;

    }

    [Test]
    public async Task Read()
    {
        EficazFramework.SPED.Schemas.LCDPR.Escrituracao escrituracao = await ReadInternal();
        escrituracao.Should().NotBeNull();
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0010").Should().Be(1);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0030").Should().Be(1);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0040").Should().Be(4);
        escrituracao.Blocos["0"].Registros.Count(reg => reg.Codigo == "0050").Should().Be(1);
        escrituracao.Blocos["Q"].Registros.Count(reg => reg.Codigo == "Q100").Should().Be(1565);
        escrituracao.Blocos["Q"].Registros.Count(reg => reg.Codigo == "Q200").Should().Be(12);
        escrituracao.Blocos["9"].Registros.Count(reg => reg.Codigo == "9999").Should().Be(1);
    }

    [Test]
    public async Task ReadContribuinte()
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(Resources.Schemas.LCDPR.v0013);
        writer.Flush();
        stream.Position = 0;
        EficazFramework.SPED.Schemas.LCDPR.Escrituracao escrituracao = new();
        (await escrituracao.LeEmpresaArquivo(stream)).Should().Be("12345678900");
    }

}
