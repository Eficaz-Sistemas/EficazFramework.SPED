using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Receitas Isentas, não alcançadas pela incidência da contribuição, sujeitas a alíquota zero ou de vendas com suspensão - Cofins
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM800 : Primitives.Registro
    {
        public RegistroM800() : base("M800")
        {
        }

        public RegistroM800(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTCofins { get; set; } = null;
        public double? VrTotalRecBrutaPeriodo { get; set; }
        public string CodigoContaContabil { get; set; } = null;
        public string DescricaoComplementarNatReceita { get; set; } = null;
        public string NotMapped_NaturezaReceita { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M800|");
            writer.Append(CSTCofins + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalRecBrutaPeriodo) + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(DescricaoComplementarNatReceita + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTCofins = data[2];
            VrTotalRecBrutaPeriodo = data[3].ToNullableDouble();
            CodigoContaContabil = data[4];
            DescricaoComplementarNatReceita = data[5];
        }
    }
}