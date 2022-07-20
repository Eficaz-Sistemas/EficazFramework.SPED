#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoConsultaCadastro Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Informacoes | `TRetConsCadInfCons` |  |
| 03 | versao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoConsultaCadastro, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoConsultaCadastro) | `Boolean` |  |
| Deserialize(string) | `RetornoConsultaCadastro` |  |
| Deserialize(Stream) | `RetornoConsultaCadastro` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoConsultaCadastro, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoConsultaCadastro) | `Boolean` |  |
| LoadFrom(Stream, bool) | `RetornoConsultaCadastro` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoConsultaCadastro>` |  |
