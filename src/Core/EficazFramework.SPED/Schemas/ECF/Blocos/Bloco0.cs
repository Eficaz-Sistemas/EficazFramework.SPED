﻿using System.Linq;

namespace EficazFramework.SPED.Schemas.ECF;

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

    public Registro0990 Registro0990
    {
        get
        {
            return (Registro0990)Registros.Where(r => r.Codigo == "0990").FirstOrDefault();
        }
    }
}
