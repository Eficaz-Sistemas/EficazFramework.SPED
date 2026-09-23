using System.Collections.Generic;
namespace EficazFramework.SPED.Schemas.eSocial;

public class S2206Test : BaseESocialTest<S2206>
{
    [Test]
    [TestCase(Versao.v_S_01_02_00)]
    [TestCase(Versao.v_S_01_03_00)]
    public async Task Valida(Versao versao)
    {
        _versao = versao;
        ValidationSchemaNamespace = $"http://www.esocial.gov.br/schema/evt/evtAltContratual/{versao}";
        ValidationSchema = versao switch
        {
            Versao.v_S_01_03_00 => Resources.Schemas.eSocial.S2006_v_S_01_03_01,
            _ => Resources.Schemas.eSocial.S2006_v_S_01_02_01
        };
        await TestaEvento();
    }

    [Test]
    public async System.Threading.Tasks.Task Read_v_S_01_03_00()
    {
        var evento = await Evento.ReadAsync(Resources.Samples.eSocial.S2206_v_S_01_03_00);
        evento.Should().NotBeNull();
        evento.Versao.Should().Be(Versao.v_S_01_03_00);

        var evtAlt = evento as S2206;
        evtAlt.Should().NotBeNull();
        evtAlt.evtAltContratual.Id.Should().Be("ID1123456780000002024050111000000001");

        evtAlt.evtAltContratual.ideEmpregador.nrInsc.Should().Be("12345678");
        evtAlt.evtAltContratual.ideVinculo.cpfTrab.Should().Be("12345678901");
        evtAlt.evtAltContratual.ideVinculo.matricula.Should().Be("123456");

        evtAlt.evtAltContratual.altContratual.dtAlteracao.Should().Be(new DateTime(2024, 5, 1));
        evtAlt.evtAltContratual.altContratual.dscAlt.Should().Be("Alteração de cargo");

        evtAlt.evtAltContratual.altContratual.vinculo.tpRegPrev.Should().Be(RegimePrevidenciario.RGPS);
        evtAlt.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.tpRegJor.Should().Be(VinculoRegimeJornada.SubHorarioTrabalho);
        evtAlt.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.natAtividade.Should().Be(NaturezaAtividade.Urbano);
        evtAlt.evtAltContratual.altContratual.vinculo.infoContrato.codCateg.Should().Be("101");
        evtAlt.evtAltContratual.altContratual.vinculo.infoContrato.nmCargo.Should().Be("Desenvolvedor Pleno");
        evtAlt.evtAltContratual.altContratual.vinculo.infoContrato.remuneracao.vrSalFx.Should().Be(4500.00);
        evtAlt.evtAltContratual.altContratual.vinculo.infoContrato.remuneracao.undSalFixo.Should().Be(UnidadeSalarial.Mes);
    }

    public override void PreencheCampos(S2206 evento)
    {
        evento.evtAltContratual = new S2206AltContratual()
        {
            ideEvento = new IdeEventoNaoPeriodico()
            {
                indRetif = IndicadorRetificacao.Original,
                tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                procEmi = EmissorEvento.AppEmpregador,
                verProc = "2.0"
            },
            ideEmpregador = new Empregador()
            {
                tpInsc = PersonalidadeJuridica.CNPJ,
                nrInsc = "12345678"
            },
            ideVinculo = new S2206IdeVinculo()
            {
                cpfTrab = "12345678901",
                matricula = "123456"
            },
            altContratual = new S2206Alteracao()
            {
                dtAlteracao = new DateTime(2024, 5, 1),
                dtEf = new DateTime(2024, 5, 1),
                dscAlt = "Alteração de cargo",
                vinculo = new S2206Vinculo()
                {
                    tpRegPrev = RegimePrevidenciario.RGPS,
                    infoRegimeTrab = new S2206InfoRegimeTrab()
                    {
                        infoCeletista = new S2206InfoCeletista()
                        {
                            tpRegJor = VinculoRegimeJornada.SubHorarioTrabalho,
                            natAtividade = NaturezaAtividade.Urbano,
                            dtBase = 5,
                            cnpjSindCategProf = "11111111111111",
                            trabTemporario = new S2206TrabTemporario()
                            {
                                justProrr = "Prorrogação de contrato temporário"
                            },
                            aprend = new S2206Aprend()
                            {
                                indAprend = 1,
                                cnpjEntQual = "11111111111111",
                                tpInsc = TipoInscricao.CNPJ,
                                nrInsc = "11111111111111",
                                cnpjPrat = "11111111111111"
                            }
                        }
                    },
                    infoContrato = new S2206InfoContrato()
                    {
                        codCateg = "101",
                        nmCargo = "Desenvolvedor Pleno",
                        CBOCargo = "212405",
                        nmFuncao = "Desenvolvedor Pleno",
                        CBOFuncao = "212405",
                        acumCargo = SimNaoString.Nao,
                        remuneracao = new S2206Remuneracao()
                        {
                            vrSalFx = 4500.00,
                            undSalFixo = UnidadeSalarial.Mes,
                            dscSalVar = "Comissão"
                        },
                        duracao = new S2206Duracao()
                        {
                            tpContr = TipoContrato.Indeterminado,
                            dtTerm = new DateTime(2024, 12, 31),
                            objDet = "Objeto determinado"
                        },
                        localTrabalho = new S2206LocalTrabalho()
                        {
                            localTrabGeral = new S2206LocalTrabGeral()
                            {
                                tpInsc = PersonalidadeJuridica.CNPJ,
                                nrInsc = "12345678000100",
                                descComp = "Matriz"
                            }
                        },
                        horContratual = new S2206HorContratual()
                        {
                            qtdHrsSem = 44,
                            tpJornada = TipoJornada.Outros,
                            tmpParc = 0,
                            horNoturno = SimNaoString.Nao,
                            dscJorn = "08:00 as 12:00 e das 13:00 as 18:00"
                        },
                        alvaraJudicial = new S2206AlvaraJudicial()
                        {
                            nrProcJud = "12345678901234567890"
                        },
                        observacoes =
                        [
                            new S2206Observacao() { observacao = "Observação 1" },
                            new S2206Observacao() { observacao = "Observação 2" }
                        ],
                        treiCap =
                        [
                            new S2206TreiCap() { codTreiCap = "1234" }
                        ]
                    }
                }
            }
        };
    }

