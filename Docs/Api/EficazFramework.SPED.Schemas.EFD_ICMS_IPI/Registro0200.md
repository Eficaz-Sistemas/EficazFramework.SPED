#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0200 Class

Tabela de Identificação do Item (Produtos e Serviços)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ID | `String` |  |
| 03 | Descricao | `String` |  |
| 04 | CodigoBarras | `String` |  |
| 05 | IDAnterior | `String` |  |
| 06 | UnidadeMedida | `String` |  |
| 07 | TipoItem | `TipoItem` |  |
| 08 | NCM | `String` |  |
| 09 | EX_IPI | `String` |  |
| 10 | Genero | `Nullable<Int64>` |  |
| 11 | ID_Servico | `Nullable<Int64>` |  |
| 12 | AliquotaICMS | `Nullable<Double>` |  |
| 13 | CEST | `String` |  |
| 14 | Registros0205 | `List<Registro0205>` |  |
| 15 | Registros0206 | `Registro0206` |  |
| 16 | Registros0220 | `List<Registro0220>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
