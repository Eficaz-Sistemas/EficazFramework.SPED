using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Consolidação de Documentos Emitidos por ECF
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC491 : Primitives.Registro
    {
        public RegistroC491() : base("C491")
        {
        }

        public RegistroC491(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoItem { get; set; } = null;
        public string CSTPis { get; set; } = null;
        public string CFOP { get; set; } = null;
        public double? ValorTotalItens { get; set; }
        public double? ValorBCPis { get; set; }
        public double? AliquotaPIs { get; set; }
        public double? QtdeBCPis { get; set; }
        public double? AliquotaPisQtde { get; set; }
        public double? ValorPis { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C491|");
            writer.Append(CodigoItem + "|");
            writer.Append(CSTPis + "|");
            writer.Append(CFOP + "|");
            writer.Append(ValorTotalItens + "|");
            writer.Append(ValorBCPis + "|");
            writer.Append(AliquotaPIs + "|");
            writer.Append(QtdeBCPis + "|");
            writer.Append(AliquotaPisQtde + "|");
            writer.Append(ValorPis + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoItem = data[2];
            CSTPis = data[3];
            CFOP = data[4];
            ValorTotalItens = data[5].ToNullableDouble();
            ValorBCPis = data[6].ToNullableDouble();
            AliquotaPIs = data[7].ToNullableDouble();
            QtdeBCPis = data[8].ToNullableDouble();
            AliquotaPisQtde = data[9].ToNullableDouble();
            ValorPis = data[10].ToNullableDouble();
            CodigoContaContabil = data[11];
        }
    }
}