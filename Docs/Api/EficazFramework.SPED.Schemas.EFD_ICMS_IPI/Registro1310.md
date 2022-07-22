#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro1310 Class

Movimentação Diária de Combustíveis por Tanque

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| NumeroTanque | `String` |  |
| EstoqueAbertura | `Nullable<Double>` |  |
| VolumeEntradas | `Nullable<Double>` |  |
| VolumeDisponivel | `Nullable<Double>` | Estoque Abertura + Volume Entradas |
| VolumeSaidas | `Nullable<Double>` |  |
| EstoqueEscritural | `Nullable<Double>` | Volume Disponível - Volume Saídas |
| AjustesPerda | `Nullable<Double>` |  |
| AjustesGanho | `Nullable<Double>` |  |
| EstoqueFechamento | `Nullable<Double>` |  |
| Registros1320 | `List<Registro1320>` |  |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro1310/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1310.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro1310/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro1310.LeParametros(string[])') | |
