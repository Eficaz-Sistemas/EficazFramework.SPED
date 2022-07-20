#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação do Empresário ou da Sociedade

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | CNPJ |  |
| 03 | NomeEmpresarial |  |
| 04 | IndicadorSitInicioPeriodo |  |
| 05 | SituacaoEspecial |  |
| 06 | PatrimonioRemanescente |  |
| 07 | DataSituacaoEspecial |  |
| 08 | DataInicial |  |
| 09 | DataFinal |  |
| 10 | Retificadora | Valores válidos:            S - ECF Retificadora            N - ECF Original            F - ECF Original com mudança de forma de tributação |
| 11 | ReciboRetificacao |  |
| 12 | TipoECF |  |
| 13 | CodigoSCP |  |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
