using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento das receitas isentas, não alcançadas pela incidência da contribuição, sujeitas a alíquota zero ou de vendas com suspensão - Cofins
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM810 : Primitives.Registro
    {
        public RegistroM810() : base("M810")
        {
        }

        public RegistroM810(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NaturezaReceitaCST { get; set; } = null;
        public double? VrReceitaBrutaPeriodo { get; set; }
        public string CodigoContaContabil { get; set; } = null;
        public string DescricaoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new global::System.Text.StringBuilder();
            writer.Append("|M810|");
            writer.Append(string.Format("{0:000}", Conversions.ToInteger(NaturezaReceitaCST)) + "|");
            writer.Append(string.Format("{0:0.##}", VrReceitaBrutaPeriodo) + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(DescricaoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NaturezaReceitaCST = data[2];
            VrReceitaBrutaPeriodo = data[3].ToNullableDouble();
            CodigoContaContabil = data[4];
            DescricaoComplementar = data[5];
        }
    }
}