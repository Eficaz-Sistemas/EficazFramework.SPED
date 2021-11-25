
namespace EficazFramework.SPED.Utilities.EFD_Reinf;

public class Converters
{
    public static bool EnumSimNaoToBoolean(Schemas.EFD_Reinf.SimNao value)
    {
        if (value == Schemas.EFD_Reinf.SimNao.Sim)
            return true;
        else
            return false;
    }

    public static Schemas.EFD_Reinf.SimNao BooleanToEnumSimNao(bool value)
    {
        if (value == true)
            return Schemas.EFD_Reinf.SimNao.Sim;
        else
            return Schemas.EFD_Reinf.SimNao.Nao;
    }
}
