using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Resumo Diário de Documentos Emitidos Por ECF
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC481 : Primitives.Registro
    {
        public RegistroC481() : base("C481")
        {
        }

        public RegistroC481(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTPis { get; set; } = null;
        public double? ValorTotalItens { get; set; }
        public double? ValorBCPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? QtdeBCPis { get; set; }
        public double? AliquotaPISQtde { get; set; }
        public double? ValorPIS { get; set; }
        public string CodigoItem { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C481|");
            writer.Append(CSTPis + "|");
            writer.Append(ValorTotalItens + "|");
            writer.Append(ValorBCPis + "|");
            writer.Append(AliquotaPis + "|");
            writer.Append(QtdeBCPis + "|");
            writer.Append(AliquotaPISQtde + "|");
            writer.Append(ValorPIS + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTPis = data[2];
            ValorTotalItens = data[3].ToNullableDouble();
            ValorBCPis = data[4].ToNullableDouble();
            AliquotaPis = data[5].ToNullableDouble();
            QtdeBCPis = data[6].ToNullableDouble();
            AliquotaPISQtde = data[7].ToNullableDouble();
            ValorPIS = data[8].ToNullableDouble();
            CodigoItem = data[9];
            CodigoContaContabil = data[10];
        }
    }
}