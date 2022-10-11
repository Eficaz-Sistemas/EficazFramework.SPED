#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf.v1_05](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05').[TotalEventoContrib](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05/TotalEventoContrib.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib')

## TotalEventoContrib.CanDeserialize(string, TotalEventoContrib, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib,System.Exception).obj'></a>

`obj` [TotalEventoContrib](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05/TotalEventoContrib.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TotalEventoContrib,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false