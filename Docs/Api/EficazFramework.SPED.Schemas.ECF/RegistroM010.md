#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.ECF](EficazFramework.SPED.Schemas.ECF.md 'EficazFramework.SPED.Schemas.ECF')

## RegistroM010 Class

Identificação da Conta na Parte B do e-Lalur e do e-Lacs

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | CodigoContaB |  |
| 03 | Descricao |  |
| 04 | DataFinal | Data final do período de apuração em que a conta foi criada. |
| 05 | CodigoLancamentoOrigem | Código do lançamento na parte A do e-Lalur e/ou do e-Lacs que deu origem à conta. |
| 06 | DescricaoLanctoOrigem | Descrição do tipo de lançamento na parte A do e-Lalur e/ou do e-Lacs que deu origem à conta. |
| 07 | DataLimite | Data limite para a exclusão, adição ou compensação do valor controlado, se houver. |
| 08 | CodigoTributo | I = IRPJ            C = CSLL |
| 09 | SaldoInicial |  |
| 10 | NaturezaSaldoInicial | D – Para prejuízos ou valores que reduzam o lucro real ou a base de cálculo da contribuição social em períodos subsequentes.            C – Para valores que aumentem o lucro real ou a base de cálculo da contribuição social em períodos subsequentes. |
| 11 | CNPJSituacaoEspecial | CNPJ da outra pessoa jurídica relacionada com evento originário da conta.            Exemplos: 1-  Identificar a investida no caso de valores (ganhos/perdas no novo AVJ) da participação societária anterior, nos caso de aquisições em estágios.            2- Identificar a investida no caso de amortização de mais-valia e menos-valia.            3- Identificar a investida no caso de impairment de goodwill, mais-valia e menos-valia.            4- Identificar a investida no caso de ganho por compra vantajosa.            5- Identificar a investida no caso registro do ágio gerado na aquisição de participação societária ocorrida até 31/12/2009.            6  - Identificar a investida no caso de ágio gerado pela sistemática de transição disciplinada no art. 65, Lei Nº 12.973/14.            7 - Identificar a pessoa jurídica antecessora no caso de conta incorporada devido a evento societário |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
