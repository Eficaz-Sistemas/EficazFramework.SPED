#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial').[eSocialRetornoEvento](EficazFramework.SPED.Schemas.eSocial/eSocialRetornoEvento.md 'EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento')

## eSocialRetornoEvento.CanLoadFrom(Stream, eSocialRetornoEvento, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento,System.Exception).obj'></a>

`obj` [eSocialRetornoEvento](EficazFramework.SPED.Schemas.eSocial/eSocialRetornoEvento.md 'EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.eSocial.eSocialRetornoEvento,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false