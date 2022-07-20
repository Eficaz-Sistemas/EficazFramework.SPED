#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcPedidoCancelamento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InfPedidoCancelamento | `tcInfPedidoCancelamento` |  |
| 03 | Signature | `SignatureType` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcPedidoCancelamento, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcPedidoCancelamento) | `Boolean` |  |
| Deserialize(string) | `tcPedidoCancelamento` |  |
| Deserialize(Stream) | `tcPedidoCancelamento` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, tcPedidoCancelamento, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcPedidoCancelamento) | `Boolean` |  |
| LoadFrom(Stream) | `tcPedidoCancelamento` |  |
| LoadFromAsync(Stream, bool) | `Task<tcPedidoCancelamento>` |  |
