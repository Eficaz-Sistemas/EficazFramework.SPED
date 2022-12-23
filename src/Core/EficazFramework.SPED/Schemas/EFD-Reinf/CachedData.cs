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