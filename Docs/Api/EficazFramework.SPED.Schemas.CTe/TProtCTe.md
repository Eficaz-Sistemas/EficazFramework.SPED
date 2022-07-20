#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## TProtCTe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | infProt | `TProtCTeInfProt` |  |
| 03 | Signature | `SignatureType` |  |
| 04 | versao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, TProtCTe, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, TProtCTe) | `Boolean` |  |
| Deserialize(string) | `TProtCTe` |  |
| Deserialize(Stream) | `TProtCTe` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, TProtCTe, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, TProtCTe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `TProtCTe` |  |
| LoadFromAsync(Stream, bool) | `Task<TProtCTe>` |  |
