namespace EficazFramework.SPED.Services.EFD_Reinf;

public class R4080Test : MovEfdReinfTest<Schemas.EFD_Reinf.R4080>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task EnviaMovimentoRendimentosTributados(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 0;
        var result = await TestaEvento(versao);
        var retorno = result.retornoLoteEventosAssincrono.retornoEventos.evento.FirstOrDefault();
        retorno.retornoEventoRetInfo.evtRet.infoRecEv.tpEv.Should().Be("4080");
        retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("34785515000166");

        var irrf = retorno.retornoEventoRetInfo.evtRet.infoTotal.ideEstab.TotalApuracaoMensal.Single();
        irrf.Should().NotBeNull();
        irrf.natRend.Should().Be("20001");
        irrf.CodigoReceita.Should().Be("804506");
        irrf.ValorBaseCR.Should().Be("152725,25");
        irrf.TotalApuracaoTributo.ValorCRInformado.Should().Be("2290,88");
    }

    public override void PreencheCampos(Schemas.EFD_Reinf.R4080 evento, int index = 0)
    {
        Schemas.EFD_Reinf.R4080Test.PreencheCamposServices(evento, CnpjCpf);
    }
}