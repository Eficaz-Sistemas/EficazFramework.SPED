using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Informação sobre a utilização do Bem
    /// </summary>
    /// <remarks></remarks>
    public class Registro0305 : Primitives.Registro
    {
        public Registro0305() : base("0305")
        {
        }

        public Registro0305(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0305|"); // 1
            // writer.Append(CInt(Me.CentroDeCusto) & "|") '2
            writer.Append(CentroDeCusto + "|"); // 2
            writer.Append(DescricaoFuncaoBem + "|"); // 3
            writer.Append(VidaUtil + "|"); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CentroDeCusto = data[2]; // .ToEnum(Of CentroDeCusto)(CentroDeCusto.Com_AreaOperacional)
            DescricaoFuncaoBem = data[3];
            VidaUtil = data[4].ToNullableInteger();
        }

        public string CentroDeCusto { get; set; } = null; // CentroDeCusto = EFD_ICMS_IPI.CentroDeCusto.Com_AreaOperacional '2
        public string DescricaoFuncaoBem { get; set; } // 3
        public int? VidaUtil { get; set; } // 4
    }
}