#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01](EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01')

## ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto Class

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| DataFatoGerador | `DateTime` | Informar a data do fato gerador, no formato AAAA-MM-DD. <br/><br/><b>Validação: </b>A data informada deve estar compreendida no período de apuração             ao qual se refere o arquivo, conforme informado em(perApur}, no formato AAAA-MM-DD. |
| vlrLiq | `String` | Valor líquido do Pagamento |
| vlrBaseIR | `String` | Valor reajustado, considerado como valor da base de cálculo do IRRF.<br/><br/><b>Validação: </b> Deve corresponder a (<see cref="P:EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto.vlrLiq"/> / 0,65). |
| vlrIR | `String` |  |
| descr | `String` | Descrição do Pagamento |
| infoProcRet | `List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgtoInfoProcRet>` |  |
