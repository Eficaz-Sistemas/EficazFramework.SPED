#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Registro9999 Class

Identificação do Signatário do LCDPR e Encerramento do Arquivo Digital

### Remarks
Nível hierárquico - 1 <br/>  
Ocorrência - 1:1
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Nome | `String` | Nome do Contador |
| CPF | `String` | CNPJ / CPF do Contador |
| CRC | `String` | Número de Inscrição do Contador no Conselho Regional de Contabilidade |
| eMail | `String` | Correio eletrônico do Contador |
| Fone | `String` | DDD + Telefone do Contador |
| QuantidadeLinhas | `Int32` | Quantidade Total de Registros do arquivo |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/Registro9999/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.Registro9999.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/Registro9999/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.Registro9999.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/Registro9999/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.Registro9999.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.Registro9999.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var reg9999 = new Registro9999(null, _versao)  
{  
    Nome = "Contador ABC",  
    CPF = "12345678900",  
    CRC = "123456/O/MG",  
    eMail = "teste@eficazcs.com.br"  
    Fone = "3535441234",  
    ValorSaida = 500d,  
    SaldoFinal = 500d,  
    QuantidadeLinhas = 9999999  
};  
```