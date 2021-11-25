
namespace EficazFramework.SPED.Utilities.eSocial
{
    public class Converters
    {
        public static bool EnumSimNaoToBoolean(Schemas.eSocial.SimNaoString value)
        {
            if (value == Schemas.eSocial.SimNaoString.Sim)
                return true;
            else
                return false;
        }

        public static bool EnumSimNaoToBoolean(Schemas.eSocial.SimNaoByte value)
        {
            if (value == Schemas.eSocial.SimNaoByte.Sim)
                return true;
            else
                return false;
        }

        public static Schemas.eSocial.SimNaoString BooleanToEnumSimNaoString(bool value)
        {
            if (value == true)
                return Schemas.eSocial.SimNaoString.Sim;
            else
                return Schemas.eSocial.SimNaoString.Nao;
        }

        public static Schemas.eSocial.SimNaoByte BooleanToEnumSimNaoByte(bool value)
        {
            if (value == true)
                return Schemas.eSocial.SimNaoByte.Sim;
            else
                return Schemas.eSocial.SimNaoByte.Nao;
        }
    }
}