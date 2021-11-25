using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Controle do Crédito de ICMS do Ativo Permanente - CIAP
    /// </summary>
    /// <remarks></remarks>
    public class BlocoG : Primitives.Bloco
    {

        // Public ReadOnly Property RegistroC000() As Registro0000
        // Get
        // Return Me.Registros.Where(Function(r) r.Codigo = "C000").FirstOrDefault
        // End Get
        // End Property

        public RegistroG110 RegistroG110
        {
            get
            {
                return (RegistroG110)Registros.Where(r => r.Codigo == "G110").FirstOrDefault();
            }
        }

        public IEnumerable<RegistroG125> RegistrosG125
        {
            get
            {
                return Registros.Where(r => r.Codigo == "G125").Cast<RegistroG125>().ToList();
            }
        }

        public IEnumerable<RegistroG130> RegistrosG130
        {
            get
            {
                return Registros.Where(r => r.Codigo == "G130").Cast<RegistroG130>().ToList();
            }
        }
    }
}