#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common').[tcCancelamentoNfse](EficazFramework.SPED.Schemas.NFSe.Common/tcCancelamentoNfse.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse')

## tcCancelamentoNfse.CanSaveToFile(Stream, Exception) Method

Serializes current TNfeProc object into file

```csharp
public virtual bool CanSaveToFile(System.IO.Stream target, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse.CanSaveToFile(System.IO.Stream,System.Exception).target'></a>

`target` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcCancelamentoNfse.CanSaveToFile(System.IO.Stream,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if can serialize and save into file; otherwise, false