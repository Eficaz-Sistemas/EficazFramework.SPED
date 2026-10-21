namespace EficazFramework.SPED.Schemas.CTe;

/// <summary>
/// Prestação do Serviço em Desacordo (610110)
/// </summary>
[XmlType("evPrestDesacordo", Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("evPrestDesacordo", Namespace = "http://www.portalfiscal.inf.br/cte")]
public class evPrestDesacordo : DetalheEvento
{
    public evPrestDesacordo() => Descricao = "Prestacao do Servico em Desacordo";

    /// <summary>
    /// Indicador de operação em desacordo (fixo: 1)
    /// </summary>
    [XmlElement("indDesacordoOper")]
    public string IndicadorDesacordo { get; set; } = "1";

    /// <summary>
    /// Observações do tomador (15 a 255 caracteres)
    /// </summary>
    [XmlElement("xObs")]
    public string Observacoes { get; set; }
}
