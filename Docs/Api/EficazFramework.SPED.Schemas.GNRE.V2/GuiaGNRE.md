#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2')

## GuiaGNRE Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | c01_UfFavorecida |  |
| 03 | c02_receita |  |
| 04 | c03_idContribuinteEmitente |  |
| 05 | c04_docOrigem |  |
| 06 | c05_referencia |  |
| 07 | c06_valorPrincipal |  |
| 08 | c10_valorTotal |  |
| 09 | c14_dataVencimentoDate |  |
| 10 | c14_dataVencimento |  |
| 11 | c15_convenio |  |
| 12 | c16_razaoSocialEmitente |  |
| 13 | c17_inscricaoEstadualEmitente |  |
| 14 | c18_enderecoEmitente |  |
| 15 | c19_municipioEmitente |  |
| 16 | c20_ufEnderecoEmitente |  |
| 17 | c21_cepEmitente |  |
| 18 | c22_telefoneEmitente |  |
| 19 | c25_detalhamentoReceita |  |
| 20 | c26_produto |  |
| 21 | c27_tipoIdentificacaoEmitente |  |
| 22 | c28_tipoDocOrigem |  |
| 23 | c33_dataPagamentoDate |  |
| 24 | c33_dataPagamento |  |
| 25 | c34_tipoIdentificacaoDestinatario |  |
| 26 | c34_tipoIdentificacaoDestinatarioSpecified |  |
| 27 | c35_idContribuinteDestinatario |  |
| 28 | c36_inscricaoEstadualDestinatario |  |
| 29 | c37_razaoSocialDestinatario |  |
| 30 | c38_municipioDestinatario |  |
| 31 | c39_camposExtras |  |
| 32 | c42_identificadorGuia |  |
| 33 | ufFavorecida |  |
| 34 | tipoGnre |  |
| 35 | contribuinteEmitente |  |
| 36 | itensGNRE |  |
| 37 | valorGNRE |  |
| 38 | dataPagamentoDate |  |
| 39 | dataPagamento |  |
| 40 | identificadorGuia |  |
| 41 | versao |  |
### Methods

| Name | |
| :--- | :--- |
| ShouldSerializec01_UfFavorecida() |  |
| ShouldSerializec02_receita() |  |
| ShouldSerializec27_tipoIdentificacaoEmitente() |  |
| ShouldSerializec39_camposExtras() |  |
| ShouldSerializec42_identificadorGuia() |  |
| ShouldSerializeufFavorecida() |  |
| ShouldSerializetipoGnre() |  |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, GuiaGNRE, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, GuiaGNRE) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, GuiaGNRE, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, GuiaGNRE) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
