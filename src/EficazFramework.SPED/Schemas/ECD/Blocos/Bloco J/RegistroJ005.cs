using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Demonstrações Contábeis
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ005 : Primitives.Registro
    {
        public RegistroJ005() : base("J005")
        {
        }

        public RegistroJ005(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public DateTime? DataInicialDC { get; set; }
        public DateTime? DataFinalDC { get; set; }
        public string IdentificacaoDemonstracoes { get; set; } = null;
        public string CabecalhoDemonstracoes { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J005|");
            writer.Append(DataInicialDC.ToSpedString() + "|");
            writer.Append(DataFinalDC.ToSpedString() + "|");
            writer.Append(IdentificacaoDemonstracoes + "|");
            writer.Append(CabecalhoDemonstracoes + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataInicialDC = data[2].ToDate();
            DataFinalDC = data[3].ToDate();
            IdentificacaoDemonstracoes = data[4];
            CabecalhoDemonstracoes = data[5];
        }
    }
}