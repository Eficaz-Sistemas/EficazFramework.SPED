using System;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Extensions
{
    public static class String
    {
        public static DateTime? ToDate(this string SPED_String)
        {
            if (SPED_String.Length == 8)
            {
                return new DateTime(Conversions.ToInteger(SPED_String.Substring(4, 4)), Conversions.ToInteger(SPED_String.Substring(2, 2)), Conversions.ToInteger(SPED_String[..2]));
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
                        return format switch
                        {
                            DateFormat.XML_AAAAMMDD => new DateTime(Conversions.ToInteger(Sintegra_String[..4]), Conversions.ToInteger(Sintegra_String.Substring(8, 2)), Conversions.ToInteger(Sintegra_String.Substring(5, 2))),
                            _ => default,
                        };
                    }
                case 8:
                    {
                        switch (format)
                        {
                            case DateFormat.AAAADDMM:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String[..4]), Conversions.ToInteger(Sintegra_String.Substring(6, 2)), Conversions.ToInteger(Sintegra_String.Substring(4, 2)));
                                }

                            case DateFormat.AAAAMMDD:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String[..4]), Conversions.ToInteger(Sintegra_String.Substring(4, 2)), Conversions.ToInteger(Sintegra_String.Substring(6, 2)));
                                }

                            case DateFormat.DDMMAAAA:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(4, 4)), Conversions.ToInteger(Sintegra_String.Substring(2, 2)), Conversions.ToInteger(Sintegra_String[..2]));
                                }

                            case DateFormat.MMDDAAAA:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(4, 4)), Conversions.ToInteger(Sintegra_String[..2]), Conversions.ToInteger(Sintegra_String.Substring(2, 2)));
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
                                    return new DateTime(Conversions.ToInteger(Sintegra_String[..4]), Conversions.ToInteger(Sintegra_String.Substring(4, 2)), 1);
                                }

                            case DateFormat.MMAAAA:
                                {
                                    return new DateTime(Conversions.ToInteger(Sintegra_String.Substring(2, 4)), Conversions.ToInteger(Sintegra_String[..2]), 1);
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
                                    return new TimeSpan(Conversions.ToInteger(Sintegra_String[..2]), Conversions.ToInteger(Sintegra_String.Substring(2, 2)), Conversions.ToInteger(Sintegra_String.Substring(4, 2)));
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
                                    return new TimeSpan(Conversions.ToInteger(Sintegra_String[..2]), Conversions.ToInteger(Sintegra_String.Substring(2, 2)), 0);
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
                    builder.Append(str[..lenght]);
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
                    builder.Append(str[..lenght]);
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
                    builder.Append(str[..lenght]);
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
                    builder.Append(str[..lenght]);
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

        public static string RemoveAccents(this string texto)
        {
            texto = Regex.Replace(texto, "[á|à|ä|â|ã]", "a", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[é|è|ë|ê]", "e", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[í|ì|ï|î]", "i", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[ó|ò|ö|ô|õ]", "o", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[ú|ù|ü|û]", "u", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[Á|À|Ä|Â|Ã]", "A", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[É|È|Ë|Ê]", "E", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[Í|Ì|Ï|Î]", "I", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[Ó|Ò|Ö|Ô|Õ]", "O", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[Ú|Ù|Ü|Û]", "U", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            texto = Regex.Replace(texto, "[Ç]", "C", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
            return texto;
        }

        /// <summary>
        /// Insere a máscara de formatação em um CNPJ ou CPF.
        /// </summary>
        /// <param name="documento">O documento a ser formatado.</param>
        /// <returns>String</returns>
        /// <remarks></remarks>
        public static string FormatRFBDocument(this string documento)
        {
            if (documento is null)
            {
                return documento;
            }

            switch (documento.Trim().Length)
            {
                case 14:
                    {
                        if (documento.Contains('.') | documento.Contains('-'))
                            return documento;
                        else
                            return FormataCNPJ(documento);
                    }

                case 11:
                    {
                        return FormataCPF(documento);
                    }

                default:
                    {
                        return documento;
                    }
            }
        }

        private static string FormataCNPJ(this string documento)
        {
            return documento[..2] + "." + documento.Substring(2, 3) + "." + documento.Substring(5, 3) + "/" + documento.Substring(8, 4) + "-" + documento.Substring(12, 2);
        }

        private static string FormataCPF(this string documento)
        {
            return documento[..3] + "." + documento.Substring(3, 3) + "." + documento.Substring(6, 3) + "-" + documento.Substring(9, 2);
        }

        /// <summary>
        /// Insere a máscara de formatação a um CEP.
        /// </summary>
        /// <param name="base">O CEP a ser formatado.</param>
        /// <returns>String</returns>
        /// <remarks></remarks>
        public static string FormatCEP(this string @base)
        {
            @base = @base.Replace("-", string.Empty).Replace(".", string.Empty).Replace(",", string.Empty).Replace("_", string.Empty);
            switch (@base.Length)
            {
                case 4:
                    {
                        return @base[..1] + "-" + @base.Substring(1, 3);
                    }

                case 5:
                    {
                        return @base[..2] + "-" + @base.Substring(2, 3);
                    }

                case 6:
                    {
                        return @base[..3] + "-" + @base.Substring(3, 3);
                    }

                case 7:
                    {
                        return @base[..1] + "." + @base.Substring(1, 3) + "-" + @base.Substring(4, 3);
                    }

                case 8:
                    {
                        return @base[..2] + "." + @base.Substring(2, 3) + "-" + @base.Substring(5, 3);
                    }

                case 9:
                    {
                        return @base[..3] + "." + @base.Substring(3, 3) + "-" + @base.Substring(6, 3);
                    }

                case 10:
                    {
                        return @base[..1] + "." + @base.Substring(1, 3) + "." + @base.Substring(4, 3) + "-" + @base.Substring(7, 3);
                    }

                case 11:
                    {
                        return @base[..2] + "." + @base.Substring(2, 3) + "." + @base.Substring(5, 3) + "-" + @base.Substring(8, 3);
                    }

                case 12:
                    {
                        return @base[..3] + "." + @base.Substring(3, 3) + "." + @base.Substring(6, 3) + "-" + @base.Substring(9, 3);
                    }

                default:
                    {
                        return @base;
                    }
            }
        }


        /// <summary>
        /// Insere a máscara de formatação em uma Inscrição Estadual
        /// </summary>
        /// <param name="vIE">O documento a ser formatado.</param>
        /// <returns>String</returns>
        /// <remarks></remarks>
        public static string FormatIE(this string vIE, string vUF)
        {
            if (vIE.ToLower() == "isento" | vIE.ToLower() == "isenta")
                return vIE;
            if (string.IsNullOrEmpty(vIE) | string.IsNullOrWhiteSpace(vIE) | string.IsNullOrEmpty(vUF) | string.IsNullOrWhiteSpace(vUF))
                return vIE;
            if (long.TryParse(vIE, out _) == false)
                return vIE;
            return FormataIE(vIE, vUF);
        }

        private static string FormataIE(this string IE, string UF)
        {
            switch (UF ?? "")
            {
                case "AC":
                    {
                        return string.Format(@"{0:00\.000\.000\/000\-00}", Conversions.ToLong(IE)); // (IE, "@@.@@@.@@@/@@@-@@")
                    }

                case "AL":
                    {
                        return string.Format("{0:000000000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

                case "AP":
                    {
                        return string.Format("{0:000000000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

                case "AM":
                    {
                        return string.Format(@"{0:00\.000\.000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@.@@@.@@@-@")

                case "BA":
                    {
                        return string.Format(@"{0:000000\-00}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@-@@")

                case "CE":
                    {
                        return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@-@")

                case "DF":
                    {
                        return string.Format(@"{0:00000000000\-00}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@@@-@@")

                case "ES":
                    {
                        return string.Format("{0:000000000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

                case "GO":
                    {
                        return string.Format(@"{0:00\.000\.000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@.@@@.@@@-@")

                case "MA":
                    {
                        return string.Format("{0:000000000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

                case "MT":
                    {
                        return string.Format(@"{0:0000000000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@@-@")

                case "MS":
                    {
                        return string.Format("{0:000000000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

                case "MG":
                    {
                        return string.Format(@"{0:000\.000000\.00\-00}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@.@@@@@@.@@-@@")

                case "PA":
                    {
                        return string.Format(@"{0:00\.000000\.0\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@.@@@@@@.@-@")

                case "PB":
                    {
                        return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@-@")

                case "PR":
                    {
                        return string.Format(@"{0:00000000\-00}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@-@@")

                case "PE":
                    {
                        return string.Format(@"{0:00\.0\.000\.0000000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@.@.@@@.@@@@@@@-@")

                case "PI":
                    {
                        return string.Format("{0:000000000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

                case "RJ":
                    {
                        return string.Format(@"{0:00\.000\.00\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@.@@@.@@-@")

                case "RN":
                    {
                        return string.Format(@"{0:00\.000\.000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@.@@@.@@@-@")

                case "RS":
                    {
                        return string.Format(@"{0:000\/0000000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@/@@@@@@@")

                case "RO":
                    {
                        return string.Format(@"{0:000\.00000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@.@@@@@-@")

                case "RR":
                    {
                        return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@-@")

                case "SC":
                    {
                        return string.Format(@"{0:000\.000\.000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@.@@@.@@@")

                case "SP":
                    {
                        return string.Format(@"{0:000\.000\.000\.000}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@.@@@.@@@.@@@")

                case "SE":
                    {
                        return string.Format(@"{0:000000000\-0}", Conversions.ToLong(IE));
                    }
                // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@-@")

                case "TO":
                    {
                        // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@@@")

                        return string.Format("{0:00000000000}", Conversions.ToLong(IE));
                    }

                default:
                    {
                        return IE; // "ISENTO"
                    }
            }
        }

        /// <summary>
        /// Verifica a veracidade do número de CNPJ informado.
        /// </summary>
        /// <param name="CNPJ">O CNPJ a ser analisado.</param>
        /// <returns>Boolean</returns>
        /// <remarks>Antes de utilizar este método, faz-se necessário remover a máscara do número.</remarks>
        public static bool IsValidCNPJ(this string CNPJ)
        {
            try
            {
                // Declara as variáveis
                var digit = new int[13];
                var verify = new int[13];
                int st_value, nd_value;
                int[] calc = new int[13];
                int calc_t, resto;

                // CÁLCULO DO PRIMEIRO DÍGITO VERIFICADOR:
                // define os valores fixos para cálculo do 1º dígito verificador
                verify[0] = 5;
                verify[1] = 4;
                verify[2] = 3;
                verify[3] = 2;
                verify[4] = 9;
                verify[5] = 8;
                verify[6] = 7;
                verify[7] = 6;
                verify[8] = 5;
                verify[9] = 4;
                verify[10] = 3;
                verify[11] = 2;

                // obtém os valores de cada dígito do cnpj informado pelo usuário
                for (int ic = 0; ic <= 11; ic++)
                    digit[ic] = Conversions.ToInteger(CNPJ.Substring(ic, 1));

                // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
                int i;
                calc_t = 0;
                for (i = 0; i <= 11; i++)
                {
                    calc[i] = verify[i] * digit[i];
                    calc_t += calc[i];
                }

                if (calc_t == 0)
                {
                    return false;
                }

                // realiza a divisão do somatório por 11 e captura o resto da divisão
                resto = calc_t % 11;

                // analisa o resto da divisão e apura o valor do primeiro dígito verificador
                if (resto < 2)
                {
                    st_value = 0;
                }
                else
                {
                    st_value = 11 - resto;
                }

                // CÁLCULO DO SEGUNDO DÍGITO VERIFICADOR:
                // nessa etapa os numeros da tabela "verify" foram modificados, além da 
                // adição de mais um algarismo, para ser multiplicado com o valor do primeiro
                // dígito verificador encontrado
                // define os valores fixos para cálculo do 2º dígito verificador
                verify[0] = 6;
                verify[1] = 5;
                verify[2] = 4;
                verify[3] = 3;
                verify[4] = 2;
                verify[5] = 9;
                verify[6] = 8;
                verify[7] = 7;
                verify[8] = 6;
                verify[9] = 5;
                verify[10] = 4;
                verify[11] = 3;
                verify[12] = 2;
                digit[12] = st_value;

                // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
                int j;
                calc_t = 0;
                for (j = 0; j <= 12; j++)
                {
                    calc[j] = verify[j] * digit[j];
                    calc_t += calc[j];
                }

                // realiza a divisão do somatório por 11 e captura o resto da divisão
                resto = calc_t % 11;

                // analisa o resto da divisão e apura o valor do segundo dígito verificador
                if (resto < 2)
                {
                    nd_value = 0;
                }
                else
                {
                    nd_value = 11 - resto;
                }

                // compara os dígitos apurados com os informados pelo usuário
                if (st_value == Conversions.ToInteger(CNPJ.Substring(12, 1)) & nd_value == Conversions.ToInteger(CNPJ.Substring(13, 1)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica a veracidade do número de CPF informado.
        /// </summary>
        /// <param name="CPF">O CPF a ser analisado.</param>
        /// <returns>Boolean</returns>
        /// <remarks>Antes de utilizar este método, faz-se necessário remover a máscara do número.</remarks>
        public static bool IsValidCPF(this string CPF)
        {
            try
            {
                // Declara as variáveis
                var digit = new int[10];
                var verify = new int[10];
                int st_value, nd_value;
                int[] calc = new int[10];
                int calc_t, resto;

                // CÁLCULO DO PRIMEIRO DÍGITO VERIFICADOR:
                // define os valores fixos para cálculo do 1º dígito verificador
                verify[0] = 10;
                verify[1] = 9;
                verify[2] = 8;
                verify[3] = 7;
                verify[4] = 6;
                verify[5] = 5;
                verify[6] = 4;
                verify[7] = 3;
                verify[8] = 2;

                // obtém os valores de cada dígito do cnpj informado pelo usuário
                for (int ic = 0; ic <= 8; ic++)
                    digit[ic] = Conversions.ToInteger(CPF.Substring(ic, 1));

                // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
                int i;
                calc_t = 0;
                for (i = 0; i <= 8; i++)
                {
                    calc[i] = verify[i] * digit[i];
                    calc_t += calc[i];
                }

                if (calc_t == 0)
                {
                    return false;
                }

                // realiza a divisão do somatório por 11 e captura o resto da divisão
                resto = calc_t % 11;

                // analisa o resto da divisão e apura o valor do primeiro dígito verificador
                if (resto < 2)
                {
                    st_value = 0;
                }
                else
                {
                    st_value = 11 - resto;
                }

                // CÁLCULO DO SEGUNDO DÍGITO VERIFICADOR:
                // nessa etapa os numeros da tabela "verify" foram modificados, além da 
                // adição de mais um algarismo, para ser multiplicado com o valor do primeiro
                // dígito verificador encontrado
                // define os valores fixos para cálculo do 2º dígito verificador
                verify[0] = 11;
                verify[1] = 10;
                verify[2] = 9;
                verify[3] = 8;
                verify[4] = 7;
                verify[5] = 6;
                verify[6] = 5;
                verify[7] = 4;
                verify[8] = 3;
                verify[9] = 2;
                digit[9] = st_value;

                // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
                int j;
                calc_t = 0;
                for (j = 0; j <= 9; j++)
                {
                    calc[j] = verify[j] * digit[j];
                    calc_t += calc[j];
                }

                // realiza a divisão do somatório por 11 e captura o resto da divisão
                resto = calc_t % 11;

                // analisa o resto da divisão e apura o valor do segundo dígito verificador
                if (resto < 2)
                {
                    nd_value = 0;
                }
                else
                {
                    nd_value = 11 - resto;
                }

                // compara os dígitos apurados com os informados pelo usuário
                if (st_value == Conversions.ToInteger(CPF.Substring(9, 1)) & nd_value == Conversions.ToInteger(CPF.Substring(10, 1)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
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