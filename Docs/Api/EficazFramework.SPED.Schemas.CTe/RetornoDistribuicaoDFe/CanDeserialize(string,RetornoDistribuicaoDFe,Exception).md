#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe').[RetornoDistribuicaoDFe](EficazFramework.SPED.Schemas.CTe/RetornoDistribuicaoDFe.md 'EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe')

## RetornoDistribuicaoDFe.CanDeserialize(string, RetornoDistribuicaoDFe, Exception) Method

Deserializes workflow markup into an TEnvEvento object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe,System.Exception).obj'></a>

`obj` [RetornoDistribuicaoDFe](EficazFramework.SPED.Schemas.CTe/RetornoDistribuicaoDFe.md 'EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe')

Output TEnvEvento object

<a name='EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe.CanDeserialize(string,EficazFramework.SPED.Schemas.CTe.RetornoDistribuicaoDFe,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false