using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Bombas
    /// </summary>
    /// <remarks></remarks>
    public class Registro1350 : Primitives.Registro
    {
        public Registro1350() : base("1350")
        {
        }

        public Registro1350(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1350|"); // 1
            writer.Append(NumeroSerie + "|"); // 2
            if ((Fabricante ?? "").Length <= 60)
                writer.Append(Fabricante + "|");
            else
                writer.Append(Fabricante.Substring(0, 60) + "|");  // 3
            writer.Append(Modelo + "|"); // 4
            writer.Append(TipoMedicao + "|"); // 5
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroSerie = data[2];
            Fabricante = data[3];
            Modelo = data[4];
            TipoMedicao = Conversions.ToInteger(data[5]);
        }

        public string NumeroSerie { get; set; } = null; // 2
        public string Fabricante { get; set; } = null; // 3
        public string Modelo { get; set; } = null; // 4
        public int TipoMedicao { get; set; } = 1; // 5

        // Registros Filhos
        public List<Registro1360> Registros1360 { get; set; } = new List<Registro1360>();
        public List<Registro1370> Registros1370 { get; set; } = new List<Registro1370>();
        // Property RegistrosC120 As New List(Of RegistroC120)
        // Property RegistrosC190 As New List(Of RegistroC190)
        // Property RegistrosC195 As New List(Of RegistroC195)

    }
}