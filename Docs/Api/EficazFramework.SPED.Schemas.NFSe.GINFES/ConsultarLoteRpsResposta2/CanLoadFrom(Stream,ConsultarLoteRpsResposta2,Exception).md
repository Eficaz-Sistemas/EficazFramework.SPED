#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES').[ConsultarLoteRpsResposta2](EficazFramework.SPED.Schemas.NFSe.GINFES/ConsultarLoteRpsResposta2.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2')

## ConsultarLoteRpsResposta2.CanLoadFrom(Stream, ConsultarLoteRpsResposta2, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2 obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2,System.Exception).obj'></a>

`obj` [ConsultarLoteRpsResposta2](EficazFramework.SPED.Schemas.NFSe.GINFES/ConsultarLoteRpsResposta2.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false