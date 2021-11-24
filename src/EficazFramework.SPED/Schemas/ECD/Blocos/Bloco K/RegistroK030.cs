using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Período da Escrituração Contábil Consolidada
    /// </summary>
    /// <remarks></remarks>

    public class RegistroK030 : Primitives.Registro
    {
        public RegistroK030() : base("K030")
        {
        }

        public RegistroK030(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public DateTime? DataInicialPeriodoConsolidado { get; set; }
        public DateTime? DataFinalPeriodoConsolidado { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K030|");
            writer.Append(DataInicialPeriodoConsolidado + "|");
            writer.Append(DataFinalPeriodoConsolidado + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataInicialPeriodoConsolidado = data[2].ToDate();
            DataFinalPeriodoConsolidado = data[3].ToDate();
        }
    }
}