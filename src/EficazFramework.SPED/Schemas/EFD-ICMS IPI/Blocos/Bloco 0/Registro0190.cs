
namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Identificação das Unidades de Medida
    /// </summary>
    /// <remarks></remarks>
    public class Registro0190 : Primitives.Registro
    {
        public Registro0190() : base("0190")
        {
        }

        public Registro0190(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0190|"); // 1
            writer.Append(Unidade + "|"); // 2
            writer.Append(Descricao + "|"); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Unidade = data[2];
            Descricao = data[3];
        }

        public string Unidade { get; set; } = null;
        public string Descricao { get; set; } = null;
    }
}