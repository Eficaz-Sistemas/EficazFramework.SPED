#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CNAB240.Febraban](EficazFramework.SPED.Schemas.CNAB240.Febraban.md 'EficazFramework.SPED.Schemas.CNAB240.Febraban')

## Registro3N_AnexoC_GPS Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoRecolhimento | `String` |  |
| 03 | TipoInscricao | `String` | 1 = CNPJ [Default]            2 = CPF            3 = NIT/PIS/PASEP            4 = CEI            6 = NB            7 = Núm. Título            8 = DEBCAD            9 = Referencia |
| 04 | CNPJ | `String` |  |
| 05 | IdentificacaoTributo | `String` |  |
| 06 | Competencia | `Nullable<DateTime>` |  |
| 07 | ValorTributo | `Nullable<Double>` |  |
| 08 | ValorOutrasEntidades | `Nullable<Double>` |  |
| 09 | ValorAtualizacaoMonetaria | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
