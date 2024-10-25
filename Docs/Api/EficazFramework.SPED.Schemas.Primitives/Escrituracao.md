#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives')

## Escrituracao Class

Classe abstrata que representa uma escrituração do SPED ou de qualquer outra obrigação assessória.  
Contém a instrumentação básica para leitura (desserialização) e escrita (serialização) da escrituração.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Blocos | `Dictionary<String,Bloco>` | Dicionário contendo o par de Chave / Valor de Todos os Blocos da Escrituração Implementada. <br/>            Permite o acesso aos registros desejados durante etapas de leitura (desserialização) e escrita (serialização). |
| Versao | `String` | Versão para leitura (desserialização) / escrita (serialização) da escrituração. |
| Progresso | `Int32` | Progresso em percentual da leitura (desserialização). |
| RegistrosIgnorados | `List<String>` | Listagem de regitros que devem ser desconsiderados durante a leitura (desserialização) da escrituração |
| IsLoading | `Boolean` | Obtém ou define se a instância está em estado de trabalho de leitura (desserialização) / escrita (serialização). |
| RegistroAtual | `String` | Obtém o registro que está em análise no momento da leitura (desserialização). |
| ValidaPipeInicial | `Boolean` | Obtém ou define se a leitura da linha do arquivo deve iniciar com carectere pipe ("|") |
| BlocoTotalizador | `String` | Obtém ou define o código do Bloco Totalizador da Escrituração implementada, para cálculo automatizado dos registros de totalização. |
| RegistroTotalizadorCodigo | `String` | Obtém ou define o código do Registro Totalizador da Escrituração implementada, para cálculo automatizado de totalização. |
| RegistroTotalizadorStringFormat | `String` | Obtém ou define o formato do registro totalizador da escrituração. |
| Encoding | `Encoding` | Obtém ou define a codificação utilizada na escrituração. Por padrão, é UTF8. |

| Methods | |
| :--- | :--- |
| [EncerraArquivo(StreamWriter)](EficazFramework.SPED.Schemas.Primitives/Escrituracao/EncerraArquivo(StreamWriter).md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.EncerraArquivo(System.IO.StreamWriter)') | Quando implementado, é chamado pelo método [EscreveArquivo(Stream)](EficazFramework.SPED.Schemas.Primitives/Escrituracao/EscreveArquivo(Stream).md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.EscreveArquivo(System.IO.Stream)') para escrita personalizada do final do arquivo. |
| [EscreveArquivo(Stream)](EficazFramework.SPED.Schemas.Primitives/Escrituracao/EscreveArquivo(Stream).md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.EscreveArquivo(System.IO.Stream)') | Método principal para escrita (serialização) da escrituração. |
| [LeArquivo(Stream)](EficazFramework.SPED.Schemas.Primitives/Escrituracao/LeArquivo(Stream).md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.LeArquivo(System.IO.Stream)') | Método principal para leitura (desserialização) da escrituração. |
| [LeEmpresaArquivo(Stream)](EficazFramework.SPED.Schemas.Primitives/Escrituracao/LeEmpresaArquivo(Stream).md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.LeEmpresaArquivo(System.IO.Stream)') | Retorna o CNPJ do informante do arquivo. |
| [PrefixoBlocoEncerramento()](EficazFramework.SPED.Schemas.Primitives/Escrituracao/PrefixoBlocoEncerramento().md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.PrefixoBlocoEncerramento()') | Quando implementado, executa custom actions para geração de registros totalizadores no cabeçalho do bloco de encerramento do arquivo. |
| [ProcessaLinha(string)](EficazFramework.SPED.Schemas.Primitives/Escrituracao/ProcessaLinha(string).md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.ProcessaLinha(string)') | Método executado durante a leitura (desserialização) do arquivo digital. <br/>É executado a cada linha e permite a criação de instâncias de Registros, <br/>e monstagem da estrutura<br/>hierárquica de Blocos e Registros. |
| [SufixoBlocoEncerramento()](EficazFramework.SPED.Schemas.Primitives/Escrituracao/SufixoBlocoEncerramento().md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.SufixoBlocoEncerramento()') | Quando implementado, executa custom actions para geração de registros totalizadores no rodapé do bloco de encerramento do arquivo. |
| [ToString()](EficazFramework.SPED.Schemas.Primitives/Escrituracao/ToString().md 'EficazFramework.SPED.Schemas.Primitives.Escrituracao.ToString()') | Por padrão, este override do método .ToString() irá retornar a representação escrita (serializada) <br/>do conteúdo da escrituração por completo. |
