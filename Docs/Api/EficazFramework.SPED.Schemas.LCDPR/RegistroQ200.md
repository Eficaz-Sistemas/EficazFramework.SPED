#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## RegistroQ200 Class

Resumo Mensal do Demonstrativo do Resultado da Atividade Rural

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - 0:N  <br/>  
O campo [SaldoFinal](EficazFramework.SPED.Schemas.LCDPR/RegistroQ200.md#EficazFramework.SPED.Schemas.LCDPR.RegistroQ200.SaldoFinal 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ200.SaldoFinal') registra o saldo cumulativo até o mês, ou seja,   
registra o saldo dos lançamentos do mês acrescido do saldo final do mês   
imediatamente anterior da declaração.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Competencia | `Nullable<DateTime>` | Mês e ano da Entrada ou Saída de Recursos (MMAAAA) |
| ValorEntrada | `Nullable<Double>` | Valor Total da Entrada Recursos no mês (P) |
| ValorSaida | `Nullable<Double>` | Valor Total da Saída de Recursos no mês (N) |
| SaldoFinal | `Nullable<Double>` | Saldo Final até o mês (P / N) |
| SaldoFinal_Natureza | `String` | Natureza do Saldo Final do mês [N/P] |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/RegistroQ200/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ200.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/RegistroQ200/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ200.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/RegistroQ200/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.RegistroQ200.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ200.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var regQ200 = new RegistroQ200(null, _versao)  
{  
    Competencia = new System.DateTime(2021, 1, 1),  
    ValorEntrada = 1500d,  
    ValorSaida = 250d,  
    SaldoFinal = 1250d,  
    SaldoFinal_Natureza = "P"  
};  
```