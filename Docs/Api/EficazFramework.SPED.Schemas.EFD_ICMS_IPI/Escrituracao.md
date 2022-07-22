#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Escrituracao Class

Classe principal de configuração, leitura e escrita da EFD ICMS / IPI.

### Remarks
Blocos disponíveis: 0, B, C, D, E, H, K, 1, 9. <br/>  
Bloco Totalizador: 9 <br/>  
Registro Totalizador: 9900 <br/>

| Methods | |
| :--- | :--- |
| [LeEmpresaArquivo(Stream)](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Escrituracao/LeEmpresaArquivo(Stream).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao.LeEmpresaArquivo(System.IO.Stream)') | Obtém o CNPJ do [Registro0000](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0000.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000') do escrituração fornecida no parâmetro [stream](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Escrituracao/LeEmpresaArquivo(Stream).md#EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao.LeEmpresaArquivo(System.IO.Stream).stream 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao.LeEmpresaArquivo(System.IO.Stream).stream') |
| [PrefixoBlocoEncerramento()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Escrituracao/PrefixoBlocoEncerramento().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao.PrefixoBlocoEncerramento()') | Gera o [Registro9001](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro9001.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9001') da Escrituração, analisando os blocos C, D, E e H para preencher corretamente o campo [IndicadorMovimento](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro9001.md#EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9001.IndicadorMovimento 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9001.IndicadorMovimento')<br/> |
| [ProcessaLinha(string)](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Escrituracao/ProcessaLinha(string).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao.ProcessaLinha(string)') | |
| [SufixoBlocoEncerramento()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Escrituracao/SufixoBlocoEncerramento().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao.SufixoBlocoEncerramento()') | Gera uma lista de [Registro9900](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro9900.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro9900') totalizando todos os registros do arquivo. |

### Example
#### Leitura  
```csharp  
System.IO.Stream stream = System.IO.File.OpenRead(@"C:\SPED\SPED-EFD-ICMS-IPI.txt");  
var escrituracao = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao();  
escrituracao.Encoding = System.Text.Encoding.Default; //opcional  
await escrituracao.LeArquivo(stream);  
```  
#### Escrita  
```csharp  
EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = new();  
escrituracao.Encoding = System.Text.Encoding.Default; //opcional  
escrituracao.Versao = "017"; //opcional  
var reg0000 = new Registro0000(null, escrituracao.Versao)  
{  
    Finalidade = Primitives.Finalidade.Original,  
    DataInicial = new System.DateTime(2022, 7, 1),  
    DataFinal = new System.DateTime(2022, 7, 31),  
    RazaoSocial = "Empresa Exemplo S/A",  
    CNPJ = "00123456000100",  
    UF = "MG",  
    InscricaoEstadual = "00112345600001",  
    MunicipioCodigo = "3129707",  
    Perfil = Perfil.B,  
    Atividade = Primitives.TipoAtividade.Outros  
};  
escrituracao.Blocos["0"].Registros.Add(reg0000);  
// TODO: Adicionar demais registros em seus respectivos blocos...  
await escrituracao.EscreveArquivo(System.IO.File.Create(@"C:\SPED\SPED-EFD-ICMS-IPI.txt"));  
```