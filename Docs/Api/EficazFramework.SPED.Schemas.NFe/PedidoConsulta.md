#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoConsulta Class

Objeto que contém as informação a serem enviadas no formato XML para requerer o serviço.

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Ambiente | `Ambiente` |  |
| 03 | Servico | `ServicoSolicitado` |  |
| 04 | CNPJ | `String` |  |
| 05 | IndicadorTipoNFeConsultada | `IndicadorTipoNFe` |  |
| 06 | IndicadorEmissorNFe | `IndicadorEmissorNFe` |  |
| 07 | UltimoNSU | `Nullable<Int64>` | Número de Série, Sequencial e Único de busca pelo destinatário.            Incrementar '+ 1' para cada busca pelo CNPJ. |
| 08 | Versao | `VersaoServicoConsDestinatario` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoConsulta, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoConsulta) | `Boolean` |  |
| Deserialize(string) | `PedidoConsulta` |  |
| Deserialize(Stream) | `PedidoConsulta` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, PedidoConsulta, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoConsulta) | `Boolean` |  |
| LoadFrom(Stream, bool) | `PedidoConsulta` |  |
| LoadFromAsync(Stream, bool) | `Task<PedidoConsulta>` |  |
