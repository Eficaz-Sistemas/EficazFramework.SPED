
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Outras Informações (Lucro Real)
    /// </summary>
    public class RegistroY671 : Primitives.Registro
    {
        public RegistroY671() : base("Y671")
        {
        }

        public RegistroY671(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        /// <summary>
        /// Todas as pessoas jurídicas que tenham projeto aprovado para instalação, ampliação,
        /// modernização ou diversificação, enquadrado em setores da economia considerados
        /// prioritários para o desenvolvimento regional, em microrregiões menos desenvolvidas
        /// localizadas nas áreas de atuação da Sudene e da Sudam
        /// </summary>
        public double? AquisMaquinasInstrEquipNovos { get; set; } = default;
        /// <summary>
        /// Doação aos Fundos dos Direitos da Criança e do Adolescente
        /// </summary>
        public double? DoacaoFundoDirCriancaAdolesc { get; set; } = default;
        /// <summary>
        /// Doação aos Fundos Nacional, Estaduais ou Municipais do Idoso
        /// </summary>
        public double? DoacaoIdosos { get; set; } = default;
        public double? AquisAtivoImobilizado { get; set; } = default;
        public double? BaixasAtivoImobilizado { get; set; } = default;
        public double? ValorInicialBens_Lei_11051_2014 { get; set; } = default;
        public double? ValorFinalBens_Lei_11051_2014 { get; set; } = default;
        public double? CreditoCSLLDepreciacaoInicial { get; set; } = default;
        public double? ValorOpCambioIsentoIOF { get; set; } = default;
        public double? ValorFolhaPagtoAliqReduzica { get; set; } = default;
        public double? AliquotaReduzidaFolhaPagto { get; set; } = default;
        /// <summary>
        /// Alteração de Capital na Forma dos art. 22 e 23 da Lei no 9.249/1995
        /// </summary>
        public bool? AlteracaoCapitalSocial { get; set; } = default;
        /// <summary>
        /// Opção pela Escrituração, no Ativo, da Base de Cálculo Negativa da CSLL
        /// </summary>
        /// <returns></returns>
        public bool? Indicador_BC_CSLL_Negativa_Ativo { get; set; } = default;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|Y671|"); // 1
            writer.Append(string.Format("{0:F2}", AquisMaquinasInstrEquipNovos) + "|"); // 2
            writer.Append(string.Format("{0:F2}", DoacaoFundoDirCriancaAdolesc) + "|"); // 3
            writer.Append(string.Format("{0:F2}", DoacaoIdosos) + "|"); // 4
            writer.Append(string.Format("{0:F2}", AquisAtivoImobilizado) + "|"); // 5
            writer.Append(string.Format("{0:F2}", BaixasAtivoImobilizado) + "|"); // 6
            writer.Append(string.Format("{0:F2}", ValorInicialBens_Lei_11051_2014) + "|"); // 7
            writer.Append(string.Format("{0:F2}", ValorFinalBens_Lei_11051_2014) + "|"); // 8
            writer.Append(string.Format("{0:F2}", CreditoCSLLDepreciacaoInicial) + "|"); // 9
            writer.Append(string.Format("{0:F2}", ValorOpCambioIsentoIOF) + "|"); // 10
            writer.Append(string.Format("{0:F2}", ValorFolhaPagtoAliqReduzica) + "|"); // 11         
            writer.Append(string.Format("{0:F4}", AliquotaReduzidaFolhaPagto) + "|"); // 12
            if (AlteracaoCapitalSocial == true == true)
                writer.Append("2|");
            else
            {
                if (AlteracaoCapitalSocial.HasValue == false)
                    writer.Append("0|");
                else
                    writer.Append("1|");
            } // 13

            if (Indicador_BC_CSLL_Negativa_Ativo == true == true)
                writer.Append("2|");
            else
            {
                if (Indicador_BC_CSLL_Negativa_Ativo.HasValue == false)
                    writer.Append("0|");
                else
                    writer.Append("1|");
            } // 14

            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}