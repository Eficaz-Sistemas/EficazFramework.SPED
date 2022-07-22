#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SAT_CFe](EficazFramework.SPED.Schemas.SAT_CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe').[envCFe](EficazFramework.SPED.Schemas.SAT_CFe/envCFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.envCFe')

## envCFe.CanLoadFrom(Stream, envCFe, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.SAT_CFe.envCFe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.SAT_CFe.envCFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.SAT_CFe.envCFe,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.SAT_CFe.envCFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.SAT_CFe.envCFe,System.Exception).obj'></a>

`obj` [envCFe](EficazFramework.SPED.Schemas.SAT_CFe/envCFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.envCFe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.SAT_CFe.envCFe.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.SAT_CFe.envCFe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false