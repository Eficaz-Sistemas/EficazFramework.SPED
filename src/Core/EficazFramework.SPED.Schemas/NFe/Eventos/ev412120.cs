using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Manifestação sobre Pedido de Transferência de Crédito de IBS em Operação de Sucessão
/// </summary>
[XmlType("ev412120", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev412120 : IbsCbsEventoBase
{
    [XmlElement("indDeferimento")]
    public IndicadorAceite IndicadorDeferimento { get; set; } = IndicadorAceite.NaoAceite;

    /// <summary>
    /// Código do motivo do indeferimento: 1–Falta de manifestação de todas as sucessoras; 2 – Outros.
    /// </summary>
    [XmlElement("cMotivo")]
    public MotivoIndeferimento CodigoMotivo { get; set; }

    /// <summary>
    /// Descrição do motivo do indeferimento (1 a 500 caracteres).
    /// </summary>
    [XmlElement("xMotivo")]
    public string? DescricaoMotivo { get; set; }
}

public enum MotivoIndeferimento
{
    [System.ComponentModel.Description("Falta de manifestação de todas as sucessoras")]
    [System.Xml.Serialization.XmlEnum("1")]
    FaltaManifestacaoSucessoras = 1,

    [System.ComponentModel.Description("Outros")]
    [System.Xml.Serialization.XmlEnum("2")]
    Outros = 2
}
