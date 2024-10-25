#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.NFe](EficazFramework.SPED.Services.NFe.md 'EficazFramework.SPED.Services.NFe').[NFeService](EficazFramework.SPED.Services.NFe/NFeService.md 'EficazFramework.SPED.Services.NFe.NFeService')

## NFeService.EnvioEventoAsync(string, string, CodigoEvento, Ambiente, string) Method

Executa a chamada ao WebService de envio de eventos para uma NF-e

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento> EnvioEventoAsync(string cnpjCpf, string chave, EficazFramework.SPED.Schemas.NFe.CodigoEvento tpEvento, EficazFramework.SPED.Schemas.NFe.Ambiente ambiente=EficazFramework.SPED.Schemas.NFe.Ambiente.Producao, string justificativa=null);
```
#### Parameters

<a name='EficazFramework.SPED.Services.NFe.NFeService.EnvioEventoAsync(string,string,EficazFramework.SPED.Schemas.NFe.CodigoEvento,EficazFramework.SPED.Schemas.NFe.Ambiente,string).cnpjCpf'></a>

`cnpjCpf` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

CNPJ ou CPF do Autor do Evento

<a name='EficazFramework.SPED.Services.NFe.NFeService.EnvioEventoAsync(string,string,EficazFramework.SPED.Schemas.NFe.CodigoEvento,EficazFramework.SPED.Schemas.NFe.Ambiente,string).chave'></a>

`chave` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Informar chave da NF-e

<a name='EficazFramework.SPED.Services.NFe.NFeService.EnvioEventoAsync(string,string,EficazFramework.SPED.Schemas.NFe.CodigoEvento,EficazFramework.SPED.Schemas.NFe.Ambiente,string).tpEvento'></a>

`tpEvento` [CodigoEvento](EficazFramework.SPED.Schemas.NFe/CodigoEvento.md 'EficazFramework.SPED.Schemas.NFe.CodigoEvento')

Cancelamento, Ciência, Confirmação, Recusa, etc.

<a name='EficazFramework.SPED.Services.NFe.NFeService.EnvioEventoAsync(string,string,EficazFramework.SPED.Schemas.NFe.CodigoEvento,EficazFramework.SPED.Schemas.NFe.Ambiente,string).ambiente'></a>

`ambiente` [Ambiente](EficazFramework.SPED.Schemas.NFe/Ambiente.md 'EficazFramework.SPED.Schemas.NFe.Ambiente')

<a name='EficazFramework.SPED.Services.NFe.NFeService.EnvioEventoAsync(string,string,EficazFramework.SPED.Schemas.NFe.CodigoEvento,EficazFramework.SPED.Schemas.NFe.Ambiente,string).justificativa'></a>

`justificativa` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Utilize este parâmetro para eventos de Cancelamento, Operação Não Realizada, etc

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[RetornoEnvioEvento](EficazFramework.SPED.Schemas.NFe/RetornoEnvioEvento.md 'EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')