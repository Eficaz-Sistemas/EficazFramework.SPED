using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C130: ISSQN, IRRF E PREVIDÊNCIA SOCIAL
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC130 : Primitives.Registro
    {
        public RegistroC130() : base("C130")
        {
        }

        public RegistroC130(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C130|"); // 1
            writer.Append(string.Format("{0:0.##}", Vr_Serv_NaoIncidenciaICMS) + "|"); // 2
            writer.Append(string.Format("{0:0.##}", Vr_Base_ISSQN) + "|"); // 3
            writer.Append(string.Format("{0:0.##}", Vr_ISSQN) + "|"); // 4
            writer.Append(string.Format("{0:0.##}", Vr_BC_IRRF) + "|"); // 5
            writer.Append(string.Format("{0:0.##}", Vr_IRRF) + "|"); // 6
            writer.Append(string.Format("{0:0.##}", Vr_BC_Prev) + "|"); // 7
            writer.Append(string.Format("{0:0.##}", Vr_Previdencia) + "|"); // 8
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            Vr_Serv_NaoIncidenciaICMS = data[2].ToNullableDouble();
            Vr_Base_ISSQN = data[3].ToNullableDouble();
            Vr_ISSQN = data[4].ToNullableDouble();
            Vr_BC_IRRF = data[5].ToNullableDouble();
            Vr_IRRF = data[6].ToNullableDouble();
            Vr_BC_Prev = data[7].ToNullableDouble();
            Vr_Previdencia = data[8].ToNullableDouble();
        }

        public double? Vr_Serv_NaoIncidenciaICMS { get; set; } // 2
        public double? Vr_Base_ISSQN { get; set; } // 3
        public double? Vr_ISSQN { get; set; } // 4
        public double? Vr_BC_IRRF { get; set; } // 5
        public double? Vr_IRRF { get; set; } // 6
        public double? Vr_BC_Prev { get; set; } // 7
        public double? Vr_Previdencia { get; set; } // 8
    }
}