#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## RetornoNFeNormal Class

Objeto de retorno do tipo Cancelamento de Nota Fiscal (Autorizada ou Denegada).

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Chave | `String` |  |
| EmitenteCNPJ_CPF | `String` |  |
| EmitentePersonalidadeJuridica | `PersonalidadeJuridica` |  |
| EmitenteRazaoSocial | `String` |  |
| EmitenteIE | `String` |  |
| EmissaoData | `Nullable<DateTime>` |  |
| DataEmissao | `Nullable<DateTime>` |  |
| Operacao | `OperacaoNFe` |  |
| ValorTotal | `String` |  |
| DigestValue | `String` |  |
| DataAutorizacao | `Nullable<DateTime>` |  |
| Situacao | `SituacaoNFe` |  |
| SituacaoManifestacao | `SituacaoManifestacaoDestinatario` |  |
| NSU | `String` |  |
| Protocolo | `String` |  |
| DocumentType | `XMLDocumentType` |  |

| Methods | |
| :--- | :--- |
| [Deserialize(string)](EficazFramework.SPED.Schemas.NFe/RetornoNFeNormal/Deserialize(string).md 'EficazFramework.SPED.Schemas.NFe.RetornoNFeNormal.Deserialize(string)') | |
| [LoadFrom(Stream, bool)](EficazFramework.SPED.Schemas.NFe/RetornoNFeNormal/LoadFrom(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.RetornoNFeNormal.LoadFrom(System.IO.Stream, bool)') | |
| [LoadFromAsync(Stream, bool)](EficazFramework.SPED.Schemas.NFe/RetornoNFeNormal/LoadFromAsync(Stream,bool).md 'EficazFramework.SPED.Schemas.NFe.RetornoNFeNormal.LoadFromAsync(System.IO.Stream, bool)') | |
| [ToString()](EficazFramework.SPED.Schemas.NFe/RetornoNFeNormal/ToString().md 'EficazFramework.SPED.Schemas.NFe.RetornoNFeNormal.ToString()') | |
