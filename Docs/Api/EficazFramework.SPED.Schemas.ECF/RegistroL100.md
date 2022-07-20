#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroL100 Class

Balanço Patrimonial

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | CodigoReferencial |  |
| 03 | Descricao |  |
| 04 | TipoConta | S - Sintética            A - Analitica |
| 05 | Nivel |  |
| 06 | Natureza |  |
| 07 | ContaSuperior |  |
| 08 | SaldoInicial |  |
| 09 | NaturezaSaldoInicial | D - Devedor            C - Credor |
| 10 | Debitos |  |
| 11 | Creditos |  |
| 12 | SaldoFinal |  |
| 13 | NaturezaSaldoFinal | D - Devedor            C - Credor |
| 14 | SubContas | Apenas para possibilitar a totalização na montagem do BP |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
