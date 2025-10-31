using EficazFramework.SPED.Schemas.DFeBase;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Informações do Evento de Informação de efetivo pagamento integral para liberar crédito presumido do adquirente
/// </summary>
public class ev112110 : IbsCbsEventoBase
{
    public string indQuitacao { get; set; } = "1"!;

}
