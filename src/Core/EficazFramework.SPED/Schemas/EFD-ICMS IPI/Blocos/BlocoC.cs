using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

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

    public IEnumerable<RegistroC100> RegistrosC100
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C100").Cast<RegistroC100>().ToList();
        }
    }

    public IEnumerable<RegistroC113> RegistrosC113
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C113").Cast<RegistroC113>().ToList();
        }
    }

    public IEnumerable<RegistroC114> RegistrosC114
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C114").Cast<RegistroC114>().ToList();
        }
    }

    public IEnumerable<RegistroC130> RegistrosC130
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C130").Cast<RegistroC130>().ToList();
        }
    }

    public IEnumerable<RegistroC140> RegistrosC140
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C140").Cast<RegistroC140>().ToList();
        }
    }

    public IEnumerable<RegistroC141> RegistrosC141
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C141").Cast<RegistroC141>().ToList();
        }
    }

    public IEnumerable<RegistroC170> RegistrosC170
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C170").Cast<RegistroC170>().ToList();
        }
    }

    public IEnumerable<RegistroC176> RegistrosC176
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C176").Cast<RegistroC176>().ToList();
        }
    }

    public IEnumerable<RegistroC190> RegistrosC190
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "C190").Cast<RegistroC190>().ToList();
        }
    }

    public IEnumerable<RegistroC195> RegistrosC195
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "C195").Cast<RegistroC195>().ToList();
        }
    }

    public IEnumerable<RegistroC197> RegistrosC197
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "C197").Cast<RegistroC197>().ToList();
        }
    }

    public IEnumerable<RegistroC500> RegistrosC500
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C500").Cast<RegistroC500>().ToList();
        }
    }

    public IEnumerable<RegistroC590> RegistrosC590
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "C590").Cast<RegistroC590>().ToList();
        }
    }

    public IEnumerable<RegistroC400> RegistrosC400
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C400").Cast<RegistroC400>().ToList();
        }
    }

    public IEnumerable<RegistroC405> RegistrosC405
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C405").Cast<RegistroC405>().ToList();
        }
    }

    public IEnumerable<RegistroC420> RegistrosC420
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "C420").Cast<RegistroC420>().ToList();
        }
    }

    public IEnumerable<RegistroC460> RegistrosC460
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C460").Cast<RegistroC460>().ToList();
        }
    }

    public IEnumerable<RegistroC490> RegistrosC490
    {
        get
        {
            // não é possível obter a lista por meio dos registros 0205 devido à sua multiplicidade,
            // então recorreu-se à lista geral via LINQ to Objects
            return Registros.Where(r => r.Codigo == "C490").Cast<RegistroC490>().ToList();
        }
    }

    public IEnumerable<RegistroC800> RegistrosC800
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C800").Cast<RegistroC800>().ToList();
        }
    }

    public IEnumerable<RegistroC860> RegistrosC860
    {
        get
        {
            return Registros.Where(r => r.Codigo == "C860").Cast<RegistroC860>().ToList();
        }
    }
}
