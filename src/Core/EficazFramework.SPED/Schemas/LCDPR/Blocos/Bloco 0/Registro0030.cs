
namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Dados Cadastrais
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - 1:1
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var reg0030 = new Registro0030(null, _versao)
/// {
///     Endereco = "Rua Teste",
///     Numero = 1234,
///     Complemento = "Bloco Z",
///     Bairro = "Centro",
///     UF = "MG",
///     CodigoMunicipio = "3129707",
///     CEP = "37990000",
///     Telefone = "3535441234",
///     EMail = "teste@eficazcs.com.br"
/// };
/// ```
/// </example>
public class Registro0030 : Primitives.Registro
{
    /// <exclude />
    public Registro0030() : base("0030")
    {
    }

    /// <exclude />
    public Registro0030(string linha, string versao) : base(linha, versao)
    {
    }

    /// <summary>
    /// Endereço da Pessoa Física
    /// </summary>
    public string Endereco { get; set; } = null;

    /// <summary>
    /// Número
    /// </summary>
    public string Numero { get; set; } = null;
    
    /// <summary>
    /// Complemento
    /// </summary>
    public string Complemento { get; set; } = null;

    /// <summary>
    /// Bairro / Distrito
    /// </summary>
    public string Bairro { get; set; } = null;

    /// <summary>
    /// Unidade Federativa (http://sped.rfb.gov.br/pasta/show/1932)
    /// </summary>
    public string UF { get; set; } = null;

    /// <summary>
    /// Código do Município (http://sped.rfb.gov.br/pasta/show/1932)
    /// </summary>
    public string CodigoMunicipio { get; set; } = null;

    /// <summary>
    /// Código de Endereçamento Postal
    /// </summary>
    public string CEP { get; set; } = null;

    /// <summary>
    /// DDD + Número de Telefone
    /// </summary>
    public string Telefone { get; set; } = null;

    /// <summary>
    /// Correio eletrônico
    /// </summary>
    public string EMail { get; set; } = null;

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0030|"); // 1
        writer.Append(Endereco + "|"); // 2
        writer.Append(Numero + "|"); // 3
        writer.Append(Complemento + "|"); // 4
        writer.Append(Bairro + "|"); // 5
        writer.Append(UF + "|"); // 6
        writer.Append(CodigoMunicipio + "|"); // 7
        writer.Append(CEP + "|"); // 8
        writer.Append(Telefone + "|"); // 9
        writer.Append(EMail); // 10
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        Endereco = data[1];
        Numero = data[2];
        Complemento = data[3];
        Bairro = data[4];
        UF = data[5];
        CodigoMunicipio = data[6];
        CEP = data[7];
        Telefone = data[8];
        EMail = data[9];
    }
}
