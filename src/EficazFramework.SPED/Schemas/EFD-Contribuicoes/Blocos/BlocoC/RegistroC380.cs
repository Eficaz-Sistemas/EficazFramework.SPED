using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Nota Fiscal de Venda a Consumidor (Código 02) - Consolidação de Documentos Emitidos
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC380 : Primitives.Registro
    {
        public RegistroC380() : base("C380")
        {
        }

        public RegistroC380(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoModeloDocumento { get; set; } = null;
        public DateTime? DataEmissaoInicialDocs { get; set; }
        public DateTime? DataEmissaoFinalDocs { get; set; }
        public string NumeroDocFiscalInicial { get; set; } = null;
        public string NumeroDocFiscalFinal { get; set; } = null;
        public double? VrTotalDocsEmitidos { get; set; }
        public double? VrTotalDocsCancelados { get; set; }
        public List<RegistroC381> RegistrosC381 { get; set; } = new List<RegistroC381>();
        public List<RegistroC385> RegistrosC385 { get; set; } = new List<RegistroC385>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C380|");
            writer.Append(CodigoModeloDocumento + "|");
            writer.Append(DataEmissaoInicialDocs + "|");
            writer.Append(DataEmissaoFinalDocs + "|");
            writer.Append(NumeroDocFiscalInicial + "|");
            writer.Append(NumeroDocFiscalFinal + "|");
            writer.Append(VrTotalDocsEmitidos + "|");
            writer.Append(VrTotalDocsCancelados + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoModeloDocumento = data[2];
            DataEmissaoInicialDocs = data[3].ToDate();
            DataEmissaoFinalDocs = data[4].ToDate();
            NumeroDocFiscalInicial = data[5];
            NumeroDocFiscalFinal = data[6];
            VrTotalDocsEmitidos = data[7].ToNullableDouble();
            VrTotalDocsCancelados = data[8].ToNullableDouble();
        }
    }
}