#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## IdentificacaoNFe Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| UF | `OrgaoIBGE` |  |
| Chave | `String` |  |
| NaturezaOperacao | `String` |  |
| FormaDePagamento | `Nullable<FormaDePagamento>` |  |
| Modelo | `ModeloDocumento` |  |
| Serie | `Int32` |  |
| Numero | `Int64` |  |
| DataEmissao | `Nullable<DateTime>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| DataEmissaoXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00            Utilize o campo 'DataEmissao' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| DataHoraEmissao | `Nullable<DateTime>` |  |
| DataHoraEmissaoXml | `String` |  |
| DataSaidaEntrada | `Nullable<DateTime>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| DataSaidaEntradaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00            Utilize o campo 'DataSaidaEntrada' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| HoraSaidaEntrada | `Nullable<TimeSpan>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| DataHoraSaidaEntrada | `Nullable<DateTime>` |  |
| DataHoraSaidaEntradaXml | `String` |  |
| HoraSaidaEntradaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'HoraSaidaEntrada' (TimeSpan?) para trabalho. Ambos estarão            automaticamente em sincronia |
| TipoOperacao | `OperacaoNFe` |  |
| DestinoOperacao | `DestinoOperacao` |  |
| CodigoMunicipio | `String` |  |
| NotasFiscaisReferenciadas | `List<ReferenciaDocFiscal>` |  |
| TipoImpressao | `TipoImpressao` |  |
| FormaEmissao | `FormaEmissao` |  |
| ChaveDigitoVerificador | `String` |  |
| Ambiente | `Ambiente` |  |
| Finalidade | `FinalidadeEmissao` |  |
| ConsumidorFinal | `IndicadorConsumidorFinal` |  |
| TipoAtendimento | `TipoAtendimento` |  |
| ProcessoDeEmissao | `ProcessoEmissao` |  |
| VersaoProcessoEmissao | `String` |  |
| DataHoraContingencia | `Nullable<DateTime>` |  |
| DataHoraContingenciaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'DataHoraContingencia' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| JustificativaContingencia | `String` |  |

| Methods | |
| :--- | :--- |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.OnPropertyChanged(string)') | |
| [ShouldSerializeDataEmissaoXML()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeDataEmissaoXML().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeDataEmissaoXML()') | |
| [ShouldSerializeDataHoraEmissaoXml()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeDataHoraEmissaoXml().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeDataHoraEmissaoXml()') | |
| [ShouldSerializeDataHoraSaidaEntradaXml()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeDataHoraSaidaEntradaXml().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeDataHoraSaidaEntradaXml()') | |
| [ShouldSerializeDataSaidaEntradaXML()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeDataSaidaEntradaXML().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeDataSaidaEntradaXML()') | |
| [ShouldSerializeFormaDePagamento()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeFormaDePagamento().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeFormaDePagamento()') | |
| [ShouldSerializeHoraSaidaEntrada()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeHoraSaidaEntrada().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeHoraSaidaEntrada()') | |
| [ShouldSerializeHoraSaidaEntradaXML()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeHoraSaidaEntradaXML().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeHoraSaidaEntradaXML()') | |
