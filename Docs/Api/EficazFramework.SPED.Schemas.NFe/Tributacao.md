#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.NFe](EficazFramework.SPED.Schemas.NFe.md 'EficazFramework.SPED.Schemas.NFe')

## Tributacao Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | ValorTotalTributos | `Nullable<Double>` |  |
| 03 | DemaisImpostos | `List<Object>` |  |
| 04 | PIS | `DetalhamentoPIS` |  |
| 05 | PISST | `DetalhamentoPISST` |  |
| 06 | COFINS | `DetalhamentoCOFINS` |  |
| 07 | COFINSST | `DetalhamentoCOFINSST` |  |
| 08 | ICMS | `DetalhamentoICMS` |  |
| 09 | ICMSUFDestino | `DetalhamentoICMS_UF_Destinataria` |  |
| 10 | IPI | `DetalhamentoIPI` |  |
| 11 | ISSQN | `DetalhamentoISSQN` |  |
| 12 | II | `DetalhamentoII` | Imposto de Importação |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeValorTotalTributos() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
