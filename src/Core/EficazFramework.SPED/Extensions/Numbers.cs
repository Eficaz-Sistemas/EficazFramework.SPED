using System;

namespace EficazFramework.SPED.Extensions;

public static class Number
{

    /// <summary>
    /// Retorna o número formatado na quantidade de algarismos significativos desejada.
    /// </summary>
    public static string ToSignificantDigits(this double d, int SignificantDigits, int MinDecimals = 0)
    {
        // Use G format to get significant digits.
        // Then convert to double and use F format.
        var decimalDigit = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        var gFormatted = string.Format(string.Join("", "{0:", $"G{SignificantDigits}", "}"), Math.Abs(d));
        string result = Convert.ToDecimal(gFormatted).ToString("F99");

        // Remove trailing 0s.
        result = result.TrimEnd('0');

        // Rmove the decimal point and leading 0s,
        // leaving just the digits.
        string test = result.Replace(decimalDigit, "").TrimStart('0');

        // See if we have enough significant digits.
        if (SignificantDigits > test.Length)
        {
            // Add trailing 0s.
            result += new string('0', SignificantDigits - test.Length);
        }
        else
        {
            // See if we should remove the trailing decimal point.
            if ((SignificantDigits < test.Length) &&
                result.EndsWith("."))
                result = result[0..^1];
        }
        if (result.EndsWith(decimalDigit) && MinDecimals == 0)
            result = result.Replace(decimalDigit, "");

        if (d < 0)
            result = $"-{result}";

        if (MinDecimals > 0)
        {
            var parts = result.Split(decimalDigit);
            if (parts.Length == 1 || parts[1].Length < MinDecimals)
                return double.Parse(result).ToString($"F{MinDecimals}");
        }

        return result;
    }

    /// <summary>
    /// Retorna o número formatado na quantidade de algarismos significativos desejada.
    /// </summary>
    public static string ToSignificantDigits(this double? d, int SignificantDigits, int MinDecimals = 0)
    {
        return ToSignificantDigits(d ?? 0.0D, SignificantDigits, MinDecimals);
    }

    /// <summary>
    /// Retorna o número formatado na quantidade de algarismos significativos desejada.
    /// </summary>
    public static string ToSignificantDigits(this decimal d, int SignificantDigits, int MinDecimals = 0)
    {
        return ToSignificantDigits((double)d, SignificantDigits, MinDecimals);
    }

    /// <summary>
    /// Retorna o número formatado na quantidade de algarismos significativos desejada.
    /// </summary>
    public static string ToSignificantDigits(this decimal? d, int SignificantDigits, int MinDecimals = 0)
    {
        return ToSignificantDigits((double)(d ?? 0.0M), SignificantDigits, MinDecimals);
    }

    public static string ValueToString(this short? field, bool removeSeparators = true)
    {
        if (field.HasValue == true)
        {
            if (removeSeparators == false)
            {
                return field.Value.ToString();
            }
            else
            {
                return field.Value.ToString().Replace(",", string.Empty).Replace(".", string.Empty);
            }
        }
        else
        {
            return string.Empty;
        }
    }

    public static string ValueToString(this int? field, bool removeSeparators = true)
    {
        if (field.HasValue == true)
        {
            if (removeSeparators == false)
            {
                return field.Value.ToString();
            }
            else
            {
                return field.Value.ToString().Replace(",", string.Empty).Replace(".", string.Empty);
            }
        }
        else
        {
            return string.Empty;
        }
    }

    public static string ValueToString(this long? field, bool removeSeparators = true)
    {
        if (field.HasValue == true)
        {
            if (removeSeparators == false)
            {
                return field.Value.ToString();
            }
            else
            {
                return field.Value.ToString().Replace(",", string.Empty).Replace(".", string.Empty);
            }
        }
        else
        {
            return string.Empty;
        }
    }

    public static string ValueToString(this double? field, int decimals = -1, bool removeSeparators = true)
    {
        if (field.HasValue == true)
        {
            if (decimals == -1)
            {
                if (removeSeparators == false)
                {
                    return field.Value.ToString();
                }
                else
                {
                    return field.Value.ToString().Replace(",", string.Empty).Replace(".", string.Empty);
                }
            }
            else if (removeSeparators == false)
            {
                return string.Format("{0:F" + decimals + "}", field.Value);
            }
            else
            {
                return string.Format("{0:F" + decimals + "}", field.Value).Replace(",", string.Empty).Replace(".", string.Empty);
            }
        }
        else
        {
            return string.Empty;
        }
    }

    public static string ValueToString(this decimal? field, int decimals = -1, bool removeSeparators = true)
    {
        if (field.HasValue == true)
        {
            if (decimals == -1)
            {
                if (removeSeparators == false)
                {
                    return field.Value.ToString();
                }
                else
                {
                    return field.Value.ToString().Replace(",", string.Empty).Replace(".", string.Empty);
                }
            }
            else if (removeSeparators == false)
            {
                return string.Format("{0:F" + decimals + "}", field.Value);
            }
            else
            {
                return string.Format("{0:F" + decimals + "}", field.Value).Replace(",", string.Empty).Replace(".", string.Empty);
            }
        }
        else
        {
            return string.Empty;
        }
    }

    public static string ValueToString(this short? field, string stringformat)
    {
        if (field.HasValue == true)
        {
            return string.Format(stringformat, field);
        }
        else
        {
            return string.Format(stringformat, 0);
        }
    }

    public static string ValueToString(this int? field, string stringformat)
    {
        if (field.HasValue == true)
        {
            return string.Format(stringformat, field);
        }
        else
        {
            return string.Format(stringformat, 0);
        }
    }

    public static string ValueToString(this long? field, string stringformat)
    {
        if (field.HasValue == true)
        {
            return string.Format(stringformat, field);
        }
        else
        {
            return string.Format(stringformat, 0);
        }
    }

    public static string ValueToString(this double? field, string stringformat)
    {
        if (field.HasValue == true)
        {
            return string.Format(stringformat, field);
        }
        else
        {
            return string.Format(stringformat, 0);
        }
    }

    public static string ValueToString(this decimal? field, string stringformat)
    {
        if (field.HasValue == true)
        {
            return string.Format(stringformat, field);
        }
        else
        {
            return string.Format(stringformat, 0);
        }
    }

    /// <summary>
    /// Determines whether a string is a numeric value.  This implementation uses Decimal.TryParse to produce it's value.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static bool IsNumeric(this string str)
    {
        decimal result = 0m;
        return decimal.TryParse(str, out result);
    }
}
