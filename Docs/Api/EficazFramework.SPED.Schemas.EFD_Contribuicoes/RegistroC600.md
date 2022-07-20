#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroC600 Class

Consolidação Diária de Notas fiscais/contas emitidas de energia elétrica

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodModDocFiscal | `String` |  |
| 03 | CodMunicipioIBGE | `String` |  |
| 04 | SerieDocFiscal | `String` |  |
| 05 | SubSerieDocFiscal | `String` |  |
| 06 | CodClasseConsEnergia | `String` |  |
| 07 | QtdeDocsConsolidadosRegistro | `Nullable<Int32>` |  |
| 08 | QtdeDocsCancelados | `Nullable<Int32>` |  |
| 09 | DataDocConsolidados | `Nullable<DateTime>` |  |
| 10 | VrTotalDocs | `Nullable<Double>` |  |
| 11 | VrAcumDescontos | `Nullable<Double>` |  |
| 12 | ConsumoTotalAcum | `Nullable<Double>` |  |
| 13 | VrAcumFornecimento | `Nullable<Double>` |  |
| 14 | VrAcumServNaoTributICMS | `Nullable<Double>` |  |
| 15 | VrCobradosNomeTerceiros | `Nullable<Double>` |  |
| 16 | VrAcumDespAcessorias | `Nullable<Double>` |  |
| 17 | VrAcumBCICMS | `Nullable<Double>` |  |
| 18 | VrAcumICMS | `Nullable<Double>` |  |
| 19 | VrAcumBCICMSST | `Nullable<Double>` |  |
| 20 | VrAcumICMSretidoST | `Nullable<Double>` |  |
| 21 | VrAcumPIS | `Nullable<Double>` |  |
| 22 | VrAcumCofins | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
