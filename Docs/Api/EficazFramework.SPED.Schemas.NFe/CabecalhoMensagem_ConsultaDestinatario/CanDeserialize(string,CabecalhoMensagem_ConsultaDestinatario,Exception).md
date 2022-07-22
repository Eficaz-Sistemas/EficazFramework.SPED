#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[CabecalhoMensagem_ConsultaDestinatario](EficazFramework.SPED.Schemas.NFe/CabecalhoMensagem_ConsultaDestinatario.md 'EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario')

## CabecalhoMensagem_ConsultaDestinatario.CanDeserialize(string, CabecalhoMensagem_ConsultaDestinatario, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario,System.Exception).obj'></a>

`obj` [CabecalhoMensagem_ConsultaDestinatario](EficazFramework.SPED.Schemas.NFe/CabecalhoMensagem_ConsultaDestinatario.md 'EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_ConsultaDestinatario,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false