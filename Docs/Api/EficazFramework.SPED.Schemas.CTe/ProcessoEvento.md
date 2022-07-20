#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## ProcessoEvento Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | eventoCTe |  |
| 03 | retEventoCTe |  |
| 04 | versao |  |
| 05 | DocumentType |  |
| 06 | DataEmissao |  |
| 07 | Chave |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, ProcessoEvento, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, ProcessoEvento) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ProcessoEvento, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, ProcessoEvento) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
