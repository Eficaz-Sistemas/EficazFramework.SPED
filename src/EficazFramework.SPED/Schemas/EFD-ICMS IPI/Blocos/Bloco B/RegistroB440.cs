using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Totalização dos Valores Retidos
    /// </summary>
    /// <remarks></remarks>

    public class RegistroB440 : Primitives.Registro
    {
        public RegistroB440() : base("B440")
        {
        }

        public RegistroB440(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|B440|"); // 1
            writer.Append(((int)IndicadorOperacaoServicos).ToString() + "|"); // 2
            writer.Append(CodParticipante + "|"); // 3
            writer.Append(string.Format("{0:0.##}", VrContabilPrestacoesAquisicoes) + "|"); // 4
            writer.Append(string.Format("{0:0.##}", VrBCISSPrestacoesAquisicoes) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", VrISSRetido) + "|"); // 6
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorOperacaoServicos = (IndicadorOperacaoServicos)data[2].ToEnum<IndicadorOperacaoServicos>(IndicadorOperacaoServicos.Aquisicao);
            CodParticipante = Conversions.ToString(data[3].ToNullableDouble());
            VrContabilPrestacoesAquisicoes = data[4].ToNullableDouble();
            VrBCISSPrestacoesAquisicoes = data[5].ToNullableDouble();
            VrISSRetido = data[6].ToNullableDouble();
        }

        public IndicadorOperacaoServicos IndicadorOperacaoServicos { get; set; } = IndicadorOperacaoServicos.Aquisicao; // 2 
        public string CodParticipante { get; set; } = null; // 3
        public double? VrContabilPrestacoesAquisicoes { get; set; } = default; // 4
        public double? VrBCISSPrestacoesAquisicoes { get; set; } = default; // 5
        public double? VrISSRetido { get; set; } = default; // 6
    }
}