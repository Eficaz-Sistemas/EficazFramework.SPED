using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Saldo das Contas Consolidadas
    /// </summary>
    /// <remarks></remarks>

    public class RegistroK300 : Primitives.Registro
    {
        public RegistroK300() : base("K300")
        {
        }

        public RegistroK300(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoContaConsolidada { get; set; } = null;
        public double? VrAbsolutoAglutinado { get; set; }
        public string IndicadorSitVrAglutinado { get; set; } = null;
        public double? VrAbsolutoEliminacoes { get; set; }
        public string IndicadorSitVrAglutinadoEliminado { get; set; } = null;
        public double? VrAbsolutoConsolidado { get; set; }
        public string IndicadorSitVrConsolidado { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K300|");
            writer.Append(CodigoContaConsolidada + "|");
            writer.Append(VrAbsolutoAglutinado + "|");
            writer.Append(IndicadorSitVrAglutinado + "|");
            writer.Append(VrAbsolutoEliminacoes + "|");
            writer.Append(IndicadorSitVrAglutinadoEliminado + "|");
            writer.Append(VrAbsolutoConsolidado + "|");
            writer.Append(IndicadorSitVrConsolidado + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoContaConsolidada = data[2];
            VrAbsolutoConsolidado = data[3].ToNullableDouble();
            IndicadorSitVrAglutinado = data[4];
            VrAbsolutoEliminacoes = data[5].ToNullableDouble();
            IndicadorSitVrAglutinadoEliminado = data[6];
            VrAbsolutoConsolidado = data[7].ToNullableDouble();
            IndicadorSitVrConsolidado = data[8];
        }
    }
}