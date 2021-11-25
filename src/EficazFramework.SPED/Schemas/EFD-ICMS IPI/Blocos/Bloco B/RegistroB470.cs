using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Deduções do ISS
    /// </summary>
    /// <remarks></remarks>

    public class RegistroB470 : Primitives.Registro
    {
        public RegistroB470() : base("B470")
        {
        }

        public RegistroB470(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|B470|"); // 1
            writer.Append(string.Format("{0:0.##}", VrTotalPrestacaoServico) + "|"); // 2
            writer.Append(string.Format("{0:0.##}", VrTotalMaterialTerceiros) + "|"); // 3
            writer.Append(string.Format("{0:0.##}", VrTotalMaterialProprio) + "|"); // 4
            writer.Append(string.Format("{0:0.##}", VrTotalSubempreitadas) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", VrTotalOperIsentasNtributaISS) + "|"); // 6
            writer.Append(string.Format("{0:0.##}", VrTotalDedBC) + "|"); // 7
            writer.Append(string.Format("{0:0.##}", VrTotalBCISS) + "|"); // 8
            writer.Append(string.Format("{0:0.##}", VrTotalBCRetencaoISSPrestDeclarante) + "|"); // 9
            writer.Append(string.Format("{0:0.##}", VrTotalISSDestacado) + "|"); // 10
            writer.Append(string.Format("{0:0.##}", VrTotalISSRetidoTomador) + "|"); // 11
            writer.Append(string.Format("{0:0.##}", VrTotalDeducoesISSProprio) + "|"); // 12
            writer.Append(string.Format("{0:0.##}", VrTotalApuradoISSProprioRecolher) + "|"); // 13
            writer.Append(string.Format("{0:0.##}", VrTotalISSsubstitutoRecolher) + "|"); // 14
            writer.Append(string.Format("{0:0.##}", VrISSProprioRecolherSociedUniprofissional) + "|"); // 15
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalPrestacaoServico = data[2].ToNullableDouble();
            VrTotalMaterialTerceiros = data[3].ToNullableDouble();
            VrTotalMaterialProprio = data[4].ToNullableDouble();
            VrTotalSubempreitadas = data[5].ToNullableDouble();
            VrTotalOperIsentasNtributaISS = (double)data[6].ToNullableDouble();
            VrTotalDedBC = data[7].ToNullableDouble();
            VrTotalBCISS = data[8].ToNullableDouble();
            VrTotalBCRetencaoISSPrestDeclarante = data[9].ToNullableDouble();
            VrTotalISSDestacado = data[10].ToNullableDouble();
            VrTotalISSRetidoTomador = data[11].ToNullableDouble();
            VrTotalDeducoesISSProprio = data[12].ToNullableDouble();
            VrTotalApuradoISSProprioRecolher = data[13].ToNullableDouble();
            VrTotalISSsubstitutoRecolher = data[14].ToNullableDouble();
            VrISSProprioRecolherSociedUniprofissional = data[15].ToNullableDouble();
        }

        public double? VrTotalPrestacaoServico { get; set; } = default; // 2
        public double? VrTotalMaterialTerceiros { get; set; } = default; // 3
        public double? VrTotalMaterialProprio { get; set; } = default; // 4
        public double? VrTotalSubempreitadas { get; set; } = default; // 5
        public double VrTotalOperIsentasNtributaISS { get; set; } = default; // 6
        public double? VrTotalDedBC { get; set; } = default; // 7
        public double? VrTotalBCISS { get; set; } = default; // 8
        public double? VrTotalBCRetencaoISSPrestDeclarante { get; set; } = default; // 9
        public double? VrTotalISSDestacado { get; set; } = default; // 10
        public double? VrTotalISSRetidoTomador { get; set; } = default; // 11
        public double? VrTotalDeducoesISSProprio { get; set; } = default; // 12
        public double? VrTotalApuradoISSProprioRecolher { get; set; } = default; // 13
        public double? VrTotalISSsubstitutoRecolher { get; set; } = default; // 14
        public double? VrISSProprioRecolherSociedUniprofissional { get; set; } = default; // 15
    }
}