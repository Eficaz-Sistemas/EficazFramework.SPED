#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## GuiaGNRE Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | c01_UfFavorecida | `String` |  |
| 03 | c02_receita | `Nullable<Double>` |  |
| 04 | c25_detalhamentoReceita | `String` |  |
| 05 | c26_produto | `String` |  |
| 06 | c27_tipoIdentificacaoEmitente | `Nullable<Identificacao>` |  |
| 07 | c03_idContribuinteEmitente | `Emitente` |  |
| 08 | c28_tipoDocOrigem | `String` |  |
| 09 | c04_docOrigem | `String` |  |
| 10 | c06_valorPrincipal | `String` |  |
| 11 | c10_valorTotal | `String` |  |
| 12 | c14_dataVencimentoDate | `Nullable<DateTime>` |  |
| 13 | c14_dataVencimento | `String` |  |
| 14 | c15_convenio | `String` |  |
| 15 | c16_razaoSocialEmitente | `String` |  |
| 16 | c17_inscricaoEstadualEmitente | `String` |  |
| 17 | c18_enderecoEmitente | `String` |  |
| 18 | c19_municipioEmitente | `String` |  |
| 19 | c20_ufEnderecoEmitente | `String` |  |
| 20 | c21_cepEmitente | `String` |  |
| 21 | c22_telefoneEmitente | `String` |  |
| 22 | c34_tipoIdentificacaoDestinatario | `Identificacao` |  |
| 23 | c34_tipoIdentificacaoDestinatarioSpecified | `Boolean` |  |
| 24 | c35_idContribuinteDestinatario | `Destinatario` |  |
| 25 | c36_inscricaoEstadualDestinatario | `String` |  |
| 26 | c37_razaoSocialDestinatario | `String` |  |
| 27 | c38_municipioDestinatario | `String` |  |
| 28 | c33_dataPagamentoDate | `Nullable<DateTime>` |  |
| 29 | c33_dataPagamento | `String` |  |
| 30 | c05_referencia | `Referencia` |  |
| 31 | c39_camposExtras | `ObservableCollection<CampoExtra>` |  |
| 32 | c42_identificadorGuia | `String` |  |
| 33 | c07_atualizacaoMonetaria | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializec02_receita() | `Boolean` |  |
| ShouldSerializec27_tipoIdentificacaoEmitente() | `Boolean` |  |
| ShouldSerializec39_camposExtras() | `Boolean` |  |
| ShouldSerializec42_identificadorGuia() | `Boolean` |  |
| ShouldSerializec07_atualizacaoMonetaria() | `Boolean` |  |
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
