using System.Linq;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

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
    }
}