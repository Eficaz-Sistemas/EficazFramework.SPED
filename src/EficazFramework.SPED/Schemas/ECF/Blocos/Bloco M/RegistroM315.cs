
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Identificação de Processos Judiciais e Administrativos Referentes ao Lançamento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroM315 : Primitives.Registro
    {
        public RegistroM315() : base("M315")
        {
        }

        public RegistroM315(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public TipoProcessoLancto IndicadorTipoProcesso { get; set; } = TipoProcessoLancto.Administrativo;
        public string NumeroLancto { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M315|");
            writer.Append((int)IndicadorTipoProcesso + "|");
            writer.Append(NumeroLancto + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}