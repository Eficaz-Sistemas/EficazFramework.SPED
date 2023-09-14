using System.Linq.Expressions;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R9015Test
{
    [Test]
    [TestCase(Versao.v2_01_02)]
    public void ValidaFechamentoMovimentoIsento(Versao versao)
    {
        R9015 instancia = new()
        {
            Versao = versao
        };
        instancia = (R9015)instancia.Read(Resources.Schemas.EFD_Reinf.Content_R9015_v2_01_02_B_MovIsento);
        instancia.evtRetCons.id.Should().Be("ID9015000000000000000000000323704091");
        instancia.evtRetCons.ideEvento.perApur.Should().Be("2023-07");
        instancia.evtRetCons.ideContri.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        instancia.evtRetCons.ideContri.nrInsc.Should().Be("34785515");
        instancia.evtRetCons.ideRecRetorno.ideStatus.cdRetorno.Should().Be("0");
        instancia.evtRetCons.ideRecRetorno.ideStatus.descRetorno.Should().Be("SUCESSO");
        instancia.evtRetCons.infoRecEv.nrRecArqBase.Should().Be("1300-02-4099-2307-1300");
        instancia.evtRetCons.infoRecEv.nrProtLote.Should().Be("2.202308.864398");
        instancia.evtRetCons.infoRecEv.dhRecepcao.Should().Be(DateTime.MinValue);
        instancia.evtRetCons.infoRecEv.dhProcess.Date.Should().Be(new DateTime(2023,08,17));
        instancia.evtRetCons.infoRecEv.dhProcess.Hour.Should().Be(22);
        instancia.evtRetCons.infoRecEv.dhProcess.Minute.Should().Be(5);
        instancia.evtRetCons.infoRecEv.dhProcess.Second.Should().Be(46);
        instancia.evtRetCons.infoRecEv.dhProcess.Should().BeCloseTo(new DateTimeOffset(2023, 08, 17, 22, 5, 46, TimeSpan.FromHours(-3)),
                                                                    TimeSpan.FromSeconds(1));
        instancia.evtRetCons.infoRecEv.tpEv.Should().Be("4099");
        instancia.evtRetCons.infoRecEv.idEv.Should().Be("ID1000000112116922023081722054500001");
        instancia.evtRetCons.infoRecEv.hash.Should().Be("O/T2ech5LsnIeFah46hJaEVP0vj3VP9d3LMODfqRxyw=");
        instancia.evtRetCons.infoRecEv.fechRet.Should().Be(IndicadorFechamentoReabertura.Fechamento);
        instancia.evtRetCons.infoCR_CNR.indExistInfo.Should().Be(2);
        instancia.evtRetCons.infoCR_CNR.identEscritDCTF.Should().Be(0);
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoMensal.Should().BeNull();
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoQuinzenal.Should().BeNull();
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoDecendial.Should().BeNull();
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoSemanal.Should().BeNull();
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoDiaria.Should().BeNull();
    }

    [Test]
    [TestCase(Versao.v2_01_02)]
    public void ValidaFechamentoMovimentoTrib(Versao versao)
    {
        R9015 instancia = new()
        {
            Versao = versao
        };
        instancia = (R9015)instancia.Read(Resources.Schemas.EFD_Reinf.Content_R9015_v2_01_02_B_MovTributavel);
        instancia.evtRetCons.id.Should().Be("ID9015000000000000000000000706807356");
        instancia.evtRetCons.ideEvento.perApur.Should().Be("2023-08");
        instancia.evtRetCons.ideContri.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        instancia.evtRetCons.ideContri.nrInsc.Should().Be("34785515");
        instancia.evtRetCons.ideRecRetorno.ideStatus.cdRetorno.Should().Be("0");
        instancia.evtRetCons.ideRecRetorno.ideStatus.descRetorno.Should().Be("SUCESSO");
        instancia.evtRetCons.infoRecEv.nrRecArqBase.Should().Be("1971-02-4099-2308-1971");
        instancia.evtRetCons.infoRecEv.nrProtLote.Should().Be("2.202309.1214293");

        DateTimeOffset excectedDtRecepcao = new DateTimeOffset(2023, 09, 11, 7, 17, 19, TimeSpan.FromHours(-3));
        (instancia.evtRetCons.infoRecEv.dhRecepcao + instancia.evtRetCons.infoRecEv.dhRecepcao.Offset)
            .Should().BeCloseTo(excectedDtRecepcao + excectedDtRecepcao.Offset, TimeSpan.FromSeconds(1));

        instancia.evtRetCons.infoRecEv.dhProcess.Should().BeCloseTo(new DateTimeOffset(2023, 09, 11, 7, 17, 19, TimeSpan.FromHours(-3)),
                                                                            TimeSpan.FromSeconds(1));
        instancia.evtRetCons.infoRecEv.tpEv.Should().Be("4099");
        instancia.evtRetCons.infoRecEv.idEv.Should().Be("ID1000000112116922023091107172200001");
        instancia.evtRetCons.infoRecEv.hash.Should().Be("p2H1AcWIrf6sS6oJBk9kDeGrj398KOE7+RPfKLuyXkk=");
        instancia.evtRetCons.infoRecEv.fechRet.Should().Be(IndicadorFechamentoReabertura.Fechamento);
        
        //! TOTAIS POR NATUREZA DE RECEITA
        instancia.evtRetCons.infoCR_CNR.indExistInfo.Should().Be(1);
        instancia.evtRetCons.infoCR_CNR.identEscritDCTF.Should().Be(0);
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoMensal?.Should().HaveCountGreaterThan(0);
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoQuinzenal.Should().BeNull();
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoDecendial.Should().BeNull();
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoSemanal.Should().BeNull();
        instancia.evtRetCons.infoCR_CNR.TotalApuracaoDiaria.Should().BeNull();

        var totalMesNR = instancia.evtRetCons.infoCR_CNR.TotalApuracaoMensal;
        totalMesNR.Should().NotBeNull();
        totalMesNR.Where(e => e.CodigoReceita == "058807")
                  .Sum(e => decimal.Parse(e.ValorCRInformado ?? "0"))
                  .Should().Be(112.5M);
        totalMesNR.Where(e => e.CodigoReceita == "058807")
                  .Sum(e => decimal.Parse(e.ValorCrDctf ?? "0"))
                  .Should().Be(112.5M);
        totalMesNR.Sum(e => decimal.Parse(e.ValorCRInformado ?? "0")).Should().Be(23250.38M);
        totalMesNR.Sum(e => decimal.Parse(e.ValorCrDctf ?? "0")).Should().Be(23250.38M);


        //! TOTAIS CONSOLIDADOS
        instancia.evtRetCons.infoTotalCR.TotalApuracaoMensal?.Should().HaveCountGreaterThan(0);
        instancia.evtRetCons.infoTotalCR.TotalApuracaoQuinzenal.Should().BeNull();
        instancia.evtRetCons.infoTotalCR.TotalApuracaoDecendial.Should().BeNull();
        instancia.evtRetCons.infoTotalCR.TotalApuracaoSemanal.Should().BeNull();
        instancia.evtRetCons.infoTotalCR.TotalApuracaoDiaria.Should().BeNull();

        var totalMes = instancia.evtRetCons.infoCR_CNR.TotalApuracaoMensal;
        totalMes.Should().NotBeNull();
        totalMes.Where(e => e.CodigoReceita == "058807")
                .Sum(e => decimal.Parse(e.ValorCRInformado ?? "0"))
                .Should().Be(112.5M);
        totalMes.Where(e => e.CodigoReceita == "058807")
                .Sum(e => decimal.Parse(e.ValorCrDctf ?? "0"))
                .Should().Be(112.5M);
        totalMes.Sum(e => decimal.Parse(e.ValorCRInformado ?? "0")).Should().Be(23250.38M);
        totalMes.Sum(e => decimal.Parse(e.ValorCrDctf ?? "0")).Should().Be(23250.38M);
    }

}