#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC176 Class

Ressarcimento de ICMS em operações com ST (01 e 55)

### Remarks
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | ModeloDocFiscal |  |
| 03 | NumeroDocFiscal |  |
| 04 | SerieDocFiscal |  |
| 05 | DataDocFiscal |  |
| 06 | CodigoParticipante |  |
| 07 | QuantidadeItem |  |
| 08 | ValorUnitarioItem |  |
| 09 | Valor_BC_ST_UnitarioItem |  |
| 10 | ChaveNFe |  |
| 11 | NumeroItem |  |
| 12 | Valor_BC_UnitarioItem |  |
| 13 | Aliquota_ICMS |  |
| 14 | ValorUnitario_LimitadoBC | Valor unitário da base de cálculo do ICMS relativo à última entrada da mercadoria, limitado ao valor            da BC da retenção (corresponde ao menor valor entre os campos VL_UNIT_BC_ST e VL_UNIT_BC_ICMS_ULT_E ) |
| 15 | ValorUnitario_Credito_ICMS_LimitadoBC | Valor unitário do crédito de ICMS sobre operações próprias Do remetente, relativo à última entrada da mercadoria            decorrente da quebra da ST – equivalente a multiplicação entre os campos 13 e 14 |
| 16 | Aliquota_ICMS_ST |  |
| 17 | ValorUnitarioRessarcimento |  |
| 18 | ResponsavelRetencao |  |
| 19 | MotivoRessarcimento |  |
| 20 | ChaveNF_Retencao | Chave NF-e emitida pelo substituto, na qual consta o valor do ICMS-ST Retido |
| 21 | CodigoParticipante_Retencao | Código do Partipante emitente da NF-e na qual consta o valor do ICMS-ST Retido |
| 22 | SerieNFe_Retencao | Série da NF-e na qual consta o valor do ICMS-ST Retido |
| 23 | NumeroNFe_Retencao | Número da NF-e na qual consta o valor do ICMS-ST Retido |
| 24 | ItemNFe_Retencao | Número de ordem do Item da NF-e na qual consta o valor do ICMS-ST Retido |
| 25 | ModeloDocumentoArrecadacao |  |
| 26 | NumeroDocumentoArrecadacao |  |
| 27 | VlrUnitarioResFCP |  |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
