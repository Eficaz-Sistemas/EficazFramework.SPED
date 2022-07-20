#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## NFe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InformacoesNFe | `InformacoesNFe` |  |
| 03 | Signature | `SignatureType` |  |
| 04 | DocumentType | `XMLDocumentType` |  |
| 05 | DataEmissao | `Nullable<DateTime>` |  |
| 06 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, NFe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, NFe) | `Boolean` |  |
| Deserialize(string) | `NFe` |  |
| Deserialize(Stream) | `NFe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, NFe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, NFe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `NFe` |  |
| LoadFromAsync(Stream, bool) | `Task<NFe>` |  |
