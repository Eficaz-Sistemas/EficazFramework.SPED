using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// DOCUMENTOS FISCAIS - SERVIÇOS (NÃO SUJEITOS AO ICMS)
    /// </summary>
    /// <remarks></remarks>
    public class BlocoA : Primitives.Bloco
    {
        public RegistroA001 RegistroA001
        {
            get
            {
                return (RegistroA001)Registros.Where(r => r.Codigo == "A001").FirstOrDefault();
            }
        }

        public IEnumerable<RegistroA010> RegistrosA010
        {
            get
            {
                return Registros.Where(r => r.Codigo == "A010").Cast<RegistroA010>().ToList();
            }
        }

        public IEnumerable<RegistroA100> RegistrosA100
        {
            get
            {
                return Registros.Where(r => r.Codigo == "A100").Cast<RegistroA100>().ToList();
            }
        }
    }
}