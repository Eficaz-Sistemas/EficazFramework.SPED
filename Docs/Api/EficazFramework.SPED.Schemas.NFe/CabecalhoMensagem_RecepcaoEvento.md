#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## CabecalhoMensagem_RecepcaoEvento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | cUF | `String` |  |
| 03 | versaoDados | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CabecalhoMensagem_RecepcaoEvento, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CabecalhoMensagem_RecepcaoEvento) | `Boolean` |  |
| Deserialize(string) | `CabecalhoMensagem_RecepcaoEvento` |  |
| Deserialize(Stream) | `CabecalhoMensagem_RecepcaoEvento` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CabecalhoMensagem_RecepcaoEvento, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CabecalhoMensagem_RecepcaoEvento) | `Boolean` |  |
| LoadFrom(Stream) | `CabecalhoMensagem_RecepcaoEvento` |  |
| LoadFromAsync(Stream) | `Task<CabecalhoMensagem_RecepcaoEvento>` |  |
