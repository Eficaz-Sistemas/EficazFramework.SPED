#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42](EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42.md 'EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42')

## Registro1100 Class

REGISTRO DE DOCUMENTO FISCAL ELETRÔNICO PARA FINS DE RESSARCIMENTO DE SUBSTITUIÇÂO TRIBUTÁRIA OU ANTECIPAÇÃO

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ChaveNFe | `String` |  |
| 03 | DataEscrituracao | `Nullable<DateTime>` |  |
| 04 | NumeroItemOrdem | `Nullable<Int32>` |  |
| 05 | Operacao | `IndicadorOperacao` |  |
| 06 | CodigoProduto | `String` |  |
| 07 | CFOP | `String` |  |
| 08 | Quantidade | `Nullable<Double>` |  |
| 09 | ICMSTotal | `Nullable<Double>` | Valor total do ICMS suportado pelo contribuinte nas operações de entrada. |
| 10 | ValorConfronto | `Nullable<Double>` | Valor de confronto nas operações de saída |
| 11 | CodigoLegal | `EnquadramentLegal` |  |
| 12 | IsDevolucao | `Boolean` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
