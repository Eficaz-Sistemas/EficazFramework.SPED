using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C165: OPERAÇÕES COM COMBUSTÍVEIS
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC165 : Primitives.Registro
    {
        public RegistroC165() : base("C165")
        {
        }

        public RegistroC165(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C165|"); // 1
            writer.Append(CodParticipante + "|"); // 2
            writer.Append(PlacaIdentificacaoVeiculo + "|"); // 3
            writer.Append(CodAutorizacaoSefaz + "|"); // 4
            writer.Append(NumPasseFiscal + "|"); // 5
            writer.Append(string.Format("{0:HHmmss}", HoraSaideMercadorias) + "|"); // 6
            writer.Append(string.Format("{0:0.#}", TemperaturaVolumeCombustivel) + "|"); // 7
            writer.Append(QuantVolumesTransportados + "|"); // 8
            writer.Append(string.Format("{0:0.##}", PesoBrutoVolumes) + "|"); // 9
            writer.Append(string.Format("{0:0.##}", PesoLiquidoVolumes) + "|"); // 10
            writer.Append(NomeMotorista + "|"); // 11
            writer.Append(CPFMotorista + "|"); // 12
            writer.Append(UFPlacaVeiculo + "|"); // 13
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodParticipante = data[2].ToString();
            PlacaIdentificacaoVeiculo = data[3].ToString();
            CodAutorizacaoSefaz = data[4].ToString();
            NumPasseFiscal = data[5].ToString();
            HoraSaideMercadorias = data[6].ToTime(TimeFormat.HHMMSS);
            TemperaturaVolumeCombustivel = data[7].ToNullableDouble();
            QuantVolumesTransportados = data[8].ToString();
            PesoBrutoVolumes = data[9].ToNullableDouble();
            PesoLiquidoVolumes = data[10].ToNullableDouble();
            NomeMotorista = data[11].ToString();
            CPFMotorista = data[12].ToString();
            UFPlacaVeiculo = data[13].ToString();
        }

        public string CodParticipante { get; set; } = null; // 2
        public string PlacaIdentificacaoVeiculo { get; set; } = null; // 3
        public string CodAutorizacaoSefaz { get; set; } = null; // 4
        public string NumPasseFiscal { get; set; } = null; // 5
        public TimeSpan? HoraSaideMercadorias { get; set; } = default; // 6
        public double? TemperaturaVolumeCombustivel { get; set; } = default; // 7
        public string QuantVolumesTransportados { get; set; } = null; // 8
        public double? PesoBrutoVolumes { get; set; } = default; // 9
        public double? PesoLiquidoVolumes { get; set; } = default; // 10
        public string NomeMotorista { get; set; } = null; // 11
        public string CPFMotorista { get; set; } = null; // 12
        public string UFPlacaVeiculo { get; set; } = null; // 13
    }
}