using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Centro de Custos
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ100 : Primitives.Registro
    {
        public RegistroJ100() : base("J100")
        {
        }

        public RegistroJ100(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public DateTime? DataInclusaoAlteracao { get; set; }
        public string CodCentroCusto { get; set; } = null;
        public string NomeCentroCusto { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J100|");
            writer.Append(DataInclusaoAlteracao + "|");
            writer.Append(CodCentroCusto + "|");
            writer.Append(NomeCentroCusto + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataInclusaoAlteracao = data[2].ToDate();
            CodCentroCusto = data[3];
            NomeCentroCusto = data[4];
        }
    }
}