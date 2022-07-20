#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcComplNfse Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Nfse |  |
| 03 | NfseCancelamento |  |
| 04 | NfseSubstituicao |  |
| 05 | DocumentType |  |
| 06 | DataEmissao |  |
| 07 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, tcComplNfse, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcComplNfse) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, tcComplNfse, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcComplNfse) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
