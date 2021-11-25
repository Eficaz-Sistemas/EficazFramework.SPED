using System;

namespace EficazFramework.SPED.Extensions;

public static class FinancialExtensions
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum ReturnType
    {
        Juros = 0,
        Montante = 1
    }

    public enum Capitalizacao
    {
        JurosSimples = 0,
        JurosCompostos = 1
    }

    public enum PeriodoCapitalizacao
    {
        Diario = 0,
        Semanal = 1,
        Mensal = 2,
        Anual = 3
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Calcula os juros sobre um capital, a uma taxa e período desejado.
    /// NOTA: periodo e taxa devem estar na mesma unidade de tempo (ao dia, ao mês, etc).
    /// </summary>
    /// <param name="capital">O capital base para cálculo.</param>
    /// <param name="taxa">A taxa de juros a ser aplicada.</param>
    /// <param name="periodo">O período a ser aplicado.</param>
    /// <param name="retorno">Montante: Retorna o valor do capital corrigido. Juros: Retorna apenas o valor dos juros calculados.</param>
    /// <param name="tipo">Juros Simples ou Juros Compostos.</param>
    /// <param name="rounding">Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.</param>
    /// <returns>Double</returns>
    /// <remarks></remarks>
    public static double CalculaJuros(this double capital, double taxa, int periodo, ReturnType retorno = ReturnType.Montante, Capitalizacao tipo = Capitalizacao.JurosSimples, int rounding = -1)
    {
        double resultado = 0d;
        switch (tipo)
        {
            case Capitalizacao.JurosSimples:
                {
                    switch (retorno)
                    {
                        case ReturnType.Montante:
                            {
                                resultado = capital * (1d + taxa / 100d) * periodo;
                                break;
                            }

                        case ReturnType.Juros:
                            {
                                resultado = capital * (taxa / 100d * periodo);
                                break;
                            }
                    }

                    break;
                }

            case Capitalizacao.JurosCompostos:
                {
                    switch (retorno)
                    {
                        case ReturnType.Montante:
                            {
                                resultado = Math.Pow(capital * (1d + taxa / 100d), periodo);
                                break;
                            }

                        case ReturnType.Juros:
                            {
                                resultado = Math.Pow(capital * (taxa / 100d), periodo);
                                break;
                            }
                    }

                    break;
                }
        }

        if (rounding <= -1)
        {
            return resultado;
        }
        else
        {
            return Math.Round(resultado, rounding);
            // Return (Round(resultado * Pow(1, rounding), 0) / (Pow(1, rounding)))
        }
    }

    /// <summary>
    /// Calcula os juros sobre um capital, a uma taxa e período desejado.
    /// NOTA: periodo e taxa devem estar na mesma unidade de tempo (ao dia, ao mês, etc).
    /// </summary>
    /// <param name="capital">O capital base para cálculo.</param>
    /// <param name="taxa">A taxa de juros a ser aplicada.</param>
    /// <param name="periodo">O período a ser aplicado.</param>
    /// <param name="retorno">Montante: Retorna o valor do capital corrigido. Juros: Retorna apenas o valor dos juros calculados.</param>
    /// <param name="tipo">Juros Simples ou Juros Compostos.</param>
    /// <param name="rounding">Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.</param>
    /// <returns>Double</returns>
    /// <remarks></remarks>
    public static double CalculaJuros(this double? capital, double taxa, int periodo, ReturnType retorno = ReturnType.Montante, Capitalizacao tipo = Capitalizacao.JurosSimples, int rounding = -1)
    {
        double resultado = 0d;
        double cap = capital.Value;
        switch (tipo)
        {
            case Capitalizacao.JurosSimples:
                {
                    switch (retorno)
                    {
                        case ReturnType.Montante:
                            {
                                resultado = cap * (1d + taxa / 100d) * periodo;
                                break;
                            }

                        case ReturnType.Juros:
                            {
                                resultado = cap * (taxa / 100d * periodo);
                                break;
                            }
                    }

                    break;
                }

            case Capitalizacao.JurosCompostos:
                {
                    switch (retorno)
                    {
                        case ReturnType.Montante:
                            {
                                resultado = Math.Pow(cap * (1d + taxa / 100d), periodo);
                                break;
                            }

                        case ReturnType.Juros:
                            {
                                resultado = Math.Pow(cap * (taxa / 100d), periodo);
                                break;
                            }
                    }

                    break;
                }
        }

        if (rounding <= -1)
        {
            return resultado;
        }
        else
        {
            return Math.Round(resultado, rounding);
            // Return (Round(resultado * Pow(1, rounding), 0) / (Pow(1, rounding)))
        }
    }

    /// <summary>
    /// Calcula a taxa de juros de uma operação com base no capital aplicado em um período desejado.
    /// NOTA: A taxa retornada será referente à unidade de tempo do período (ao dia, ao mês, etc).
    /// </summary>
    /// <param name="capital">O capital base para cálculo.</param>
    /// <param name="montante">O montante final (valor agregado) (capital + juros).</param>
    /// <param name="periodo">O período a ser aplicado.</param>
    /// <param name="tipo">Juros Simples ou Juros Compostos.</param>
    /// <param name="rounding">Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.</param>
    /// <returns>Double</returns>
    /// <remarks></remarks>
    public static double CalculaTaxa(this double capital, double montante, int periodo, Capitalizacao tipo = Capitalizacao.JurosSimples, int rounding = -1)
    {
        double resultado = 0d;
        switch (tipo)
        {
            case Capitalizacao.JurosSimples:
                {
                    resultado = capital * periodo / (montante - capital) / 100d;
                    break;
                }

            case Capitalizacao.JurosCompostos:
                {
                    break;
                }
                // TODO...
                // Return 0
        }

        if (rounding <= -1)
        {
            return resultado;
        }
        else
        {
            return Math.Round(resultado, rounding);
            // Return (Round(resultado * Pow(1, rounding), 0) / (Pow(1, rounding)))
        }
    }

    /// <summary>
    /// Calcula a taxa de juros de uma operação com base no capital aplicado em um período desejado.
    /// NOTA: A taxa retornada será referente à unidade de tempo do período (ao dia, ao mês, etc).
    /// </summary>
    /// <param name="capital">O capital base para cálculo.</param>
    /// <param name="montante">O montante final (valor agregado) (capital + juros).</param>
    /// <param name="periodo">O período a ser aplicado.</param>
    /// <param name="tipo">Juros Simples ou Juros Compostos.</param>
    /// <param name="rounding">Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.</param>
    /// <returns>Double</returns>
    /// <remarks></remarks>
    public static double CalculaTaxa(this double? capital, double montante, int periodo, Capitalizacao tipo = Capitalizacao.JurosSimples, int rounding = -1)
    {
        double resultado = 0d;
        double cap = capital.Value;
        switch (tipo)
        {
            case Capitalizacao.JurosSimples:
                {
                    resultado = cap * periodo / (montante - cap) / 100d;
                    break;
                }

            case Capitalizacao.JurosCompostos:
                {
                    break;
                }
                // TODO...
                // Return 0
        }

        if (rounding <= -1)
        {
            return resultado;
        }
        else
        {
            return Math.Round(resultado, rounding);
            // Return (Round(resultado * Pow(1, rounding), 0) / (Pow(1, rounding)))
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}
