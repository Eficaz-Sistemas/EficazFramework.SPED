using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Informações FCP - Exceto na aplicabilidade da EC 87/15 (C101)
    /// Provenientes de Documento Fiscal
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC191 : Primitives.Registro
    {
        public RegistroC191() : base("C191")
        {
        }

        public RegistroC191(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C191|"); // 1
            writer.Append(string.Format("{0:0.##}", ValorFCP) + "|"); // 02
            writer.Append(string.Format("{0:0.##}", ValorFCP_ST) + "|"); // 03
            writer.Append(string.Format("{0:0.##}", ValorFCP_Ret) + "|"); // 04
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            ValorFCP_ST = data[2].ToNullableDouble();
            ValorFCP_ST = data[3].ToNullableDouble();
            ValorFCP_Ret = data[4].ToNullableDouble();
        }

        public double? ValorFCP { get; set; } = default; // 02
        public double? ValorFCP_ST { get; set; } = default; // 03
        public double? ValorFCP_Ret { get; set; } = default; // 04
    }
}