#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## TConsCad Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | infCons | `TConsCadInfCons` |  |
| 03 | versao | `VersaoServicoConsCadastro` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, TConsCad, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, TConsCad) | `Boolean` |  |
| Deserialize(string) | `TConsCad` |  |
| Deserialize(Stream) | `TConsCad` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, TConsCad, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, TConsCad) | `Boolean` |  |
| LoadFrom(Stream, bool) | `TConsCad` |  |
| LoadFromAsync(Stream, bool) | `Task<TConsCad>` |  |
