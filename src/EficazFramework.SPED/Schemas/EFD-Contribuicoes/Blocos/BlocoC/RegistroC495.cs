using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Consolidação de Documentos Emitidos por ECF
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC495 : Primitives.Registro
    {
        public RegistroC495() : base("C495")
        {
        }

        public RegistroC495(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoItem { get; set; } = null;
        public string CSTCofins { get; set; } = null;
        public string CFOP { get; set; } = null;
        public double? ValorTotalItens { get; set; }
        public double? ValorBCCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? QtdeBCCofins { get; set; }
        public double? AliquotaCofinsQtde { get; set; }
        public double? ValorCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C495|");
            writer.Append(CodigoItem + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(CFOP + "|");
            writer.Append(ValorTotalItens + "|");
            writer.Append(ValorBCCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(QtdeBCCofins + "|");
            writer.Append(AliquotaCofinsQtde + "|");
            writer.Append(ValorCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoItem = data[2];
            CSTCofins = data[3];
            CFOP = data[4];
            ValorTotalItens = data[5].ToNullableDouble();
            ValorBCCofins = data[6].ToNullableDouble();
            AliquotaCofins = data[7].ToNullableDouble();
            QtdeBCCofins = data[8].ToNullableDouble();
            AliquotaCofinsQtde = data[9].ToNullableDouble();
            ValorCofins = data[10].ToNullableDouble();
            CodigoContaContabil = data[11];
        }
    }
}