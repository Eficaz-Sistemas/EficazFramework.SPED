namespace EficazFramework.SPED.Schemas.eSocial;

public class S2200Test : BaseESocialTest<S2200>
{
    private int _testNumber = 0;

    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    public async Task Valida(Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtAdmissao/{versao}";
        ValidationSchema = versao switch
        {
            _ => Resources.Schemas.eSocial.S2200_v_S_01_02_00
        };
        await TestaEvento();
    }


    // BaseESocialTest overrides
    public override void PreencheCampos(S2200 evento)
    {
        evento.Versao = _versao;
        evento.evtAdmissao = new()
        {
            ideEvento = new()
            {
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "2.2"
            },
            ideEmpregador = new()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = CnpjCpf[..8]
            },
            trabalhador = new()
            {
                cpfTrab = "45019308889",
                nmTrab = "Fulano de Tal",
                sexo = "M",
                nascimento = new()
                {
                    dtNascto = new(1980, 1, 2),
                    paisNascto = "105",
                    paisNac = "105"
                }
            },
            vinculo = new()
            {
                matricula = "1002",
                tpRegTrab = VinculoTrabalhista.CLT,
                tpRegPrev = RegimePrevidenciario.RGPS,
                cadIni = SimNaoString.Sim,
                infoRegimeTrab = new()
                {
                    Item = new S2200InfoRegimeTrabInfoCeletista()
                    {
                        dtAdm = new(2021, 1, 1),
                        tpAdmissao = TipoAdmissaoCLT.Admissao,
                        indAdmissao = IndicadorAdmissao.Normal,
                        tpRegJor = VinculoRegimeJornada.SubHorarioTrabalho,
                        natAtividade = NaturezaAtividade.Urbano,
                        dtBase = 1,
                        dtBaseSpecified = true,
                        cnpjSindCategProf = CnpjCpf
                    }
                },
                infoContrato = new()
                {
                    nmCargo = "Auxiliar de qualquer coisa",
                    CBOCargo = "411005",
                    codCateg = "101",
                    remuneracao = new()
                    {
                        vrSalFx = 1000,
                        undSalFixo = UnidadeSalarial.Mes
                    }
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2200 instanciaPopulada, S2200 instanciaXml)
    {
        // TODO: verifique se os campos de instanciaXml, preenchidos a partir da leitura de um XmlDocument, 
        //       correspondem exatamente aos valores de instanciaPopulada, formado à partir do método
        //       PreencheCampos().


        // ideEvento
        instanciaXml.evtAdmissao.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAdmissao.ideEvento.tpAmb);
        instanciaXml.evtAdmissao.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAdmissao.ideEvento.procEmi);
        instanciaXml.evtAdmissao.ideEvento.verProc.Should().Be(instanciaPopulada.evtAdmissao.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtAdmissao.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtAdmissao.ideEmpregador.tpInsc);
        instanciaXml.evtAdmissao.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtAdmissao.ideEmpregador.nrInsc);


        // trabalhador
        instanciaXml.evtAdmissao.trabalhador.cpfTrab.Should().Be(instanciaPopulada.evtAdmissao.trabalhador.cpfTrab);
        instanciaXml.evtAdmissao.trabalhador.nmTrab.Should().Be(instanciaPopulada.evtAdmissao.trabalhador.nmTrab);

        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        //// idePeriodo
        //instanciaXml.idePeriodo.iniValid.Should().Be(itemPopulado.idePeriodo.iniValid);
        //instanciaXml.idePeriodo.fimValid.Should().Be(itemPopulado.idePeriodo.fimValid);

        //// infoCadastro
        //instanciaXml.infoCadastro.classTrib.Should().Be(itemPopulado.infoCadastro.classTrib);
        //instanciaXml.infoCadastro.indCoop.Should().Be(itemPopulado.infoCadastro.indCoop);
        //instanciaXml.infoCadastro.indConstr.Should().Be(itemPopulado.infoCadastro.indConstr);
        //instanciaXml.infoCadastro.indDesFolha.Should().Be(itemPopulado.infoCadastro.indDesFolha);
        //instanciaXml.infoCadastro.indOpcCP.Should().Be(itemPopulado.infoCadastro.indOpcCP);
        //instanciaXml.infoCadastro.indPorte.Should().Be(itemPopulado.infoCadastro.indPorte);
        //instanciaXml.infoCadastro.indOptRegEletron.Should().Be(itemPopulado.infoCadastro.indOptRegEletron);
        //instanciaXml.infoCadastro.indTribFolhaPisCofins.Should().Be(itemPopulado.infoCadastro.indTribFolhaPisCofins);
        //instanciaXml.infoCadastro.dadosIsencao.ideMinLei.Should().Be(itemPopulado.infoCadastro.dadosIsencao.ideMinLei);
        //instanciaXml.infoCadastro.dadosIsencao.nrCertif.Should().Be(itemPopulado.infoCadastro.dadosIsencao.nrCertif);
        //instanciaXml.infoCadastro.dadosIsencao.dtEmisCertif.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtEmisCertif);
        //instanciaXml.infoCadastro.dadosIsencao.dtVencCertif.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtVencCertif);
        //instanciaXml.infoCadastro.dadosIsencao.dtDou.Should().BeSameDateAs(itemPopulado.infoCadastro.dadosIsencao.dtDou.Value);
        //instanciaXml.infoCadastro.dadosIsencao.pagDou.Should().Be(itemPopulado.infoCadastro.dadosIsencao.pagDou);
    }
}