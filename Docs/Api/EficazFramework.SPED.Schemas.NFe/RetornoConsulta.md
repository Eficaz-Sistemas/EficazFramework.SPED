#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoConsulta Class

Objeto retornado pelo serviço, no formato XML.  
Limite: 50 NF-e

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Ambiente | `Ambiente` |  |
| 03 | VersaoAplicativo | `String` | Versão do aplicativo que processou a consulta |
| 04 | RespostaStatus | `String` |  |
| 05 | RespostaDescricao | `String` |  |
| 06 | RespostaData | `DateTime` |  |
| 07 | IndicadorContinuacao | `IndicadorContinuacao` |  |
| 08 | indContSpecified | `Boolean` | ??? Que raios é isso ???            Vide XmlIgnore |
| 09 | UltimaNSUConsultada | `String` | No caso do aplicativo não conhecer a última NSU ao requerer o serviço,            à partir deste resultado ele pode controlar sua numeração para ser            devidamente utilizada na próxima consulta. |
| 10 | Resultados | `List<NFeResultado>` |  |
| 11 | Versao | `VersaoServicoConsDestinatario` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ToString() | `String` |  |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoConsulta, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoConsulta) | `Boolean` |  |
| Deserialize(string) | `RetornoConsulta` |  |
| Deserialize(Stream) | `RetornoConsulta` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoConsulta, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoConsulta) | `Boolean` |  |
| LoadFrom(Stream, bool) | `RetornoConsulta` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoConsulta>` |  |
