using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento dos ajustes do crédito de pis apurado
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM115 : Primitives.Registro
    {
        public RegistroM115() : base("M115")
        {
        }

        public RegistroM115(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? DetVrCredRedAcresc { get; set; }
        public string CSTPis { get; set; } = null;
        public double? DetBcGeradorCredAj { get; set; }
        public double? DetAliqAjCredito { get; set; }
        public DateTime? DataOperacaoAjRegistro { get; set; }
        public string DescricaoOperacoesAjuste { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M115|");
            writer.Append(DetVrCredRedAcresc + "|");
            writer.Append(CSTPis + "|");
            writer.Append(DetBcGeradorCredAj + "|");
            writer.Append(DetAliqAjCredito + "|");
            writer.Append(DataOperacaoAjRegistro + "|");
            writer.Append(DescricaoOperacoesAjuste + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DetVrCredRedAcresc = data[2].ToNullableDouble();
            CSTPis = data[3];
            DetBcGeradorCredAj = data[4].ToNullableDouble();
            DetAliqAjCredito = data[5].ToNullableDouble();
            DataOperacaoAjRegistro = data[6].ToDate();
            DescricaoOperacoesAjuste = Conversions.ToString(data[7].ToNullableDouble());
            CodigoContaContabil = data[8];
            InfoComplementar = data[9];
        }
    }
}