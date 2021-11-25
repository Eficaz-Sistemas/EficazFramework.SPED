using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// REGISTRO C179: INFORMAÇÕES COMPLEMENTARES ST (CÓDIGO 01)
    /// </summary>
    /// <remarks></remarks>
    public class RegistroC179 : Primitives.Registro
    {
        public RegistroC179() : base("C179")
        {
        }

        public RegistroC179(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C179|"); // 1
            writer.Append(VrBCSTOperacoesInterest + "|"); // 2
            writer.Append(VrICMSSTOperacoesInterest + "|"); // 3
            writer.Append(VrICMSSTComplementarUFDestino + "|"); // 4
            writer.Append(VrBCRetRemessaST + "|"); // 5
            writer.Append(VrParcelaImpostoRetidoST + "|"); // 6
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrBCSTOperacoesInterest = data[2].ToNullableDouble();
            VrICMSSTOperacoesInterest = data[3].ToNullableDouble();
            VrICMSSTComplementarUFDestino = data[4].ToNullableDouble();
            VrBCRetRemessaST = data[5].ToNullableDouble();
            VrParcelaImpostoRetidoST = data[6].ToNullableDouble();
        }

        public double? VrBCSTOperacoesInterest { get; set; } = default; // 2
        public double? VrICMSSTOperacoesInterest { get; set; } = default; // 3
        public double? VrICMSSTComplementarUFDestino { get; set; } = default; // 4
        public double? VrBCRetRemessaST { get; set; } = default; // 5
        public double? VrParcelaImpostoRetidoST { get; set; } = default; // 6
    }
}