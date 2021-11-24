// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Abertura do Bloco I
    /// </summary>
    /// <remarks></remarks>
    public class Registro1001 : Primitives.Registro
    {
        public Registro1001() : base("1001")
        {
        }

        public Registro1001(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1001|"); // 1
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