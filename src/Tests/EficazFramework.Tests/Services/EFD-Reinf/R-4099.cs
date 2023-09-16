using EficazFramework.SPED.Schemas.EFD_Reinf;

namespace EficazFramework.SPED.Services.EFD_Reinf;

public class R4099Test : MovEfdReinfTest<Schemas.EFD_Reinf.R4099>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaFechamentoSemMovimento(Schemas.EFD_Reinf.Versao versao)
    {
        CodigosResultadoEsperado = new[] {"1", "3" };
        _testNumber = 0;
        var result = await TestaEvento(versao);
        result.retornoLoteEventosAssincrono.retornoEventos.evento.ToList().ForEach(evt =>
        {
            //? O evento R-4099 só é aceito se houver algum evento da série R-4000 enviado para o período de apuração indicado em {perApur}. Recepção não permitida.
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.ideRecRetorno.ideStatus.regOcorrs.Single().codResp.Should().Be("MS1484");
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.tpEv.Should().Be("4099");
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.dhProcess.Should().NotBe(DateTime.MinValue);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.nrProtLote.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.nrRecArqBase.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.hash.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.fechRet.Should().Be(IndicadorFechamentoReabertura.Fechamento);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoTotalCR.Should().BeNull();
        });
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaFechamentoComMovimentoIsento(Schemas.EFD_Reinf.Versao versao)
    {
        CodigosResultadoEsperado = new[] { "0", "2" };
        _testNumber = 0;

        //? Envio de R-4010
        var r4010Test = new R4010Test()
        {
            ReciclaDadosCadastrais = false,
            CnpjCpf = CnpjCpf
        };
        r4010Test.Contribuinte.nrInsc = CnpjCpf;
        await r4010Test.EnviaMovimentoRendimentosIsentos(versao);

        //? Envio de R-4020
        var r4020Test = new R4020Test()
        {
            GeraDadosCadastrais = false,
            ReciclaDadosCadastrais = false,
            CnpjCpf = CnpjCpf
        };
        r4020Test.Contribuinte.nrInsc = CnpjCpf;
        await r4020Test.EnviaMovimentoRendimentosIsentos(versao);

        ////? Envio de R-4080
        //var r2055Test = new R2055Test()
        //{
        //    GeraDadosCadastrais = false,
        //    ReciclaDadosCadastrais = false
        //};
        //await r2055Test.TestaEvento(versao);

        //? Encerra com R-4099
        GeraDadosCadastrais = false;
        var result = await TestaEvento(versao);
        result.retornoLoteEventosAssincrono.retornoEventos.evento.ToList().ForEach(evt =>
        {
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.tpEv.Should().Be("4099");
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.dhProcess.Should().NotBe(DateTime.MinValue);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.nrProtLote.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.nrRecArqBase.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.hash.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.fechRet.Should().Be(IndicadorFechamentoReabertura.Fechamento);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoTotalCR.Should().BeNull();

            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.indExistInfo.Should().Be(2);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoMensal.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoQuinzenal.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoSemanal.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoDecendial.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoDiaria.Should().BeNull();
        });
        GeraDadosCadastrais = true;
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaFechamentoComMovimentoTributavel(Versao versao)
    {
        CodigosResultadoEsperado = new[] { "0", "2" };
        _testNumber = 0;

        //? Envio de R-4010
        var r4010Test = new R4010Test() 
        {
            ReciclaDadosCadastrais = false,
            CnpjCpf = CnpjCpf
        };
        r4010Test.Contribuinte.nrInsc = CnpjCpf;
        await r4010Test.EnviaMovimentoRendimentosTributados(versao);

        //? Envio de R-4020
        var r4020Test = new R4020Test()
        {
            GeraDadosCadastrais = false,
            ReciclaDadosCadastrais = false,
            CnpjCpf = CnpjCpf
        };
        r4020Test.Contribuinte.nrInsc = CnpjCpf;
        await r4020Test.EnviaMovimentoRendimentosTributados(versao);

        ////? Envio de R-4080
        //var r2055Test = new R2055Test()
        //{
        //    GeraDadosCadastrais = false,
        //    ReciclaDadosCadastrais = false
        //};
        //await r2055Test.TestaEvento(versao);

        //? Encerra com R-4099
        GeraDadosCadastrais = false;
        var result = await TestaEvento(versao);
        result.retornoLoteEventosAssincrono.retornoEventos.evento.ToList().ForEach(evt =>
        {
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.tpEv.Should().Be("4099");
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.dhProcess.Should().NotBe(DateTime.MinValue);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.nrProtLote.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.nrRecArqBase.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.hash.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.fechRet.Should().Be(IndicadorFechamentoReabertura.Fechamento);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoTotalCR.Should().NotBeNull();

            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.indExistInfo.Should().Be(1);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoMensal.Should().HaveCountGreaterThan(0);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoQuinzenal.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoSemanal.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoDecendial.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoDiaria.Should().BeNull();

            var totalNatRec = evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.TotalApuracaoMensal;

            var irrfPF = totalNatRec.Single(cr => cr.CodigoReceita == "058807");
            irrfPF.Should().NotBeNull();
            irrfPF.natRend.Should().Be("10002");
            irrfPF.ValorCrDctf.Should().Be("112,50");
            irrfPF.ValorCRInformado.Should().Be("112,50");

            var irrfPJ = totalNatRec.Single(ev => ev.CodigoReceita == "170806");
            irrfPJ.Should().NotBeNull();
            irrfPJ.natRend.Should().Be("15010");
            irrfPJ.ValorCrDctf.Should().Be("2290,88");
            irrfPJ.ValorCRInformado.Should().Be("2290,88");

            var csll = totalNatRec.Single(ev => ev.CodigoReceita == "598707");
            csll.Should().NotBeNull();
            csll.natRend.Should().Be("15010");
            csll.ValorCrDctf.Should().Be("15272,53");
            csll.ValorCRInformado.Should().Be("15272,53");

            var cofins = totalNatRec.Single(ev => ev.CodigoReceita == "596007");
            cofins.Should().NotBeNull();
            cofins.natRend.Should().Be("15010");
            cofins.ValorCrDctf.Should().Be("4581,76");
            cofins.ValorCRInformado.Should().Be("4581,76");

            var pis = totalNatRec.Single(ev => ev.CodigoReceita == "597907");
            pis.Should().NotBeNull();
            pis.natRend.Should().Be("15010");
            pis.ValorCrDctf.Should().Be("992,71");
            pis.ValorCRInformado.Should().Be("992,71");


            var total = evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoTotalCR.TotalApuracaoMensal;

            var irrfPFTotal = total.Single(cr => cr.CodigoReceita == "058807");
            irrfPFTotal.Should().NotBeNull();
            irrfPFTotal.natRend.Should().BeNullOrEmpty();
            irrfPFTotal.ValorCrDctf.Should().Be("112,50");

            var irrfPJTotal = total.Single(ev => ev.CodigoReceita == "170806");
            irrfPJTotal.Should().NotBeNull();
            irrfPJTotal.natRend.Should().BeNullOrEmpty();
            irrfPJTotal.ValorCrDctf.Should().Be("2290,88");

            var csllTotal = total.Single(ev => ev.CodigoReceita == "598707");
            csllTotal.Should().NotBeNull();
            csllTotal.natRend.Should().BeNullOrEmpty();
            csllTotal.ValorCrDctf.Should().Be("15272,53");

            var cofinsTotal = total.Single(ev => ev.CodigoReceita == "596007");
            cofinsTotal.Should().NotBeNull();
            cofinsTotal.natRend.Should().BeNullOrEmpty();
            cofinsTotal.ValorCrDctf.Should().Be("4581,76");

            var pisTotal = total.Single(ev => ev.CodigoReceita == "597907");
            pisTotal.Should().NotBeNull();
            pisTotal.natRend.Should().BeNullOrEmpty();
            pisTotal.ValorCrDctf.Should().Be("992,71");
        });
        GeraDadosCadastrais = true;
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaReabertura(Schemas.EFD_Reinf.Versao versao)
    {
        CodigosResultadoEsperado = new[] { "0", "2" };
        GeraDadosCadastrais = true;
        ReciclaDadosCadastrais = false;
        await EnviaFechamentoComMovimentoTributavel(versao);
        GeraDadosCadastrais = false;
        ReciclaDadosCadastrais = true;

        _testNumber = 2;
        var result = await TestaEvento(versao);
        result.retornoLoteEventosAssincrono.retornoEventos.evento.ToList().ForEach(evt =>
        {
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.tpEv.Should().Be("4099");
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.dhProcess.Should().NotBe(DateTime.MinValue);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.nrProtLote.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.nrRecArqBase.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.hash.Should().NotBeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoRecEv.fechRet.Should().Be(Schemas.EFD_Reinf.IndicadorFechamentoReabertura.Reabertura);
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoTotalCR.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoCR_CNR.Should().BeNull();
            evt?.retornoEventoFechamentoRetInfo.evtRetCons.infoTotalCR.Should().BeNull();
        });
        GeraDadosCadastrais = true;
    }


    public override void PreencheCampos(Schemas.EFD_Reinf.R4099 evento, int index = 0)
    {
        if (_testNumber == 2)
            Schemas.EFD_Reinf.R4099Test.PreencheCamposReabertura(evento, CnpjCpf);
        else
            Schemas.EFD_Reinf.R4099Test.PreencheCamposFechamento(evento, CnpjCpf);
    }
}