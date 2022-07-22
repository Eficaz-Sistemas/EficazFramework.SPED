#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFSe.Common](EficazFramework.SPED.Schemas.NFSe.Common.md 'EficazFramework.SPED.Schemas.NFSe.Common')

## tcInfNfse Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Numero | `String` |  |
| CodigoVerificacao | `String` |  |
| DataEmissao | `DateTime` |  |
| IdentificacaoRps | `tcIdentificacaoRps` |  |
| IdentificacaoNfse | `tcIdentificacaoNfse` |  |
| DataEmissaoRpsString | `String` |  |
| DataEmissaoRps | `Nullable<DateTime>` |  |
| DataEmissaoRpsSpecified | `Boolean` |  |
| NaturezaOperacao | `Int32` |  |
| RegimeEspecialTributacao | `Int32` |  |
| RegimeEspecialTributacaoSpecified | `Boolean` |  |
| OptanteSimplesNacional | `Int32` |  |
| IncentivadorCultural | `Int32` |  |
| Competencia | `String` |  |
| NfseSubstituida | `NfseSubstituida` |  |
| OutrasInformacoes | `String` |  |
| Servico | `tcDadosServico` |  |
| ValorCredito | `Decimal` |  |
| ValorCreditoSpecified | `Boolean` |  |
| PrestadorServico | `tcDadosPrestador` |  |
| Prestador | `tcDadosPrestador` | ATENÇÃO: Disponível apenas no padrão ABRASF. Outros layoutes retornarão NULL |
| TomadorServico | `tcDadosTomador` |  |
| Tomador | `tcDadosTomador` | ATENÇÃO: Disponível apenas no padrão ABRASF. Outros layoutes retornarão NULL |
| IntermediarioServico | `tcIdentificacaoIntermediarioServico` |  |
| OrgaoGerador | `tcIdentificacaoOrgaoGerador` |  |
| ConstrucaoCivil | `tcDadosConstrucaoCivil` |  |
| Id | `String` |  |

| Methods | |
| :--- | :--- |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFSe.Common/tcInfNfse/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFSe.Common.tcInfNfse.OnPropertyChanged(string)') | |
