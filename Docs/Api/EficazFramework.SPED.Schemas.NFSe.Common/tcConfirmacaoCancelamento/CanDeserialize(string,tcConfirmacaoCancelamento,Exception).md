#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common').[tcConfirmacaoCancelamento](EficazFramework.SPED.Schemas.NFSe.Common/tcConfirmacaoCancelamento.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento')

## tcConfirmacaoCancelamento.CanDeserialize(string, tcConfirmacaoCancelamento, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento,System.Exception).obj'></a>

`obj` [tcConfirmacaoCancelamento](EficazFramework.SPED.Schemas.NFSe.Common/tcConfirmacaoCancelamento.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.Common.tcConfirmacaoCancelamento,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false