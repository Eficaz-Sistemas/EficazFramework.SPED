using System;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Extensions
{
    public static class String
    {
        public static DateTime? ToDate(this string SPED_String)
        {
            if (SPED_String.Length == 8)
            {
                return new DateTime(Conversions.ToInteger(SPED_String.Substring(4, 4)), Conversions.ToInteger(SPED_String.Substring(2, 2)), Conversions.ToInteger(SPED_String.Substring(0, 2)));
            }
            else
            {
                return default;
            }
        }

        public static DateTime? ToDate(this string Sintegra_String, DateFormat format)
        {
            // If Sintegra_String.Length <> 8 Then
            // Return Nothing
            // End If

            switch (Sintegra_String.Length)
            {
                case 10:
                    {
                        switch (format)
                        {
                            case DateFormat.XML_AAAAMMDD:
                                return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(0, 4)), Conversions.ToInteger(Sintegra_String.Substring(8, 2)), Conversions.ToInteger(Sintegra_String.Substring(5, 2)));

                            default:
                                return default;
                        }
                    }
                case 8:
                    {
                        switch (format)
                        {
                            case DateFormat.AAAADDMM:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(0, 4)), Conversions.ToInteger(Sintegra_String.Substring(6, 2)), Conversions.ToInteger(Sintegra_String.Substring(4, 2)));
                                }

                            case DateFormat.AAAAMMDD:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(0, 4)), Conversions.ToInteger(Sintegra_String.Substring(4, 2)), Conversions.ToInteger(Sintegra_String.Substring(6, 2)));
                                }

                            case DateFormat.DDMMAAAA:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(4, 4)), Conversions.ToInteger(Sintegra_String.Substring(2, 2)), Conversions.ToInteger(Sintegra_String.Substring(0, 2)));
                                }

                            case DateFormat.MMDDAAAA:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(4, 4)), Conversions.ToInteger(Sintegra_String.Substring(0, 2)), Conversions.ToInteger(Sintegra_String.Substring(2, 2)));
                                }

                            default:
                                {
                                    return default;
                                }
                        }
                    }

                case 6:
                    {
                        switch (format)
                        {
                            case DateFormat.AAAAMM:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(0, 4)), Conversions.ToInteger(Sintegra_String.Substring(4, 2)), 1);
                                }

                            case DateFormat.MMAAAA:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(2, 4)), Conversions.ToInteger(Sintegra_String.Substring(0, 2)), 1);
                                }

                            default:
                                {
                                    return default;
                                }
                        }
                    }

                default:
                    {
                        return default;
                    }
            }
        }

        public static TimeSpan? ToTime(this string Sintegra_String, TimeFormat format)
        {
            // If Sintegra_String.Length <> 8 Then
            // Return Nothing
            // End If

            switch (Sintegra_String.Length)
            {
                case 6:
                    {
                        switch (format)
                        {
                            case TimeFormat.HHMMSS:
                                {
                                    return new TimeSpan(Conversions.ToInteger(Sintegra_String.Substring(0, 2)), Conversions.ToInteger(Sintegra_String.Substring(2, 2)), Conversions.ToInteger(Sintegra_String.Substring(4, 2)));
                                }

                            default:
                                {
                                    return default;
                                }
                        }
                    }

                case 4:
                    {
                        switch (format)
                        {
                            case TimeFormat.HHMM:
                                {
                                    return new TimeSpan(Conversions.ToInteger(Sintegra_String.Substring(0, 2)), Conversions.ToInteger(Sintegra_String.Substring(2, 2)), 0);
                                }

                            default:
                                {
                                    return default;
                                }
                        }
                    }

                default:
                    {
                        return default;
                    }
            }
        }

        public static bool? ToNullableBool(this string SPED_String)
        {
            if (SPED_String.IsNumeric())
            {
                if (Conversions.ToInteger(SPED_String) <= 1)
                {
                    return Conversions.ToBoolean(Conversions.ToInteger(SPED_String));
                }
                else
                {
                    return (bool?)false;
                }
            }
            else
            {
                return (bool?)false;
            }
        }

        public static double? ToNullableDouble(this string SPED_String, int decimais = 0)
        {
            if (SPED_String.Length > 0)
            {
                if (SPED_String.IsNumeric())
                {
                    if (decimais == 0)
                    {
                        return Conversions.ToDouble(SPED_String);
                    }
                    else
                    {
                        int divisor = (int)Math.Pow(10d, decimais);
                        return Conversions.ToDouble(SPED_String) / divisor;
                    }
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return default;
            }
        }

        public static long? ToNullableLong(this string SPED_String)
        {
            if (SPED_String.Length > 0)
            {
                return Conversions.ToLong(SPED_String);
            }
            else
            {
                return default;
            }
        }

        public static int? ToNullableInteger(this string SPED_String)
        {
            if (SPED_String.Length > 0)
            {
                return (int?)Conversions.ToDouble(SPED_String);
            }
            else
            {
                return default;
            }
        }

        public static short? ToNullableShort(this string SPED_String)
        {
            if (SPED_String.Length > 0)
            {
                return Conversions.ToShort(SPED_String);
            }
            else
            {
                return default;
            }
        }

        public static object ToEnum<T>(this string SPED_String, object defaultValue)
        {
            if (SPED_String.Length > 0)
            {
                return Enum.Parse(typeof(T), Conversions.ToInteger(SPED_String).ToString());
            }
            else
            {
                return defaultValue;
            }
        }

        public static string ToFixedLenghtString(this string str, int lenght, Alignment alignment, string chr = " ")
        {
            var builder = new System.Text.StringBuilder();
            int actualLenght = 0;
            if (!string.IsNullOrEmpty(str))
            {
                actualLenght = str.Length;
            }

            actualLenght = Math.Min(lenght, actualLenght);
            if (alignment == Alignment.Left)
            {
                for (int i = 1, loopTo = lenght - actualLenght; i <= loopTo; i++)
                    builder.Append(chr);
                if ((str ?? "").Length > lenght)
                {
                    builder.Append(str.Substring(0, lenght));
                }
                else
                {
                    builder.Append(str);
                }
            }
            else
            {
                if ((str ?? "").Length > lenght)
                {
                    builder.Append(str.Substring(0, lenght));
                }
                else
                {
                    builder.Append(str);
                }

                for (int i = 1, loopTo1 = lenght - actualLenght; i <= loopTo1; i++)
                    builder.Append(chr);
            }

            return builder.ToString();
        }

        public static object ToFixedLenghtString(this string str, int lenght, System.Text.StringBuilder builder, Alignment alignment, string chr = " ")
        {
            if (builder != null)
            {
                builder.Clear();
            }
            else
            {
                builder = new System.Text.StringBuilder();
            }

            int actualLenght = 0;
            if (!(string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str)))
            {
                actualLenght = str.Length;
            }

            actualLenght = Math.Min(lenght, actualLenght);
            if (alignment == Alignment.Left)
            {
                for (int i = 1, loopTo = lenght - actualLenght; i <= loopTo; i++)
                    builder.Append(chr);
                if ((str ?? "").Length > lenght)
                {
                    builder.Append(str.Substring(0, lenght));
                }
                else
                {
                    builder.Append(str);
                }
            }
            else
            {
                if ((str ?? "").Length > lenght)
                {
                    builder.Append(str.Substring(0, lenght));
                }
                else
                {
                    builder.Append(str);
                }

                for (int i = 1, loopTo1 = lenght - actualLenght; i <= loopTo1; i++)
                    builder.Append(chr);
            }

            return builder.ToString();
        }

        public static string DecodeXMLString(this string base_string, string literal)
        {
            int prefix = base_string.IndexOf("<?xml");
            if (prefix > 0)
                base_string = base_string.Remove(0, prefix);
            if (literal != null)
            {
                try
                {
                    base_string = base_string.Remove(base_string.IndexOf(literal) + literal.Length);
                }
                catch
                {
                }
            }

            return base_string;
        }
    }

    public enum DateFormat
    {
        DDMMAAAA = 0,
        AAAAMMDD = 1,
        AAAADDMM = 2,
        MMDDAAAA = 3,
        MMAAAA = 4,
        AAAAMM = 5,
        DD = 6,
        XML_AAAAMMDD = 11,

    }

    public enum TimeFormat
    {
        HHMMSS = 0,
        HHMM = 1
    }

    public enum Alignment
    {
        Left = 0,
        Right = 1
    }
}