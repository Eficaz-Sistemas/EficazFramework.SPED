#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTeOS](EficazFramework.SPED.Schemas.CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS').[CTeOS](EficazFramework.SPED.Schemas.CTeOS/CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS.CTeOS')

## CTeOS.CanDeserialize(string, CTeOS, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.CTeOS.CTeOS obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.CTeOS.CTeOS.CanDeserialize(string,EficazFramework.SPED.Schemas.CTeOS.CTeOS,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.CTeOS.CTeOS.CanDeserialize(string,EficazFramework.SPED.Schemas.CTeOS.CTeOS,System.Exception).obj'></a>

`obj` [CTeOS](EficazFramework.SPED.Schemas.CTeOS/CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS.CTeOS')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.CTeOS.CTeOS.CanDeserialize(string,EficazFramework.SPED.Schemas.CTeOS.CTeOS,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false