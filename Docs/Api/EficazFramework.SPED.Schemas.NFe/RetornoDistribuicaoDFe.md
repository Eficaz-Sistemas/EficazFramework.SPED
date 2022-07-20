#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoDistribuicaoDFe Class

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | tpAmb | `Ambiente` |  |
| 03 | verAplic | `String` |  |
| 04 | cStat | `String` |  |
| 05 | xMotivo | `String` |  |
| 06 | dhResp | `String` |  |
| 07 | ultNSU | `String` |  |
| 08 | maxNSU | `String` |  |
| 09 | loteDistDFeInt | `retDistDFeIntLoteDistDFeInt` |  |
| 10 | versao | `VersaoServicoDistribuicaoDF` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoDistribuicaoDFe, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoDistribuicaoDFe) | `Boolean` |  |
| Deserialize(string) | `RetornoDistribuicaoDFe` |  |
| Deserialize(Stream) | `RetornoDistribuicaoDFe` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, RetornoDistribuicaoDFe, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoDistribuicaoDFe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `RetornoDistribuicaoDFe` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoDistribuicaoDFe>` |  |
