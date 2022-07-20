#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoConsulta Class

Objeto que contém as informação a serem enviadas no formato XML para requerer o serviço.

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Ambiente |  |
| 03 | Servico |  |
| 04 | CNPJ |  |
| 05 | IndicadorTipoNFeConsultada |  |
| 06 | IndicadorEmissorNFe |  |
| 07 | UltimoNSU | Número de Série, Sequencial e Único de busca pelo destinatário.            Incrementar '+ 1' para cada busca pelo CNPJ. |
| 08 | Versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoConsulta, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoConsulta) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, PedidoConsulta, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoConsulta) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
