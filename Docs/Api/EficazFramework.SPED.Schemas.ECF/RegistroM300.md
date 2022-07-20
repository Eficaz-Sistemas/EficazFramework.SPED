#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroM300 Class

Demonstração do Lucro Real

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoReferencial | `String` |  |
| 03 | Descricao | `String` |  |
| 04 | TipoConta | `String` | A- Adição            E - Exclusão            P - Compensação de Prejuízo            L - Lucro |
| 05 | IndicadorRelacao | `String` | 1 - Com Conta da Parte B            2 - Com Conta Contábil            3 – Com Conta da parte B e Conta Contábil            4 - Sem Relacionamento |
| 06 | Valor | `Nullable<Double>` |  |
| 07 | Historico | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
