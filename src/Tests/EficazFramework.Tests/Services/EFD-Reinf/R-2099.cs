namespace EficazFramework.SPED.Services.EFD_Reinf
{
    public class R2099Test : MovEfdReinfTest<Schemas.EFD_Reinf.R2099>
    {
        private int _testNumber = 0;

        [Test]
        [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
        public async Task EnviaComMovimento(Schemas.EFD_Reinf.Versao versao)
        {
            _testNumber = 0;

            //? Envio de R-2010
            var r2010Test = new R2010Test() 
            { 
                ReciclaDadosCadastrais = false,
                CnpjCpf = CnpjCpf
            };
            r2010Test.Contribuinte.nrInsc = CnpjCpf;
            await r2010Test.TestaEvento(versao);

            //? Envio de R-2020
            var r2020Test = new R2020Test() 
            { 
                GeraDadosCadastrais = false,
                ReciclaDadosCadastrais = false ,
                CnpjCpf = CnpjCpf
            };
            r2020Test.Contribuinte.nrInsc = CnpjCpf;
            await r2020Test.TestaEvento(versao);

            //? Envio de R-2055
            var r2055Test = new R2055Test()
            {
                GeraDadosCadastrais = false,
                ReciclaDadosCadastrais = false,
                CnpjCpf = CnpjCpf
            };
            r2055Test.Contribuinte.nrInsc = CnpjCpf;
            await r2055Test.TestaEvento(versao);

            //? Encerra com R-2099
            GeraDadosCadastrais = false;
            var result = await TestaEvento(versao);
            result.retornoLoteEventosAssincrono.retornoEventos.evento.ToList().ForEach(evt =>
            {
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.tpEv.Should().Be("2099");
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.dhProcess.Should().NotBe(DateTime.MinValue);
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.nrProtEntr.Should().NotBeNull();
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.nrRecArqBase.Should().NotBeNull();
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.hash.Should().NotBeNull();
                var totais = evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoTotalContrib;
                totais.indExistInfo.Should().Be(1);
                //! R-2010
                totais.RTom.Single().cnpjPrestador.Should().Be("61918769000188");
                totais.RTom.Single().vlrTotalBaseRet.Should().Be("600,00");
                totais.RTom.Single().infoCRTom.Sum(s => double.Parse(!string.IsNullOrEmpty(s.vlrCRTom) ? s.vlrCRTom : "0")).Should().Be(66.00D);
                totais.RTom.Single().infoCRTom.Sum(s => double.Parse(!string.IsNullOrEmpty(s.vlrCRTomSusp) ? s.vlrCRTomSusp : "0")).Should().Be(0D);
                //! R-2020
                totais.RPrest.Single().nrInscTomador.Should().Be("61918769000188");
                totais.RPrest.Single().vlrTotalBaseRet.Should().Be("600,00");
                totais.RPrest.Single().vlrTotalRetPrinc.Should().Be("66,00");
                //! R-2055
                totais.RAquis.Should().HaveCountGreaterThan(0);
                totais.RAquis.Sum(s => double.Parse(!string.IsNullOrEmpty(s.vlrCRAquis) ? s.vlrCRAquis : "0")).Should().Be(15.0D);
            });
        }


        [Test]
        [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
        public async Task EnviaSemMovimento(Schemas.EFD_Reinf.Versao versao)
        {
            _testNumber = 1;
            GeraDadosCadastrais = true;
            var result = await TestaEvento(versao);
            result.retornoLoteEventosAssincrono.retornoEventos.evento.ToList().ForEach(evt =>
            {
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.tpEv.Should().Be("2099");
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.dhProcess.Should().NotBe(DateTime.MinValue);
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.nrProtEntr.Should().NotBeNull();
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.nrRecArqBase.Should().NotBeNull();
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoRecEv.hash.Should().NotBeNull();
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.infoTotalContrib.indExistInfo.Should().Be(3);
            });
        }


        public override void PreencheCampos(Schemas.EFD_Reinf.R2099 evento, int index = 0)
        {
            Schemas.EFD_Reinf.R2099Test.PreencheCamposR2099(evento, CnpjCpf);

            if (_testNumber == 0) 
            {
                evento.evtFechaEvPer.infoFech.evtServTm = Schemas.EFD_Reinf.SimNao.Sim;
                evento.evtFechaEvPer.infoFech.evtServPr = Schemas.EFD_Reinf.SimNao.Sim;
                evento.evtFechaEvPer.infoFech.evtAquis = Schemas.EFD_Reinf.SimNao.Sim;
            }
        }
    }
}