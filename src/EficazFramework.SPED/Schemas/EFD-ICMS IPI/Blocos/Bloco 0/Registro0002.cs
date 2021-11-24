using EficazFrameworkCore.SPED.Extensions;
using EficazFrameworkCore.SPED.Schemas.Primitives;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Abertura do Bloco 0
    /// </summary>
    /// <remarks></remarks>

    public class Registro0002 : Registro
    {
        public Registro0002() : base("0002")
        {
        }

        public Registro0002(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0002|"); // 1
            writer.Append(((int)ClassificacaoEstabelecimento).ToString() + "|"); // 2
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            ClassificacaoEstabelecimento = (TipoAtividade)data[2].ToEnum<TipoDeAtividade>(TipoAtividade.Industrial);
        }

        public TipoAtividade ClassificacaoEstabelecimento { get; set; } = TipoAtividade.Industrial; // 2
    }
}