#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Extensions](EficazFramework.SPED.Extensions.md 'EficazFramework.SPED.Extensions').[FinancialExtensions](EficazFramework.SPED.Extensions/FinancialExtensions.md 'EficazFramework.SPED.Extensions.FinancialExtensions')

## FinancialExtensions.CalculaTaxa(this double, double, int, Capitalizacao, int) Method

Calcula a taxa de juros de uma operação com base no capital aplicado em um período desejado.  
NOTA: A taxa retornada será referente à unidade de tempo do período (ao dia, ao mês, etc).

```csharp
public static double CalculaTaxa(this double capital, double montante, int periodo, EficazFramework.SPED.Extensions.FinancialExtensions.Capitalizacao tipo=EficazFramework.SPED.Extensions.FinancialExtensions.Capitalizacao.JurosSimples, int rounding=-1);
```
#### Parameters

<a name='EficazFramework.SPED.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.SPED.Extensions.FinancialExtensions.Capitalizacao,int).capital'></a>

`capital` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

O capital base para cálculo.

<a name='EficazFramework.SPED.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.SPED.Extensions.FinancialExtensions.Capitalizacao,int).montante'></a>

`montante` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

O montante final (valor agregado) (capital + juros).

<a name='EficazFramework.SPED.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.SPED.Extensions.FinancialExtensions.Capitalizacao,int).periodo'></a>

`periodo` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

O período a ser aplicado.

<a name='EficazFramework.SPED.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.SPED.Extensions.FinancialExtensions.Capitalizacao,int).tipo'></a>

`tipo` [Capitalizacao](EficazFramework.SPED.Extensions/FinancialExtensions/Capitalizacao.md 'EficazFramework.SPED.Extensions.FinancialExtensions.Capitalizacao')

Juros Simples ou Juros Compostos.

<a name='EficazFramework.SPED.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.SPED.Extensions.FinancialExtensions.Capitalizacao,int).rounding'></a>

`rounding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Double

### Remarks