using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// Ocorrências (Ajustes de Apuração)
    /// </summary>
    public class Registro20 : Primitives.Registro
    {
        public Registro20() : base("20")
        {
        }

        public Registro20(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("20"); // 1 Código Registro
            writer.Append(CodigoOcorrencia.ToFixedLenghtString(5, Escrituracao._builder, Alignment.Left, "0")); // 2
            writer.Append(Valor.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 3
            writer.Append((int)Operacao); // 4
            writer.Append(FundamentacaoLegal.ToFixedLenghtString(100, Escrituracao._builder, Alignment.Right, " ")); // 5
            writer.Append(DescricaoOcorrencia.ToFixedLenghtString(300, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(Registros25.Count.ToString().PadLeft(4, '0'));  // 7
            writer.Append(Registros25.Count.ToString().PadLeft(4, '0')); // 8
            writer.Append(Registros27.Count.ToString().PadLeft(4, '0')); // 9
            writer.Append(Registros28.Count.ToString().PadLeft(4, '0')); // 9
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            CodigoOcorrencia = linha.Substring(2, 5).Trim();
            Valor = linha.Substring(7, 15).ToNullableDouble(2);
            Operacao = (Operacao)linha.Substring(22, 1).Trim().ToEnum<Operacao>(Operacao.Propria);
            FundamentacaoLegal = linha.Substring(23, 100).Trim();
            DescricaoOcorrencia = linha.Substring(123, 300).Trim();
        }

        public string CodigoOcorrencia { get; set; } = null;
        public double? Valor { get; set; } = 0;
        public Operacao Operacao { get; set; } = Operacao.Propria;
        public string FundamentacaoLegal { get; set; } = null;
        public string DescricaoOcorrencia { get; set; } = null;
        public List<Registro25> Registros25 { get; set; } = new List<Registro25>();
        public List<Registro26> Registros26 { get; set; } = new List<Registro26>();
        public List<Registro27> Registros27 { get; set; } = new List<Registro27>();
        public List<Registro28> Registros28 { get; set; } = new List<Registro28>();
    }
}