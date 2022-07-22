#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[PedidoDownloadNF](EficazFramework.SPED.Schemas.NFe/PedidoDownloadNF.md 'EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF')

## PedidoDownloadNF.CanDeserialize(string, PedidoDownloadNF, Exception) Method

Deserializes workflow markup into an TEnvEvento object

```csharp
public static bool CanDeserialize(string xml, ref EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF,System.Exception).xml'></a>

`xml` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string workflow markup to deserialize

<a name='EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF,System.Exception).obj'></a>

`obj` [PedidoDownloadNF](EficazFramework.SPED.Schemas.NFe/PedidoDownloadNF.md 'EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF')

Output TEnvEvento object

<a name='EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF.CanDeserialize(string,EficazFramework.SPED.Schemas.NFe.PedidoDownloadNF,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false