using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Crédito presumido sobre estoques de abertura
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF150 : Primitives.Registro
    {
        public RegistroF150() : base("F150")
        {
        }

        public RegistroF150(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NatBcCredito { get; set; } = null;
        public double? VrTotalEstoqueAbertura { get; set; }
        public double? ParcelaEstoqueSemCred { get; set; }
        public double? VrBcEstoqueAbertura { get; set; }
        public double? VrBcMensalCredEstoqueAbert { get; set; }
        public string CSTPis { get; set; } = null;
        public double? AliqPis { get; set; }
        public double? VrMensalCredPresApPeriodoPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? AliqCofins { get; set; }
        public double? VrMensalCredPresApPeriodoCofins { get; set; }
        public string DescricaoEstoque { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F150|");
            writer.Append(NatBcCredito + "|");
            writer.Append(VrTotalEstoqueAbertura + "|");
            writer.Append(ParcelaEstoqueSemCred + "|");
            writer.Append(VrBcEstoqueAbertura + "|");
            writer.Append(VrBcMensalCredEstoqueAbert + "|");
            writer.Append(CSTPis + "|");
            writer.Append(AliqPis + "|");
            writer.Append(VrMensalCredPresApPeriodoPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(AliqCofins + "|");
            writer.Append(VrMensalCredPresApPeriodoCofins + "|");
            writer.Append(DescricaoEstoque + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NatBcCredito = data[2];
            VrTotalEstoqueAbertura = data[3].ToNullableDouble();
            ParcelaEstoqueSemCred = data[4].ToNullableDouble();
            VrBcEstoqueAbertura = data[5].ToNullableDouble();
            VrBcMensalCredEstoqueAbert = data[6].ToNullableDouble();
            CSTPis = data[7];
            AliqPis = data[8].ToNullableDouble();
            VrMensalCredPresApPeriodoPis = data[9].ToNullableDouble();
            CSTCofins = data[10];
            AliqCofins = data[11].ToNullableDouble();
            VrMensalCredPresApPeriodoCofins = data[12].ToNullableDouble();
            DescricaoEstoque = data[13];
            CodigoContaContabil = data[14];
        }
    }
}