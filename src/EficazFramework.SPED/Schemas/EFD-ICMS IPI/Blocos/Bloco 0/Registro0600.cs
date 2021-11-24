using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Centro de Custos
    /// </summary>
    /// <remarks></remarks>
    public class Registro0600 : Primitives.Registro
    {
        public Registro0600() : base("0600")
        {
        }

        public Registro0600(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0600|"); // 1
            writer.Append(DataAlteracao.ToSpedString() + "|"); // 02
            writer.Append(CodigoCC + "|"); // 03
            writer.Append(NomeCC + "|"); // 04
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataAlteracao = data[2].ToDate();
            CodigoCC = data[3];
            NomeCC = data[4];
        }

        public DateTime? DataAlteracao { get; set; }
        public string CodigoCC { get; set; } = null;
        public string NomeCC { get; set; } = null;
    }
}