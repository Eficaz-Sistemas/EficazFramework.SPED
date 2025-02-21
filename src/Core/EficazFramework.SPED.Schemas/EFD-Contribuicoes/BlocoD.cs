using System.Linq;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Documentos Fiscais II - Serviços (ICMS)
/// </summary>
/// <remarks></remarks>
public class BlocoD : Primitives.Bloco
{
    public RegistroD001 RegistroD001
    {
        get
        {
            return (RegistroD001)Registros.Where(r => r.Codigo == "D001").FirstOrDefault();
        }
    }

    public RegistroD010 RegistroD010
    {
        get
        {
            return (RegistroD010)Registros.Where(r => r.Codigo == "D010").FirstOrDefault();
        }
    }
}
