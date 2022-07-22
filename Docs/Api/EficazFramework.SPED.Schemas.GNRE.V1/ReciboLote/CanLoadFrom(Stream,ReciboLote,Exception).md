#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1').[ReciboLote](EficazFramework.SPED.Schemas.GNRE.V1/ReciboLote.md 'EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote')

## ReciboLote.CanLoadFrom(Stream, ReciboLote, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote,System.Exception).obj'></a>

`obj` [ReciboLote](EficazFramework.SPED.Schemas.GNRE.V1/ReciboLote.md 'EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false