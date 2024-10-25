#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.EFD_Reinf](EficazFramework.SPED.Services.EFD_Reinf.md 'EficazFramework.SPED.Services.EFD_Reinf').[EfdReinfServices](EficazFramework.SPED.Services.EFD_Reinf/EfdReinfServices.md 'EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices')

## EfdReinfServices.ConsultaLoteAsync(string, Ambiente, VersaoRest) Method

Efetua a requisição à API REST consulta/lotes da EFD-REINF para consulta de processamento de lote enviado

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Services.EFD_Reinf.Response> ConsultaLoteAsync(string protocolo, EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente ambiente=EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente.Producao, EficazFramework.SPED.Services.EFD_Reinf.VersaoRest versao=EficazFramework.SPED.Services.EFD_Reinf.VersaoRest.v1_00_00);
```
#### Parameters

<a name='EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices.ConsultaLoteAsync(string,EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente,EficazFramework.SPED.Services.EFD_Reinf.VersaoRest).protocolo'></a>

`protocolo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Número do protocolo para consulta

<a name='EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices.ConsultaLoteAsync(string,EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente,EficazFramework.SPED.Services.EFD_Reinf.VersaoRest).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.EFD_Reinf/Ambiente.md 'EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente')

Ambiente de Produção ou Testes

<a name='EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices.ConsultaLoteAsync(string,EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente,EficazFramework.SPED.Services.EFD_Reinf.VersaoRest).versao'></a>

`versao` [VersaoRest](EficazFramework.SPED.Services.EFD_Reinf/VersaoRest.md 'EficazFramework.SPED.Services.EFD_Reinf.VersaoRest')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Response](EficazFramework.SPED.Services.EFD_Reinf/Response.md 'EficazFramework.SPED.Services.EFD_Reinf.Response')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')