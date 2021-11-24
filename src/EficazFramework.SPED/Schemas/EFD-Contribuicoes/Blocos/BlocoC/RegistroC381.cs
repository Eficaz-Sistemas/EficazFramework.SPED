using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Consolidação - PIS/PASEP
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC381 : Primitives.Registro
    {
        public RegistroC381() : base("C381")
        {
        }

        public RegistroC381(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTPis { get; set; } = null;
        public string CodigoItem { get; set; } = null;
        public double? VrTotalItens { get; set; }
        public double? VrBaseCalculoPis { get; set; }
        public double? AliquotaPIS { get; set; }
        public double? BCQuantidadePis { get; set; }
        public double? AliquotaPisReais { get; set; }
        public double? VrPIS { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C381|");
            writer.Append(CSTPis + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(VrTotalItens + "|");
            writer.Append(VrBaseCalculoPis + "|");
            writer.Append(AliquotaPIS + "|");
            writer.Append(BCQuantidadePis + "|");
            writer.Append(AliquotaPisReais + "|");
            writer.Append(VrPIS + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTPis = data[2];
            CodigoItem = data[3];
            VrTotalItens = data[4].ToNullableDouble();
            VrBaseCalculoPis = data[5].ToNullableDouble();
            AliquotaPIS = data[6].ToNullableDouble();
            BCQuantidadePis = data[7].ToNullableDouble();
            AliquotaPisReais = data[8].ToNullableDouble();
            VrPIS = data[9].ToNullableDouble();
            CodigoContaContabil = data[10];
        }
    }
}