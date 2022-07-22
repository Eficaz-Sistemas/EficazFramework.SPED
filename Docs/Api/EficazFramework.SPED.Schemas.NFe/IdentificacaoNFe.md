#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## IdentificacaoNFe Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| UF | `OrgaoIBGE` |  |
| Chave | `String` |  |
| NaturezaOperacao | `String` |  |
| FormaDePagamento | `FormaDePagamento` |  |
| Modelo | `ModeloDocumento` |  |
| Serie | `Int32` |  |
| Numero | `Int64` |  |
| DataEmissao | `Nullable<DateTime>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| DataEmissaoXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00            Utilize o campo 'DataEmissao' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| DataHoraEmissao | `Nullable<DateTime>` | v3.10 |
| DataSaidaEntrada | `Nullable<DateTime>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| DataSaidaEntradaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00            Utilize o campo 'DataSaidaEntrada' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| HoraSaidaEntrada | `Nullable<TimeSpan>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| DataHoraSaidaEntrada | `Nullable<DateTime>` | v3.10 |
| HoraSaidaEntradaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'HoraSaidaEntrada' (TimeSpan?) para trabalho. Ambos estarão            automaticamente em sincronia |
| TipoOperacao | `OperacaoNFe` |  |
| CodigoMunicipio | `String` |  |
| NotasFiscaisReferenciadas | `List<ReferenciaDocFiscal>` |  |
| TipoImpressao | `TipoImpressao` |  |
| FormaEmissao | `FormaEmissao` |  |
| ChaveDigitoVerificador | `String` |  |
| Ambiente | `Ambiente` |  |
| Finalidade | `FinalidadeEmissao` |  |
| ProcessoDeEmissao | `ProcessoEmissao` |  |
| VersaoProcessoEmissao | `String` |  |
| DataHoraContingencia | `Nullable<DateTime>` |  |
| ConsumidorFinal | `Boolean` |  |
| TipoAtendimento | `TipoAtendimento` |  |
| DestinoOperacao | `DestinoOperacao` |  |
| DataHoraContingenciaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'DataHoraContingencia' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| JustificativaContingencia | `String` |  |

| Methods | |
| :--- | :--- |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.OnPropertyChanged(string)') | |
| [ShouldSerializeDataEmissaoXML()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeDataEmissaoXML().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeDataEmissaoXML()') | |
| [ShouldSerializeDataHoraEmissao()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeDataHoraEmissao().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeDataHoraEmissao()') | |
| [ShouldSerializeDataHoraSaidaEntrada()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeDataHoraSaidaEntrada().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeDataHoraSaidaEntrada()') | |
| [ShouldSerializeDataSaidaEntradaXML()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeDataSaidaEntradaXML().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeDataSaidaEntradaXML()') | |
| [ShouldSerializeHoraSaidaEntrada()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeHoraSaidaEntrada().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeHoraSaidaEntrada()') | |
| [ShouldSerializeHoraSaidaEntradaXML()](EficazFramework.SPED.Schemas.NFe/IdentificacaoNFe/ShouldSerializeHoraSaidaEntradaXML().md 'EficazFramework.SPED.Schemas.NFe.IdentificacaoNFe.ShouldSerializeHoraSaidaEntradaXML()') | |
