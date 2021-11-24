using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Consolidação das operações da pessoa jurídica submetida ao regime de tributação com base no lucro presumido
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF510 : Primitives.Registro
    {
        public RegistroF510() : base("F510")
        {
        }

        public RegistroF510(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? VrTotalRecRecebCSTAliquotaCaixa { get; set; }
        public string CSTPis { get; set; } = null;
        public double? VrDescontoBcPis { get; set; }
        public double? VrBcPisQtde { get; set; }
        public double? AliqPisQtde { get; set; }
        public double? VrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? VrDescontoBcCofins { get; set; }
        public double? VrBcCofinsQtde { get; set; }
        public double? AliqCofinsQtde { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoModeloDocFiscal { get; set; } = null;
        public string CFOP { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F510|");
            writer.Append(VrTotalRecRecebCSTAliquotaCaixa + "|");
            writer.Append(CSTPis + "|");
            writer.Append(VrDescontoBcPis + "|");
            writer.Append(VrBcPisQtde + "|");
            writer.Append(AliqPisQtde + "|");
            writer.Append(VrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrDescontoBcCofins + "|");
            writer.Append(VrBcCofinsQtde + "|");
            writer.Append(AliqCofinsQtde + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoModeloDocFiscal + "|");
            writer.Append(CFOP + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalRecRecebCSTAliquotaCaixa = data[2].ToNullableDouble();
            CSTPis = data[3];
            VrDescontoBcPis = data[4].ToNullableDouble();
            VrBcPisQtde = data[5].ToNullableDouble();
            AliqPisQtde = data[6].ToNullableDouble();
            VrPis = data[7].ToNullableDouble();
            CSTCofins = data[8];
            VrDescontoBcCofins = data[9].ToNullableDouble();
            VrBcCofinsQtde = data[10].ToNullableDouble();
            AliqCofinsQtde = data[11].ToNullableDouble();
            VrCofins = data[12].ToNullableDouble();
            CodigoModeloDocFiscal = data[13];
            CFOP = data[14];
            CodigoContaContabil = data[15];
            InfoComplementar = data[16];
        }
    }
}