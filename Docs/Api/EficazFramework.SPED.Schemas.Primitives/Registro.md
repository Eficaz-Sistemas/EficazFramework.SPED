#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives')

## Registro Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Codigo | Código do Registro representado pela instância. |
| 03 | Versao | Versão do layout para correta leitura (desserialização) / escrita (serialização) |
### Methods

| Name | |
| :--- | :--- |
| LeParametros(string[]) | Efetua a leitura (desserialização) da linha especificada em <paramref name="data"/> |
| EscreveLinha() | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| ToString() | Retorna o resultado do método <see cref="M:EficazFramework.SPED.Schemas.Primitives.Registro.EscreveLinha"/> |
