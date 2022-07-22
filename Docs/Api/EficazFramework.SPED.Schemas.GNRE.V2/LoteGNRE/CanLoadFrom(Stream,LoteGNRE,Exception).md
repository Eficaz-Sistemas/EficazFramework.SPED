#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2').[LoteGNRE](EficazFramework.SPED.Schemas.GNRE.V2/LoteGNRE.md 'EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE')

## LoteGNRE.CanLoadFrom(Stream, LoteGNRE, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE,System.Exception).obj'></a>

`obj` [LoteGNRE](EficazFramework.SPED.Schemas.GNRE.V2/LoteGNRE.md 'EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V2.LoteGNRE,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false