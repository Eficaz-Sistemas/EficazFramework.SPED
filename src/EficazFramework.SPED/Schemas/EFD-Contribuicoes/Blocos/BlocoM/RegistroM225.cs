using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento dos ajustes da contribuição para o pis apurada
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM225 : Primitives.Registro
    {
        public RegistroM225() : base("M225")
        {
        }

        public RegistroM225(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? DetVrContRedAcrescM220 { get; set; }
        public string CSTPis { get; set; } = null;
        public double? DetBcGeradoraAjCont { get; set; }
        public double? DetAliqAjusteCont { get; set; }
        public DateTime? DataOperacaoAjuste { get; set; }
        public string DescAjuste { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M225|");
            writer.Append(DetVrContRedAcrescM220 + "|");
            writer.Append(CSTPis + "|");
            writer.Append(DetBcGeradoraAjCont + "|");
            writer.Append(DataOperacaoAjuste + "|");
            writer.Append(DescAjuste + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DetVrContRedAcrescM220 = data[2].ToNullableDouble();
            CSTPis = data[3];
            DetBcGeradoraAjCont = data[4].ToNullableDouble();
            DetAliqAjusteCont = data[5].ToNullableDouble();
            DataOperacaoAjuste = data[6].ToDate();
            DescAjuste = data[7];
            CodigoContaContabil = data[8];
            InfoComplementar = data[9];
        }
    }
}