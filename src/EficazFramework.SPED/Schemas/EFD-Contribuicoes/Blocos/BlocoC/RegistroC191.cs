using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Detalhamento da Consolidaçao - Operações de Aquisição Com direito a crédito
    /// e operações de devolução de compras e vendas - pis pasep
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC191 : Primitives.Registro
    {
        public RegistroC191() : base("C191")
        {
        }

        public RegistroC191(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos 
        public string CNPJParticipanteOperConsolidadas { get; set; } = null;
        public string CSTPis { get; set; } = null;
        public string CFOP { get; set; } = null;
        public double? VrItem { get; set; }
        public double? VrDescontoExclusao { get; set; }
        public double? VrBaseCalculoPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? BCPISQuantidade { get; set; }
        public double? AliquotaPISReais { get; set; }
        public double VrPIS { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C191|");
            writer.Append(CNPJParticipanteOperConsolidadas + "|");
            writer.Append(CSTPis + "|");
            writer.Append(CFOP + "|");
            writer.Append(VrItem + "|");
            writer.Append(VrDescontoExclusao + "|");
            writer.Append(VrBaseCalculoPis + "|");
            writer.Append(AliquotaPis + "|");
            writer.Append(BCPISQuantidade + "|");
            writer.Append(AliquotaPISReais + "|");
            writer.Append(VrPIS + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CNPJParticipanteOperConsolidadas = data[2];
            CSTPis = data[3];
            CFOP = data[4];
            VrItem = data[5].ToNullableDouble();
            VrDescontoExclusao = data[6].ToNullableDouble();
            VrBaseCalculoPis = data[7].ToNullableDouble();
            AliquotaPis = data[8].ToNullableDouble();
            BCPISQuantidade = data[9].ToNullableDouble();
            AliquotaPISReais = data[10].ToNullableDouble();
            VrPIS = (double)data[11].ToNullableDouble();
            CodigoContaContabil = data[12];
        }
    }
}