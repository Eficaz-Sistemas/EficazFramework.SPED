#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroF130 Class

Bens incorporados ao ativo imobilizado - operações geradoras de créditos

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NatBcCalculo | `String` |  |
| 03 | IdentificacaoBensGrupoAtivo | `IdentificacaoBensGrupoAtivoImobilizado` |  |
| 04 | IndicadorOrigemBemAtivoImob | `IndicadorOrigemCreditoAtivoImobilizado` |  |
| 05 | IndicadorUtilizacaoBensAtivoImob | `IndicadorUtilizacaoBensAtivoImobilizado` |  |
| 06 | MesAquisicaoBemAtivoImobilizado | `Nullable<DateTime>` |  |
| 07 | VrOperacaoAquisicao | `Nullable<Double>` |  |
| 08 | ParcelaExcluirBcCreditoAquisicao | `Nullable<Double>` |  |
| 09 | VrBcCrédito | `Nullable<Double>` |  |
| 10 | IndicadorNumParcelas | `IndicadorNumeroParcelas` |  |
| 11 | CSTPis | `String` |  |
| 12 | VrBcPis | `Nullable<Double>` |  |
| 13 | AliqPis | `Nullable<Double>` |  |
| 14 | VrPis | `Nullable<Double>` |  |
| 15 | CSTCofins | `String` |  |
| 16 | VrBcCofins | `Nullable<Double>` |  |
| 17 | AliqCofins | `Nullable<Double>` |  |
| 18 | VrCofins | `Nullable<Double>` |  |
| 19 | CodigoContaContabil | `String` |  |
| 20 | CodigoCentroCusto | `String` |  |
| 21 | DescricaoComplementar | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
