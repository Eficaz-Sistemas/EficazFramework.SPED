#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## ResumoEvento Class

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| UF | `OrgaoIBGE` |  |
| EmitenteCNPJ_CPF | `String` |  |
| EmitentePersonalidadeJuridica | `PersonalidadeJuridica` |  |
| Chave | `String` |  |
| DataEmissao | `Nullable<DateTime>` |  |
| EventoCodigo | `CodigoEvento` |  |
| EventoNumeroSequencial | `String` |  |
| DescricaoEvento | `String` |  |
| DataAutorizacao | `Nullable<DateTime>` |  |
| Protocolo | `String` |  |
| DocumentType | `XMLDocumentType` |  |

| Methods | |
| :--- | :--- |
| [CanDeserialize(string, ResumoEvento)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/CanDeserialize(string,ResumoEvento).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.CanDeserialize(string, EficazFramework.SPED.Schemas.NFe.ResumoEvento)') | |
| [CanDeserialize(string, ResumoEvento, Exception)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/CanDeserialize(string,ResumoEvento,Exception).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.CanDeserialize(string, EficazFramework.SPED.Schemas.NFe.ResumoEvento, System.Exception)') | Deserializes workflow markup into an TEnvEvento object |
| [CanLoadFrom(Stream, ResumoEvento)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/CanLoadFrom(Stream,ResumoEvento).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.NFe.ResumoEvento)') | |
| [CanLoadFrom(Stream, ResumoEvento, Exception)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/CanLoadFrom(Stream,ResumoEvento,Exception).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.NFe.ResumoEvento, System.Exception)') | Deserializes xml markup from file into an TEnvEvento object |
| [CanSaveTo(Stream, Exception)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/CanSaveTo(Stream,Exception).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.CanSaveTo(System.IO.Stream, System.Exception)') | Serializes current TNfeProc object into file |
| [Deserialize(string)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/Deserialize(string).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.Deserialize(string)') | |
| [Deserialize(Stream)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/Deserialize(Stream).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.Deserialize(System.IO.Stream)') | |
| [LoadFrom(Stream, bool)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/LoadFrom(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.LoadFrom(System.IO.Stream, bool)') | |
| [LoadFromAsync(Stream, bool)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/LoadFromAsync(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.LoadFromAsync(System.IO.Stream, bool)') | |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.OnPropertyChanged(string)') | |
| [SaveTo(Stream)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/SaveTo(Stream).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.SaveTo(System.IO.Stream)') | |
| [SaveToAsync(Stream)](EficazFramework.SPED.Schemas.NFe/ResumoEvento/SaveToAsync(Stream).md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.SaveToAsync(System.IO.Stream)') | |
| [Serialize()](EficazFramework.SPED.Schemas.NFe/ResumoEvento/Serialize().md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.Serialize()') | Serializes current TEnvEvento object into an XML document |
| [SerializeToXMLDocument()](EficazFramework.SPED.Schemas.NFe/ResumoEvento/SerializeToXMLDocument().md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento.SerializeToXMLDocument()') | Semelhante À Function Serialize, porém já retorna o resultado<br/>em uma instância de XmlDocument, agilizando o processo de assinatura<br/>digital dos eventos. |
