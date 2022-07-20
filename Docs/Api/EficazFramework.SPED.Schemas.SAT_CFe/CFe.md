#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SAT_CFe](EficazFramework.SPED.Schemas.SAT_CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe')

## CFe Class

Classe Principal do CF-e
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | infCFe | `CFeInformacoes` |  |
| 03 | Any | `XElement` |  |
| 04 | DocumentType | `XMLDocumentType` |  |
| 05 | DataEmissao | `Nullable<DateTime>` |  |
| 06 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CFe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CFe) | `Boolean` |  |
| Deserialize(string) | `CFe` |  |
| Deserialize(Stream) | `CFe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CFe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CFe) | `Boolean` |  |
| LoadFrom(Stream) | `CFe` |  |
| LoadFromAsync(Stream, bool) | `Task<CFe>` |  |
