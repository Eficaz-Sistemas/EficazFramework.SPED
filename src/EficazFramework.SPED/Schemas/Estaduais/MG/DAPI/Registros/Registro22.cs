using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.MG.DAPI
{

    /// <summary>
    /// Detalhamento de Estorno de Débitos no Campo 90
    /// </summary>
    public class Registro22 : Primitives.Registro
    {
        public Registro22() : base("22")
        {
        }

        public Registro22(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("22"); // 1 Código Registro
            writer.Append(InscricaoEstadual.ToFixedLenghtString(13, Alignment.Left, "0")); // 2 IE do Contribuinte
            writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3 Competencia no Formato AAAAMMDD
            writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.DD)); // 4 Competencia no Formato DD
            writer.Append(NotaFiscal_Numero.ToFixedLenghtString(9, Alignment.Left, "0")); // 5
            writer.Append(NotaFiscal_Serie.ToFixedLenghtString(3, Alignment.Left, "0")); // 6
            writer.Append(NotaFiscal_Data.ToSintegraString(Extensions.DateFormat.AAAADDMM)); // 7
            writer.Append(ValorDeclarado.ValueToString(2).ToFixedLenghtString(15, Alignment.Left, "0")); // 8
            writer.Append(Justificativa.ToFixedLenghtString(13, Alignment.Right, " ")); // 9
            writer.Append(((int)Motivo).ToString().ToFixedLenghtString(1, Alignment.Left, "0")); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
        }

        public string InscricaoEstadual { get; set; } = null;
        public DateTime? DataFinal { get; set; } = default;
        public DateTime? DataInicial { get; set; } = default;
        public string NotaFiscal_Numero { get; set; } = null;
        public string NotaFiscal_Serie { get; set; } = null;
        public DateTime? NotaFiscal_Data { get; set; } = default;
        public double? ValorDeclarado { get; set; } = default;
        public string Justificativa { get; set; } = null;
        public Registro_22_Motivos Motivo { get; set; } = Registro_22_Motivos.Outros;
    }
}