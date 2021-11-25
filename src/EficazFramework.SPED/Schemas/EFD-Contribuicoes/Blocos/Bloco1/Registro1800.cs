using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Icorporação Imobiliária - RET
    /// </summary>
    /// <remarks></remarks>

    public class Registro1800 : Primitives.Registro
    {
        public Registro1800() : base("1800")
        {
        }

        public Registro1800(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string EmpreendObjIncorpImobRET { get; set; } = null;
        public double? RecRecebIncorpVendaUnidImobIncorp { get; set; }
        public double? RecFinancVarMonetDecorrenteVendaSubRet { get; set; }
        public double? BCRecolhUnificado { get; set; }
        public double? AliqRecolhUnificado { get; set; }
        public double? VrRecolhUnificado { get; set; }
        public DateTime? DataRecolhUnificado { get; set; }
        public string CodigoReceita { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1800|");
            writer.Append(EmpreendObjIncorpImobRET + "|");
            writer.Append(RecRecebIncorpVendaUnidImobIncorp + "|");
            writer.Append(RecFinancVarMonetDecorrenteVendaSubRet + "|");
            writer.Append(BCRecolhUnificado + "|");
            writer.Append(AliqRecolhUnificado + "|");
            writer.Append(VrRecolhUnificado + "|");
            writer.Append(DataRecolhUnificado + "|");
            writer.Append(CodigoReceita + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            EmpreendObjIncorpImobRET = data[2];
            RecRecebIncorpVendaUnidImobIncorp = data[3].ToNullableDouble();
            RecFinancVarMonetDecorrenteVendaSubRet = data[4].ToNullableDouble();
            BCRecolhUnificado = data[5].ToNullableDouble();
            AliqRecolhUnificado = data[6].ToNullableDouble();
            VrRecolhUnificado = data[7].ToNullableDouble();
            DataRecolhUnificado = data[8].ToDate();
            CodigoReceita = Conversions.ToString(data[9].ToNullableDouble());
        }
    }
}