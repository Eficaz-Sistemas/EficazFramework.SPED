#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SAT_CFe](EficazFramework.SPED.Schemas.SAT_CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe').[CFe](EficazFramework.SPED.Schemas.SAT_CFe/CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.CFe')

## CFe.CanDeserialize(string, CFe, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.SAT_CFe.CFe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.SAT_CFe.CFe.CanDeserialize(string,EficazFramework.SPED.Schemas.SAT_CFe.CFe,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.SAT_CFe.CFe.CanDeserialize(string,EficazFramework.SPED.Schemas.SAT_CFe.CFe,System.Exception).obj'></a>

`obj` [CFe](EficazFramework.SPED.Schemas.SAT_CFe/CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.CFe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.SAT_CFe.CFe.CanDeserialize(string,EficazFramework.SPED.Schemas.SAT_CFe.CFe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false