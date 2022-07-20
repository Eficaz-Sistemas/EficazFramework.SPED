#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC140 Class

REGISTRO C140: FATURA (CÓDIGO 01)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Indicador_emitente_titulo | `IndicadorEmitente` |  |
| 03 | Indicador_Tipo_titulo | `IndicadorTituloCredito` |  |
| 04 | Descricao_Compl_titulo | `String` |  |
| 05 | Num_tituto | `String` |  |
| 06 | Qtd_Parcelas | `Nullable<Int32>` |  |
| 07 | Vr_titulototal | `Nullable<Double>` |  |
| 08 | RegistrosC141 | `List<RegistroC141>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
