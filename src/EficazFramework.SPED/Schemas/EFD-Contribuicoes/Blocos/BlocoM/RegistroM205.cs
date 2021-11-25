using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Contribuição para o pis a recolher - detalhamento por código de receita
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM205 : Primitives.Registro
    {
        public RegistroM205() : base("M205")
        {
        }

        public RegistroM205(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NumeroCampoRegistroM200 { get; set; } = null;
        public string CodigoReceita { get; set; } = null;
        public double? VrDebitoDCTF { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M205|");
            writer.Append(NumeroCampoRegistroM200 + "|");
            writer.Append(CodigoReceita + "|");
            writer.Append(VrDebitoDCTF + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroCampoRegistroM200 = data[2];
            CodigoReceita = data[3];
            VrDebitoDCTF = data[4].ToNullableDouble();
        }
    }
}