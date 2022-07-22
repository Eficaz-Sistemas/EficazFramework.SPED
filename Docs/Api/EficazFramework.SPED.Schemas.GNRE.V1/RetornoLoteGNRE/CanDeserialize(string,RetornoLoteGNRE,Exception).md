#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1').[RetornoLoteGNRE](EficazFramework.SPED.Schemas.GNRE.V1/RetornoLoteGNRE.md 'EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE')

## RetornoLoteGNRE.CanDeserialize(string, RetornoLoteGNRE, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE,System.Exception).obj'></a>

`obj` [RetornoLoteGNRE](EficazFramework.SPED.Schemas.GNRE.V1/RetornoLoteGNRE.md 'EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.RetornoLoteGNRE,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false