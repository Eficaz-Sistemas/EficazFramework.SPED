#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives').[Escrituracao](EficazFramework.SPED.Schemas.Primitives/Escrituracao.md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao')

## Escrituracao.LeEmpresaArquivo(Stream) Method

Retorna o CNPJ do informante do arquivo.

```csharp
public abstract System.Threading.Tasks.Task<string> LeEmpresaArquivo(System.IO.Stream stream);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.Primitives.Escrituracao.LeEmpresaArquivo(System.IO.Stream).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

Origem para leitura dos dados.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')