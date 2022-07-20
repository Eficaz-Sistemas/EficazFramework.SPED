#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## retDistDFeIntLoteDistDFeIntDocZip Class

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NSU | `String` |  |
| 03 | schema | `String` |  |
| 04 | Value | `Byte[]` |  |
| 05 | DocumentType | `XMLDocumentType` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| DescompactaAsync() | `Task<Byte[]>` |  |
| DecodedValueAsync() | `Task<String>` |  |
| GetInstanceAsync() | `Task<IXmlSpedDocument>` |  |
| SaveAsync(Stream) | `Task` |  |
| ToString() | `String` |  |
