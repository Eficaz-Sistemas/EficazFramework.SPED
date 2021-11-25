using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Abertura do Bloco 0
    /// </summary>
    /// <remarks></remarks>

    public class Registro0205 : Primitives.Registro
    {
        public Registro0205() : base("0205")
        {
        }

        public Registro0205(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0205|"); // 1
            writer.Append(DescrAnteriorItem + "|"); // 2
            writer.Append(DataInicialUtilizacaoItem + "|"); // 3
            writer.Append(DataFinalUtilizacaoItem + "|"); // 4
            writer.Append(CodAnteriorItem + "|"); // 5
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DescrAnteriorItem = data[2].ToString();
            DataInicialUtilizacaoItem = data[3].ToDate();
            DataFinalUtilizacaoItem = data[4].ToDate();
            CodAnteriorItem = data[5].ToString();
        }

        public string DescrAnteriorItem { get; set; } = null; // 2
        public DateTime? DataInicialUtilizacaoItem { get; set; } = default; // 3
        public DateTime? DataFinalUtilizacaoItem { get; set; } = default; // 4
        public string CodAnteriorItem { get; set; } = null; // 5
    }
}