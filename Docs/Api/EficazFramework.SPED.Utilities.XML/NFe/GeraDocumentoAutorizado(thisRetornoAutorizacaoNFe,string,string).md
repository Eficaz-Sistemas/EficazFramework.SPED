#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Utilities.XML](EficazFramework.SPED.Utilities.XML.md 'EficazFramework.SPED.Utilities.XML').[NFe](EficazFramework.SPED.Utilities.XML/NFe.md 'EficazFramework.SPED.Utilities.XML.NFe')

## NFe.GeraDocumentoAutorizado(this RetornoAutorizacaoNFe, string, string) Method

retorna o documento XML no schema [ProcessoNFe](EficazFramework.SPED.Schemas.NFe/ProcessoNFe.md 'EficazFramework.SPED.Schemas.NFe.ProcessoNFe') (tag raíz nfeProc),   
contendo a [NFe](EficazFramework.SPED.Schemas.NFe/NFe.md 'EficazFramework.SPED.Schemas.NFe.NFe') e seu [ProtocoloRecebimento](EficazFramework.SPED.Schemas.NFe/ProtocoloRecebimento.md 'EficazFramework.SPED.Schemas.NFe.ProtocoloRecebimento')

```csharp
public static string GeraDocumentoAutorizado(this EficazFramework.SPED.Schemas.NFe.RetornoAutorizacaoNFe retornoAutorizacao, string nfe, string versao="4.00");
```
#### Parameters

<a name='EficazFramework.SPED.Utilities.XML.NFe.GeraDocumentoAutorizado(thisEficazFramework.SPED.Schemas.NFe.RetornoAutorizacaoNFe,string,string).retornoAutorizacao'></a>

`retornoAutorizacao` [RetornoAutorizacaoNFe](EficazFramework.SPED.Schemas.NFe/RetornoAutorizacaoNFe.md 'EficazFramework.SPED.Schemas.NFe.RetornoAutorizacaoNFe')

<a name='EficazFramework.SPED.Utilities.XML.NFe.GeraDocumentoAutorizado(thisEficazFramework.SPED.Schemas.NFe.RetornoAutorizacaoNFe,string,string).nfe'></a>

`nfe` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Utilities.XML.NFe.GeraDocumentoAutorizado(thisEficazFramework.SPED.Schemas.NFe.RetornoAutorizacaoNFe,string,string).versao'></a>

`versao` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')