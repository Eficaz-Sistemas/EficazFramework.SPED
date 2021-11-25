
namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Plano de Contas Consolidado
    /// </summary>
    /// <remarks></remarks>

    public class RegistroK200 : Primitives.Registro
    {
        public RegistroK200() : base("K200")
        {
        }

        public RegistroK200(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoNaturezaContas { get; set; } = null;
        public string IndicadorTipoConta { get; set; } = null;
        public string NivelConta { get; set; } = null;
        public string CodigoConta { get; set; } = null;
        public string CodigoContaSuperior { get; set; } = null;
        public string NomeConta { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K200|");
            writer.Append(CodigoNaturezaContas + "|");
            writer.Append(IndicadorTipoConta + "|");
            writer.Append(NivelConta + "|");
            writer.Append(CodigoConta + "|");
            writer.Append(CodigoContaSuperior + "|");
            writer.Append(NomeConta + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoNaturezaContas = data[2];
            IndicadorTipoConta = data[3];
            NivelConta = data[4];
            CodigoConta = data[5];
            CodigoContaSuperior = data[6];
            NomeConta = data[7];
        }
    }
}