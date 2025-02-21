using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Parâmetros de Tributação
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - 1:1
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var reg0010 = new Registro0010(null, _versao)
/// {
///     FormaApuracao = FormaApuracao.LivroCaixa
/// };
/// ```
/// </example>
public class Registro0010 : Primitives.Registro
{
    /// <exclude />
    public Registro0010() : base("0010")
    {
    }
    
    /// <exclude />
    public Registro0010(string linha, string versao) : base(linha, versao)
    {
    }

    /// <summary>
    /// Forma de Apuração:
    /// 1 – Livro Caixa (Resutlado com base nos lançamentos da LCDPR. <br/>
    /// 2 – Apuração do lucro pelo disposto no art. 5º da Lei nº 8.023, de 1990 (20% da Receita Bruta).
    /// </summary>
    public FormaApuracao FormaApuracao { get; set; } = FormaApuracao.LivroCaixa;

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0010|"); // 1
        writer.Append((int)FormaApuracao); // 2
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        FormaApuracao = (FormaApuracao)data[1].ToEnum<FormaApuracao>(FormaApuracao.LivroCaixa);
    }
}
