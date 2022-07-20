#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## RetornoConsultaSituacaoCTe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | tpAmb | `Ambiente` |  |
| 03 | verAplic | `String` |  |
| 04 | RetornoCodigo | `String` |  |
| 05 | RetornoDescricao | `String` |  |
| 06 | UF | `OrgaoIBGE` |  |
| 07 | Item | `Object` |  |
| 08 | procEventoCTe | `ObservableCollection<ProcessoEvento>` |  |
| 09 | versao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoConsultaSituacaoCTe, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoConsultaSituacaoCTe) | `Boolean` |  |
| Deserialize(string) | `RetornoConsultaSituacaoCTe` |  |
| Deserialize(Stream) | `RetornoConsultaSituacaoCTe` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoConsultaSituacaoCTe, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoConsultaSituacaoCTe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `RetornoConsultaSituacaoCTe` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoConsultaSituacaoCTe>` |  |
