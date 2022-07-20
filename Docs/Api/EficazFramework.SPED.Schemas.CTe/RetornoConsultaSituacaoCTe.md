#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## RetornoConsultaSituacaoCTe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | tpAmb |  |
| 03 | verAplic |  |
| 04 | RetornoCodigo |  |
| 05 | RetornoDescricao |  |
| 06 | UF |  |
| 07 | Item |  |
| 08 | procEventoCTe |  |
| 09 | versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoConsultaSituacaoCTe, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoConsultaSituacaoCTe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, RetornoConsultaSituacaoCTe, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoConsultaSituacaoCTe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
