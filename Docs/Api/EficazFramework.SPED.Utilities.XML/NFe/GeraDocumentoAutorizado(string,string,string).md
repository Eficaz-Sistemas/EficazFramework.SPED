#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Utilities.XML](EficazFramework.SPED.Utilities.XML.md 'EficazFramework.SPED.Utilities.XML').[NFe](EficazFramework.SPED.Utilities.XML/NFe.md 'EficazFramework.SPED.Utilities.XML.NFe')

## NFe.GeraDocumentoAutorizado(string, string, string) Method

retorna o documento XML no schema [ProcessoNFe](EficazFramework.SPED.Schemas.NFe/ProcessoNFe.md 'EficazFramework.SPED.Schemas.NFe.ProcessoNFe') (tag raíz nfeProc),   
contendo a [NFe](EficazFramework.SPED.Schemas.NFe/NFe.md 'EficazFramework.SPED.Schemas.NFe.NFe') e seu [ProtocoloRecebimento](EficazFramework.SPED.Schemas.NFe/ProtocoloRecebimento.md 'EficazFramework.SPED.Schemas.NFe.ProtocoloRecebimento')

```csharp
public static string GeraDocumentoAutorizado(string nfe, string protocoloAutorizacao, string versao="4.00");
```
#### Parameters

<a name='EficazFramework.SPED.Utilities.XML.NFe.GeraDocumentoAutorizado(string,string,string).nfe'></a>

`nfe` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Utilities.XML.NFe.GeraDocumentoAutorizado(string,string,string).protocoloAutorizacao'></a>

`protocoloAutorizacao` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Utilities.XML.NFe.GeraDocumentoAutorizado(string,string,string).versao'></a>

`versao` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')