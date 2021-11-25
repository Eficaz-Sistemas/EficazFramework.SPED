using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Processo Referenciado
/// </summary>
/// <remarks></remarks>

public class RegistroC111 : Primitives.Registro
{
    public RegistroC111() : base("C111")
    {
    }

    public RegistroC111(string linha, string versao) : base(linha, versao)
    {
    }

    // campos'
    public string NumeroProcessoConcessorio { get; set; } = null;
    public IndicadorOrigemProcesso IndicadorOrigemProcesso { get; set; } = IndicadorOrigemProcesso.Outros;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C111|");
        writer.Append(NumeroProcessoConcessorio + "|");
        writer.Append(((int)IndicadorOrigemProcesso).ToString() + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumeroProcessoConcessorio = data[2];
        IndicadorOrigemProcesso = (IndicadorOrigemProcesso)data[3].ToEnum<IndicadorOrigemProcesso>(IndicadorOrigemProcesso.Outros);
    }
}
