
namespace EficazFramework.SPED.Extensions;

public static class Number
{
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
