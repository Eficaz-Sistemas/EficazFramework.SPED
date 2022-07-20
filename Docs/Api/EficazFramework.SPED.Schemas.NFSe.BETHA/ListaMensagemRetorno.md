#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.BETHA](EficazFramework.SPED.Schemas.NFSe.BETHA.md 'EficazFramework.SPED.Schemas.NFSe.BETHA')

## ListaMensagemRetorno Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | MensagemRetorno | `List<tcMensagemRetorno>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ListaMensagemRetorno, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ListaMensagemRetorno) | `Boolean` |  |
| Deserialize(string) | `ListaMensagemRetorno` |  |
| Deserialize(Stream) | `ListaMensagemRetorno` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ListaMensagemRetorno, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ListaMensagemRetorno) | `Boolean` |  |
| LoadFrom(Stream) | `ListaMensagemRetorno` |  |
| LoadFromAsync(Stream, bool) | `Task<ListaMensagemRetorno>` |  |
