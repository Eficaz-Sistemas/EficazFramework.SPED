#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.CTe](EficazFramework.SPED.Services.CTe.md 'EficazFramework.SPED.Services.CTe').[CTeService](EficazFramework.SPED.Services.CTe/CTeService.md 'EficazFramework.SPED.Services.CTe.CTeService')

## CTeService.ConsultaSituacaoAsync(string, Ambiente) Method

Efetua a consulta de protocolo de CT-e / CT-eOS

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.CTe.RetornoConsultaSituacaoCTe> ConsultaSituacaoAsync(string chave, EficazFramework.SPED.Schemas.NFe.Ambiente ambiente=EficazFramework.SPED.Schemas.NFe.Ambiente.Producao);
```
#### Parameters

<a name='EficazFramework.SPED.Services.CTe.CTeService.ConsultaSituacaoAsync(string,EficazFramework.SPED.Schemas.NFe.Ambiente).chave'></a>

`chave` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Chave da CT-e ou CT-eOS para consulta

<a name='EficazFramework.SPED.Services.CTe.CTeService.ConsultaSituacaoAsync(string,EficazFramework.SPED.Schemas.NFe.Ambiente).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.NFe/Ambiente.md 'EficazFramework.SPED.Schemas.NFe.Ambiente')

Produção ou Homologação

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[RetornoConsultaSituacaoCTe](EficazFramework.SPED.Schemas.CTe/RetornoConsultaSituacaoCTe.md 'EficazFramework.SPED.Schemas.CTe.RetornoConsultaSituacaoCTe')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')