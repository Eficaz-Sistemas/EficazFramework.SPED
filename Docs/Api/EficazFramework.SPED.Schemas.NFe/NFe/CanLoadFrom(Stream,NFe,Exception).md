#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[NFe](EficazFramework.SPED.Schemas.NFe/NFe.md 'EficazFramework.SPED.Schemas.NFe.NFe')

## NFe.CanLoadFrom(Stream, NFe, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFe.NFe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.NFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.NFe,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFe.NFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.NFe,System.Exception).obj'></a>

`obj` [NFe](EficazFramework.SPED.Schemas.NFe/NFe.md 'EficazFramework.SPED.Schemas.NFe.NFe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFe.NFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.NFe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false