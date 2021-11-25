using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Tabela de Observações do Lançamento Fiscal
    /// </summary>
    /// <remarks></remarks>
    public class Registro0460 : Primitives.Registro
    {
        public Registro0460() : base("0460")
        {
        }

        public Registro0460(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0460|"); // 1
            writer.Append(CodigoObservacao + "|"); // 2
            if (!string.IsNullOrEmpty(Descricao))
                Descricao = Descricao.Trim();
            writer.Append(Descricao + "|"); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoObservacao = data[2].ToNullableInteger();
            Descricao = data[3];
        }

        public int? CodigoObservacao { get; set; }
        public string Descricao { get; set; } = null;
    }
}