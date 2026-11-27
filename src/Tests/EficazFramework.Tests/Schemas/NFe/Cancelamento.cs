using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Services.NFe;

namespace EficazFramework.SPED.Schemas.NFe.Tests;

/// <summary>Evento de cancelamento (110111): protocolo no detEvento e montagem do procEventoNFe.</summary>
public class Cancelamento
{
    private const string Chave = "35240109041929000133550010000000011000000015";

    private static Evento NovoEvento() => new()
    {
        Versao = "1.00",
        InformacaoEvento = new()
        {
            Ambiente = Ambiente.Homologacao,
            ChaveNFe = Chave,
            CNPJ_CPF = "09041929000133",
            PersonalidadeJuridica = PersonalidadeJuridica.CNPJ,
            EventoCodigo = CodigoEvento.Cancelamento,
            EventoData = new DateTime(2026, 11, 26, 10, 0, 0),
            EventoNumeroSequencial = "1",
            Orgao = OrgaoIBGE.SP,
            EventoVersao = "1.00",
            EventoDetalhe = new ev110111
            {
                Versao = VersaoServicoEvento.Versao_1_00,
                Descricao = "Cancelamento",
                Protocolo = "135240000000001",
                Justificativa = "Erro de digitacao no valor"
            }
        }
    };

    [Test]
    public void Evento_GravaDescricaoProtocoloEJustificativa_NaOrdemDoLeiaute()
    {
        string xml = NovoEvento().Serialize();

        xml.Should().Contain("<descEvento>Cancelamento</descEvento>")
            .And.Contain("<nProt>135240000000001</nProt>")
            .And.Contain("<xJust>Erro de digitacao no valor</xJust>");
        xml.IndexOf("<descEvento>", StringComparison.Ordinal).Should().BeLessThan(xml.IndexOf("<nProt>", StringComparison.Ordinal));
        xml.IndexOf("<nProt>", StringComparison.Ordinal).Should().BeLessThan(xml.IndexOf("<xJust>", StringComparison.Ordinal));
    }

    [Test]
    public void ProcessoEvento_JuntaEventoComoAssinadoERetorno()
    {
        // simula o evento assinado: o conteúdo precisa entrar sem nenhuma alteração
        XmlDocument assinado = new();
        assinado.LoadXml(NovoEvento().Serialize());
        XmlElement assinatura = assinado.CreateElement("Signature", "http://www.w3.org/2000/09/xmldsig#");
        assinatura.InnerText = "ASSINATURA";
        assinado.DocumentElement!.AppendChild(assinatura);

        EventoRetorno retorno = new()
        {
            Versao = "1.00",
            InformacaoEventoRetorno = new()
            {
                Ambiente = Ambiente.Homologacao,
                VersaoAplicativo = "SP_EVENTOS_PL_100",
                Orgao = OrgaoIBGE.SP,
                RespostaCodigo = "135",
                RespostaDescricao = "Evento registrado e vinculado a NF-e",
                ChaveNFe = Chave,
                EventoCodigo = CodigoEvento.Cancelamento,
                EventoNumeroSequencial = "1",
                EventoDataRegistro = new DateTime(2026, 11, 26, 10, 0, 5),
                Protocolo = "135240000000099"
            }
        };

        string xml = NFeService.ProcessoEventoXml(assinado.OuterXml, retorno);

        XmlDocument doc = new();
        doc.LoadXml(xml);
        doc.DocumentElement!.LocalName.Should().Be("procEventoNFe");
        doc.DocumentElement.GetAttribute("versao").Should().Be("1.00");
        doc.DocumentElement.ChildNodes.Cast<XmlNode>().Select(n => n.LocalName).Should().Equal("evento", "retEvento");
        xml.Should().Contain("ASSINATURA").And.Contain("<nProt>135240000000001</nProt>").And.Contain("<nProt>135240000000099</nProt>");

        ProcessoEvento processo = ProcessoEvento.Deserialize(xml);
        processo.Evento.InformacaoEvento.ChaveNFe.Should().Be(Chave);
        processo.EventoRetorno.InformacaoEventoRetorno.RespostaCodigo.Should().Be("135");
        processo.EventoRetorno.InformacaoEventoRetorno.Protocolo.Should().Be("135240000000099");
    }
}
