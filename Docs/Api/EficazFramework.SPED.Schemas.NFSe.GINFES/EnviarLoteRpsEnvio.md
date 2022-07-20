#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.GINFES](EficazFramework.SPED.Schemas.NFSe.GINFES.md 'EficazFramework.SPED.Schemas.NFSe.GINFES')

## EnviarLoteRpsEnvio Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Lote | `tcLoteRps` |  |
| 03 | DocumentType | `XMLDocumentType` |  |
| 04 | DataEmissao | `Nullable<DateTime>` |  |
| 05 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, EnviarLoteRpsEnvio, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, EnviarLoteRpsEnvio) | `Boolean` |  |
| Deserialize(string) | `EnviarLoteRpsEnvio` |  |
| Deserialize(Stream) | `EnviarLoteRpsEnvio` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, EnviarLoteRpsEnvio, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, EnviarLoteRpsEnvio) | `Boolean` |  |
| LoadFrom(Stream) | `EnviarLoteRpsEnvio` |  |
| LoadFromAsync(Stream, bool) | `Task<EnviarLoteRpsEnvio>` |  |
