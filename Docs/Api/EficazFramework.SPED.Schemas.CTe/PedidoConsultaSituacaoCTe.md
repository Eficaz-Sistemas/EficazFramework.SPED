#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## PedidoConsultaSituacaoCTe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Ambiente | `Ambiente` |  |
| 03 | TipoServico | `String` |  |
| 04 | Chave | `String` |  |
| 05 | versao | `VersaoServicoConsulta` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoConsultaSituacaoCTe, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoConsultaSituacaoCTe) | `Boolean` |  |
| Deserialize(string) | `PedidoConsultaSituacaoCTe` |  |
| Deserialize(Stream) | `PedidoConsultaSituacaoCTe` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, PedidoConsultaSituacaoCTe, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoConsultaSituacaoCTe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `PedidoConsultaSituacaoCTe` |  |
| LoadFromAsync(Stream, bool) | `Task<PedidoConsultaSituacaoCTe>` |  |
