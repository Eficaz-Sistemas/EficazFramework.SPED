#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC420 Class

Registro Totalizador Parcial da Redução Z

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoTotalizador | `String` |  |
| 03 | ValorAcumulado | `Nullable<Double>` |  |
| 04 | Numero | `Nullable<Int32>` | Número do totalizador quando ocorrer mais de uma situação com a mesma carga tributária efetiva. |
| 05 | Descricao | `String` |  |
| 06 | TipoRegistro | `TipoC420` |  |
| 07 | CompoeValorContabil | `Boolean` |  |
| 08 | AliquotaEfetiva | `Double` |  |
| 09 | RegistrosC425 | `List<RegistroC425>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
