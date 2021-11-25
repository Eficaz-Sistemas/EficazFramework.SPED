
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C115: LOCAL DA COLETA E/OU ENTREGA (CÓDIGO 01, 1B E 04)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC115 : Primitives.Registro
    {
        public RegistroC115() : base("C115")
        {
        }

        public RegistroC115(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C115|"); // 1
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }

        public IndicadorTipoTransporte IndicadorTipoTransporte { get; set; } = IndicadorTipoTransporte.Rodoviario; // 2
        public string CNPJ_Coleta { get; set; } // 3 ---- tamanho 14
        public string IE_coleta { get; set; } // 4 ---- tamanho 14
        public string CPF_Coleta { get; set; } // 5 ---- tamanho 11
        public string Codigo_Municipio_Coleta { get; set; } // 6 ----tamanho 7
        public string CNPJ_Entrega { get; set; } // 7 ----tamanho 14
        public string IE_Entrega { get; set; } // 8 ----tamanho 14
        public string CPF_Entrega { get; set; } // 9 ---- tamanho 11
        public string Codigo_Municipio_Entrega { get; set; } // 10 ---- tamanho 7
    }
}