#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## DetalhamentoICMS_Tributacao Class

Clase genérica para tratamento das tributações de ICMS.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Origem | `OrigemMercadoria` |  |
| CST | `CST_ICMS` |  |
| CSOSN | `CSOSN_ICMS` |  |
| CSTFinal | `Int32` |  |
| vBC | `Nullable<Double>` |  |
| vBC_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBC' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| pICMS | `Nullable<Double>` |  |
| vICMS | `Nullable<Double>` |  |
| vICMS_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMS' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| modBC00 | `DetalhamentoICMS_CST00_ModBC` |  |
| modBC10 | `DetalhamentoICMS_CST10_ModBC` |  |
| modBCST10 | `DetalhamentoICMS_CST10_ModBCST` |  |
| modBC20 | `DetalhamentoICMS_CST20_ModBC` |  |
| modBCST30 | `DetalhamentoICMS_CST30_ModBCST` |  |
| modBC51 | `DetalhamentoICMS_CST51_ModBC` |  |
| vBCSTRet | `Nullable<Double>` |  |
| vBCSTRet_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCSTRet' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| pST | `Nullable<Double>` |  |
| pST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'pST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| vICMSSTRet | `Nullable<Double>` |  |
| vICMSSTRet_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSSTRet' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| modBC70 | `DetalhamentoICMS_CST70_ModBC` |  |
| modBCST70 | `DetalhamentoICMS_CST70_ModBCST` |  |
| modBC90 | `DetalhamentoICMS_CST90_ModBC` |  |
| modBCST90 | `DetalhamentoICMS_CST90_ModBCST` |  |
| pMVAST | `Nullable<Double>` |  |
| pRedBCST | `Nullable<Double>` |  |
| vBCST | `Nullable<Double>` |  |
| vBCST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| pICMSST | `Nullable<Double>` |  |
| vICMSST | `Nullable<Double>` |  |
| vICMSST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| vBCFCPST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCFCPST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| vBCFCPST | `Nullable<Double>` |  |
| pFCPST | `Nullable<Double>` |  |
| vFCPST | `Nullable<Double>` |  |
| vFCPST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vFCPST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| pRedBC | `Nullable<Double>` |  |
| motDesICMS | `DetalhamentoICMS_CST40_MotivoDesoneracao` |  |
| vICMSDeson | `Nullable<Double>` |  |
| pCredSN | `Nullable<Double>` |  |
| vCredICMSSN | `Nullable<Double>` |  |
| vCredICMSSN_XML | `String` |  |
| modBCST201 | `DetalhamentoICMSSN_CSOSN201_ModBCST` |  |
| modBCST202 | `DetalhamentoICMSSN_CSOSN202_ModBCST` |  |
| modBC900 | `DetalhamentoICMSSN_CSOSN900_ModBC` |  |
| modBCST900 | `DetalhamentoICMSSN_CSOSN900_ModBCST` |  |
| modBCPart | `DetalhamentoICMS_Part_ModBC` |  |
| modBCSTPart | `DetalhamentoICMS_Part_ModBCST` |  |
| UFST | `Estado` |  |
| pBCOp | `Nullable<Double>` |  |
| vBCSTDest | `Nullable<Double>` |  |
| vBCSTDest_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCSTDest' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| vICMSSTDest | `Nullable<Double>` |  |
| vICMSSTDest_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| vBCEfet | `Nullable<Double>` |  |
| pICMSEfet | `Nullable<Double>` |  |
| vICMSEfet | `Nullable<Double>` |  |
| modBC | `Nullable<Int32>` | Propriedade genérica apenas para compatibilidade com Parser XML.            Para correto funcionamento, utilizar as propriedades modBCXXXX.            A sincronização das demais para com esta, no ato da escrita do arquivo XML deve ser feita manualmente. |
| modBCSpecified | `Boolean` |  |
| modBCST | `Nullable<Int32>` | Propriedade genérica apenas para compatibilidade com Parser XML.            Para correto funcionamento, utilizar as propriedades modBCXXXX.            A sincronização das demais para com esta, no ato da escrita do arquivo XML deve ser feita manualmente. |
| modBCSTSpecified | `Boolean` |  |
| qBCMonoRet | `Nullable<Double>` |  |
| adRemICMSRet | `Nullable<Double>` |  |
| vICMSMonoRet | `Nullable<Double>` |  |

