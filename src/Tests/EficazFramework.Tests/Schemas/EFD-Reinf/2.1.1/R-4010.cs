namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

public class R4010Test : BaseEfdReinfTest<R4010>
{
    public override string ValidationSchemaNamespace => "http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01";

    public override string ValidationSchema => Resources.Schemas.EFD_Reinf.R4010_v2_01_01;

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
                nrInsc = "34785515000166",
            },
            ideEstab = new()
            {
                tpInscEstab = PersonalidadeJuridica.CNPJ,
                nrInscEstab = "34785515000166",
                ideBenef = new()
                {
                    // identificação do beneficiário
                    cpfBenef = "47363361886",
                    nmBenef = "Pierre de Fermat",
                    // listagem de pagamentos
                    idePgto = new()
                    {
                        // identificação do pagamento
                        new()
                        {
                            // informações do pagamento
                            infoPgto = new()
                            {
                                new()
                                {
                                    DataFatoGerador = DateTime.Now,
                                    vlrRendBruto = 152725.25M,

                                },
                            },
                            // Utilizar a tabela 01, do Anexo I do Manual
                            natRend = "12001", // Lucro e dividendo
                            observ = "Lucros do exercício de 2021"
                        },
                    }
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
