using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C178: OPERAÇÕES COM PRODUTOS SUJEITOS À TRIBUTAÇÃO DE IPI POR UNIDADE OU QUANTIDADE DE PRODUTO
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC178 : Primitives.Registro
    {
        public RegistroC178() : base("C178")
        {
        }

        public RegistroC178(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C178|"); // 1
            writer.Append(CodClasseEnquadIPI + "|"); // 2
            writer.Append(string.Format("{0:0.##}", VrUnidPadraoTrib) + "|"); // 3
            writer.Append(string.Format("{0:0.###}", QtdeTotalProd) + "|"); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodClasseEnquadIPI = data[2].ToString();
            VrUnidPadraoTrib = data[3].ToNullableDouble();
            QtdeTotalProd = data[4].ToNullableDouble();
        }

        public string CodClasseEnquadIPI { get; set; } = null; // 2
        public double? VrUnidPadraoTrib { get; set; } = default; // 3
        public double? QtdeTotalProd { get; set; } = default; // 4
    }
}