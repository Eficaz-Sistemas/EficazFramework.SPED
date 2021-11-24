using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Sociedades cooperativas - composição da base de calculo pis
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM211 : Primitives.Registro
    {
        public RegistroM211() : base("M211")
        {
        }

        public RegistroM211(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorTipoSociedadeCooperativa IndicadorTipoSociedadeCooperativa { get; set; } = IndicadorTipoSociedadeCooperativa.Outras;
        public double? VrBcContribuicao { get; set; }
        public double? VrExclusaoEspecCooperativasSobrasFATES { get; set; }
        public double? VrExclusaoEspecCooperativasTipo { get; set; }
        public double? VrBcAposExclusoes { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M211|");
            writer.Append(((int)IndicadorTipoSociedadeCooperativa).ToString() + "|");
            writer.Append(VrBcContribuicao + "|");
            writer.Append(VrExclusaoEspecCooperativasSobrasFATES + "|");
            writer.Append(VrExclusaoEspecCooperativasTipo + "|");
            writer.Append(VrBcAposExclusoes + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorTipoSociedadeCooperativa = (IndicadorTipoSociedadeCooperativa)data[2].ToEnum<IndicadorTipoSociedadeCooperativa>(IndicadorTipoSociedadeCooperativa.Outras);
            VrBcContribuicao = data[3].ToNullableDouble();
            VrExclusaoEspecCooperativasSobrasFATES = data[4].ToNullableDouble();
            VrExclusaoEspecCooperativasTipo = data[5].ToNullableDouble();
            VrBcAposExclusoes = data[6].ToNullableDouble();
        }
    }
}