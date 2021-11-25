using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Partidas do Lançamento
/// </summary>
/// <remarks></remarks>

public class RegistroI250 : Primitives.Registro
{
    public RegistroI250() : base("I250")
    {
    }

    public RegistroI250(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodContaAnalitica { get; set; } = null;
    public string CodCentroCusto { get; set; } = null;
    public double? VrPartida { get; set; }
    public string IndNaturezaPartida { get; set; } = null;
    public string NumeroCodigoCaminhoLocalizacaoArquivo { get; set; } = null;
    public string CodHistoricoPadronizado { get; set; } = null;
    public string HistoricoCompleto { get; set; } = null;
    public string CodParticipante { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|I250|");
        writer.Append(CodContaAnalitica + "|");
        writer.Append(CodCentroCusto + "|");
        writer.Append(string.Format("{0:F2}", VrPartida) + "|");
        writer.Append(IndNaturezaPartida + "|");
        writer.Append(NumeroCodigoCaminhoLocalizacaoArquivo + "|");
        writer.Append(CodHistoricoPadronizado + "|");
        writer.Append(HistoricoCompleto + "|");
        writer.Append(CodParticipante + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodContaAnalitica = data[2];
        CodCentroCusto = data[3];
        VrPartida = data[4].ToNullableDouble();
        IndNaturezaPartida = data[5];
        NumeroCodigoCaminhoLocalizacaoArquivo = data[6];
        CodHistoricoPadronizado = data[7];
        HistoricoCompleto = data[8];
        CodParticipante = data[9];
    }
}
