using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Informação de efetivo pagamento integral para liberar crédito presumido do adquirente
/// </summary>
[XmlType("ev112110", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ev112110 : IbsCbsEventoBase
{
    public string indQuitacao { get; set; } = "1"!;

}
