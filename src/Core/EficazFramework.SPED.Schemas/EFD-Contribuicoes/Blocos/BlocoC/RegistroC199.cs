using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Complemento do Documento - Operações de Importação (Código 55)
/// </summary>
/// <remarks></remarks>

public class RegistroC199 : Primitives.Registro
{
    public RegistroC199() : base("C199")
    {
    }

    public RegistroC199(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public EFD_ICMS_IPI.DocumentoImportacao DocumentoImportacao { get; set; } = EFD_ICMS_IPI.DocumentoImportacao.Declaracao_Importacao;
    public string NumeroDocumentoImportacao { get; set; } = null;
    public double? VrPagoPisImportacao { get; set; }
    public double? VrPagoCofinsImportacao { get; set; }
    public string NumeroAtoConcessorioDrawBack { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|C199|");
        writer.Append(((int)DocumentoImportacao).ToString() + "|");
        writer.Append(VrPagoPisImportacao + "|");
        writer.Append(VrPagoCofinsImportacao + "|");
        writer.Append(NumeroAtoConcessorioDrawBack + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DocumentoImportacao = (EFD_ICMS_IPI.DocumentoImportacao)data[2].ToEnum<EFD_ICMS_IPI.DocumentoImportacao>(EFD_ICMS_IPI.DocumentoImportacao.Declaracao_Importacao);
        NumeroDocumentoImportacao = data[3];
        VrPagoPisImportacao = data[4].ToNullableDouble();
        VrPagoCofinsImportacao = data[5].ToNullableDouble();
        NumeroAtoConcessorioDrawBack = data[6];
    }
}
