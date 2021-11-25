using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Consolidação das operações da pj submetida ao retime de tributação com base no lucro presumido - pis e cofins competência
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF550 : Primitives.Registro
    {
        public RegistroF550() : base("F550")
        {
        }

        public RegistroF550(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? VrTotalRecAufCSTAliq { get; set; }
        public string CSTPis { get; set; } = null;
        public double? VrDescontoExclBcCalculoPis { get; set; }
        public double? VrBcPis { get; set; }
        public double? AliqPis { get; set; }
        public double? VrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? VrDescontoExclBcCalculoCofins { get; set; }
        public double? VrBcCofins { get; set; }
        public double? AliqCofins { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoModDocFiscal { get; set; } = null;
        public string CFOP { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F550|");
            writer.Append(VrTotalRecAufCSTAliq + "|");
            writer.Append(CSTPis + "|");
            writer.Append(VrDescontoExclBcCalculoPis + "|");
            writer.Append(VrBcPis + "|");
            writer.Append(AliqPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrDescontoExclBcCalculoCofins + "|");
            writer.Append(VrBcCofins + "|");
            writer.Append(AliqCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoModDocFiscal + "|");
            writer.Append(CFOP + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalRecAufCSTAliq = data[2].ToNullableDouble();
            CSTPis = data[3];
            VrDescontoExclBcCalculoPis = data[4].ToNullableDouble();
            VrBcPis = data[5].ToNullableDouble();
            AliqPis = data[6].ToNullableDouble();
            VrPis = data[7].ToNullableDouble();
            CSTCofins = data[8];
            VrDescontoExclBcCalculoCofins = data[9].ToNullableDouble();
            VrBcCofins = data[10].ToNullableDouble();
            AliqCofins = data[11].ToNullableDouble();
            VrCofins = data[12].ToNullableDouble();
            CodigoModDocFiscal = data[13];
            CFOP = data[14];
            CodigoContaContabil = data[15];
            InfoComplementar = data[16];
        }
    }
}