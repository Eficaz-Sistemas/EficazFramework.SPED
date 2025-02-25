
namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207;

/// <summary>
/// Enquadramento Legal da Operação / Prestação Geradora de Crédito Acumulado do ICMS
/// </summary>
/// <remarks></remarks>
public class Registro0300 : Primitives.Registro
{
    public int ID { get; set; }
    /// <summary>
    /// Código Relativo à Hipotese de Geração, conforme Artigo 71 do RICMS/00. De 1 a 13
    /// </summary>
    public int Descricao { get; set; }
    public string Anexo { get; set; }
    public string Artigo { get; set; }
    public string Inciso { get; set; }
    public string Alinea { get; set; }
    public string Paragrafo { get; set; }
    public string Item { get; set; }
    public string Letra { get; set; }
    public string Observacao { get; set; }

    public Registro0300() : base("0300")
    {
    }

    public Registro0300(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0300|"); // texto fixo
        writer.Append(string.Format("{0:0000}", ID) + "|");
        writer.Append(string.Format("{0:00}", Descricao) + "|");
        writer.Append(Anexo + "|");
        writer.Append(Artigo + "|");
        writer.Append(Inciso + "|");
        writer.Append(Alinea + "|");
        writer.Append(Paragrafo + "|");
        writer.Append(Item + "|");
        writer.Append(Letra + "|");
        writer.Append(Observacao);
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
