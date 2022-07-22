#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common').[tcCancelamentoNfse](EficazFramework.SPED.Schemas.NFSe.Common/tcCancelamentoNfse.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse')

## tcCancelamentoNfse.CanDeserialize(string, tcCancelamentoNfse, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse,System.Exception).obj'></a>

`obj` [tcCancelamentoNfse](EficazFramework.SPED.Schemas.NFSe.Common/tcCancelamentoNfse.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false