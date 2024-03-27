namespace EficazFramework.SPED.Services.NFe;

public class ConsultaCadastroTests : BaseNFeTests
{
    [Test]
    [TestCase("10608025000126", Schemas.NFe.TipoPesquisaCadastro.CNPJ, Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.Ambiente.Homologacao, "111")]
    [TestCase("00073030000128", Schemas.NFe.TipoPesquisaCadastro.CNPJ, Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.Ambiente.Homologacao, "259")]
    public async Task ConsultaCadastroAsync(
        string cnpjCPF,
        Schemas.NFe.TipoPesquisaCadastro tpPesquisa, 
        Schemas.NFe.OrgaoIBGE uf, 
        Schemas.NFe.Ambiente ambiente, 
        string resultadoCodigo)
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


    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.sefaz.ba.gov.br/webservices/CadConsultaCadastro4/CadConsultaCadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/CadConsultaCadastro4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.fazenda.mg.gov.br/nfe2/services/CadConsultaCadastro4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfe.sefaz.ms.gov.br/ws/CadConsultaCadastro4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/CadConsultaCadastro4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/CadConsultaCadastro4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.sefa.pr.gov.br/nfe/CadConsultaCadastro4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad.sefazrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cad-homologacao.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ba.gov.br/webservices/CadConsultaCadastro4/CadConsultaCadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/CadConsultaCadastro4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.mg.gov.br/nfe2/services/CadConsultaCadastro4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ms.gov.br/ws/CadConsultaCadastro4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/CadConsultaCadastro4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.pe.gov.br/nfe-service/services/CadConsultaCadastro4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefa.pr.gov.br/nfe/CadConsultaCadastro4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.sefazrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cad.svrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx")]
    public string VerificaUrls(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient<SoapClients.CadConsultaCadastro4SoapClient>(uf.ToString(), ambiente.ToString());
        return client.Endpoint.Address.Uri.AbsoluteUri ;
    }
}
