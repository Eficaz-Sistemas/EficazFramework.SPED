#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoEnvioEvento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Lote | `String` |  |
| 03 | Ambiente | `Ambiente` |  |
| 04 | VersaoAplicativo | `String` |  |
| 05 | Orgao | `OrgaoIBGE` |  |
| 06 | RespostaCodigo | `String` |  |
| 07 | RespostaDescricao | `String` |  |
| 08 | ResultadoEventos | `List<EventoRetorno>` |  |
| 09 | Versao | `String` |  |
| 10 | DocumentType | `XMLDocumentType` |  |
| 11 | DataEmissao | `Nullable<DateTime>` |  |
| 12 | Chave | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ToString() | `String` |  |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoEnvioEvento, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoEnvioEvento) | `Boolean` |  |
| Deserialize(string) | `RetornoEnvioEvento` |  |
| Deserialize(Stream) | `RetornoEnvioEvento` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoEnvioEvento, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoEnvioEvento) | `Boolean` |  |
| LoadFrom(Stream, bool) | `RetornoEnvioEvento` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoEnvioEvento>` |  |
