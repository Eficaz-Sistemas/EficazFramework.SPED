#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives').[Escrituracao](EficazFramework.SPED.Schemas.Primitives/Escrituracao.md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao')

## Escrituracao.ProcessaLinha(string) Method

Método executado durante a leitura (desserialização) do arquivo digital.   
É executado a cada linha e permite a criação de instâncias de Registros,   
e monstagem da estrutura  
hierárquica de Blocos e Registros.

```csharp
public abstract void ProcessaLinha(string linha);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.Primitives.Escrituracao.ProcessaLinha(string).linha'></a>

`linha` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Conteúdo da linha atualmente lida.