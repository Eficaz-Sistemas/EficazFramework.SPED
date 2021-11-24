using System;
using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Movimentação de BEM ou Componente do Ativo Imobilizado
    /// </summary>
    /// <remarks></remarks>
    public class RegistroG125 : Primitives.Registro
    {
        public RegistroG125() : base("G125")
        {
        }

        public RegistroG125(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|G125|"); // 01
            writer.Append(CodigoBem + "|"); // 02
            writer.Append(DataMovimento.ToSpedString() + "|"); // 03
            writer.Append(TipoMov_EnumToString(TipoMovimento) + "|"); // 04
            writer.Append(string.Format("{0:0.##}", ICMS_OpPropria_Entrada) + "|"); // 05
            writer.Append(string.Format("{0:0.##}", ICMS_ST_Entrada) + "|"); // 06
            writer.Append(string.Format("{0:0.##}", ICMS_Frete_Entrada) + "|"); // 07
            writer.Append(string.Format("{0:0.########}", ICMS_Difal_Entrada) + "|"); // 08
            writer.Append(string.Format("{0:000}", NumeroParcela) + "|"); // 09
            writer.Append(string.Format("{0:0.##}", ValorParcelaAprop) + "|"); // 10
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoBem = data[2];
            DataMovimento = data[3].ToDate();
            TipoMovimento = TipoMov_StringToEnum(data[4]);
            ICMS_OpPropria_Entrada = data[5].ToNullableDouble();
            ICMS_ST_Entrada = data[6].ToNullableDouble();
            ICMS_Frete_Entrada = data[7].ToNullableDouble();
            ICMS_Difal_Entrada = data[8].ToNullableDouble();
            NumeroParcela = data[9].ToNullableDouble();
            ValorParcelaAprop = data[10].ToNullableDouble();
        }

        public string CodigoBem { get; set; } = null; // 02
        public DateTime? DataMovimento { get; set; } = default; // 03
        public TipoMovimentoCIAP? TipoMovimento { get; set; } = default; // 04
        public double? ICMS_OpPropria_Entrada { get; set; } = default; // 05
        public double? ICMS_ST_Entrada { get; set; } = default; // 06
        public double? ICMS_Frete_Entrada { get; set; } = default; // 07
        public double? ICMS_Difal_Entrada { get; set; } = default; // 08
        public double? NumeroParcela { get; set; } = default; // 09
        /// <summary>
        /// Valor da Parcela de ICMS passível de Apropriação
        /// (antes da aplicação da participação percentual do valor
        /// das saídas tributadas / exportação sobre as saídas totais)
        /// </summary>
        public double? ValorParcelaAprop { get; set; } = default; // 10

        // Navigation:
        public List<RegistroG126> RegistrosG126 { get; set; } = new List<RegistroG126>();
        public List<RegistroG130> RegistrosG130 { get; set; } = new List<RegistroG130>();

        private TipoMovimentoCIAP? TipoMov_StringToEnum(string value)
        {
            switch (value ?? "")
            {
                case "SI":
                    {
                        return TipoMovimentoCIAP.SI_SaldoInicial;
                    }

                case "IM":
                    {
                        return TipoMovimentoCIAP.IM_ImobIndividual;
                    }

                case "IA":
                    {
                        return TipoMovimentoCIAP.IA_ImobEmAndamento;
                    }

                case "CI":
                    {
                        return TipoMovimentoCIAP.CI_ConclusaoImobAndamento;
                    }

                case "MC":
                    {
                        return TipoMovimentoCIAP.MC_ImobAtivoCirculante;
                    }

                case "BA":
                    {
                        return TipoMovimentoCIAP.BA_BaixaBemFimApropriacao;
                    }

                case "AT":
                    {
                        return TipoMovimentoCIAP.AT_AlienacaoTransf;
                    }

                case "PE":
                    {
                        return TipoMovimentoCIAP.PE_PerecExtravioDeterior;
                    }

                case "OT":
                    {
                        return TipoMovimentoCIAP.OT_OutrasSaidas;
                    }

                default:
                    {
                        return default;
                    }
            }
        }

        private string TipoMov_EnumToString(TipoMovimentoCIAP? value)
        {
            if (value.HasValue == false)
                return string.Empty;
            switch ((int)value)
            {
                case 0:
                    {
                        return "SI";
                    }

                case 1:
                    {
                        return "IM";
                    }

                case 2:
                    {
                        return "IA";
                    }

                case 3:
                    {
                        return "CI";
                    }

                case 4:
                    {
                        return "MC";
                    }

                case 5:
                    {
                        return "BA";
                    }

                case 6:
                    {
                        return "AT";
                    }

                case 7:
                    {
                        return "PE";
                    }

                case 8:
                    {
                        return "OT";
                    }

                default:
                    {
                        return string.Empty;
                    }
            }
        }
    }
}