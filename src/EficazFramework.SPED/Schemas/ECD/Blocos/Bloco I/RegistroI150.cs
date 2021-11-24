using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Saldos Periódicos - Identificação do Período
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI150 : Primitives.Registro
    {
        public RegistroI150() : base("I150")
        {
        }

        public RegistroI150(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public DateTime? DataInicioPeriodo { get; set; }
        public DateTime? DataFinalPeriodo { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I150|");
            writer.Append(DataInicioPeriodo.ToSpedString() + "|");
            writer.Append(DataFinalPeriodo.ToSpedString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataInicioPeriodo = data[2].ToDate();
            DataFinalPeriodo = data[3].ToDate();
        }
    }
}