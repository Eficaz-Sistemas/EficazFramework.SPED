using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento do Documento - Operações de Importação
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC120 : Primitives.Registro
    {
        public RegistroC120() : base("C120")
        {
        }

        public RegistroC120(string linha, string versao) : base(linha, versao)
        {
        }

        // campos'
        public EFD_ICMS_IPI.DocumentoImportacao DocumentoDeImportacao { get; set; } = EFD_ICMS_IPI.DocumentoImportacao.Declaracao_Importacao;
        public string NumeroDocImportacao { get; set; } = null;
        public double? VrPagoPisImportacao { get; set; }
        public double? VrPagoCofinsImportacao { get; set; }
        public string NumeroAtoConcessorioRegimeDrawBack { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C120|");
            writer.Append(((int)DocumentoDeImportacao).ToString() + "|");
            writer.Append(NumeroDocImportacao + "|");
            writer.Append(string.Format("{0:0.##}", VrPagoPisImportacao) + "|");
            writer.Append(string.Format("{0:0.##}", VrPagoCofinsImportacao) + "|");
            writer.Append(NumeroAtoConcessorioRegimeDrawBack + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DocumentoDeImportacao = (EFD_ICMS_IPI.DocumentoImportacao)data[2].ToEnum<EFD_ICMS_IPI.DocumentoImportacao>(EFD_ICMS_IPI.DocumentoImportacao.Declaracao_Importacao);
            NumeroDocImportacao = data[3];
            VrPagoPisImportacao = data[4].ToNullableDouble();
            VrPagoCofinsImportacao = data[5].ToNullableDouble();
            NumeroAtoConcessorioRegimeDrawBack = data[6];
        }
    }
}