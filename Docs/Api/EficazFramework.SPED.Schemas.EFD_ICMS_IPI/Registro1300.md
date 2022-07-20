#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro1300 Class

Movimentação Diária de Combustíveis

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoCombustivel0200 | `String` |  |
| 03 | DataFechamento | `Nullable<DateTime>` |  |
| 04 | EstoqueAbertura | `Nullable<Double>` |  |
| 05 | VolumeEntradas | `Nullable<Double>` |  |
| 06 | VolumeDisponivel | `Nullable<Double>` | Estoque Abertura + Volume Entradas |
| 07 | VolumeSaidas | `Nullable<Double>` |  |
| 08 | EstoqueEscritural | `Nullable<Double>` | Volume Disponível - Volume Saídas |
| 09 | AjustesPerda | `Nullable<Double>` |  |
| 10 | AjustesGanho | `Nullable<Double>` |  |
| 11 | EstoqueFechamento | `Nullable<Double>` |  |
| 12 | Registros1310 | `List<Registro1310>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
