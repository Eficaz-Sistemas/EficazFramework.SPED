using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Campos Adicionais
    /// </summary>
    /// <remarks></remarks>

    public class RegistroI020 : Primitives.Registro
    {
        public RegistroI020() : base("I020")
        {
        }

        public RegistroI020(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoRegistroRecepCampoAdicional { get; set; } = null;
        public short? NumSeqCampoAdicional { get; set; }
        public string NomeCampoAdicional { get; set; } = null;
        public string DescricaoCampoAdicional { get; set; } = null;
        public string IndicacaoTipoData { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|I020|");
            writer.Append(CodigoRegistroRecepCampoAdicional + "|");
            writer.Append(NumSeqCampoAdicional + "|");
            writer.Append(NomeCampoAdicional + "|");
            writer.Append(DescricaoCampoAdicional + "|");
            writer.Append(IndicacaoTipoData + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoRegistroRecepCampoAdicional = data[2];
            NumSeqCampoAdicional = data[3].ToNullableShort();
            NomeCampoAdicional = data[4];
            DescricaoCampoAdicional = data[5];
            IndicacaoTipoData = data[6];
        }
    }
}