#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2')

## GuiaGNRE Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | c01_UfFavorecida | `Nullable<UF>` |  |
| 03 | c02_receita | `Nullable<Double>` |  |
| 04 | c03_idContribuinteEmitente | `IDEmitente` |  |
| 05 | c04_docOrigem | `String` |  |
| 06 | c05_referencia | `Referencia` |  |
| 07 | c06_valorPrincipal | `String` |  |
| 08 | c10_valorTotal | `String` |  |
| 09 | c14_dataVencimentoDate | `Nullable<DateTime>` |  |
| 10 | c14_dataVencimento | `String` |  |
| 11 | c15_convenio | `String` |  |
| 12 | c16_razaoSocialEmitente | `String` |  |
| 13 | c17_inscricaoEstadualEmitente | `String` |  |
| 14 | c18_enderecoEmitente | `String` |  |
| 15 | c19_municipioEmitente | `String` |  |
| 16 | c20_ufEnderecoEmitente | `String` |  |
| 17 | c21_cepEmitente | `String` |  |
| 18 | c22_telefoneEmitente | `String` |  |
| 19 | c25_detalhamentoReceita | `String` |  |
| 20 | c26_produto | `String` |  |
| 21 | c27_tipoIdentificacaoEmitente | `Nullable<Identificacao>` |  |
| 22 | c28_tipoDocOrigem | `String` |  |
| 23 | c33_dataPagamentoDate | `Nullable<DateTime>` |  |
| 24 | c33_dataPagamento | `String` |  |
| 25 | c34_tipoIdentificacaoDestinatario | `Nullable<Identificacao>` |  |
| 26 | c34_tipoIdentificacaoDestinatarioSpecified | `Boolean` |  |
| 27 | c35_idContribuinteDestinatario | `IDDestinatario` |  |
| 28 | c36_inscricaoEstadualDestinatario | `String` |  |
| 29 | c37_razaoSocialDestinatario | `String` |  |
| 30 | c38_municipioDestinatario | `String` |  |
| 31 | c39_camposExtras | `ObservableCollection<CampoExtra>` |  |
| 32 | c42_identificadorGuia | `String` |  |
| 33 | ufFavorecida | `Nullable<UF>` |  |
| 34 | tipoGnre | `Nullable<TipoGNRE>` |  |
| 35 | contribuinteEmitente | `Emitente` |  |
| 36 | itensGNRE | `ObservableCollection<DetalhamentoItemGNRE>` |  |
| 37 | valorGNRE | `String` |  |
| 38 | dataPagamentoDate | `Nullable<DateTime>` |  |
| 39 | dataPagamento | `String` |  |
| 40 | identificadorGuia | `String` |  |
| 41 | versao | `Versao` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializec01_UfFavorecida() | `Boolean` |  |
| ShouldSerializec02_receita() | `Boolean` |  |
| ShouldSerializec27_tipoIdentificacaoEmitente() | `Boolean` |  |
| ShouldSerializec39_camposExtras() | `Boolean` |  |
| ShouldSerializec42_identificadorGuia() | `Boolean` |  |
| ShouldSerializeufFavorecida() | `Boolean` |  |
| ShouldSerializetipoGnre() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, GuiaGNRE, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, GuiaGNRE) | `Boolean` |  |
| Deserialize(string) | `GuiaGNRE` |  |
| Deserialize(Stream) | `GuiaGNRE` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, GuiaGNRE, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, GuiaGNRE) | `Boolean` |  |
| LoadFrom(Stream) | `GuiaGNRE` |  |
| LoadFromAsync(Stream) | `Task<GuiaGNRE>` |  |
| LoadFromAsync(Stream, bool) | `Task<GuiaGNRE>` |  |
