#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.ABRASF](EficazFramework.SPED.Schemas.NFSe.ABRASF.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF').[tcCompNfse](EficazFramework.SPED.Schemas.NFSe.ABRASF/tcCompNfse.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse')

## tcCompNfse.CanDeserialize(string, tcCompNfse, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse,System.Exception).obj'></a>

`obj` [tcCompNfse](EficazFramework.SPED.Schemas.NFSe.ABRASF/tcCompNfse.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false