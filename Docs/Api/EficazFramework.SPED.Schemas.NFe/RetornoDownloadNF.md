#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoDownloadNF Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Ambiente |  |
| 03 | VersaoAplicativo |  |
| 04 | RetornoCodigo |  |
| 05 | RetornoDescricao |  |
| 06 | RetornoDataHora |  |
| 07 | Retorno |  |
| 08 | Versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoDownloadNF, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoDownloadNF) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, RetornoDownloadNF, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoDownloadNF) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
