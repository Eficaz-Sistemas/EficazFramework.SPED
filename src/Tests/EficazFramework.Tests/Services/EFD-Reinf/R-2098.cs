namespace EficazFramework.SPED.Services.EFD_Reinf
{
    public class R2098Test : MovEfdReinfTest<Schemas.EFD_Reinf.R2098>
    {
        [Test]
        [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
        public async Task ReabreMovimento(Schemas.EFD_Reinf.Versao versao)
        {
            //? Envio de R-2099
            var r2099Test = new R2099Test() 
            {
                ReciclaDadosCadastrais = false ,
                CnpjCpf = CnpjCpf
            };
            r2099Test.Contribuinte.nrInsc = CnpjCpf;
            await r2099Test.EnviaSemMovimento(versao);

            //? Reabre com R-2098
            GeraDadosCadastrais = false;
            var result = await TestaEvento(versao);
            result.retornoLoteEventosAssincrono.retornoEventos.evento.ToList().ForEach(evt =>
            {
                evt?.retornoEventoInfo.evtTotal.infoRecEv.tpEv.Should().Be("2098");
                evt?.retornoEventoInfo.evtTotal.infoRecEv.dhProcess.Should().NotBe(DateTime.MinValue);
                evt?.retornoEventoInfo.evtTotal.infoRecEv.nrProtEntr.Should().BeNull();
                evt?.retornoEventoInfo.evtTotal.infoRecEv.nrRecArqBase.Should().NotBeNull();
                evt?.retornoEventoInfo.evtTotal.infoRecEv.hash.Should().NotBeNull();
                var totais = evt?.retornoEventoInfo.evtTotal.infoTotal;
                totais.ideEstab.Should().BeNull();
            });
        }

        public override void PreencheCampos(Schemas.EFD_Reinf.R2098 evento, int index = 0)
        {
            Schemas.EFD_Reinf.R2098Test.PreencheCamposR2098(evento, CnpjCpf);
        }
    }
}