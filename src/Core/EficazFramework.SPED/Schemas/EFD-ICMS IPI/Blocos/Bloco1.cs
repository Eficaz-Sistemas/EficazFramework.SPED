using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Outras Informações
/// </summary>
/// <remarks></remarks>
public class Bloco1 : Primitives.Bloco
{
    public Registro1010 Registro1010
    {
        get
        {
            return (Registro1010)Registros.Where(r => r.Codigo == "1010").FirstOrDefault();
        }
    }

    public List<Registro1300> Registros1300
    {
        get
        {
            return Registros.Where(r => r.Codigo == "1300").Cast<Registro1300>().ToList();
        }
    }

    public List<Registro1310> Registros1310
    {
        get
        {
            return Registros.Where(r => r.Codigo == "1310").Cast<Registro1310>().ToList();
        }
    }

}
