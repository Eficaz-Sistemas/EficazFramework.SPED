#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## IdentificacaoNFe Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | UF | `OrgaoIBGE` |  |
| 03 | Chave | `String` |  |
| 04 | NaturezaOperacao | `String` |  |
| 05 | FormaDePagamento | `FormaDePagamento` |  |
| 06 | Modelo | `ModeloDocumento` |  |
| 07 | Serie | `Int32` |  |
| 08 | Numero | `Int64` |  |
| 09 | DataEmissao | `Nullable<DateTime>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| 10 | DataEmissaoXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00            Utilize o campo 'DataEmissao' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 11 | DataHoraEmissao | `Nullable<DateTime>` | v3.10 |
| 12 | DataSaidaEntrada | `Nullable<DateTime>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| 13 | DataSaidaEntradaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00            Utilize o campo 'DataSaidaEntrada' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 14 | HoraSaidaEntrada | `Nullable<TimeSpan>` | Fornece valores válidos para NFe 2.00 e 3.10 |
| 15 | DataHoraSaidaEntrada | `Nullable<DateTime>` | v3.10 |
| 16 | HoraSaidaEntradaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'HoraSaidaEntrada' (TimeSpan?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 17 | TipoOperacao | `OperacaoNFe` |  |
| 18 | CodigoMunicipio | `String` |  |
| 19 | NotasFiscaisReferenciadas | `List<ReferenciaDocFiscal>` |  |
| 20 | TipoImpressao | `TipoImpressao` |  |
| 21 | FormaEmissao | `FormaEmissao` |  |
| 22 | ChaveDigitoVerificador | `String` |  |
| 23 | Ambiente | `Ambiente` |  |
| 24 | Finalidade | `FinalidadeEmissao` |  |
| 25 | ProcessoDeEmissao | `ProcessoEmissao` |  |
| 26 | VersaoProcessoEmissao | `String` |  |
| 27 | DataHoraContingencia | `Nullable<DateTime>` |  |
| 28 | ConsumidorFinal | `Boolean` |  |
| 29 | TipoAtendimento | `TipoAtendimento` |  |
| 30 | DestinoOperacao | `DestinoOperacao` |  |
| 31 | DataHoraContingenciaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'DataHoraContingencia' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 32 | JustificativaContingencia | `String` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeDataEmissaoXML() | `Boolean` |  |
| ShouldSerializeDataHoraEmissao() | `Boolean` |  |
| ShouldSerializeDataSaidaEntradaXML() | `Boolean` |  |
| ShouldSerializeHoraSaidaEntrada() | `Boolean` |  |
| ShouldSerializeDataHoraSaidaEntrada() | `Boolean` |  |
| ShouldSerializeHoraSaidaEntradaXML() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
