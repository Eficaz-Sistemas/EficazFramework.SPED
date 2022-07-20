#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC176 Class

Ressarcimento de ICMS em operações com ST (01 e 55)

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ModeloDocFiscal | `String` |  |
| 03 | NumeroDocFiscal | `Nullable<Int32>` |  |
| 04 | SerieDocFiscal | `String` |  |
| 05 | DataDocFiscal | `Nullable<DateTime>` |  |
| 06 | CodigoParticipante | `String` |  |
| 07 | QuantidadeItem | `Nullable<Double>` |  |
| 08 | ValorUnitarioItem | `Nullable<Double>` |  |
| 09 | Valor_BC_ST_UnitarioItem | `Nullable<Double>` |  |
| 10 | ChaveNFe | `String` |  |
| 11 | NumeroItem | `Nullable<Int32>` |  |
| 12 | Valor_BC_UnitarioItem | `Nullable<Double>` |  |
| 13 | Aliquota_ICMS | `Nullable<Double>` |  |
| 14 | ValorUnitario_LimitadoBC | `Nullable<Double>` | Valor unitário da base de cálculo do ICMS relativo à última entrada da mercadoria, limitado ao valor            da BC da retenção (corresponde ao menor valor entre os campos VL_UNIT_BC_ST e VL_UNIT_BC_ICMS_ULT_E ) |
| 15 | ValorUnitario_Credito_ICMS_LimitadoBC | `Nullable<Double>` | Valor unitário do crédito de ICMS sobre operações próprias Do remetente, relativo à última entrada da mercadoria            decorrente da quebra da ST – equivalente a multiplicação entre os campos 13 e 14 |
| 16 | Aliquota_ICMS_ST | `Nullable<Double>` |  |
| 17 | ValorUnitarioRessarcimento | `Nullable<Double>` |  |
| 18 | ResponsavelRetencao | `ResponsavelRetencaoST` |  |
| 19 | MotivoRessarcimento | `MotimoRessarcimentoST` |  |
| 20 | ChaveNF_Retencao | `String` | Chave NF-e emitida pelo substituto, na qual consta o valor do ICMS-ST Retido |
| 21 | CodigoParticipante_Retencao | `String` | Código do Partipante emitente da NF-e na qual consta o valor do ICMS-ST Retido |
| 22 | SerieNFe_Retencao | `String` | Série da NF-e na qual consta o valor do ICMS-ST Retido |
| 23 | NumeroNFe_Retencao | `Nullable<Int32>` | Número da NF-e na qual consta o valor do ICMS-ST Retido |
| 24 | ItemNFe_Retencao | `Nullable<Int32>` | Número de ordem do Item da NF-e na qual consta o valor do ICMS-ST Retido |
| 25 | ModeloDocumentoArrecadacao | `ModeloDocumentoArrecadacaoC176` |  |
| 26 | NumeroDocumentoArrecadacao | `String` |  |
| 27 | VlrUnitarioResFCP | `Nullable<Double>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
