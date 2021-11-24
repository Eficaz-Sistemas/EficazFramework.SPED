using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Balancetes Diários - Identificação da Data
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI300 : Primitives.Registro
    {
        public RegistroI300() : base("I300")
        {
        }

        public RegistroI300(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public DateTime? DataBalancete { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I300|");
            writer.Append(DataBalancete.ToSpedString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataBalancete = data[2].ToDate();
        }
    }
}