using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Schemas.Primitives;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Classificação do Estabelecimento Industrial ou Equiparado a Industrial
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - um por arquivo.
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "017";
/// var reg0002 = new Registro0002(null, _versao)
/// {
///     ClassificacaoEstabelecimento = Primitives.TipoAtividade.Industrial
/// };
/// ```
/// </example>
public class Registro0002 : Registro
{
    public Registro0002() : base("0002")
    {
    }

    public Registro0002(string linha, string versao) : base(linha, versao)
    {
    }

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0002|"); // 1
        writer.Append($"{(int)ClassificacaoEstabelecimento:#00}" + "|"); // 2
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        ClassificacaoEstabelecimento = (TipoAtividade)data[2].ToEnum<TipoDeAtividade>(TipoAtividade.Industrial);
    }

    /// <summary>
    /// Classificação do Estabelecimento conforme Tabela 4.5.5: <br/>
    /// 0 - Industrial ou Equiparado a Industrial <br/>
    /// 1 - Outross <br/>
    /// </summary>
    public TipoAtividade ClassificacaoEstabelecimento { get; set; } = TipoAtividade.Industrial; // 2
}
