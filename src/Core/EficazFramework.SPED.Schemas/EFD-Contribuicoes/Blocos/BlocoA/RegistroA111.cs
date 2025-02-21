using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Processo referenciado
/// </summary>
/// <remarks></remarks>

public class RegistroA111 : Primitives.Registro
{
    public RegistroA111() : base("A111")
    {
    }

    public RegistroA111(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string IdentificacaoProcessoConcessorio { get; set; } = null; // tamanho 15'
    public IndicadorOrigemProcesso IndicadorOrigemProcesso { get; set; } = IndicadorOrigemProcesso.JusticaFederal;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|A111|");
        writer.Append(IdentificacaoProcessoConcessorio + "|");
        writer.Append(((int)IndicadorOrigemProcesso).ToString() + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        IdentificacaoProcessoConcessorio = data[2];
        IndicadorOrigemProcesso = (IndicadorOrigemProcesso)data[3].ToEnum<IndicadorOrigemProcesso>(IndicadorOrigemProcesso.JusticaFederal);
    }
}
