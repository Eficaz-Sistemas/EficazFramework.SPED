#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CNAB240.Itau](EficazFramework.SPED.Schemas.CNAB240.Itau.md 'EficazFramework.SPED.Schemas.CNAB240.Itau')

## Registro3N_AnexoC_DARF Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoRecolhimento | `String` |  |
| 03 | TipoInscricao | `String` | 1 = CPF            2 = CNPJ [Default] |
| 04 | CNPJ_CPF | `String` |  |
| 05 | Competencia | `Nullable<DateTime>` |  |
| 06 | Referencia | `String` |  |
| 07 | ValorPrincipal | `Nullable<Double>` |  |
| 08 | ValorMulta | `Nullable<Double>` |  |
| 09 | ValorJurosEncargos | `Nullable<Double>` |  |
| 10 | ValorTotal | `Nullable<Double>` |  |
| 11 | DataVencimento | `Nullable<DateTime>` |  |
| 12 | DataArrecadacao | `Nullable<DateTime>` |  |
| 13 | ContribuinteNome | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
