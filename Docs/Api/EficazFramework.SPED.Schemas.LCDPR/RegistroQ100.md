#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## RegistroQ100 Class

Demonstração da Atividade Rural

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - 0:N
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| DataMov | `Nullable<DateTime>` | Data de Entrada ou Saída dos Recursos |
| CodImovel | `Nullable<Int32>` | Código do Imóvel em <see cref="P:EficazFramework.SPED.Schemas.LCDPR.Registro0040.IDImovel"/> |
| CodigoContaBanco | `String` | Código da Conta Bancária em <see cref="P:EficazFramework.SPED.Schemas.LCDPR.Registro0050.CodigoContaBanco"/><br/>            Para pagamentos ou recebimentos em espécie, utilizar 000. <br/>            Para numerários em trânsito, utilizar 999. |
| NumeroDoc | `String` | Número do Documento |
| TipoDocumento | `TipoDocumento` | Tipo de Documento: <br/>            1 - Nota Fiscal <br/>            2 – Fatura <br/>            3 – Recibo <br/>            4 – Contrato <br/>            5 - Folha de Pagamento <br/>            6 - Outros |
| Historico | `String` | Histórico do Lançamento |
| TerceiroID | `String` | CPF ou CNPJ do Terceiro. <br/>            Caso <see cref="P:EficazFramework.SPED.Schemas.LCDPR.RegistroQ100.TipoDocumento"/> = <see cref="F:EficazFramework.SPED.Schemas.LCDPR.TipoDocumento.FolhaPagto"/>,            utilizar o CPF do próprio declarante. |
| TipoLancamento | `TipoLancamento` | Tipo de Lançamento; <br/>            1 - Receita da Atividade Rural <br/>            2 - Despesas de custeio e investimentos <br/>            3 – Receita de produtos entregues no ano referente a adiantamento de recursos financeiro |
| ValorEntrada | `Nullable<Double>` | Valor de Entrada dos Recursos |
| ValorSaida | `Nullable<Double>` | Valor de Saída dos Recursos |
| SaldoFinal | `Nullable<Double>` | Saldo Final |
| SaldoFinal_Natureza | `String` | Natureza do Saldo Final [N/P] |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/RegistroQ100/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ100.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/RegistroQ100/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ100.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/RegistroQ100/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.RegistroQ100.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ100.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var regQ100 = new RegistroQ100(null, _versao)  
{  
    DataMov = new System.DateTime(2021, 1, 1),  
    CodImovel = 1,  
    CodigoContaBanco = 1,  
    NumeroDoc = "123456",  
    TipoDocumento = TipoDocumento.NF,  
    Historico = "Pg. ref. aquisição de fertilizantes",  
    TerceiroID = "12345678900",  
    TipoLancamento = TipoLancamento.Despesa,  
    ValorSaida = 500d,  
    SaldoFinal = 500d,  
    SaldoFinal_Natureza = "N"  
};  
```