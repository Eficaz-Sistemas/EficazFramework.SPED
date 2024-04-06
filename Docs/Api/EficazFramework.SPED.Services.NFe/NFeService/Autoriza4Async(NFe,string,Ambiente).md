#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.NFe](EficazFramework.SPED.Services.NFe.md 'EficazFramework.SPED.Services.NFe').[NFeService](EficazFramework.SPED.Services.NFe/NFeService.md 'EficazFramework.SPED.Services.NFe.NFeService')

## NFeService.Autoriza4Async(NFe, string, Ambiente) Method

Efetua a transmissão de NF-e / NFC-e na versão 4.00 para autorização.  
NOTA: No nomento, opera apenas no modelo síncroni, com um único documento por lote

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.NFe.RetornoAutorizacaoNFe> Autoriza4Async(EficazFramework.SPED.Schemas.NFe.NFe nfe, string identificadorLote, EficazFramework.SPED.Schemas.NFe.Ambiente ambiente=EficazFramework.SPED.Schemas.NFe.Ambiente.Producao);
```
#### Parameters

<a name='EficazFramework.SPED.Services.NFe.NFeService.Autoriza4Async(EficazFramework.SPED.Schemas.NFe.NFe,string,EficazFramework.SPED.Schemas.NFe.Ambiente).nfe'></a>

`nfe` [NFe](EficazFramework.SPED.Schemas.NFe/NFe.md 'EficazFramework.SPED.Schemas.NFe.NFe')

<a name='EficazFramework.SPED.Services.NFe.NFeService.Autoriza4Async(EficazFramework.SPED.Schemas.NFe.NFe,string,EficazFramework.SPED.Schemas.NFe.Ambiente).identificadorLote'></a>

`identificadorLote` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Services.NFe.NFeService.Autoriza4Async(EficazFramework.SPED.Schemas.NFe.NFe,string,EficazFramework.SPED.Schemas.NFe.Ambiente).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.NFe/Ambiente.md 'EficazFramework.SPED.Schemas.NFe.Ambiente')

Produção ou Homologação

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[RetornoAutorizacaoNFe](EficazFramework.SPED.Schemas.NFe/RetornoAutorizacaoNFe.md 'EficazFramework.SPED.Schemas.NFe.RetornoAutorizacaoNFe')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')