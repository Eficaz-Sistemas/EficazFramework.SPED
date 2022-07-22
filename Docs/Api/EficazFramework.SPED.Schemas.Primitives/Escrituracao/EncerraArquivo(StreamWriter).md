#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives').[Escrituracao](EficazFramework.SPED.Schemas.Primitives/Escrituracao.md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao')

## Escrituracao.EncerraArquivo(StreamWriter) Method

Quando implementado, é chamado pelo método [EscreveArquivo(Stream)](EficazFramework.SPED.Schemas.Primitives/Escrituracao/EscreveArquivo(Stream).md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.EscreveArquivo(System.IO.Stream)') para escrita personalizada do final do arquivo.

```csharp
public virtual System.Threading.Tasks.Task EncerraArquivo(System.IO.StreamWriter writer);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.Primitives.Escrituracao.EncerraArquivo(System.IO.StreamWriter).writer'></a>

`writer` [System.IO.StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/System.IO.StreamWriter 'System.IO.StreamWriter')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
[System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')