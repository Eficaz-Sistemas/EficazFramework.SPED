#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro1300 Class

Movimentação Diária de Combustíveis

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | CodigoCombustivel0200 |  |
| 03 | DataFechamento |  |
| 04 | EstoqueAbertura |  |
| 05 | VolumeEntradas |  |
| 06 | VolumeDisponivel | Estoque Abertura + Volume Entradas |
| 07 | VolumeSaidas |  |
| 08 | EstoqueEscritural | Volume Disponível - Volume Saídas |
| 09 | AjustesPerda |  |
| 10 | AjustesGanho |  |
| 11 | EstoqueFechamento |  |
| 12 | Registros1310 |  |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
