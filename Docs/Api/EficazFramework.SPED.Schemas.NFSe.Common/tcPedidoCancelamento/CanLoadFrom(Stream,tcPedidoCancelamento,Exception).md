#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common').[tcPedidoCancelamento](EficazFramework.SPED.Schemas.NFSe.Common/tcPedidoCancelamento.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento')

## tcPedidoCancelamento.CanLoadFrom(Stream, tcPedidoCancelamento, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento,System.Exception).obj'></a>

`obj` [tcPedidoCancelamento](EficazFramework.SPED.Schemas.NFSe.Common/tcPedidoCancelamento.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.Common.tcPedidoCancelamento,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false