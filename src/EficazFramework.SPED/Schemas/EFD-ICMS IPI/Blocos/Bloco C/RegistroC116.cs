using System;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C116: CUPOM FISCAL ELETRÔNICO REFERENCIADO
    /// </summary>C:\Users\Daniel Basilio\Documents\Visual Studio 2012\Projects\EficazFrameworkV2\EficazFramework.SPED\EFD-ICMS IPI\Blocos\Bloco C\RegistroC001.vb
    /// <remarks></remarks>
    public class RegistroC116 : Primitives.Registro
    {
        public RegistroC116() : base("C116")
        {
        }

        public RegistroC116(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C116|"); // 1
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }

        public string Cod_Modelo { get; set; } // 2 ---- tamanho 2 ---- conforme tabela 4.1.1
        public string Num_Serie_SAT { get; set; } // 3 ---- tamanho 9
        public string Chave_Cupom_Eletronico { get; set; } // 4 ---- tamanho 44
        public string Num_CFE { get; set; } // 5 ----tamanho 6
        public DateTime DataDoc { get; set; } // 6 ----tamanho 8*
    }
}