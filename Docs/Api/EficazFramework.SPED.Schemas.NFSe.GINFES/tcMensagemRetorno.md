#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES')

## tcMensagemRetorno Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Codigo | `String` |  |
| 03 | Mensagem | `String` |  |
| 04 | Correcao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcMensagemRetorno, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcMensagemRetorno) | `Boolean` |  |
| Deserialize(string) | `tcMensagemRetorno` |  |
| Deserialize(Stream) | `tcMensagemRetorno` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, tcMensagemRetorno, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcMensagemRetorno) | `Boolean` |  |
| LoadFrom(Stream) | `tcMensagemRetorno` |  |
| LoadFromAsync(Stream, bool) | `Task<tcMensagemRetorno>` |  |
