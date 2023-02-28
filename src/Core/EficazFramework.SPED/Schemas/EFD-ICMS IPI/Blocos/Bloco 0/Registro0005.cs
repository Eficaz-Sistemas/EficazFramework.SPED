namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Dados Complementares da entidade
/// </summary>
/// <remarks>
/// Nível hierárquico - 1 <br/>
/// Ocorrência - um por arquivo.
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "017";
/// var reg0005 = new Registro0005(null, _versao)
/// {
///     NomeFantasia = "Nome Fantasia Comércio de Artigos Diversos",
///     CEP = "37990000",
///     Endereco = "Rua Exemplo",
///     Numero = "88",
///     Bairro = "Centro",
///     EMail = "contato@artdiversos.com.br"
/// };
/// ```
/// </example>
public class Registro0005 : Primitives.Registro
{
    public Registro0005() : base("0005")
    {
    }

    public Registro0005(string linha, string versao) : base(linha, versao)
    {
    }

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0005|"); // 1
        writer.Append(NomeFantasia + "|"); // 2
        writer.Append(CEP + "|"); // 3
        writer.Append(Endereco + "|"); // 4
        writer.Append(Numero + "|"); // 5
        writer.Append(Complemento + "|"); // 6
        writer.Append(Bairro + "|"); // 7
        writer.Append(Fone + "|"); // 8
        writer.Append(Fax + "|"); // 9
        writer.Append(EMail + "|"); // 10
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        NomeFantasia = data[2];
        CEP = data[3];
        Endereco = data[4];
        Numero = data[5];
        Complemento = data[6];
        Bairro = data[7];
        Fone = data[8];
        Fax = data[9];
        EMail = data[10];
    }

    /// <summary>
    /// Nome Fantasia assossiado ao nome empresarial
    /// </summary>
    public string NomeFantasia { get; set; } = null;
    /// <summary>
    /// Código de Enderaçamento Postal
    /// </summary>
    public string CEP { get; set; } = null;
    /// <summary>
    /// Logradouro e Endereço do imóvel
    /// </summary>
    public string Endereco { get; set; } = null;
    /// <summary>
    /// Número do Imóvel
    /// </summary>
    public string Numero { get; set; } = null;
    /// <summary>
    /// Dados complementares do endereço
    /// </summary>
    public string Complemento { get; set; } = null;
    /// <summary>
    /// Bairro em que o imóvel está situado
    /// </summary>
    public string Bairro { get; set; } = null;
    /// <summary>
    /// Número do telefone (ddd+fone)
    /// </summary>
    public string Fone { get; set; } = null;
    /// <summary>
    /// Número do fax
    /// </summary>
    public string Fax { get; set; } = null;
    /// <summary>
    /// Endereço de correio eletrônico
    /// </summary>
    public string EMail { get; set; } = null;
}
