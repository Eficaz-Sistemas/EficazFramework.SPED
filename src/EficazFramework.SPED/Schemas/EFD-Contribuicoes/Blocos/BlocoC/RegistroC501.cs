using System.Collections.Generic;
using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento da Operação
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC501 : Primitives.Registro
    {
        public RegistroC501() : base("C501")
        {
        }

        public RegistroC501(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CstPis { get; set; } = null;
        public double? VrTotalItens { get; set; }
        public string NatBaseCalculo { get; set; } = null;
        public double VrBaseCalculoPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? VrPis { get; set; }
        public string CodContaContabil { get; set; } = null;
        public List<RegistroC501> RegistrosC501 { get; set; } = new List<RegistroC501>();
        public List<RegistroC505> RegistrosC505 { get; set; } = new List<RegistroC505>();
        public List<RegistroC509> RegistrosC509 { get; set; } = new List<RegistroC509>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C501|");
            if (Conversions.ToDouble(CstPis) != (double)NFe.CST_PIS.NotValid)
                writer.Append(string.Format("{0:#00}", Conversions.ToInteger(CstPis)) + "|");
            else
                writer.Append("|");
            writer.Append(string.Format("{0:0.##}", VrTotalItens) + "|");
            writer.Append(string.Format("{0:00}", Conversions.ToInteger(NatBaseCalculo)) + "|");
            writer.Append(string.Format("{0:0.##}", VrBaseCalculoPis) + "|");
            writer.Append(string.Format("{0:0.####}", AliquotaPis) + "|");
            writer.Append(string.Format("{0:0.##}", VrPis) + "|");
            writer.Append(CodContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CstPis = data[2];
            VrTotalItens = data[3].ToNullableDouble();
            NatBaseCalculo = data[4];
            VrBaseCalculoPis = (double)data[5].ToNullableDouble();
            AliquotaPis = data[6].ToNullableDouble();
            VrPis = data[7].ToNullableDouble();
            CodContaContabil = data[8];
        }
    }
}