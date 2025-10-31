using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Manifestação do Fisco sobre Pedido de Transferência de Crédito de CBS em Operação de Sucessão
/// </summary>
public class ev412130 : IbsCbsEventoBase
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
