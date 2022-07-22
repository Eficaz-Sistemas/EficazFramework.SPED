#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.GNRE.V2](EficazFramework.SPED.Schemas.GNRE.V2.md 'EficazFramework.SPED.Schemas.GNRE.V2')

## GuiaGNRE Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| c01_UfFavorecida | `Nullable<UF>` |  |
| c02_receita | `Nullable<Double>` |  |
| c03_idContribuinteEmitente | `IDEmitente` |  |
| c04_docOrigem | `String` |  |
| c05_referencia | `Referencia` |  |
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
| c25_detalhamentoReceita | `String` |  |
| c26_produto | `String` |  |
| c27_tipoIdentificacaoEmitente | `Nullable<Identificacao>` |  |
| c28_tipoDocOrigem | `String` |  |
| c33_dataPagamentoDate | `Nullable<DateTime>` |  |
| c33_dataPagamento | `String` |  |
| c34_tipoIdentificacaoDestinatario | `Nullable<Identificacao>` |  |
| c34_tipoIdentificacaoDestinatarioSpecified | `Boolean` |  |
| c35_idContribuinteDestinatario | `IDDestinatario` |  |
| c36_inscricaoEstadualDestinatario | `String` |  |
| c37_razaoSocialDestinatario | `String` |  |
| c38_municipioDestinatario | `String` |  |
| c39_camposExtras | `ObservableCollection<CampoExtra>` |  |
| c42_identificadorGuia | `String` |  |
| ufFavorecida | `Nullable<UF>` |  |
| tipoGnre | `Nullable<TipoGNRE>` |  |
| contribuinteEmitente | `Emitente` |  |
| itensGNRE | `ObservableCollection<DetalhamentoItemGNRE>` |  |
| valorGNRE | `String` |  |
| dataPagamentoDate | `Nullable<DateTime>` |  |
| dataPagamento | `String` |  |
| identificadorGuia | `String` |  |
| versao | `Versao` |  |

| Methods | |
| :--- | :--- |
| [CanDeserialize(string, GuiaGNRE)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/CanDeserialize(string,GuiaGNRE).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.CanDeserialize(string, EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE)') | |
| [CanDeserialize(string, GuiaGNRE, Exception)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/CanDeserialize(string,GuiaGNRE,Exception).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.CanDeserialize(string, EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE, System.Exception)') | Deserializes workflow markup into an TNfeProc object |
| [CanLoadFrom(Stream, GuiaGNRE)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/CanLoadFrom(Stream,GuiaGNRE).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE)') | |
| [CanLoadFrom(Stream, GuiaGNRE, Exception)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/CanLoadFrom(Stream,GuiaGNRE,Exception).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE, System.Exception)') | Deserializes xml markup from file into an TNfeProc object |
| [CanSaveToFile(Stream, Exception)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/CanSaveToFile(Stream,Exception).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.CanSaveToFile(System.IO.Stream, System.Exception)') | Serializes current TNfeProc object into file |
| [Deserialize(string)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/Deserialize(string).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.Deserialize(string)') | |
| [Deserialize(Stream)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/Deserialize(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.Deserialize(System.IO.Stream)') | |
| [LoadFrom(Stream)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/LoadFrom(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.LoadFrom(System.IO.Stream)') | |
| [LoadFromAsync(Stream)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/LoadFromAsync(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.LoadFromAsync(System.IO.Stream)') | |
| [LoadFromAsync(Stream, bool)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/LoadFromAsync(Stream,bool).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.LoadFromAsync(System.IO.Stream, bool)') | |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.OnPropertyChanged(string)') | |
| [SaveTo(Stream)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/SaveTo(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.SaveTo(System.IO.Stream)') | |
| [SaveToAsync(Stream)](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/SaveToAsync(Stream).md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.SaveToAsync(System.IO.Stream)') | |
| [Serialize()](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/Serialize().md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.Serialize()') | Serializes current TNfeProc object into an XML document |
| [ShouldSerializec01_UfFavorecida()](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/ShouldSerializec01_UfFavorecida().md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.ShouldSerializec01_UfFavorecida()') | |
| [ShouldSerializec02_receita()](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/ShouldSerializec02_receita().md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.ShouldSerializec02_receita()') | |
| [ShouldSerializec27_tipoIdentificacaoEmitente()](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/ShouldSerializec27_tipoIdentificacaoEmitente().md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.ShouldSerializec27_tipoIdentificacaoEmitente()') | |
| [ShouldSerializec39_camposExtras()](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/ShouldSerializec39_camposExtras().md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.ShouldSerializec39_camposExtras()') | |
| [ShouldSerializec42_identificadorGuia()](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/ShouldSerializec42_identificadorGuia().md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.ShouldSerializec42_identificadorGuia()') | |
| [ShouldSerializetipoGnre()](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/ShouldSerializetipoGnre().md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.ShouldSerializetipoGnre()') | |
| [ShouldSerializeufFavorecida()](EficazFramework.SPED.Schemas.GNRE.V2/GuiaGNRE/ShouldSerializeufFavorecida().md 'EficazFramework.SPED.Schemas.GNRE.V2.GuiaGNRE.ShouldSerializeufFavorecida()') | |
