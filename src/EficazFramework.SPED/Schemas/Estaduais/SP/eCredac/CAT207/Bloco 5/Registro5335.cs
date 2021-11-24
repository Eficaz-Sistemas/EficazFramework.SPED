
namespace EficazFrameworkCore.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Operações Geradoras de Crédito Acumulado nas Fichas 6C ou 6D
    /// </summary>
    /// <remarks></remarks>
    public class Registro5335 : Primitives.Registro
    {
        public string DeclaracaoExportacao { get; set; } = null;
        public bool OperacaoComprovada { get; set; } = false;

        public Registro5335() : base("5335")
        {
        }

        public Registro5335(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("5335|");
            writer.Append(DeclaracaoExportacao + "|");
            if (OperacaoComprovada == true)
                writer.Append("0");
            else
                writer.Append("1");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}