using System;
using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Consolidação de Notas Fiscais Eletrônicas Emitidas Pela Pessoa Jurídica - Códigos 55 e 65 - Operações de Vendas
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC180 : Primitives.Registro
    {
        public RegistroC180() : base("C180")
        {
        }

        public RegistroC180(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoModeloDocumento { get; set; } = null;
        public DateTime? DataEmissaoInicialDocs { get; set; }
        public DateTime? DataEmissaoFinalDocs { get; set; }
        public string CodigoItem { get; set; } = null;
        public string CodigoNCM { get; set; } = null;
        public string CodigoEXTipi { get; set; } = null;
        public double? VrTotalItem { get; set; }
        public List<RegistroC181> RegistrosC181 { get; set; } = new List<RegistroC181>();
        public List<RegistroC185> RegistrosC185 { get; set; } = new List<RegistroC185>();
        public List<RegistroC188> RegistrosC188 { get; set; } = new List<RegistroC188>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C180|");
            writer.Append(CodigoModeloDocumento + "|");
            writer.Append(DataEmissaoInicialDocs + "|");
            writer.Append(DataEmissaoFinalDocs + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(CodigoNCM + "|");
            writer.Append(CodigoEXTipi + "|");
            writer.Append(VrTotalItem + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoModeloDocumento = data[2];
            DataEmissaoInicialDocs = data[3].ToDate();
            DataEmissaoFinalDocs = data[4].ToDate();
            CodigoItem = data[5];
            CodigoNCM = data[6];
            CodigoEXTipi = data[7];
            VrTotalItem = data[8].ToNullableDouble();
        }
    }
}