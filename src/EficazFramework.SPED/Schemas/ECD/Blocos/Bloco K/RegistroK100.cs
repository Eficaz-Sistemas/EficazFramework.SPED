using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Relação das Empresas Consolidadas
    /// </summary>
    /// <remarks></remarks>

    public class RegistroK100 : Primitives.Registro
    {
        public RegistroK100() : base("K100")
        {
        }

        public RegistroK100(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodPais { get; set; } = null;
        public string CodigoIdentifEmpresaPart { get; set; } = null;
        public string CNPJ { get; set; } = null;
        public string NomeEmpresarial { get; set; } = null;
        public double? PercentualPartConglomerado { get; set; }
        public string EventoSocietarioOcorrido { get; set; } = null;
        public double? PercentualConsolidacaoEmpresa { get; set; }
        public DateTime? DataInicialEscrituracaoEmpresaConsolidada { get; set; }
        public DateTime? DataFinalEscrituracaoEmpresaConsolidada { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K100|");
            writer.Append(CodPais + "|");
            writer.Append(CodigoIdentifEmpresaPart + "|");
            writer.Append(CNPJ + "|");
            writer.Append(NomeEmpresarial + "|");
            writer.Append(PercentualPartConglomerado + "|");
            writer.Append(EventoSocietarioOcorrido + "|");
            writer.Append(PercentualPartConglomerado + "|");
            writer.Append(DataInicialEscrituracaoEmpresaConsolidada + "|");
            writer.Append(DataFinalEscrituracaoEmpresaConsolidada + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodPais = data[2];
            CodigoIdentifEmpresaPart = data[3];
            CNPJ = data[4];
            NomeEmpresarial = data[5];
            PercentualPartConglomerado = data[6].ToNullableDouble();
            EventoSocietarioOcorrido = data[7];
            PercentualPartConglomerado = data[8].ToNullableDouble();
            DataInicialEscrituracaoEmpresaConsolidada = data[9].ToDate();
            DataFinalEscrituracaoEmpresaConsolidada = data[10].ToDate();
        }
    }
}