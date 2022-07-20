#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial')

## TArquivoEsocial Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Any | `XElement` |  |
| 03 | Id | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, TArquivoEsocial, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, TArquivoEsocial) | `Boolean` |  |
| Deserialize(string) | `TArquivoEsocial` |  |
| Deserialize(Stream) | `TArquivoEsocial` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, TArquivoEsocial, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, TArquivoEsocial) | `Boolean` |  |
| LoadFrom(Stream) | `TArquivoEsocial` |  |
| LoadFromAsync(Stream) | `Task<TArquivoEsocial>` |  |
