#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf.v1_05](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05').[RetornoLoteEventos](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05/RetornoLoteEventos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos')

## RetornoLoteEventos.CanLoadFrom(Stream, RetornoLoteEventos, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos,System.Exception).obj'></a>

`obj` [RetornoLoteEventos](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05/RetornoLoteEventos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.RetornoLoteEventos,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false