﻿using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207;

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

    public IEnumerable<Registro0150> Registros0150
    {
        get
        {
            return Registros.Where(r => r.Codigo == "0150").Cast<Registro0150>().ToList();
        }
    }

    public IEnumerable<Registro0300> Registros0300
    {
        get
        {
            return Registros.Where(r => r.Codigo == "0300").Cast<Registro0300>().ToList();
        }
    }
}
