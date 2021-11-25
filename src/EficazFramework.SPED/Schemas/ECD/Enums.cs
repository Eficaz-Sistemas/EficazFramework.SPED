using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.ECD
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum SituacaoInicioPeriodo
    {
        [System.ComponentModel.Description("Normal (Início no primeiro dia do ano)")]
        Normal = 0,
        [System.ComponentModel.Description("Abertura (Início de atividades no ano-calendário)")]
        Abertura = 1,
        [System.ComponentModel.Description("Resultante de cisão/fusão ou remanescente de cisão, ou realizou incorporação")]
        Resultante_Cisao_Fusao_Incoporacao = 2,
        [System.ComponentModel.Description("Início de obrigatoriedade da entrega no curso do ano calendário")]
        InicioObrigatoriedadeCursoAnoCalendario = 3
    }

    public enum SituacaoEspecial
    {
        [System.ComponentModel.Description("Não Aplicável")]
        NaoAplicavel = 0,
        [System.ComponentModel.Description("Cisão")]
        Cisao = 1,
        [System.ComponentModel.Description("Fusão")]
        Fusao = 2,
        [System.ComponentModel.Description("Incorporação")]
        Incorporacao = 3,
        [System.ComponentModel.Description("Extinção")]
        Extincao = 4
    }

    public enum TipoConta
    {
        [System.ComponentModel.Description("Contas de Ativo")]
        Ativo = 1,
        [System.ComponentModel.Description("Contas de Passivo")]
        Passivo = 2,
        [System.ComponentModel.Description("Patrimônio Líquido")]
        PatrimonioLiquido = 3,
        [System.ComponentModel.Description("Contas de Resultado")]
        Resultado = 4,
        [System.ComponentModel.Description("Contas de Compensação")]
        Compensacao = 5,
        [System.ComponentModel.Description("Outras")]
        Outras = 9
    }

    public enum IndicadorConta
    {
        Sintetica = 1,
        Analitica = 2
    }

    public enum IndicadorExistNire
    {
        EmpresaNaoPossuiRegistroJunta = 0,
        EmpresaPossuiRegistroJunta = 1
    }

    public enum IndicadorFinalidadeEscrit
    {
        Original = 0,
        SubstitutaEscrituracaoNire = 1,
        SubstitutaEscrituracaoSemNire = 2,
        SubstitutaEscrituracaoTrocaNire = 3
    }

    public enum IndicadorGrandePorte
    {
        EmpresaNaoSujeitaAuditoria = 0,
        EmpresaSujeitaAuditoria = 1
    }

    public enum IndicadorTipoECD
    {
        ECDempresaNaoParticipanteSCP = 0,
        ECDempresaParticipanteSCP = 1,
        ECDdaSCP = 2
    }

    public enum IndicadorDescentralizacao
    {
        EscrituracaoMatriz = 0,
        EscrituracaoFilial = 1
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum TipoEscrituracao
    {
        Digital = 0,
        Outros = 1
    }


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IndicadorGrupoBalanço
    {
        Ativo = 1,
        PassivoPL = 2
    }

    public enum IndicadorTipoDemonst
    {
        DLPA = 0,
        DMPL = 1
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum EventoSocietario
    {
        Aquisicao = 1,
        Alienacao = 2,
        Fusao = 3,
        CisaoParcial = 4,
        CisaoTotal = 5,
        Incorporacao = 6,
        Extincao = 7,
        Constituicao = 5
    }

    public enum CondicaoEmpresaRelacionada
    {
        Sucessora = 1,
        Adquirente = 2,
        Alienante = 3
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public class NaturezaSubConta
    {
        public string Numero { get; set; } = null;
        public string Descricao { get; set; } = null;
        public string FundamentoLegal { get; set; } = null;
        public string ContaPrincipal { get; set; } = null;

        public override string ToString()
        {
            return string.Format("{0} - {1}", Numero, Descricao);
        }
    }

    public class NaturezasSubContas : Dictionary<string, NaturezaSubConta>
    {
        public NaturezasSubContas()
        {
            Add("2", new NaturezaSubConta() { Numero = "2", Descricao = "SUBCONTA TBU - CONTROLADA DIRETA NO EXTERIOR", FundamentoLegal = "Art. 76, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO CONTROLADA NO EXTERIOR" });
            Add("3", new NaturezaSubConta() { Numero = "3", Descricao = "SUBCONTA TBU - CONTROLADA INDIRETA NO EXTERIOR", FundamentoLegal = "Art. 76, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO CONTROLADA NO EXTERIOR" });
            Add("10", new NaturezaSubConta() { Numero = "10", Descricao = "SUBCONTA GOODWILL", FundamentoLegal = "Art. 20, Inciso III, Decreto-Lei no 1.598/77", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA" });
            Add("11", new NaturezaSubConta() { Numero = "11", Descricao = "SUBCONTA MAIS VALIA", FundamentoLegal = "Art. 20, Inciso II, Decreto-Lei no 1.598/77", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA" });
            Add("12", new NaturezaSubConta() { Numero = "12", Descricao = "SUBCONTA MENOS VALIA", FundamentoLegal = "Art. 20, Inciso II, Decreto-Lei no 1.598/77", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA" });
            Add("60", new NaturezaSubConta() { Numero = "60", Descricao = "SUBCONTA AVJ REFLEXO", FundamentoLegal = "Arts. 24A e 24B, Decreto-Lei no 1.598/77", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA" });
            Add("65", new NaturezaSubConta() { Numero = "65", Descricao = "SUBCONTA AVJ SUBSCRIÇÃO DE CAPITAL", FundamentoLegal = "Arts. 17 e 18, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA" });
            Add("70", new NaturezaSubConta() { Numero = "70", Descricao = "SUBCONTA AVJ - VINCULADA ATIVO/PASSIVO", FundamentoLegal = "Arts 13 e 14, Lei no 12.973/14", ContaPrincipal = "ATIVO OU PASSIVO" });
            Add("71", new NaturezaSubConta() { Numero = "71", Descricao = "SUBCONTA AVJ - DEPRECIAÇÃO ACUMULADA", FundamentoLegal = "Arts 13, §1o, e 14, Lei no 12.973/14", ContaPrincipal = "DEPRECIAÇÃO ACUMULADA" });
            Add("72", new NaturezaSubConta() { Numero = "72", Descricao = "SUBCONTA AVJ - AMORTIZAÇÃO ACUMULADA", FundamentoLegal = "Arts 13, §1o, e 14, Lei no 12.973/14", ContaPrincipal = "AMORTIZAÇÃO ACUMULADA" });
            Add("73", new NaturezaSubConta() { Numero = "73", Descricao = "SUBCONTA AVJ - EXAUSTÃO ACUMULADA", FundamentoLegal = "Arts 13, §1o, e 14, Lei no 12.973/14", ContaPrincipal = "EXAUSTÃO ACUMULADA" });
            Add("75", new NaturezaSubConta() { Numero = "75", Descricao = "SUBCONTA AVP - VINCULADA AO ATIVO", FundamentoLegal = "Art. 5o, § 1o, Lei no 12.973/14", ContaPrincipal = "ATIVO" });
            Add("76", new NaturezaSubConta() { Numero = "76", Descricao = "SUBCONTA AVP - DEPRECIAÇÃO ACUMULADA", FundamentoLegal = "Art. 5o, Inc. III, Lei no 12.973/14", ContaPrincipal = "DEPRECIAÇÃO ACUMULADA" });
            Add("77", new NaturezaSubConta() { Numero = "77", Descricao = "SUBCONTA AVP - AMORTIZAÇÃO ACUMULADA", FundamentoLegal = "Art. 5o, Inc. III, Lei no 12.973/14", ContaPrincipal = "AMORTIZAÇÃO ACUMULADA" });
            Add("78", new NaturezaSubConta() { Numero = "78", Descricao = "SUBCONTA AVP - EXAUSTÃO ACUMULADA", FundamentoLegal = "Art. 5o, Inc. III, Lei no 12.973/14", ContaPrincipal = "EXAUSTÃO ACUMULADA" });
            Add("80", new NaturezaSubConta() { Numero = "80", Descricao = "SUBCONTA MAIS VALIA ANTERIOR – ESTÁGIOS", FundamentoLegal = "Art. 37, §3o, Inc. I, Lei no 12.973/14, ou Art. 39, §1o, Inc. I, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA NO PAÍS" });
            Add("81", new NaturezaSubConta() { Numero = "81", Descricao = "SUBCONTA MENOS VALIA ANTERIOR – ESTÁGIOS", FundamentoLegal = "Art. 37, §3o, Inc. I, Lei no 12.973/14, ou Art. 39, §1o., Inc. I, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA NO PAÍS" });
            Add("82", new NaturezaSubConta() { Numero = "82", Descricao = "SUBCONTA GOODWILL ANTERIOR – ESTÁGIOS", FundamentoLegal = "Art. 37, §3o, Inc. I, Lei no 12.973/14, ou Art. 39, §1o, Inc. I, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA NO PAÍS" });
            Add("84", new NaturezaSubConta() { Numero = "84", Descricao = "SUBCONTA VARIAÇÃO MAIS VALIA ANTERIOR – ESTÁGIOS", FundamentoLegal = "Art. 37, §3o, Inc. II, Lei no 12.973/14 ou Art. 39, §1o, Inc. II, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA NO PAÍS" });
            Add("85", new NaturezaSubConta() { Numero = "85", Descricao = "SUBCONTA VARIAÇÃO MENOS VALIA ANTERIOR – ESTÁGIOS", FundamentoLegal = "Art. 37, §3o, Inc. II, Lei no 12.973/14 ou Art. 39, §1o, Inc. II, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA NO PAÍS" });
            Add("86", new NaturezaSubConta() { Numero = "86", Descricao = "SUBCONTA VARIAÇÃO GOODWILL ANTERIOR – ESTÁGIOS", FundamentoLegal = "Art. 37, §3o, Inc. II, Lei no 12.973/14 ou Art. 39, §1o, Inc. II, Lei no 12.973/14", ContaPrincipal = "PARTICIPAÇÃO SOCIETARIA NO PAÍS" });
            Add("90", new NaturezaSubConta() { Numero = "90", Descricao = "SUBCONTA ADOÇÃO INICIAL – VINCULADA OU AUXILIAR ATIVO/PASSIVO", FundamentoLegal = "Arts. 66 e 67, Lei no 12.973/14 Arts. 295, 296, 298 e 299 da Instrução Normativa RFB nº 1.700, de 14 de março de 2017", ContaPrincipal = "ATIVO OU PASSIVO" });
            Add("91", new NaturezaSubConta() { Numero = "91", Descricao = "SUBCONTA ADOÇÃO INICIAL – VINCULADA OU AUXILIAR - DEPRECIAÇÃO ACUMULADA", FundamentoLegal = "Arts. 66 e 67, Lei no 12.973/14 Arts. 295, 296, 298 e 299 da Instrução Normativa RFB nº 1.700, de 14 de março de 2017", ContaPrincipal = "DEPRECIAÇÃO ACUMULADA" });
            Add("92", new NaturezaSubConta() { Numero = "92", Descricao = "SUBCONTA ADOÇÃO INICIAL – VINCULADA OU AUXILIAR - AMORTIZAÇÃO ACUMULADA", FundamentoLegal = "Arts. 66 e 67, Lei no 12.973/14 Arts. 295, 296, 298 e 299 da Instrução Normativa RFB nº 1.700, de 14 de março de 2017", ContaPrincipal = "AMORTIZAÇÃO ACUMULADA" });
            Add("93", new NaturezaSubConta() { Numero = "93", Descricao = "SUBCONTA ADOÇÃO INICIAL – VINCULADA OU AUXILIAR - EXAUSTÃO ACUMULADA", FundamentoLegal = "Arts. 66 e 67, Lei no 12.973/14 Arts. 295, 296, 298 e 299 da Instrução Normativa RFB nº 1.700, de 14 de março de 2017", ContaPrincipal = "EXAUSTÃO ACUMULADA" });
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}