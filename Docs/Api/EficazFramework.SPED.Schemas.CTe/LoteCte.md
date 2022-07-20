#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## LoteCte Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CTe | `CTe` |  |
| 03 | IdLote | `String` |  |
| 04 | Versao | `String` |  |
| 05 | DocumentType | `XMLDocumentType` |  |
| 06 | DataEmissao | `Nullable<DateTime>` |  |
| 07 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, LoteCte, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, LoteCte) | `Boolean` |  |
| Deserialize(string) | `LoteCte` |  |
| Deserialize(Stream) | `LoteCte` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, LoteCte, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, LoteCte) | `Boolean` |  |
| LoadFrom(Stream) | `LoteCte` |  |
| LoadFromAsync(Stream, bool) | `Task<LoteCte>` |  |
