#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroC170 Class

Complemento do Documento - itens do documento

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroSequenciaItem | `Nullable<Int16>` |  |
| 03 | CodigoItem | `String` |  |
| 04 | DescricaoItem | `String` |  |
| 05 | QuantidadeItem | `Nullable<Double>` |  |
| 06 | UnidadeItem | `String` |  |
| 07 | VrItem | `Nullable<Double>` |  |
| 08 | VrDesconto | `Nullable<Double>` |  |
| 09 | MovimentacaoFisica | `Nullable<Boolean>` |  |
| 10 | Origem | `OrigemMercadoria` |  |
| 11 | CST_ICMS | `CST_ICMS` |  |
| 12 | CFOP | `String` |  |
| 13 | CodNaturezaOperacao | `String` |  |
| 14 | VrBaseCalculoICMS | `Nullable<Double>` |  |
| 15 | AliquotaICMS | `Nullable<Double>` |  |
| 16 | VrICMS | `Nullable<Double>` |  |
| 17 | VrBaseCalculoICMSST | `Nullable<Double>` |  |
| 18 | AliquotaICMSST | `Nullable<Double>` |  |
| 19 | VrICMSST | `Nullable<Double>` |  |
| 20 | IndicadorApuracaoIPI | `Nullable<IndicadorPeriodoIPI>` |  |
| 21 | CST_IPI | `CST_IPI` |  |
| 22 | CodEnquadramentoIPI | `String` |  |
| 23 | VrBaseCalculoIPI | `Nullable<Double>` |  |
| 24 | AliquotaIPI | `Nullable<Double>` |  |
| 25 | VrIPI | `Nullable<Double>` |  |
| 26 | CST_PIS | `CST_PIS` |  |
| 27 | VrBaseCalculoPIS | `Nullable<Double>` |  |
| 28 | AliquotaPIS | `Nullable<Double>` |  |
| 29 | QuantidadeBCPIS | `Nullable<Double>` |  |
| 30 | AliquotaPISQuantidade | `Nullable<Double>` |  |
| 31 | VrPIS | `Nullable<Double>` |  |
| 32 | CST_COFINS | `CST_COFINS` |  |
| 33 | VrBaseCalculoCOFINS | `Nullable<Double>` |  |
| 34 | AliquotaCOFINS | `Nullable<Double>` |  |
| 35 | QuantidadeBCCOFINS | `Nullable<Double>` |  |
| 36 | AliquotaCOFINSQuantidade | `Nullable<Double>` |  |
| 37 | VrCOFINS | `Nullable<Double>` |  |
| 38 | CodigoContaContabil | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
