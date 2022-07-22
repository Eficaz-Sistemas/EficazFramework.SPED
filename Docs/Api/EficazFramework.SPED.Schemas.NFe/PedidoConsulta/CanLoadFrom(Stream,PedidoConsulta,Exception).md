#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[PedidoConsulta](EficazFramework.SPED.Schemas.NFe/PedidoConsulta.md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta')

## PedidoConsulta.CanLoadFrom(Stream, PedidoConsulta, Exception) Method

Deserializes xml markup from file into an TEnvEvento object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFe.PedidoConsulta obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.PedidoConsulta.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.PedidoConsulta,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFe.PedidoConsulta.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.PedidoConsulta,System.Exception).obj'></a>

`obj` [PedidoConsulta](EficazFramework.SPED.Schemas.NFe/PedidoConsulta.md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta')

Output TEnvEvento object

<a name='EficazFramework.SPED.Schemas.NFe.PedidoConsulta.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.PedidoConsulta,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false