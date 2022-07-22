#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe').[ProtocoloAutorizacao](EficazFramework.SPED.Schemas.CTe/ProtocoloAutorizacao.md 'EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao')

## ProtocoloAutorizacao.CanLoadFrom(Stream, ProtocoloAutorizacao, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao,System.Exception).obj'></a>

`obj` [ProtocoloAutorizacao](EficazFramework.SPED.Schemas.CTe/ProtocoloAutorizacao.md 'EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.CTe.ProtocoloAutorizacao,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false