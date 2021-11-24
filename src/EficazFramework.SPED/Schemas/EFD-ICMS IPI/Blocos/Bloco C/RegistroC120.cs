using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C120: COMPLEMENTO DE DOCUMENTO - OPERAÇÕES DE
    /// IMPORTAÇÃO (CÓDIGOS 01 e 55).
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

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C120|"); // 1
            writer.Append(((int)Documento_Importacao).ToString() + "|"); // 2
            writer.Append(Numero_Doc_Imp + "|"); // 3
            writer.Append(string.Format("{0:0.##}", ValorPIS) + "|"); // 4
            writer.Append(string.Format("{0:0.##}", ValorCOFINS) + "|"); // 5
            writer.Append(Numero_Acdraw + "|"); // 6
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Documento_Importacao = (DocumentoImportacao)data[2].ToEnum<DocumentoImportacao>(DocumentoImportacao.Declaracao_Importacao);
            Numero_Doc_Imp = data[3];
            ValorPIS = data[4].ToNullableDouble();
            ValorCOFINS = data[5].ToNullableDouble();
            Numero_Acdraw = data[6];
        }

        public DocumentoImportacao Documento_Importacao { get; set; } = DocumentoImportacao.Declaracao_Importacao; // 2
        public string Numero_Doc_Imp { get; set; } // 3 ---- tamanho 12
        public double? ValorPIS { get; set; } // 4
        public double? ValorCOFINS { get; set; } // 5
        public string Numero_Acdraw { get; set; } // 6 --- tamanho 20
    }
}