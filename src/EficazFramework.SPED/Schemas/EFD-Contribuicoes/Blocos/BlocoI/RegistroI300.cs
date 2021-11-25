using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento das operações - detalhamento das receitas, deduções ou exclusões do período
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI300 : Primitives.Registro
    {
        public RegistroI300() : base("I300")
        {
        }

        public RegistroI300(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoComplementar { get; set; } = null;
        public double? DetValor { get; set; }
        public string CodigoContaContabil { get; set; } = null;
        public string InfoComplementar { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I300|");
            writer.Append(CodigoComplementar + "|");
            writer.Append(DetValor + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(InfoComplementar + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoComplementar = data[2];
            DetValor = data[3].ToNullableDouble();
            CodigoContaContabil = data[4];
            InfoComplementar = data[5];
        }
    }
}