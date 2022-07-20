#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoEnvioEvento Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Lote |  |
| 03 | Ambiente |  |
| 04 | VersaoAplicativo |  |
| 05 | Orgao |  |
| 06 | RespostaCodigo |  |
| 07 | RespostaDescricao |  |
| 08 | ResultadoEventos |  |
| 09 | Versao |  |
| 10 | DocumentType |  |
| 11 | DataEmissao |  |
| 12 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| ToString() |  |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoEnvioEvento, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoEnvioEvento) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, RetornoEnvioEvento, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoEnvioEvento) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
