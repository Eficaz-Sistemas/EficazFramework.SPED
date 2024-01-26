namespace EficazFramework.SPED.Services.NFe;

public class ConsultaCadastroTests : BaseNFeTests
{
    [Test]
    [TestCase("10608025000126", Schemas.NFe.TipoPesquisaCadastro.CNPJ, Schemas.NFe.OrgaoIBGE.MG, "111")]
    [TestCase("00073030000128", Schemas.NFe.TipoPesquisaCadastro.CNPJ, Schemas.NFe.OrgaoIBGE.MG, "259")]
    public async Task ConsultaCadastroAsync(string cnpjCPF, Schemas.NFe.TipoPesquisaCadastro tpPesquisa, Schemas.NFe.OrgaoIBGE uf, string resultadoCodigo)
    {
        var client = CreateClient();
        var result = await client.ConsultaCadastro4Async(cnpjCPF, tpPesquisa, uf);
        result.Should().NotBeNull();
        result.Informacoes.Codigo.Should().Be(resultadoCodigo);
        result.Informacoes.Uf.Should().Be(uf);
        if (int.Parse(result.Informacoes.Codigo) < 120)
            result.Informacoes.Documento.Should().Be(cnpjCPF);
        else
            result.Informacoes.Documento.Should().BeNull();
    }
}
