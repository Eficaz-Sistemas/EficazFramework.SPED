#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[RetornoEnvioEvento](EficazFramework.SPED.Schemas.NFe/RetornoEnvioEvento.md 'EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento')

## RetornoEnvioEvento.CanLoadFrom(Stream, RetornoEnvioEvento, Exception) Method

Deserializes xml markup from file into an TEnvEvento object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento,System.Exception).obj'></a>

`obj` [RetornoEnvioEvento](EficazFramework.SPED.Schemas.NFe/RetornoEnvioEvento.md 'EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento')

Output TEnvEvento object

<a name='EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false