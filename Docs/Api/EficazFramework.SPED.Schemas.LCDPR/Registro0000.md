#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação da Pessoa Física

### Remarks
Nível hierárquico - 1 <br/>  
Ocorrência - 1:1
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| CPF | `String` | CPF do declarante |
| Nome | `String` | Nome da Pessoa Física |
| IndicadorSitInicioPeriodo | `SituacaoInicioPeriodo` | Indicador do Início do Período: <br/>            0 – Regular(Início no primeiro dia do ano). <br/>            1 – Abertura(Início de atividades no ano-calendário). <br/>            2 – Início de obrigatoriedade da escrituração no curso do ano calendário.            (Exemplo: desenquadramento como isento do IRPF) |
| SituacaoEspecial | `SituacaoEspecial` | Indicador de Situação Especial e Outros Eventos:  <br/>            0 – Normal;  <br/>            1 – Falecimento; <br/>            2 - Espólio; <br/>            3 - Saída definitiva do País; |
| DataSituacaoEspecial | `Nullable<DateTime>` | Data da Situação Especial |
| DataInicial | `Nullable<DateTime>` | Data do Início do Período <br/>            Em caso de falecimento da Pessoa Física, a data de falecimento. |
| DataFinal | `Nullable<DateTime>` | Data do Final do Período |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/Registro0000/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.Registro0000.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/Registro0000/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.Registro0000.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/Registro0000/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.Registro0000.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.Registro0000.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var reg0000 = new Registro0000(null, _versao)  
{  
    SituacaoEspecial = SituacaoEspecial.Normal,  
    DataInicial = new System.DateTime(2021, 1, 1),  
    DataFinal = new System.DateTime(2021, 12, 31),  
    Nome = "Produtor Rural Exemplo",  
    CPF = "12345678900"  
};  
```