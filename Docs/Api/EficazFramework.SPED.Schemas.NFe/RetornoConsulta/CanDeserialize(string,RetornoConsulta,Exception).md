#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[RetornoConsulta](EficazFramework.SPED.Schemas.NFe/RetornoConsulta.md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta')

## RetornoConsulta.CanDeserialize(string, RetornoConsulta, Exception) Method

Deserializes workflow markup into an TEnvEvento object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFe.RetornoConsulta obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.RetornoConsulta.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.RetornoConsulta,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFe.RetornoConsulta.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.RetornoConsulta,System.Exception).obj'></a>

`obj` [RetornoConsulta](EficazFramework.SPED.Schemas.NFe/RetornoConsulta.md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta')

Output TEnvEvento object

<a name='EficazFramework.SPED.Schemas.NFe.RetornoConsulta.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.RetornoConsulta,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false