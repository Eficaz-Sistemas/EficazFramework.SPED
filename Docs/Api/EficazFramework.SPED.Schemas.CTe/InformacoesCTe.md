#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## InformacoesCTe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IdentificacaoOperacao | `IdentificacaoOperacao` |  |
| 03 | Complemento | `ComplementoCTe` |  |
| 04 | Emitente | `Emitente` |  |
| 05 | Tomador | `Object` |  |
| 06 | Remetente | `Remetente` |  |
| 07 | Expedidor | `Expedidor` | Tomador do Serviço? |
| 08 | Recebedor | `Recebedor` |  |
| 09 | Destinatario | `Destinatario` |  |
| 10 | Valores | `ValoresPrestacaoServico` |  |
| 11 | Impostos | `Impostos` |  |
| 12 | DocumentosReferenciados | `ICollection` |  |
| 13 | InformacaoCTePorTipo | `Object` |  |
| 14 | AutorizadosDownloadXML | `ObservableCollection<AutorizadoXML>` |  |
| 15 | Versao | `String` |  |
| 16 | Id | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, InformacoesCTe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, InformacoesCTe) | `Boolean` |  |
| Deserialize(string) | `InformacoesCTe` |  |
| Deserialize(Stream) | `InformacoesCTe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, InformacoesCTe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, InformacoesCTe) | `Boolean` |  |
| LoadFrom(Stream) | `InformacoesCTe` |  |
| LoadFromAsync(Stream) | `Task<InformacoesCTe>` |  |
