using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Abertura do BlocoC
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC001 : Primitives.Registro
    {
        public RegistroC001() : base("C001")
        {
        }

        public RegistroC001(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;
        public List<RegistroC010> RegistrosC010 { get; set; } = new List<RegistroC010>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C001|");
            writer.Append(((int)IndicadorMovimento).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
        }
    }
}