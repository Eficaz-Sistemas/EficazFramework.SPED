#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe').[ProcessoCTe](EficazFramework.SPED.Schemas.CTe/ProcessoCTe.md 'EficazFramework.SPED.Schemas.CTe.ProcessoCTe')

## ProcessoCTe.CanLoadFrom(Stream, ProcessoCTe, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.CTe.ProcessoCTe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.CTe.ProcessoCTe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTe.ProcessoCTe,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.CTe.ProcessoCTe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTe.ProcessoCTe,System.Exception).obj'></a>

`obj` [ProcessoCTe](EficazFramework.SPED.Schemas.CTe/ProcessoCTe.md 'EficazFramework.SPED.Schemas.CTe.ProcessoCTe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.CTe.ProcessoCTe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTe.ProcessoCTe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false