#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcComplNfse Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Nfse | `NFSe` |  |
| 03 | NfseCancelamento | `tcCancelamentoNfse` |  |
| 04 | NfseSubstituicao | `tcSubstituicaoNfse` |  |
| 05 | DocumentType | `XMLDocumentType` |  |
| 06 | DataEmissao | `Nullable<DateTime>` |  |
| 07 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcComplNfse, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcComplNfse) | `Boolean` |  |
| Deserialize(string) | `tcComplNfse` |  |
| Deserialize(Stream) | `tcComplNfse` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, tcComplNfse, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcComplNfse) | `Boolean` |  |
| LoadFrom(Stream, bool) | `tcComplNfse` |  |
| LoadFromAsync(Stream, bool) | `Task<tcComplNfse>` |  |
