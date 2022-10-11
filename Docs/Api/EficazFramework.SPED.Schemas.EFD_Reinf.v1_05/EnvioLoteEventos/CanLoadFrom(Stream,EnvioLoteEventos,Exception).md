#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf.v1_05](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05').[EnvioLoteEventos](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05/EnvioLoteEventos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos')

## EnvioLoteEventos.CanLoadFrom(Stream, EnvioLoteEventos, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos,System.Exception).obj'></a>

`obj` [EnvioLoteEventos](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05/EnvioLoteEventos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.EnvioLoteEventos,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false