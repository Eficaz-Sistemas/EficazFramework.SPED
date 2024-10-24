#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.EFD_Reinf](EficazFramework.SPED.Services.EFD_Reinf.md 'EficazFramework.SPED.Services.EFD_Reinf').[EfdReinfServices](EficazFramework.SPED.Services.EFD_Reinf/EfdReinfServices.md 'EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices')

## EfdReinfServices.EnviaEventosAsync(IList<Evento>, IdentificacaoContribuinte, Ambiente, VersaoRest) Method

Efetua a requisição à API REST recepcao/lotes da EFD-REINF para transmissão do lote de eventos

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Services.EFD_Reinf.Response> EnviaEventosAsync(System.Collections.Generic.IList<EficazFramework.SPED.Schemas.EFD_Reinf.Evento> eventos, EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte contribuinte, EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente ambiente=EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente.Producao, EficazFramework.SPED.Services.EFD_Reinf.VersaoRest versao=EficazFramework.SPED.Services.EFD_Reinf.VersaoRest.v1_00_00);
```
#### Parameters

<a name='EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices.EnviaEventosAsync(System.Collections.Generic.IList_EficazFramework.SPED.Schemas.EFD_Reinf.Evento_,EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte,EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente,EficazFramework.SPED.Services.EFD_Reinf.VersaoRest).eventos'></a>

`eventos` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[Evento](EficazFramework.SPED.Schemas.EFD_Reinf/Evento.md 'EficazFramework.SPED.Schemas.EFD_Reinf.Evento')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

Lote de Eventos a serem transmitidos. Respeitar o limite de 50 eventos por lote

<a name='EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices.EnviaEventosAsync(System.Collections.Generic.IList_EficazFramework.SPED.Schemas.EFD_Reinf.Evento_,EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte,EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente,EficazFramework.SPED.Services.EFD_Reinf.VersaoRest).contribuinte'></a>

`contribuinte` [EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte 'EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte')

Identificação do Contribuinte

<a name='EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices.EnviaEventosAsync(System.Collections.Generic.IList_EficazFramework.SPED.Schemas.EFD_Reinf.Evento_,EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte,EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente,EficazFramework.SPED.Services.EFD_Reinf.VersaoRest).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.EFD_Reinf/Ambiente.md 'EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente')

Ambiente de Produção ou Testes

<a name='EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices.EnviaEventosAsync(System.Collections.Generic.IList_EficazFramework.SPED.Schemas.EFD_Reinf.Evento_,EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte,EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente,EficazFramework.SPED.Services.EFD_Reinf.VersaoRest).versao'></a>

`versao` [VersaoRest](EficazFramework.SPED.Services.EFD_Reinf/VersaoRest.md 'EficazFramework.SPED.Services.EFD_Reinf.VersaoRest')

Versão do Serviço REST

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Response](EficazFramework.SPED.Services.EFD_Reinf/Response.md 'EficazFramework.SPED.Services.EFD_Reinf.Response')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')