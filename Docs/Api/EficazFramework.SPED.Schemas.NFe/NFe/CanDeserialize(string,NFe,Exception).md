#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[NFe](EficazFramework.SPED.Schemas.NFe/NFe.md 'EficazFramework.SPED.Schemas.NFe.NFe')

## NFe.CanDeserialize(string, NFe, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFe.NFe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.NFe.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.NFe,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFe.NFe.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.NFe,System.Exception).obj'></a>

`obj` [NFe](EficazFramework.SPED.Schemas.NFe/NFe.md 'EficazFramework.SPED.Schemas.NFe.NFe')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFe.NFe.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.NFe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false