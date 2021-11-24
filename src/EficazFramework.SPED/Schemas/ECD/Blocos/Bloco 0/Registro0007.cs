
namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Outras Inscrições Cadastrais da Pessoa Jurídica
    /// </summary>
    /// <remarks></remarks>

    public class Registro0007 : Primitives.Registro
    {
        public Registro0007() : base("0007")
        {
        }

        public Registro0007(string linha, string versao) : base(linha, versao)
        {
        }

        // Campo'
        public string CodigoInstRespAdmCadastro { get; set; } = null;
        public string CodigoCadastralPJInst { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0007|");
            writer.Append(CodigoInstRespAdmCadastro + "|");
            writer.Append(CodigoCadastralPJInst + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoInstRespAdmCadastro = data[2];
            CodigoCadastralPJInst = data[3];
        }
    }
}