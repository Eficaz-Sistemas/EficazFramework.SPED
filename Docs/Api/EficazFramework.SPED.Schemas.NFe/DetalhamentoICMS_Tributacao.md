#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## DetalhamentoICMS_Tributacao Class

Clase genérica para tratamento das tributações de ICMS.
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | orig | `OrigemMercadoria` |  |
| 03 | CST | `CST_ICMS` |  |
| 04 | CSOSN | `CSOSN_ICMS` |  |
| 05 | CSTFinal | `Int32` |  |
| 06 | vBC | `Nullable<Double>` |  |
| 07 | vBC_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBC' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 08 | pICMS | `Nullable<Double>` |  |
| 09 | vICMS | `Nullable<Double>` |  |
| 10 | vICMS_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMS' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 11 | modBC00 | `DetalhamentoICMS_CST00_ModBC` |  |
| 12 | modBC10 | `DetalhamentoICMS_CST10_ModBC` |  |
| 13 | modBCST10 | `DetalhamentoICMS_CST10_ModBCST` |  |
| 14 | modBC20 | `DetalhamentoICMS_CST20_ModBC` |  |
| 15 | modBCST30 | `DetalhamentoICMS_CST30_ModBCST` |  |
| 16 | modBC51 | `DetalhamentoICMS_CST51_ModBC` |  |
| 17 | vBCSTRet | `Nullable<Double>` |  |
| 18 | vBCSTRet_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCSTRet' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 19 | vICMSSTRet | `Nullable<Double>` |  |
| 20 | vICMSSTRet_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSSTRet' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 21 | modBC70 | `DetalhamentoICMS_CST70_ModBC` |  |
| 22 | modBCST70 | `DetalhamentoICMS_CST70_ModBCST` |  |
| 23 | modBC90 | `DetalhamentoICMS_CST90_ModBC` |  |
| 24 | modBCST90 | `DetalhamentoICMS_CST90_ModBCST` |  |
| 25 | pMVAST | `Nullable<Double>` |  |
| 26 | pRedBCST | `Nullable<Double>` |  |
| 27 | vBCST | `Nullable<Double>` |  |
| 28 | vBCST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 29 | pICMSST | `Nullable<Double>` |  |
| 30 | vICMSST | `Nullable<Double>` |  |
| 31 | vICMSST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 32 | vBCFCPST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCFCPST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 33 | vBCFCPST | `Nullable<Double>` |  |
| 34 | pFCPST | `Nullable<Double>` |  |
| 35 | vFCPST | `Nullable<Double>` |  |
| 36 | vFCPST_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vFCPST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 37 | pRedBC | `Nullable<Double>` |  |
| 38 | motDesICMS | `DetalhamentoICMS_CST40_MotivoDesoneracao` |  |
| 39 | vICMSDeson | `Nullable<Double>` |  |
| 40 | pCredSN | `Nullable<Double>` |  |
| 41 | vCredICMSSN | `Nullable<Double>` |  |
| 42 | vCredICMSSN_XML | `String` |  |
| 43 | modBCST201 | `DetalhamentoICMSSN_CSOSN201_ModBCST` |  |
| 44 | modBCST202 | `DetalhamentoICMSSN_CSOSN202_ModBCST` |  |
| 45 | modBC900 | `DetalhamentoICMSSN_CSOSN900_ModBC` |  |
| 46 | modBCST900 | `DetalhamentoICMSSN_CSOSN900_ModBCST` |  |
| 47 | modBCPart | `DetalhamentoICMS_Part_ModBC` |  |
| 48 | modBCSTPart | `DetalhamentoICMS_Part_ModBCST` |  |
| 49 | UFST | `Estado` |  |
| 50 | pBCOp | `Nullable<Double>` |  |
| 51 | vBCSTDest | `Nullable<Double>` |  |
| 52 | vBCSTDest_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCSTDest' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 53 | vICMSSTDest | `Nullable<Double>` |  |
| 54 | vICMSSTDest_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 55 | vBCEfet | `Nullable<Double>` |  |
| 56 | pICMSEfet | `Nullable<Double>` |  |
| 57 | vICMSEfet | `Nullable<Double>` |  |
| 58 | modBC | `Nullable<Int32>` | Propriedade genérica apenas para compatibilidade com Parser XML.            Para correto funcionamento, utilizar as propriedades modBCXXXX.            A sincronização das demais para com esta, no ato da escrita do arquivo XML deve ser feita manualmente. |
| 59 | modBCSpecified | `Boolean` |  |
| 60 | modBCST | `Nullable<Int32>` | Propriedade genérica apenas para compatibilidade com Parser XML.            Para correto funcionamento, utilizar as propriedades modBCXXXX.            A sincronização das demais para com esta, no ato da escrita do arquivo XML deve ser feita manualmente. |
| 61 | modBCSTSpecified | `Boolean` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeCSTNormal() | `Boolean` |  |
| ShouldSerializeCSOSN() | `Boolean` |  |
| ShouldSerializevBC_XML() | `Boolean` |  |
| ShouldSerializepICMS() | `Boolean` |  |
| ShouldSerializevICMS_XML() | `Boolean` |  |
| ShouldSerializevBCSTRet_XML() | `Boolean` |  |
| ShouldSerializevICMSSTRet_XML() | `Boolean` |  |
| ShouldSerializepMVAST() | `Boolean` |  |
| ShouldSerializepRedBCST() | `Boolean` |  |
| ShouldSerializevBCST_XML() | `Boolean` |  |
| ShouldSerializepICMSST() | `Boolean` |  |
| ShouldSerializevICMSST_XML() | `Boolean` |  |
| ShouldSerializevBCFCPST_XML() | `Boolean` |  |
| ShouldSerializepFCPST() | `Boolean` |  |
| ShouldSerializevFCPST_XML() | `Boolean` |  |
| ShouldSerializepRedBC() | `Boolean` |  |
| ShouldSerializemotDesICMS() | `Boolean` |  |
| ShouldSerializevICMSDeson() | `Boolean` |  |
| ShouldSerializepCredSN() | `Boolean` |  |
| ShouldSerializevCredICMSSN_XML() | `Boolean` |  |
| ShouldSerializeUFST() | `Boolean` |  |
| ShouldSerializepBCOp() | `Boolean` |  |
| ShouldSerializevBCSTDest_XML() | `Boolean` |  |
| ShouldSerializevICMSSTDest_XML() | `Boolean` |  |
| ShouldSerializevBCEfet() | `Boolean` |  |
| ShouldSerializepICMSEfet() | `Boolean` |  |
| ShouldSerializevICMSEfet() | `Boolean` |  |
| ShouldSerializemodBC() | `Boolean` |  |
| ShouldSerializemodBCST() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
