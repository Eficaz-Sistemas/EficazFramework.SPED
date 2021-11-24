using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Lacre da Bomba
    /// </summary>
    /// <remarks></remarks>
    public class Registro1360 : Primitives.Registro
    {
        public Registro1360() : base("1360")
        {
        }

        public Registro1360(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1360|"); // 1
            writer.Append(NumeroLacre + "|"); // 2
            writer.Append(DataAplicacao.ToSpedString() + "|"); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroLacre = data[2];
            DataAplicacao = data[3].ToDate();
        }

        public string NumeroLacre { get; set; } = null; // 2
        public DateTime? DataAplicacao { get; set; } = default; // 3
    }
}