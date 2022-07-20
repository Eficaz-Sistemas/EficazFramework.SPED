#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives')

## Registro Class

Classe abstrata que representa um registro do SPED ou qualquer outra obrigação assessória.
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Codigo | `String` | Código do Registro representado pela instância. |
| 03 | Versao | `String` | Versão do layout para correta leitura (desserialização) / escrita (serialização) |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| LeParametros(string[]) | `Void` | Efetua a leitura (desserialização) da linha especificada em <paramref name="data"/> |
| EscreveLinha() | `String` | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| ToString() | `String` | Retorna o resultado do método <see cref="M:EficazFramework.SPED.Schemas.Primitives.Registro.EscreveLinha"/> |
