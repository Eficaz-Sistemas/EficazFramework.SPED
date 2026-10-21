using System.Runtime.Serialization;

namespace EficazFramework.SPED.Schemas.CTe;

/// <summary>
/// Códigos dos eventos do CT-e (tpEvento) mapeados pelo Eficaz Framework
/// </summary>
[Serializable()]
[XmlType(TypeName = "TEventoTpEvento", Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum CodigoEvento
{
    /// <summary>
    /// Manifestação do tomador: Prestação do Serviço em Desacordo
    /// </summary>
    [Description("Prestação do Serviço em Desacordo")]
    [EnumMember(Value = "610110")]
    [XmlEnum("610110")]
    PrestacaoServicoDesacordo = 610110,

    /// <summary>
    /// Cancelamento da manifestação de Prestação do Serviço em Desacordo
    /// </summary>
    [Description("Cancelamento Prestação do Serviço em Desacordo")]
    [EnumMember(Value = "610111")]
    [XmlEnum("610111")]
    CancelamentoPrestacaoServicoDesacordo = 610111,
}

[Serializable()]
[XmlType(TypeName = "TVerEvento", Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum VersaoServicoEvento
{
    [Description("4.00")]
    [XmlEnum("4.00")]
    Versao_4_00,
}
