using Microsoft.VisualBasic;

namespace EficazFramework.SPED.Services.NFe;

public class AutorizacaoTests : BaseNFeTests
{
    /// <summary>
    /// NOTA: É esperado que este teste resulte sempre em rejeição por duplicidade,
    /// pois sempre tentará enviar a mesma NFe (chave, número, etc). <br/><br/>
    /// Tal fato pode ser compreendido como sucesso, no contexto de que os textes são de 
    /// comunicação e schema do XML enviado.
    /// </summary>
    [Test]
    public async Task AutorizacaoSincronoAsync()
    {
        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificadoAutorizacao; // aqui estamos fazendo algumas mudanças para usar outro certificado
        var result = await client.Autoriza4Async(Schemas.Mock.NFe.PreencheNFeFake(), $"{1:000000000}", Schemas.NFe.Ambiente.Homologacao);
        result.Should().NotBeNull();
        result.Ambiente.Should().Be(Schemas.NFe.Ambiente.Homologacao);
        result.RetornoCodigo.Should().Be("104");
        result.ProtocoloRecebimento.Should().NotBeNull();
        result.ProtocoloRecebimento.InformacoesProtocolo.StatusNFeCodigo.Should().Be("230"); //Emitente não cadastrado para emissão de NFe
    }


    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homnfe.sefaz.am.gov.br/services2/services/NfeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.sefaz.ba.gov.br/webservices/NFeAutorizacao4/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.sefazvirtual.fazenda.gov.br/NFeAutorizacao4/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfe.sefaz.ms.gov.br/ws/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.am.gov.br/services2/services/NfeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ba.gov.br/webservices/NFeAutorizacao4/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://www.sefazvirtual.fazenda.gov.br/NFeAutorizacao4/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.ms.gov.br/ws/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefa.pr.gov.br/nfe/NFeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homnfce.sefaz.am.gov.br/nfce-services/services/NfeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homolog.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hnfce.fazenda.mg.gov.br/nfce/services/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hom.nfce.sefaz.ms.gov.br/ws/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.sefaz.mt.gov.br/nfcews/services/NfeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfce.sefa.pr.gov.br/nfce/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://nfce-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AL, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AM, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.am.gov.br/nfce-services/services/NfeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.CE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.DF, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.ES, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.GO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.fazenda.mg.gov.br/nfce/services/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.ms.gov.br/ws/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefaz.mt.gov.br/nfcews/services/NfeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PA, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PB, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PI, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefa.pr.gov.br/nfce/NFeAutorizacao4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RJ, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RN, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SC, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SE, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.fazenda.sp.gov.br/ws/NFeAutorizacao4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.ModeloDocumento.NFCe, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfce.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx")]
    public string VerificaUrls(
    Schemas.NFe.OrgaoIBGE uf,
    Schemas.NFe.ModeloDocumento modelo,
    Schemas.NFe.Ambiente ambiente)
    {
        var client = CreateClient<SoapClients.NFeAutorizacao4SoapClient>(uf.ToString(), modelo.ToString(), ambiente.ToString());
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
