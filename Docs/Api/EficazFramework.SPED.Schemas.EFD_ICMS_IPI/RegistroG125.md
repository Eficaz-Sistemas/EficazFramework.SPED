#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroG125 Class

Movimentação de BEM ou Componente do Ativo Imobilizado

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| CodigoBem | `String` |  |
| DataMovimento | `Nullable<DateTime>` |  |
| TipoMovimento | `Nullable<TipoMovimentoCIAP>` |  |
| ICMS_OpPropria_Entrada | `Nullable<Double>` |  |
| ICMS_ST_Entrada | `Nullable<Double>` |  |
| ICMS_Frete_Entrada | `Nullable<Double>` |  |
| ICMS_Difal_Entrada | `Nullable<Double>` |  |
| NumeroParcela | `Nullable<Double>` |  |
| ValorParcelaAprop | `Nullable<Double>` | Valor da Parcela de ICMS passível de Apropriação            (antes da aplicação da participação percentual do valor            das saídas tributadas / exportação sobre as saídas totais) |
| RegistrosG126 | `List<RegistroG126>` |  |
| RegistrosG130 | `List<RegistroG130>` |  |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/RegistroG125/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG125.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/RegistroG125/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroG125.LeParametros(string[])') | |
