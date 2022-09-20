#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01](EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01')

## ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto Class

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| DataFatoGerador | `DateTime` | Informar a data do fato gerador, ou, em caso de fato não tributável mas de             informação obrigatória conforme legislação vigente, a data do pagamento ou            crédito, no formato AAAA-MM-DD. <br/><br/><b>Validação:</b> A data informada deve estar compreendida no período de apuração            ao qual se refere o arquivo, conforme informado em(perApur}, no formato            AAAA-MM-DD. |
| vlrBruto | `String` |  |
| indFciScp | `Nullable<IndicadorFciScp>` |  |
| nrInscFciScp | `String` |  |
| percSCP | `String` |  |
| indJud | `String` |  |
| paisResidExt | `String` |  |
| retencoes | `ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoRetencoes` | Informações relativas a retenções na fonte e respectivas bases de cálculo. |
| infoProcRet | `List<ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet>` | Informações de processos relacionados a não retenção de tributos ou a depósitos judiciais. |
| infoProcJud | `ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud` |  |
| infoPgtoExt | `ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt` |  |

| Methods | |
| :--- | :--- |
| [ShouldSerializeindFciScp()](EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01/ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto/ShouldSerializeindFciScp().md 'EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.ReinfEvtRetPJIdeEstabIdeBenefIdePgtoInfoPgto.ShouldSerializeindFciScp()') | |
