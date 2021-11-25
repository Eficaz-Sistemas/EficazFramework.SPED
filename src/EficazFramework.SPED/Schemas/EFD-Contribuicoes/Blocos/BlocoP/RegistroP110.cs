using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento da escrituração - detalhamento da apuração da contribuição
    /// </summary>
    /// <remarks></remarks>

    public class RegistroP110 : Primitives.Registro
    {
        public RegistroP110() : base("P110")
        {
        }

        public RegistroP110(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public short? NumeroCampoP100 { get; set; }
        public string CodigoDetalhamento { get; set; } = null;
        public double? VrDetalhado { get; set; }
        public string InfoComplementarDet { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|P110|");
            writer.Append(NumeroCampoP100 + "|");
            writer.Append(CodigoDetalhamento + "|");
            writer.Append(VrDetalhado + "|");
            writer.Append(InfoComplementarDet + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroCampoP100 = data[2].ToNullableShort();
            CodigoDetalhamento = data[3];
            VrDetalhado = data[4].ToNullableDouble();
            InfoComplementarDet = data[5];
        }
    }
}