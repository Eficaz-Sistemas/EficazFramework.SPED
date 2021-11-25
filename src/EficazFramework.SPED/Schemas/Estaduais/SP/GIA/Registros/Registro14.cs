using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.SP.GIA
{

    /// <summary>
    /// Detalhes CFOP's
    /// </summary>
    public class Registro14 : Primitives.Registro
    {
        public Registro14() : base("14")
        {
        }

        public Registro14(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("14"); // 1 Código Registro
            writer.Append(UF); // 2
            writer.Append(ValorContabil_Contribuinte.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 3
            writer.Append(BaseCalculo_Contribuinte.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 4
            writer.Append(ValorContabil_NaoContribuinte.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(BaseCalculo_NaoContribuinte.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 6
            writer.Append(Imposto.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(Outras.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 8
            writer.Append(ICMSCobradoST.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(PetroleoEnergia.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(OutrosProdutos.ValueToString(2).ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(Convert.ToInt32(BeneficioFiscal)); // 12
            writer.Append(Registros18.Count.ToString().PadLeft(4, '0')); // 13
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            UF = ((int)Utilities.SP.GIA.Helpers.UF_FromGiaString(linha.Substring(2, 2))).ToString();
            ValorContabil_Contribuinte = linha.Substring(4, 15).ToNullableDouble(2);
            BaseCalculo_Contribuinte = linha.Substring(19, 15).ToNullableDouble(2);
            ValorContabil_Contribuinte = linha.Substring(34, 15).ToNullableDouble(2);
            BaseCalculo_Contribuinte = linha.Substring(49, 15).ToNullableDouble(2);
            Imposto = linha.Substring(64, 15).ToNullableDouble(2);
            Outras = linha.Substring(79, 15).ToNullableDouble(2);
            ICMSCobradoST = linha.Substring(94, 15).ToNullableDouble(2);
            PetroleoEnergia = linha.Substring(109, 15).ToNullableDouble(2);
            OutrosProdutos = linha.Substring(124, 15).ToNullableDouble(2);
            if (!string.IsNullOrWhiteSpace(linha.Substring(139, 1)))
                BeneficioFiscal = Convert.ToBoolean(Conversions.ToInteger(linha.Substring(139, 1)));
        }

        public string UF { get; set; } = "SP";
        public double? ValorContabil_Contribuinte { get; set; } = 0;
        public double? BaseCalculo_Contribuinte { get; set; } = 0;
        public double? ValorContabil_NaoContribuinte { get; set; } = 0;
        public double? BaseCalculo_NaoContribuinte { get; set; } = 0;
        public double? Imposto { get; set; } = 0;
        public double? Outras { get; set; } = 0;
        public double? ICMSCobradoST { get; set; } = 0;
        public double? PetroleoEnergia { get; set; } = 0;
        public double? OutrosProdutos { get; set; } = 0;
        public bool BeneficioFiscal { get; set; } = false;
        public List<Registro18> Registros18 { get; set; } = new List<Registro18>();
    }
}