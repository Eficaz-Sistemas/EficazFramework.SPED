#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives')

## Escrituracao Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Blocos | Dicionário contendo o par de Chave / Valor de Todos os Blocos da Escrituração Implementada. <br/>            Permite o acesso aos registros desejados durante etapas de leitura (desserialização) e escrita (serialização). |
| 03 | Versao | Versão para leitura (desserialização) / escrita (serialização) da escrituração. |
| 04 | Progresso | Progresso em percentual da leitura (desserialização). |
| 05 | RegistrosIgnorados | Listagem de regitros que devem ser desconsiderados durante a leitura (desserialização) da escrituração |
| 06 | IsLoading | Obtém ou define se a instância está em estado de trabalho de leitura (desserialização) / escrita (serialização). |
| 07 | RegistroAtual | Obtém o registro que está em análise no momento da leitura (desserialização). |
| 08 | BlocoTotalizador | Obtém ou define o código do Bloco Totalizador da Escrituração implementada, para cálculo automatizado dos registros de totalização. |
| 09 | RegistroTotalizadorCodigo | Obtém ou define o código do Registro Totalizador da Escrituração implementada, para cálculo automatizado de totalização. |
| 10 | RegistroTotalizadorStringFormat | Obtém ou define o formato do registro totalizador da escrituração. |
| 11 | Encoding | Obtém ou define a codificação utilizada na escrituração. Por padrão, é UTF8. |
### Methods

| Name | |
| :--- | :--- |
| LeArquivo(Stream) | Método principal para leitura (desserialização) da escrituração. |
| EscreveArquivo(Stream) | Método principal para escrita (serialização) da escrituração. |
| PrefixoBlocoEncerramento() |  |
| SufixoBlocoEncerramento() |  |
| EncerraArquivo(StreamWriter) |  |
| ProcessaLinha(string) | Método executado durante a leitura (desserialização) do arquivo digital.             É executado a cada linha. |
| LeEmpresaArquivo(Stream) | Retorna o CNPJ do informante do arquivo. |
| ToString() | Por padrão, este override do método .ToString() irá retornar a representação escrita (serializada)             do conteúdo da escrituração por completo. |
