using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Consolidação das operações da pessoa jurídica submetida ao regime de tributação com base no lucro presumido - incidência do pis e da cofins pelo regime de caixa
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF500 : Primitives.Registro
    {
        public RegistroF500() : base("F500")
        {
        }

        public RegistroF500(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? VrTotalRecRecebCSTAliquota { get; set; }
        public string CSTPis { get; set; } = null;
        public double? VrDescontoBcPis { get; set; }
        public double? VrBcPis { get; set; }
        public double? AliqPis { get; set; }
        public double? VrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? VrDescontoBcCofins { get; set; }
        public double? VrBcCofins { get; set; }
        public double? AliqCofins { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoModeloDocFiscal { get; set; } = null;
        public string CFOP { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F500|");
            writer.Append(VrTotalRecRecebCSTAliquota + "|");
            writer.Append(CSTPis + "|");
            writer.Append(VrDescontoBcPis + "|");
            writer.Append(VrBcPis + "|");
            writer.Append(AliqPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrDescontoBcCofins + "|");
            writer.Append(VrBcCofins + "|");
            writer.Append(AliqCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoModeloDocFiscal + "|");
            writer.Append(CFOP + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalRecRecebCSTAliquota = data[2].ToNullableDouble();
            CSTPis = data[3];
            VrDescontoBcPis = data[4].ToNullableDouble();
            VrBcPis = data[5].ToNullableDouble();
            AliqPis = data[6].ToNullableDouble();
            VrPis = data[7].ToNullableDouble();
            CSTCofins = data[8];
            VrDescontoBcCofins = data[9].ToNullableDouble();
            VrBcCofins = data[10].ToNullableDouble();
            AliqCofins = data[11].ToNullableDouble();
            VrCofins = data[12].ToNullableDouble();
            CodigoModeloDocFiscal = data[13];
            CFOP = data[14];
            CodigoContaContabil = data[15];
            InfoComplementar = data[16];
        }
    }
}