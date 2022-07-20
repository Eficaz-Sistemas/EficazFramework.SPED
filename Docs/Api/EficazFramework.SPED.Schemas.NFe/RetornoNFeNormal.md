#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoNFeNormal Class

Objeto de retorno do tipo Cancelamento de Nota Fiscal (Autorizada ou Denegada).

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Chave | `String` |  |
| 03 | EmitenteCNPJ_CPF | `String` |  |
| 04 | EmitentePersonalidadeJuridica | `PersonalidadeJuridica` |  |
| 05 | EmitenteRazaoSocial | `String` |  |
| 06 | EmitenteIE | `String` |  |
| 07 | EmissaoData | `Nullable<DateTime>` |  |
| 08 | DataEmissao | `Nullable<DateTime>` |  |
| 09 | Operacao | `OperacaoNFe` |  |
| 10 | ValorTotal | `String` |  |
| 11 | DigestValue | `String` |  |
| 12 | DataAutorizacao | `Nullable<DateTime>` |  |
| 13 | Situacao | `SituacaoNFe` |  |
| 14 | SituacaoManifestacao | `SituacaoManifestacaoDestinatario` |  |
| 15 | NSU | `String` |  |
| 16 | Protocolo | `String` |  |
| 17 | DocumentType | `XMLDocumentType` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ToString() | `String` |  |
| LoadFrom(Stream, bool) | `RetornoNFeNormal` |  |
| LoadFromAsync(Stream, bool) | `Task<RetornoNFeNormal>` |  |
| Deserialize(string) | `RetornoNFeNormal` |  |
