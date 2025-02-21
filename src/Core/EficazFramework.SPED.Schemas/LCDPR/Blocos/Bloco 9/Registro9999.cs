
namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
///  Identificação do Signatário do LCDPR e Encerramento do Arquivo Digital
/// </summary>
/// <remarks>
/// Nível hierárquico - 1 <br/>
/// Ocorrência - 1:1
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var reg9999 = new Registro9999(null, _versao)
/// {
///     Nome = "Contador ABC",
///     CPF = "12345678900",
///     CRC = "123456/O/MG",
///     eMail = "teste@eficazcs.com.br"
///     Fone = "3535441234",
///     ValorSaida = 500d,
///     SaldoFinal = 500d,
///     QuantidadeLinhas = 9999999
/// };
/// ```
/// </example>
public class Registro9999 : Primitives.Registro
{
    /// <exclude />
    public Registro9999() : base("9999")
    {
    }

    /// <exclude />
    public Registro9999(string linha, string versao) : base(linha, versao)
    {
    }

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("9999|"); // 1
        writer.Append(Nome + "|"); // 2
        writer.Append(CPF + "|"); // 3
        writer.Append(CRC + "|"); // 4
        writer.Append(eMail + "|"); // 5
        writer.Append(Fone + "|"); // 6
        writer.Append(QuantidadeLinhas); // 7
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        Nome = data[1];
        CPF = data[2];
        CRC = data[3];
        eMail = data[4];
        Fone = data[5];
        _ = int.TryParse(data[6], out int result);
        QuantidadeLinhas = result;
    }
    
    /// <summary>
    /// Nome do Contador
    /// </summary>
    public string Nome { get; set; } = null;

    /// <summary>
    /// CNPJ / CPF do Contador
    /// </summary>
    public string CPF { get; set; } = null;

    /// <summary>
    /// Número de Inscrição do Contador no Conselho Regional de Contabilidade
    /// </summary>
    public string CRC { get; set; } = null;

    /// <summary>
    /// Correio eletrônico do Contador
    /// </summary>
    public string eMail { get; set; } = null;

    /// <summary>
    /// DDD + Telefone do Contador
    /// </summary>
    public string Fone { get; set; } = null;

    /// <summary>
    /// Quantidade Total de Registros do arquivo
    /// </summary>
    public int QuantidadeLinhas { get; set; } = 0;
}
