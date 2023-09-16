namespace EficazFramework.SPED.Services.EFD_Reinf;

public class R4020Test : MovEfdReinfTest<Schemas.EFD_Reinf.R4020>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoRendimentosIsentos(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 0;
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.retornoEventoRetInfo.evtRet.infoRecEv.tpEv.Should().Be("4020");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("34785515000166");
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoRendimentosTributados(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 2;
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.retornoEventoRetInfo.evtRet.infoRecEv.tpEv.Should().Be("4020");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("34785515000166");

        var irrf = retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single(ev => ev.CodigoReceita == "170806");
        var csll = retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single(ev => ev.CodigoReceita == "598707");
        var cofins = retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single(ev => ev.CodigoReceita =="596007");
        var pis = retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single(ev => ev.CodigoReceita == "597907");

        irrf.Should().NotBeNull();
        csll.Should().NotBeNull();  
        cofins.Should().NotBeNull();
        pis.Should().NotBeNull();   

        irrf.natRend.Should().Be("15010");
        csll.natRend.Should().Be("15010");
        cofins.natRend.Should().Be("15010");
        pis.natRend.Should().Be("15010");

        irrf.ValorBaseCR.Should().Be("152725,25");
        csll.ValorBaseCR.Should().Be("152725,25");
        cofins.ValorBaseCR.Should().Be("152725,25");
        pis.ValorBaseCR.Should().Be("152725,25");

        irrf.TotalApuracaoTributo.ValorCRInformado.Should().Be("2290,88");
        csll.TotalApuracaoTributo.ValorCRInformado.Should().Be("15272,53");
        cofins.TotalApuracaoTributo.ValorCRInformado.Should().Be("4581,76");
        pis.TotalApuracaoTributo.ValorCRInformado.Should().Be("992,71");
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoRendimentosTributadosAgregados(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 3;
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.retornoEventoRetInfo.evtRet.infoRecEv.tpEv.Should().Be("4020");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("34785515000166");

        var irrf = retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single(ev => ev.CodigoReceita == "170806");
        var agreg = retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single(ev => ev.CodigoReceita == "595207");

        irrf.Should().NotBeNull();
        agreg.Should().NotBeNull();

        irrf.natRend.Should().Be("15010");
        agreg.natRend.Should().Be("15010");

        irrf.ValorBaseCR.Should().Be("152725,25");
        agreg.ValorBaseCR.Should().Be("152725,25");

        irrf.TotalApuracaoTributo.ValorCRInformado.Should().Be("2290,88");
        agreg.TotalApuracaoTributo.ValorCRInformado.Should().Be("7101,72");
    }

    public override void PreencheCampos(Schemas.EFD_Reinf.R4020 evento, int index = 0)
    {
        switch (_testNumber)
        {
            case 0:
                Schemas.EFD_Reinf.R4020Test.PreencheCamposRendimentoisento(evento, CnpjCpf);
                break;
            //case 1:
            //    Schemas.R4020Test.PreencheCamposRendimentoisento(evento);
            //    evento.evtRetPJ.ideEstab.ideBenef.isenImun = TipoIsencaoPJ.InstEduOrAssistSocial;
            //    break;
            case 2:
                Schemas.EFD_Reinf.R4020Test.PreencheCamposRendimentoTributado(evento, CnpjCpf);
                break;
            case 3:
                Schemas.EFD_Reinf.R4020Test.PreencheCamposRendimentoTributadoAgregado(evento, CnpjCpf);
                break;
        }
        evento.evtRetPJ.ideEstab.ideBenef.nmBenef = null;
        evento.evtRetPJ.ideEstab.ideBenef.isenImun = null;
    }
}