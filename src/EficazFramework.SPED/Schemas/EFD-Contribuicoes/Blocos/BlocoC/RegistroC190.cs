using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Consolidação de Notas Fiscais Eletrônicas (Código 55) - Operações
    /// de Aquisição com Direito a Crédito, e Operações de Devolução de
    /// Compras e Vendas
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC190 : Primitives.Registro
    {
        public RegistroC190() : base("C190")
        {
        }

        public RegistroC190(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos 
        public string CodigoModeloDocs { get; set; } = null;
        public DateTime? DataInicialRefConsolidacao { get; set; }
        public DateTime? DataFinalRefConsolidacao { get; set; }
        public string CodigoItem { get; set; } = null;
        public string CodigoNCM { get; set; } = null;
        public string CodigoEXTIPI { get; set; } = null;
        public double? VrTotalItem { get; set; }
        public List<RegistroC191> RegistrosC191 { get; set; } = new List<RegistroC191>();
        public List<RegistroC195> RegistrosC195 { get; set; } = new List<RegistroC195>();
        public List<RegistroC198> RegistrosC198 { get; set; } = new List<RegistroC198>();
        public List<RegistroC199> RegistrosC199 { get; set; } = new List<RegistroC199>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C190|");
            writer.Append(CodigoModeloDocs + "|");
            writer.Append(DataInicialRefConsolidacao + "|");
            writer.Append(DataFinalRefConsolidacao + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(CodigoNCM + "|");
            writer.Append(CodigoEXTIPI + "|");
            writer.Append(VrTotalItem + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoModeloDocs = data[2];
            DataInicialRefConsolidacao = data[3].ToDate();
            DataFinalRefConsolidacao = data[4].ToDate();
            CodigoItem = data[5];
            CodigoNCM = data[6];
            CodigoEXTIPI = data[7];
            VrTotalItem = data[8].ToNullableDouble();
        }
    }
}