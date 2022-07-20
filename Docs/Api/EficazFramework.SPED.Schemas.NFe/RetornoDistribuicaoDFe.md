#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoDistribuicaoDFe Class

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | tpAmb |  |
| 03 | verAplic |  |
| 04 | cStat |  |
| 05 | xMotivo |  |
| 06 | dhResp |  |
| 07 | ultNSU |  |
| 08 | maxNSU |  |
| 09 | loteDistDFeInt |  |
| 10 | versao |  |
### Methods

| Name | |
| :--- | :--- |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, RetornoDistribuicaoDFe, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, RetornoDistribuicaoDFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, RetornoDistribuicaoDFe, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, RetornoDistribuicaoDFe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