    public override void ValidaInstanciasLeituraEscrita(S2206 instanciaPopulada, S2206 instanciaXml)
    {
        // TODO: Validação.
        instanciaXml.evtAltContratual.ideEvento.tpAmb.Should().Be(instanciaPopulada.evtAltContratual.ideEvento.tpAmb);
        instanciaXml.evtAltContratual.ideEvento.procEmi.Should().Be(instanciaPopulada.evtAltContratual.ideEvento.procEmi);
        instanciaXml.evtAltContratual.ideEvento.verProc.Should().Be(instanciaPopulada.evtAltContratual.ideEvento.verProc);
        instanciaXml.evtAltContratual.ideEmpregador.tpInsc.Should().Be(instanciaPopulada.evtAltContratual.ideEmpregador.tpInsc);
        instanciaXml.evtAltContratual.ideEmpregador.nrInsc.Should().Be(instanciaPopulada.evtAltContratual.ideEmpregador.nrInsc);
        instanciaXml.evtAltContratual.ideVinculo.cpfTrab.Should().Be(instanciaPopulada.evtAltContratual.ideVinculo.cpfTrab);
        instanciaXml.evtAltContratual.ideVinculo.matricula.Should().Be(instanciaPopulada.evtAltContratual.ideVinculo.matricula);

        instanciaXml.evtAltContratual.altContratual.dtAlteracao.Should().Be(instanciaPopulada.evtAltContratual.altContratual.dtAlteracao);
        instanciaXml.evtAltContratual.altContratual.dtEf.Should().Be(instanciaPopulada.evtAltContratual.altContratual.dtEf);
        instanciaXml.evtAltContratual.altContratual.dscAlt.Should().Be(instanciaPopulada.evtAltContratual.altContratual.dscAlt);

        instanciaXml.evtAltContratual.altContratual.vinculo.tpRegPrev.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.tpRegPrev);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.tpRegJor.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.tpRegJor);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.natAtividade.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.natAtividade);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.dtBase.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.dtBase);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.cnpjSindCategProf.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.cnpjSindCategProf);

        instanciaXml.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.trabTemporario.justProrr.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.trabTemporario.justProrr);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.aprend.indAprend.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.aprend.indAprend);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.aprend.cnpjEntQual.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoRegimeTrab.infoCeletista.aprend.cnpjEntQual);

        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.codCateg.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.codCateg);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.nmCargo.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.nmCargo);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.CBOCargo.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.CBOCargo);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.nmFuncao.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.nmFuncao);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.CBOFuncao.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.CBOFuncao);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.acumCargo.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.acumCargo);

        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.remuneracao.vrSalFx.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.remuneracao.vrSalFx);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.remuneracao.undSalFixo.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.remuneracao.undSalFixo);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.remuneracao.dscSalVar.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.remuneracao.dscSalVar);

        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.duracao.tpContr.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.duracao.tpContr);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.duracao.dtTerm.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.duracao.dtTerm);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.duracao.objDet.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.duracao.objDet);

        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.localTrabalho.localTrabGeral.tpInsc.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.localTrabalho.localTrabGeral.tpInsc);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.localTrabalho.localTrabGeral.nrInsc.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.localTrabalho.localTrabGeral.nrInsc);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.localTrabalho.localTrabGeral.descComp.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.localTrabalho.localTrabGeral.descComp);

        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.qtdHrsSem.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.qtdHrsSem);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.tpJornada.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.tpJornada);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.tmpParc.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.tmpParc);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.horNoturno.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.horNoturno);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.dscJorn.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.horContratual.dscJorn);

        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.alvaraJudicial.nrProcJud.Should().Be(instanciaPopulada.evtAltContratual.altContratual.vinculo.infoContrato.alvaraJudicial.nrProcJud);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.observacoes.Should().HaveCount(2);
        instanciaXml.evtAltContratual.altContratual.vinculo.infoContrato.treiCap.Should().HaveCount(1);
    }
}
