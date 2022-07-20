#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## DetalhamentoICMS_Tributacao Class

Clase genérica para tratamento das tributações de ICMS.
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | orig |  |
| 03 | CST |  |
| 04 | CSOSN |  |
| 05 | CSTFinal |  |
| 06 | vBC |  |
| 07 | vBC_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBC' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 08 | pICMS |  |
| 09 | vICMS |  |
| 10 | vICMS_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMS' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 11 | modBC00 |  |
| 12 | modBC10 |  |
| 13 | modBCST10 |  |
| 14 | modBC20 |  |
| 15 | modBCST30 |  |
| 16 | modBC51 |  |
| 17 | vBCSTRet |  |
| 18 | vBCSTRet_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCSTRet' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 19 | vICMSSTRet |  |
| 20 | vICMSSTRet_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSSTRet' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 21 | modBC70 |  |
| 22 | modBCST70 |  |
| 23 | modBC90 |  |
| 24 | modBCST90 |  |
| 25 | pMVAST |  |
| 26 | pRedBCST |  |
| 27 | vBCST |  |
| 28 | vBCST_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 29 | pICMSST |  |
| 30 | vICMSST |  |
| 31 | vICMSST_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 32 | vBCFCPST_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCFCPST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 33 | vBCFCPST |  |
| 34 | pFCPST |  |
| 35 | vFCPST |  |
| 36 | vFCPST_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vFCPST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 37 | pRedBC |  |
| 38 | motDesICMS |  |
| 39 | vICMSDeson |  |
| 40 | pCredSN |  |
| 41 | vCredICMSSN |  |
| 42 | vCredICMSSN_XML |  |
| 43 | modBCST201 |  |
| 44 | modBCST202 |  |
| 45 | modBC900 |  |
| 46 | modBCST900 |  |
| 47 | modBCPart |  |
| 48 | modBCSTPart |  |
| 49 | UFST |  |
| 50 | pBCOp |  |
| 51 | vBCSTDest |  |
| 52 | vBCSTDest_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vBCSTDest' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 53 | vICMSSTDest |  |
| 54 | vICMSSTDest_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'vICMSST' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 55 | vBCEfet |  |
| 56 | pICMSEfet |  |
| 57 | vICMSEfet |  |
| 58 | modBC | Propriedade genérica apenas para compatibilidade com Parser XML.            Para correto funcionamento, utilizar as propriedades modBCXXXX.            A sincronização das demais para com esta, no ato da escrita do arquivo XML deve ser feita manualmente. |
| 59 | modBCSpecified |  |
| 60 | modBCST | Propriedade genérica apenas para compatibilidade com Parser XML.            Para correto funcionamento, utilizar as propriedades modBCXXXX.            A sincronização das demais para com esta, no ato da escrita do arquivo XML deve ser feita manualmente. |
| 61 | modBCSTSpecified |  |
### Methods

| Name | |
| :--- | :--- |
| ShouldSerializeCSTNormal() |  |
| ShouldSerializeCSOSN() |  |
| ShouldSerializevBC_XML() |  |
| ShouldSerializepICMS() |  |
| ShouldSerializevICMS_XML() |  |
| ShouldSerializevBCSTRet_XML() |  |
| ShouldSerializevICMSSTRet_XML() |  |
| ShouldSerializepMVAST() |  |
| ShouldSerializepRedBCST() |  |
| ShouldSerializevBCST_XML() |  |
| ShouldSerializepICMSST() |  |
| ShouldSerializevICMSST_XML() |  |
| ShouldSerializevBCFCPST_XML() |  |
| ShouldSerializepFCPST() |  |
| ShouldSerializevFCPST_XML() |  |
| ShouldSerializepRedBC() |  |
| ShouldSerializemotDesICMS() |  |
| ShouldSerializevICMSDeson() |  |
| ShouldSerializepCredSN() |  |
| ShouldSerializevCredICMSSN_XML() |  |
| ShouldSerializeUFST() |  |
| ShouldSerializepBCOp() |  |
| ShouldSerializevBCSTDest_XML() |  |
| ShouldSerializevICMSSTDest_XML() |  |
| ShouldSerializevBCEfet() |  |
| ShouldSerializepICMSEfet() |  |
| ShouldSerializevICMSEfet() |  |
| ShouldSerializemodBC() |  |
| ShouldSerializemodBCST() |  |
| OnPropertyChanged(string) |  |
