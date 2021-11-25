using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Totalização Resumo Diário
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD205 : Primitives.Registro
    {
        public RegistroD205() : base("D205")
        {
        }

        public RegistroD205(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTCofins { get; set; } = null;
        public double? VrTotalItens { get; set; }
        public double? VrBcCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D205|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrTotalItens + "|");
            writer.Append(VrBcCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTCofins = data[2];
            VrTotalItens = data[3].ToNullableDouble();
            VrBcCofins = data[4].ToNullableDouble();
            AliquotaCofins = data[5].ToNullableDouble();
            VrCofins = data[6].ToNullableDouble();
            CodigoContaContabil = data[7];
        }
    }
}