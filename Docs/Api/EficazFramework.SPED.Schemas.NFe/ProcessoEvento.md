#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProcessoEvento Class

Esta classe representa o retorno de Cancelamento da NF-e por meio de Evento.

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Evento |  |
| 03 | EventoRetorno |  |
| 04 | Versao |  |
| 05 | DocumentType |  |
| 06 | DataEmissao |  |
| 07 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoEvento, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoEvento) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProcessoEvento, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoEvento) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
