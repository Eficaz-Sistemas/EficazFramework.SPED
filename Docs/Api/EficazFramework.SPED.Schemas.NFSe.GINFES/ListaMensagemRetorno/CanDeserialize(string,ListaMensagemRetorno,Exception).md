#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES').[ListaMensagemRetorno](EficazFramework.SPED.Schemas.NFSe.GINFES/ListaMensagemRetorno.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno')

## ListaMensagemRetorno.CanDeserialize(string, ListaMensagemRetorno, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno,System.Exception).obj'></a>

`obj` [ListaMensagemRetorno](EficazFramework.SPED.Schemas.NFSe.GINFES/ListaMensagemRetorno.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.GINFES.ListaMensagemRetorno,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false