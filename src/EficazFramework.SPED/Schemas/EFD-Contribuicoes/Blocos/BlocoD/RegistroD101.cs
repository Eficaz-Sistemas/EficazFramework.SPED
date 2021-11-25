using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento do Documento de Transporte
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD101 : Primitives.Registro
    {
        public RegistroD101() : base("D101")
        {
        }

        public RegistroD101(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public IndicadorNaturezaFrete IndicadorNaturezaFrete { get; set; } = IndicadorNaturezaFrete.Outras;
        public double? VrTotalItens { get; set; }
        public string CSTPis { get; set; } = null;
        public string NatBcCredito { get; set; } = null;
        public double? VrBcPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? VrPis { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D101|");
            writer.Append(((int)IndicadorNaturezaFrete).ToString() + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalItens) + "|");
            writer.Append(CSTPis + "|");
            writer.Append(string.Format("{0:00}", Conversions.ToInteger(NatBcCredito)) + "|");
            writer.Append(string.Format("{0:0.##}", VrBcPis) + "|");
            writer.Append(string.Format("{0:0.####}", AliquotaPis) + "|");
            writer.Append(string.Format("{0:0.##}", VrPis) + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorNaturezaFrete = (IndicadorNaturezaFrete)data[2].ToEnum<IndicadorNaturezaFrete>(IndicadorNaturezaFrete.Outras);
            VrTotalItens = data[3].ToNullableDouble();
            CSTPis = data[4];
            NatBcCredito = data[5];
            VrBcPis = data[6].ToNullableDouble();
            AliquotaPis = data[7].ToNullableDouble();
            VrPis = data[8].ToNullableDouble();
            CodigoContaContabil = data[9];
        }
    }
}