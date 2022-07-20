#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoDownloadNF Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Ambiente |  |
| 03 | Servico |  |
| 04 | CNPJ |  |
| 05 | ChaveNFe |  |
| 06 | Versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoDownloadNF, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoDownloadNF) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, PedidoDownloadNF, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoDownloadNF) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
