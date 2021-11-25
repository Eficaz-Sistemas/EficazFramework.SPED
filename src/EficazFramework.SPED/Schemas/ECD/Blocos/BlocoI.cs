using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// </summary>
    /// <remarks></remarks>
    public class BlocoI : Primitives.Bloco
    {
        public IEnumerable<RegistroI200> RegistrosI200
        {
            get
            {
                return Registros.Where(r => r.Codigo == "I200").Cast<RegistroI200>().ToList();
            }
        }

        public IEnumerable<RegistroI250> RegistrosI250
        {
            get
            {
                return Registros.Where(r => r.Codigo == "I250").Cast<RegistroI250>().ToList();
            }
        }
    }
}