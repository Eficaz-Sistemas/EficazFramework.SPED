#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcConfirmacaoCancelamento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Pedido | `tcPedidoCancelamento` |  |
| 03 | InfConfirmacaoCancelamento | `tcInfConfirmacaoCancelamento` |  |
| 04 | Id | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcConfirmacaoCancelamento, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcConfirmacaoCancelamento) | `Boolean` |  |
| Deserialize(string) | `tcConfirmacaoCancelamento` |  |
| Deserialize(Stream) | `tcConfirmacaoCancelamento` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, tcConfirmacaoCancelamento, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcConfirmacaoCancelamento) | `Boolean` |  |
| LoadFrom(Stream) | `tcConfirmacaoCancelamento` |  |
| LoadFromAsync(Stream, bool) | `Task<tcConfirmacaoCancelamento>` |  |
