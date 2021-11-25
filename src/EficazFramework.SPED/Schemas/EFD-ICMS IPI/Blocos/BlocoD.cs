using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Documentos Fiscais I - Mercadorias (ICMS / IPI)
    /// </summary>
    /// <remarks></remarks>
    public class BlocoD : Primitives.Bloco
    {

        // Public ReadOnly Property RegistroC000() As Registro0000
        // Get
        // Return Me.Registros.Where(Function(r) r.Codigo = "C000").FirstOrDefault
        // End Get
        // End Property

        public List<RegistroD100> RegistrosD100
        {
            get
            {
                return Registros.Where(r => r.Codigo == "D100").Cast<RegistroD100>().ToList();
            }
        }

        public IEnumerable<RegistroD190> RegistrosD190
        {
            get
            {
                // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
                // então recorreu-se à lista geral via LINQ to Objects
                return Registros.Where(r => r.Codigo == "D190").Cast<RegistroD190>().ToList();
            }
        }

        public List<RegistroD500> RegistrosD500
        {
            get
            {
                return Registros.Where(r => r.Codigo == "D500").Cast<RegistroD500>().ToList();
            }
        }

        public IEnumerable<RegistroD590> RegistrosD590
        {
            get
            {
                // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
                // então recorreu-se à lista geral via LINQ to Objects
                return Registros.Where(r => r.Codigo == "D590").Cast<RegistroD590>().ToList();
            }
        }
    }
}