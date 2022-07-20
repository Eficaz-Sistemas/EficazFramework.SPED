#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## InformacoesNFe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | IdentificacaoOperacao | `IdentificacaoNFe` |  |
| 03 | Emitente | `Emitente` |  |
| 04 | Avulsa | `Fisco` |  |
| 05 | Destinatario | `Destinatario` |  |
| 06 | LocalRetirada | `Local` |  |
| 07 | LocalEntrega | `Local` |  |
| 08 | Items | `List<Item>` |  |
| 09 | Totais | `Totais` |  |
| 10 | Transporte | `InformacoesTransporte` |  |
| 11 | Cobranca | `Cobranca` |  |
| 12 | Pagamento | `Pagamento` |  |
| 13 | InformacoesAdicionais | `InformacoesAdicionais` |  |
| 14 | Exportacao | `Exportacao` |  |
| 15 | InformacaoAdicionalCompra | `Compra` |  |
| 16 | Cana | `Cana` |  |
| 17 | Versao | `String` |  |
| 18 | Id | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, InformacoesNFe, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, InformacoesNFe) | `Boolean` |  |
| Deserialize(string) | `InformacoesNFe` |  |
| Deserialize(Stream) | `InformacoesNFe` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, InformacoesNFe, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, InformacoesNFe) | `Boolean` |  |
| LoadFrom(Stream) | `InformacoesNFe` |  |
| LoadFromAsync(Stream) | `Task<InformacoesNFe>` |  |
