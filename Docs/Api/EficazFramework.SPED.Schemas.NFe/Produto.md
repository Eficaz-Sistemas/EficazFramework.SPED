#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## Produto Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Codigo |  |
| 03 | GTIN | Global Trade Item Number: Código do Produto, antigo código EAN ou código de barras.            Preencher com código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14. Não informar conteúdo da TAG em caso do produto não possuir este código. |
| 04 | Descricao |  |
| 05 | NCM |  |
| 06 | CEST |  |
| 07 | EXTIPI |  |
| 08 | CFOP |  |
| 09 | UnidadeComercial |  |
| 10 | QuantidadeComercial |  |
| 11 | ValorUnitarioComercial |  |
| 12 | ValorTotalBruto |  |
| 13 | ValorTotalBruto_XML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'ValorTotalBruto' (Double?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 14 | GTIN_Tributavel | Global Trade Item Number: Código do Produto, antigo código EAN ou código de barras.            Preencher com código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 da unidade tributável do produto.            Não informar conteúdo da TAG em caso do produto não possuir este código. |
| 15 | UnidadeTributavel |  |
| 16 | QuantidadeTributavel |  |
| 17 | ValorUnitarioTributavel |  |
| 18 | ValorFrete |  |
| 19 | ValorSeguro |  |
| 20 | ValorDesconto |  |
| 21 | ValorOutrasDespesas |  |
| 22 | IndicadorComposicaoTotal |  |
| 23 | NumeroFCI |  |
| 24 | PossuiFCI |  |
| 25 | Importacoes |  |
| 26 | PedidoCompraNumero |  |
| 27 | PedidoCompraItem |  |
| 28 | Detalhamentos |  |
| 29 | DetalhamentoArmamento |  |
| 30 | DetalhamentoMedicamento |  |
| 31 | DetalhamentoMedicamento_Rastro |  |
| 32 | DetalhamentoCombustivel |  |
| 33 | DetalhamentoVeiculo |  |
### Methods

| Name | |
| :--- | :--- |
| ShouldSerializeQuantidadeComercial() |  |
| ShouldSerializeValorUnitarioComercial() |  |
| ShouldSerializeValorTotalBruto_XML() |  |
| ShouldSerializeQuantidadeTributavel() |  |
| ShouldSerializeValorUnitarioTributavel() |  |
| ShouldSerializeValorFrete() |  |
| ShouldSerializeValorSeguro() |  |
| ShouldSerializeValorDesconto() |  |
| ShouldSerializeValorOutrasDespesas() |  |
| ShouldSerializePedidoCompraItem() |  |
| OnPropertyChanged(string) |  |
