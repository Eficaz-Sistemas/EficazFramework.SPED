#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroY550 Class

Demonstrativo do Imposto de Renda e CSLL Retidos na Fonte
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CNPJ_FontePagadora | `String` |  |
| 03 | NomeEmpresarial | `String` |  |
| 04 | IndicadorOrgaoPublico | `Boolean` |  |
| 05 | CodigoRecolhimento | `String` |  |
| 06 | RendimentoBruto | `Nullable<Double>` |  |
| 07 | IR_Retido | `Nullable<Double>` |  |
| 08 | CSLL_Retida | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
