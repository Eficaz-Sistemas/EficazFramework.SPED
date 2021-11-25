using System.Linq;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Abertura, Identificação e Referências
/// </summary>
/// <remarks></remarks>
public class Bloco0 : Primitives.Bloco
{
    public Registro0000 Registro0000
    {
        get
        {
            return (Registro0000)Registros.Where(r => r.Codigo == "0000").FirstOrDefault();
        }
    }
}
