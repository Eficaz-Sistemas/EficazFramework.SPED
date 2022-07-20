#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SAT_CFe](EficazFramework.SPED.Schemas.SAT_CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe')

## envCFe Class

Classe de Envio de lote de CF-e'ss
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | tpAmb | `String` |  |
| 03 | idLote | `String` |  |
| 04 | cUF | `String` |  |
| 05 | LoteCFe | `CFe[]` |  |
| 06 | nSeg | `String` |  |
| 07 | dhEnvio | `String` |  |
| 08 | nserieSAT | `String` |  |
| 09 | versao | `String` |  |
| 10 | DocumentType | `XMLDocumentType` |  |
| 11 | DataEmissao | `Nullable<DateTime>` |  |
| 12 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, envCFe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, envCFe) | `Boolean` |  |
| Deserialize(string) | `envCFe` |  |
| Deserialize(Stream) | `envCFe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, envCFe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, envCFe) | `Boolean` |  |
| LoadFrom(Stream) | `envCFe` |  |
| LoadFromAsync(Stream, bool) | `Task<envCFe>` |  |
