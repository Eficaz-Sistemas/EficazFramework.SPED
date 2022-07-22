#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.ABRASF](EficazFramework.SPED.Schemas.NFSe.ABRASF.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF').[NFSe](EficazFramework.SPED.Schemas.NFSe.ABRASF/NFSe.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe')

## NFSe.CanLoadFrom(Stream, NFSe, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe,System.Exception).obj'></a>

`obj` [NFSe](EficazFramework.SPED.Schemas.NFSe.ABRASF/NFSe.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.ABRASF.NFSe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false