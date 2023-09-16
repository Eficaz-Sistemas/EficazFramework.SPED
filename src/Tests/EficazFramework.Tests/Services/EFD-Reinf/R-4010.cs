namespace EficazFramework.SPED.Services.EFD_Reinf;

public class R4010Test : MovEfdReinfTest<Schemas.EFD_Reinf.R4010>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoRendimentosIsentos(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 0;
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.retornoEventoRetInfo.evtRet.infoRecEv.tpEv.Should().Be("4010");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("47363361886");
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoRendimentosTributados(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 1;
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.retornoEventoRetInfo.evtRet.infoRecEv.tpEv.Should().Be("4010");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("47363361886");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().CodigoReceita.Should().Be("058807");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().natRend.Should().Be("10002");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().ValorBaseCR.Should().Be("750,00");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().TotalApuracaoTributo.ValorCRInformado.Should().Be("112,50");
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoRendimentosTributadosVlrIncorreto(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 2;
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.retornoEventoRetInfo.evtRet.infoRecEv.tpEv.Should().Be("4010");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("47363361886");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().CodigoReceita.Should().Be("058807");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().natRend.Should().Be("10002");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().ValorBaseCR.Should().Be("750,00");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().TotalApuracaoTributo.ValorCRInformado.Should().Be("200,10");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().TotalApuracaoTributo.ValorCRCalculado.Should().NotBe("200,10");
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoRendimentosTributadosComDependente(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 3;
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.retornoEventoRetInfo.evtRet.infoRecEv.tpEv.Should().Be("4010");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("47363361886");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().CodigoReceita.Should().Be("058807");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().natRend.Should().Be("10002");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().ValorBaseCR.Should().Be("716,25");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single().TotalApuracaoTributo.ValorCRInformado.Should().Be("112,50");
    }

    public override void PreencheCampos(Schemas.EFD_Reinf.R4010 evento, int index = 0)
    {
        switch (_testNumber)
        {
            case 0:
                Schemas.EFD_Reinf.R4010Test.PreencheCamposRendimentoisento(evento, CnpjCpf);
                evento.evtRetPF.ideEstab.ideBenef.idePgto.Single().infoPgto.Single().rendIsento = null;
                break;
            case 1:
                Schemas.EFD_Reinf.R4010Test.PreencheCamposRendimentoTributado(evento, CnpjCpf);
                break;
            case 2:
                Schemas.EFD_Reinf.R4010Test.PreencheCamposRendimentoTributado(evento, CnpjCpf);
                evento.evtRetPF.ideEstab.ideBenef.idePgto.Single().infoPgto.Single().vlrIR = 200.1.ToString("f2");
                break;
            case 3:
                Schemas.EFD_Reinf.R4010Test.PreencheCamposRendimentoTributadoComDependente(evento, CnpjCpf);
                break;
        }
        evento.evtRetPF.ideEstab.ideBenef.nmBenef = null;
    }
}