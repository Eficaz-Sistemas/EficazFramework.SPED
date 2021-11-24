using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Abertura do Bloco B
    /// </summary>
    /// <remarks></remarks>

    public class RegistroB350 : Primitives.Registro
    {
        public RegistroB350() : base("B350")
        {
        }

        public RegistroB350(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|B350|"); // 1
            writer.Append(CodContaPlano + "|"); // 2
            writer.Append(DescContaPlano + "|"); // 3
            writer.Append(CodCosifInstFin + "|"); // 4
            writer.Append(QuantOcorrConta + "|"); // 5
            writer.Append(CodServico + "|"); // 6
            writer.Append(string.Format("{0:0.##}", ValorContabil) + "|"); // 7
            writer.Append(string.Format("{0:0.##}", ValorBCISS) + "|"); // 8
            writer.Append(string.Format("{0:0.##}", AliquotaISS) + "|"); // 9
            writer.Append(string.Format("{0:0.##}", ValorISS) + "|"); // 10
            writer.Append(CodObsLacto + "|"); // 11
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodContaPlano = data[2].ToString();
            DescContaPlano = data[3].ToString();
            CodCosifInstFin = data[4].ToString();
            QuantOcorrConta = data[5].ToNullableInteger();
            CodServico = data[6].ToString();
            ValorContabil = data[7].ToNullableDouble();
            ValorBCISS = data[8].ToNullableDouble();
            AliquotaISS = data[9].ToNullableDouble();
            ValorISS = data[10].ToNullableDouble();
            CodObsLacto = data[11].ToString();
        }

        public string CodContaPlano { get; set; } = null; // 2
        public string DescContaPlano { get; set; } = null; // 3
        public string CodCosifInstFin { get; set; } = null; // 4
        public int? QuantOcorrConta { get; set; } = default; // 5
        public string CodServico { get; set; } = null; // 6
        public double? ValorContabil { get; set; } = default; // 7
        public double? ValorBCISS { get; set; } = default; // 8
        public double? AliquotaISS { get; set; } = default; // 9
        public double? ValorISS { get; set; } = default; // 10
        public string CodObsLacto { get; set; } = null; // 11
    }
}