using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Livros Auxiliares ao Diário ou Livro Principal
/// </summary>
/// <remarks></remarks>

public class RegistroI012 : Primitives.Registro
{
    public RegistroI012() : base("I012")
    {
    }

    public RegistroI012(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public short? NumeroOrdemInstAssociado { get; set; }
    public string NaturezaLivroAssociado { get; set; } = null;
    public TipoEscrituracao TipoEscrituracao { get; set; } = TipoEscrituracao.Digital;
    public string CodigoHASHLivroAuxiliar { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|I012|");
        writer.Append(NumeroOrdemInstAssociado + "|");
        writer.Append(NaturezaLivroAssociado + "|");
        writer.Append(((int)TipoEscrituracao).ToString() + "|");
        writer.Append(CodigoHASHLivroAuxiliar + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        NumeroOrdemInstAssociado = data[2].ToNullableShort();
        NaturezaLivroAssociado = data[3];
        TipoEscrituracao = (TipoEscrituracao)data[4].ToEnum<TipoEscrituracao>(TipoEscrituracao.Digital);
        CodigoHASHLivroAuxiliar = data[5];
    }
}
