using System.Collections.Generic;
using System.Linq;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Inventário Físico
    /// </summary>
    /// <remarks></remarks>
    public class BlocoH : Primitives.Bloco
    {
        public RegistroH001 RegistroH001
        {
            get
            {
                return (RegistroH001)Registros.Where(r => r.Codigo == "H001").FirstOrDefault();
            }
        }

        public RegistroH005 RegistroH005
        {
            get
            {
                return (RegistroH005)Registros.Where(r => r.Codigo == "H005").FirstOrDefault();
            }
        }

        public List<RegistroH010> RegistrosH010
        {
            get
            {
                return Registros.Where(r => r.Codigo == "H010").Cast<RegistroH010>().ToList();
            }
        }

        public List<RegistroH020> RegistrosH020
        {
            get
            {
                return Registros.Where(r => r.Codigo == "H020").Cast<RegistroH020>().ToList();
            }
        }
    }
}