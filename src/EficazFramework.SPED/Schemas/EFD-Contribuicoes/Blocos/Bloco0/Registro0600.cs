using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
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

        // Campos'
        public DateTime? DataInclusaoAlteracao { get; set; }
        public string CodigoCentroCusto { get; set; } = null; // tamanho 60'
        public string NomeCentroCusto { get; set; } = null; // tamanho 60'

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0600|");
            writer.Append(DataInclusaoAlteracao.ToSpedString() + "|");
            writer.Append(CodigoCentroCusto + "|");
            writer.Append(NomeCentroCusto + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataInclusaoAlteracao = data[2].ToDate();
            CodigoCentroCusto = data[3];
            CodigoCentroCusto = data[4];
        }
    }
}