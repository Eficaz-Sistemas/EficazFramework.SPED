
namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Assinatura Digital dos Arquivos que Contêm as Fichas de Lançamento Utilizadas no Período
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI151 : Primitives.Registro
    {
        public RegistroI151() : base("I151")
        {
        }

        public RegistroI151(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string HashFichasLanctos { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I151|");
            writer.Append(HashFichasLanctos + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            HashFichasLanctos = data[2];
        }
    }
}