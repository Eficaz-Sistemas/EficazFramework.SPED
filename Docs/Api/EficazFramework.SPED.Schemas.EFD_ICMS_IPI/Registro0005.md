#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0005 Class

Dados Complementares da entidade

### Remarks
Nível hierárquico - 1 <br/>  
Ocorrência - um por arquivo.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| NomeFantasia | `String` | Nome Fantasia assossiado ao nome empresarial |
| CEP | `String` | Código de Enderaçamento Postal |
| Endereco | `String` | Logradouro e Endereço do imóvel |
| Numero | `String` | Número do Imóvel |
| Complemento | `String` | Dados complementares do endereço |
| Bairro | `String` | Bairro em que o imóvel está situado |
| Fone | `String` | Número do telefone (ddd+fone) |
| Fax | `String` | Número do fax |
| EMail | `String` | Endereço de correio eletrônico |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0005/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0005/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0005/LeParametros(string[]).md#EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0005.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "017";  
var reg0005 = new Registro0005(null, _versao)  
{  
    NomeFantasia = "Nome Fantasia Comércio de Artigos Diversos",  
    CEP = "37990000",  
    Endereco = "Rua Exemplo",  
    Numero = "88",  
    Bairro = "Centro",  
    EMail = "contato@artdiversos.com.br"  
};  
```