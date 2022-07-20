#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro1601 Class

REGISTRO 1600: OPERAÇÕES COM INSTRUMENTOS DE PAGAMENTOS ELETRÔNICOS

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoParticipante | `String` |  |
| 03 | CodigoParticipanteIntermediador | `String` |  |
| 04 | TotalBrutoIncIcms | `Nullable<Double>` | Valor total bruto das vendas e/ou prestações de serviços no campo de incidência Do ICMS,             incluindo operações com imunidade Do imposto |
| 05 | TotalBrutoIncIss | `Nullable<Double>` | Valor total bruto das prestações de serviços no campo de incidência Do ISS |
| 06 | TotalOutros | `Nullable<Double>` | Valor total de operações deduzido dos valores dos campos TotalBrutoIncIcms e TotalBrutoIncIss |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
