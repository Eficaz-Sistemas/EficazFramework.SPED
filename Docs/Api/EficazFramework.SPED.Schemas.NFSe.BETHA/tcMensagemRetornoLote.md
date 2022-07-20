#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.BETHA](EficazFramework.SPED.Schemas.NFSe.BETHA.md 'EficazFramework.SPED.Schemas.NFSe.BETHA')

## tcMensagemRetornoLote Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IdentificacaoRps | `tcIdentificacaoRps` |  |
| 03 | Codigo | `String` |  |
| 04 | Mensagem | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcMensagemRetornoLote, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcMensagemRetornoLote) | `Boolean` |  |
| Deserialize(string) | `tcMensagemRetornoLote` |  |
| Deserialize(Stream) | `tcMensagemRetornoLote` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, tcMensagemRetornoLote, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcMensagemRetornoLote) | `Boolean` |  |
| LoadFrom(Stream) | `tcMensagemRetornoLote` |  |
| LoadFromAsync(Stream, bool) | `Task<tcMensagemRetornoLote>` |  |
