#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## CabecalhoMensagem_ConsultaDestinatario Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | cUF | `String` |  |
| 03 | versaoDados | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CabecalhoMensagem_ConsultaDestinatario, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CabecalhoMensagem_ConsultaDestinatario) | `Boolean` |  |
| Deserialize(string) | `CabecalhoMensagem_ConsultaDestinatario` |  |
| Deserialize(Stream) | `CabecalhoMensagem_ConsultaDestinatario` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CabecalhoMensagem_ConsultaDestinatario, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CabecalhoMensagem_ConsultaDestinatario) | `Boolean` |  |
| LoadFrom(Stream) | `CabecalhoMensagem_ConsultaDestinatario` |  |
| LoadFromAsync(Stream) | `Task<CabecalhoMensagem_ConsultaDestinatario>` |  |
