using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.eSocial.CachedData
{
    public class IndicadoresPrevidenciaSocial : Dictionary<string, string>
    {
        public static object Instance
        {
            get
            {
                return new IndicadoresPrevidenciaSocial();
            }
        }

        public IndicadoresPrevidenciaSocial()
        {
            Add("00", "00 - Não é base de cálculo");
            Add("01", "01 - Não é base de cálculo em função de acordos internacionais de previdência social");
            Add("11", "11 - Base de Cálculo Mensal");
            Add("12", "12 - Base de Cálculo do 13o Salário");
            Add("13", "13 - Exclusiva do Empregador - mensal");
            Add("14", "14 - Exclusiva do Empregador - 13° salário");
            Add("15", "15 - Exclusiva do segurado - mensal");
            Add("16", "16 - Exclusiva do segurado - 13° salário");
            Add("21", "21 - Salário maternidade mensal pago pelo Empregador");
            Add("22", "22 - Salário maternidade - 13o Salário, pago pelo Empregador");
            // Me.Add("23", "23 - Auxilio doença mensal - Regime Próprio de Previdência Social")
            // Me.Add("24", "24 - Auxilio doença 13o salário doença - Regime próprio de previdência social")
            Add("25", "25 - Salário maternidade mensal pago pelo INSS");
            Add("26", "26 - Salário maternidade - 13° salário, pago pelo INSS");
            Add("31", "31 - INSS Mensal");
            Add("32", "32 - INSS 13o Salário");
            Add("34", "34 - INSS SEST");
            Add("35", "35 - INSS SENAT");
            Add("51", "51 - Salário-família");
            // Me.Add("61", "61 - Complemento de salário-mínimo - Regime próprio de previdência social")
            Add("91", "91 - Suspensão INSS Mensal");
            Add("92", "92 - Suspensão INSS 13o Salário");
            Add("93", "93 - Suspensão INSS Salário maternidade");
            Add("94", "94 - Suspensão INSS Salário maternidade 13o salário");
            Add("95", "95 - Suspensão INSS Exclusiva do Empregador - mensal");
            Add("96", "96 - Suspensão INSS Exclusiva do Empregador - 13º salário");
            Add("97", "97 - Suspensão INSS Exclusiva do Empregador - Salário maternidade");
            Add("98", "98 - Suspensão INSS  Exclusiva do Empregador - Salário maternidade 13º salário");
        }
    }

    public class IndicadoresIRRF : Dictionary<string, string>
    {
        public static object Instance
        {
            get
            {
                return new IndicadoresIRRF();
            }
        }

        public IndicadoresIRRF()
        {
            Add("00", "00 - Rendimento não tributável");
            Add("01", "01 - Rendimento não tributável em função de acordos internacionais de bitributação");
            Add("09", "09 - Outras verbas não consideradas como base de cálculo ou rendimento");
            // Rendimento Tributável:
            Add("11", "11 - Remuneração mensal");
            Add("12", "12 - 13o Salário");
            Add("13", "13 - Férias");
            Add("14", "14 - PLR");
            Add("15", "15 - Rendimentos Recebidos Acumuladamente - RRA");
            // Retenção de IRRF Efetuada Sobre:
            Add("31", "31 - IRRF Remuneração mensal");
            Add("32", "32 - IRRF 13o Salário");
            Add("33", "33 - IRRF Férias");
            Add("34", "34 - IRRF PLR");
            Add("35", "35 - IRRF RRA");
            // Dedução do rendimento tributável do IRRF:
            Add("41", "41 - Previdência Social Oficial - PSO - Remuner. mensal");
            Add("42", "42 - PSO - 13° salário");
            Add("43", "43 - PSO - Férias");
            Add("44", "44 - PSO - RRA");
            Add("46", "46 - Previdência Privada - salário mensal");
            Add("47", "47 - Previdência Privada - 13° salário");
            Add("48", "48 - Previdência Privada - Férias");
            Add("51", "51 - Pensão Alimentícia - Remuneração mensal");
            Add("52", "52 - Pensão Alimentícia - 13° salário");
            Add("53", "53 - Pensão Alimentícia - Férias");
            Add("54", "54 - Pensão Alimentícia - PLR");
            Add("55", "55 - Pensão Alimentícia - RRA");
            Add("61", "61 - Fundo de Aposentadoria Programada Individual - FAPI - Remuneração");
            Add("62", "62 - Fundo de Aposentadoria Programada Individual - FAPI - 13° salário");
            Add("63", "63 - Fundação de Previdência Complementar do Servidor Público - Funpresp - Remuneração mensal");
            Add("64", "64 - Fundação de Previdência Complementar do Servidor Público - 13º salário");
            Add("65", "65 - Fundação de Previdência Complementar do Servidor Público - Férias");
            Add("66", "66 - Fundo de Aposentadoria Programada Individual - FAPI - Férias");
            Add("67", "67 - Plano privado coletivo de assistência à saúde");
            Add("70", "70 - Parcela Isenta 65 anos - Remuneração mensal");
            Add("71", "71 - Parcela Isenta 65 anos - 13° salário");
            Add("72", "72 - Diárias");
            Add("73", "73 - Ajuda de custo");
            Add("74", "74 - Indenização e rescisão de contrato, inclusive a título de PDV e acidentes de trabalho");
            Add("75", "75 - Abono pecuniário");
            Add("76", "76 - Pensão, aposentadoria ou reforma por moléstia grave ou acidente em serviço - Remuneração Mensal");
            Add("77", "77 - Pensão, aposentadoria ou reforma por moléstia grave ou acidente em serviço - 13° salário");
            Add("78", "78 - Valores pagos a titular ou sócio de microempresa ou empresa de pequeno porte, exceto pró-labore e alugueis");
            Add("700", "700 - Auxílio Moradia");
            Add("701", "701 - Parte não tributável do valor de serviço de transporte de passageiros ou cargas");
            Add("79", "79 - Outras isenções (o nome da rubrica deve ser claro para identificação da natureza dos valores)");
            // Demandas Judiciais:
            Add("81", "81 - Depósito judicial");
            Add("82", "82 - Compensação judicial do ano calendário");
            Add("83", "83 - Compensação judicial de anos anteriores");
            // Exigibilidade suspensa - rendimento tributável (BC IR)
            Add("91", "91 - Suspensão Remuneração mensal");
            Add("92", "92 - Suspensão 13o Salário");
            Add("93", "93 - Suspensão Férias");
            Add("94", "94 - Suspensão PLR");
            Add("95", "95 - Suspensão RRA");
            Add("9011", "9011 - Remuneração Mensal");
            Add("9012", "9012 - 13º Salário");
            Add("9013", "9013 - Férias");
            Add("9014", "9014 - PLR");
            Add("9043", "9043 - PSO - Férias");
            Add("9046", "9046 - Previdência Privada - Salário mensal");
            Add("9047", "9047 - Previdência Privada - 13º salário");
            Add("9048", "9048 - Previdência Privada - Férias");
            Add("9051", "9051 - Pensão Alimentícia - Remuneração mensal");
            Add("9052", "9052 - Pensão Alimentícia - 13º salário");
            Add("9053", "9053 - Pensão Alimentícia - Férias");
            Add("9054", "9046 - Pensão Alimentícia - PLR");
            Add("9061", "9061 - Fundo de Aposentadoria Programada Individual - FAPI - Remuneração mensal");
            Add("9062", "9062 - Fundo de Aposentadoria Programada Individual - FAPI - 13º salário");
            Add("9063", "9063 - Fundação de Previdência Complementar do Servidor Público - Remuneração mensal");
            Add("9064", "9064 - Fundação de Previdência Complementar do Servidor Público - 13º salário");
            Add("9065", "9065 - Fundação de Previdência Complementar do Servidor Público - Férias");
            Add("9066", "9066 - Fundo de Aposentadoria Programada Individual - FAPI - Férias");
            Add("9067", "9067 - Plano privado coletivo de assistência à saúde");
            // Compensação Judicial
            Add("9082", "9082 - Compensação judicial do ano-calendário");
            Add("9083", "9083 - Compensação judicial de anos anteriores");
        }
    }

    public class IndicadoresFGTS : Dictionary<string, string>
    {
        public static object Instance
        {
            get
            {
                return new IndicadoresFGTS();
            }
        }

        public IndicadoresFGTS()
        {
            Add("00", "00 - Não é Base de Cálculo do FGTS");
            Add("11", "11 - Base de Cálculo do FGTS");
            Add("12", "12 - Base de Cálculo do FGTS 13° salário");
            Add("21", "21 - Base de Cálculo do FGTS Rescisório (aviso prévio)");
            Add("91", "91 - Incidência suspensa em decorrência de decisão judicial");
            // Me.Add("92", "92 - Incidência suspensa em decorrência de decisão judicial")
            // Me.Add("93", "93 - Incidência suspensa em decorrência de decisão judicial")
        }
    }

    public class IndicadoresRPPSMilitar : Dictionary<string, string>
    {
        public static object Instance
        {
            get
            {
                return new IndicadoresRPPSMilitar();
            }
        }

        public IndicadoresRPPSMilitar()
        {
            Add("00", "00 - Não é Base de Cálculo de contribuições devidas ao RPPS/Regime Militar");
            Add("11", "11 - Base de Cálculo de contribuições devidas ao RPPS/Regime Militar");
            Add("12", "12 - Base de Cálculo de contribuições devidas ao RPPS/Regime Militar - 13° salário");
            Add("31", "31 - Contribuição Descontada do segurado e beneficiário");
            Add("32", "32 - Contribuição Descontada do segurado e beneficiário - 13° salário");
            Add("91", "91 - Suspensão de incidência em decorrência de decisão judicial");
        }
    }

    public class IndicadoresContrSindical : Dictionary<string, string>
    {
        public static object Instance
        {
            get
            {
                return new IndicadoresContrSindical();
            }
        }

        public IndicadoresContrSindical()
        {
            Add("00", "00 - Não é base de cálculo");
            Add("11", "11 - Base de cálculo");
            Add("31", "31 - Valor da contribuição sindical laboral descontada");
            Add("91", "91 - Incidência suspensa em decorrência de decisão judicial");
        }
    }
}