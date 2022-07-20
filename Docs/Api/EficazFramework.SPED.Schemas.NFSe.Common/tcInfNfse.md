#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcInfNfse Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Numero | `String` |  |
| 03 | CodigoVerificacao | `String` |  |
| 04 | DataEmissao | `DateTime` |  |
| 05 | IdentificacaoRps | `tcIdentificacaoRps` |  |
| 06 | IdentificacaoNfse | `tcIdentificacaoNfse` |  |
| 07 | DataEmissaoRpsString | `String` |  |
| 08 | DataEmissaoRps | `Nullable<DateTime>` |  |
| 09 | DataEmissaoRpsSpecified | `Boolean` |  |
| 10 | NaturezaOperacao | `Int32` |  |
| 11 | RegimeEspecialTributacao | `Int32` |  |
| 12 | RegimeEspecialTributacaoSpecified | `Boolean` |  |
| 13 | OptanteSimplesNacional | `Int32` |  |
| 14 | IncentivadorCultural | `Int32` |  |
| 15 | Competencia | `String` |  |
| 16 | NfseSubstituida | `NfseSubstituida` |  |
| 17 | OutrasInformacoes | `String` |  |
| 18 | Servico | `tcDadosServico` |  |
| 19 | ValorCredito | `Decimal` |  |
| 20 | ValorCreditoSpecified | `Boolean` |  |
| 21 | PrestadorServico | `tcDadosPrestador` |  |
| 22 | Prestador | `tcDadosPrestador` | ATENÇÃO: Disponível apenas no padrão ABRASF. Outros layoutes retornarão NULL |
| 23 | TomadorServico | `tcDadosTomador` |  |
| 24 | Tomador | `tcDadosTomador` | ATENÇÃO: Disponível apenas no padrão ABRASF. Outros layoutes retornarão NULL |
| 25 | IntermediarioServico | `tcIdentificacaoIntermediarioServico` |  |
| 26 | OrgaoGerador | `tcIdentificacaoOrgaoGerador` |  |
| 27 | ConstrucaoCivil | `tcDadosConstrucaoCivil` |  |
| 28 | Id | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| OnPropertyChanged(string) | `Void` |  |
