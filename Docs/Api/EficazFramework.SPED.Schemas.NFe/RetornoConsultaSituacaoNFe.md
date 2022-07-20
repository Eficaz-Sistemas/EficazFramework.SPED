#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoConsultaSituacaoNFe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Ambiente | `Ambiente` |  |
| 03 | VersaoAplicativo | `String` |  |
| 04 | RetornoCodigo | `String` |  |
| 05 | RetornoDescricao | `String` |  |
| 06 | UF | `OrgaoIBGE` |  |
| 07 | ChaveNFe | `String` |  |
| 08 | ProtocoloNFe | `ProtocoloRecebimentoConsSitNFe` |  |
| 09 | RetornoCancelamentoV107 | `RetornoCancelamento_v200_107` |  |
| 10 | RetornoEventos | `ObservableCollection<Evento>` |  |
| 11 | Versao | `VersaoServicoConsSitNFe` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, RetornoConsultaSituacaoNFe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, RetornoConsultaSituacaoNFe) | `Boolean` |  |
| Deserialize(string) | `RetornoConsultaSituacaoNFe` |  |
| Deserialize(Stream) | `RetornoConsultaSituacaoNFe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoConsultaSituacaoNFe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, RetornoConsultaSituacaoNFe) | `Boolean` |  |
| LoadFrom(Stream) | `RetornoConsultaSituacaoNFe` |  |
| LoadFromAsync(Stream) | `Task<RetornoConsultaSituacaoNFe>` |  |
