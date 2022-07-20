#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro1310 Class

Movimentação Diária de Combustíveis por Tanque

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | NumeroTanque |  |
| 03 | EstoqueAbertura |  |
| 04 | VolumeEntradas |  |
| 05 | VolumeDisponivel | Estoque Abertura + Volume Entradas |
| 06 | VolumeSaidas |  |
| 07 | EstoqueEscritural | Volume Disponível - Volume Saídas |
| 08 | AjustesPerda |  |
| 09 | AjustesGanho |  |
| 10 | EstoqueFechamento |  |
| 11 | Registros1320 |  |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
