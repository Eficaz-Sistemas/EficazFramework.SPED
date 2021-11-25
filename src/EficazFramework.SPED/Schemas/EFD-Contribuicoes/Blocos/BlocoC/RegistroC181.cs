using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Consolidação - Operações de Vendas - PIS/PASEP
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC181 : Primitives.Registro
    {
        public RegistroC181() : base("C181")
        {
        }

        public RegistroC181(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTPIS { get; set; } = null;
        public string CFOP { get; set; } = null;
        public double? VrITem { get; set; }
        public double? VrDescontoExclusao { get; set; }
        public double? VrBaseCalculoPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? BCPisQuantidade { get; set; }
        public double? AliquotaPISReais { get; set; }
        public double? VrPIS { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new global::System.Text.StringBuilder();
            writer.Append("|C181|");
            writer.Append(CSTPIS + "|");
            writer.Append(CFOP + "|");
            writer.Append(VrITem + "|");
            writer.Append(VrDescontoExclusao + "|");
            writer.Append(VrBaseCalculoPis + "|");
            writer.Append(AliquotaPis + "|");
            writer.Append(BCPisQuantidade + "|");
            writer.Append(AliquotaPISReais + "|");
            writer.Append(VrPIS + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTPIS = data[2];
            CFOP = data[3];
            VrITem = data[4].ToNullableDouble();
            VrDescontoExclusao = data[5].ToNullableDouble();
            VrBaseCalculoPis = data[6].ToNullableDouble();
            AliquotaPis = data[7].ToNullableDouble();
            BCPisQuantidade = data[8].ToNullableDouble();
            AliquotaPISReais = data[9].ToNullableDouble();
            VrPIS = data[10].ToNullableDouble();
            CodigoContaContabil = data[11];
        }
    }
}