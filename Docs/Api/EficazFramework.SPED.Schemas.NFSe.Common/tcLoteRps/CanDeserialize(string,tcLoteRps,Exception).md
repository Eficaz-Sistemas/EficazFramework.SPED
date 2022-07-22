#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common').[tcLoteRps](EficazFramework.SPED.Schemas.NFSe.Common/tcLoteRps.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps')

## tcLoteRps.CanDeserialize(string, tcLoteRps, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps,System.Exception).obj'></a>

`obj` [tcLoteRps](EficazFramework.SPED.Schemas.NFSe.Common/tcLoteRps.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcLoteRps,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false