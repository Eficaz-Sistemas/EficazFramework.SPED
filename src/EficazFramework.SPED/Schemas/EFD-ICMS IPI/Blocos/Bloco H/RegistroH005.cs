// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Totais do Inventário
    /// </summary>
    /// <remarks></remarks>
    public class RegistroH005 : Primitives.Registro
    {
        public RegistroH005() : base("H005")
        {
        }

        public RegistroH005(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|H005|"); // 1
            writer.Append(DataInventario.ToSpedString() + "|"); // 2
            writer.Append(string.Format("{0:0.##}", ValorEstoque) + "|"); // 3
            writer.Append(string.Format("{0:00}", (int)Motivo) + "|"); // 4
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataInventario = data[2].ToDate();
            ValorEstoque = data[3].ToNullableDouble(2);
            Motivo = (MotivoInventario)data[4].ToEnum<MotivoInventario>(MotivoInventario.FinalPeriodo);
        }

        public DateTime? DataInventario { get; set; }
        public double? ValorEstoque { get; set; }
        public MotivoInventario Motivo { get; set; } = MotivoInventario.FinalPeriodo;
    }
}