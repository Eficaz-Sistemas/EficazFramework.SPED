namespace EficazFramework.SPED.Services.EFD_Reinf;

public class R2010Test : MovEfdReinfTest<Schemas.EFD_Reinf.R2010>
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
        totalEstabelecimento.RTom.Single().cnpjPrestador.Should().Be("61918769000188");
        totalEstabelecimento.RTom.Single().vlrTotalBaseRet.Should().Be("600,00");
        Console.WriteLine($"R-2010, Código de Recolhimento Retornado: {totalEstabelecimento.RTom.Single().infoCRTom.FirstOrDefault().CRTom}");
        totalEstabelecimento.RTom.Single().infoCRTom.FirstOrDefault().vlrCRTom.Should().Be("66,00");
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
        totalEstabelecimento.RTom.Single().cnpjPrestador.Should().Be("61918769000188");
        totalEstabelecimento.RTom.Single().vlrTotalBaseRet.Should().Be("600,00");
        Console.WriteLine($"R-2010, Código de Recolhimento Retornado do Evento 1: {totalEstabelecimento.RTom.Single().infoCRTom.FirstOrDefault().CRTom}");
        totalEstabelecimento.RTom.Single().infoCRTom.FirstOrDefault().vlrCRTom.Should().Be("66,00");

        //! Evento 2: 18505527000133 | 1600,00 | 2 nfs
        retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.LastOrDefault();
        retorno.Should().NotBeNull();
        totalEstabelecimento = retorno.retornoEventoInfo.evtTotal.infoTotal.ideEstab;
        totalEstabelecimento.Should().NotBeNull();
        totalEstabelecimento.RTom.Single().cnpjPrestador.Should().Be("18505527000133");
        totalEstabelecimento.RTom.Single().vlrTotalBaseRet.Should().Be("1600,00");
        Console.WriteLine($"R-2010, Código de Recolhimento Retornado do Evento 2: {totalEstabelecimento.RTom.Single().infoCRTom.FirstOrDefault().CRTom}");
        totalEstabelecimento.RTom.Single().infoCRTom.FirstOrDefault().vlrCRTom.Should().Be("176,00");
    }


    public override void PreencheCampos(Schemas.EFD_Reinf.R2010 evento, int index = 0)
    {
        Schemas.EFD_Reinf.R2010Test.PreencheCamposR2010(evento, CnpjCpf);

        if (index != 0)
        {
            DateTime dtbase = DateTime.Now.AddMonths(-1);
            //evtServTom
            evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.cnpjPrestador = "18505527000133";
            evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalBruto = "1600,00";
            evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalBaseRet = "1600,00";
            evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.vlrTotalRetPrinc = "176,00";
            evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.indCPRB = Schemas.EFD_Reinf.IndicadorContribuinteCPRB.NaoContribuinte;
            evento.evtServTom.infoServTom.ideEstabObra.idePrestServ.nfs.Add(new Schemas.EFD_Reinf.R2010eR2020Nfs()
            {
                serie = "1",
                numDocto = "2000",
                dtEmissaoNF = dtbase,
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