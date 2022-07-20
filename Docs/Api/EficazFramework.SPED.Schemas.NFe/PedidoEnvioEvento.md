#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## PedidoEnvioEvento Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Lote | ATENÇÃO:            Identificador de controle do Lote de Envio do Evento.            Número sequencial autoincremental único para identificação do Lote. A responsabilidade de gerar e controlar o            identificador é exclusiva do autor do evento. O Web Service não faz qualquer uso ou controle deste identificador. |
| 03 | Eventos | Máximo de eventos suportados por Lote: 20;            Cada evento deve ser assinado digitalmente na tag 'infEvento'. |
| 04 | Versao |  |
### Methods

| Name | |
| :--- | :--- |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TEnvEvento object into an XML document |
| SerializeToXMLDocument() | Semelhante À Function Serialize, porém já retorna o resultado            em uma instância de XmlDocument, agilizando o processo de assinatura            digital dos eventos. |
| CanDeserialize(string, PedidoEnvioEvento, Exception) | Deserializes workflow markup into an TEnvEvento object |
| CanDeserialize(string, PedidoEnvioEvento) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveTo(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, PedidoEnvioEvento, Exception) | Deserializes xml markup from file into an TEnvEvento object |
| CanLoadFrom(Stream, PedidoEnvioEvento) |  |
| LoadFrom(Stream, bool) |  |
| LoadFromAsync(Stream, bool) |  |
