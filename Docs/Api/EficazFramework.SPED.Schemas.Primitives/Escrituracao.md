#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives')

## Escrituracao Class

Classe abstrata que representa uma escrituração do SPED ou de qualquer outra obrigação assessória.  
Contém a instrumentação básica para leitura (desserialização) e escrita (serialização) da escrituração.
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Blocos | `Dictionary<String,Bloco>` | Dicionário contendo o par de Chave / Valor de Todos os Blocos da Escrituração Implementada. <br/>            Permite o acesso aos registros desejados durante etapas de leitura (desserialização) e escrita (serialização). |
| 03 | Versao | `String` | Versão para leitura (desserialização) / escrita (serialização) da escrituração. |
| 04 | Progresso | `Int32` | Progresso em percentual da leitura (desserialização). |
| 05 | RegistrosIgnorados | `List<String>` | Listagem de regitros que devem ser desconsiderados durante a leitura (desserialização) da escrituração |
| 06 | IsLoading | `Boolean` | Obtém ou define se a instância está em estado de trabalho de leitura (desserialização) / escrita (serialização). |
| 07 | RegistroAtual | `String` | Obtém o registro que está em análise no momento da leitura (desserialização). |
| 08 | BlocoTotalizador | `String` | Obtém ou define o código do Bloco Totalizador da Escrituração implementada, para cálculo automatizado dos registros de totalização. |
| 09 | RegistroTotalizadorCodigo | `String` | Obtém ou define o código do Registro Totalizador da Escrituração implementada, para cálculo automatizado de totalização. |
| 10 | RegistroTotalizadorStringFormat | `String` | Obtém ou define o formato do registro totalizador da escrituração. |
| 11 | Encoding | `Encoding` | Obtém ou define a codificação utilizada na escrituração. Por padrão, é UTF8. |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| LeArquivo(Stream) | `Task` | Método principal para leitura (desserialização) da escrituração. |
| EscreveArquivo(Stream) | `Task` | Método principal para escrita (serialização) da escrituração. |
| PrefixoBlocoEncerramento() | `Registro[]` |  |
| SufixoBlocoEncerramento() | `Registro[]` |  |
| EncerraArquivo(StreamWriter) | `Task` |  |
| ProcessaLinha(string) | `Void` | Método executado durante a leitura (desserialização) do arquivo digital.             É executado a cada linha. |
| LeEmpresaArquivo(Stream) | `Task<String>` | Retorna o CNPJ do informante do arquivo. |
| ToString() | `String` | Por padrão, este override do método .ToString() irá retornar a representação escrita (serializada)             do conteúdo da escrituração por completo. |
