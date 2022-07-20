#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoEnvioEvento Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Lote | `String` | ATENÇÃO:            Identificador de controle do Lote de Envio do Evento.            Número sequencial autoincremental único para identificação do Lote. A responsabilidade de gerar e controlar o            identificador é exclusiva do autor do evento. O Web Service não faz qualquer uso ou controle deste identificador. |
| 03 | Eventos | `List<Evento>` | Máximo de eventos suportados por Lote: 20;            Cada evento deve ser assinado digitalmente na tag 'infEvento'. |
| 04 | Versao | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | `XDocument` | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoEnvioEvento, Exception) | `Boolean` | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoEnvioEvento) | `Boolean` |  |
| Deserialize(string) | `PedidoEnvioEvento` |  |
| Deserialize(Stream) | `PedidoEnvioEvento` |  |
| CanSaveTo(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, PedidoEnvioEvento, Exception) | `Boolean` | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoEnvioEvento) | `Boolean` |  |
| LoadFrom(Stream, bool) | `PedidoEnvioEvento` |  |
| LoadFromAsync(Stream, bool) | `Task<PedidoEnvioEvento>` |  |
