#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01](EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01')

## ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoRetencoes Class

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| vlrBaseIR | `String` |  |
| vlrIR | `String` |  |
| vlrBaseAgreg | `String` | Valor da base de retenção de tributos de forma agregada, efetivamente realizada. <br/>            Este campo deve ser utilizado nos casos em que a retenção for realizada em valor agregado e             informada no campo {vlrAgreg}. <br/><br/><b>Validação: </b>Informação permitida apenas se, para a natureza do rendimento informada             em {natRend}, houver "Agreg" na coluna "Tributo" da Tabela 01.<br/>            Se informado, deve ser maior que 0 (zero). |
| vlrAgreg | `String` | Valor da retenção em valor agregado de tributos (IR, CSLL, Cofins e PIS/Pasep). <br/><br/><b>Validação: </b>Informação obrigatória se {vlrBaseAgreg} for informado. Se informado, deve ser maior que zero |
| vlrBaseCSLL | `String` |  |
| vlrCSLL | `String` |  |
| vlrBaseCofins | `String` |  |
| vlrCofins | `String` |  |
| vlrBasePP | `String` |  |
| vlrPP | `String` |  |
