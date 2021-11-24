using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C114: CUPOM FISCAL REFERENCIADO
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC114 : Primitives.Registro
    {
        public RegistroC114() : base("C114")
        {
        }

        public RegistroC114(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C114|"); // 1
            writer.Append(Cod_Modelo + "|"); // 2
            writer.Append(ECF_FAB + "|"); // 3
            writer.Append(ECF_CX + "|"); // 4
            writer.Append(Num_Doc + "|"); // 5
            writer.Append(DataDoc.ToSpedString() + "|"); // 6
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Cod_Modelo = data[2];
            ECF_FAB = data[3];
            ECF_CX = data[4];
            Num_Doc = data[5];
            DataDoc = data[6].ToDate();
        }

        public string Cod_Modelo { get; set; } // 2 ---- tamanho 2 ---- conforme tabela 4.1.1
        public string ECF_FAB { get; set; } // 3 ---- tamanho 21
        public string ECF_CX { get; set; } // 4 ---- tamanho 3
        public string Num_Doc { get; set; } // 5 ----tamanho 9
        public DateTime? DataDoc { get; set; } // 6 ----tamanho 8*
    }
}