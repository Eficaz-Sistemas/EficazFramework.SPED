#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC176 Class

Ressarcimento de ICMS em operações com ST (01 e 55)

### Remarks
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| ModeloDocFiscal | `String` |  |
| NumeroDocFiscal | `Nullable<Int32>` |  |
| SerieDocFiscal | `String` |  |
| DataDocFiscal | `Nullable<DateTime>` |  |
| CodigoParticipante | `String` |  |
| QuantidadeItem | `Nullable<Double>` |  |
| ValorUnitarioItem | `Nullable<Double>` |  |
| Valor_BC_ST_UnitarioItem | `Nullable<Double>` |  |
| ChaveNFe | `String` |  |
| NumeroItem | `Nullable<Int32>` |  |
| Valor_BC_UnitarioItem | `Nullable<Double>` |  |
| Aliquota_ICMS | `Nullable<Double>` |  |
| ValorUnitario_LimitadoBC | `Nullable<Double>` | Valor unitário da base de cálculo do ICMS relativo à última entrada da mercadoria, limitado ao valor            da BC da retenção (corresponde ao menor valor entre os campos VL_UNIT_BC_ST e VL_UNIT_BC_ICMS_ULT_E ) |
| ValorUnitario_Credito_ICMS_LimitadoBC | `Nullable<Double>` | Valor unitário do crédito de ICMS sobre operações próprias Do remetente, relativo à última entrada da mercadoria            decorrente da quebra da ST – equivalente a multiplicação entre os campos 13 e 14 |
| Aliquota_ICMS_ST | `Nullable<Double>` |  |
| ValorUnitarioRessarcimento | `Nullable<Double>` |  |
| ResponsavelRetencao | `ResponsavelRetencaoST` |  |
| MotivoRessarcimento | `MotimoRessarcimentoST` |  |
| ChaveNF_Retencao | `String` | Chave NF-e emitida pelo substituto, na qual consta o valor do ICMS-ST Retido |
| CodigoParticipante_Retencao | `String` | Código do Partipante emitente da NF-e na qual consta o valor do ICMS-ST Retido |
| SerieNFe_Retencao | `String` | Série da NF-e na qual consta o valor do ICMS-ST Retido |
| NumeroNFe_Retencao | `Nullable<Int32>` | Número da NF-e na qual consta o valor do ICMS-ST Retido |
| ItemNFe_Retencao | `Nullable<Int32>` | Número de ordem do Item da NF-e na qual consta o valor do ICMS-ST Retido |
| ModeloDocumentoArrecadacao | `ModeloDocumentoArrecadacaoC176` |  |
| NumeroDocumentoArrecadacao | `String` |  |
| VlrUnitarioResFCP | `Nullable<Double>` |  |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/RegistroC176/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC176.EscreveLinha()') | |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/RegistroC176/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC176.LeParametros(string[])') | |
