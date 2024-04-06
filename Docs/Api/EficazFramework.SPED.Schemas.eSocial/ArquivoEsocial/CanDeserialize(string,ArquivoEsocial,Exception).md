#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial').[ArquivoEsocial](EficazFramework.SPED.Schemas.eSocial/ArquivoEsocial.md 'EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial')

## ArquivoEsocial.CanDeserialize(string, ArquivoEsocial, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial.CanDeserialize(string,EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial.CanDeserialize(string,EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial,System.Exception).obj'></a>

`obj` [ArquivoEsocial](EficazFramework.SPED.Schemas.eSocial/ArquivoEsocial.md 'EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial.CanDeserialize(string,EficazFramework.SPED.Schemas.eSocial.ArquivoEsocial,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false