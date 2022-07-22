#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1').[ConsultaConfigUfReceita](EficazFramework.SPED.Schemas.GNRE.V1/ConsultaConfigUfReceita.md 'EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita')

## ConsultaConfigUfReceita.CanLoadFrom(Stream, ConsultaConfigUfReceita, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita,System.Exception).obj'></a>

`obj` [ConsultaConfigUfReceita](EficazFramework.SPED.Schemas.GNRE.V1/ConsultaConfigUfReceita.md 'EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.GNRE.V1.ConsultaConfigUfReceita,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false