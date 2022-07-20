#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoDownloadNF Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Ambiente | `Ambiente` |  |
| 03 | VersaoAplicativo | `String` |  |
| 04 | RetornoCodigo | `String` |  |
| 05 | RetornoDescricao | `String` |  |
| 06 | RetornoDataHora | `DateTime` |  |
| 07 | Retorno | `List<RetornoNFe>` |  |
| 08 | Versao | `VersaoServicoDownload` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoDownloadNF, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoDownloadNF) | `Boolean` |  |
| Deserialize(string) | `RetornoDownloadNF` |  |
| Deserialize(Stream) | `RetornoDownloadNF` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoDownloadNF, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoDownloadNF) | `Boolean` |  |
| LoadFrom(Stream, bool) | `RetornoDownloadNF` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoDownloadNF>` |  |
