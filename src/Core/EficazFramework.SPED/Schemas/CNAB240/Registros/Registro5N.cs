using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240;

/// <summary>
/// Registro Trailer de Lote de Serviço: Pagamentos de Tributos sem Código de Barras e FGTS/GRRF
/// </summary>
public class Registro5N : Primitives.Registro
{
    public Registro5N() : base("5")
    {
    }

    public Registro5N(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
        writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
        writer.Append('5'); // 3
        writer.Append("         "); // 4
        writer.Append(QuantidadeRegistros.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 5
        writer.Append(TotalValorPrincipal.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(TotalOutrasEntidades.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 7
        writer.Append(TotalAcrescimos.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 8
        writer.Append(TotalValorArrecadado.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 9
        writer.Append("".ToFixedLenghtString(151, Escrituracao._builder, Alignment.Right, " ")); // 8
        writer.Append(Ocorrencias.ToFixedLenghtString(10, Escrituracao._builder, Alignment.Right, " ")); // 11
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        CodigoBanco = linha[..3].Trim();
        LoteDeServico = linha.Substring(3, 4).Trim();
        QuantidadeRegistros = linha.Substring(17, 6).Trim().ToNullableInteger();
        TotalValorPrincipal = linha.Substring(23, 14).Trim().ToNullableDouble(2);
        TotalOutrasEntidades = linha.Substring(37, 14).Trim().ToNullableDouble(2);
        TotalAcrescimos = linha.Substring(51, 14).Trim().ToNullableDouble(2);
        TotalValorArrecadado = linha.Substring(65, 14).Trim().ToNullableDouble(2);
        Ocorrencias = linha.Substring(230, 105).Trim();
    }

    public string CodigoBanco { get; set; }
    public string LoteDeServico { get; set; }
    public int? QuantidadeRegistros { get; set; }
    public double? TotalValorPrincipal { get; set; }
    public double? TotalOutrasEntidades { get; set; }
    public double? TotalAcrescimos { get; set; }
    public double? TotalValorArrecadado { get; set; }
    public string Ocorrencias { get; set; }
}
