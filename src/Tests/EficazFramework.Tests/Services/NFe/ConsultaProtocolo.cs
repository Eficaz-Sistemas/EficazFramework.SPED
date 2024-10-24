namespace EficazFramework.SPED.Services.NFe;

public class ConsultaProtocoloTests : BaseNFeTests
{
    [Test]
    [TestCase("31240261156501011000550110001321351664476971", SPED.Schemas.NFe.Ambiente.Producao, "100")]
    [TestCase("31240134557109000146550010000001011828480400", SPED.Schemas.NFe.Ambiente.Producao, "101")]
    public async Task ConsultaProtocoloAsync(string chave, SPED.Schemas.NFe.Ambiente ambiente, string resultadoCodigo)
    {
        var client = CreateClient();
        var result = await client.ConsultaProtocolo4Async(chave, ambiente);
        result.Should().NotBeNull();    
        result.ChaveNFe.Should().Be(chave);
        result.Ambiente.Should().Be(ambiente);
        result.RetornoCodigo.Should().Be(resultadoCodigo);
        result.ProtocoloNFe.Should().NotBeNull();
        result.ProtocoloNFe.InformacoesProtocolo.Should().NotBeNull();
        result.ProtocoloNFe.InformacoesProtocolo.Ambiente.Should().Be(ambiente);
        result.ProtocoloNFe.InformacoesProtocolo.ChaveNFe.Should().Be(chave);
    }


    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homnfe.sefaz.am.gov.br/services2/services/NfeConsulta4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.sefaz.ba.gov.br/webservices/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.am.gov.br/services2/services/NfeConsulta4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ba.gov.br/webservices/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homnfce.sefaz.am.gov.br/nfce-services/services/NfeConsulta4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfce.fazenda.mg.gov.br/nfce/services/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfce.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfcews/services/NfeConsulta4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfce.sefa.pr.gov.br/nfce/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeConsultaProtocolo4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.am.gov.br/nfce-services/services/NfeConsulta4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.mt.gov.br/nfcews/services/NfeConsulta4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefa.pr.gov.br/nfce/NFeConsultaProtocolo4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.fazenda.sp.gov.br/ws/NFeConsultaProtocolo4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx")]

    public string VerificaUrls(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo,
        Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient<SoapClients.NFeConsultaProtocolo4SoapClient>(uf.ToString(), modelo.ToString(), ambiente.ToString());
        return client.Endpoint.Address.Uri.AbsoluteUri;
    }

}
