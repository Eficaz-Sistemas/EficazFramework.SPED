
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C160: VOLUMES TRANSPORTADOS (CÓDIGO 01 E 04) - EXCETO COMBUSTÍVEIS
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC160 : Primitives.Registro
    {
        public RegistroC160() : base("C160")
        {
        }

        public RegistroC160(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C160|"); // 1
            writer.Append(CodParticipante + "|"); // 2
            writer.Append(PlacaVeiculoIdent + "|"); // 3
            writer.Append(QuantVolumeTransp + "|"); // 4
            writer.Append(string.Format("{0:0.##}", PesoBrutoTransp) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", PesoLiquidoTransp) + "|"); // 6
            writer.Append(UFPlacaVeiculo + "|"); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodParticipante = data[2];
            PlacaVeiculoIdent = data[3];
            QuantVolumeTransp = data[4];
            PesoBrutoTransp = data[5].ToNullableDouble();
            PesoLiquidoTransp = data[6].ToNullableDouble();
            UFPlacaVeiculo = data[7].ToString();
        }

        public string CodParticipante { get; set; } = null; // 2
        public string PlacaVeiculoIdent { get; set; } = null; // 3
        public string QuantVolumeTransp { get; set; } = null; // 4
        public double? PesoBrutoTransp { get; set; } = default; // 5
        public double? PesoLiquidoTransp { get; set; } = default; // 6
        public string UFPlacaVeiculo { get; set; } = null; // 7
    }
}