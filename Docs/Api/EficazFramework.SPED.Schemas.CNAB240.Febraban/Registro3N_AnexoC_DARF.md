#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CNAB240.Febraban](EficazFramework.SPED.Schemas.CNAB240.Febraban.md 'EficazFramework.SPED.Schemas.CNAB240.Febraban')

## Registro3N_AnexoC_DARF Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoRecolhimento | `String` |  |
| 03 | TipoInscricao | `String` | 1 = CNPJ [Default]            2 = CPF            3 = NIT/PIS/PASEP            4 = CEI            6 = NB            7 = Núm. Título            8 = DEBCAD            9 = Referencia |
| 04 | CNPJ_CPF | `String` |  |
| 05 | IdentificacaoTributo | `String` |  |
| 06 | Competencia | `Nullable<DateTime>` |  |
| 07 | Referencia | `String` |  |
| 08 | ValorPrincipal | `Nullable<Double>` |  |
| 09 | ValorMulta | `Nullable<Double>` |  |
| 10 | ValorJurosEncargos | `Nullable<Double>` |  |
| 11 | DataVencimento | `Nullable<DateTime>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
