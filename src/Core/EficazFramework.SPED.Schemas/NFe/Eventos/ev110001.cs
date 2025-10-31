using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Cancelamento de evento
/// </summary>
public class ev110001 : IbsCbsEventoBase
{
    /// <summary>
    /// Código do evento autorizado a ser cancelado. Eventos válidos:
    /// <list type="bullet">
    /// <item>112110</item>
    /// <item>112120</item>
    /// <item>112130</item>
    /// <item>112140</item>
    /// <item>112150</item>
    /// <item>211110</item>
    /// <item>211120</item>
    /// <item>211124</item>
    /// <item>211128</item>
    /// <item>211130</item>
    /// <item>211140</item>
    /// <item>211150</item>
    /// <item>212110</item>
    /// <item>212120</item>
    /// <item>412120</item>
    /// <item>412130</item>
    /// </list>
    /// </summary>
    [XmlElement("tpEventoAut")]
    public CodigoEvento CodigoEventoAutorizado { get; set; }

    /// <summary>
    /// Informar o número do Protocolo de Autorização do Evento a ser cancelado
    /// </summary>
    [XmlElement("nProtEvento")]
    public string? Protocolo { get; set; }
}
