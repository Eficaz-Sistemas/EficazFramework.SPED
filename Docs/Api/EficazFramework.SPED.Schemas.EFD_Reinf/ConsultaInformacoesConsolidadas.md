#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## ConsultaInformacoesConsolidadas Class

Envio do evento R-5011
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | tipoInscricaoContribuinte |  |
| 03 | numeroInscricaoContribuinte |  |
| 04 | numeroProtocoloFechamento |  |
### Methods

| Name | |
| :--- | :--- |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, ConsultaInformacoesConsolidadas, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, ConsultaInformacoesConsolidadas) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, ConsultaInformacoesConsolidadas, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, ConsultaInformacoesConsolidadas) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
