#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## EventoTotalDadosProcessamento Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| nrRecArqBase | `String` | Recibo do arquivo de origem. Adicionado na versão 2.01.02 |
| nrProtEntr | `String` | Numero do protocolo de entrega do lote (retorno da série R-2000) |
| nrProtLote | `String` | Numero do protocolo de entrega do lote (retorno da série R-4000) |
| dhRecepcao | `DateTimeOffset` | Data e hora da recepcao do evento |
| dhProcess | `DateTimeOffset` | Data e hora do processamento |
| tpEv | `String` | Tipo do evento |
| idEv | `String` | ID do Evento |
| hash | `String` |  |
| fechRet | `Nullable<IndicadorFechamentoReabertura>` |  |

| Methods | |
| :--- | :--- |
| [ShouldSerializefechRet()](EficazFramework.SPED.Schemas.EFD_Reinf/EventoTotalDadosProcessamento/ShouldSerializefechRet().md 'EficazFramework.SPED.Schemas.EFD_Reinf.EventoTotalDadosProcessamento.ShouldSerializefechRet()') | |
