#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.ABRASF](EficazFramework.SPED.Schemas.NFSe.ABRASF.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF')

## tcCompNfse Class
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
| CanDeserialize(string, tcCompNfse, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, tcCompNfse) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, tcCompNfse, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, tcCompNfse) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
