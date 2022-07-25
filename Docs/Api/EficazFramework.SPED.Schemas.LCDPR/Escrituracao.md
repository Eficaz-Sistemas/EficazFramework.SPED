#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Escrituracao Class

Classe principal de configuração, leitura e escrita do Livro Caixa Digital do Produtor Rural

### Remarks
Blocos disponíveis: 0, Q <br/>  
Bloco Totalizador: Não se aplica <br/>  
Registro Totalizador: Não se aplica <br/>

| Methods | |
| :--- | :--- |
| [LeEmpresaArquivo(Stream)](EficazFramework.SPED.Schemas.LCDPR/Escrituracao/LeEmpresaArquivo(Stream).md 'EficazFramework.SPED.Schemas.LCDPR.Escrituracao.LeEmpresaArquivo(System.IO.Stream)') | Obtém o valor do campo CPF do [Registro0000](EficazFramework.SPED.Schemas.LCDPR/Registro0000.md 'EficazFramework.SPED.Schemas.LCDPR.Registro0000') do escrituração fornecida no parâmetro [stream](EficazFramework.SPED.Schemas.LCDPR/Escrituracao/LeEmpresaArquivo(Stream).md#EficazFramework.SPED.Schemas.LCDPR.Escrituracao.LeEmpresaArquivo(System.IO.Stream).stream 'EficazFramework.SPED.Schemas.LCDPR.Escrituracao.LeEmpresaArquivo(System.IO.Stream).stream') |

### Example
#### Leitura  
```csharp  
System.IO.Stream stream = System.IO.File.OpenRead(@"C:\LCDPR\exemplo.txt");  
var escrituracao = new EficazFramework.SPED.Schemas.LCDPR.Escrituracao();  
escrituracao.Encoding = System.Text.Encoding.Default; //opcional  
await escrituracao.LeArquivo(stream);  
```  
#### Escrita  
```csharp  
EficazFramework.SPED.Schemas.LCDPR.Escrituracao escrituracao = new();  
escrituracao.Encoding = System.Text.Encoding.Default; //opcional  
escrituracao.Versao = "0013"; //opcional  
var reg0000 = new Registro0000(null, escrituracao.Versao)  
{  
    SituacaoEspecial = SituacaoEspecial.Normal,  
    DataInicial = new System.DateTime(2021, 1, 1),  
    DataFinal = new System.DateTime(2021, 12, 31),  
    Nome = "Produtor Rural Exemplo",  
    CPF = "12345678900"  
};  
escrituracao.Blocos["0"].Registros.Add(reg0000);  
// TODO: Adicionar demais registros em seus respectivos blocos...  
await escrituracao.EscreveArquivo(System.IO.File.Create(@"C:\LCDPR\exemplo.txt"));  
```