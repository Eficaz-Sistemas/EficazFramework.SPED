namespace EficazFramework.SPED.Services.EFD_Reinf;

public class R2020Test : MovEfdReinfTest<Schemas.EFD_Reinf.R2020>
{
    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimento(Schemas.EFD_Reinf.Versao versao)
    {
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.SingleOrDefault();
        retorno.Should().NotBeNull();
        var totalEstabelecimento = retorno.retornoEventoInfo.evtTotal.infoTotal.ideEstab;
        totalEstabelecimento.Should().NotBeNull();
        totalEstabelecimento.RPrest.Single().nrInscTomador.Should().Be("61918769000188");
        totalEstabelecimento.RPrest.Single().vlrTotalBaseRet.Should().Be("600,00");
        totalEstabelecimento.RPrest.Single().vlrTotalRetPrinc.Should().Be("66,00");
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoEmLote(Schemas.EFD_Reinf.Versao versao)
    {
        var result = await TestaLoteEvento(versao, 2);

        //! Evento 1: 61918769000188 | 600,00 | 1 nf
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.Should().NotBeNull();
        var totalEstabelecimento = retorno.retornoEventoInfo.evtTotal.infoTotal.ideEstab;
        totalEstabelecimento.Should().NotBeNull();
        totalEstabelecimento.RPrest.Single().nrInscTomador.Should().Be("61918769000188");
        totalEstabelecimento.RPrest.Single().vlrTotalBaseRet.Should().Be("600,00");
        totalEstabelecimento.RPrest.Single().vlrTotalRetPrinc.Should().Be("66,00");

        //! Evento 2: 18505527000133 | 1600,00 | 2 nfs
        retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.LastOrDefault();
        retorno.Should().NotBeNull();
        totalEstabelecimento = retorno.retornoEventoInfo.evtTotal.infoTotal.ideEstab;
        totalEstabelecimento.Should().NotBeNull();
        totalEstabelecimento.RPrest.Single().nrInscTomador.Should().Be("18505527000133");
        totalEstabelecimento.RPrest.Single().vlrTotalBaseRet.Should().Be("1600,00");
        totalEstabelecimento.RPrest.Single().vlrTotalRetPrinc.Should().Be("176,00");
    }


    public override void PreencheCampos(Schemas.EFD_Reinf.R2020 evento, int index = 0)
    {
        Schemas.EFD_Reinf.R2020Test.PreencheCamposR2020(evento, CnpjCpf);

        if (index != 0)
        {
            //evtServPrest
            evento.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nrInscTomador = "18505527000133";
            evento.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalBruto = "1600,00";
            evento.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalBaseRet = "1600,00";
            evento.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.vlrTotalRetPrinc = "176,00";
            evento.evtServPrest.infoServPrest.ideEstabPrest.ideTomador.nfs.Add(new Schemas.EFD_Reinf.R2010eR2020Nfs()
            {
                serie = "1",
                numDocto = "2000",
                dtEmissaoNF = new DateTime(DateTime.Now.Year, DateTime.Now.Date.AddMonths(-1).Month, 3),
                vlrBruto = "1000,00",
                infoTpServ = new System.Collections.Generic.List<Schemas.EFD_Reinf.R2010eR2020InformacaoServico>
            {
                new Schemas.EFD_Reinf.R2010eR2020InformacaoServico()
                {
                    tpServico = "100000001",
                    vlrBaseRet = "1000,00",
                    vlrRetencao = "110,00"
                }
            }

            });
        }
    }
}