using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento dos ajustes da contribuição para o Cofins apurada
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM625 : Primitives.Registro
    {
        public RegistroM625() : base("M625")
        {
        }

        public RegistroM625(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? DetVrContRedAcrescM620 { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? DetBcGeradoraAjCont { get; set; }
        public double? DetAliqAjusteCont { get; set; }
        public DateTime? DataOperacaoAjuste { get; set; }
        public string DescAjuste { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M625|");
            writer.Append(DetVrContRedAcrescM620 + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(DetBcGeradoraAjCont + "|");
            writer.Append(DataOperacaoAjuste + "|");
            writer.Append(DescAjuste + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DetVrContRedAcrescM620 = data[2].ToNullableDouble();
            CSTCofins = data[3];
            DetBcGeradoraAjCont = data[4].ToNullableDouble();
            DetAliqAjusteCont = data[5].ToNullableDouble();
            DataOperacaoAjuste = data[6].ToDate();
            DescAjuste = data[7];
            CodigoContaContabil = data[8];
            InfoComplementar = data[9];
        }
    }
}