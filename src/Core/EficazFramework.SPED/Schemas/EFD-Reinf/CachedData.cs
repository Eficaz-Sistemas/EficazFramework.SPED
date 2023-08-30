namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <exclude />
public class IndicadoresIRRF : Dictionary<string, string>
{

    private static IndicadoresIRRF _instance = new();
    public static object Instance
    {
        get => _instance;
    }

    public IndicadoresIRRF()
    {
        // Retenção de IRRF:
        Add("10", "10 - Retenção de IRRF - alíquota padrão");
        Add("11", "11 - Retenção de IRRF - alíquota da tabela progressiva");
        Add("12", "12 - Retenção de IRRF - alíquota diferenciada (países com tributação favorecida)");
        Add("13", "13 - Retenção de IRRF - alíquota limitada conforme cláusula em convênio");
        Add("30", "30 - Retenção de IRRF - outras hipóteses");
        // Não Retenção de IRRF:
        Add("40", "40 - Não Retenção de IRRF - isenção estabelecida em convênio");
        Add("41", "41 - Não Retenção de IRRF - isenção prevista em lei interna");
        Add("42", "42 - Não Retenção de IRRF - alíquota zero prevista em lei interna");
        Add("43", "43 - Não Retenção de IRRF - pagamento antecipado do imposto");
        Add("44", "44 - Não Retenção de IRRF - medida Judicial");
        Add("50", "50 - Não Retenção de IRRF - outras hipóteses");
    }
}


/// <summary>
/// Tabela 6 do Anexo IV: Relação de Serviços para registros R-2010 e R-2020s
/// </summary>
/// <exclude/>
public class R2000TabelaServicos : Dictionary<string, string>
{
    public R2000TabelaServicos()
    {
        Add("--", "Não Aplicável");
        Add("100000001", "100000001 - Limpeza, conservação ou zeladoria");
        Add("100000002", "100000002 - Vigilância ou segurança");
        Add("100000003", "100000003 - Construção civil");
        Add("100000004", "100000004 - Serviços de natureza rural");
        Add("100000005", "100000005 - Digitação");
        Add("100000006", "100000006 - Preparação de dados para processamento");
        Add("100000007", "100000007 - Acabamento");
        Add("100000008", "100000008 - Embalagem");
        Add("100000009", "100000009 - Acondicionamento");
        Add("100000010", "100000010 - Cobrança");
        Add("100000011", "100000011 - Coleta ou reciclagem de lixo ou de resíduos");
        Add("100000012", "100000012 - Copa");
        Add("100000013", "100000013 - Hotelaria");
        Add("100000014", "100000014 - Corte ou ligação de serviços públicos");
        Add("100000015", "100000015 - Distribuição");
        Add("100000016", "100000016 - Treinamento e ensino");
        Add("100000017", "100000017 - Entrega de contas e de documentos");
        Add("100000018", "100000018 - Ligação de medidores");
        Add("100000019", "100000019 - Leitura de medidores");
        Add("100000020", "100000020 - Manutenção de instalações, de máquinas ou de equipamentos");
        Add("100000021", "100000021 - Montagem");
        Add("100000022", "100000022 - Operação de máquinas, de equipamentos e de veículos");
        Add("100000023", "100000023 - Operação de pedágio ou de terminal de transporte");
        Add("100000024", "100000024 - Operação de transporte de passageiros");
        Add("100000025", "100000025 - Portaria, recepção ou ascensorista");
        Add("100000026", "100000026 - Recepção, triagem ou movimentação de materiais");
        Add("100000027", "100000027 - Promoção de vendas ou de eventos");
        Add("100000028", "100000028 - Secretaria e expediente");
        Add("100000029", "100000029 - Saúde");
        Add("100000030", "100000030 - Telefonia ou telemarketing");
        Add("100000031", "100000031 - Trabalho temporário na forma da Lei nº 6.019, de janeiro de 1974");
    }
}