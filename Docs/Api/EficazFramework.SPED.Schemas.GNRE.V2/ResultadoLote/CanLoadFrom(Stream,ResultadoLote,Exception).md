#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2').[ResultadoLote](EficazFramework.SPED.Schemas.GNRE.V2/ResultadoLote.md 'EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote')

## ResultadoLote.CanLoadFrom(Stream, ResultadoLote, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote,System.Exception).obj'></a>

`obj` [ResultadoLote](EficazFramework.SPED.Schemas.GNRE.V2/ResultadoLote.md 'EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false