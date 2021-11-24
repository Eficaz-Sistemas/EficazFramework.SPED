using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Processo Referenciado
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF211 : Primitives.Registro
    {
        public RegistroF211() : base("F211")
        {
        }

        public RegistroF211(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string IdentificacaoProcesso { get; set; } = null;
        public EFD_ICMS_IPI.IndicadorOrigemProcesso IndicadorOrigemProcesso { get; set; } = EFD_ICMS_IPI.IndicadorOrigemProcesso.Outros;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F211|");
            writer.Append(IdentificacaoProcesso + "|");
            writer.Append(((int)IndicadorOrigemProcesso).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IdentificacaoProcesso = Conversions.ToString(data[2].ToEnum<EFD_ICMS_IPI.IndicadorOrigemProcesso>(EFD_ICMS_IPI.IndicadorOrigemProcesso.Outros));
        }
    }
}