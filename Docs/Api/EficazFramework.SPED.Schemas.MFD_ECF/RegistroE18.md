#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.MFD_ECF](EficazFramework.SPED.Schemas.MFD_ECF.md 'EficazFramework.SPED.Schemas.MFD_ECF')

## RegistroE18 Class

Detalhe da Redução Z - Meios de Pagamenteo e Troco

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroFabricacaoECF | `String` |  |
| 03 | MFAdicional | `String` |  |
| 04 | Modelo | `String` |  |
| 05 | NumeroUsuario | `Nullable<Int32>` |  |
| 06 | CRZ | `Nullable<Int32>` |  |
| 07 | DescricaoMeioPagto | `String` |  |
| 08 | ValorAcumulado | `Nullable<Double>` |  |
| 09 | FormaPagamento | `FormaPagamento` |  |
| 10 | ValorAcumuladoAjustado | `Double` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
