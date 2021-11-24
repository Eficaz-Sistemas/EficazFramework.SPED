using System.Collections.Generic;
using System.Linq;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Abertura, Identificação e Referências
    /// </summary>
    /// <remarks></remarks>
    public class Bloco0 : Primitives.Bloco
    {
        public Registro0000 Registro0000
        {
            get
            {
                return (Registro0000)Registros.Where(r => r.Codigo == "0000").FirstOrDefault();
            }
        }

        public Registro0001 Registro0001
        {
            get
            {
                return (Registro0001)Registros.Where(r => r.Codigo == "0001").FirstOrDefault();
            }
        }

        public Registro0035 Registro0035
        {
            get
            {
                return (Registro0035)Registros.Where(r => r.Codigo == "0035").FirstOrDefault();
            }
        }

        public Registro0100 Registro0100
        {
            get
            {
                return (Registro0100)Registros.Where(r => r.Codigo == "0100").FirstOrDefault();
            }
        }

        public IEnumerable<Registro0140> Registros0140
        {
            get
            {
                return Registros.Where(r => r.Codigo == "0140").Cast<Registro0140>().ToList();
            }
        }

        public IEnumerable<Registro0150> Registros0150
        {
            get
            {
                return Registros.Where(r => r.Codigo == "0150").Cast<Registro0150>().ToList();
            }
        }

        public IEnumerable<Registro0205> Registros0205
        {
            get
            {
                // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
                // então recorreu-se à lista geral via LINQ to Objects
                return Registros.Where(r => r.Codigo == "0205").Cast<Registro0205>().ToList();
            }
        }

        public IEnumerable<Registro0206> Registros0206
        {
            get
            {
                // não é possível obter a lista por meio dos registros 0206 devido à sua multiplicidade,
                // então recorreu-se à lista geral via LINQ to Objects
                return Registros.Where(r => r.Codigo == "0206").Cast<Registro0206>().ToList();
            }
        }

        public IEnumerable<Registro0208> Registros0208
        {
            get
            {
                // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
                // então recorreu-se à lista geral via LINQ to Objects
                return Registros.Where(r => r.Codigo == "0208").Cast<Registro0208>().ToList();
            }
        }

        public IEnumerable<Registro0400> Registros0400
        {
            get
            {
                return Registros.Where(r => r.Codigo == "0400").Cast<Registro0400>().ToList();
            }
        }

        public IEnumerable<Registro0450> Registros0450
        {
            get
            {
                return Registros.Where(r => r.Codigo == "0450").Cast<Registro0450>().ToList();
            }
        }

        public IEnumerable<Registro0500> Registros0500
        {
            get
            {
                return Registro0001.Registros0500;
            }
        }

        public IEnumerable<Registro0600> Registros0600
        {
            get
            {
                return Registro0001.Registros0600;
            }
        }

        public Registro0990 Registro0990
        {
            get
            {
                return (Registro0990)Registros.Where(r => r.Codigo == "0990").FirstOrDefault();
            }
        }
    }
}