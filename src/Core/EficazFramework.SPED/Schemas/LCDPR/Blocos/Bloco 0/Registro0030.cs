using EficazFramework.SPED.Schemas.Primitives;
using System.Runtime.CompilerServices;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// LCPDR - Livro Caixa Digital do Produtor Rural
/// Dados Cadastrais do Contribuinte: É utilizado para mostrar os dados cadastrais da pessoa física quanto ao esclarecimento à Receita Federal sobre as movimentações do produtor rural.
/// </summary>
/// <remarks>
/// Nível Hierárquico => 2 (Indexador)<br/>
/// Ocorrência => 1:1 (1 documento para uma ocorrência)
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// var reg0030 = new Registro0030(null, "0013")
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
public class Registro0030 : Registro
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
    /// LCDPR | Dados Cadastrais | Registro0030 | Endereço da Pessoa Física
    /// </summary>
    public string Endereco { get; set; } = null;

    /// <summary>
    /// LCDPR | Dados Cadastrais | Registro0030 | Número do Endereço
    /// </summary>
    public string Numero { get; set; } = null;

    /// <summary>
    /// LCDPR | Dados Cadastrais | Registro0030 | Complemento
    /// </summary>
    public string Complemento { get; set; } = null;

    /// <summary>
    /// LCDPR | Dados Cadastrais | Registro0030 | Bairro / Distrito
    /// </summary>
    public string Bairro { get; set; } = null;

    /// <summary>
    /// LCDPR | Dados Cadastrais | Registro0030 | Unidade Federativa (http://sped.rfb.gov.br/pasta/show/1932)
    /// </summary>
    public string UF { get; set; } = null;

    /// <summary>
    /// LCDPR | Dados Cadastrais | Registro0030 | Código do Município (http://sped.rfb.gov.br/pasta/show/1932)
    /// </summary>
    public string CodigoMunicipio { get; set; } = null;

    /// <summary>
    /// LCDPR | Dados Cadastrais | Registro0030 | Código de Endereçamento Postal(CEP)
    /// </summary>
    public string CEP { get; set; } = null;

    /// <summary>
    /// LCDPR | Dados Cadastrais | Registro0030 | DDD + Número de Telefone
    /// </summary>
    public string Telefone { get; set; } = null;

    /// <summary>
    /// LCDPR | Dados Cadastrais | Registro0030 | Correio eletrônico
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
