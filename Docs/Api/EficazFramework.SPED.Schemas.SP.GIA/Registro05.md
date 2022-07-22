#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SP.GIA](EficazFramework.SPED.Schemas.SP.GIA.md 'EficazFramework.SPED.Schemas.SP.GIA')

## Registro05 Class

Cabeçalho do Documento Fiscal
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| InscricaoEstadual | `String` |  |
| CNPJ | `String` |  |
| CNAE | `String` | Deixar fixo "0000000" |
| RegimeTributario | `RegimeTributario` |  |
| Competencia | `Nullable<DateTime>` |  |
| ReferenciaInicial | `Nullable<DateTime>` | - RefInicial &gt;=200007            - Se RegTrib = 01 (RPA) , RefInicial IGUAL 000000 (ZEROS)            - Se RegTrib = 02 (RES),  RefInicial MAIOR OU IGUAL Competencia e deve pertencer ao mesmo semestre de Competencia            - Se RegTrib = 03 (RPA-DISPENSADO), RefInicial IGUAL 000000 (ZEROS)            - Se RegTrib = 04 (Simples-ST), RefInicial IGUAL 000000 (ZEROS) |
| Tipo | `TipoGIA` |  |
| PossuiMovimeto | `Boolean` |  |
| Transmitida | `Boolean` |  |
| SaldoCredorAnterior | `Nullable<Double>` |  |
| SaldoCredorSTAnterior | `Nullable<Double>` | Preencher com ZEROS se RegTrib = 04 |
| OrigemSoftware | `String` | CNPJ ou CPF do desenvolvedor |
| OrigemGIA | `OrigemPreenchimento` |  |
| ICMS_Fixado | `Nullable<Double>` | - Se RegTrib = 02 Conteúdo &gt; ZEROS            - Se RegTrib = 01 ou 03 ou 04 , conteúdo = ZEROS |
| ChaveInterna | `String` |  |
| Registros07 | `List<Registro07>` |  |
| Registros10 | `List<Registro10>` |  |
| Registros20 | `List<Registro20>` |  |
| Registros30 | `List<Registro30>` |  |
| Registros31 | `List<Registro31>` |  |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.SP.GIA/Registro05/EscreveLinha().md 'EficazFramework.SPED.Schemas.SP.GIA.Registro05.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.SP.GIA/Registro05/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.SP.GIA.Registro05.LeParametros(string[])') | |
