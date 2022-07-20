#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## InformacoesNFe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | IdentificacaoOperacao |  |
| 03 | Emitente |  |
| 04 | Avulsa |  |
| 05 | Destinatario |  |
| 06 | LocalRetirada |  |
| 07 | LocalEntrega |  |
| 08 | Items |  |
| 09 | Totais |  |
| 10 | Transporte |  |
| 11 | Cobranca |  |
| 12 | Pagamento |  |
| 13 | InformacoesAdicionais |  |
| 14 | Exportacao |  |
| 15 | InformacaoAdicionalCompra |  |
| 16 | Cana |  |
| 17 | Versao |  |
| 18 | Id |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, InformacoesNFe, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, InformacoesNFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, InformacoesNFe, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, InformacoesNFe) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
