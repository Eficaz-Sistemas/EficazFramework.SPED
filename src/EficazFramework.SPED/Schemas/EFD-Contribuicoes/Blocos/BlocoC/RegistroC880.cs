using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Resumo Diário de Documentos Emitidos por Equipamento SAT
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC880 : Primitives.Registro
    {
        public RegistroC880() : base("C880")
        {
        }

        public RegistroC880(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoItem { get; set; } = null;
        public string CFOP { get; set; } = null;
        public double? VrTotalItens { get; set; }
        public double? VrExclusaoDescontoItens { get; set; }
        public string CSTPis { get; set; } = null;
        public double? BcPisQtde { get; set; }
        public double? AliquotaPisQtde { get; set; }
        public double? VrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? BcCofinsQtde { get; set; }
        public double? AliquotaCofinsQtde { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C880|");
            writer.Append(CodigoItem + "|");
            writer.Append(CFOP + "|");
            writer.Append(VrTotalItens + "|");
            writer.Append(VrExclusaoDescontoItens + "|");
            writer.Append(CSTPis + "|");
            writer.Append(BcPisQtde + "|");
            writer.Append(AliquotaPisQtde + "|");
            writer.Append(VrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(BcCofinsQtde + "|");
            writer.Append(AliquotaCofinsQtde + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoItem = data[2];
            CFOP = data[3];
            VrTotalItens = data[4].ToNullableDouble();
            VrExclusaoDescontoItens = data[5].ToNullableDouble();
            CSTPis = data[6];
            BcPisQtde = data[7].ToNullableDouble();
            AliquotaPisQtde = data[8].ToNullableDouble();
            VrPis = data[9].ToNullableDouble();
            CSTCofins = data[10];
            BcCofinsQtde = data[11].ToNullableDouble();
            AliquotaCofinsQtde = data[12].ToNullableDouble();
            VrCofins = data[13].ToNullableDouble();
            CodigoContaContabil = data[14];
        }
    }
}