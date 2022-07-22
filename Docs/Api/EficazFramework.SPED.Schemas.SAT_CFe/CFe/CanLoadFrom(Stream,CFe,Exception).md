#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SAT_CFe](EficazFramework.SPED.Schemas.SAT_CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe').[CFe](EficazFramework.SPED.Schemas.SAT_CFe/CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.CFe')

## CFe.CanLoadFrom(Stream, CFe, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.SAT_CFe.CFe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.SAT_CFe.CFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.SAT_CFe.CFe,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.SAT_CFe.CFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.SAT_CFe.CFe,System.Exception).obj'></a>

`obj` [CFe](EficazFramework.SPED.Schemas.SAT_CFe/CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.CFe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.SAT_CFe.CFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.SAT_CFe.CFe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false