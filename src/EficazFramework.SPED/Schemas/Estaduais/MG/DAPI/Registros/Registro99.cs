using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.MG.DAPI
{

    /// <summary>
    /// Total de Linhas do Arquivo
    /// </summary>
    public class Registro99 : Primitives.Registro
    {
        public Registro99() : base("99")
        {
        }

        public Registro99(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("99"); // 1 Código Registro
            writer.Append(InscricaoEstadual.ToFixedLenghtString(13, Alignment.Left, "0")); // 2 
            writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3 Competencia no Formato AAAAMMDD
            writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.DD)); // 4 Competencia no Formato DD
            writer.Append(TotalLinhas.ToString().ToFixedLenghtString(4, Alignment.Left, "0")); // 5
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
        }

        public string InscricaoEstadual { get; set; } = null;
        public DateTime? DataFinal { get; set; } = default;
        public DateTime? DataInicial { get; set; } = default;
        public long TotalLinhas { get; set; } = 0L;
    }
}