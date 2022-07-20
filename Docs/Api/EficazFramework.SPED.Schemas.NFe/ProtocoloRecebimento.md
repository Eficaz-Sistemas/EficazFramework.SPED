#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProtocoloRecebimento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InformacoesProtocolo | `InformacoesProtocolo` |  |
| 03 | Signature | `SignatureType` |  |
| 04 | versao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProtocoloRecebimento, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProtocoloRecebimento) | `Boolean` |  |
| Deserialize(string) | `ProtocoloRecebimento` |  |
| Deserialize(Stream) | `ProtocoloRecebimento` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ProtocoloRecebimento, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProtocoloRecebimento) | `Boolean` |  |
| LoadFrom(Stream) | `ProtocoloRecebimento` |  |
| LoadFromAsync(Stream) | `Task<ProtocoloRecebimento>` |  |
