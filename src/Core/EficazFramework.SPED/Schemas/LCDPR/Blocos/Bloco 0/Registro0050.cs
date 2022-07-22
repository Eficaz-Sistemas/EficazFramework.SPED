using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Cadastro das Contas Bancárias do Produtor Rural
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - 1:N
/// </remarks>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var reg0040 = new Registro0040(null, _versao)
/// {
///     CodigoContaBanco = 1,
///     Pais = "BR",
///     NumeroInstBancaria = "756",
///     Nome = "Banco LCDPR",
///     Agencia = "0001",
///     NumeroCC = "123456",
/// };
/// ```
/// </example>
public class Registro0050 : Primitives.Registro
{
    /// <exclude />
    public Registro0050() : base("0050")
    {
    }

    /// <exclude />
    public Registro0050(string linha, string versao) : base(linha, versao)
    {
    }

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0050|"); // 1
        writer.Append(CodigoContaBanco + "|"); // 2
        writer.Append(Pais + "|"); // 3
        writer.Append(NumeroInstBancaria + "|"); // 4
        writer.Append(Nome + "|"); // 5
        writer.Append(Agencia + "|"); // 6
        writer.Append(NumeroCC); // 7
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        CodigoContaBanco = data[1].ToNullableInteger();
        Pais = data[2];
        NumeroInstBancaria = data[3];
        Nome = data[4];
        Agencia = data[5];
        NumeroCC = data[6];
    }

    /// <summary>
    /// ID (código) da Conta Bancária
    /// </summary>
    public int? CodigoContaBanco { get; set; } = default;

    /// <summary>
    /// Código do País em que a conta bancária é mantida. (http://sped.rfb.gov.br/pasta/show/1932)
    /// </summary>
    public string Pais { get; set; } = "BR";
    
    /// <summary>
    /// Código a instituição bancária
    /// </summary>
    public string NumeroInstBancaria { get; set; } = null;

    /// <summary>
    /// Nome da Instituição Financeira
    /// </summary>
    public string Nome { get; set; } = null;

    /// <summary>
    /// Número da Agência (sem dígito verificador)
    /// </summary>
    public string Agencia { get; set; } = null;

    /// <summary>
    /// Número da Conta Corrente (com dígito verificador)
    /// </summary>
    public string NumeroCC { get; set; } = null;
}
