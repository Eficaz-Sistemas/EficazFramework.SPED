#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE](EficazFramework.SPED.Schemas.GNRE.md 'EficazFramework.SPED.Schemas.GNRE')

## CabecalhoMensagem Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | versaoDados |  |
| 03 | RootNamespace |  |
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
