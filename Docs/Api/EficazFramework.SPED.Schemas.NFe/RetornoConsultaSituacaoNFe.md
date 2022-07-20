#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoConsultaSituacaoNFe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Ambiente |  |
| 03 | VersaoAplicativo |  |
| 04 | RetornoCodigo |  |
| 05 | RetornoDescricao |  |
| 06 | UF |  |
| 07 | ChaveNFe |  |
| 08 | ProtocoloNFe |  |
| 09 | RetornoCancelamentoV107 |  |
| 10 | RetornoEventos |  |
| 11 | Versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, RetornoConsultaSituacaoNFe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, RetornoConsultaSituacaoNFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, RetornoConsultaSituacaoNFe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, RetornoConsultaSituacaoNFe) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
