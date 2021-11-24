using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Processo Referenciado
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC198 : Primitives.Registro
    {
        public RegistroC198() : base("C198")
        {
        }

        public RegistroC198(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string NumeroProcesso { get; set; } = null;
        public EFD_ICMS_IPI.IndicadorOrigemProcesso IndicadorOrigemProcesso { get; set; } = EFD_ICMS_IPI.IndicadorOrigemProcesso.Outros;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C198|");
            writer.Append(NumeroProcesso + "|");
            writer.Append(((int)IndicadorOrigemProcesso).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroProcesso = data[2];
            IndicadorOrigemProcesso = (EFD_ICMS_IPI.IndicadorOrigemProcesso)data[3].ToEnum<EFD_ICMS_IPI.IndicadorOrigemProcesso>(EFD_ICMS_IPI.IndicadorOrigemProcesso.Outros);
        }
    }
}