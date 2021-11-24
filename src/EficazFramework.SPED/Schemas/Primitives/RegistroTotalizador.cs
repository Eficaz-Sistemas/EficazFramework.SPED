
namespace EficazFrameworkCore.SPED.Schemas.Primitives
{
    public sealed class RegistroTotalizador : Registro
    {
        public RegistroTotalizador() : base(null, null)
        {
        }

        public RegistroTotalizador(string codigo) : base(codigo)
        {
        }

        public override string EscreveLinha()
        {
            if (StringFormat is null)
                StringFormat = "|????|{0}|{1}|";
            return string.Format(StringFormat, RegistroTotalizado, TotalRegistros);
        }

        public override void LeParametros(string[] data)
        {
            // N/A
        }

        public string StringFormat { get; set; } = "|????|{0}|{1}|";
        public string RegistroTotalizado { get; set; } = "0000";
        public int TotalRegistros { get; set; } = 0;
    }
}