| Methods | |
| :--- | :--- |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.OnPropertyChanged(string)') | |
| [ShouldSerializeadRemICMSRet()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializeadRemICMSRet().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializeadRemICMSRet()') | |
| [ShouldSerializeCSOSN()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializeCSOSN().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializeCSOSN()') | |
| [ShouldSerializeCST()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializeCST().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializeCST()') | |
| [ShouldSerializemodBC()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializemodBC().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializemodBC()') | |
| [ShouldSerializemodBCST()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializemodBCST().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializemodBCST()') | |
| [ShouldSerializemotDesICMS()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializemotDesICMS().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializemotDesICMS()') | |
| [ShouldSerializepBCOp()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepBCOp().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepBCOp()') | |
| [ShouldSerializepCredSN()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepCredSN().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepCredSN()') | |
| [ShouldSerializepFCPST()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepFCPST().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepFCPST()') | |
| [ShouldSerializepICMS()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepICMS().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepICMS()') | |
| [ShouldSerializepICMSEfet()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepICMSEfet().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepICMSEfet()') | |
| [ShouldSerializepICMSST()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepICMSST().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepICMSST()') | |
| [ShouldSerializepMVAST()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepMVAST().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepMVAST()') | |
| [ShouldSerializepRedBC()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepRedBC().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepRedBC()') | |
| [ShouldSerializepRedBCST()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepRedBCST().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepRedBCST()') | |
| [ShouldSerializepST_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializepST_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializepST_XML()') | |
| [ShouldSerializeqBCMonoRet()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializeqBCMonoRet().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializeqBCMonoRet()') | |
| [ShouldSerializeUFST()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializeUFST().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializeUFST()') | |
| [ShouldSerializevBC_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevBC_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevBC_XML()') | |
| [ShouldSerializevBCEfet()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevBCEfet().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevBCEfet()') | |
| [ShouldSerializevBCFCPST_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevBCFCPST_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevBCFCPST_XML()') | |
| [ShouldSerializevBCST_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevBCST_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevBCST_XML()') | |
| [ShouldSerializevBCSTDest_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevBCSTDest_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevBCSTDest_XML()') | |
| [ShouldSerializevBCSTRet_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevBCSTRet_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevBCSTRet_XML()') | |
| [ShouldSerializevCredICMSSN()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevCredICMSSN().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevCredICMSSN()') | |
| [ShouldSerializevCredICMSSN_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevCredICMSSN_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevCredICMSSN_XML()') | |
| [ShouldSerializevFCPST_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevFCPST_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevFCPST_XML()') | |
| [ShouldSerializevICMS_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevICMS_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevICMS_XML()') | |
| [ShouldSerializevICMSDeson()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevICMSDeson().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevICMSDeson()') | |
| [ShouldSerializevICMSEfet()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevICMSEfet().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevICMSEfet()') | |
| [ShouldSerializevICMSMonoRet()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevICMSMonoRet().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevICMSMonoRet()') | |
| [ShouldSerializevICMSST_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevICMSST_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevICMSST_XML()') | |
| [ShouldSerializevICMSSTDest_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevICMSSTDest_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevICMSSTDest_XML()') | |
| [ShouldSerializevICMSSTRet_XML()](EficazFramework.SPED.Schemas.NFe/DetalhamentoICMS_Tributacao/ShouldSerializevICMSSTRet_XML().md 'EficazFramework.SPED.Schemas.NFe.DetalhamentoICMS_Tributacao.ShouldSerializevICMSSTRet_XML()') | |
