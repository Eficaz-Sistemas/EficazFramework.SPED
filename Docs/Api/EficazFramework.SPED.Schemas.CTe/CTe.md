#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## CTe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Informacoes | `InformacoesCTe` |  |
| 03 | Signature | `SignatureType` |  |
| 04 | DocumentType | `XMLDocumentType` |  |
| 05 | DataEmissao | `Nullable<DateTime>` |  |
| 06 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CTe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CTe) | `Boolean` |  |
| Deserialize(string) | `CTe` |  |
| Deserialize(Stream) | `CTe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CTe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CTe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `CTe` |  |
| LoadFromAsync(Stream) | `Task<CTe>` |  |
| LoadFromAsync(Stream, bool) | `Task<CTe>` |  |
