#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES').[tcListaNfse](EficazFramework.SPED.Schemas.NFSe.GINFES/tcListaNfse.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse')

## tcListaNfse.CanDeserialize(string, tcListaNfse, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse,System.Exception).obj'></a>

`obj` [tcListaNfse](EficazFramework.SPED.Schemas.NFSe.GINFES/tcListaNfse.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse.CanDeserialize(string,EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false