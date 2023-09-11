using System.Linq.Expressions;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public class R9015Test
{
    [Test]
    [TestCase(Versao.v2_01_02)]
    public void ValidaFechamentoSemMovimento(Versao versao)
    {
        R9015 instancia = new()
        {
            Versao = versao
        };
        instancia = (R9015)instancia.Read(Resources.Schemas.EFD_Reinf.Content_R9015_v2_01_02_B_SemMovto);
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
        instancia.evtRetCons.infoRecEv.tpEv.Should().Be("4099");
        instancia.evtRetCons.infoRecEv.idEv.Should().Be("ID1000000112116922023081722054500001");
        instancia.evtRetCons.infoRecEv.hash.Should().Be("O/T2ech5LsnIeFah46hJaEVP0vj3VP9d3LMODfqRxyw=");
        instancia.evtRetCons.infoRecEv.fechRet.Should().Be(IndicadorFechamentoReabertura.Fechamento);
        instancia.evtRetCons.infoCR_CNR.indExistInfo.Should().Be(2);
        instancia.evtRetCons.infoCR_CNR.identEscritDCTF.Should().Be(0);
    }
}