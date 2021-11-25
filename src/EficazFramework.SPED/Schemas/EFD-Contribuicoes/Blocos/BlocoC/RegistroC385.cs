using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Consolidação - COFINS
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC385 : Primitives.Registro
    {
        public RegistroC385() : base("C385")
        {
        }

        public RegistroC385(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTCofins { get; set; } = null;
        public string CodigoItem { get; set; } = null;
        public double? VrTotalItens { get; set; }
        public double? VrBaseCalculoCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? BCQuantidadeCofins { get; set; }
        public double? AliquotaCofinsReais { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C385|");
            writer.Append(CSTCofins + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(VrTotalItens + "|");
            writer.Append(VrBaseCalculoCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(BCQuantidadeCofins + "|");
            writer.Append(AliquotaCofinsReais + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTCofins = data[2];
            CodigoItem = data[3];
            VrTotalItens = data[4].ToNullableDouble();
            VrBaseCalculoCofins = data[5].ToNullableDouble();
            AliquotaCofins = data[6].ToNullableDouble();
            BCQuantidadeCofins = data[7].ToNullableDouble();
            AliquotaCofinsReais = data[8].ToNullableDouble();
            VrCofins = data[9].ToNullableDouble();
            CodigoContaContabil = data[10];
        }
    }
}