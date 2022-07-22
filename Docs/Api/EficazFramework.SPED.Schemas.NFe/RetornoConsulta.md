#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoConsulta Class

Objeto retornado pelo serviço, no formato XML.  
Limite: 50 NF-e

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Ambiente | `Ambiente` |  |
| VersaoAplicativo | `String` | Versão do aplicativo que processou a consulta |
| RespostaStatus | `String` |  |
| RespostaDescricao | `String` |  |
| RespostaData | `DateTime` |  |
| IndicadorContinuacao | `IndicadorContinuacao` |  |
| indContSpecified | `Boolean` | ??? Que raios é isso ???            Vide XmlIgnore |
| UltimaNSUConsultada | `String` | No caso do aplicativo não conhecer a última NSU ao requerer o serviço,            à partir deste resultado ele pode controlar sua numeração para ser            devidamente utilizada na próxima consulta. |
| Resultados | `List<NFeResultado>` |  |
| Versao | `VersaoServicoConsDestinatario` |  |

| Methods | |
| :--- | :--- |
| [CanDeserialize(string, RetornoConsulta)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/CanDeserialize(string,RetornoConsulta).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.CanDeserialize(string, EficazFramework.SPED.Schemas.NFe.RetornoConsulta)') | |
| [CanDeserialize(string, RetornoConsulta, Exception)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/CanDeserialize(string,RetornoConsulta,Exception).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.CanDeserialize(string, EficazFramework.SPED.Schemas.NFe.RetornoConsulta, System.Exception)') | Deserializes workflow markup into an TEnvEvento object |
| [CanLoadFrom(Stream, RetornoConsulta)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/CanLoadFrom(Stream,RetornoConsulta).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.NFe.RetornoConsulta)') | |
| [CanLoadFrom(Stream, RetornoConsulta, Exception)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/CanLoadFrom(Stream,RetornoConsulta,Exception).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.NFe.RetornoConsulta, System.Exception)') | Deserializes xml markup from file into an TEnvEvento object |
| [CanSaveTo(Stream, Exception)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/CanSaveTo(Stream,Exception).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.CanSaveTo(System.IO.Stream, System.Exception)') | Serializes current TNfeProc object into file |
| [Deserialize(string)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/Deserialize(string).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.Deserialize(string)') | |
| [Deserialize(Stream)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/Deserialize(Stream).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.Deserialize(System.IO.Stream)') | |
| [LoadFrom(Stream, bool)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/LoadFrom(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.LoadFrom(System.IO.Stream, bool)') | |
| [LoadFromAsync(Stream, bool)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/LoadFromAsync(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.LoadFromAsync(System.IO.Stream, bool)') | |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.OnPropertyChanged(string)') | |
| [SaveTo(Stream)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/SaveTo(Stream).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.SaveTo(System.IO.Stream)') | |
| [SaveToAsync(Stream)](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/SaveToAsync(Stream).md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.SaveToAsync(System.IO.Stream)') | |
| [Serialize()](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/Serialize().md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.Serialize()') | Serializes current TEnvEvento object into an XML document |
| [SerializeToXMLDocument()](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/SerializeToXMLDocument().md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.SerializeToXMLDocument()') | Semelhante À Function Serialize, porém já retorna o resultado<br/>em uma instância de XmlDocument, agilizando o processo de assinatura<br/>digital dos eventos. |
| [ToString()](EficazFramework.SPED.Schemas.NFe/RetornoConsulta/ToString().md 'EficazFramework.SPED.Schemas.NFe.RetornoConsulta.ToString()') | |
