#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial').[EnvioLoteEventos](EficazFramework.SPED.Schemas.eSocial/EnvioLoteEventos.md 'EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos')

## EnvioLoteEventos.CanLoadFrom(Stream, EnvioLoteEventos, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos,System.Exception).obj'></a>

`obj` [EnvioLoteEventos](EficazFramework.SPED.Schemas.eSocial/EnvioLoteEventos.md 'EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.EnvioLoteEventos,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false