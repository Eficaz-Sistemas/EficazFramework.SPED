using System;
using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Movimentação Diária de Combustíveis
    /// </summary>
    /// <remarks></remarks>
    public class Registro1300 : Primitives.Registro
    {
        public Registro1300() : base("1300")
        {
        }

        public Registro1300(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1300|"); // 1
            writer.Append(CodigoCombustivel0200 + "|"); // 2
            writer.Append(DataFechamento.ToSpedString() + "|");  // 3
            writer.Append(string.Format("{0:0.###}", EstoqueAbertura) + "|"); // 4
            writer.Append(string.Format("{0:0.###}", VolumeEntradas) + "|"); // 5
            writer.Append(string.Format("{0:0.###}", VolumeDisponivel) + "|");  // 6
            writer.Append(string.Format("{0:0.###}", VolumeSaidas) + "|");  // 7
            writer.Append(string.Format("{0:0.###}", EstoqueEscritural) + "|");  // 8
            writer.Append(string.Format("{0:0.###}", AjustesPerda) + "|");  // 9
            writer.Append(string.Format("{0:0.###}", AjustesGanho) + "|"); // 10
            writer.Append(string.Format("{0:0.###}", EstoqueFechamento) + "|");  // 11
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoCombustivel0200 = data[2];
            DataFechamento = data[3].ToDate();
            EstoqueAbertura = data[4].ToNullableDouble();
            VolumeEntradas = data[5].ToNullableDouble();
            VolumeDisponivel = data[6].ToNullableDouble();
            VolumeSaidas = data[7].ToNullableDouble();
            EstoqueEscritural = data[8].ToNullableDouble();
            AjustesPerda = data[9].ToNullableDouble();
            AjustesGanho = data[10].ToNullableDouble();
            EstoqueFechamento = data[11].ToNullableDouble();
        }

        public string CodigoCombustivel0200 { get; set; } = null; // 2
        public DateTime? DataFechamento { get; set; } = default; // 3
        public double? EstoqueAbertura { get; set; } = default; // 4
        public double? VolumeEntradas { get; set; } = default; // 5
        /// <summary>
        /// Estoque Abertura + Volume Entradas
        /// </summary>
        public double? VolumeDisponivel { get; set; } = default; // 6
        public double? VolumeSaidas { get; set; } = default; // 7
        /// <summary>
        /// Volume Disponível - Volume Saídas
        /// </summary>
        public double? EstoqueEscritural { get; set; } = default; // 8
        public double? AjustesPerda { get; set; } = default; // 9
        public double? AjustesGanho { get; set; } = default; // 10
        public double? EstoqueFechamento { get; set; } = default; // 11


        // Registros Filhos
        public List<Registro1310> Registros1310 { get; set; } = new List<Registro1310>();
        // Property RegistrosC114 As New List(Of RegistroC114)
        // Property RegistrosC120 As New List(Of RegistroC120)
        // Property RegistrosC190 As New List(Of RegistroC190)
        // Property RegistrosC195 As New List(Of RegistroC195)

    }
}