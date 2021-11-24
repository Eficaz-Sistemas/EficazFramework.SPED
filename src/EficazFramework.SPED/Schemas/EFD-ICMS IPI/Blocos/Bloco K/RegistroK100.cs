using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Período da Apuração do ICMS
    /// </summary>
    /// <remarks></remarks>
    public class RegistroK100 : Primitives.Registro
    {
        public RegistroK100() : base("K100")
        {
        }

        public RegistroK100(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K100|"); // 1
            writer.Append(DataInicial.ToSpedString() + "|"); // 2
            writer.Append(DataFinal.ToSpedString() + "|"); // 2
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataInicial = data[2].ToDate(); // 2
            DataFinal = data[3].ToDate();
        }

        public DateTime? DataInicial { get; set; } = default; // 2
        public DateTime? DataFinal { get; set; } = default; // 3

        // Registros Filhos
        public RegistroE110 RegistroE110 { get; set; } = null;
    }
}