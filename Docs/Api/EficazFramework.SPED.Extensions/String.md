#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Extensions](EficazFramework.SPED.Extensions.md 'EficazFramework.SPED.Extensions')

## String Class
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ToDate(this string) | `Nullable<DateTime>` |  |
| ToDate(this string, DateFormat) | `Nullable<DateTime>` |  |
| ToTime(this string, TimeFormat) | `Nullable<TimeSpan>` |  |
| ToNullableBool(this string) | `Nullable<Boolean>` |  |
| ToNullableDouble(this string, int) | `Nullable<Double>` |  |
| ToNullableLong(this string) | `Nullable<Int64>` |  |
| ToNullableInteger(this string) | `Nullable<Int32>` |  |
| ToNullableShort(this string) | `Nullable<Int16>` |  |
| ToEnum<T>(this string, object) | `Object` |  |
| ToFixedLenghtString(this string, int, Alignment, string) | `String` |  |
| ToFixedLenghtString(this string, int, StringBuilder, Alignment, string) | `Object` |  |
| DecodeXMLString(this string, string) | `String` |  |
| RemoveAccents(this string) | `String` |  |
| FormatRFBDocument(this string) | `String` | Insere a máscara de formatação em um CNPJ ou CPF. |
| FormatCEP(this string) | `String` | Insere a máscara de formatação a um CEP. |
| FormatIE(this string, string) | `String` | Insere a máscara de formatação em uma Inscrição Estadual |
| IsValidCNPJ(this string) | `Boolean` | Verifica a veracidade do número de CNPJ informado. |
| IsValidCPF(this string) | `Boolean` | Verifica a veracidade do número de CPF informado. |
