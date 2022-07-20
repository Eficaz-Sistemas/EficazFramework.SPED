#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC186 Class

Informações complementares das operações de devolução de entradas de mercadorias sujeitas à  
substituição tributária(código 01, 1B, 04 e 55).

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroItem | `Nullable<Int16>` |  |
| 03 | CodigoProduto | `String` |  |
| 04 | Origem | `OrigemMercadoria` |  |
| 05 | CST_ICMS | `CST_ICMS` |  |
| 06 | CFOP | `String` |  |
| 07 | CodMotivoRestituicao | `String` |  |
| 08 | QuantidadeItem | `Nullable<Double>` |  |
| 09 | Unidade | `String` |  |
| 10 | EspecieDocEntrada | `String` |  |
| 11 | SerieDocEntrada | `String` |  |
| 12 | NumeroDocEntrada | `Nullable<Int64>` |  |
| 13 | ChaveDocEntrada | `String` |  |
| 14 | DataDocEntrada | `Nullable<DateTime>` |  |
| 15 | NumeroItemDocEntrada | `Nullable<Int16>` |  |
| 16 | VrUnitarioEntrada | `Nullable<Double>` |  |
| 17 | VrUnitarioOpPropriaEntrada | `Nullable<Double>` |  |
| 18 | VrUnitarioBC_STEntrada | `Nullable<Double>` |  |
| 19 | VrUnitarioSTEntrada | `Nullable<Double>` |  |
| 20 | VrUnitarioFCPEntrada | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
