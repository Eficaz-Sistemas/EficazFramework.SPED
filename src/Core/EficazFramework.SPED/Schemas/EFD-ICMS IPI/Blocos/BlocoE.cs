using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Apuração do ICMS e do IPI
/// </summary>
/// <exclude />
public class BlocoE : Primitives.Bloco
{

    // Public ReadOnly Property RegistroC000() As Registro0000
    // Get
    // Return Me.Registros.Where(Function(r) r.Codigo = "C000").FirstOrDefault
    // End Get
    // End Property

    public RegistroE001 RegistroE001
    {
        get
        {
            return (RegistroE001)Registros.Where(r => r.Codigo == "E001").FirstOrDefault();
        }
    }

    public RegistroE100 RegistroE100
    {
        get
        {
            return (RegistroE100)Registros.Where(r => r.Codigo == "E100").FirstOrDefault();
        }
    }

    public RegistroE110 RegistroE110
    {
        get
        {
            return (RegistroE110)Registros.Where(r => r.Codigo == "E110").FirstOrDefault();
        }
    }

    public IEnumerable<RegistroE111> RegistrosE111
    {
        get
        {
            return Registros.Where(r => r.Codigo == "E111").Cast<RegistroE111>().ToList();
        }
    }

    public IEnumerable<RegistroE200> RegistrosE200
    {
        get
        {
            return Registros.Where(r => r.Codigo == "E200").Cast<RegistroE200>().ToList();
        }
    }

    public IEnumerable<RegistroE210> RegistrosE210
    {
        get
        {
            return Registros.Where(r => r.Codigo == "E210").Cast<RegistroE210>().ToList();
        }
    }

    public IEnumerable<RegistroE220> RegistrosE220
    {
        get
        {
            return Registros.Where(r => r.Codigo == "E220").Cast<RegistroE220>().ToList();
        }
    }

    public IEnumerable<RegistroE300> RegistrosE300
    {
        get
        {
            return Registros.Where(r => r.Codigo == "E300").Cast<RegistroE300>().ToList();
        }
    }

    public IEnumerable<RegistroE310> RegistrosE310
    {
        get
        {
            return Registros.Where(r => r.Codigo == "E310").Cast<RegistroE310>().ToList();
        }
    }

    public IEnumerable<RegistroE311> RegistrosE311
    {
        get
        {
            return Registros.Where(r => r.Codigo == "E311").Cast<RegistroE311>().ToList();
        }
    }
}
