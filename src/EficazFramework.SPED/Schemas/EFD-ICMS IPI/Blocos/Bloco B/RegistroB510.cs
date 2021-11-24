using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Deduções do ISS
    /// </summary>
    /// <remarks></remarks>

    public class RegistroB510 : Primitives.Registro
    {
        public RegistroB510() : base("B510")
        {
        }

        public RegistroB510(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|B510|"); // 1
            writer.Append(((int)IndicadorHabilitacao).ToString() + "|"); // 2
            writer.Append(((int)IndicadorEscolaridade).ToString() + "|"); // 3
            writer.Append(((int)IndicadorParticipacaoSocietaria).ToString() + "|"); // 4
            writer.Append(NumeroCPFProfissional + "|"); // 5
            writer.Append(NomeProfissional + "|"); // 6
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            IndicadorHabilitacao = (IndicadorHabilitacao)data[2].ToEnum<IndicadorHabilitacao>(IndicadorHabilitacao.ProfissionalHabilitado);
            IndicadorEscolaridade = (IndicadorEscolaridade)data[3].ToEnum<IndicadorEscolaridade>(IndicadorEscolaridade.NivelSuperior);
            IndicadorParticipacaoSocietaria = (IndicadorParticipacaoSocietaria)data[4].ToEnum<IndicadorParticipacaoSocietaria>(IndicadorParticipacaoSocietaria.Socio);
            NumeroCPFProfissional = data[5].ToString();
            NomeProfissional = data[6].ToString();
        }

        public IndicadorHabilitacao IndicadorHabilitacao { get; set; } = IndicadorHabilitacao.ProfissionalHabilitado; // 2
        public IndicadorEscolaridade IndicadorEscolaridade { get; set; } = IndicadorEscolaridade.NivelSuperior; // 3
        public IndicadorParticipacaoSocietaria IndicadorParticipacaoSocietaria { get; set; } = IndicadorParticipacaoSocietaria.Socio; // 4
        public string NumeroCPFProfissional { get; set; } = null; // 5
        public string NomeProfissional { get; set; } = null; // 6
    }
}