#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação do Empresário ou da Sociedade

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| CNPJ | `String` |  |
| NomeEmpresarial | `String` |  |
| IndicadorSitInicioPeriodo | `SituacaoInicioPeriodo` |  |
| SituacaoEspecial | `SituacaoEspecial` |  |
| PatrimonioRemanescente | `Nullable<Double>` |  |
| DataSituacaoEspecial | `Nullable<DateTime>` |  |
| DataInicial | `Nullable<DateTime>` |  |
| DataFinal | `Nullable<DateTime>` |  |
| Retificadora | `Boolean` | Valores válidos:            S - ECF Retificadora            N - ECF Original            F - ECF Original com mudança de forma de tributação |
| ReciboRetificacao | `String` |  |
| TipoECF | `TipoECF` |  |
| CodigoSCP | `String` |  |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.ECF/Registro0000/EscreveLinha().md 'EficazFramework.SPED.Schemas.ECF.Registro0000.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.ECF/Registro0000/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.ECF.Registro0000.LeParametros(string[])') | |
