#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Registro0010 Class

Parâmetros de Tributação

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - 1:1
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| FormaApuracao | `FormaApuracao` | Forma de Apuração:            1 – Livro Caixa (Resutlado com base nos lançamentos da LCDPR. <br/>            2 – Apuração do lucro pelo disposto no art. 5º da Lei nº 8.023, de 1990 (20% da Receita Bruta). |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/Registro0010/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.Registro0010.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/Registro0010/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.Registro0010.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/Registro0010/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.Registro0010.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.Registro0010.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var reg0010 = new Registro0010(null, _versao)  
{  
    FormaApuracao = FormaApuracao.LivroCaixa  
};  
```