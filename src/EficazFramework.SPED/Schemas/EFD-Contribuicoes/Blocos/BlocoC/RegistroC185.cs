using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Consolidação - Operações de Vendas - Cofins
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC185 : Primitives.Registro
    {
        public RegistroC185() : base("C185")
        {
        }

        public RegistroC185(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTCOFINS { get; set; } = null;
        public string CFOP { get; set; } = null;
        public double? VrITem { get; set; }
        public double? VrDescontoExclusao { get; set; }
        public double? VrBaseCalculoCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? BCCofinsQuantidade { get; set; }
        public double? AliquotaCofinsReais { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C185|");
            writer.Append(CSTCOFINS + "|");
            writer.Append(CFOP + "|");
            writer.Append(VrITem + "|");
            writer.Append(VrDescontoExclusao + "|");
            writer.Append(VrBaseCalculoCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(BCCofinsQuantidade + "|");
            writer.Append(AliquotaCofinsReais + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTCOFINS = data[2];
            CFOP = data[3];
            VrITem = data[4].ToNullableDouble();
            VrDescontoExclusao = data[5].ToNullableDouble();
            VrBaseCalculoCofins = data[6].ToNullableDouble();
            AliquotaCofins = data[7].ToNullableDouble();
            BCCofinsQuantidade = data[8].ToNullableDouble();
            AliquotaCofinsReais = data[9].ToNullableDouble();
            VrCofins = data[10].ToNullableDouble();
            CodigoContaContabil = data[11];
        }
    }
}