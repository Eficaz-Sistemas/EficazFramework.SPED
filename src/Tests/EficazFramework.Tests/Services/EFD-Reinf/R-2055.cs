namespace EficazFramework.SPED.Services.EFD_Reinf;

public class R2055Test : MovEfdReinfTest<Schemas.EFD_Reinf.R2055>
{
    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimento(Schemas.EFD_Reinf.Versao versao)
    {
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.Should().NotBeNull();
        var totalEstabelecimento = retorno.retornoEventoInfo.evtTotal.infoTotal.ideEstab;
        totalEstabelecimento.Should().NotBeNull();
        totalEstabelecimento.RAquis.Should().HaveCountGreaterThan(0);
        Console.WriteLine($"R-2055, Código de Recolhimento Retornado: {string.Join(", ", totalEstabelecimento.RAquis.GroupBy(gp => gp.CRAquis).Select(s => s.Key))}");
        totalEstabelecimento.RAquis.Sum(s => double.Parse(!string.IsNullOrEmpty(s.vlrCRAquis) ? s.vlrCRAquis : "0")).Should().BeApproximately(16.3D, 0.01D);
    
    }

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoEmLote(Schemas.EFD_Reinf.Versao versao)
    {
        var result = await TestaLoteEvento(versao, 2);

        //! Evento 1: 07731253619 | 1000,00 | 1 nf
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.Should().NotBeNull();
        var totalEstabelecimento = retorno.retornoEventoInfo.evtTotal.infoTotal.ideEstab;
        totalEstabelecimento.Should().NotBeNull();
        totalEstabelecimento.RAquis.Should().HaveCountGreaterThan(0);
        Console.WriteLine($"R-2055, Código de Recolhimento Retornado: {string.Join(", ", totalEstabelecimento.RAquis.GroupBy(gp => gp.CRAquis).Select(s => s.Key))}");
        totalEstabelecimento.RAquis.Sum(s => double.Parse(!string.IsNullOrEmpty(s.vlrCRAquis) ? s.vlrCRAquis : "0")).Should().BeApproximately(16.3D, 0.01D);

        //! Evento 2: 40794791077 | 2500,00 | 2 nfs 
        retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.LastOrDefault();
        retorno.Should().NotBeNull();
        totalEstabelecimento = retorno.retornoEventoInfo.evtTotal.infoTotal.ideEstab;
        totalEstabelecimento.Should().NotBeNull();
        totalEstabelecimento.RAquis.Should().HaveCountGreaterThan(0);
        Console.WriteLine($"R-2055, Código de Recolhimento Retornado: {string.Join(", ", totalEstabelecimento.RAquis.GroupBy(gp => gp.CRAquis).Select(s => s.Key))}");
        totalEstabelecimento.RAquis.Sum(s => double.Parse(!string.IsNullOrEmpty(s.vlrCRAquis) ? s.vlrCRAquis : "0")).Should().BeApproximately(57.05D, 0.03D);
    }


    public override void PreencheCampos(Schemas.EFD_Reinf.R2055 evento, int index = 0)
    {
        Schemas.EFD_Reinf.R2055Test.PreencheCamposR2055(evento, CnpjCpf);

        if(index != 0)
        {
            evento.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.nrInscProd = "40794791077";
            evento.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis.Add(new Schemas.EFD_Reinf.R2055DetalhamentoAquisicao()
            {
                indAquis = Schemas.EFD_Reinf.IndicadorAquisProd.PF,
                vlrBruto = $"{2250D:#0.00}",
                vlrCPDescPR = $"{29.70D:#0.00}",
                vlrRatDescPR = $"{2.48D:#0.00}",
                vlrSenarDesc = $"{4.50D:#0.00}",
                infoProcJud = null
            });
            evento.evtAqProd.infoAquisProd.ideEstabAdquir.ideProdutor.detAquis.Add(new Schemas.EFD_Reinf.R2055DetalhamentoAquisicao()
            {
                indAquis = Schemas.EFD_Reinf.IndicadorAquisProd.PF,
                vlrBruto = $"{250.00D:#0.00}",
                vlrCPDescPR = $"{3.30D:#0.00}",
                vlrRatDescPR = $"{0.28D:#0.00}",
                vlrSenarDesc = $"{0.50D:#0.00}",
                infoProcJud = null
            });
        }
    }
}