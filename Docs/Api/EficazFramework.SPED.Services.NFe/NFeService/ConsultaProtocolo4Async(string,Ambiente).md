#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.NFe](EficazFramework.SPED.Services.NFe.md 'EficazFramework.SPED.Services.NFe').[NFeService](EficazFramework.SPED.Services.NFe/NFeService.md 'EficazFramework.SPED.Services.NFe.NFeService')

## NFeService.ConsultaProtocolo4Async(string, Ambiente) Method

Efetua a consulta de protocolo de NF-e / NFC-e na versão 4.00

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.NFe.RetornoConsultaSituacaoNFe> ConsultaProtocolo4Async(string chave, EficazFramework.SPED.Schemas.NFe.Ambiente ambiente=EficazFramework.SPED.Schemas.NFe.Ambiente.Producao);
```
#### Parameters

<a name='EficazFramework.SPED.Services.NFe.NFeService.ConsultaProtocolo4Async(string,EficazFramework.SPED.Schemas.NFe.Ambiente).chave'></a>

`chave` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Chave da NF-e ou NFC-e para consulta

<a name='EficazFramework.SPED.Services.NFe.NFeService.ConsultaProtocolo4Async(string,EficazFramework.SPED.Schemas.NFe.Ambiente).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.NFe/Ambiente.md 'EficazFramework.SPED.Schemas.NFe.Ambiente')

Produção ou Homologação

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[RetornoConsultaSituacaoNFe](EficazFramework.SPED.Schemas.NFe/RetornoConsultaSituacaoNFe.md 'EficazFramework.SPED.Schemas.NFe.RetornoConsultaSituacaoNFe')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')