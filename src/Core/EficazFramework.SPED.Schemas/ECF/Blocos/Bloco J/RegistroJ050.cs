using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF;

/// <summary>
/// Plano de Contas
/// </summary>
/// <remarks></remarks>

public class RegistroJ050 : Primitives.Registro
{
    public RegistroJ050() : base("J050")
    {
    }

    public RegistroJ050(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public DateTime? DataInclusaoAlteracao { get; set; }
    public string CodNaturezaContaGrupo { get; set; } = null;
    public ECD.IndicadorConta IndicadorTipoConta { get; set; } = ECD.IndicadorConta.Analitica;
    public short? NivelContaAnaliticaGrupo { get; set; }
    public string CodContaAnaliticaGrupo { get; set; } = null;
    public string CodContaSuperior { get; set; } = null;
    public string NomeContaAnaliticaGrupo { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|J050|");
        writer.Append(DataInclusaoAlteracao.ToSpedString() + "|");
        writer.Append(CodNaturezaContaGrupo + "|");
        if (IndicadorTipoConta == ECD.IndicadorConta.Analitica)
            writer.Append("A|");
        else
            writer.Append("S|");
        writer.Append(NivelContaAnaliticaGrupo + "|");
        writer.Append(CodContaAnaliticaGrupo + "|");
        writer.Append(CodContaSuperior + "|");
        writer.Append(NomeContaAnaliticaGrupo + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataInclusaoAlteracao = data[2].ToDate();
        CodNaturezaContaGrupo = data[3];
        if (data[4] == "A")
            IndicadorTipoConta = ECD.IndicadorConta.Analitica;
        else
            IndicadorTipoConta = ECD.IndicadorConta.Sintetica; // Me.IndicadorTipoConta = data(4).ToEnum(Of IndicadorConta)(IndicadorConta.Analitica)
        NivelContaAnaliticaGrupo = data[5].ToNullableShort();
        CodContaAnaliticaGrupo = data[6];
        CodContaSuperior = data[7];
        NomeContaAnaliticaGrupo = data[8];
    }
}
