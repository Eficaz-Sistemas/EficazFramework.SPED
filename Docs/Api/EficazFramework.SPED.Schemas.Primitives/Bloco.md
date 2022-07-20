#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.Primitives](EficazFramework.SPED.Schemas.Primitives.md 'EficazFramework.SPED.Schemas.Primitives')

## Bloco Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Registros | `ObservableCollection<Registro>` | Obtém a listagem de registros da instância de bloco. |
| 03 | TotaisRegistros | `Dictionary<String,Int64>` | Obtém a contagem de um determinado registro da instância de bloco. |
| 04 | RegistrosGroupBy | `Dictionary<String,Int64>` | Obtém uma listagem dos tipos de registros informados na escrituração |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ContagemRegistro(string) | `Int64` | Obtém a contagem de um determinado registro da instância de bloco. |
| EscreveLinha() | `String` |  |
| GeraRegistrosTotalizadores(string, string) | `RegistroTotalizador[]` |  |
