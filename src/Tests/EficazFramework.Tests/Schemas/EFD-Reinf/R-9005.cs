namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R9005Test
{
    [Test]
    [TestCase(Versao.v2_01_02)]
    public void ValidaRetornoEnvio(Versao versao)
    {
        R9005 instancia = new()
        {
            Versao = versao
        };
        instancia = (R9005)instancia.Read(Resources.Schemas.EFD_Reinf.Content_R9005_v2_01_02_B);
        instancia.evtRet.id.Should().Be("ID9005000000000000000000000601050088");
        instancia.evtRet.ideEvento.perApur.Should().Be("2023-08");
        instancia.evtRet.ideContri.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        instancia.evtRet.ideContri.nrInsc.Should().Be("34785515");
        instancia.evtRet.ideRecRetorno.ideStatus.cdRetorno.Should().Be("0");
        instancia.evtRet.ideRecRetorno.ideStatus.descRetorno.Should().Be("SUCESSO");
        instancia.evtRet.infoRecEv.nrRecArqBase.Should().Be("26072-02-4020-2308-26072");
        instancia.evtRet.infoRecEv.nrProtLote.Should().Be("2.202309.1247674");

        DateTimeOffset excectedDtRecepcao = new(2023, 09, 11, 21, 43, 41, 877, TimeSpan.FromHours(-3));
        (instancia.evtRet.infoRecEv.dhRecepcao + instancia.evtRet.infoRecEv.dhRecepcao.Offset)
            .Should().BeCloseTo(excectedDtRecepcao + excectedDtRecepcao.Offset, TimeSpan.FromSeconds(1));

        instancia.evtRet.infoRecEv.dhProcess.Should().BeCloseTo(new DateTimeOffset(2023, 09, 11, 21, 43, 42, 591, TimeSpan.FromHours(-3)), 
                                                                TimeSpan.FromSeconds(1));

        instancia.evtRet.infoRecEv.tpEv.Should().Be("4020");
        instancia.evtRet.infoRecEv.idEv.Should().Be("ID1000000112116922023091121434100001");
        instancia.evtRet.infoRecEv.hash.Should().Be("NBZkwxhz0EL9Uxq0UQxgz/BJZF72DtqKkYB4az7Bqf0=");
        instancia.evtRet.infoRecEv.fechRet.Should().BeNull();
        
        instancia.evtRet.infoTotal.ideEstab.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        instancia.evtRet.infoTotal.ideEstab.nrInsc.Should().Be("61918769000188");
        instancia.evtRet.infoTotal.ideEstab.nrInscBenef.Should().Be("10608025000126");
        instancia.evtRet.infoTotal.ideEstab.TotalApuracaoQuinzenal.Should().BeNull();
        instancia.evtRet.infoTotal.ideEstab.TotalApuracaoDecendial.Should().BeNull();
        instancia.evtRet.infoTotal.ideEstab.TotalApuracaoSemanal.Should().BeNull();
        instancia.evtRet.infoTotal.ideEstab.TotalApuracaoDiaria.Should().BeNull();
        var totalMesNR = instancia.evtRet.infoTotal.ideEstab.TotalApuracaoMensal;
        totalMesNR.Should().NotBeNull();
        totalMesNR.Where(e => e.CodigoReceita == "170806")
                  .Sum(e => decimal.Parse(e.ValorBaseCR ?? "0"))
                  .Should().Be(152725.25M);
        totalMesNR.Where(e => e.CodigoReceita == "170806")
                  .Sum(e => decimal.Parse(e.TotalApuracaoTributo.ValorCRInformado ?? "0"))
                  .Should().Be(2290.88M);
        totalMesNR.Sum(e => decimal.Parse(e.ValorBaseCR ?? "0")).Should().Be(610901M);
        totalMesNR.Sum(e => decimal.Parse(e.TotalApuracaoTributo.ValorCRInformado ?? "0")).Should().Be(23137.88M);
    }

}