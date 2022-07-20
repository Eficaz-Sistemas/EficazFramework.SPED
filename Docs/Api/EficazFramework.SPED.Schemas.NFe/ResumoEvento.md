#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ResumoEvento Class

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | UF | `OrgaoIBGE` |  |
| 03 | EmitenteCNPJ_CPF | `String` |  |
| 04 | EmitentePersonalidadeJuridica | `PersonalidadeJuridica` |  |
| 05 | Chave | `String` |  |
| 06 | DataEmissao | `Nullable<DateTime>` |  |
| 07 | EventoCodigo | `CodigoEvento` |  |
| 08 | EventoNumeroSequencial | `String` |  |
| 09 | DescricaoEvento | `String` |  |
| 10 | DataAutorizacao | `Nullable<DateTime>` |  |
| 11 | Protocolo | `String` |  |
| 12 | DocumentType | `XMLDocumentType` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, ResumoEvento, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, ResumoEvento) | `Boolean` |  |
| Deserialize(string) | `ResumoEvento` |  |
| Deserialize(Stream) | `ResumoEvento` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ResumoEvento, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, ResumoEvento) | `Boolean` |  |
| LoadFrom(Stream, bool) | `ResumoEvento` |  |
| LoadFromAsync(Stream, bool) | `Task<ResumoEvento>` |  |
