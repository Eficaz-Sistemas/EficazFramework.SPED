using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Resumo Diário de Documentos Emitidos Por ECF
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC485 : Primitives.Registro
    {
        public RegistroC485() : base("C485")
        {
        }

        public RegistroC485(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CSTCofins { get; set; } = null;
        public double? ValorTotalItens { get; set; }
        public double? ValorBCCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? QtdeBCCofins { get; set; }
        public double? AliquotaCofinsQtde { get; set; }
        public double? ValorCofins { get; set; }
        public string CodigoItem { get; set; } = null;
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C485|");
            writer.Append(CSTCofins + "|");
            writer.Append(ValorTotalItens + "|");
            writer.Append(ValorBCCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(QtdeBCCofins + "|");
            writer.Append(AliquotaCofinsQtde + "|");
            writer.Append(ValorCofins + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CSTCofins = data[2];
            ValorTotalItens = data[3].ToNullableDouble();
            ValorBCCofins = data[4].ToNullableDouble();
            AliquotaCofins = data[5].ToNullableDouble();
            QtdeBCCofins = data[6].ToNullableDouble();
            AliquotaCofinsQtde = data[7].ToNullableDouble();
            ValorCofins = data[8].ToNullableDouble();
            CodigoItem = data[9];
            CodigoContaContabil = data[10];
        }
    }
}