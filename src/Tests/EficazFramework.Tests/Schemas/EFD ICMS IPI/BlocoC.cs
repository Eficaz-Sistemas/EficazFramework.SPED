using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

public class BlocoC : Tests.BaseTest
{
    [Test]
    public void RegistroC500_Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC500();
        reg.Codigo.Should().Be("C500");
    }

    
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555||||||", "015")]
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555|||2|||||||122021|||", "016", true)]
    public void RegistroC500_Construtor(string linha, string versao = "016", bool indicadorContribIcms = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC500(linha, versao);
        RegistroC500_InternalRead(reg, versao, indicadorContribIcms);
    }

    
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|", "002")]
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|", "003")]
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555||||||", "014")]
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555||||||", "015")]
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555||||||||||122021|||", "016")]
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555|||2|||||||122021|||", "016", true)]
    public void RegistroC500_Escrita(string result, string versao = "016", bool indicadorContribIcms = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC500("", versao)
        {
            Operacao = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorOperacao.Entrada,
            Emissao = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorEmitente.Terceiros,
            CodigoParticipante = "123",
            EspecieDocumento = "06",
            SituacaoDocumento = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.SituacaoDocumento.Regular,
            Serie = "U1",
            CodigoConsumo = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.CodigoConsumoEnEletricaOuGas.Comercial,
            Numero = 12345678,
            DataEmissao = new System.DateTime(2021,6,18),
            DataEntradaSaida = new System.DateTime(2021, 6, 18),
            ValorTotalDocumento = 539.8d,
            ValorFornecidoOuConsumido = 530d,
            ValorDespesasAcessorias = 9.8d,
            ValorBaseCalculoICMS = 539.8d,
            ValorICMS = 100d,
            ValorPIS = 6d,
            ValorCofins = 42d,
            TipoLigacao = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.TipoLigacaoEnEletrica.Trifasico,
            CodigoGrupoTensao = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.GrupoTensao.A1,
            ChaveDocE = "5555",
            CompetenciaDocumentoReferenciado = new System.DateTime(2021, 12, 25)
        };
        
        if (indicadorContribIcms)
            reg.DestinatarioIndicador = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorDestinatario.ContribIsentoICMS;
        
        reg.ToString().Should().Be(result);
    }


    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|", "003")]
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555||||||", "014")]
    [TestCase("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555|||2|||||||122021|||", "016", true)]
    public void RegistroC500_Leitura(string linha, string versao = "016", bool indicadorContribIcms = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC500("", versao);
        reg.CodigoParticipante.Should().Be(null);
        reg.ValorTotalDocumento.HasValue.Should().Be(false);

        reg.LeParametros(linha.Split('|'));
        RegistroC500_InternalRead(reg, versao, indicadorContribIcms);
    }

    
    private void RegistroC500_InternalRead(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC500 reg, string versao = "016", bool indicadorContribIcms = false)
    {
        reg.Codigo.Should().Be("C500");
        reg.Versao.Should().Be(versao);
        reg.Operacao.Should().Be(IndicadorOperacao.Entrada);
        reg.Emissao.Should().Be(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorEmitente.Terceiros);
        reg.CodigoParticipante.Should().Be("123");
        reg.EspecieDocumento.Should().Be("06");
        reg.SituacaoDocumento.Should().Be(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.SituacaoDocumento.Regular);
        reg.Numero.Should().Be(12345678);
        reg.Serie.Should().Be("U1");
        reg.DataEmissao.Should().Be(new System.DateTime(2021, 6, 18));
        reg.ValorTotalDocumento.Should().Be(539.8d);

        if (int.Parse(versao) >= 14)
            reg.ChaveDocE.Should().Be("5555");
        else
            reg.ChaveDocE.Should().BeNull();
        

        if (int.Parse(versao) >= 16)
        {
            reg.CompetenciaDocumentoReferenciado.Value.Month.Should().Be(12);
            reg.CompetenciaDocumentoReferenciado.Value.Year.Should().Be(2021);
        }


        if (indicadorContribIcms)
            reg.DestinatarioIndicador.Should().Be(EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorDestinatario.ContribIsentoICMS);

    }
}
