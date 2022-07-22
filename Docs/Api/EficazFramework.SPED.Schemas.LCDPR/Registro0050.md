#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Registro0050 Class

Cadastro das Contas Bancárias do Produtor Rural

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - 1:N
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| CodigoContaBanco | `Nullable<Int32>` | ID (código) da Conta Bancária |
| Pais | `String` | Código do País em que a conta bancária é mantida. (http://sped.rfb.gov.br/pasta/show/1932) |
| NumeroInstBancaria | `String` | Código a instituição bancária |
| Nome | `String` | Nome da Instituição Financeira |
| Agencia | `String` | Número da Agência (sem dígito verificador) |
| NumeroCC | `String` | Número da Conta Corrente (com dígito verificador) |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/Registro0050/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.Registro0050.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/Registro0050/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.Registro0050.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/Registro0050/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.Registro0050.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.Registro0050.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var reg0050 = new Registro0050(null, _versao)  
{  
    CodigoContaBanco = 1,  
    Pais = "BR",  
    NumeroInstBancaria = "756",  
    Nome = "Banco LCDPR",  
    Agencia = "0001",  
    NumeroCC = "123456",  
};  
```