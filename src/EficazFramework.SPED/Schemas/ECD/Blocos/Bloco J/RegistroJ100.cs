using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Balanço Patrimonial
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ100 : Primitives.Registro
    {
        public RegistroJ100() : base("J100")
        {
        }

        // Campos'
        public string CodAglutinacao { get; set; } = null;
        // layout 7
        public string IndicadorCodAglutinacao { get; set; } = null;
        // fim layout 7
        public string NivelCodAglut { get; set; } = null;
        // layout 7
        public string CodAglutinacaoSuperior { get; set; } = null;
        // fim layout 7
        public IndicadorGrupoBalanço IndicadorGrupoBalanco { get; set; } = IndicadorGrupoBalanço.Ativo;
        public string DescrCodAglut { get; set; } = null;
        public double? VrTotalCodAglut { get; set; }
        public string IndicadorSitSaldo { get; set; } = null;
        public double? VrInicialCodAglut { get; set; }
        public string IndicadorSitSaldoInicial { get; set; } = null;
        public string NotaExplicativa { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J100|");
            writer.Append(CodAglutinacao + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
                writer.Append(IndicadorCodAglutinacao + "|");
            writer.Append(NivelCodAglut + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
            {
                writer.Append(CodAglutinacaoSuperior + "|");
                if (IndicadorGrupoBalanco == IndicadorGrupoBalanço.Ativo)
                    writer.Append("A|");
                else
                    writer.Append("P|");
            }
            else
            {
                writer.Append(((int)IndicadorGrupoBalanco).ToString() + "|");
            }

            writer.Append(DescrCodAglut.TrimStart() + "|");
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
            {
                writer.Append(string.Format("{0:F2}", VrInicialCodAglut) + "|");
                writer.Append(IndicadorSitSaldoInicial + "|");
                writer.Append(string.Format("{0:F2}", VrTotalCodAglut) + "|");
                writer.Append(IndicadorSitSaldo + "|");
            }
            else
            {
                writer.Append(string.Format("{0:F2}", VrTotalCodAglut) + "|");
                writer.Append(IndicadorSitSaldo + "|");
                writer.Append(string.Format("{0:F2}", VrInicialCodAglut) + "|");
                writer.Append(IndicadorSitSaldoInicial + "|");
            }

            writer.Append(NotaExplicativa + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            if (Conversions.ToInteger(Versao) / 100d >= 7d)
            {
                CodAglutinacao = data[2];
                IndicadorCodAglutinacao = data[3];
                NivelCodAglut = data[4];
                CodAglutinacaoSuperior = data[5];
                if (data[6] == "A")
                {
                    IndicadorGrupoBalanco = IndicadorGrupoBalanço.Ativo;
                }
                else
                {
                    IndicadorGrupoBalanco = IndicadorGrupoBalanço.PassivoPL;
                }

                DescrCodAglut = data[7];
                VrInicialCodAglut = data[8].ToNullableDouble();
                IndicadorSitSaldoInicial = data[9];
                VrTotalCodAglut = data[10].ToNullableDouble();
                IndicadorSitSaldo = data[11];
            }
            else
            {
                CodAglutinacao = data[2];
                NivelCodAglut = data[3];
                IndicadorGrupoBalanco = (IndicadorGrupoBalanço)data[4].ToEnum<IndicadorGrupoBalanço>(IndicadorGrupoBalanço.Ativo);
                DescrCodAglut = data[5];
                VrTotalCodAglut = data[6].ToNullableDouble();
                IndicadorSitSaldo = data[7];
                VrInicialCodAglut = data[8].ToNullableDouble();
                IndicadorSitSaldoInicial = data[9];
            }
        }

        public RegistroJ100(string linha, string versao) : base(linha, versao)
        {
        }
    }
}