using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes.BlocoF;

public class RegistroF100 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF100();
        reg.Codigo.Should().Be("F100");
    }

    
    [TestCase("|F100|0|ID278831IE1||31082023|37229,13|50|37229,13|1,65|614,28|50|37229,13|7,6|2829,41|03|0|50128||Despesa sem NF Contabilidade|", "006")]
    public void Construtor(string linha, string versao = "006", bool omitirNatBC = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF100(linha, versao);
        InternalRead(reg, versao, omitirNatBC);
    }

    
    [TestCase("|F100|0|ID278831IE1||31082023|37229,13|50|37229,13|1,65|614,28|50|37229,13|7,6|2829,41|03|0|50128||Despesa sem NF Contabilidade|", "006")]
    [TestCase("|F100|1|ID278831IE1||31082023|37229,13|50|37229,13|1,65|614,28|50|37229,13|7,6|2829,41||0|50128||Despesa sem NF Contabilidade|", "006", true)]
    public void Escrita(string result, string versao = "006", bool omitirNatBC = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF100("", versao)
        {
            IndicadorTipoOperacaoF = IndicadorTipoOperacaoF.OperacaoRepresentativaAquisCustosDespEncargRecIncPisCofins,
            CodigoParticipante = "ID278831IE1",
            DataOperacao = new System.DateTime(2023, 8, 31),
            ValorOperacaoItem = 37229.13d,
            NatBcCredito = NaturezaBaseCalculo.AquisServicosInsumo,
            IndicadorOrigemCredito = IndicadorOrigemCredito.OperacaoMercadoInterno,
            CSTPis = "50",
            VrBcPis = 37229.13d,
            AliqPis = 1.65d,
            VrPis = 614.28,
            CSTCofins = "50",
            VrBcCofins = 37229.13d,
            AliqCofins = 7.6d,
            VrCofins = 2829.41,
            CodigoContaContabil = "50128",
            DescricaoDocOperacao = "Despesa sem NF Contabilidade"
        };

        if (omitirNatBC)
            reg.IndicadorTipoOperacaoF = IndicadorTipoOperacaoF.OperacaoRepresentativaRecAufSujPgtoContPisCofins;
        
        reg.ToString().Should().Be(result);
    }


    [TestCase("|F100|0|ID278831IE1||31082023|37229,13|50|37229,13|1,65|614,28|50|37229,13|7,6|2829,41|03|0|50128||Despesa sem NF Contabilidade|", "006")]
    [TestCase("|F100|1|ID278831IE1||31082023|37229,13|50|37229,13|1,65|614,28|50|37229,13|7,6|2829,41||0|50128||Despesa sem NF Contabilidade|", "006", true)]
    public void Leitura(string linha, string versao = "006", bool omitirNatBC = false)
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF100("", versao);
        reg.VrPis.Should().Be(null);
        reg.NatBcCredito.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao, omitirNatBC);
    }

    
    private void InternalRead(EficazFramework.SPED.Schemas.EFD_Contribuicoes.RegistroF100 reg, string versao = "006", bool omitirNatBC = false)
    {
        reg.CodigoParticipante.Should().Be("ID278831IE1");
        reg.DataOperacao.Should().BeCloseTo(new System.DateTime(2023, 8, 31), TimeSpan.FromHours(23));
        reg.ValorOperacaoItem.Should().Be(37229.13d);
        reg.IndicadorOrigemCredito.Should().Be(IndicadorOrigemCredito.OperacaoMercadoInterno);
        reg.CSTPis.Should().Be("50");
        reg.VrBcPis.Should().Be(37229.13d);
        reg.AliqPis.Should().Be(1.65d);
        reg.VrPis.Should().Be(614.28d);
        reg.CSTCofins.Should().Be("50");
        reg.VrBcCofins.Should().Be(37229.13d);
        reg.AliqCofins.Should().Be(7.6d);
        reg.VrCofins.Should().Be(2829.41d);
        reg.CodigoContaContabil.Should().Be("50128");
        reg.DescricaoDocOperacao.Should().Be("Despesa sem NF Contabilidade");
        if (omitirNatBC)
        {
            reg.NatBcCredito.Should().Be(NaturezaBaseCalculo.OutOpDireitoCredito);
            reg.IndicadorTipoOperacaoF.Should().Be(IndicadorTipoOperacaoF.OperacaoRepresentativaRecAufSujPgtoContPisCofins);
        }
        else
        {
            reg.NatBcCredito.Should().Be(NaturezaBaseCalculo.AquisServicosInsumo);
            reg.IndicadorTipoOperacaoF.Should().Be(IndicadorTipoOperacaoF.OperacaoRepresentativaAquisCustosDespEncargRecIncPisCofins);
        }

    }
}
