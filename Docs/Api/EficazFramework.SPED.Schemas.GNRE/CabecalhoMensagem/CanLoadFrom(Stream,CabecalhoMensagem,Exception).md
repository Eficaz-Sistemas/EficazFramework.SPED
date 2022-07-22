#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE](EficazFramework.SPED.Schemas.GNRE.md 'EficazFramework.SPED.Schemas.GNRE').[CabecalhoMensagem](EficazFramework.SPED.Schemas.GNRE/CabecalhoMensagem.md 'EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem')

## CabecalhoMensagem.CanLoadFrom(Stream, CabecalhoMensagem, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem,System.Exception).obj'></a>

`obj` [CabecalhoMensagem](EficazFramework.SPED.Schemas.GNRE/CabecalhoMensagem.md 'EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.CabecalhoMensagem,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false