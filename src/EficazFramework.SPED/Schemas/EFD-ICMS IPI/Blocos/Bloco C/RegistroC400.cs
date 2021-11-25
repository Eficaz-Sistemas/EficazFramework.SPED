using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Equipamento ECF (Código 02, 2D e 60)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC400 : Primitives.Registro
    {
        public RegistroC400() : base("C400")
        {
        }

        public RegistroC400(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C400|"); // 1
            writer.Append(CodigoModelo + "|"); // 2
            writer.Append(Especie + "|"); // 3
            writer.Append(NumeroSerie + "|"); // 4
            writer.Append(NumeroCaixa + "|"); // 5
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoModelo = data[2];
            Especie = data[3];
            NumeroSerie = data[4];
            NumeroCaixa = data[5].ToNullableInteger();
        }

        public string CodigoModelo { get; set; } = null; // 2
        public string Especie { get; set; } = null; // 3
        public string NumeroSerie { get; set; } = null; // 4
        public int? NumeroCaixa { get; set; } = default; // 5


        // Registros Filhos
        public List<RegistroC405> RegistrosC405 { get; set; } = new List<RegistroC405>();
    }
}