#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroY600 Class

Identificação e Remuneração de Sócios, Titulares, Dirigentes e Conselheiros
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | DataAlteracao | `Nullable<DateTime>` |  |
| 03 | DataSaida | `Nullable<DateTime>` |  |
| 04 | Pais | `String` |  |
| 05 | IndicadorQualificacao | `String` | PF = Pessoa Física            PJ = Pessoa Jurídica            FI = FUndo de Investimento |
| 06 | CNPJ_CPF | `String` |  |
| 07 | Nome | `String` |  |
| 08 | Qualificacao | `String` |  |
| 09 | PercentualCapitalTotal | `Nullable<Double>` |  |
| 10 | PercentualCapitalVotante | `Nullable<Double>` |  |
| 11 | CPF_ResponsavelLegal | `String` |  |
| 12 | QualificacaoResponsavelLegal | `String` | 01 - Procurador            02 - Curador            03 - Mãe            04 - Pai            05 - Tutor            06 - Outro |
| 13 | ValorRemuneracao | `Nullable<Double>` |  |
| 14 | ValorLucrosDividendos | `Nullable<Double>` |  |
| 15 | ValorJurosCapitalProprio | `Nullable<Double>` |  |
| 16 | ValorDemaisRendimentos | `Nullable<Double>` |  |
| 17 | ValorIR_Retido | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
