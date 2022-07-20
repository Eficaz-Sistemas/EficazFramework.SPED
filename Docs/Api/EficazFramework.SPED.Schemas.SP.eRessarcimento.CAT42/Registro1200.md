#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42](EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42.md 'EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42')

## Registro1200 Class

REGISTRO DE DOCUMENTO FISCAL NÃO-ELETRÔNICO PARA FINS DE RESSARCIMENTO DE SUBSTITUIÇÂO TRIBUTÁRIA - SP

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoParticipante | `String` |  |
| 03 | CodigoModelo | `String` |  |
| 04 | ECF_NnumeroSerie | `String` |  |
| 05 | SerieDocumento | `String` |  |
| 06 | NumeroDocumento | `Nullable<Int32>` |  |
| 07 | NumeroItemOrdem | `Nullable<Int32>` |  |
| 08 | Operacao | `IndicadorOperacao` |  |
| 09 | DataEscrituracao | `Nullable<DateTime>` |  |
| 10 | CFOP | `String` |  |
| 11 | CodigoProduto | `String` |  |
| 12 | Quantidade | `Nullable<Double>` |  |
| 13 | ICMSTotal | `Nullable<Double>` | Valor total do ICMS suportado pelo contribuinte nas operações de entrada. |
| 14 | ValorConfronto | `Nullable<Double>` | Valor de confronto nas operações de saída |
| 15 | CodigoLegal | `EnquadramentLegal` |  |
| 16 | IsDevolucao | `Boolean` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
