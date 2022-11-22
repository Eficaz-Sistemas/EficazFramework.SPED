#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf.v1_05](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05').[TArquivoeReinf](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05/TArquivoeReinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf')

## TArquivoeReinf.CanDeserialize(string, TArquivoeReinf, Exception) Method

Deserializes workflow markup into an TNfeProc object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf,System.Exception).obj'></a>

`obj` [TArquivoeReinf](EficazFramework.SPED.Schemas.EFD_Reinf.v1_05/TArquivoeReinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf.CanDeserialize(string,EficazFramework.SPED.Schemas.EFD_Reinf.v1_05.TArquivoeReinf,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false