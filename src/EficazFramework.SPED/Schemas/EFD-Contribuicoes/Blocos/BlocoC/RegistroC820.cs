using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento do Cupom Fiscal Eletrônico
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC820 : Primitives.Registro
    {
        public RegistroC820() : base("C820")
        {
        }

        public RegistroC820(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CFOP { get; set; } = null;
        public double? VrTotalItens { get; set; }
        public string CodigoItem { get; set; } = null;
        public string CstPis { get; set; } = null;
        public double? BCPisQuantidade { get; set; }
        public double? AliquotaPisQtde { get; set; }
        public double? VrPis { get; set; }
        public string CstCofins { get; set; } = null;
        public double? BCCofinsQuantidade { get; set; }
        public double? AliquotaCofinsQtde { get; set; }
        public double? VrCofins { get; set; }
        public string CodContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C820|");
            writer.Append(CFOP + "|");
            writer.Append(VrTotalItens + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(CstPis + "|");
            writer.Append(BCPisQuantidade + "|");
            writer.Append(AliquotaPisQtde + "|");
            writer.Append(VrPis + "|");
            writer.Append(CstCofins + "|");
            writer.Append(BCCofinsQuantidade + "|");
            writer.Append(AliquotaCofinsQtde + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CFOP = data[2];
            VrTotalItens = data[3].ToNullableDouble();
            CodigoItem = data[4];
            CstPis = data[5];
            BCPisQuantidade = data[6].ToNullableDouble();
            AliquotaPisQtde = data[7].ToNullableDouble();
            VrPis = data[8].ToNullableDouble();
            CstCofins = Conversions.ToString(data[9].ToNullableDouble());
            BCCofinsQuantidade = data[10].ToNullableDouble();
            AliquotaCofinsQtde = data[11].ToNullableDouble();
            VrCofins = data[12].ToNullableDouble();
            CodContaContabil = data[13];
        }
    }
}