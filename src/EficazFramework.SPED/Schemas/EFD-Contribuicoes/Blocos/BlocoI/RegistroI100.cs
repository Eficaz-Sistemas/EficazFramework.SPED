using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Consolidação das Operações do Período
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI100 : Primitives.Registro
    {
        public RegistroI100() : base("I100")
        {
        }

        public RegistroI100(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? VrTotalFatBrutoPeriodo { get; set; }
        public string CSTPisCofinsReceitaPeriodo { get; set; } = null;
        public double? VrTotalDedExclusoesCaraterGeral { get; set; }
        public double? VrTotalDedExclusoesCaraterEspecif { get; set; }
        public double? VrBcPis { get; set; }
        public double? AliqPis { get; set; }
        public double? VrPis { get; set; }
        public double? VrBcCofins { get; set; }
        public double? AliqCofins { get; set; }
        public double? VrCofins { get; set; }
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F001|");
            writer.Append(VrTotalFatBrutoPeriodo + "|");
            writer.Append(CSTPisCofinsReceitaPeriodo + "|");
            writer.Append(VrTotalDedExclusoesCaraterGeral + "|");
            writer.Append(VrTotalDedExclusoesCaraterEspecif + "|");
            writer.Append(VrBcPis + "|");
            writer.Append(AliqPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(VrBcCofins + "|");
            writer.Append(AliqCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalFatBrutoPeriodo = data[2].ToNullableDouble();
            CSTPisCofinsReceitaPeriodo = data[3];
            VrTotalDedExclusoesCaraterGeral = data[4].ToNullableDouble();
            VrTotalDedExclusoesCaraterEspecif = data[5].ToNullableDouble();
            VrBcPis = data[6].ToNullableDouble();
            AliqPis = data[7].ToNullableDouble();
            VrPis = data[8].ToNullableDouble();
            VrBcCofins = data[9].ToNullableDouble();
            AliqCofins = data[10].ToNullableDouble();
            VrCofins = data[11].ToNullableDouble();
            InfoComplementar = data[12];
        }
    }
}