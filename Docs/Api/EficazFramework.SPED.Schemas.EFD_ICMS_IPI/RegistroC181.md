#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC181 Class

Informações complementares das operações de devolução de saídas de mercadorias sujeitas à  
substituição tributária(código 01, 1B, 04 e 55).

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodMotivoRestituicao | `String` |  |
| 03 | QuantidadeItem | `Nullable<Double>` |  |
| 04 | Unidade | `String` |  |
| 05 | EspecieDocSaida | `String` |  |
| 06 | SerieDocSaida | `String` |  |
| 07 | ECFNumSerieSaida | `String` |  |
| 08 | NumeroDocSaida | `Nullable<Int64>` |  |
| 09 | ChaveDocSaida | `String` |  |
| 10 | DataDocSaida | `Nullable<DateTime>` |  |
| 11 | NumeroItemDocSaida | `Nullable<Int16>` |  |
| 12 | VrUnitarioSaida | `Nullable<Double>` |  |
| 13 | VrUnitarioOpPropriaEstoqueSaida | `Nullable<Double>` |  |
| 14 | VrUnitarioSTSaida | `Nullable<Double>` |  |
| 15 | VrUnitarioFCP_STSaida | `Nullable<Double>` |  |
| 16 | VrUnitarioICMSSaida | `Nullable<Double>` |  |
| 17 | VrUnitarioOpPropriaSaida | `Nullable<Double>` |  |
| 18 | VrUnitarioST_TotalRestituir | `Nullable<Double>` |  |
| 19 | VrUnitarioST_FCPRestituir | `Nullable<Double>` |  |
| 20 | VrUnitarioST_TotalComplementar | `Nullable<Double>` |  |
| 21 | VrUnitarioST_FCPComplementar | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
