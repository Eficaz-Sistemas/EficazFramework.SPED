#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoDistribuicaoDFe Class

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Ambiente |  |
| 03 | UF_Autor |  |
| 04 | CNPJ_CPF |  |
| 05 | ItemElementName |  |
| 06 | NSUObject |  |
| 07 | consChNFe |  |
| 08 | versao |  |
### Methods

| Name | |
| :--- | :--- |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoDistribuicaoDFe, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoDistribuicaoDFe) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, PedidoDistribuicaoDFe, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoDistribuicaoDFe) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
