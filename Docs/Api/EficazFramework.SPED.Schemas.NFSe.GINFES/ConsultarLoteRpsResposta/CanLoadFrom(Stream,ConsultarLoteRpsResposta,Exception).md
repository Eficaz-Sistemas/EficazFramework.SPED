#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES').[ConsultarLoteRpsResposta](EficazFramework.SPED.Schemas.NFSe.GINFES/ConsultarLoteRpsResposta.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta')

## ConsultarLoteRpsResposta.CanLoadFrom(Stream, ConsultarLoteRpsResposta, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta,System.Exception).obj'></a>

`obj` [ConsultarLoteRpsResposta](EficazFramework.SPED.Schemas.NFSe.GINFES/ConsultarLoteRpsResposta.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false