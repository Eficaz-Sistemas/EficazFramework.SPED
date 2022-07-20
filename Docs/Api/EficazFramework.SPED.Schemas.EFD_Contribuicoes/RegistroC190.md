#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Contribuicoes](EficazFramework.SPED.Schemas.EFD_Contribuicoes.md 'EficazFramework.SPED.Schemas.EFD_Contribuicoes')

## RegistroC190 Class

Consolidação de Notas Fiscais Eletrônicas (Código 55) - Operações  
de Aquisição com Direito a Crédito, e Operações de Devolução de  
Compras e Vendas

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoModeloDocs | `String` |  |
| 03 | DataInicialRefConsolidacao | `Nullable<DateTime>` |  |
| 04 | DataFinalRefConsolidacao | `Nullable<DateTime>` |  |
| 05 | CodigoItem | `String` |  |
| 06 | CodigoNCM | `String` |  |
| 07 | CodigoEXTIPI | `String` |  |
| 08 | VrTotalItem | `Nullable<Double>` |  |
| 09 | RegistrosC191 | `List<RegistroC191>` |  |
| 10 | RegistrosC195 | `List<RegistroC195>` |  |
| 11 | RegistrosC198 | `List<RegistroC198>` |  |
| 12 | RegistrosC199 | `List<RegistroC199>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
