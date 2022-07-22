#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1').[GuiaGNRE](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE.md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE')

## GuiaGNRE.CanDeserialize(string, GuiaGNRE, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE,System.Exception).obj'></a>

`obj` [GuiaGNRE](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE.md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false