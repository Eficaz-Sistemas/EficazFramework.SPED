#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoNFeCancelada Class

Objeto de retorno do tipo Cancelamento de Nota Fiscal Eletrônica.

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ChaveNFe | `String` |  |
| 03 | EmitenteCNPJ_CPF | `String` |  |
| 04 | EmitentePersonalidadeJuridica | `PersonalidadeJuridica` |  |
| 05 | EmitenteRazaoSocial | `String` |  |
| 06 | EmitenteIE | `String` |  |
| 07 | DataEmissao | `Nullable<DateTime>` |  |
| 08 | Operacao | `OperacaoNFe` |  |
| 09 | ValorTotal | `Nullable<Double>` |  |
| 10 | DigestValue | `String` |  |
| 11 | DataCancelamento | `Nullable<DateTime>` |  |
| 12 | Situacao | `SituacaoNFe` |  |
| 13 | SituacaoManifestacao | `SituacaoManifestacaoDestinatario` |  |
| 14 | NSU | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ToString() | `String` |  |
