#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroG125 Class

Movimentação de BEM ou Componente do Ativo Imobilizado

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoBem | `String` |  |
| 03 | DataMovimento | `Nullable<DateTime>` |  |
| 04 | TipoMovimento | `Nullable<TipoMovimentoCIAP>` |  |
| 05 | ICMS_OpPropria_Entrada | `Nullable<Double>` |  |
| 06 | ICMS_ST_Entrada | `Nullable<Double>` |  |
| 07 | ICMS_Frete_Entrada | `Nullable<Double>` |  |
| 08 | ICMS_Difal_Entrada | `Nullable<Double>` |  |
| 09 | NumeroParcela | `Nullable<Double>` |  |
| 10 | ValorParcelaAprop | `Nullable<Double>` | Valor da Parcela de ICMS passível de Apropriação            (antes da aplicação da participação percentual do valor            das saídas tributadas / exportação sobre as saídas totais) |
| 11 | RegistrosG126 | `List<RegistroG126>` |  |
| 12 | RegistrosG130 | `List<RegistroG130>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
