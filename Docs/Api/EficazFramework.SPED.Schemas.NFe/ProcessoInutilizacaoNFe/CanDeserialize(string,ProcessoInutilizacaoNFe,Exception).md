#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[ProcessoInutilizacaoNFe](EficazFramework.SPED.Schemas.NFe/ProcessoInutilizacaoNFe.md 'EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe')

## ProcessoInutilizacaoNFe.CanDeserialize(string, ProcessoInutilizacaoNFe, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe,System.Exception).obj'></a>

`obj` [ProcessoInutilizacaoNFe](EficazFramework.SPED.Schemas.NFe/ProcessoInutilizacaoNFe.md 'EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false