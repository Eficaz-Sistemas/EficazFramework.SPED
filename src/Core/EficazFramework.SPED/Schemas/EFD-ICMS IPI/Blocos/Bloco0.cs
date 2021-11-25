using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

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

    public Registro0005 Registro0005
    {
        get
        {
            return (Registro0005)Registros.Where(r => r.Codigo == "0005").FirstOrDefault();
        }
    }

    public IEnumerable<Registro0015> Registros0015
    {
        get
        {
            return Registro0001.Registros0015;
        }
    }

    public Registro0100 Registro0100
    {
        get
        {
            return (Registro0100)Registros.Where(r => r.Codigo == "0100").FirstOrDefault();
        }
    }

    public IEnumerable<Registro0150> Registros0150
    {
        get
        {
            return Registros.Where(r => r.Codigo == "0150").Cast<Registro0150>().ToList();
        }
    }

    public IEnumerable<Registro0175> Registros0175
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0150 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "0175").Cast<Registro0175>().ToList();
        }
    }

    public IEnumerable<Registro0190> Registros0190
    {
        get
        {
            return Registro0001.Registros0190;
        }
    }

    public IEnumerable<Registro0200> Registros0200
    {
        get
        {
            return Registro0001.Registros0200;
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

    public IEnumerable<Registro0220> Registros0220
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "0220").Cast<Registro0220>().ToList();
        }
    }

    public IEnumerable<Registro0300> Registros0300
    {
        get
        {
            return Registro0001.Registros0300;
        }
    }

    public IEnumerable<Registro0305> Registros0305
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0305 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "0305").Cast<Registro0305>().ToList();
        }
    }

    public IEnumerable<Registro0400> Registros0400
    {
        get
        {
            return Registro0001.Registros0400;
        }
    }

    public IEnumerable<Registro0450> Registros0450
    {
        get
        {
            return Registro0001.Registros0450;
        }
    }

    public IEnumerable<Registro0460> Registros0460
    {
        get
        {
            return Registro0001.Registros0460;
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
