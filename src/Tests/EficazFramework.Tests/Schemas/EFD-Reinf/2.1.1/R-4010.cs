using EficazFramework.SPED.Schemas.CTe;

namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.TestPeriodicos;

internal class TestR4010 : BaseEfdReinfTest<R4010>
{
    private int key = 0;

    //[Test]
    internal void TesteBasico()
    {
        TestaEvento();
    }

    public override void PreencheCampos(R4010 evento)
    {
        switch (key)
        {
            case 0:
                PreencheCampos_TesteBasico(evento);
                break;
        }
    }

    private static void PreencheCampos_TesteBasico(R4010 evento)
    {
        evento.evtRetPF = new()
        {
            ideEvento = new()
            {
                indRetif = IndicadorRetificacao.Original,
                perApur = "2022-08",
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppContribuinte,
                verProc = "6.0"
            },
            ideContri = new()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "",
            },
            ideEstab = new()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = "",
                ideBenef = new()
                {
                    cpfBenef = "",
                    nmBenef = ""
                }
            }
        };
    }

    public override void ValidaLeituraXml(R4010 instanciaPopulada, R4010 instanciaXml)
    {
        throw new System.NotImplementedException();
    }
}
