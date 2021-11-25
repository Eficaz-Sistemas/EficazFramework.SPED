using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento da Operação
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD501 : Primitives.Registro
    {
        public RegistroD501() : base("D501")
        {
        }

        public RegistroD501(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTPis { get; set; } = null;
        public double? VrTotalItens { get; set; }
        public string NatBcCalculo { get; set; } = null;
        public double? VrBCPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? VrPis { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D501|");
            writer.Append(CSTPis + "|");
            writer.Append(string.Format("{0:0.##}", VrTotalItens) + "|");
            writer.Append(NatBcCalculo + "|");
            writer.Append(string.Format("{0:0.##}", VrBCPis) + "|");
            writer.Append(string.Format("{0:0.####}", AliquotaPis) + "|");
            writer.Append(string.Format("{0:0.##}", VrPis) + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTPis = data[2];
            VrTotalItens = data[3].ToNullableDouble();
            NatBcCalculo = data[4];
            VrBCPis = data[5].ToNullableDouble();
            AliquotaPis = data[6].ToNullableDouble();
            VrPis = data[7].ToNullableDouble();
            CodigoContaContabil = data[8];
        }
    }
}