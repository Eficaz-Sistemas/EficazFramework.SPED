#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SP.GIA](EficazFramework.SPED.Schemas.SP.GIA.md 'EficazFramework.SPED.Schemas.SP.GIA')

## Registro05 Class

Cabeçalho do Documento Fiscal
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | InscricaoEstadual | `String` |  |
| 03 | CNPJ | `String` |  |
| 04 | CNAE | `String` | Deixar fixo "0000000" |
| 05 | RegimeTributario | `RegimeTributario` |  |
| 06 | Competencia | `Nullable<DateTime>` |  |
| 07 | ReferenciaInicial | `Nullable<DateTime>` | - RefInicial &gt;=200007            - Se RegTrib = 01 (RPA) , RefInicial IGUAL 000000 (ZEROS)            - Se RegTrib = 02 (RES),  RefInicial MAIOR OU IGUAL Competencia e deve pertencer ao mesmo semestre de Competencia            - Se RegTrib = 03 (RPA-DISPENSADO), RefInicial IGUAL 000000 (ZEROS)            - Se RegTrib = 04 (Simples-ST), RefInicial IGUAL 000000 (ZEROS) |
| 08 | Tipo | `TipoGIA` |  |
| 09 | PossuiMovimeto | `Boolean` |  |
| 10 | Transmitida | `Boolean` |  |
| 11 | SaldoCredorAnterior | `Nullable<Double>` |  |
| 12 | SaldoCredorSTAnterior | `Nullable<Double>` | Preencher com ZEROS se RegTrib = 04 |
| 13 | OrigemSoftware | `String` | CNPJ ou CPF do desenvolvedor |
| 14 | OrigemGIA | `OrigemPreenchimento` |  |
| 15 | ICMS_Fixado | `Nullable<Double>` | - Se RegTrib = 02 Conteúdo &gt; ZEROS            - Se RegTrib = 01 ou 03 ou 04 , conteúdo = ZEROS |
| 16 | ChaveInterna | `String` |  |
| 17 | Registros07 | `List<Registro07>` |  |
| 18 | Registros10 | `List<Registro10>` |  |
| 19 | Registros20 | `List<Registro20>` |  |
| 20 | Registros30 | `List<Registro30>` |  |
| 21 | Registros31 | `List<Registro31>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
