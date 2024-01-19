
namespace EficazFramework.SPED.Schemas.ECF;

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

    // Versao 00010 e acima:

    public bool SuspensaoOleoBunker { get; set; } = false;
    public bool REPORTO { get; set; } = false;
    public bool RetII { get; set; } = false;
    public bool RETPMCMV { get; set; } = false;
    public bool RetEEI { get; set; } = false;
    public bool IndEBAS { get; set; } = false;
    public bool REPETROIND { get; set; } = false;
    public bool REPETRONAC { get; set; } = false;
    public bool REPETROPERM { get; set; } = false;
    public bool REPETROTEMP { get; set; } = false;


    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0021|"); // 1

        if (int.Parse(Versao) >= 10)
        {
            writer.Append(REPES ? "S|" : "N|"); // 2
            writer.Append(RECAP ? "S|" : "N|"); // 3
            writer.Append(PADIS ? "S|" : "N|"); // 4
            writer.Append(REIDI ? "S|" : "N|"); // 5
            writer.Append(RECINE ? "S|" : "N|"); // 6
            writer.Append(RETID ? "S|" : "N|"); // 7
            writer.Append(SuspensaoOleoBunker ? "S|" : "N|"); // 8
            writer.Append(REPORTO ? "S|" : "N|"); // 9
            writer.Append(RetII ? "S|" : "N|"); // 10
            writer.Append(RETPMCMV ? "S|" : "N|"); // 11
            writer.Append(RetEEI ? "S|" : "N|"); // 12
            writer.Append(IndEBAS ? "S|" : "N|"); // 13
            writer.Append(REPETROIND ? "S|" : "N|"); // 14
            writer.Append(REPETRONAC ? "S|" : "N|"); // 15
            writer.Append(REPETROPERM ? "S|" : "N|"); // 16
            writer.Append(REPETROTEMP ? "S|" : "N|"); // 17
        }
        else
        {
            writer.Append(REPES ? "S|" : "N|"); // 2
            writer.Append(RECAP ? "S|" : "N|"); // 3
            writer.Append(PADIS ? "S|" : "N|"); // 4
            writer.Append(PATVD ? "S|" : "N|"); // 5
            writer.Append(REIDI ? "S|" : "N|"); // 6
            writer.Append(REPENEC ? "S|" : "N|"); // 7
            writer.Append(REICOMP ? "S|" : "N|"); // 8
            writer.Append(RETAERO ? "S|" : "N|"); // 9
            writer.Append(RECINE ? "S|" : "N|"); // 10
            writer.Append(ResiduosSolidos ? "S|" : "N|"); // 11
            writer.Append(RECOPA ? "S|" : "N|"); // 12
            writer.Append(CopaDoMundo ? "S|" : "N|"); // 13
            writer.Append(RETID ? "S|" : "N|"); // 14
            writer.Append(REPNBL_REDES ? "S|" : "N|"); // 15
            writer.Append(REIF ? "S|" : "N|"); // 16
            writer.Append(Olimpiadas ? "S|" : "N|"); // 17
        }

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
