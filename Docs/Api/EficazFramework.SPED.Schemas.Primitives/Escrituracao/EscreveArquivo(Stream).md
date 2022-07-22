#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives').[Escrituracao](EficazFramework.SPED.Schemas.Primitives/Escrituracao.md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao')

## Escrituracao.EscreveArquivo(Stream) Method

Método principal para escrita (serialização) da escrituração.

```csharp
public System.Threading.Tasks.Task EscreveArquivo(System.IO.Stream stream);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.Primitives.Escrituracao.EscreveArquivo(System.IO.Stream).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

Stream destino para gravação dos dados.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Uma [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') pode ser disparada quando a propriedade   
            [BlocoTotalizador](EficazFramework.SPED.Schemas.Primitives/Escrituracao.md#EficazFramework.SPED.Schemas.Primitives.Escrituracao.BlocoTotalizador 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.BlocoTotalizador') se referir a algum bloco não mapeado na escrituração.