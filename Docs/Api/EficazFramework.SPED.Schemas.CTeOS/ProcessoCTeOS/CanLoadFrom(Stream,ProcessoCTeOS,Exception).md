#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTeOS](EficazFramework.SPED.Schemas.CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS').[ProcessoCTeOS](EficazFramework.SPED.Schemas.CTeOS/ProcessoCTeOS.md 'EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS')

## ProcessoCTeOS.CanLoadFrom(Stream, ProcessoCTeOS, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS,System.Exception).obj'></a>

`obj` [ProcessoCTeOS](EficazFramework.SPED.Schemas.CTeOS/ProcessoCTeOS.md 'EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false