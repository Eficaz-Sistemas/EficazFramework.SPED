#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## RetornoEvento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | infEvento | `TRetEventoInfEvento` |  |
| 03 | Signature | `SignatureType` |  |
| 04 | versao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoEvento, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoEvento) | `Boolean` |  |
| Deserialize(string) | `RetornoEvento` |  |
| Deserialize(Stream) | `RetornoEvento` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoEvento, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoEvento) | `Boolean` |  |
| LoadFrom(Stream, bool) | `RetornoEvento` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoEvento>` |  |
