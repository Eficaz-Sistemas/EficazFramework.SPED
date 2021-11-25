using System;

namespace EficazFramework.SPED.Schemas.SP.eCredAc.CAT207;

/// <summary>
/// Dados da Exportação Indireta Comprovada - Ficha 5H
/// </summary>
/// <remarks></remarks>
public class Registro5340 : Primitives.Registro
{
    public DateTime? Exportador_DataEmissao { get; set; } = default;
    public int? Exportador_Numero { get; set; } = default;
    public string Exportador_Serie { get; set; } = null;
    public string DeclaracaoExportacao { get; set; } = null;

    public Registro5340() : base("5340")
    {
    }

    public Registro5340(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("5340|");
        writer.Append(string.Format("{0:ddMMyyyy}", Exportador_DataEmissao) + "|");
        writer.Append(Exportador_Numero + "|");
        writer.Append(Exportador_Serie + "|");
        writer.Append(DeclaracaoExportacao);
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
