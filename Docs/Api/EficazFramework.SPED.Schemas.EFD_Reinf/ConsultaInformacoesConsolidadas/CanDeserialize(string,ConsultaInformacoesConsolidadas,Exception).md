#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf').[ConsultaInformacoesConsolidadas](EficazFramework.SPED.Schemas.EFD_Reinf/ConsultaInformacoesConsolidadas.md 'EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas')

## ConsultaInformacoesConsolidadas.CanDeserialize(string, ConsultaInformacoesConsolidadas, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas,System.Exception).obj'></a>

`obj` [ConsultaInformacoesConsolidadas](EficazFramework.SPED.Schemas.EFD_Reinf/ConsultaInformacoesConsolidadas.md 'EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.ConsultaInformacoesConsolidadas,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false