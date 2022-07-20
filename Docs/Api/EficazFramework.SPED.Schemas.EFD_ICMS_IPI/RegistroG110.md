#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroG110 Class

ICMS - Ativo Permanente - CIAP

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | DataInicial | `Nullable<DateTime>` |  |
| 03 | DataFinal | `Nullable<DateTime>` |  |
| 04 | SaldoInicial | `Nullable<Double>` |  |
| 05 | SomatoriosParcelas | `Nullable<Double>` | Correspondente ao campo 10 do Registro G125 |
| 06 | SaidasTributadasOuExportacao | `Nullable<Double>` |  |
| 07 | TotalSaidas | `Nullable<Double>` |  |
| 08 | IndiceParticipacao | `Nullable<Double>` |  |
| 09 | ICMSApropriado | `Nullable<Double>` |  |
| 10 | SomaICMSOutrosCreditos | `Nullable<Double>` | Correspondente ao campo 09 do Registro G126 |
| 11 | RegistrosG125 | `List<RegistroG125>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
