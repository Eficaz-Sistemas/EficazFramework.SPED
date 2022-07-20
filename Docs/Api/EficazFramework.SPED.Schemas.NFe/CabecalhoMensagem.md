#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## CabecalhoMensagem Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | cUF |  |
| 03 | versaoDados |  |
| 04 | RootNamespace |  |
### Methods

| Name | |
| :--- | :--- |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CabecalhoMensagem, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CabecalhoMensagem) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, CabecalhoMensagem, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CabecalhoMensagem) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
