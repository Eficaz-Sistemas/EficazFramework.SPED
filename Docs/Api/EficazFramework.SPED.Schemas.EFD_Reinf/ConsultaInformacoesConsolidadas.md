#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## ConsultaInformacoesConsolidadas Class

Envio do evento R-5011
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | tipoInscricaoContribuinte | `PersonalidadeJuridica` |  |
| 03 | numeroInscricaoContribuinte | `String` |  |
| 04 | numeroProtocoloFechamento | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ConsultaInformacoesConsolidadas, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultaInformacoesConsolidadas) | `Boolean` |  |
| Deserialize(string) | `ConsultaInformacoesConsolidadas` |  |
| Deserialize(Stream) | `ConsultaInformacoesConsolidadas` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, ConsultaInformacoesConsolidadas, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultaInformacoesConsolidadas) | `Boolean` |  |
| LoadFrom(Stream) | `ConsultaInformacoesConsolidadas` |  |
| LoadFromAsync(Stream) | `Task<ConsultaInformacoesConsolidadas>` |  |
