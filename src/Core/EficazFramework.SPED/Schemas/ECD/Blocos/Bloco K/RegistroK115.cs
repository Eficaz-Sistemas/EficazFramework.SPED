using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Empresas Participantes do Evento Societário
/// </summary>
/// <remarks></remarks>

public class RegistroK115 : Primitives.Registro
{
    public RegistroK115() : base("K115")
    {
    }

    public RegistroK115(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoEmpresaEnvolvidaOperacao { get; set; } = null;
    public CondicaoEmpresaRelacionada CondicaoEmpresaRelacionada { get; set; } = CondicaoEmpresaRelacionada.Adquirente;
    public double? PercentualEmpPartEnvolvidaOper { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K115|");
        writer.Append(CodigoEmpresaEnvolvidaOperacao + "|");
        writer.Append(((int)CondicaoEmpresaRelacionada).ToString() + "|");
        writer.Append(PercentualEmpPartEnvolvidaOper + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoEmpresaEnvolvidaOperacao = data[2];
        CondicaoEmpresaRelacionada = (CondicaoEmpresaRelacionada)data[3].ToEnum<CondicaoEmpresaRelacionada>(CondicaoEmpresaRelacionada.Adquirente);
        PercentualEmpPartEnvolvidaOper = data[4].ToNullableDouble();
    }
}
