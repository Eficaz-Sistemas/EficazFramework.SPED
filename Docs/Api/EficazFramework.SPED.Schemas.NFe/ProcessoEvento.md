#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProcessoEvento Class

Esta classe representa o retorno de Cancelamento da NF-e por meio de Evento.

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Evento | `Evento` |  |
| 03 | EventoRetorno | `EventoRetorno` |  |
| 04 | Versao | `VersaoServicoEvento` |  |
| 05 | DocumentType | `XMLDocumentType` |  |
| 06 | DataEmissao | `Nullable<DateTime>` |  |
| 07 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoEvento, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoEvento) | `Boolean` |  |
| Deserialize(string) | `ProcessoEvento` |  |
| Deserialize(Stream) | `ProcessoEvento` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ProcessoEvento, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoEvento) | `Boolean` |  |
| LoadFrom(Stream) | `ProcessoEvento` |  |
| LoadFromAsync(Stream) | `Task<ProcessoEvento>` |  |
| LoadFromAsync(Stream, bool) | `Task<ProcessoEvento>` |  |
