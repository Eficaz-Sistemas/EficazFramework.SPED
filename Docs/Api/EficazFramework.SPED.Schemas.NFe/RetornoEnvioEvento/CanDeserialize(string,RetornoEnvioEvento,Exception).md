#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[RetornoEnvioEvento](EficazFramework.SPED.Schemas.NFe/RetornoEnvioEvento.md 'EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento')

## RetornoEnvioEvento.CanDeserialize(string, RetornoEnvioEvento, Exception) Method

Deserializes workflow markup into an TEnvEvento object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento,System.Exception).obj'></a>

`obj` [RetornoEnvioEvento](EficazFramework.SPED.Schemas.NFe/RetornoEnvioEvento.md 'EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento')

Output TEnvEvento object

<a name='EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false