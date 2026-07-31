namespace EficazFramework.SPED.Schemas.eSocial;

public class S2200Test : BaseESocialTest<S2200>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtAdmissao/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2200_v_S_01_03_00,
            _ => Resources.Schemas.eSocial.S2200_v_S_01_02_00
        };
        await TestaEvento();
    }

    [Test]
    public async Task ImportaXmlLegado()
    {
        string xmlLegado = $@"<eSocial xmlns=""http://www.esocial.gov.br/schema/evt/evtAdmissao/v_S_01_01_00"">
  <evtAdmissao Id=""ID1347855150001662021010112000000001"">
    <ideEvento>
      <tpAmb>2</tpAmb>
      <procEmi>1</procEmi>
      <verProc>1.0</verProc>
    </ideEvento>
    <ideEmpregador>
      <tpInsc>1</tpInsc>
      <nrInsc>{CnpjCpf[..8]}</nrInsc>
    </ideEmpregador>
    <trabalhador>
      <cpfTrab>45019308889</cpfTrab>
      <nisTrab>12345678901</nisTrab>
      <nmTrab>Fulano Legado</nmTrab>
      <sexo>M</sexo>
      <racaCor>1</racaCor>
      <estCiv>1</estCiv>
      <grauInstr>07</grauInstr>
      <indPriEmpr>N</indPriEmpr>
      <nascimento>
        <dtNascto>1980-01-02</dtNascto>
        <codMunic>3106200</codMunic>
        <uf>MG</uf>
        <paisNascto>105</paisNascto>
        <paisNac>105</paisNac>
        <nmMae>Maria Legado</nmMae>
      </nascimento>
      <documentos>
        <CTPS>
          <nrCtps>12345</nrCtps>
          <serieCtps>001</serieCtps>
          <ufCtps>MG</ufCtps>
        </CTPS>
      </documentos>
      <contato>
        <fonePrinc>31999998888</fonePrinc>
        <foneAlternat>3133334444</foneAlternat>
        <emailPrinc>legado@teste.com</emailPrinc>
      </contato>
    </trabalhador>
    <vinculo>
      <matricula>LEG1001</matricula>
      <tpRegTrab>1</tpRegTrab>
      <tpRegPrev>1</tpRegPrev>
      <nrRecInfPrelim>REC12345</nrRecInfPrelim>
      <cadIni>S</cadIni>
      <infoRegimeTrab>
        <infoCeletista>
          <dtAdm>2021-01-01</dtAdm>
          <tpAdmissao>1</tpAdmissao>
          <indAdmissao>1</indAdmissao>
          <tpRegJor>1</tpRegJor>
          <natAtividade>1</natAtividade>
          <dtBase>1</dtBase>
          <FGTS>
            <opcFGTS>1</opcFGTS>
            <dtOpcFGTS>2021-01-01</dtOpcFGTS>
          </FGTS>
        </infoCeletista>
      </infoRegimeTrab>
      <infoContrato>
        <codCargo>C001</codCargo>
        <nmCargo>Analista Legado</nmCargo>
        <CBOCargo>411005</CBOCargo>
        <codCateg>101</codCateg>
        <remuneracao>
          <vrSalFx>2500.00</vrSalFx>
          <undSalFixo>5</undSalFixo>
        </remuneracao>
      </infoContrato>
      <sucessaoVinc>
        <tpInsc>1</tpInsc>
        <cnpjEmpregAnt>{CnpjCpf}</cnpjEmpregAnt>
        <matricAnt>OLD55</matricAnt>
        <dtTransf>2020-12-31</dtTransf>
      </sucessaoVinc>
    </vinculo>
  </evtAdmissao>
</eSocial>";

        Evento evento = await Evento.ReadAsync(xmlLegado);
        evento.Should().NotBeNull();
        evento.Should().BeOfType<S2200>();
        S2200 s2200 = (S2200)evento;

        s2200.Versao.Should().Be(Versao.v_S_01_01_00);
        s2200.evtAdmissao.Should().NotBeNull();
        s2200.evtAdmissao.trabalhador.cpfTrab.Should().Be("45019308889");
        s2200.evtAdmissao.trabalhador.nmTrab.Should().Be("Fulano Legado");
        s2200.evtAdmissao.trabalhador.nisTrab.Should().Be("12345678901");
        s2200.evtAdmissao.trabalhador.nascimento.nmMae.Should().Be("Maria Legado");
        s2200.evtAdmissao.trabalhador.nascimento.codMunic.Should().Be("3106200");
        s2200.evtAdmissao.trabalhador.documentos.Should().NotBeNull();
        s2200.evtAdmissao.trabalhador.documentos.CTPS.nrCtps.Should().Be("12345");
        s2200.evtAdmissao.trabalhador.contato.foneAlternat.Should().Be("3133334444");
        s2200.evtAdmissao.vinculo.matricula.Should().Be("LEG1001");
        s2200.evtAdmissao.vinculo.nrRecInfPrelim.Should().Be("REC12345");
        s2200.evtAdmissao.vinculo.sucessaoVinc.cnpjEmpregAnt.Should().Be(CnpjCpf);
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
                racaCor = RacaCor.Branca,
                estCiv = EstadoCivil.Solteiro,
                grauInstr = GrauInstrucao.SuperiorCompleto,
                nmSoc = "Nome Social Fulano",
                nascimento = new()
                {
                    dtNascto = new(1980, 1, 2),
                    paisNascto = "105",
                    paisNac = "105"
                },
                contato = new()
                {
                    fonePrinc = "31999998888",
                    emailPrinc = "fulano@teste.com"
                },
                infoDeficiencia = new()
                {
                    defFisica = SimNaoString.Nao,
                    defVisual = SimNaoString.Nao,
                    defAuditiva = SimNaoString.Nao,
                    defMental = SimNaoString.Nao,
                    defIntelectual = SimNaoString.Nao,
                    reabReadap = SimNaoString.Nao,
                    infoCota = SimNaoString.Nao
                },
                dependente =
                [
                    new S2200Dependente()
                    {
                        tpDep = "01",
                        nmDep = "Filho de Tal",
                        dtNascto = new(2010, 5, 10),
                        cpfDep = "12345678901",
                        sexoDep = _versao == Versao.v_S_01_03_00 ? "M" : null,
                        depIRRF = SimNaoString.Sim,
                        depSF = SimNaoString.Sim,
                        incTrab = SimNaoString.Nao
                    }
                ]
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
                        cnpjSindCategProf = CnpjCpf,
                        matAnotJud = _versao == Versao.v_S_01_03_00 ? "MATJUD123" : null,
                        FGTS = new()
                        {
                            dtOpcFGTS = new(2021, 1, 1),
                            dtOpcFGTSSpecified = true
                        }
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
                    },
                    duracao = new()
                    {
                        tpContr = 1
                    },
                    localTrabalho = new()
                    {
                        localTrabGeral = new()
                        {
                            tpInsc = 1,
                            nrInsc = CnpjCpf
                        }
                    },
                    horContratual = new()
                    {
                        qtdHrsSem = 44,
                        qtdHrsSemSpecified = true,
                        tpJornada = TipoJornada.HorarioFixoFolgaFixa_Dom,
                        dscTpJorn = "Jornada de 44 horas semanais",
                        tmpParc = 0,
                        horNoturno = SimNaoString.Nao
                    },
                    treiCap = _versao == Versao.v_S_01_03_00 ? new() { codTreiCap = "1001" } : null
                },
                sucessaoVinc = new()
                {
                    tpInsc = VinculoSucecssaoAnteriorTipo.CNPJ,
                    nlrInsc = CnpjCpf,
                    matricAnt = "999",
                    dtTransf = new(2020, 12, 31)
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2200 instanciaPopulada, S2200 instanciaXml)
    {
        instanciaPopulada.Should().NotBeNull();
        instanciaXml.Should().NotBeNull();

        // ideEvento
        instanciaXml.evtAdmissao.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAdmissao.ideEvento.tpAmb);
        instanciaXml.evtAdmissao.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAdmissao.ideEvento.procEmi);
        instanciaXml.evtAdmissao.ideEvento.verProc.Should().Be(instanciaPopulada.evtAdmissao.ideEvento.verProc);

        // ideEmpregador
        instanciaXml.evtAdmissao.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtAdmissao.ideEmpregador.tpInsc);
        instanciaXml.evtAdmissao.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtAdmissao.ideEmpregador.nrInsc);

        // trabalhador
        var trabPop = instanciaPopulada.evtAdmissao.trabalhador;
        var trabXml = instanciaXml.evtAdmissao.trabalhador;

        trabXml.cpfTrab.Should().Be(trabPop.cpfTrab);
        trabXml.nmTrab.Should().Be(trabPop.nmTrab);
        trabXml.sexo.Should().Be(trabPop.sexo);
        trabXml.racaCor.Should().Be(trabPop.racaCor);
        trabXml.estCiv.Should().Be(trabPop.estCiv);
        trabXml.grauInstr.Should().Be(trabPop.grauInstr);
        trabXml.nmSoc.Should().Be(trabPop.nmSoc);

        // nascimento
        trabXml.nascimento.dtNascto.Should().Be(trabPop.nascimento.dtNascto);
        trabXml.nascimento.paisNascto.Should().Be(trabPop.nascimento.paisNascto);
        trabXml.nascimento.paisNac.Should().Be(trabPop.nascimento.paisNac);

        // contato
        trabXml.contato.fonePrinc.Should().Be(trabPop.contato.fonePrinc);
        trabXml.contato.emailPrinc.Should().Be(trabPop.contato.emailPrinc);

        // dependente
        trabXml.dependente.Should().HaveCount(trabPop.dependente.Count);
        trabXml.dependente[0].tpDep.Should().Be(trabPop.dependente[0].tpDep);
        trabXml.dependente[0].nmDep.Should().Be(trabPop.dependente[0].nmDep);
        trabXml.dependente[0].dtNascto.Should().Be(trabPop.dependente[0].dtNascto);
        trabXml.dependente[0].cpfDep.Should().Be(trabPop.dependente[0].cpfDep);
        if (_versao == Versao.v_S_01_03_00)
        {
            trabXml.dependente[0].sexoDep.Should().Be(trabPop.dependente[0].sexoDep);
        }

        // vinculo
        var vincPop = instanciaPopulada.evtAdmissao.vinculo;
        var vincXml = instanciaXml.evtAdmissao.vinculo;

        vincXml.matricula.Should().Be(vincPop.matricula);
        vincXml.tpRegTrab.Should().Be(vincPop.tpRegTrab);
        vincXml.tpRegPrev.Should().Be(vincPop.tpRegPrev);
        vincXml.cadIni.Should().Be(vincPop.cadIni);

        // infoRegimeTrab
        var celPop = (S2200InfoRegimeTrabInfoCeletista)vincPop.infoRegimeTrab.Item;
        var celXml = (S2200InfoRegimeTrabInfoCeletista)vincXml.infoRegimeTrab.Item;

        celXml.dtAdm.Should().Be(celPop.dtAdm);
        celXml.tpAdmissao.Should().Be(celPop.tpAdmissao);
        celXml.indAdmissao.Should().Be(celPop.indAdmissao);
        celXml.tpRegJor.Should().Be(celPop.tpRegJor);
        celXml.natAtividade.Should().Be(celPop.natAtividade);
        celXml.dtBase.Should().Be(celPop.dtBase);
        celXml.cnpjSindCategProf.Should().Be(celPop.cnpjSindCategProf);
        if (_versao == Versao.v_S_01_03_00)
        {
            celXml.matAnotJud.Should().Be(celPop.matAnotJud);
        }

        // infoContrato
        var ctrPop = vincPop.infoContrato;
        var ctrXml = vincXml.infoContrato;

        ctrXml.nmCargo.Should().Be(ctrPop.nmCargo);
        ctrXml.CBOCargo.Should().Be(ctrPop.CBOCargo);
        ctrXml.codCateg.Should().Be(ctrPop.codCateg);
        ctrXml.remuneracao.vrSalFx.Should().Be(ctrPop.remuneracao.vrSalFx);
        ctrXml.remuneracao.undSalFixo.Should().Be(ctrPop.remuneracao.undSalFixo);
        ctrXml.horContratual.dscTpJorn.Should().Be(ctrPop.horContratual.dscTpJorn);

        if (_versao == Versao.v_S_01_03_00)
        {
            ctrXml.treiCap.Should().NotBeNull();
            ctrXml.treiCap.codTreiCap.Should().Be(ctrPop.treiCap.codTreiCap);
        }

        // sucessaoVinc
        vincXml.sucessaoVinc.Should().NotBeNull();
        vincXml.sucessaoVinc.tpInsc.Should().Be(vincPop.sucessaoVinc.tpInsc);
        vincXml.sucessaoVinc.nlrInsc.Should().Be(vincPop.sucessaoVinc.nlrInsc);
        vincXml.sucessaoVinc.matricAnt.Should().Be(vincPop.sucessaoVinc.matricAnt);
        vincXml.sucessaoVinc.dtTransf.Should().Be(vincPop.sucessaoVinc.dtTransf);
    }
}