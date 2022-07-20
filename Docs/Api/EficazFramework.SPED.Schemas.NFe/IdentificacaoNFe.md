#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## IdentificacaoNFe Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | UF |  |
| 03 | Chave |  |
| 04 | NaturezaOperacao |  |
| 05 | FormaDePagamento |  |
| 06 | Modelo |  |
| 07 | Serie |  |
| 08 | Numero |  |
| 09 | DataEmissao | Fornece valores válidos para NFe 2.00 e 3.10 |
| 10 | DataEmissaoXML | Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00            Utilize o campo 'DataEmissao' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 11 | DataHoraEmissao | v3.10 |
| 12 | DataSaidaEntrada | Fornece valores válidos para NFe 2.00 e 3.10 |
| 13 | DataSaidaEntradaXML | Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00            Utilize o campo 'DataSaidaEntrada' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 14 | HoraSaidaEntrada | Fornece valores válidos para NFe 2.00 e 3.10 |
| 15 | DataHoraSaidaEntrada | v3.10 |
| 16 | HoraSaidaEntradaXML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'HoraSaidaEntrada' (TimeSpan?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 17 | TipoOperacao |  |
| 18 | CodigoMunicipio |  |
| 19 | NotasFiscaisReferenciadas |  |
| 20 | TipoImpressao |  |
| 21 | FormaEmissao |  |
| 22 | ChaveDigitoVerificador |  |
| 23 | Ambiente |  |
| 24 | Finalidade |  |
| 25 | ProcessoDeEmissao |  |
| 26 | VersaoProcessoEmissao |  |
| 27 | DataHoraContingencia |  |
| 28 | ConsumidorFinal |  |
| 29 | TipoAtendimento |  |
| 30 | DestinoOperacao |  |
| 31 | DataHoraContingenciaXML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'DataHoraContingencia' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 32 | JustificativaContingencia |  |
### Methods

| Name | |
| :--- | :--- |
| ShouldSerializeDataEmissaoXML() |  |
| ShouldSerializeDataHoraEmissao() |  |
| ShouldSerializeDataSaidaEntradaXML() |  |
| ShouldSerializeHoraSaidaEntrada() |  |
| ShouldSerializeDataHoraSaidaEntrada() |  |
| ShouldSerializeHoraSaidaEntradaXML() |  |
| OnPropertyChanged(string) |  |
