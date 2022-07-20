#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcSubstituicaoNfse Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | SubstituicaoNfse | `tcInfSubstituicaoNfse` |  |
| 03 | Signature | `List<SignatureType>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcSubstituicaoNfse, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcSubstituicaoNfse) | `Boolean` |  |
| Deserialize(string) | `tcSubstituicaoNfse` |  |
| Deserialize(Stream) | `tcSubstituicaoNfse` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, tcSubstituicaoNfse, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcSubstituicaoNfse) | `Boolean` |  |
| LoadFrom(Stream) | `tcSubstituicaoNfse` |  |
| LoadFromAsync(Stream, bool) | `Task<tcSubstituicaoNfse>` |  |
