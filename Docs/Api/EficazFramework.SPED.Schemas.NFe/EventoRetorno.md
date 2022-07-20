#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## EventoRetorno Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | InformacaoEventoRetorno |  |
| 03 | Signature | Assinatura digital do documento XML. Deverá ser aplicada no elemento infEvento. |
| 04 | Versao |  |
### Methods

| Name | |
| :--- | :--- |
| ToString() |  |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, EventoRetorno, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, EventoRetorno) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, EventoRetorno, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, EventoRetorno) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
