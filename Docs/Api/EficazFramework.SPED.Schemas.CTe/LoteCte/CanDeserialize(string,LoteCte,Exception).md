#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe').[LoteCte](EficazFramework.SPED.Schemas.CTe/LoteCte.md 'EficazFramework.SPED.Schemas.CTe.LoteCte')

## LoteCte.CanDeserialize(string, LoteCte, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.CTe.LoteCte obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.CTe.LoteCte.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.LoteCte,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.CTe.LoteCte.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.LoteCte,System.Exception).obj'></a>

`obj` [LoteCte](EficazFramework.SPED.Schemas.CTe/LoteCte.md 'EficazFramework.SPED.Schemas.CTe.LoteCte')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.CTe.LoteCte.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.LoteCte,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false