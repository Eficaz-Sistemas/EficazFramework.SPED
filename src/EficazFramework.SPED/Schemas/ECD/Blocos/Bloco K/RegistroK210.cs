
namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Mapeamento para Planos de Contas das Empresas Consolidadas
    /// </summary>
    /// <remarks></remarks>

    public class RegistroK210 : Primitives.Registro
    {
        public RegistroK210() : base("K210")
        {
        }

        public RegistroK210(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoIdentEmpresaParticipante { get; set; } = null;
        public string CodigoContaEmpresaParticipante { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|K210|");
            writer.Append(CodigoIdentEmpresaParticipante + "|");
            writer.Append(CodigoContaEmpresaParticipante + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoIdentEmpresaParticipante = data[2];
            CodigoContaEmpresaParticipante = data[3];
        }
    }
}