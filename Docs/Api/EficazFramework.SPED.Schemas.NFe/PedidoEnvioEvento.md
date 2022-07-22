#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoEnvioEvento Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Lote | `String` | ATENÇÃO:            Identificador de controle do Lote de Envio do Evento.            Número sequencial autoincremental único para identificação do Lote. A responsabilidade de gerar e controlar o            identificador é exclusiva do autor do evento. O Web Service não faz qualquer uso ou controle deste identificador. |
| Eventos | `List<Evento>` | Máximo de eventos suportados por Lote: 20;            Cada evento deve ser assinado digitalmente na tag 'infEvento'. |
| Versao | `String` |  |

| Methods | |
| :--- | :--- |
| [CanDeserialize(string, PedidoEnvioEvento)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/CanDeserialize(string,PedidoEnvioEvento).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.CanDeserialize(string, EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento)') | |
| [CanDeserialize(string, PedidoEnvioEvento, Exception)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/CanDeserialize(string,PedidoEnvioEvento,Exception).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.CanDeserialize(string, EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento, System.Exception)') | Deserializes workflow markup into an TEnvEvento object |
| [CanLoadFrom(Stream, PedidoEnvioEvento)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/CanLoadFrom(Stream,PedidoEnvioEvento).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento)') | |
| [CanLoadFrom(Stream, PedidoEnvioEvento, Exception)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/CanLoadFrom(Stream,PedidoEnvioEvento,Exception).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento, System.Exception)') | Deserializes xml markup from file into an TEnvEvento object |
| [CanSaveTo(Stream, Exception)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/CanSaveTo(Stream,Exception).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.CanSaveTo(System.IO.Stream, System.Exception)') | Serializes current TNfeProc object into file |
| [Deserialize(string)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/Deserialize(string).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.Deserialize(string)') | |
| [Deserialize(Stream)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/Deserialize(Stream).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.Deserialize(System.IO.Stream)') | |
| [LoadFrom(Stream, bool)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/LoadFrom(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.LoadFrom(System.IO.Stream, bool)') | |
| [LoadFromAsync(Stream, bool)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/LoadFromAsync(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.LoadFromAsync(System.IO.Stream, bool)') | |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.OnPropertyChanged(string)') | |
| [SaveTo(Stream)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/SaveTo(Stream).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.SaveTo(System.IO.Stream)') | |
| [SaveToAsync(Stream)](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/SaveToAsync(Stream).md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.SaveToAsync(System.IO.Stream)') | |
| [Serialize()](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/Serialize().md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.Serialize()') | Serializes current TEnvEvento object into an XML document |
| [SerializeToXMLDocument()](EficazFramework.SPED.Schemas.NFe/PedidoEnvioEvento/SerializeToXMLDocument().md 'EficazFramework.SPED.Schemas.NFe.PedidoEnvioEvento.SerializeToXMLDocument()') | Semelhante À Function Serialize, porém já retorna o resultado<br/>em uma instância de XmlDocument, agilizando o processo de assinatura<br/>digital dos eventos. |
