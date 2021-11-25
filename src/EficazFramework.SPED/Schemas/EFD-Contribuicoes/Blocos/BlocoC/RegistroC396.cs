using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Itens do Documento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC396 : Primitives.Registro
    {
        public RegistroC396() : base("C396")
        {
        }

        public RegistroC396(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoItem { get; set; } = null;
        public double? ValorItem { get; set; }
        public double? ValorDesconto { get; set; }
        public string NaturezaBCCredito { get; set; } = null;
        public string CSTPis { get; set; } = null;
        public double? ValorBCPis { get; set; }
        public double? AliquotaPIS { get; set; }
        public double? ValorPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? ValorBCCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? ValorCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C396|");
            writer.Append(CodigoItem + "|");
            writer.Append(ValorItem + "|");
            writer.Append(ValorDesconto + "|");
            writer.Append(NaturezaBCCredito + "|");
            writer.Append(CSTPis + "|");
            writer.Append(ValorBCPis + "|");
            writer.Append(AliquotaPIS + "|");
            writer.Append(ValorPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(ValorBCCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(ValorCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoItem = data[2];
            ValorItem = data[3].ToNullableDouble();
            ValorDesconto = data[4].ToNullableDouble();
            NaturezaBCCredito = data[5];
            CSTPis = data[6];
            ValorBCPis = data[7].ToNullableDouble();
            AliquotaPIS = data[8].ToNullableDouble();
            ValorPis = data[9].ToNullableDouble();
            CSTCofins = data[10];
            ValorBCCofins = data[11].ToNullableDouble();
            AliquotaCofins = data[12].ToNullableDouble();
            ValorCofins = data[13].ToNullableDouble();
            CodigoContaContabil = data[14];
        }
    }
}