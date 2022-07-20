#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## TProtCTe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | infProt |  |
| 03 | Signature |  |
| 04 | versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, TProtCTe, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, TProtCTe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, TProtCTe, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, TProtCTe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
