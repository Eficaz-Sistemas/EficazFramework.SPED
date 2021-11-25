using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Registro Anaítico do Documento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC175 : Primitives.Registro
    {
        public RegistroC175() : base("C175")
        {
        }

        public RegistroC175(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CFOP { get; set; } = null;
        public double? VrOperacaoCombinacaoCFOPCSTeAliquotas { get; set; }
        public double? VrDescontoComercialExclusao { get; set; }
        public string CSTPIS { get; set; } = null;
        public double? VrBaseCalculoPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? BCPISquantidade { get; set; }
        public double? AliquotaPISReais { get; set; }
        public double? VrPIS { get; set; }
        public string CSTCOFINS { get; set; } = null;
        public double? VrBaseCalculoCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? BCCOFINSquantidade { get; set; }
        public double? AliquotaCOFINSReais { get; set; }
        public double? VrCOFINS { get; set; }
        public string CodigoContaContabil { get; set; } = null;
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C175|");
            writer.Append(CFOP + "|");
            writer.Append(string.Format("{0:0.##}", VrOperacaoCombinacaoCFOPCSTeAliquotas) + "|");
            writer.Append(string.Format("{0:0.##}", VrDescontoComercialExclusao) + "|");
            writer.Append(CSTPIS + "|");
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoPis) + "|");
            writer.Append(string.Format("{0:0.####}", AliquotaPis) + "|");
            writer.Append(string.Format("{0:0.###}", BCPISquantidade) + "|");
            writer.Append(string.Format("{0:0.####}", AliquotaPISReais) + "|");
            writer.Append(string.Format("{0:0.##}", VrPIS) + "|");
            writer.Append(CSTCOFINS + "|");
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoCofins) + "|");
            writer.Append(string.Format("{0:0.####}", AliquotaCofins) + "|");
            writer.Append(string.Format("{0:0.###}", BCCOFINSquantidade) + "|");
            writer.Append(string.Format("{0:0.####}", AliquotaCOFINSReais) + "|");
            writer.Append(string.Format("{0:0.##}", VrCOFINS) + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CFOP = data[2];
            VrOperacaoCombinacaoCFOPCSTeAliquotas = data[3].ToNullableDouble();
            VrDescontoComercialExclusao = data[4].ToNullableDouble();
            CSTPIS = data[5];
            VrBaseCalculoPis = data[6].ToNullableDouble();
            AliquotaPis = data[7].ToNullableDouble();
            BCPISquantidade = data[8].ToNullableDouble();
            AliquotaPISReais = data[9].ToNullableDouble();
            VrPIS = data[10].ToNullableDouble();
            CSTCOFINS = data[11];
            VrBaseCalculoCofins = data[12].ToNullableDouble();
            AliquotaCofins = data[13].ToNullableDouble();
            BCCOFINSquantidade = data[14].ToNullableDouble();
            AliquotaCOFINSReais = data[15].ToNullableDouble();
            VrCOFINS = data[16].ToNullableDouble();
            CodigoContaContabil = data[17];
            InfoComplementar = data[18];
        }
    }
}