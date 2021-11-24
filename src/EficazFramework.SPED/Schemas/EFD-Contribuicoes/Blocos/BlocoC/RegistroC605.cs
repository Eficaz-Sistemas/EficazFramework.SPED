using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento da Consolidação Diária
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC605 : Primitives.Registro
    {
        public RegistroC605() : base("C605")
        {
        }

        public RegistroC605(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CstCofins { get; set; } = null;
        public double? VrTotaItens { get; set; }
        public double? VrBaseCalculoCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? VrCofins { get; set; }
        public string CodContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C605|");
            writer.Append(CstCofins + "|");
            writer.Append(VrTotaItens + "|");
            writer.Append(VrBaseCalculoCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CstCofins = data[2];
            VrTotaItens = data[3].ToNullableDouble();
            VrBaseCalculoCofins = data[4].ToNullableDouble();
            AliquotaCofins = data[5].ToNullableDouble();
            VrCofins = data[6].ToNullableDouble();
            CodContaContabil = data[7];
        }
    }
}