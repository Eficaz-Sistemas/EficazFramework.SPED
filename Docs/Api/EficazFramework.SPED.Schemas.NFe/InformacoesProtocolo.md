#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## InformacoesProtocolo Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Ambiente |  |
| 03 | VersaoAplicativo |  |
| 04 | ChaveNFe |  |
| 05 | ChaveNFeCodificada |  |
| 06 | ChaveNFeCodificadaByte |  |
| 07 | ChaveNFeFormatada |  |
| 08 | DataHoraRecebimento |  |
| 09 | Protocolo |  |
| 10 | DigestValue |  |
| 11 | StatusNFeCodigo |  |
| 12 | StatusNfeMotivo |  |
| 13 | Id |  |
### Methods

| Name | |
| :--- | :--- |
| SetCodeBarRaw(string, byte[]) |  |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, InformacoesProtocolo, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, InformacoesProtocolo) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, InformacoesProtocolo, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, InformacoesProtocolo) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
