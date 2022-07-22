#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf').[TotalEventos](EficazFramework.SPED.Schemas.EFD_Reinf/TotalEventos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos')

## TotalEventos.CanLoadFrom(Stream, TotalEventos, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos,System.Exception).obj'></a>

`obj` [TotalEventos](EficazFramework.SPED.Schemas.EFD_Reinf/TotalEventos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false