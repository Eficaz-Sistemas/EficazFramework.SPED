using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C173: OPERAÇÕES COM MEDICAMENTOS (CÓDIGO 01 E 55)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC173 : Primitives.Registro
    {
        public RegistroC173() : base("C173")
        {
        }

        public RegistroC173(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C173|"); // 1
            writer.Append(NumLoteFabricMedic + "|"); // 2
            writer.Append(string.Format("{0:0.###}", QtdeItemLote) + "|"); // 3
            writer.Append(DataFabricMedic + "|"); // 4
            writer.Append(DataExpValidMedic + "|"); // 5
            writer.Append(((int)IndicadorTipoCalculoST).ToString() + "|"); // 6
            writer.Append(((int)TipoProduto).ToString() + "|"); // 7
            writer.Append(string.Format("{0:0.##}", VrPrecoTabPrecoMaximo) + "|"); // 8
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumLoteFabricMedic = data[2].ToString();
            QtdeItemLote = data[3].ToNullableDouble();
            DataFabricMedic = data[4].ToDate();
            DataExpValidMedic = data[5].ToDate();
            IndicadorTipoCalculoST = (IndicadorTipoCalculoST)data[6].ToEnum<IndicadorTipoCalculoST>(IndicadorTipoCalculoST.Base_Calculo_Preco);
            TipoProduto = (TipoProduto)data[6].ToEnum<TipoProduto>(TipoProduto.Similar);
            VrPrecoTabPrecoMaximo = data[8].ToNullableDouble();
        }

        public string NumLoteFabricMedic { get; set; } = null; // 2
        public double? QtdeItemLote { get; set; } = default; // 3
        public DateTime? DataFabricMedic { get; set; } = default; // 4
        public DateTime? DataExpValidMedic { get; set; } = default; // 5
        public IndicadorTipoCalculoST IndicadorTipoCalculoST { get; set; } = IndicadorTipoCalculoST.Base_Calculo_Preco; // 6
        public TipoProduto TipoProduto { get; set; } = TipoProduto.Similar; // 7
        public double? VrPrecoTabPrecoMaximo { get; set; } = default; // 8
    }
}