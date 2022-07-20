#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0300 Class

Cadastro de Bens ou Componentes do Ativo Imobilizado

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoProduto | `String` |  |
| 03 | IdentificacaoTipo | `TipoMercadoriaImobilizado` |  |
| 04 | Descricao | `String` |  |
| 05 | CodigoBemPrincipal | `String` |  |
| 06 | CodigoContaContabil | `String` |  |
| 07 | NumeroParcelas | `Nullable<Int32>` |  |
| 08 | Registro0305 | `Registro0305` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
