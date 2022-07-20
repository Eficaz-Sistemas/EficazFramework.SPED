#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CNAB240](EficazFramework.SPED.Schemas.CNAB240.md 'EficazFramework.SPED.Schemas.CNAB240')

## Registro0 Class

Registro de Header de Arquivo
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoBanco | `String` |  |
| 03 | LoteDeServico | `String` |  |
| 04 | VersaoLayoutArquivo | `String` |  |
| 05 | TipoInscricao | `String` | 1 = CPF            2 = CNPJ [Default] |
| 06 | CNPJ | `String` |  |
| 07 | Convenio | `String` |  |
| 08 | Agencia | `String` |  |
| 09 | AgenciaDV | `String` |  |
| 10 | Conta | `String` |  |
| 11 | ContaDV | `String` |  |
| 12 | DAC | `String` |  |
| 13 | NomeEmpresa | `String` |  |
| 14 | NomeBanco | `String` |  |
| 15 | ArquivoCodigo | `String` | 1 = Remessa [Default]            2 = Retorno |
| 16 | DataGeracaoArquivo | `Nullable<DateTime>` |  |
| 17 | HoraGeracaoArquivo | `Nullable<TimeSpan>` |  |
| 18 | NumeroSequencialArquivo | `String` |  |
| 19 | VersaoCNAB | `String` |  |
| 20 | UnidadeDensidade | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
