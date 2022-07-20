#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## EventoRetorno Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InformacaoEventoRetorno | `InformacaoEventoRetorno` |  |
| 03 | Signature | `SignatureType` | Assinatura digital do documento XML. Deverá ser aplicada no elemento infEvento. |
| 04 | Versao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ToString() | `String` |  |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, EventoRetorno, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, EventoRetorno) | `Boolean` |  |
| Deserialize(string) | `EventoRetorno` |  |
| Deserialize(Stream) | `EventoRetorno` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, EventoRetorno, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, EventoRetorno) | `Boolean` |  |
| LoadFrom(Stream, bool) | `EventoRetorno` |  |
| LoadFromAsync(Stream, bool) | `Task<EventoRetorno>` |  |
