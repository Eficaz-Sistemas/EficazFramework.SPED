using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Cadastro de Terceiros
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - 1:N
/// </remarks>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var reg0045 = new Registro0045(null, _versao)
/// {
///     Imovel = 1,
///     TipoContratante = TipoExploracaoTerceiro.Condomino,
///     CPF = "12345678912",
///     Nome = "Condomino da Silva",
///     Percentual = 5.2 // 5,2%,
/// };
/// ```
/// </example>
public class Registro0045 : Primitives.Registro
{
    /// <exclude />
    public Registro0045() : base("0045")
    {
    }

    /// <exclude />
    public Registro0045(string linha, string versao) : base(linha, versao)
    {
    }
    
    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0045|"); // 1
        writer.Append(Imovel + "|"); // 2
        writer.Append((int)TipoContratante + "|"); // 3
        writer.Append(CPF + "|"); // 4
        writer.Append(Nome + "|"); // 5
        writer.Append(Percentual.ValueToString(2)); // 6
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        Imovel = data[1].ToNullableInteger();
        TipoContratante = (TipoExploracaoTerceiro)data[2].ToEnum<TipoExploracaoTerceiro>(TipoExploracaoTerceiro.Condomino);
        CPF = data[3];
        Nome = data[4];
        Percentual = data[5].ToNullableDouble();
    }

    /// <summary>
    /// Código do Imóvel (<see cref="Registro0040.IDImovel"/>)
    /// </summary>
    public int? Imovel { get; set; } = default;

    /// <summary>
    /// Tipo de terceiro relacionado ao imóvel: <br/>
    ///1 - Condômino <br/>
    ///2 - Arrendador <br/>
    ///3 - Parceiro <br/>
    ///4 - Comodante <br/>
    ///5 - Outro <br/>
    /// </summary>
    public TipoExploracaoTerceiro TipoContratante { get; set; } = TipoExploracaoTerceiro.Condomino;

    /// <summary>
    /// CNPJ ou CPF do Terceiro que explora em conjunto ou do arrendador / comodante do Imóvel Rural
    /// </summary>
    public string CPF { get; set; } = null;

    /// <summary>
    /// Nome do Terceiro que explora em conjunto ou do arrendador / comodante do Imóvel Rural
    /// </summary>
    public string Nome { get; set; } = null;

    /// <summary>
    /// Percentual do Terceiro que explora em conjunto ou do arrendador / comodante do Imóvel Rural
    /// </summary>
    public double? Percentual { get; set; } = default;
}
