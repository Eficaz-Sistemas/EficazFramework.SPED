using System;

namespace EficazFramework.SPED.Extensions;

public static class Date
{
    public static string ToSpedString(this DateTime? field)
    {
        if (field.HasValue == true)
        {
            return string.Format("{0:ddMMyyyy}", field);
        }
        else
        {
            return null;
        }
    }

    public static string ToSintegraString(this DateTime? field, DateFormat format)
    {
        if (field.HasValue == true)
        {
            string tmp_string = "ddMMyyyy";
            switch (format)
            {
                case DateFormat.AAAADDMM:
                    {
                        tmp_string = "yyyyddMM";
                        break;
                    }

                case DateFormat.AAAAMMDD:
                    {
                        tmp_string = "yyyyMMdd";
                        break;
                    }

                case DateFormat.DDMMAAAA:
                    {
                        tmp_string = "ddMMyyyy";
                        break;
                    }

                case DateFormat.MMDDAAAA:
                    {
                        tmp_string = "MMddyyyy";
                        break;
                    }

                case DateFormat.MMAAAA:
                    {
                        tmp_string = "MMyyyy";
                        break;
                    }

                case DateFormat.AAAAMM:
                    {
                        tmp_string = "yyyyMM";
                        break;
                    }

                case DateFormat.DD:
                    {
                        tmp_string = "dd";
                        break;
                    }
            }

            return string.Format("{0:" + tmp_string + "}", field);
        }
        else
        {
            return "00000000";
        }
    }

    public static string ToSintegraString(this DateTime field, DateFormat format)
    {
        string tmp_string = "ddMMyyyy";
        switch (format)
        {
            case DateFormat.AAAADDMM:
                {
                    tmp_string = "yyyyddMM";
                    break;
                }

            case DateFormat.AAAAMMDD:
                {
                    tmp_string = "yyyyMMdd";
                    break;
                }

            case DateFormat.DDMMAAAA:
                {
                    tmp_string = "ddMMyyyy";
                    break;
                }

            case DateFormat.MMDDAAAA:
                {
                    tmp_string = "MMddyyyy";
                    break;
                }

            case DateFormat.MMAAAA:
                {
                    tmp_string = "MMyyyy";
                    break;
                }

            case DateFormat.AAAAMM:
                {
                    tmp_string = "yyyyMM";
                    break;
                }

            case DateFormat.DD:
                {
                    tmp_string = "dd";
                    break;
                }
        }

        return string.Format("{0:" + tmp_string + "}", field);
    }

    /// <summary>
    /// Retorna a primeira data disponível para um mês e ano determinado.
    /// </summary>
    /// <param name="BaseDate">A data a ser analisada.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DateTime MonthStartDate(this DateTime BaseDate)
    {
        return new DateTime(BaseDate.Year, BaseDate.Month, 1, 0, 0, 0);
    }

    /// <summary>
    /// Retorna a primeira data disponível para um mês e ano determinado.
    /// </summary>
    /// <param name="BaseDate">A data a ser analisada.</param>
    /// <param name="UseTime235959">Define se a data deve ser retornada com Timespan 23:59:59.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DateTime MonthEndDate(this DateTime BaseDate, bool UseTime235959 = false)
    {
        DateTime tmp_date;
        switch (BaseDate.Month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                {
                    if (UseTime235959 == false)
                        tmp_date = new DateTime(BaseDate.Year, BaseDate.Month, 31);
                    else
                        tmp_date = new DateTime(BaseDate.Year, BaseDate.Month, 31, 23, 59, 59);
                    break;
                }

            case 4:
            case 6:
            case 9:
            case 11:
                {
                    if (UseTime235959 == false)
                        tmp_date = new DateTime(BaseDate.Year, BaseDate.Month, 30);
                    else
                        tmp_date = new DateTime(BaseDate.Year, BaseDate.Month, 30, 23, 59, 59);
                    break;
                }

            case 2:
                {
                    try
                    {
                        if (UseTime235959 == false)
                            tmp_date = new DateTime(BaseDate.Year, BaseDate.Month, 29);
                        else
                            tmp_date = new DateTime(BaseDate.Year, BaseDate.Month, 29, 23, 59, 59);
                    }
                    catch (Exception)
                    {
                        if (UseTime235959 == false)
                            tmp_date = new DateTime(BaseDate.Year, BaseDate.Month, 28);
                        else
                            tmp_date = new DateTime(BaseDate.Year, BaseDate.Month, 28, 23, 59, 59);
                    }

                    break;
                }

            default:
                {
                    return default;
                }
        }

        return tmp_date;
    }

    public static string ToEFDReinfCompetencia(this DateTime? field)
    {
        if (field.HasValue == true)
        {
            return string.Format("{0:yyyy-MM}", field.Value);
        }
        else
        {
            return null;
        }
    }

    public static string ToEFDReinfCompetencia(this DateTime field)
    {
        return string.Format("{0:yyyy-MM}", field);
    }
}

static class Timespan
{
    public static string ToSintegraString(this TimeSpan? field, TimeFormat format)
    {
        if (field.HasValue == true)
        {
            string tmp_string = "hhmmss";
            switch (format)
            {
                case TimeFormat.HHMMSS:
                    {
                        tmp_string = "hhmmss";
                        break;
                    }

                case TimeFormat.HHMM:
                    {
                        tmp_string = "hhmm";
                        break;
                    }
            }

            return string.Format("{0:" + tmp_string + "}", field.Value);
        }
        else
        {
            return "00000000";
        }
    }
}
