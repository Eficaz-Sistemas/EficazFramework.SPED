#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoConsultaSituacaoNFe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Ambiente | `Ambiente` |  |
| 03 | Servico | `String` |  |
| 04 | ChaveNFe | `String` |  |
| 05 | Versao | `VersaoServicoConsSitNFe` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoConsultaSituacaoNFe, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoConsultaSituacaoNFe) | `Boolean` |  |
| Deserialize(string) | `PedidoConsultaSituacaoNFe` |  |
| Deserialize(Stream) | `PedidoConsultaSituacaoNFe` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, PedidoConsultaSituacaoNFe, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoConsultaSituacaoNFe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `PedidoConsultaSituacaoNFe` |  |
| LoadFromAsync(Stream, bool) | `Task<PedidoConsultaSituacaoNFe>` |  |
