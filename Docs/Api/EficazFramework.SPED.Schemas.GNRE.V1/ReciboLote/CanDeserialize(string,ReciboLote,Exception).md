#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1').[ReciboLote](EficazFramework.SPED.Schemas.GNRE.V1/ReciboLote.md 'EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote')

## ReciboLote.CanDeserialize(string, ReciboLote, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote,System.Exception).obj'></a>

`obj` [ReciboLote](EficazFramework.SPED.Schemas.GNRE.V1/ReciboLote.md 'EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote.CanDeserialize(string,EficazFramework.SPED.Schemas.GNRE.V1.ReciboLote,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false