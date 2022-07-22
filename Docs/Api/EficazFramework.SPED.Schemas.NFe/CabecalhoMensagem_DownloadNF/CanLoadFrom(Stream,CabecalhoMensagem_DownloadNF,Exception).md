#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe').[CabecalhoMensagem_DownloadNF](EficazFramework.SPED.Schemas.NFe/CabecalhoMensagem_DownloadNF.md 'EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF')

## CabecalhoMensagem_DownloadNF.CanLoadFrom(Stream, CabecalhoMensagem_DownloadNF, Exception) Method

Deserializes xml markup from file into an TNfeProc object

```csharp
public static bool CanLoadFrom(System.IO.Stream source, ref EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF obj, ref System.Exception exception);
```
#### Parameters

<a name='EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF,System.Exception).source'></a>

`source` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

target stream of outupt xml file

<a name='EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF,System.Exception).obj'></a>

`obj` [CabecalhoMensagem_DownloadNF](EficazFramework.SPED.Schemas.NFe/CabecalhoMensagem_DownloadNF.md 'EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF')

Output TNfeProc object

<a name='EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF.CanLoadFrom(System.IO.Stream,EficazFramework.SPED.Schemas.NFe.CabecalhoMensagem_DownloadNF,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

output Exception value if deserialize failed

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if this XmlSerializer can deserialize the object; otherwise, false