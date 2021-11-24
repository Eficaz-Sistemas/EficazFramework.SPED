using System.Collections.Generic;
using System.Linq;

namespace EficazFrameworkCore.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Informações Relativas às Operações e Prestações de Saídas e à Apuração de Crédito Acumulado
    /// </summary>
    /// <remarks></remarks>
    public class Bloco5 : Primitives.Bloco
    {
        public IEnumerable<Registro5315> Registros5315
        {
            get
            {
                return Registros.Where(r => r.Codigo == "5315").Cast<Registro5315>().ToList();
            }
        }
    }
}