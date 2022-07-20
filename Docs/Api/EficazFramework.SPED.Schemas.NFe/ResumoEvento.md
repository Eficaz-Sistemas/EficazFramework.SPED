#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ResumoEvento Class

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | UF |  |
| 03 | EmitenteCNPJ_CPF |  |
| 04 | EmitentePersonalidadeJuridica |  |
| 05 | Chave |  |
| 06 | DataEmissao |  |
| 07 | EventoCodigo |  |
| 08 | EventoNumeroSequencial |  |
| 09 | DescricaoEvento |  |
| 10 | DataAutorizacao |  |
| 11 | Protocolo |  |
| 12 | DocumentType |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, ResumoEvento, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, ResumoEvento) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ResumoEvento, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, ResumoEvento) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
