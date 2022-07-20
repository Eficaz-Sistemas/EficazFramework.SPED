#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroM410 Class

Lançamento na Conta da Parte B do e-Lalur e do e-Lacs sem Reflexo na Parte A
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | CodigoContaParteB |  |
| 03 | CodigoTributo | I = IRPJ            C = CSLL |
| 04 | Valor |  |
| 05 | IndicadorRelacao | CR = Crédito            DB = Débito            PR = Prejuízo do Exerício            BC = Base de Cálculo Negativa da CSLL |
| 06 | CodigoContaParteB_Destino | Caso seja necessária a transferência de saldo de uma conta na parte B para outra conta na parte B |
| 07 | Historico |  |
| 08 | LanctoExerciciosAnteriores |  |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
