#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.NFe](EficazFramework.SPED.Services.NFe.md 'EficazFramework.SPED.Services.NFe').[NFeService](EficazFramework.SPED.Services.NFe/NFeService.md 'EficazFramework.SPED.Services.NFe.NFeService')

## NFeService.DistribuicaoDFeAsync(OrgaoIBGE, string, int, Ambiente, string) Method

Executa o serviço de distribuição de DF-e e visa retornar as informações sobre NF-e dos últimos 90 dias. <br/>  
Pode incluir: NF-e completa, resumo de NF-e e/ou eventos da NF-e.

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.NFe.RetornoDistribuicaoDFe> DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE uf, string cnpjCpf, int ultimoNsu=0, EficazFramework.SPED.Schemas.NFe.Ambiente ambiente=EficazFramework.SPED.Schemas.NFe.Ambiente.Producao, string chave=null);
```
#### Parameters

<a name='EficazFramework.SPED.Services.NFe.NFeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente,string).uf'></a>

`uf` [OrgaoIBGE](EficazFramework.SPED.Schemas.NFe/OrgaoIBGE.md 'EficazFramework.SPED.Schemas.NFe.OrgaoIBGE')

Utilizar a UF do destinatário até que se conheça a real aplicação deste parâmetro

<a name='EficazFramework.SPED.Services.NFe.NFeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente,string).cnpjCpf'></a>

`cnpjCpf` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

CNPJ ou CPF do interessado pela busca

<a name='EficazFramework.SPED.Services.NFe.NFeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente,string).ultimoNsu'></a>

`ultimoNsu` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

NSU para início das buscas, ou 0 para mais antigo possível

<a name='EficazFramework.SPED.Services.NFe.NFeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente,string).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.NFe/Ambiente.md 'EficazFramework.SPED.Schemas.NFe.Ambiente')

<a name='EficazFramework.SPED.Services.NFe.NFeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente,string).chave'></a>

`chave` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Pesquisar por uma chave em particular

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[RetornoDistribuicaoDFe](EficazFramework.SPED.Schemas.NFe/RetornoDistribuicaoDFe.md 'EficazFramework.SPED.Schemas.NFe.RetornoDistribuicaoDFe')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')