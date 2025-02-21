
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Dados do Contribuinte Substituto Ou Responsável pelo ICMS Destino
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - vários (por arquivo).
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "017";
/// var reg0015 = new Registro0015(null, _versao)
/// {
///     UF = "MG",
///     InscricaoEstadual = "0010001112233"
/// };
/// ```
/// </example>
public class Registro0015 : Primitives.Registro
{
    public Registro0015() : base("0015")
    {
    }

    public Registro0015(string linha, string versao) : base(linha, versao)
    {
    }

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0015|"); // 1
        writer.Append(UF + "|"); // 2
        writer.Append(InscricaoEstadual + "|"); // 3
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        UF = data[2];
        InscricaoEstadual = data[3];
    }

    /// <summary>
    /// Sigla da unidade federativa do contribuinte substituído ou unidade de federação do consumidor final 
    /// não contribuinte - ICMS Destino EC 87/15
    /// </summary>
    public string UF { get; set; } = null;
    /// <summary>
    /// Inscrição Estadual do contribuinte substituído ou unidade de federação do consumidor final 
    /// não contribuinte - ICMS Destino EC 87/15
    /// </summary>
    public string InscricaoEstadual { get; set; } = null;
}
