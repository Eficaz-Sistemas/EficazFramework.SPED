
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Parâmetros de Identificação dos Tipos de Programa ¬¬
    /// </summary>
    /// <remarks></remarks>
    public class Registro0021 : Primitives.Registro
    {
        public Registro0021() : base("0021")
        {
        }

        public Registro0021(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public bool REPES { get; set; } = false;
        public bool RECAP { get; set; } = false;
        public bool PADIS { get; set; } = false;
        public bool PATVD { get; set; } = false;
        public bool REIDI { get; set; } = false;
        public bool REPENEC { get; set; } = false;
        public bool REICOMP { get; set; } = false;
        public bool RETAERO { get; set; } = false;
        public bool RECINE { get; set; } = false;
        public bool ResiduosSolidos { get; set; } = false;
        public bool RECOPA { get; set; } = false;
        public bool CopaDoMundo { get; set; } = false;
        public bool RETID { get; set; } = false;
        public bool REPNBL_REDES { get; set; } = false;
        public bool REIF { get; set; } = false;
        public bool Olimpiadas { get; set; } = false;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0021|"); // 1
            if (REPES)
                writer.Append("S|");
            else
                writer.Append("N|"); // 2
            if (RECAP)
                writer.Append("S|");
            else
                writer.Append("N|"); // 3
            if (PADIS)
                writer.Append("S|");
            else
                writer.Append("N|"); // 4
            if (PATVD)
                writer.Append("S|");
            else
                writer.Append("N|"); // 5
            if (REIDI)
                writer.Append("S|");
            else
                writer.Append("N|"); // 6
            if (REPENEC)
                writer.Append("S|");
            else
                writer.Append("N|"); // 7
            if (REICOMP)
                writer.Append("S|");
            else
                writer.Append("N|"); // 8
            if (RETAERO)
                writer.Append("S|");
            else
                writer.Append("N|"); // 9
            if (RECINE)
                writer.Append("S|");
            else
                writer.Append("N|"); // 10
            if (ResiduosSolidos)
                writer.Append("S|");
            else
                writer.Append("N|"); // 11
            if (RECOPA)
                writer.Append("S|");
            else
                writer.Append("N|"); // 12
            if (CopaDoMundo)
                writer.Append("S|");
            else
                writer.Append("N|"); // 13
            if (RETID)
                writer.Append("S|");
            else
                writer.Append("N|"); // 14
            if (REPNBL_REDES)
                writer.Append("S|");
            else
                writer.Append("N|"); // 15
            if (REIF)
                writer.Append("S|");
            else
                writer.Append("N|"); // 16
            if (Olimpiadas)
                writer.Append("S|");
            else
                writer.Append("N|"); // 17
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            // Me.DataInicial = data(3).ToDate
            // Me.DataFinal = data(4).ToDate
            // Me.NomeEmpresarialPJ = data(5)
            // Me.CNPJ = data(6)
            // Me.UF = data(7)
            // Me.IEPj = data(8)
            // Me.CodMunicipio = data(9)
            // Me.InscMunicipal = data(10)
            // Me.IndicadorSitEspecial = data(11)
            // Me.IndicadorSitInicioPeriodo = data(12)
            // Me.IndicadorExistNire = data(13).ToEnum(Of IndicadorExistNire)(IndicadorExistNire.EmpresaPossuiRegistroJunta)
            // Me.IndicadorFinalidadeEscrit = data(14).ToEnum(Of IndicadorFinalidadeEscrit)(IndicadorFinalidadeEscrit.Original)
            // Me.CodigoHash = data(15)
            // Me.IndicadorGrandePorte = data(16).ToEnum(Of IndicadorGrandePorte)(IndicadorGrandePorte.EmpresaNaoSujeitaAuditoria)
            // Me.IndicadorTipoECD = data(17).ToEnum(Of IndicadorTipoECD)(IndicadorTipoECD.ECDempresaNaoParticipanteSCP)
            // Me.IdentificacaoSCP = data(18)
            // If data(19) = "S" Then
            // Me.IdentificacaoMoedaFuncional = True
            // Else
            // Me.IdentificacaoMoedaFuncional = False
            // End If
            // If data(20) = "S" Then
            // Me.EscritContConsolidades = True
            // Else
            // Me.EscritContConsolidades = False
            // End If
        }
    }
}