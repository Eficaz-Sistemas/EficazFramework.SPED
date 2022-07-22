#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoConsulta Class

Objeto que contém as informação a serem enviadas no formato XML para requerer o serviço.

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Ambiente | `Ambiente` |  |
| Servico | `ServicoSolicitado` |  |
| CNPJ | `String` |  |
| IndicadorTipoNFeConsultada | `IndicadorTipoNFe` |  |
| IndicadorEmissorNFe | `IndicadorEmissorNFe` |  |
| UltimoNSU | `Nullable<Int64>` | Número de Série, Sequencial e Único de busca pelo destinatário.            Incrementar '+ 1' para cada busca pelo CNPJ. |
| Versao | `VersaoServicoConsDestinatario` |  |

| Methods | |
| :--- | :--- |
| [CanDeserialize(string, PedidoConsulta)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/CanDeserialize(string,PedidoConsulta).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.CanDeserialize(string, EficazFramework.SPED.Schemas.NFe.PedidoConsulta)') | |
| [CanDeserialize(string, PedidoConsulta, Exception)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/CanDeserialize(string,PedidoConsulta,Exception).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.CanDeserialize(string, EficazFramework.SPED.Schemas.NFe.PedidoConsulta, System.Exception)') | Deserializes workflow markup into an TEnvEvento object |
| [CanLoadFrom(Stream, PedidoConsulta)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/CanLoadFrom(Stream,PedidoConsulta).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.NFe.PedidoConsulta)') | |
| [CanLoadFrom(Stream, PedidoConsulta, Exception)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/CanLoadFrom(Stream,PedidoConsulta,Exception).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.NFe.PedidoConsulta, System.Exception)') | Deserializes xml markup from file into an TEnvEvento object |
| [CanSaveTo(Stream, Exception)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/CanSaveTo(Stream,Exception).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.CanSaveTo(System.IO.Stream, System.Exception)') | Serializes current TNfeProc object into file |
| [Deserialize(string)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/Deserialize(string).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.Deserialize(string)') | |
| [Deserialize(Stream)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/Deserialize(Stream).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.Deserialize(System.IO.Stream)') | |
| [LoadFrom(Stream, bool)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/LoadFrom(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.LoadFrom(System.IO.Stream, bool)') | |
| [LoadFromAsync(Stream, bool)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/LoadFromAsync(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.LoadFromAsync(System.IO.Stream, bool)') | |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.OnPropertyChanged(string)') | |
| [SaveTo(Stream)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/SaveTo(Stream).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.SaveTo(System.IO.Stream)') | |
| [SaveToAsync(Stream)](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/SaveToAsync(Stream).md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.SaveToAsync(System.IO.Stream)') | |
| [Serialize()](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/Serialize().md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.Serialize()') | Serializes current TEnvEvento object into an XML document |
| [SerializeToXMLDocument()](EficazFramework.SPED.Schemas.NFe/PedidoConsulta/SerializeToXMLDocument().md 'EficazFramework.SPED.Schemas.NFe.PedidoConsulta.SerializeToXMLDocument()') | Semelhante À Function Serialize, porém já retorna o resultado<br/>em uma instância de XmlDocument, agilizando o processo de assinatura<br/>digital dos eventos. |
