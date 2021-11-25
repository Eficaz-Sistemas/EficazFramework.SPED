using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Movimentação Diária de Combustíveis por Tanque
    /// </summary>
    /// <remarks></remarks>
    public class Registro1310 : Primitives.Registro
    {
        public Registro1310() : base("1310")
        {
        }

        public Registro1310(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1310|"); // 1
            writer.Append(NumeroTanque + "|"); // 2
            writer.Append(string.Format("{0:0.###}", EstoqueAbertura) + "|"); // 3
            writer.Append(string.Format("{0:0.###}", VolumeEntradas) + "|"); // 4
            writer.Append(string.Format("{0:0.###}", VolumeDisponivel) + "|");  // 5
            writer.Append(string.Format("{0:0.###}", VolumeSaidas) + "|");  // 6
            writer.Append(string.Format("{0:0.###}", EstoqueEscritural) + "|");  // 7
            writer.Append(string.Format("{0:0.###}", AjustesPerda) + "|");  // 8
            writer.Append(string.Format("{0:0.###}", AjustesGanho) + "|"); // 9
            writer.Append(string.Format("{0:0.###}", EstoqueFechamento) + "|");  // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroTanque = data[2];
            EstoqueAbertura = data[3].ToNullableDouble();
            VolumeEntradas = data[4].ToNullableDouble();
            VolumeDisponivel = data[5].ToNullableDouble();
            VolumeSaidas = data[6].ToNullableDouble();
            EstoqueEscritural = data[7].ToNullableDouble();
            AjustesPerda = data[8].ToNullableDouble();
            AjustesGanho = data[9].ToNullableDouble();
            EstoqueFechamento = data[10].ToNullableDouble();
        }

        public string NumeroTanque { get; set; } = null; // 2
        public double? EstoqueAbertura { get; set; } = default; // 3
        public double? VolumeEntradas { get; set; } = default; // 4
        /// <summary>
        /// Estoque Abertura + Volume Entradas
        /// </summary>
        public double? VolumeDisponivel { get; set; } = default; // 5
        public double? VolumeSaidas { get; set; } = default; // 6
        /// <summary>
        /// Volume Disponível - Volume Saídas
        /// </summary>
        public double? EstoqueEscritural { get; set; } = default; // 7
        public double? AjustesPerda { get; set; } = default; // 8
        public double? AjustesGanho { get; set; } = default; // 9
        public double? EstoqueFechamento { get; set; } = default; // 10


        // Registros Filhos
        public List<Registro1320> Registros1320 { get; set; } = new List<Registro1320>();
    }
}