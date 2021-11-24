using System.Linq;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// </summary>
    /// <remarks></remarks>
    public class BlocoB : Primitives.Bloco
    {
        public RegistroB001 RegistroB001
        {
            get
            {
                return (RegistroB001)Registros.Where(r => r.Codigo == "B001").FirstOrDefault();
            }
        }
    }
}