#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## RegistroC170 Class

Items dos Documentos Fiscais

### Remarks
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | NumeroSequencialItem | `Nullable<Int32>` |  |
| 03 | CodigoProduto | `String` |  |
| 04 | DescricaoComplementarItem | `String` |  |
| 05 | Quantidade | `Nullable<Double>` |  |
| 06 | UnidadeMedida | `String` |  |
| 07 | TotalItem | `Nullable<Double>` |  |
| 08 | Desconto | `Nullable<Double>` |  |
| 09 | IndicadorMovimento | `Nullable<Boolean>` |  |
| 10 | Origem | `OrigemMercadoria` |  |
| 11 | CST_ICMS | `CST_ICMS` |  |
| 12 | CFOP | `String` |  |
| 13 | NaturezaOperacao | `String` |  |
| 14 | BaseCalculo_ICMS | `Nullable<Double>` |  |
| 15 | Aliquota_ICMS | `Nullable<Double>` |  |
| 16 | Valor_ICMS | `Nullable<Double>` |  |
| 17 | BaseCalculoST_ICMS | `Nullable<Double>` |  |
| 18 | AliquotaST_ICMS | `Nullable<Double>` |  |
| 19 | ValorST_ICMS | `Nullable<Double>` |  |
| 20 | IndicadorApuracaoIPI | `Nullable<IndicadorPeriodoIPI>` |  |
| 21 | CST_IPI | `String` |  |
| 22 | Enquadramento_IPI | `String` |  |
| 23 | BaseCalculo_IPI | `Nullable<Double>` |  |
| 24 | Aliquota_IPI | `Nullable<Double>` |  |
| 25 | Valor_IPI | `Nullable<Double>` |  |
| 26 | CST_PIS | `CST_PIS` |  |
| 27 | BaseCalculo_PIS | `Nullable<Double>` |  |
| 28 | BaseCalculoQuantidade_PIS | `Nullable<Double>` |  |
| 29 | AliquotaPercentual_PIS | `Nullable<Double>` |  |
| 30 | AliquotaReais_PIS | `Nullable<Double>` |  |
| 31 | Valor_PIS | `Nullable<Double>` |  |
| 32 | CST_COFINS | `CST_COFINS` |  |
| 33 | BaseCalculo_COFINS | `Nullable<Double>` |  |
| 34 | BaseCalculoQuantidade_COFINS | `Nullable<Double>` |  |
| 35 | AliquotaPercentual_COFINS | `Nullable<Double>` |  |
| 36 | AliquotaReais_COFINS | `Nullable<Double>` |  |
| 37 | Valor_COFINS | `Nullable<Double>` |  |
| 38 | CodigoContaContabil | `String` |  |
| 39 | AbatimentosNT | `Nullable<Double>` |  |
| 40 | RegistroC172 | `RegistroC172` |  |
| 41 | RegistrosC176 | `List<RegistroC176>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` |  |
| LeParametros(string[]) | `Void` |  |
