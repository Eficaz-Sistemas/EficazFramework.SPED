#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProtocoloRecebimento Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | InformacoesProtocolo |  |
| 03 | Signature |  |
| 04 | versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProtocoloRecebimento, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProtocoloRecebimento) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProtocoloRecebimento, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProtocoloRecebimento) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
