#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Extensions](EficazFramework.SPED.Extensions.md 'EficazFramework.SPED.Extensions')

## Number Class
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ToSignificantDigits(this double, int, int) | `String` | Retorna o número formatado na quantidade de algarismos significativos desejada. |
| ToSignificantDigits(this Nullable<double>, int, int) | `String` | Retorna o número formatado na quantidade de algarismos significativos desejada. |
| ToSignificantDigits(this decimal, int, int) | `String` | Retorna o número formatado na quantidade de algarismos significativos desejada. |
| ToSignificantDigits(this Nullable<decimal>, int, int) | `String` | Retorna o número formatado na quantidade de algarismos significativos desejada. |
| ValueToString(this Nullable<short>, bool) | `String` |  |
| ValueToString(this Nullable<int>, bool) | `String` |  |
| ValueToString(this Nullable<long>, bool) | `String` |  |
| ValueToString(this Nullable<double>, int, bool) | `String` |  |
| ValueToString(this Nullable<decimal>, int, bool) | `String` |  |
| ValueToString(this Nullable<short>, string) | `String` |  |
| ValueToString(this Nullable<int>, string) | `String` |  |
| ValueToString(this Nullable<long>, string) | `String` |  |
| ValueToString(this Nullable<double>, string) | `String` |  |
| ValueToString(this Nullable<decimal>, string) | `String` |  |
| IsNumeric(this string) | `Boolean` | Determines whether a string is a numeric value.  This implementation uses Decimal.TryParse to produce it's value. |
