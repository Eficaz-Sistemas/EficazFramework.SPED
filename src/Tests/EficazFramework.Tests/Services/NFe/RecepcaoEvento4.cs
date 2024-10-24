namespace EficazFramework.SPED.Services.NFe;

public class RecepcaoEvento4Tests : BaseNFeTests
{
    [Test]
    [TestCase("31240209041929000133550010000273651000332943")]
    public async Task CienciaOperacaoTest(string chave)
    {
        var client = CreateClient();
        var result = await client.EnvioEventoAsync(Configuration["SSL:NFE:CertificateCnpjCpf"], chave, Schemas.NFe.CodigoEvento.Ciencia, Schemas.NFe.Ambiente.Homologacao, null);
        result.Should().NotBeNull();

        result.RespostaCodigo.Should().Be("128"); 
        result.ResultadoEventos.Should().HaveCount(1);
        result.ResultadoEventos[0].InformacaoEventoRetorno.RespostaCodigo.Should().BeOneOf("136", "252", "573");
        result.ResultadoEventos[0].InformacaoEventoRetorno.EventoCodigo.Should().Be(Schemas.NFe.CodigoEvento.Ciencia);
        result.ResultadoEventos[0].InformacaoEventoRetorno.ChaveNFe.Should().Be(chave);
    }


    [Test]
    [TestCase("31240209041929000133550010000273651000332943")]
    public async Task CancelamentoTest(string chave)
    {
        var client = CreateClient();
        var result = await client.EnvioEventoAsync(Configuration["SSL:NFE:CertificateCnpjCpf"], chave, Schemas.NFe.CodigoEvento.Cancelamento, Schemas.NFe.Ambiente.Homologacao, null);
        result.Should().NotBeNull();
        // o documento não existe em homologação, mas ao menos asseguramos conformidade ao schema do XML formado,
        // além de verificar que a tag cOrgao em fato utilizou o código da UF do emitente do documento fiscal.
        result.RespostaCodigo.Should().Be("999"); 
    }



    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.SefazNacional_AN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom1.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homnfe.sefaz.am.gov.br/services2/services/RecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.sefaz.ba.gov.br/webservices/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/NFeRecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.sefazvirtual.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfe.sefaz.ms.gov.br/ws/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/RecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeRecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeRecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nferecepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SefazNacional_AN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://www.nfe.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.am.gov.br/services2/services/RecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ba.gov.br/webservices/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeRecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://www.sefazvirtual.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ms.gov.br/ws/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/RecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefa.pr.gov.br/nfe/NFeRecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/ws/nferecepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homnfce.sefaz.am.gov.br/nfce-services/services/RecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/NFeRecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfce.fazenda.mg.gov.br/nfce/services/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfce.sefaz.ms.gov.br/ws/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfcews/services/RecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfce.sefa.pr.gov.br/nfce/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeRecepcaoEvento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.am.gov.br/nfce-services/services/RecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeRecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.ms.gov.br/ws/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeRecepcaoEvento4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefa.pr.gov.br/nfce/NFeRecepcaoEvento4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.fazenda.sp.gov.br/ws/NFeRecepcaoEvento4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
    public string VerificaUrls(
        Schemas.NFe.OrgaoIBGE uf,
        Schemas.NFe.ModeloDocumento modelo,
        Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient<SoapClients.RecepcaoEvento4SoapClient>(uf.ToString(), modelo.ToString(), ambiente.ToString());
        return client.Endpoint.Address.Uri.AbsoluteUri;
    }


}
