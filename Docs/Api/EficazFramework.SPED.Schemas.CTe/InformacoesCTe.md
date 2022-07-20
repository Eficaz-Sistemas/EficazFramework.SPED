#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## InformacoesCTe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | IdentificacaoOperacao |  |
| 03 | Complemento |  |
| 04 | Emitente |  |
| 05 | Tomador |  |
| 06 | Remetente |  |
| 07 | Expedidor | Tomador do Serviço? |
| 08 | Recebedor |  |
| 09 | Destinatario |  |
| 10 | Valores |  |
| 11 | Impostos |  |
| 12 | DocumentosReferenciados |  |
| 13 | InformacaoCTePorTipo |  |
| 14 | AutorizadosDownloadXML |  |
| 15 | Versao |  |
| 16 | Id |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, InformacoesCTe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, InformacoesCTe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, InformacoesCTe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, InformacoesCTe) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
