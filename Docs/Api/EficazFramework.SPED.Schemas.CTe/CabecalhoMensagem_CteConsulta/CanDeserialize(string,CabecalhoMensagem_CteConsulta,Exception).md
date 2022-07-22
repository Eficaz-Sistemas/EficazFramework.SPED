#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe').[CabecalhoMensagem_CteConsulta](EficazFramework.SPED.Schemas.CTe/CabecalhoMensagem_CteConsulta.md 'EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta')

## CabecalhoMensagem_CteConsulta.CanDeserialize(string, CabecalhoMensagem_CteConsulta, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta,System.Exception).obj'></a>

`obj` [CabecalhoMensagem_CteConsulta](EficazFramework.SPED.Schemas.CTe/CabecalhoMensagem_CteConsulta.md 'EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.CabecalhoMensagem_CteConsulta,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false