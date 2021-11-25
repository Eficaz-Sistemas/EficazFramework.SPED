
namespace EficazFramework.SPED.Schemas.CNAB240
{
    public enum TipoDePagamento
    {
        Dividendos = 10,
        Debendures = 15,
        Fornecedores = 20,
        Tributos = 22,
        Salarios = 30,
        FundosInvestimentos = 40,
        SinistroSeguros = 50,
        DespViajanteEmTransito = 60,
        RepresentantesAutorizados = 80,
        Beneficios = 90,
        Diversos = 98
    }

    public enum FormaDePagamento
    {
        CreditoCCMesmoBanco = 1,
        ChequePagtoAdmin = 2,
        DocC = 3,
        CreditoPoupancaMesmoBanco = 5,
        CreditoCCMesmaTitularidade = 6,
        DocD = 7,
        OrdemPagamento = 10,
        OrdemPagtoAcertoSomenteRetorno = 11,
        PagtoConcessionarias = 13,
        DarfNormal = 16,
        GPS = 17,
        DarfSimples = 18,
        IPTU_ISS_OutrosMun = 19,
        DARJ = 21,
        GARE_SP = 22,
        IPVA = 25,
        DPVAT = 27,
        TitulosEmCobranca = 30,
        TitulosEmeCobrancaOutrosBancos = 31,
        NotaFiscal_LiqEletron = 32,
        FGTS = 35,
        TED_OutroTitular = 41,
        TED_MesmoTitular = 43,
        CartaoSalario = 60,
        GnreTributosCodBarras = 91
    }

    public enum FinalidadeLote
    {
        FolhaMensal = 1,
        FolhaQuinzenal = 2,
        FolhaComplementar = 3,
        DecimoTerceiroSalario = 4,
        ParticipacaodeResultados = 5,
        InformedeRendimentos = 6,
        Ferias = 7,
        Rescisao = 8,
        RescisaoComplementar = 9,
        Outros = 10,
        DebitoContaInvestimento = 85,
        OutrosNota6 = 0
    }
}