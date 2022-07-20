#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SAT_CFe](EficazFramework.SPED.Schemas.SAT_CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe')

## CFe Class

Classe Principal do CF-e
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | infCFe |  |
| 03 | Any |  |
| 04 | DocumentType |  |
| 05 | DataEmissao |  |
| 06 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CFe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, CFe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CFe) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
