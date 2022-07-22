#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V1](EficazFramework.SPED.Schemas.GNRE.V1.md 'EficazFramework.SPED.Schemas.GNRE.V1')

## GuiaGNRE Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| c01_UfFavorecida | `String` |  |
| c02_receita | `Nullable<Double>` |  |
| c25_detalhamentoReceita | `String` |  |
| c26_produto | `String` |  |
| c27_tipoIdentificacaoEmitente | `Nullable<Identificacao>` |  |
| c03_idContribuinteEmitente | `Emitente` |  |
| c28_tipoDocOrigem | `String` |  |
| c04_docOrigem | `String` |  |
| c06_valorPrincipal | `String` |  |
| c10_valorTotal | `String` |  |
| c14_dataVencimentoDate | `Nullable<DateTime>` |  |
| c14_dataVencimento | `String` |  |
| c15_convenio | `String` |  |
| c16_razaoSocialEmitente | `String` |  |
| c17_inscricaoEstadualEmitente | `String` |  |
| c18_enderecoEmitente | `String` |  |
| c19_municipioEmitente | `String` |  |
| c20_ufEnderecoEmitente | `String` |  |
| c21_cepEmitente | `String` |  |
| c22_telefoneEmitente | `String` |  |
| c34_tipoIdentificacaoDestinatario | `Identificacao` |  |
| c34_tipoIdentificacaoDestinatarioSpecified | `Boolean` |  |
| c35_idContribuinteDestinatario | `Destinatario` |  |
| c36_inscricaoEstadualDestinatario | `String` |  |
| c37_razaoSocialDestinatario | `String` |  |
| c38_municipioDestinatario | `String` |  |
| c33_dataPagamentoDate | `Nullable<DateTime>` |  |
| c33_dataPagamento | `String` |  |
| c05_referencia | `Referencia` |  |
| c39_camposExtras | `ObservableCollection<CampoExtra>` |  |
| c42_identificadorGuia | `String` |  |
| c07_atualizacaoMonetaria | `Nullable<Double>` |  |

| Methods | |
| :--- | :--- |
| [CanDeserialize(string, GuiaGNRE)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/CanDeserialize(string,GuiaGNRE).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.CanDeserialize(string, EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE)') | |
| [CanDeserialize(string, GuiaGNRE, Exception)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/CanDeserialize(string,GuiaGNRE,Exception).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.CanDeserialize(string, EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE, System.Exception)') | Deserializes workflow markup into an TNfeProc object |
| [CanLoadFrom(Stream, GuiaGNRE)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/CanLoadFrom(Stream,GuiaGNRE).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE)') | |
| [CanLoadFrom(Stream, GuiaGNRE, Exception)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/CanLoadFrom(Stream,GuiaGNRE,Exception).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE, System.Exception)') | Deserializes xml markup from file into an TNfeProc object |
| [CanSaveToFile(Stream, Exception)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/CanSaveToFile(Stream,Exception).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.CanSaveToFile(System.IO.Stream, System.Exception)') | Serializes current TNfeProc object into file |
| [Deserialize(string)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/Deserialize(string).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.Deserialize(string)') | |
| [Deserialize(Stream)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/Deserialize(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.Deserialize(System.IO.Stream)') | |
| [LoadFrom(Stream)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/LoadFrom(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.LoadFrom(System.IO.Stream)') | |
| [LoadFromAsync(Stream)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/LoadFromAsync(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.LoadFromAsync(System.IO.Stream)') | |
| [LoadFromAsync(Stream, bool)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/LoadFromAsync(Stream,bool).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.LoadFromAsync(System.IO.Stream, bool)') | |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.OnPropertyChanged(string)') | |
| [SaveTo(Stream)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/SaveTo(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.SaveTo(System.IO.Stream)') | |
| [SaveToAsync(Stream)](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/SaveToAsync(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.SaveToAsync(System.IO.Stream)') | |
| [Serialize()](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/Serialize().md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.Serialize()') | Serializes current TNfeProc object into an XML document |
| [ShouldSerializec02_receita()](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/ShouldSerializec02_receita().md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.ShouldSerializec02_receita()') | |
| [ShouldSerializec07_atualizacaoMonetaria()](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/ShouldSerializec07_atualizacaoMonetaria().md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.ShouldSerializec07_atualizacaoMonetaria()') | |
| [ShouldSerializec27_tipoIdentificacaoEmitente()](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/ShouldSerializec27_tipoIdentificacaoEmitente().md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.ShouldSerializec27_tipoIdentificacaoEmitente()') | |
| [ShouldSerializec39_camposExtras()](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/ShouldSerializec39_camposExtras().md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.ShouldSerializec39_camposExtras()') | |
| [ShouldSerializec42_identificadorGuia()](EficazFramework.SPED.Schemas.GNRE.V1/GuiaGNRE/ShouldSerializec42_identificadorGuia().md 'EficazFramework.SPED.Schemas.GNRE.V1.GuiaGNRE.ShouldSerializec42_identificadorGuia()') | |
