#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## CabecalhoMensagem_CteConsulta Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | cUF | `String` |  |
| 03 | versaoDados | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CabecalhoMensagem_CteConsulta, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CabecalhoMensagem_CteConsulta) | `Boolean` |  |
| Deserialize(string) | `CabecalhoMensagem_CteConsulta` |  |
| Deserialize(Stream) | `CabecalhoMensagem_CteConsulta` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CabecalhoMensagem_CteConsulta, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CabecalhoMensagem_CteConsulta) | `Boolean` |  |
| LoadFrom(Stream) | `CabecalhoMensagem_CteConsulta` |  |
| LoadFromAsync(Stream) | `Task<CabecalhoMensagem_CteConsulta>` |  |
