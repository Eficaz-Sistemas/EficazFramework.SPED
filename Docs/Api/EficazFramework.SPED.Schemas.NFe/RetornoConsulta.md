#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoConsulta Class

Objeto retornado pelo serviço, no formato XML.  
Limite: 50 NF-e

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Ambiente |  |
| 03 | VersaoAplicativo | Versão do aplicativo que processou a consulta |
| 04 | RespostaStatus |  |
| 05 | RespostaDescricao |  |
| 06 | RespostaData |  |
| 07 | IndicadorContinuacao |  |
| 08 | indContSpecified | ??? Que raios é isso ???            Vide XmlIgnore |
| 09 | UltimaNSUConsultada | No caso do aplicativo não conhecer a última NSU ao requerer o serviço,            à partir deste resultado ele pode controlar sua numeração para ser            devidamente utilizada na próxima consulta. |
| 10 | Resultados |  |
| 11 | Versao |  |
### Methods

| Name | |
| :--- | :--- |
| ToString() |  |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoConsulta, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoConsulta) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, RetornoConsulta, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoConsulta) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
