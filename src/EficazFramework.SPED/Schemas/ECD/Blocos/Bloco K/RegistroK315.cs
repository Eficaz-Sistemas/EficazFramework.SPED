using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Empresas Contrapartes das Parcelas do Valor Eliminado Total
    /// </summary>
    /// <remarks></remarks>

    public class RegistroK315 : Primitives.Registro
    {
        public RegistroK315() : base("K315")
        {
        }

        public RegistroK315(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoEmpresaContrapartida { get; set; } = null;
        public string CodigoContaConsolidadaContrapartida { get; set; } = null;
        public double? ParcelaContrapartidaVrEliminado { get; set; }
        public string IndicadorSitVrEliminado { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K315|");
            writer.Append(CodigoEmpresaContrapartida + "|");
            writer.Append(CodigoContaConsolidadaContrapartida + "|");
            writer.Append(ParcelaContrapartidaVrEliminado + "|");
            writer.Append(IndicadorSitVrEliminado + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoEmpresaContrapartida = data[2];
            CodigoContaConsolidadaContrapartida = data[3];
            ParcelaContrapartidaVrEliminado = data[4].ToNullableDouble();
            IndicadorSitVrEliminado = data[5];
        }
    }
}