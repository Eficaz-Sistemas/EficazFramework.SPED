using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento do Crédito Extemporâneo Vinculado a mais de um tipo de receita - pis
    /// </summary>
    /// <remarks></remarks>

    public class Registro1102 : Primitives.Registro
    {
        public Registro1102() : base("1102")
        {
        }

        public Registro1102(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? ParcelaCreditoPisReceitaMercInterno { get; set; }
        public double? ParcelaCreditoPisReceitaNãoTribMercInterno { get; set; }
        public double? ParcelaCreditoVincExportacao { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1102|");
            writer.Append(ParcelaCreditoPisReceitaMercInterno + "|");
            writer.Append(ParcelaCreditoPisReceitaNãoTribMercInterno + "|");
            writer.Append(ParcelaCreditoVincExportacao + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            ParcelaCreditoPisReceitaMercInterno = data[2].ToNullableDouble();
            ParcelaCreditoPisReceitaNãoTribMercInterno = data[3].ToNullableDouble();
            ParcelaCreditoVincExportacao = data[4].ToNullableDouble();
        }
    }
}