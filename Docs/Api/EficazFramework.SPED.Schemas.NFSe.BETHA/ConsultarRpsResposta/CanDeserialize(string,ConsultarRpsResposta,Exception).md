#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.BETHA](EficazFramework.SPED.Schemas.NFSe.BETHA.md 'EficazFramework.SPED.Schemas.NFSe.BETHA').[ConsultarRpsResposta](EficazFramework.SPED.Schemas.NFSe.BETHA/ConsultarRpsResposta.md 'EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta')

## ConsultarRpsResposta.CanDeserialize(string, ConsultarRpsResposta, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta,System.Exception).obj'></a>

`obj` [ConsultarRpsResposta](EficazFramework.SPED.Schemas.NFSe.BETHA/ConsultarRpsResposta.md 'EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false