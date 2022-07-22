#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common').[tcSubstituicaoNfse](EficazFramework.SPED.Schemas.NFSe.Common/tcSubstituicaoNfse.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse')

## tcSubstituicaoNfse.CanLoadFrom(Stream, tcSubstituicaoNfse, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse,System.Exception).obj'></a>

`obj` [tcSubstituicaoNfse](EficazFramework.SPED.Schemas.NFSe.Common/tcSubstituicaoNfse.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.Common.tcSubstituicaoNfse,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false