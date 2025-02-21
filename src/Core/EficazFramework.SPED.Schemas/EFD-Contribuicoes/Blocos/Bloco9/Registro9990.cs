using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Encerramento do Bloco 9
/// </summary>
public class Registro9990 : Primitives.Registro
{
    public Registro9990() : base("9990")
    {
    }

    public Registro9990(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        {
            var withBlock = writer;
            withBlock.Append("|9990|"); // texto fixo
            withBlock.Append(TotalLinhas + "|");
        }

        string result = writer.ToString();
        return result;
    }

    public override void LeParametros(string[] data)
    {
        TotalLinhas = data[1].ToNullableInteger();
    }

    /// <summary>
    /// Total de Linhas do Bloco
    /// </summary>
    public int? TotalLinhas { get; set; }
}
