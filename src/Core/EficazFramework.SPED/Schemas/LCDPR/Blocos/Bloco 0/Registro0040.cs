using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Cadastro dos Imóveis Rurais
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - 1:N
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var reg0040 = new Registro0040(null, _versao)
/// {
///     IDImovel = 1,
///     Pais = "BR",
///     Moeda = "BRL",
///     NIRF = "12345678",
///     CAEPF = "12345678901234",
///     InscricaoEstadual = "12345678901234",
///     NomeImovel = "Fazenda Eficaz",
///     Endereco = "Rodovia BR 999, Km 3000",
///     Bairro = "Zona Rural",
///     UF = "MG",
///     CodigoMunicipio = "3129707",
///     CEP = "37990000",
///     TipoExploracao = TipoExploracao.Individual,
///     Percentual = 100000
/// };
/// ```
/// </example>
public class Registro0040 : Primitives.Registro
{
    /// <exclude />
    public Registro0040() : base("0040")
    {
    }

    /// <exclude />
    public Registro0040(string linha, string versao) : base(linha, versao)
    {
    }

    /// <summary>
    /// Identificador único (código) do Imóvel no LCDPR
    /// </summary>
    public int? IDImovel { get; set; } = default;

    /// <summary>
    /// País (Brasil - BR)
    /// </summary>
    public string Pais { get; set; } = "BR";

    /// <summary>
    /// Moeda (Padrão: Real Brasileiro 0 BRL)
    /// </summary>
    public string Moeda { get; set; } = "BRL";
    
    /// <summary>
    /// CAFIR (Informar DV)
    /// </summary>
    public string NIRF { get; set; } = null;

    /// <summary>
    /// Cadastro de Atividade Econômica da Pessoa Física (IN RFB nº 1.828/2018)
    /// </summary>
    public string CAEPF { get; set; } = null;

    /// <summary>
    /// Inscrição Estadual
    /// </summary>
    public string InscricaoEstadual { get; set; } = null;

    /// <summary>
    /// Nome do Imóvel
    /// </summary>
    public string NomeImovel { get; set; } = null;

    /// <summary>
    /// Endereço do Imóvel
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
    /// Bairro
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
    /// Tipo de Exploração do Imóvel: <br/>
    /// 1 – Exploração individual(Imóvel próprio) <br/>
    /// 2 - Condomínio <br/>
    /// 3 - Imóvel arrendado <br/>
    /// 4 - Parceria <br/>
    /// 5 - Comodato <br/>
    /// 6- Outros 
    /// </summary>
    public TipoExploracao TipoExploracao { get; set; } = TipoExploracao.Individual;

    /// <summary>
    /// Participação em percentual na exploração do Imóvel
    /// </summary>
    public double? Percentual { get; set; } = default;

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0040|"); // 1
        writer.Append(IDImovel + "|"); // 2
        writer.Append(Pais + "|"); // 3
        writer.Append(Moeda + "|"); // 4
        writer.Append(NIRF + "|"); // 5
        writer.Append(CAEPF + "|"); // 6
        writer.Append(InscricaoEstadual + "|"); // 7
        writer.Append(NomeImovel + "|"); // 8
        writer.Append(Endereco + "|"); // 9
        writer.Append(Numero + "|"); // 10
        writer.Append(Complemento + "|"); // 11 
        writer.Append(Bairro + "|"); // 12
        writer.Append(UF + "|"); // 13
        writer.Append(CodigoMunicipio + "|"); // 14
        writer.Append(CEP + "|"); // 15
        writer.Append((int)TipoExploracao + "|"); // 16
        writer.Append(Percentual.ValueToString(2)); // 17
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        IDImovel = data[1].ToNullableInteger();
        Pais = data[2];
        Moeda = data[3];
        NIRF = data[4];
        CAEPF = data[5];
        InscricaoEstadual = data[6];
        NomeImovel = data[7];
        Endereco = data[8];
        Numero = data[9];
        Complemento = data[10];
        Bairro = data[11];
        UF = data[12];
        CodigoMunicipio = data[13];
        CEP = data[14];
        TipoExploracao = (TipoExploracao)data[15].ToEnum<TipoExploracao>(TipoExploracao.Individual);
        Percentual = data[16].ToNullableDouble();
    }
}
