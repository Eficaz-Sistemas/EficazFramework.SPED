using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Abertura do Arquivo Digital e Identificação da Pessoa Física
/// </summary>
/// <remarks>
/// Nível hierárquico - 1 <br/>
/// Ocorrência - 1:1
/// </remarks>
/// /// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var reg0000 = new Registro0000(null, _versao)
/// {
///     SituacaoEspecial = SituacaoEspecial.Normal,
///     DataInicial = new System.DateTime(2021, 1, 1),
///     DataFinal = new System.DateTime(2021, 12, 31),
///     Nome = "Produtor Rural Exemplo",
///     CPF = "12345678900"
/// };
/// ```
/// </example>
public class Registro0000 : Primitives.Registro
{
    /// <exclude />
    public Registro0000() : base("0000")
    {
    }

    /// <exclude />
    public Registro0000(string linha, string versao) : base(linha, versao)
    {
    }

    /// <summary>
    /// CPF do declarante
    /// </summary>
    public string CPF { get; set; } = null;
    
    /// <summary>
    /// Nome da Pessoa Física
    /// </summary>
    public string Nome { get; set; } = null;
    
    /// <summary>
    /// Indicador do Início do Período: <br/>
    /// 0 – Regular(Início no primeiro dia do ano). <br/>
    /// 1 – Abertura(Início de atividades no ano-calendário). <br/>
    /// 2 – Início de obrigatoriedade da escrituração no curso do ano calendário.
    /// (Exemplo: desenquadramento como isento do IRPF)
    /// </summary>
    public SituacaoInicioPeriodo IndicadorSitInicioPeriodo { get; set; } = SituacaoInicioPeriodo.Regular;

    /// <summary>
    /// Indicador de Situação Especial e Outros Eventos:  <br/>
    /// 0 – Normal;  <br/>
    /// 1 – Falecimento; <br/>
    /// 2 - Espólio; <br/>
    /// 3 - Saída definitiva do País;
    /// </summary>
    public SituacaoEspecial SituacaoEspecial { get; set; } = SituacaoEspecial.Normal;

    /// <summary>
    /// Data da Situação Especial
    /// </summary>
    public DateTime? DataSituacaoEspecial { get; set; }

    /// <summary>
    /// Data do Início do Período <br/>
    /// Em caso de falecimento da Pessoa Física, a data de falecimento.
    /// </summary>
    public DateTime? DataInicial { get; set; }

    /// <summary>
    /// Data do Final do Período
    /// </summary>
    public DateTime? DataFinal { get; set; }

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0000|LCDPR|"); // 1 e 2
        writer.Append(Versao + "|"); // 3
        writer.Append(CPF + "|"); // 4
        writer.Append(Nome + "|"); // 5
        writer.Append((int)IndicadorSitInicioPeriodo + "|"); // 6
        writer.Append((int)SituacaoEspecial + "|"); // 7
        writer.Append(DataSituacaoEspecial.ToSpedString() + "|"); // 8
        writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.DDMMAAAA) + "|"); // 9
        writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.DDMMAAAA)); // 10
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        CPF = data[3];
        Nome = data[4];
        IndicadorSitInicioPeriodo = (SituacaoInicioPeriodo)data[5].ToEnum<SituacaoInicioPeriodo>(SituacaoInicioPeriodo.Regular);
        SituacaoEspecial = (SituacaoEspecial)data[6].ToEnum<SituacaoEspecial>(SituacaoEspecial.Normal);
        DataSituacaoEspecial = data[7].ToDate();
        DataInicial = data[9].ToDate();
        DataFinal = data[9].ToDate();
    }
}
