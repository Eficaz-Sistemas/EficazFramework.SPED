using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento do Documento de Transporte
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD105 : Primitives.Registro
    {
        public RegistroD105() : base("D105")
        {
        }

        public RegistroD105(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorNaturezaFrete IndicadorNaturezaFrete { get; set; } = IndicadorNaturezaFrete.Outras;
        public double? VrTotalItens { get; set; }
        public string CSTCofins { get; set; } = null;
        public string NatBcCredito { get; set; } = null;
        public double? VrBcCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D105|");
            writer.Append(((int)IndicadorNaturezaFrete).ToString() + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalItens) + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(string.Format("{0:00}", Conversions.ToInteger(NatBcCredito)) + "|");
            writer.Append(string.Format("{0:0.##}", VrBcCofins) + "|");
            writer.Append(string.Format("{0:0.####}", AliquotaCofins) + "|");
            writer.Append(string.Format("{0:0.##}", VrCofins) + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorNaturezaFrete = (IndicadorNaturezaFrete)data[2].ToEnum<IndicadorNaturezaFrete>(IndicadorNaturezaFrete.Outras);
            VrTotalItens = data[3].ToNullableDouble();
            CSTCofins = data[4];
            NatBcCredito = data[5];
            VrBcCofins = data[6].ToNullableDouble();
            AliquotaCofins = data[7].ToNullableDouble();
            VrCofins = data[8].ToNullableDouble();
            CodigoContaContabil = data[9];
        }
    }
}