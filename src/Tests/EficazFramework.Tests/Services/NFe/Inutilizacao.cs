namespace EficazFramework.SPED.Services.NFe;

public class InutilizacaoTests : BaseNFeTests
{
    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, 75, 77, Schemas.NFe.ModeloDocumento.NFe, 99, "falha na sequencia de numeração.", SPED.Schemas.NFe.Ambiente.Homologacao)]
    public async Task InutilizaAsyncAsync(
        Schemas.NFe.OrgaoIBGE uf,
        long NfInicio, 
        long NfFim,
        Schemas.NFe.ModeloDocumento modelo, 
        int serie,
        string justificativa,
        Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificadoAutorizacao; // aqui estamos fazendo algumas mudanças para usar outro certificado
        var result = await client.InutilizaAsync(Configuration["SSL:NFEAUTH:CertificateCnpjCpf"], uf, [NfInicio, NfFim], serie, justificativa, modelo, ambiente);
        result.Should().NotBeNull();
        result.infInut.Should().NotBeNull();
        result.infInut.tpAmb.Should().Be(ambiente);
        result.infInut.cStat.Should().NotBeNull();
    }


    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homnfe.sefaz.am.gov.br/services2/services/NfeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.sefaz.ba.gov.br/webservices/NFeInutilizacao4/NFeInutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.sefazvirtual.fazenda.gov.br/NFeInutilizacao4/NFeInutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfe.sefaz.ms.gov.br/ws/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.am.gov.br/services2/services/NfeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ba.gov.br/webservices/NFeInutilizacao4/NFeInutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://www.sefazvirtual.fazenda.gov.br/NFeInutilizacao4/NFeInutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ms.gov.br/ws/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefa.pr.gov.br/nfe/NFeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homnfce.sefaz.am.gov.br/nfce-services/services/NfeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfce.fazenda.mg.gov.br/nfce/services/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfce.sefaz.ms.gov.br/ws/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfcews/services/NfeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfce.sefa.pr.gov.br/nfce/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeInutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.am.gov.br/nfce-services/services/NfeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.ms.gov.br/ws/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.mt.gov.br/nfcews/services/NfeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefa.pr.gov.br/nfce/NFeInutilizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.fazenda.sp.gov.br/ws/NFeInutilizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx")]
    public string VerificaUrls(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo,
        Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient<SoapClients.NFeInutilizacaoSoapClient>(uf.ToString(), modelo.ToString(), ambiente.ToString());
        return client.Endpoint.Address.Uri.AbsoluteUri;
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
