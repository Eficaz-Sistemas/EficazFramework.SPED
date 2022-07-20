#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro1310 Class

Movimentação Diária de Combustíveis por Tanque

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroTanque | `String` |  |
| 03 | EstoqueAbertura | `Nullable<Double>` |  |
| 04 | VolumeEntradas | `Nullable<Double>` |  |
| 05 | VolumeDisponivel | `Nullable<Double>` | Estoque Abertura + Volume Entradas |
| 06 | VolumeSaidas | `Nullable<Double>` |  |
| 07 | EstoqueEscritural | `Nullable<Double>` | Volume Disponível - Volume Saídas |
| 08 | AjustesPerda | `Nullable<Double>` |  |
| 09 | AjustesGanho | `Nullable<Double>` |  |
| 10 | EstoqueFechamento | `Nullable<Double>` |  |
| 11 | Registros1320 | `List<Registro1320>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
