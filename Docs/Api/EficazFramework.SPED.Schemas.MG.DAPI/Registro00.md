#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.MG.DAPI](EficazFramework.SPED.Schemas.MG.DAPI.md 'EficazFramework.SPED.Schemas.MG.DAPI')

## Registro00 Class

Identificação da DAPI
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InscricaoEstadual | `String` |  |
| 03 | DataFinal | `Nullable<DateTime>` |  |
| 04 | DataInicial | `Nullable<DateTime>` |  |
| 05 | DapiSubstituta | `Boolean` |  |
| 06 | RegimeRecolhimento | `Int32` | Valor padrao: 1 - Debito e Credito            2 - Isento e Imune (nao aplicável) |
| 07 | RegimeEspecialFiscalizacao | `Boolean` |  |
| 08 | OptanteFundese | `Boolean` |  |
| 09 | DapiComMovimento | `Boolean` |  |
| 10 | DapiComMovimentoCafe | `Boolean` |  |
| 11 | CNAE | `String` |  |
| 12 | CNAEDesmembramento | `String` |  |
| 13 | TermoAceite | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
