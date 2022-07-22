#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2').[ResultadoLote](EficazFramework.SPED.Schemas.GNRE.V2/ResultadoLote.md 'EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote')

## ResultadoLote.CanDeserialize(string, ResultadoLote, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote,System.Exception).obj'></a>

`obj` [ResultadoLote](EficazFramework.SPED.Schemas.GNRE.V2/ResultadoLote.md 'EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V2.ResultadoLote,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false