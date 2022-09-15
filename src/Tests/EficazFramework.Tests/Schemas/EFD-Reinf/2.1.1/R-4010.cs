namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01.TestPeriodicos;

public class R4010Test : BaseEfdReinfTest<R4010>
{
    [Test]
    public void LeituraEscrita()
    {
        TestaEvento();
    }

    public override void PreencheCampos(R4010 evento)
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

    public override void ValidaInstanciasLeituraEscrita(R4010 instanciaPopulada, R4010 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().
    }
}
