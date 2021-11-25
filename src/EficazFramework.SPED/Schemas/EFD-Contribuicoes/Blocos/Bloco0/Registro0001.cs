using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Abertura do Bloco 0
    /// </summary>
    /// <remarks></remarks>
    public class Registro0001 : Primitives.Registro
    {
        public Registro0001() : base("0001")
        {
        }

        public Registro0001(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public Primitives.IndicadorMovimento IndicadorMovimento { get; set; } = Primitives.IndicadorMovimento.ComDados;
        public List<Registro0035> Registros0035 { get; set; } = new List<Registro0035>();
        public List<Registro0100> Registros0100 { get; set; } = new List<Registro0100>();
        public Registro0110 Registro0110 { get; set; } = null;
        public List<Registro0120> Registros0120 { get; set; } = new List<Registro0120>();
        public List<Registro0140> Registros0140 { get; set; } = new List<Registro0140>();
        public List<Registro0500> Registros0500 { get; set; } = new List<Registro0500>();
        public List<Registro0600> Registros0600 { get; set; } = new List<Registro0600>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0001|");
            writer.Append(((int)IndicadorMovimento).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorMovimento = (Primitives.IndicadorMovimento)data[2].ToEnum<Primitives.IndicadorMovimento>(Primitives.IndicadorMovimento.ComDados);
        }
    }
}