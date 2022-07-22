#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common').[tcRps](EficazFramework.SPED.Schemas.NFSe.Common/tcRps.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcRps')

## tcRps.CanDeserialize(string, tcRps, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFSe.Common.tcRps obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcRps.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcRps,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcRps.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcRps,System.Exception).obj'></a>

`obj` [tcRps](EficazFramework.SPED.Schemas.NFSe.Common/tcRps.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcRps')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcRps.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcRps,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false