#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcCancelamentoNfse Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Confirmacao | `tcConfirmacaoCancelamento` |  |
| 03 | Signature | `SignatureType` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcCancelamentoNfse, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcCancelamentoNfse) | `Boolean` |  |
| Deserialize(string) | `tcCancelamentoNfse` |  |
| Deserialize(Stream) | `tcCancelamentoNfse` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, tcCancelamentoNfse, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcCancelamentoNfse) | `Boolean` |  |
| LoadFrom(Stream) | `tcCancelamentoNfse` |  |
| LoadFromAsync(Stream, bool) | `Task<tcCancelamentoNfse>` |  |
