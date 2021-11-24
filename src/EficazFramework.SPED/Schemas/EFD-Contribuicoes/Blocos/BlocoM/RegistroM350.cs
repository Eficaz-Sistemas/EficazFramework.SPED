using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Pis Folha de Salários
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM350 : Primitives.Registro
    {
        public RegistroM350() : base("M350")
        {
        }

        public RegistroM350(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? VrTotalFolhaSalarios { get; set; }
        public double? VrTotalExclusoesBC { get; set; }
        public double? VrTotalBC { get; set; }
        public double? AliqPisFolhaSalarios { get; set; }
        public double? VrTotalContribFolhaSalarios { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M350|");
            writer.Append(VrTotalFolhaSalarios + "|");
            writer.Append(VrTotalExclusoesBC + "|");
            writer.Append(VrTotalBC + "|");
            writer.Append(AliqPisFolhaSalarios + "|");
            writer.Append(VrTotalContribFolhaSalarios + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalFolhaSalarios = data[2].ToNullableDouble();
            VrTotalExclusoesBC = data[3].ToNullableDouble();
            VrTotalBC = data[4].ToNullableDouble();
            AliqPisFolhaSalarios = data[5].ToNullableDouble();
            VrTotalContribFolhaSalarios = data[6].ToNullableDouble();
        }
    }
}