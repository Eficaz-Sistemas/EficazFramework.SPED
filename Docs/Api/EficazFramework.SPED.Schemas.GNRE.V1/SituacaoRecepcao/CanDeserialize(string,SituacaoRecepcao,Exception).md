#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1').[SituacaoRecepcao](EficazFramework.SPED.Schemas.GNRE.V1/SituacaoRecepcao.md 'EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao')

## SituacaoRecepcao.CanDeserialize(string, SituacaoRecepcao, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao,System.Exception).obj'></a>

`obj` [SituacaoRecepcao](EficazFramework.SPED.Schemas.GNRE.V1/SituacaoRecepcao.md 'EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.SituacaoRecepcao,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false