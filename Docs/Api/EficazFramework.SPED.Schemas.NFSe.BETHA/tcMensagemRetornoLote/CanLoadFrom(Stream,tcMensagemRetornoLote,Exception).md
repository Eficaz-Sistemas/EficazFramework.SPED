#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.BETHA](EficazFramework.SPED.Schemas.NFSe.BETHA.md 'EficazFramework.SPED.Schemas.NFSe.BETHA').[tcMensagemRetornoLote](EficazFramework.SPED.Schemas.NFSe.BETHA/tcMensagemRetornoLote.md 'EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote')

## tcMensagemRetornoLote.CanLoadFrom(Stream, tcMensagemRetornoLote, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote,System.Exception).obj'></a>

`obj` [tcMensagemRetornoLote](EficazFramework.SPED.Schemas.NFSe.BETHA/tcMensagemRetornoLote.md 'EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.BETHA.tcMensagemRetornoLote,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false