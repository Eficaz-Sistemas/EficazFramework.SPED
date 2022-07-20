#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ProcessoNFeBase Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Processo |  |
| 03 | Schema |  |
| 04 | DocumentType |  |
| 05 | DataEmissao |  |
| 06 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| ToString() |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ProcessoNFeBase, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ProcessoNFeBase) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProcessoNFeBase, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ProcessoNFeBase) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
