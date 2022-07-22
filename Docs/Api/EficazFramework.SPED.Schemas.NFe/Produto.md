#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## Produto Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Codigo | `String` |  |
| GTIN | `String` | Global Trade Item Number: Código do Produto, antigo código EAN ou código de barras.            Preencher com código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14. Não informar conteúdo da TAG em caso do produto não possuir este código. |
| Descricao | `String` |  |
| NCM | `String` |  |
| CEST | `String` |  |
| EXTIPI | `String` |  |
| CFOP | `String` |  |
| UnidadeComercial | `String` |  |
| QuantidadeComercial | `Nullable<Double>` |  |
| ValorUnitarioComercial | `Nullable<Double>` |  |
| ValorTotalBruto | `Nullable<Double>` |  |
| ValorTotalBruto_XML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'ValorTotalBruto' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| GTIN_Tributavel | `String` | Global Trade Item Number: Código do Produto, antigo código EAN ou código de barras.            Preencher com código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 da unidade tributável do produto.            Não informar conteúdo da TAG em caso do produto não possuir este código. |
| UnidadeTributavel | `String` |  |
| QuantidadeTributavel | `Nullable<Double>` |  |
| ValorUnitarioTributavel | `Nullable<Double>` |  |
| ValorFrete | `Nullable<Double>` |  |
| ValorSeguro | `Nullable<Double>` |  |
| ValorDesconto | `Nullable<Double>` |  |
| ValorOutrasDespesas | `Nullable<Double>` |  |
| IndicadorComposicaoTotal | `IndicadorTotal` |  |
| NumeroFCI | `String` |  |
| PossuiFCI | `Boolean` |  |
| Importacoes | `List<DeclaracaoImportacao>` |  |
| PedidoCompraNumero | `String` |  |
| PedidoCompraItem | `Nullable<Int32>` |  |
| Detalhamentos | `List<Object>` |  |
| DetalhamentoArmamento | `List<DetalhamentoItemArma>` |  |
| DetalhamentoMedicamento | `List<DetalhamentoItemMedicamento>` |  |
| DetalhamentoMedicamento_Rastro | `List<DetalhamentoItemMedicamento_Rastro>` |  |
| DetalhamentoCombustivel | `DetalhamentoItemCombustivel` |  |
| DetalhamentoVeiculo | `DetalhamentoItemVeiculo` |  |

| Methods | |
| :--- | :--- |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.NFe/Produto/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.NFe.Produto.OnPropertyChanged(string)') | |
| [ShouldSerializePedidoCompraItem()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializePedidoCompraItem().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializePedidoCompraItem()') | |
| [ShouldSerializeQuantidadeComercial()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeQuantidadeComercial().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeQuantidadeComercial()') | |
| [ShouldSerializeQuantidadeTributavel()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeQuantidadeTributavel().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeQuantidadeTributavel()') | |
| [ShouldSerializeValorDesconto()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeValorDesconto().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeValorDesconto()') | |
| [ShouldSerializeValorFrete()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeValorFrete().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeValorFrete()') | |
| [ShouldSerializeValorOutrasDespesas()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeValorOutrasDespesas().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeValorOutrasDespesas()') | |
| [ShouldSerializeValorSeguro()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeValorSeguro().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeValorSeguro()') | |
| [ShouldSerializeValorTotalBruto_XML()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeValorTotalBruto_XML().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeValorTotalBruto_XML()') | |
| [ShouldSerializeValorUnitarioComercial()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeValorUnitarioComercial().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeValorUnitarioComercial()') | |
| [ShouldSerializeValorUnitarioTributavel()](EficazFramework.SPED.Schemas.NFe/Produto/ShouldSerializeValorUnitarioTributavel().md 'EficazFramework.SPED.Schemas.NFe.Produto.ShouldSerializeValorUnitarioTributavel()') | |
