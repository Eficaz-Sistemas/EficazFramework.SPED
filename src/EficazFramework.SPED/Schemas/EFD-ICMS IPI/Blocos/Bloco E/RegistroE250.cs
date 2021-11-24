using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Obrigações do ICMS ST Recolhido ou a Recolher
    /// </summary>
    public class RegistroE250 : Primitives.Registro
    {
        public RegistroE250() : base("E250")
        {
        }

        public RegistroE250(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|E250|"); // 01
            writer.Append(CodigoObrigacao + "|"); // 02
            writer.Append(string.Format("{0:0.##}", ValorObrigacao) + "|"); // 03
            writer.Append(DataVencimento.ToSpedString() + "|"); // 04
            writer.Append(CodigoReceita + "|"); // 05
            writer.Append(NumeroProcessoOuAuto + "|"); // 06
            if (OrigemProcesso.HasValue == true)
                writer.Append((int)OrigemProcesso + "|");
            else
                writer.Append("|"); // 07
            writer.Append(DescricaoProcesso + "|"); // 08
            writer.Append(TextoComplementar + "|"); // 09
            writer.Append(DataVencimento.ToSintegraString(Extensions.DateFormat.MMAAAA) + "|"); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoObrigacao = data[2];
            ValorObrigacao = data[3].ToNullableDouble();
            DataVencimento = data[4].ToDate();
            CodigoReceita = data[5];
            NumeroProcessoOuAuto = data[6];
            if (!string.IsNullOrEmpty(data[7]))
                OrigemProcesso = (IndicadorOrigemProcesso?)data[7].ToEnum<IndicadorOrigemProcesso>(IndicadorOrigemProcesso.Outros);
            DescricaoProcesso = data[8];
            TextoComplementar = data[9];
            DataVencimento = data[10].ToDate(Extensions.DateFormat.MMAAAA);
        }

        public string CodigoObrigacao { get; set; } = null; // 02
        public double? ValorObrigacao { get; set; } // 03
        public DateTime? DataVencimento { get; set; } // 04
        public string CodigoReceita { get; set; } = null; // 05
        public string NumeroProcessoOuAuto { get; set; } = null; // 06
        public IndicadorOrigemProcesso? OrigemProcesso { get; set; } // 07
        public string DescricaoProcesso { get; set; } = null; // 08
        public string TextoComplementar { get; set; } = null; // 09
        public DateTime? MesReferencia { get; set; } // 10
    }
}