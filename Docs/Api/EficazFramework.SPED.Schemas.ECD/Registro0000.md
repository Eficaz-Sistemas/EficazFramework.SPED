#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECD](EficazFramework.SPED.Schemas.ECD.md 'EficazFramework.SPED.Schemas.ECD')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação do Empresário ou da Sociedade

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | DataInicial | `Nullable<DateTime>` |  |
| 03 | DataFinal | `Nullable<DateTime>` |  |
| 04 | NomeEmpresarialPJ | `String` |  |
| 05 | CNPJ | `String` |  |
| 06 | UF | `String` |  |
| 07 | IEPj | `String` |  |
| 08 | CodMunicipio | `String` |  |
| 09 | InscMunicipal | `String` |  |
| 10 | IndicadorSitEspecial | `String` |  |
| 11 | IndicadorSitInicioPeriodo | `String` |  |
| 12 | IndicadorExistNire | `IndicadorExistNire` |  |
| 13 | IndicadorFinalidadeEscrit | `IndicadorFinalidadeEscrit` |  |
| 14 | CodigoHash | `String` |  |
| 15 | IndicadorGrandePorte | `IndicadorGrandePorte` |  |
| 16 | IndicadorTipoECD | `IndicadorTipoECD` |  |
| 17 | IdentificacaoSCP | `String` |  |
| 18 | IdentificacaoMoedaFuncional | `Boolean` |  |
| 19 | EscritContConsolidades | `Boolean` |  |
| 20 | IndicadorCentralizada | `Boolean` |  |
| 21 | IndicadorMudancaPlanoContas | `Boolean` |  |
| 22 | CodigoPlanoContasReferencial | `Int32` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
