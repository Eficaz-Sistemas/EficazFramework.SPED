#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01](EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.md 'EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01')

## ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgto Class

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| DataFatoGerador | `DateTime` | Informar a data do fato gerador, ou, em caso de fato não tributável mas de             informação obrigatória conforme legislação vigente, a data do pagamento ou            crédito, no formato AAAA-MM-DD. <br/><br/><b>Validação:</b> A data informada deve estar compreendida no período de apuração            ao qual se refere o arquivo, conforme informado em(perApur}, no formato            AAAA-MM-DD. |
| compFP | `String` | Informar a competência a que se refere os rendimentos.<br/><br/><b>Validação:</b> Informação permitida apenas se a natureza de rendimento            informada em { natRend } for do grupo 10 da Tabela 01 ou se constar "S" na            coluna "13°" da mesma tabela.            <br/>Se informado, não pode ser superior à data atual e deve estar no formato:<br/>            a) AAAA, se {indDecTerc} = [S];<br/>            b) AAAA-MM, nos demais casos |
| indDecTerc | `String` |  |
| vlrRendBruto | `String` |  |
| vlrRendTrib | `String` |  |
| vlrIR | `String` |  |
| indRRA | `String` |  |
| indFciScp | `Nullable<IndicadorFciScp>` |  |
| nrInscFciScp | `String` |  |
| percSCP | `String` |  |
| indJud | `String` |  |
| paisResidExt | `String` |  |
| detDed | `List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed>` |  |
| rendIsento | `List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento>` |  |
| infoProcRet | `List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet>` |  |
| infoRRA | `ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRA` |  |
| infoProcJud | `ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud` |  |
| infoPgtoExt | `ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt` |  |

| Methods | |
| :--- | :--- |
| [ShouldSerializeindFciScp()](EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01/ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgto/ShouldSerializeindFciScp().md 'EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgto.ShouldSerializeindFciScp()') | |
