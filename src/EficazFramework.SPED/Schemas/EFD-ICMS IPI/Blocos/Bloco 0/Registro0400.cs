
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Tabela de Natureza da Operação / Prestação
    /// </summary>
    /// <remarks></remarks>
    public class Registro0400 : Primitives.Registro
    {
        public Registro0400() : base("0400")
        {
        }

        public Registro0400(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0400|"); // 1
            writer.Append(CodigoNatureza + "|"); // 2
            writer.Append(DescricaoNatureza + "|"); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoNatureza = data[2];
            DescricaoNatureza = data[3];
        }

        public string CodigoNatureza { get; set; } // 2
        public string DescricaoNatureza { get; set; } // 3
    }
}