#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[TConsCad](EficazFramework.SPED.Schemas.NFe/TConsCad.md 'EficazFramework.SPED.Schemas.NFe.TConsCad')

## TConsCad.CanLoadFrom(Stream, TConsCad, Exception) Method

Deserializes xml markup from file into an TEnvEvento object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFe.TConsCad obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.TConsCad.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.TConsCad,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFe.TConsCad.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.TConsCad,System.Exception).obj'></a>

`obj` [TConsCad](EficazFramework.SPED.Schemas.NFe/TConsCad.md 'EficazFramework.SPED.Schemas.NFe.TConsCad')

Output TEnvEvento object

<a name='EficazFramework.SPED.Schemas.NFe.TConsCad.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.TConsCad,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false