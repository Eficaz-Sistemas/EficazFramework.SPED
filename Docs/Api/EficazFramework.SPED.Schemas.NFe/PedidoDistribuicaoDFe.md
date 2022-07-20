#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoDistribuicaoDFe Class

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Ambiente | `Ambiente` |  |
| 03 | UF_Autor | `OrgaoIBGE` |  |
| 04 | CNPJ_CPF | `String` |  |
| 05 | ItemElementName | `PersonalidadeJuridica` |  |
| 06 | NSUObject | `Object` |  |
| 07 | consChNFe | `distDFeIntconsChNFe` |  |
| 08 | versao | `VersaoServicoDistribuicaoDF` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoDistribuicaoDFe, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoDistribuicaoDFe) | `Boolean` |  |
| Deserialize(string) | `PedidoDistribuicaoDFe` |  |
| Deserialize(Stream) | `PedidoDistribuicaoDFe` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, PedidoDistribuicaoDFe, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoDistribuicaoDFe) | `Boolean` |  |
| LoadFrom(Stream, bool) | `PedidoDistribuicaoDFe` |  |
| LoadFromAsync(Stream, bool) | `Task<PedidoDistribuicaoDFe>` |  |
