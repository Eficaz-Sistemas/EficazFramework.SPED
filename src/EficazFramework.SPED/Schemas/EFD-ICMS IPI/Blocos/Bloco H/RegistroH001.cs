// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Abertura do Bloco H
    /// </summary>
    /// <remarks></remarks>
    public class RegistroH001 : Primitives.Registro
    {
        public RegistroH001() : base("H001")
        {
        }

        public RegistroH001(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|H001|"); // 1
            writer.Append(((int)IndicadorMovimento).ToString() + "|"); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
        }

        public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;
    }
}