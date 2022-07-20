#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SAT_CFe](EficazFramework.SPED.Schemas.SAT_CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe')

## envCFe Class

Classe de Envio de lote de CF-e'ss
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | tpAmb |  |
| 03 | idLote |  |
| 04 | cUF |  |
| 05 | LoteCFe |  |
| 06 | nSeg |  |
| 07 | dhEnvio |  |
| 08 | nserieSAT |  |
| 09 | versao |  |
| 10 | DocumentType |  |
| 11 | DataEmissao |  |
| 12 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, envCFe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, envCFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, envCFe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, envCFe) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
