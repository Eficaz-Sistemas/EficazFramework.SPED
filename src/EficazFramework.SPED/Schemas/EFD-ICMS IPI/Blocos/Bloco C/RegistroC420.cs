using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Registro Totalizador Parcial da Redução Z
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC420 : Primitives.Registro
    {
        public RegistroC420() : base("C420")
        {
        }

        public RegistroC420(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C420|"); // 1
            writer.Append(CodigoTotalizador + "|"); // 2
            writer.Append(ValorAcumulado + "|"); // 3
            writer.Append(Numero + "|"); // 4
            writer.Append(Descricao + "|"); // 5
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoTotalizador = data[2];
            ValorAcumulado = data[3].ToNullableDouble();
            Numero = data[4].ToNullableInteger();
            Descricao = data[5];
        }

        public string CodigoTotalizador { get; set; } = null; // 2
        public double? ValorAcumulado { get; set; } = default; // 3
        /// <summary>
        /// Número do totalizador quando ocorrer mais de uma situação com a mesma carga tributária efetiva.
        /// </summary>
        /// <returns></returns>
        public int? Numero { get; set; } = default; // 4
        public string Descricao { get; set; } = null; // 5

        public TipoC420 TipoRegistro
        {
            get
            {
                switch (CodigoTotalizador ?? "")
                {
                    case "Can-T":
                        {
                            return TipoC420.Cancelamento_ICMS;
                        }

                    case "Can-S":
                        {
                            return TipoC420.Cancelamento_ISSQN;
                        }

                    case "Can-O":
                        {
                            return TipoC420.Cancelamento_OperacoesNaoFiscais;
                        }

                    case "IOF":
                        {
                            return TipoC420.IOF;
                        }

                    case "AT":
                        {
                            return TipoC420.Acrescimo_ICMS;
                        }

                    case "AS":
                        {
                            return TipoC420.Acrescimo_ISSQN;
                        }

                    case "AO":
                        {
                            return TipoC420.Acrescimo_OperacoesNaoFiscais;
                        }

                    case "DT":
                        {
                            return TipoC420.Desconto_ICMS;
                        }

                    case "DS":
                        {
                            return TipoC420.Desconto_ISSQN;
                        }

                    case "DO":
                        {
                            return TipoC420.Desconto_OperacoesNaoFiscais;
                        }

                    case "OPNF":
                        {
                            return TipoC420.OperacoesNaoFiscais;
                        }

                    default:
                        {
                            switch (CodigoTotalizador.Length)
                            {
                                case 2:
                                    {
                                        if (CodigoTotalizador.Contains("F"))
                                            return TipoC420.ST;
                                        if (CodigoTotalizador.Contains("I"))
                                            return TipoC420.Isento;
                                        if (CodigoTotalizador.Contains("N"))
                                            return TipoC420.NaoIncidencia;
                                        break;
                                    }

                                case 3:
                                    {
                                        if (CodigoTotalizador.Contains("FS"))
                                            return TipoC420.ST_ISSQN;
                                        if (CodigoTotalizador.Contains("IS"))
                                            return TipoC420.Isento_ISSQN;
                                        if (CodigoTotalizador.Contains("NS"))
                                            return TipoC420.NaoIncidencia_ISSQN;
                                        break;
                                    }

                                default:
                                    {
                                        if (CodigoTotalizador.Contains("T"))
                                            return TipoC420.TributadoICMS;
                                        if (CodigoTotalizador.Contains("S"))
                                            return TipoC420.TributadoISSQN;
                                        return TipoC420.NaoSei;
                                    }
                            }

                            return TipoC420.NaoSei;
                        }
                }
            }
        }

        public bool CompoeValorContabil
        {
            get
            {
                switch (TipoRegistro)
                {
                    case TipoC420.Isento:
                    case TipoC420.Isento_ISSQN:
                    case TipoC420.NaoIncidencia:
                    case TipoC420.NaoIncidencia_ISSQN:
                    case TipoC420.ST:
                    case TipoC420.ST_ISSQN:
                    case TipoC420.TributadoICMS:
                    case TipoC420.TributadoISSQN:
                        {
                            // TipoC420.TributadoICMS_X_Totalizadores,
                            // TipoC420.TributadoISSQN_X_Totalizadores
                            return true;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }
        }

        public double AliquotaEfetiva
        {
            get
            {
                if (TipoRegistro == TipoC420.TributadoICMS)
                {
                    string aliqStr = CodigoTotalizador.Substring(CodigoTotalizador.Length - 4, 4);
                    return Conversions.ToDouble(aliqStr) / 100d;
                }
                else if (TipoRegistro == TipoC420.TributadoISSQN)
                {
                    string aliqStr = CodigoTotalizador.Substring(CodigoTotalizador.Length - 4, 4);
                    return Conversions.ToDouble(aliqStr) / 100d;
                }
                else
                {
                    return 0.0d;
                }
            }
        }


        // Filhos:
        public List<RegistroC425> RegistrosC425 { get; set; } = new List<RegistroC425>();
    }
}