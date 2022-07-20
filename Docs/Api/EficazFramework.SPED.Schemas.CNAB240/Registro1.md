#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CNAB240](EficazFramework.SPED.Schemas.CNAB240.md 'EficazFramework.SPED.Schemas.CNAB240')

## Registro1 Class

Registro Header de Lote de Serviço
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | CodigoBanco | `String` |  |
| 03 | LoteDeServico | `String` |  |
| 04 | TipoOperacao | `String` |  |
| 05 | TipoDePagamento | `TipoDePagamento` |  |
| 06 | FormaDePagamento | `FormaDePagamento` |  |
| 07 | LayoutLote | `String` |  |
| 08 | TipoInscricao | `String` | 1 = CPF            2 = CNPJ [Default] |
| 09 | CNPJ | `String` |  |
| 10 | Convenio | `String` |  |
| 11 | Agencia | `String` |  |
| 12 | AgenciaDV | `String` |  |
| 13 | Conta | `String` |  |
| 14 | ContaDV | `String` |  |
| 15 | DAC | `String` |  |
| 16 | NomeEmpresa | `String` |  |
| 17 | FinalidadeLote | `FinalidadeLote` |  |
| 18 | HistoricoCC | `String` |  |
| 19 | EnderecoEmpresa | `String` |  |
| 20 | EnderecoNumero | `String` |  |
| 21 | EnderecoComplemento | `String` |  |
| 22 | EnderecoCidade | `String` |  |
| 23 | EnderecoCEP | `String` |  |
| 24 | EnderecoUF | `String` |  |
| 25 | Ocorrencias | `String` |  |
| 26 | Registros3 | `List<Registro3>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
