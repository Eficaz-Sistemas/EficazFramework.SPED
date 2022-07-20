#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial')

## eSocialRetornoEvento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Id | `String` |  |
| 03 | ideEmpregador | `TEmpregador` |  |
| 04 | recepcao | `TDadosRecepcaoRetornoEvento` |  |
| 05 | processamento | `TProcessamentoRetornoEvento` |  |
| 06 | recibo | `eSocialRetornoEventoRecibo` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, eSocialRetornoEvento, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, eSocialRetornoEvento) | `Boolean` |  |
| Deserialize(string) | `eSocialRetornoEvento` |  |
| Deserialize(Stream) | `eSocialRetornoEvento` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, eSocialRetornoEvento, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, eSocialRetornoEvento) | `Boolean` |  |
| LoadFrom(Stream) | `eSocialRetornoEvento` |  |
| LoadFromAsync(Stream) | `Task<eSocialRetornoEvento>` |  |
