#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.NFe](EficazFramework.SPED.Services.NFe.md 'EficazFramework.SPED.Services.NFe').[NFeService](EficazFramework.SPED.Services.NFe/NFeService.md 'EficazFramework.SPED.Services.NFe.NFeService')

## NFeService.InutilizaAsync(string, OrgaoIBGE, long[], int, string, ModeloDocumento, Ambiente) Method

Efetua a inutilização de uma faixa de numeração de NF-e / NFC-e.

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.NFe.InutilizacaoRetorno> InutilizaAsync(string cnpj, EficazFramework.SPED.Schemas.NFe.OrgaoIBGE uf, long[] numeracao, int serie, string justificativa, EficazFramework.SPED.Schemas.NFe.ModeloDocumento modelo=EficazFramework.SPED.Schemas.NFe.ModeloDocumento.NFe, EficazFramework.SPED.Schemas.NFe.Ambiente ambiente=EficazFramework.SPED.Schemas.NFe.Ambiente.Producao);
```
#### Parameters

<a name='EficazFramework.SPED.Services.NFe.NFeService.InutilizaAsync(string,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,long[],int,string,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).cnpj'></a>

`cnpj` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

CNPJ do emitente

<a name='EficazFramework.SPED.Services.NFe.NFeService.InutilizaAsync(string,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,long[],int,string,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).uf'></a>

`uf` [OrgaoIBGE](EficazFramework.SPED.Schemas.NFe/OrgaoIBGE.md 'EficazFramework.SPED.Schemas.NFe.OrgaoIBGE')

UF do emitente

<a name='EficazFramework.SPED.Services.NFe.NFeService.InutilizaAsync(string,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,long[],int,string,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).numeracao'></a>

`numeracao` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='EficazFramework.SPED.Services.NFe.NFeService.InutilizaAsync(string,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,long[],int,string,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).serie'></a>

`serie` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

55 para NF-e ou 65 para NFC-e

<a name='EficazFramework.SPED.Services.NFe.NFeService.InutilizaAsync(string,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,long[],int,string,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).justificativa'></a>

`justificativa` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Services.NFe.NFeService.InutilizaAsync(string,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,long[],int,string,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).modelo'></a>

`modelo` [ModeloDocumento](EficazFramework.SPED.Schemas.NFe/ModeloDocumento.md 'EficazFramework.SPED.Schemas.NFe.ModeloDocumento')

55 para NF-e ou 65 para NFC-e

<a name='EficazFramework.SPED.Services.NFe.NFeService.InutilizaAsync(string,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,long[],int,string,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.NFe/Ambiente.md 'EficazFramework.SPED.Schemas.NFe.Ambiente')

Produção ou Homologação

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[InutilizacaoRetorno](EficazFramework.SPED.Schemas.NFe/InutilizacaoRetorno.md 'EficazFramework.SPED.Schemas.NFe.InutilizacaoRetorno')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')