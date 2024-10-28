#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.NFe](EficazFramework.SPED.Services.NFe.md 'EficazFramework.SPED.Services.NFe').[NFeService](EficazFramework.SPED.Services.NFe/NFeService.md 'EficazFramework.SPED.Services.NFe.NFeService')

## NFeService.ConsultaStatusServicoAsync(OrgaoIBGE, ModeloDocumento, Ambiente) Method

Consulta a situação de funcionamento dos serviços da NF-e e NFC-e

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.NFe.RetornoConsultaStatusServicoNFe> ConsultaStatusServicoAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE uf, EficazFramework.SPED.Schemas.NFe.ModeloDocumento modelo=EficazFramework.SPED.Schemas.NFe.ModeloDocumento.NFe, EficazFramework.SPED.Schemas.NFe.Ambiente ambiente=EficazFramework.SPED.Schemas.NFe.Ambiente.Producao);
```
#### Parameters

<a name='EficazFramework.SPED.Services.NFe.NFeService.ConsultaStatusServicoAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).uf'></a>

`uf` [OrgaoIBGE](EficazFramework.SPED.Schemas.NFe/OrgaoIBGE.md 'EficazFramework.SPED.Schemas.NFe.OrgaoIBGE')

Unidade Federativa para verificação

<a name='EficazFramework.SPED.Services.NFe.NFeService.ConsultaStatusServicoAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).modelo'></a>

`modelo` [ModeloDocumento](EficazFramework.SPED.Schemas.NFe/ModeloDocumento.md 'EficazFramework.SPED.Schemas.NFe.ModeloDocumento')

55 para NF-e ou 65 para NFC-e

<a name='EficazFramework.SPED.Services.NFe.NFeService.ConsultaStatusServicoAsync(EficazFramework.SPED.Schemas.NFe.OrgaoIBGE,EficazFramework.SPED.Schemas.NFe.ModeloDocumento,EficazFramework.SPED.Schemas.NFe.Ambiente).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.NFe/Ambiente.md 'EficazFramework.SPED.Schemas.NFe.Ambiente')

Produção ou Homologação

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[RetornoConsultaStatusServicoNFe](EficazFramework.SPED.Schemas.NFe/RetornoConsultaStatusServicoNFe.md 'EficazFramework.SPED.Schemas.NFe.RetornoConsultaStatusServicoNFe')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')