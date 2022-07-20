#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SAT_CFe](EficazFramework.SPED.Schemas.SAT_CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe')

## CancelamentoCFe Class

Classe Principal contendo lote de CF-e's cancelados
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | tpAmb | `String` |  |
| 03 | idLote | `String` |  |
| 04 | LoteCFeCanc | `CFeCancelado[]` |  |
| 05 | cUF | `String` |  |
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
| CanDeserialize(string, CancelamentoCFe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CancelamentoCFe) | `Boolean` |  |
| Deserialize(string) | `CancelamentoCFe` |  |
| Deserialize(Stream) | `CancelamentoCFe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CancelamentoCFe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CancelamentoCFe) | `Boolean` |  |
| LoadFrom(Stream) | `CancelamentoCFe` |  |
| LoadFromAsync(Stream, bool) | `Task<CancelamentoCFe>` |  |
