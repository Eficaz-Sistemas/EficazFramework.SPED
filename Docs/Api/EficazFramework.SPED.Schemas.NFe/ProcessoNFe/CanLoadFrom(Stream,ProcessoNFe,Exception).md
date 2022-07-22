#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[ProcessoNFe](EficazFramework.SPED.Schemas.NFe/ProcessoNFe.md 'EficazFramework.SPED.Schemas.NFe.ProcessoNFe')

## ProcessoNFe.CanLoadFrom(Stream, ProcessoNFe, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFe.ProcessoNFe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.ProcessoNFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.ProcessoNFe,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFe.ProcessoNFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.ProcessoNFe,System.Exception).obj'></a>

`obj` [ProcessoNFe](EficazFramework.SPED.Schemas.NFe/ProcessoNFe.md 'EficazFramework.SPED.Schemas.NFe.ProcessoNFe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFe.ProcessoNFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.ProcessoNFe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false