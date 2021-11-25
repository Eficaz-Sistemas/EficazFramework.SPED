using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C175: OPERAÇÕES COM VEÍCULOS NOVOS (CÓDIGO 01 E 55)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC175 : Primitives.Registro
    {
        public RegistroC175() : base("C175")
        {
        }

        public RegistroC175(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C175|"); // 1
            writer.Append(((int)IndicadorTipoOperacaoVeiculo).ToString() + "|"); // 2
            writer.Append(CNPJ + "|"); // 3
            writer.Append(UFConcessionaria + "|"); // 4
            writer.Append(ChassiVeiculo + "|"); // 5
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorTipoOperacaoVeiculo = (IndicadorTipoOperacaoVeiculo)data[2].ToEnum<IndicadorTipoOperacaoVeiculo>(IndicadorTipoOperacaoVeiculo.Faturamento_Direto);
            CNPJ = data[3].ToString();
            UFConcessionaria = data[4].ToString();
            ChassiVeiculo = data[5].ToString();
        }

        public IndicadorTipoOperacaoVeiculo IndicadorTipoOperacaoVeiculo { get; set; } = IndicadorTipoOperacaoVeiculo.Faturamento_Direto; // 2
        public string CNPJ { get; set; } = null;
        public string UFConcessionaria { get; set; } = null;
        public string ChassiVeiculo { get; set; } = null;
    }
}