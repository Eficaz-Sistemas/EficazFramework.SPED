#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## PedidoConsultaSituacaoCTe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Ambiente |  |
| 03 | TipoServico |  |
| 04 | Chave |  |
| 05 | versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoConsultaSituacaoCTe, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoConsultaSituacaoCTe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, PedidoConsultaSituacaoCTe, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoConsultaSituacaoCTe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
