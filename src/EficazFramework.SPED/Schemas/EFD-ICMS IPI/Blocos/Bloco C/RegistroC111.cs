
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C111: PROCESSO REFERENCIADO
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC111 : Primitives.Registro
    {
        public RegistroC111() : base("C111")
        {
        }

        public RegistroC111(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C111|"); // 1
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }

        public string Ident_Proc_AtoConcessorio { get; set; } // 2
        public IndicadorOrigemProcesso Ind_Origem_Processo { get; set; } = IndicadorOrigemProcesso.SEFAZ; // 3
    }
}