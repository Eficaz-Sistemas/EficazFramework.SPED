#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial').[TArquivoEsocial](EficazFramework.SPED.Schemas.eSocial/TArquivoEsocial.md 'EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial')

## TArquivoEsocial.CanDeserialize(string, TArquivoEsocial, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial.CanDeserialize(string,EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial.CanDeserialize(string,EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial,System.Exception).obj'></a>

`obj` [TArquivoEsocial](EficazFramework.SPED.Schemas.eSocial/TArquivoEsocial.md 'EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial.CanDeserialize(string,EficazFramework.SPED.Schemas.eSocial.TArquivoEsocial,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false