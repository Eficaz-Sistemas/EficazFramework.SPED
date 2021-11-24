using System;
using System.Collections.Generic;
using System.Linq;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Redução Z (Código 02, 2D e 60)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC405 : Primitives.Registro
    {
        public RegistroC405() : base("C405")
        {
        }

        public RegistroC405(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C405|"); // 1
            writer.Append(Data.ToSpedString() + "|"); // 2
            writer.Append(CRO + "|"); // 3
            writer.Append(CRZ + "|"); // 4
            writer.Append(COO + "|"); // 5
            writer.Append(string.Format("{0:0.##}", GrandeTotalFinal) + "|"); // 6
            writer.Append(string.Format("{0:0.##}", VendaBruta) + "|"); // 7
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Data = data[2].ToDate();
            CRO = data[3].ToNullableInteger();
            CRZ = data[4].ToNullableInteger();
            COO = data[5].ToNullableInteger();
            GrandeTotalFinal = data[6].ToNullableDouble();
            VendaBruta = data[7].ToNullableDouble();
        }

        public DateTime? Data { get; set; } = default; // 2

        /// <summary>
        /// Contador Reinínio Operação
        /// </summary>
        public int? CRO { get; set; } = default; // 3
        /// <summary>
        /// Contador de Redução Z
        /// </summary>
        public int? CRZ { get; set; } = default; // 4
        /// <summary>
        /// Contador de Redução Z
        /// </summary>
        public int? COO { get; set; } = default; // 5
        public double? GrandeTotalFinal { get; set; } = default; // 6
        public double? VendaBruta { get; set; } = default; // 7

        // Registros Filhos
        public RegistroC410 RegistroC410 { get; set; } = null;
        public List<RegistroC420> RegistrosC420 { get; set; } = new List<RegistroC420>();
        public List<RegistroC460> RegistrosC460 { get; set; } = new List<RegistroC460>();
        public List<RegistroC470> RegistrosC470 { get; set; } = new List<RegistroC470>();
        public List<RegistroC490> RegistrosC490 { get; set; } = new List<RegistroC490>();

        public bool PossuiItemsC425
        {
            get
            {
                return RegistrosC420.Where(f => f.RegistrosC425.Count > 0).Select(f => f.RegistrosC425.Count).Count() > 0;
            }
        }

        public bool PossuiItemsC470
        {
            get
            {
                return RegistrosC470.Count > 0;
            }
        }
    }
}