#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Registro0030 Class

Dados Cadastrais

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - 1:1
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Endereco | `String` | Endereço da Pessoa Física |
| Numero | `String` | Número |
| Complemento | `String` | Complemento |
| Bairro | `String` | Bairro / Distrito |
| UF | `String` | Unidade Federativa (http://sped.rfb.gov.br/pasta/show/1932) |
| CodigoMunicipio | `String` | Código do Município (http://sped.rfb.gov.br/pasta/show/1932) |
| CEP | `String` | Código de Endereçamento Postal |
| Telefone | `String` | DDD + Número de Telefone |
| EMail | `String` | Correio eletrônico |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/Registro0030/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.Registro0030.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/Registro0030/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.Registro0030.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/Registro0030/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.Registro0030.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.Registro0030.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var reg0030 = new Registro0030(null, _versao)  
{  
    Endereco = "Rua Teste",  
    Numero = 1234,  
    Complemento = "Bloco Z",  
    Bairro = "Centro",  
    UF = "MG",  
    CodigoMunicipio = "3129707",  
    CEP = "37990000",  
    Telefone = "3535441234",  
    EMail = "teste@eficazcs.com.br"  
};  
```