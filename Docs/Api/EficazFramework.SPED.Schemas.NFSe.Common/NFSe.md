#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## NFSe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InfNfse | `tcInfNfse` |  |
| 03 | Signature | `List<SignatureType>` |  |
| 04 | DocumentType | `XMLDocumentType` |  |
| 05 | DataEmissao | `Nullable<DateTime>` |  |
| 06 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, NFSe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, NFSe) | `Boolean` |  |
| Deserialize(string) | `NFSe` |  |
| Deserialize(Stream) | `NFSe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, NFSe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, NFSe) | `Boolean` |  |
| LoadFrom(Stream) | `NFSe` |  |
| LoadFromAsync(Stream, bool) | `Task<NFSe>` |  |
