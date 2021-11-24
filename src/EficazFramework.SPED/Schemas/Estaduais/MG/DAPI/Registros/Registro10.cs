using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.MG.DAPI
{

    /// <summary>
    /// Valores por CFOP
    /// </summary>
    public class Registro10 : Primitives.Registro
    {
        public Registro10() : base("10")
        {
        }

        public Registro10(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("10"); // 1 Código Registro
            writer.Append(InscricaoEstadual.ToFixedLenghtString(13, Alignment.Left, "0")); // 2 IE do Contribuinte
            writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3 Competencia no Formato AAAAMMDD
            writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.DD)); // 4 Competencia no Formato DD
            writer.Append(Linha.ToFixedLenghtString(3, Alignment.Left, "0")); // 5 Linha
            writer.Append(Coluna.ToFixedLenghtString(2, Alignment.Left, "0")); // 6 Coluna
            writer.Append(ValorDeclarado.ValueToString(2).ToFixedLenghtString(15, Alignment.Left, "0")); // 7 valor declarado
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
        }

        public string InscricaoEstadual { get; set; } = null;
        public DateTime? DataFinal { get; set; } = default;
        public DateTime? DataInicial { get; set; } = default;
        public string Linha { get; set; } = null;
        public string Coluna { get; set; } = null;
        public double? ValorDeclarado { get; set; } = default;
    }
}