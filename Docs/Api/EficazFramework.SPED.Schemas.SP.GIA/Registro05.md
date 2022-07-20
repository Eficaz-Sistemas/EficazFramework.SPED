#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.SP.GIA](EficazFramework.SPED.Schemas.SP.GIA.md 'EficazFramework.SPED.Schemas.SP.GIA')

## Registro05 Class

Cabeçalho do Documento Fiscal
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | InscricaoEstadual |  |
| 03 | CNPJ |  |
| 04 | CNAE | Deixar fixo "0000000" |
| 05 | RegimeTributario |  |
| 06 | Competencia |  |
| 07 | ReferenciaInicial | - RefInicial &gt;=200007            - Se RegTrib = 01 (RPA) , RefInicial IGUAL 000000 (ZEROS)            - Se RegTrib = 02 (RES),  RefInicial MAIOR OU IGUAL Competencia e deve pertencer ao mesmo semestre de Competencia            - Se RegTrib = 03 (RPA-DISPENSADO), RefInicial IGUAL 000000 (ZEROS)            - Se RegTrib = 04 (Simples-ST), RefInicial IGUAL 000000 (ZEROS) |
| 08 | Tipo |  |
| 09 | PossuiMovimeto |  |
| 10 | Transmitida |  |
| 11 | SaldoCredorAnterior |  |
| 12 | SaldoCredorSTAnterior | Preencher com ZEROS se RegTrib = 04 |
| 13 | OrigemSoftware | CNPJ ou CPF do desenvolvedor |
| 14 | OrigemGIA |  |
| 15 | ICMS_Fixado | - Se RegTrib = 02 Conteúdo &gt; ZEROS            - Se RegTrib = 01 ou 03 ou 04 , conteúdo = ZEROS |
| 16 | ChaveInterna |  |
| 17 | Registros07 |  |
| 18 | Registros10 |  |
| 19 | Registros20 |  |
| 20 | Registros30 |  |
| 21 | Registros31 |  |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
