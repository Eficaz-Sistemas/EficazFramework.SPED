#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives')

## Registro Class

Classe abstrata que representa um registro do SPED ou qualquer outra obrigação assessória.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Codigo | `String` | Código do Registro representado pela instância. |
| Versao | `String` | Versão do layout para correta leitura (desserialização) / escrita (serialização) |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.Primitives/Registro/EscreveLinha().md 'EficazFramework.SPED.Schemas.Primitives.Registro.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.Primitives/Registro/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.Primitives.Registro.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.Primitives/Registro/LeParametros(string[]).md#EficazFramework.SPED.Schemas.Primitives.Registro.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.Primitives.Registro.LeParametros(string[]).data') |
| [ToString()](EficazFramework.SPED.Schemas.Primitives/Registro/ToString().md 'EficazFramework.SPED.Schemas.Primitives.Registro.ToString()') | Retorna o resultado do método [EscreveLinha()](EficazFramework.SPED.Schemas.Primitives/Registro/EscreveLinha().md 'EficazFramework.SPED.Schemas.Primitives.Registro.EscreveLinha()') |
