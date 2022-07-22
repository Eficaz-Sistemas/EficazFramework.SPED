#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial').[RetornoConsultaLoteEventos](EficazFramework.SPED.Schemas.eSocial/RetornoConsultaLoteEventos.md 'EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos')

## RetornoConsultaLoteEventos.CanLoadFrom(Stream, RetornoConsultaLoteEventos, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos,System.Exception).obj'></a>

`obj` [RetornoConsultaLoteEventos](EficazFramework.SPED.Schemas.eSocial/RetornoConsultaLoteEventos.md 'EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.RetornoConsultaLoteEventos,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false