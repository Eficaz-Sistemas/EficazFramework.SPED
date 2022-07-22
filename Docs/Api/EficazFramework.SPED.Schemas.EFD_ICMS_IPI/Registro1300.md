#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro1300 Class

Movimentação Diária de Combustíveis

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| CodigoCombustivel0200 | `String` |  |
| DataFechamento | `Nullable<DateTime>` |  |
| EstoqueAbertura | `Nullable<Double>` |  |
| VolumeEntradas | `Nullable<Double>` |  |
| VolumeDisponivel | `Nullable<Double>` | Estoque Abertura + Volume Entradas |
| VolumeSaidas | `Nullable<Double>` |  |
| EstoqueEscritural | `Nullable<Double>` | Volume Disponível - Volume Saídas |
| AjustesPerda | `Nullable<Double>` |  |
| AjustesGanho | `Nullable<Double>` |  |
| EstoqueFechamento | `Nullable<Double>` |  |
| Registros1310 | `List<Registro1310>` |  |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro1300/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1300.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro1300/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1300.LeParametros(string[])') | |
