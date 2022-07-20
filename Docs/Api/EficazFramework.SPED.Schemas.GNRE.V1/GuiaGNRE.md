#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## GuiaGNRE Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | c01_UfFavorecida |  |
| 03 | c02_receita |  |
| 04 | c25_detalhamentoReceita |  |
| 05 | c26_produto |  |
| 06 | c27_tipoIdentificacaoEmitente |  |
| 07 | c03_idContribuinteEmitente |  |
| 08 | c28_tipoDocOrigem |  |
| 09 | c04_docOrigem |  |
| 10 | c06_valorPrincipal |  |
| 11 | c10_valorTotal |  |
| 12 | c14_dataVencimentoDate |  |
| 13 | c14_dataVencimento |  |
| 14 | c15_convenio |  |
| 15 | c16_razaoSocialEmitente |  |
| 16 | c17_inscricaoEstadualEmitente |  |
| 17 | c18_enderecoEmitente |  |
| 18 | c19_municipioEmitente |  |
| 19 | c20_ufEnderecoEmitente |  |
| 20 | c21_cepEmitente |  |
| 21 | c22_telefoneEmitente |  |
| 22 | c34_tipoIdentificacaoDestinatario |  |
| 23 | c34_tipoIdentificacaoDestinatarioSpecified |  |
| 24 | c35_idContribuinteDestinatario |  |
| 25 | c36_inscricaoEstadualDestinatario |  |
| 26 | c37_razaoSocialDestinatario |  |
| 27 | c38_municipioDestinatario |  |
| 28 | c33_dataPagamentoDate |  |
| 29 | c33_dataPagamento |  |
| 30 | c05_referencia |  |
| 31 | c39_camposExtras |  |
| 32 | c42_identificadorGuia |  |
| 33 | c07_atualizacaoMonetaria |  |
### Methods

| Name | |
| :--- | :--- |
| ShouldSerializec02_receita() |  |
| ShouldSerializec27_tipoIdentificacaoEmitente() |  |
| ShouldSerializec39_camposExtras() |  |
| ShouldSerializec42_identificadorGuia() |  |
| ShouldSerializec07_atualizacaoMonetaria() |  |
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
