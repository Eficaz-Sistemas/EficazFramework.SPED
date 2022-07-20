#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## CabecalhoMensagem_DownloadNF Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | cUF | `String` |  |
| 03 | versaoDados | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CabecalhoMensagem_DownloadNF, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CabecalhoMensagem_DownloadNF) | `Boolean` |  |
| Deserialize(string) | `CabecalhoMensagem_DownloadNF` |  |
| Deserialize(Stream) | `CabecalhoMensagem_DownloadNF` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CabecalhoMensagem_DownloadNF, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CabecalhoMensagem_DownloadNF) | `Boolean` |  |
| LoadFrom(Stream) | `CabecalhoMensagem_DownloadNF` |  |
| LoadFromAsync(Stream) | `Task<CabecalhoMensagem_DownloadNF>` |  |
