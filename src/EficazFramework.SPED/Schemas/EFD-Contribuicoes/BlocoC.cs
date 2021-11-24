using System.Linq;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Documentos Fiscais I - Mercadorias (ICMS / IPI)
    /// </summary>
    /// <remarks></remarks>
    public class BlocoC : Primitives.Bloco
    {
        public RegistroC001 RegistroC001
        {
            get
            {
                return (RegistroC001)Registros.Where(r => r.Codigo == "C001").FirstOrDefault();
            }
        }

        public RegistroC010 RegistroC010
        {
            get
            {
                return (RegistroC010)Registros.Where(r => r.Codigo == "C010").FirstOrDefault();
            }
        }
    }
}