#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## TArquivoeReinf Class

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Any | `XElement` |  |
| 03 | id | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, TArquivoeReinf, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, TArquivoeReinf) | `Boolean` |  |
| Deserialize(string) | `TArquivoeReinf` |  |
| Deserialize(Stream) | `TArquivoeReinf` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, TArquivoeReinf, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, TArquivoeReinf) | `Boolean` |  |
| LoadFrom(Stream) | `TArquivoeReinf` |  |
| LoadFromAsync(Stream) | `Task<TArquivoeReinf>` |  |
