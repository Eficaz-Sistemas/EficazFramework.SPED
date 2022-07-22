#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf').[TotalEventos](EficazFramework.SPED.Schemas.EFD_Reinf/TotalEventos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos')

## TotalEventos.CanDeserialize(string, TotalEventos, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos,System.Exception).obj'></a>

`obj` [TotalEventos](EficazFramework.SPED.Schemas.EFD_Reinf/TotalEventos.md 'EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.TotalEventos,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false