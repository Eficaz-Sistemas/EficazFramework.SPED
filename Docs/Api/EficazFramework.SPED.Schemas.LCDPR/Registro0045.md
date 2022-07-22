#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Registro0045 Class

Cadastro de Terceiros

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - 1:N
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Imovel | `Nullable<Int32>` | Código do Imóvel (<see cref="P:EficazFramework.SPED.Schemas.LCDPR.Registro0040.IDImovel"/>) |
| TipoContratante | `TipoExploracaoTerceiro` | Tipo de terceiro relacionado ao imóvel: <br/>            1 - Condômino <br/>            2 - Arrendador <br/>            3 - Parceiro <br/>            4 - Comodante <br/>            5 - Outro <br/> |
| CPF | `String` | CNPJ ou CPF do Terceiro que explora em conjunto ou do arrendador / comodante do Imóvel Rural |
| Nome | `String` | Nome do Terceiro que explora em conjunto ou do arrendador / comodante do Imóvel Rural |
| Percentual | `Nullable<Double>` | Percentual do Terceiro que explora em conjunto ou do arrendador / comodante do Imóvel Rural |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/Registro0045/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.Registro0045.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/Registro0045/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.Registro0045.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/Registro0045/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.Registro0045.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.Registro0045.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var reg0045 = new Registro0045(null, _versao)  
{  
    Imovel = 1,  
    TipoContratante = TipoExploracaoTerceiro.Condomino,  
    CPF = "12345678912",  
    Nome = "Condomino da Silva",  
    Percentual = 5.2 // 5,2%,  
};  
```