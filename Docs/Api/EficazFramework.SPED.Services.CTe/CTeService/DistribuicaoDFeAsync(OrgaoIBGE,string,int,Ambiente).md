#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.CTe](EficazFramework.SPED.Services.CTe.md 'EficazFramework.SPED.Services.CTe').[CTeService](EficazFramework.SPED.Services.CTe/CTeService.md 'EficazFramework.SPED.Services.CTe.CTeService')

## CTeService.DistribuicaoDFeAsync(OrgaoIBGE, string, int, Ambiente) Method

Executa o serviço de distribuição de DF-e e visa retornar as informações sobre CT-e dos últimos 90 dias. <br/>  
Pode incluir: CT-e completo, resumo de CT-e e/ou eventos do CT-e.

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe> DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE uf, string cnpjCpf, int ultimoNsu=0, EficazFramework.SPED.Schemas.NFe.Ambiente ambiente=EficazFramework.SPED.Schemas.NFe.Ambiente.Producao);
```
#### Parameters

<a name='EficazFramework.SPED.Services.CTe.CTeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente).uf'></a>

`uf` [OrgaoIBGE](EficazFramework.SPED.Schemas.NFe/OrgaoIBGE.md 'EficazFramework.SPED.Schemas.NFe.OrgaoIBGE')

Utilizar a UF do destinatário até que se conheça a real aplicação deste parâmetro

<a name='EficazFramework.SPED.Services.CTe.CTeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente).cnpjCpf'></a>

`cnpjCpf` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

CNPJ ou CPF do interessado pela busca

<a name='EficazFramework.SPED.Services.CTe.CTeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente).ultimoNsu'></a>

`ultimoNsu` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

NSU para início das buscas, ou 0 para mais antigo possível

<a name='EficazFramework.SPED.Services.CTe.CTeService.DistribuicaoDFeAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,string,int,EficazFramework.SPED.Schemas.NFe.Ambiente).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.NFe/Ambiente.md 'EficazFramework.SPED.Schemas.NFe.Ambiente')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[RetornoDistribuicaoDFe](EficazFramework.SPED.Schemas.CTe/RetornoDistribuicaoDFe.md 'EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')