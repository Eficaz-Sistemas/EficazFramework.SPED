#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## Produto Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Codigo | `String` |  |
| 03 | GTIN | `String` | Global Trade Item Number: Código do Produto, antigo código EAN ou código de barras.            Preencher com código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14. Não informar conteúdo da TAG em caso do produto não possuir este código. |
| 04 | Descricao | `String` |  |
| 05 | NCM | `String` |  |
| 06 | CEST | `String` |  |
| 07 | EXTIPI | `String` |  |
| 08 | CFOP | `String` |  |
| 09 | UnidadeComercial | `String` |  |
| 10 | QuantidadeComercial | `Nullable<Double>` |  |
| 11 | ValorUnitarioComercial | `Nullable<Double>` |  |
| 12 | ValorTotalBruto | `Nullable<Double>` |  |
| 13 | ValorTotalBruto_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'ValorTotalBruto' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 14 | GTIN_Tributavel | `String` | Global Trade Item Number: Código do Produto, antigo código EAN ou código de barras.            Preencher com código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 da unidade tributável do produto.            Não informar conteúdo da TAG em caso do produto não possuir este código. |
| 15 | UnidadeTributavel | `String` |  |
| 16 | QuantidadeTributavel | `Nullable<Double>` |  |
| 17 | ValorUnitarioTributavel | `Nullable<Double>` |  |
| 18 | ValorFrete | `Nullable<Double>` |  |
| 19 | ValorSeguro | `Nullable<Double>` |  |
| 20 | ValorDesconto | `Nullable<Double>` |  |
| 21 | ValorOutrasDespesas | `Nullable<Double>` |  |
| 22 | IndicadorComposicaoTotal | `IndicadorTotal` |  |
| 23 | NumeroFCI | `String` |  |
| 24 | PossuiFCI | `Boolean` |  |
| 25 | Importacoes | `List<DeclaracaoImportacao>` |  |
| 26 | PedidoCompraNumero | `String` |  |
| 27 | PedidoCompraItem | `Nullable<Int32>` |  |
| 28 | Detalhamentos | `List<Object>` |  |
| 29 | DetalhamentoArmamento | `List<DetalhamentoItemArma>` |  |
| 30 | DetalhamentoMedicamento | `List<DetalhamentoItemMedicamento>` |  |
| 31 | DetalhamentoMedicamento_Rastro | `List<DetalhamentoItemMedicamento_Rastro>` |  |
| 32 | DetalhamentoCombustivel | `DetalhamentoItemCombustivel` |  |
| 33 | DetalhamentoVeiculo | `DetalhamentoItemVeiculo` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeQuantidadeComercial() | `Boolean` |  |
| ShouldSerializeValorUnitarioComercial() | `Boolean` |  |
| ShouldSerializeValorTotalBruto_XML() | `Boolean` |  |
| ShouldSerializeQuantidadeTributavel() | `Boolean` |  |
| ShouldSerializeValorUnitarioTributavel() | `Boolean` |  |
| ShouldSerializeValorFrete() | `Boolean` |  |
| ShouldSerializeValorSeguro() | `Boolean` |  |
| ShouldSerializeValorDesconto() | `Boolean` |  |
| ShouldSerializeValorOutrasDespesas() | `Boolean` |  |
| ShouldSerializePedidoCompraItem() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
