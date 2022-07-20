#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2')

## ResultadoGuiaGNRE Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | situacaoGuia | `SituacaoGuia` |  |
| 03 | c01_UfFavorecida | `Nullable<UF>` |  |
| 04 | c02_receita | `Nullable<Double>` |  |
| 05 | c03_idContribuinteEmitente | `IDEmitente` |  |
| 06 | c04_docOrigem | `String` |  |
| 07 | c05_referencia | `Referencia` |  |
| 08 | c06_valorPrincipal | `String` |  |
| 09 | c07_atualizacaoMonetaria | `String` |  |
| 10 | c08_juros | `String` |  |
| 11 | c09_multa | `String` |  |
| 12 | c10_valorTotal | `String` |  |
| 13 | c14_dataVencimentoDate | `Nullable<DateTime>` |  |
| 14 | c14_dataVencimento | `String` |  |
| 15 | c15_convenio | `String` |  |
| 16 | c16_razaoSocialEmitente | `String` |  |
| 17 | c17_inscricaoEstadualEmitente | `String` |  |
| 18 | c18_enderecoEmitente | `String` |  |
| 19 | c19_municipioEmitente | `String` |  |
| 20 | c20_ufEnderecoEmitente | `String` |  |
| 21 | c21_cepEmitente | `String` |  |
| 22 | c22_telefoneEmitente | `String` |  |
| 23 | c23_informacoes | `String` |  |
| 24 | c25_detalhamentoReceita | `String` |  |
| 25 | c26_produto | `String` |  |
| 26 | c27_tipoIdentificacaoEmitente | `Nullable<Identificacao>` |  |
| 27 | c28_tipoDocOrigem | `String` |  |
| 28 | c29_dataLimitePagamentoDate | `Nullable<DateTime>` |  |
| 29 | c29_dataLimitePagamento | `String` |  |
| 30 | c30_nossoNumero | `String` |  |
| 31 | c33_dataPagamentoDate | `Nullable<DateTime>` |  |
| 32 | c33_dataPagamento | `String` |  |
| 33 | c34_tipoIdentificacaoDestinatario | `Nullable<Identificacao>` |  |
| 34 | c34_tipoIdentificacaoDestinatarioSpecified | `Boolean` |  |
| 35 | c35_idContribuinteDestinatario | `IDDestinatario` |  |
| 36 | c36_inscricaoEstadualDestinatario | `String` |  |
| 37 | c37_razaoSocialDestinatario | `String` |  |
| 38 | c38_municipioDestinatario | `String` |  |
| 39 | c39_camposExtras | `ObservableCollection<CampoExtra>` |  |
| 40 | c42_identificadorGuia | `String` |  |
| 41 | contribuinteEmitente | `Emitente` |  |
| 42 | dataLimitePagamentoDate | `Nullable<DateTime>` |  |
| 43 | dataLimitePagamento | `String` |  |
| 44 | dataPagamentoDate | `Nullable<DateTime>` |  |
| 45 | dataPagamento | `String` |  |
| 46 | identificadorGuia | `String` |  |
| 47 | itensGNRE | `ObservableCollection<DetalhamentoItemGNRE>` |  |
| 48 | tipoGnre | `Nullable<TipoGNRE>` |  |
| 49 | ufFavorecida | `Nullable<UF>` |  |
| 50 | valorGNRE | `String` |  |
| 51 | linhaDigitavel | `String` |  |
| 52 | codigoBarras | `String` |  |
| 53 | motivosRejeicao | `GuiaResultadoMotivo[]` |  |
| 54 | versao | `Versao` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializec01_UfFavorecida() | `Boolean` |  |
| ShouldSerializec02_receita() | `Boolean` |  |
| ShouldSerializec27_tipoIdentificacaoEmitente() | `Boolean` |  |
| ShouldSerializec39_camposExtras() | `Boolean` |  |
| ShouldSerializec42_identificadorGuia() | `Boolean` |  |
| ShouldSerializeufFavorecida() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
