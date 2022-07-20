#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES')

## tcMensagemRetorno Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Codigo |  |
| 03 | Mensagem |  |
| 04 | Correcao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcMensagemRetorno, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcMensagemRetorno) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, tcMensagemRetorno, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcMensagemRetorno) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
