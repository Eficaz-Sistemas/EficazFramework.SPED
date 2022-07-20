#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTeOS](EficazFramework.SPED.Schemas.CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS')

## CTeOS Class
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
| CanDeserialize(string, CTeOS, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CTeOS) | `Boolean` |  |
| Deserialize(string) | `CTeOS` |  |
| Deserialize(Stream) | `CTeOS` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CTeOS, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CTeOS) | `Boolean` |  |
| LoadFrom(Stream, bool) | `CTeOS` |  |
| LoadFromAsync(Stream) | `Task<CTeOS>` |  |
| LoadFromAsync(Stream, bool) | `Task<CTeOS>` |  |
