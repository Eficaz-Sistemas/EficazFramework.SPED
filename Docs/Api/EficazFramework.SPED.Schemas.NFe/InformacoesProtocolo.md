#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## InformacoesProtocolo Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Ambiente | `Ambiente` |  |
| 03 | VersaoAplicativo | `String` |  |
| 04 | ChaveNFe | `String` |  |
| 05 | ChaveNFeCodificada | `String` |  |
| 06 | ChaveNFeCodificadaByte | `Byte[]` |  |
| 07 | ChaveNFeFormatada | `String` |  |
| 08 | DataHoraRecebimento | `DateTime` |  |
| 09 | Protocolo | `String` |  |
| 10 | DigestValue | `Byte[]` |  |
| 11 | StatusNFeCodigo | `String` |  |
| 12 | StatusNfeMotivo | `String` |  |
| 13 | Id | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| SetCodeBarRaw(string, byte[]) | `Void` |  |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, InformacoesProtocolo, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, InformacoesProtocolo) | `Boolean` |  |
| Deserialize(string) | `InformacoesProtocolo` |  |
| Deserialize(Stream) | `InformacoesProtocolo` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, InformacoesProtocolo, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, InformacoesProtocolo) | `Boolean` |  |
| LoadFrom(Stream) | `InformacoesProtocolo` |  |
| LoadFromAsync(Stream) | `Task<InformacoesProtocolo>` |  |
