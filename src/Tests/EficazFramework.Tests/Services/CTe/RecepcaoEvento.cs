using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Utilities.XML;

namespace EficazFramework.SPED.Services.CTe;

public class RecepcaoEventoTests : BaseCTeTests
{
    private const string Chave = "35231029749080000164570000000034431199972606";
    private const string Cnpj = "29749080000164";

    [Test]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PE, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.AP, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RR, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SefazNacional_SVCSP, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cte.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.BA, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cte.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.TO, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cte.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SefazNacional_SVCRS, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cte.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cte.fazenda.mg.gov.br/cte/services/CTeRecepcaoEventoV4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MS, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://producao.cte.ms.gov.br/ws/CTeRecepcaoEventoV4")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MT, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cte.sefaz.mt.gov.br/ctews2/services/CTeRecepcaoEventoV4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.PR, Schemas.NFe.Ambiente.Producao, ExpectedResult = "https://cte.fazenda.pr.gov.br/cte4/CTeRecepcaoEventoV4?wsdl")]
    [TestCase(Schemas.NFe.OrgaoIBGE.SP, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.RS, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://cte-homologacao.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx")]
    [TestCase(Schemas.NFe.OrgaoIBGE.MG, Schemas.NFe.Ambiente.Homologacao, ExpectedResult = "https://hcte.fazenda.mg.gov.br/cte/services/CTeRecepcaoEventoV4")]
    public string VerificaUrls(Schemas.NFe.OrgaoIBGE uf, Schemas.NFe.Ambiente ambiente)
    {
        var client = SoapClients.CTeRecepcaoEventoV4SoapClient.Create(uf, ambiente);
        return client.Endpoint.Address.Uri.AbsoluteUri;
    }


    [Test]
    public void UrlParaOrgaoSemAutorizadorDeveFalhar()
    {
        var act = () => SoapClients.CTeRecepcaoEventoV4SoapClient.Create(Schemas.NFe.OrgaoIBGE.SefazNacional_AN, Schemas.NFe.Ambiente.Producao);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }


    [Test]
    public void SerializaEventoPrestacaoDesacordo()
    {
        var evento = CriaEvento(new Schemas.CTe.evPrestDesacordo { Observacoes = "Servico prestado em desacordo com o contratado" }, Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo);

        var doc = new XmlDocument();
        doc.LoadXml(evento.Serialize().RemoveW3CNamespaces());

        var ns = new XmlNamespaceManager(doc.NameTable);
        ns.AddNamespace("c", "http://www.portalfiscal.inf.br/cte");

        doc.DocumentElement.LocalName.Should().Be("eventoCTe");
        doc.DocumentElement.GetAttribute("versao").Should().Be("4.00");
        var inf = doc.SelectSingleNode("/c:eventoCTe/c:infEvento", ns);
        inf.Should().NotBeNull();
        var id = inf.Attributes["Id"].Value;
        id.Should().Be($"ID610110{Chave}001");
        id.Should().MatchRegex("ID[0-9]{12}[A-Z0-9]{12}[0-9]{29}");
        inf.SelectSingleNode("c:cOrgao", ns).InnerText.Should().Be("35");
        inf.SelectSingleNode("c:tpAmb", ns).InnerText.Should().Be("2");
        inf.SelectSingleNode("c:CNPJ", ns).InnerText.Should().Be(Cnpj);
        inf.SelectSingleNode("c:chCTe", ns).InnerText.Should().Be(Chave);
        inf.SelectSingleNode("c:dhEvento", ns).InnerText.Should().MatchRegex(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}[+-]\d{2}:\d{2}$");
        inf.SelectSingleNode("c:tpEvento", ns).InnerText.Should().Be("610110");
        inf.SelectSingleNode("c:nSeqEvento", ns).InnerText.Should().Be("1");

        var det = inf.SelectSingleNode("c:detEvento", ns);
        ((XmlElement)det).GetAttribute("versaoEvento").Should().Be("4.00");
        det.SelectSingleNode("c:evPrestDesacordo/c:descEvento", ns).InnerText.Should().Be("Prestacao do Servico em Desacordo");
        det.SelectSingleNode("c:evPrestDesacordo/c:indDesacordoOper", ns).InnerText.Should().Be("1");
        det.SelectSingleNode("c:evPrestDesacordo/c:xObs", ns).InnerText.Should().Be("Servico prestado em desacordo com o contratado");
        doc.SelectSingleNode("//*[local-name()='Signature']").Should().BeNull("a assinatura só é adicionada em tempo de envio");
    }


    [Test]
    public void SerializaEventoCancelamentoComCpf()
    {
        var evento = CriaEvento(new Schemas.CTe.evCancPrestDesacordo { ProtocoloEventoDesacordo = "135230000000001" }, Schemas.CTe.CodigoEvento.CancelamentoPrestacaoServicoDesacordo);
        evento.infEvento.CNPJ_CPF = "12345678909";
        evento.infEvento.ItemElementName = Schemas.CTe.PersonalidadeJuridica7.CPF;

        var xml = evento.Serialize();
        xml.Should().Contain("<CPF>12345678909</CPF>").And.NotContain("<CNPJ>");
        xml.Should().Contain("<nProtEvPrestDes>135230000000001</nProtEvPrestDes>");
        xml.Should().Contain("Id=\"ID610111" + Chave + "001\"");
    }


    [Test]
    public void AssinaEvento()
    {
        var evento = CriaEvento(new Schemas.CTe.evPrestDesacordo { Observacoes = "Servico prestado em desacordo com o contratado" }, Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo);
        var doc = new XmlDocument();
        doc.LoadXml(evento.Serialize().RemoveW3CNamespaces());
        InstanciaCertificado().SignXml(doc, "eventoCTe", "infEvento", false, false);

        var sig = doc.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#");
        sig.Count.Should().Be(1);
        doc.OuterXml.Should().Contain($"URI=\"#ID610110{Chave}001\"");
    }


    [Test]
    public void DesserializaRetornoEvento()
    {
        const string xml = """
            <retEventoCTe xmlns="http://www.portalfiscal.inf.br/cte" versao="4.00">
              <infEvento Id="ID135230000000001">
                <tpAmb>2</tpAmb>
                <verAplic>SVRS202310</verAplic>
                <cOrgao>35</cOrgao>
                <cStat>135</cStat>
                <xMotivo>Evento registrado e vinculado a CT-e</xMotivo>
                <chCTe>35231029749080000164570000000034431199972606</chCTe>
                <tpEvento>610110</tpEvento>
                <xEvento>Prestacao do Servico em Desacordo</xEvento>
                <nSeqEvento>1</nSeqEvento>
                <dhRegEvento>2023-10-20T10:00:00-03:00</dhRegEvento>
                <nProt>135230000000001</nProt>
              </infEvento>
            </retEventoCTe>
            """;

        var ret = Schemas.CTe.RetornoEvento.Deserialize(xml);
        ret.versao.Should().Be("4.00");
        ret.infEvento.Id.Should().Be("ID135230000000001");
        ret.infEvento.tpAmb.Should().Be(Schemas.NFe.Ambiente.Homologacao);
        ret.infEvento.cOrgao.Should().Be(Schemas.NFe.OrgaoIBGE.SP);
        ret.infEvento.cStat.Should().Be("135");
        ret.infEvento.chCTe.Should().Be(Chave);
        ret.infEvento.tpEvento.Should().Be("610110");
        ret.infEvento.nProt.Should().Be("135230000000001");
        ret.Chave.Should().Be(Chave);
    }


    [Test]
    public void DesserializaProcessoEvento()
    {
        const string xml = """
            <procEventoCTe xmlns="http://www.portalfiscal.inf.br/cte" versao="4.00">
              <eventoCTe versao="4.00">
                <infEvento Id="ID61011035231029749080000164570000000034431199972606001">
                  <cOrgao>35</cOrgao>
                  <tpAmb>1</tpAmb>
                  <CPF>12345678909</CPF>
                  <chCTe>35231029749080000164570000000034431199972606</chCTe>
                  <dhEvento>2023-10-20T09:00:00-03:00</dhEvento>
                  <tpEvento>610110</tpEvento>
                  <nSeqEvento>1</nSeqEvento>
                  <detEvento versaoEvento="4.00">
                    <evPrestDesacordo>
                      <descEvento>Prestacao do Servico em Desacordo</descEvento>
                      <indDesacordoOper>1</indDesacordoOper>
                      <xObs>Servico prestado em desacordo com o contratado</xObs>
                    </evPrestDesacordo>
                  </detEvento>
                </infEvento>
              </eventoCTe>
              <retEventoCTe versao="4.00">
                <infEvento>
                  <tpAmb>1</tpAmb>
                  <verAplic>SVRS202310</verAplic>
                  <cOrgao>35</cOrgao>
                  <cStat>135</cStat>
                  <xMotivo>Evento registrado e vinculado a CT-e</xMotivo>
                  <nProt>135230000000001</nProt>
                </infEvento>
              </retEventoCTe>
            </procEventoCTe>
            """;

        var proc = Schemas.CTe.ProcessoEvento.Deserialize(xml);
        proc.versao.Should().Be("4.00");
        proc.eventoCTe.versao.Should().Be("4.00");
        proc.eventoCTe.infEvento.Id.Should().Be($"ID610110{Chave}001");
        proc.eventoCTe.infEvento.CNPJ_CPF.Should().Be("12345678909");
        proc.eventoCTe.infEvento.ItemElementName.Should().Be(Schemas.CTe.PersonalidadeJuridica7.CPF);
        proc.eventoCTe.infEvento.chCTe.Should().Be(Chave);
        proc.eventoCTe.infEvento.dhEvento.Should().Be(new DateTime(2023, 10, 20, 9, 0, 0));
        proc.eventoCTe.infEvento.detEvento.versaoEvento.Should().Be("4.00");
        proc.eventoCTe.infEvento.detEvento.Any.Should().NotBeNull();
        proc.retEventoCTe.infEvento.cStat.Should().Be("135");
        proc.Chave.Should().Be($"610110{Chave}001");
    }


    [Test]
    [TestCase("123", "12345678000195", "Observacao longa o bastante", Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo)]
    [TestCase(Chave, "123", "Observacao longa o bastante", Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo)]
    [TestCase(Chave, Cnpj, "curta", Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo)]
    [TestCase(Chave, Cnpj, null, Schemas.CTe.CodigoEvento.CancelamentoPrestacaoServicoDesacordo)]
    public async Task ValidaArgumentos(string chave, string cnpjCpf, string observacao, Schemas.CTe.CodigoEvento evento)
    {
        var client = CreateClient();
        var act = () => client.EnvioEventoAsync(cnpjCpf, chave, evento, Schemas.NFe.Ambiente.Homologacao, observacao);
        await act.Should().ThrowAsync<ArgumentException>();
    }


    [Test, Explicit("Requer certificado do tomador e chave real de CT-e em homologação")]
    public async Task EnvioEventoDesacordoAsync()
    {
        var client = CreateClient();
        var result = await client.EnvioEventoAsync(
            Configuration["SSL:NFE:CertificateCnpjCpf"],
            Chave,
            Schemas.CTe.CodigoEvento.PrestacaoServicoDesacordo,
            Schemas.NFe.Ambiente.Homologacao,
            observacao: "Servico prestado em desacordo com o contratado");
        result.Should().NotBeNull();
        result.infEvento.cStat.Should().NotBeNullOrEmpty();
    }


    private static Schemas.CTe.Evento CriaEvento(Schemas.CTe.DetalheEvento detalhe, Schemas.CTe.CodigoEvento codigo) => new()
    {
        versao = "4.00",
        infEvento = new()
        {
            cOrgao = Schemas.NFe.OrgaoIBGE.SP,
            tpAmb = Schemas.NFe.Ambiente.Homologacao,
            CNPJ_CPF = Cnpj,
            ItemElementName = Schemas.CTe.PersonalidadeJuridica7.CNPJ,
            chCTe = Chave,
            dhEvento = new DateTime(2023, 10, 20, 9, 0, 0),
            tpEvento = ((int)codigo).ToString(),
            nSeqEvento = "1",
            Id = $"ID{(int)codigo}{Chave}001",
            detEvento = new() { versaoEvento = "4.00", Any = detalhe.ToXElement() }
        }
    };
}
