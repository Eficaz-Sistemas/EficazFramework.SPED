using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra
{

    /// <summary>
    /// 60 Mestre: Identificador do Equipamento
    /// </summary>
    /// <remarks></remarks>
    public class Registro60M : Primitives.Registro
    {
        public Registro60M(string linha, string versao) : base(linha, versao)
        {
        }

        public Registro60M() : base("60M")
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("60M"); // 1 & 2
            writer.Append(DataEmissao.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3
            writer.Append(NumeroSerieFabEquip.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
            writer.Append(NumeroSequencialEquip.ValueToString().ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 5
            writer.Append(ModeloDocFiscal.ToFixedLenghtString(2, Escrituracao._builder, Alignment.Right, " ")); // 6
            writer.Append(COO_Inicial.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 7
            writer.Append(COO_Final.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 8
            writer.Append(CRZ.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 9
            writer.Append(CRO.ValueToString().ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 10
            writer.Append(VendaBrutaAcumulada.ValueToString(2).ToFixedLenghtString(16, Escrituracao._builder, Alignment.Left, "0")); // 11
            writer.Append(TotalGeralAcumulado.ValueToString(2).ToFixedLenghtString(16, Escrituracao._builder, Alignment.Left, "0")); // 12
            writer.Append(Brancos.ToFixedLenghtString(37, Escrituracao._builder, Alignment.Right, " ")); // 13
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            string linha = data[0];
            DataEmissao = linha.Substring(3, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
            NumeroSerieFabEquip = linha.Substring(11, 20).Trim();
            NumeroSequencialEquip = linha.Substring(31, 3).Trim().ToNullableInteger();
            ModeloDocFiscal = linha.Substring(34, 2).Trim();
            COO_Inicial = linha.Substring(36, 6).Trim().ToNullableInteger();
            COO_Final = linha.Substring(42, 6).Trim().ToNullableInteger();
            CRZ = linha.Substring(48, 6).Trim().ToNullableInteger();
            CRO = linha.Substring(54, 6).Trim().ToNullableInteger();
            VendaBrutaAcumulada = linha.Substring(57, 16).Trim().ToNullableDouble(2);
            TotalGeralAcumulado = linha.Substring(73, 16).Trim().ToNullableDouble(2);
            Brancos = linha.Substring(89, 37).Trim();
        }

        public DateTime? DataEmissao { get; set; }
        public string NumeroSerieFabEquip { get; set; }
        public int? NumeroSequencialEquip { get; set; }
        public string ModeloDocFiscal { get; set; }
        public int? COO_Inicial { get; set; }
        public int? COO_Final { get; set; }
        public int? CRZ { get; set; }
        public int? CRO { get; set; }
        public double? VendaBrutaAcumulada { get; set; }
        public double? TotalGeralAcumulado { get; set; }
        public string Brancos { get; set; }
        // // Navigation Properties
        public List<Registro60A> Registros60A { get; set; } = new List<Registro60A>();
        public List<Registro60D> Registros60D { get; set; } = new List<Registro60D>();
        public List<Registro60I> Registros60I { get; set; } = new List<Registro60I>();
    }
}