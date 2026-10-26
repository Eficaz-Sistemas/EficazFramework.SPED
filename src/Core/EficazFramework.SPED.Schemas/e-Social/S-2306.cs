using System;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Trabalhador Sem Vínculo de Emprego/Estatutário - Alteração Contratual
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
///
/// evento.evtTSVAltContr = new S2306EvtTSVAltContr
/// {
///     ideEvento = new S2306IdeEvento
///     {
///         indRetif = IndicadorRetificacao.Original,
///         nrRecibo = null,
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "EficazFramework"
///     },
///
///     ideEmpregador = new Empregador
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "12345678000199"
///     },
///
///     ideTrabSemVinculo = new S2306IdeTrabSemVinculo
///     {
///         cpfTrab = "12345678901",
///         matricula = "123",
///         codCateg = null
///     },
///
///     infoTSVAlteracao = new S2306InfoTSVAlteracao
///     {
///         dtAlteracao = new DateTime(2026, 10, 1),
///         natAtividade = NaturezaAtividade.Urbano,
///
///         infoComplementares = new S2306InfoComplementares
///         {
///             cargoFuncao = new S2306CargoFuncao
///             {
///                 nmCargo = "Diretor Administrativo",
///                 CBOCargo = "123105",
///                 nmFuncao = "Coordenador de Projetos",
///                 CBOFuncao = "142105"
///             },
///
///             remuneracao = new S2306Remuneracao
///             {
///                 vrSalFx = 3500.50m,
///                 undSalFixo = 5,
///                 dscSalVar = "Comissões de 10% sobre as vendas"
///             },
///
///             infoDirigenteSindical = new S2306InfoDirigenteSindical
///             {
///                 tpRegPrev = RegimePrevidenciario.RGPS
///             },
///
///             infoTrabCedido = new S2306InfoTrabCedido
///             {
///                 tpRegPrev = RegimePrevidenciario.SPSMFA
///             },
///
///             infoMandElet = new S2306InfoMandElet
///             {
///                 indRemunCargo = SimNaoString.Sim,
///                 tpRegPrev = RegimePrevidenciario.RPPS
///             },
///
///             infoEstagiario = new S2306InfoEstagiario
///             {
///                 natEstagio = "N",
///                 nivEstagio = 4,
///                 areaAtuacao = "Administração",
///                 nrApol = "AP123456",
///                 dtPrevTerm = new DateTime(2027, 6, 30),
///                 instEnsino = new S2306InstEnsino
///                 {
///                     cnpjInstEnsino = "12345678000195",
///                     nmRazao = "Instituição de Ensino Ltda",
///                     dscLograd = "Rua das Flores",
///                     nrLograd = "100",
///                     bairro = "Centro",
///                     cep = "01001000",
///                     codMunic = "3550308",
///                     uf = "SP"
///                 },
///                 ageIntegracao = new S2306AgeIntegracao
///                 {
///                     cnpjAgntInteg = "98765432000198"
///                 },
///                 supervisorEstagio = new S2306SupervisorEstagio
///                 {
///                     cpfSupervisor = "98765432100"
///                 }
///             },
///
///             localTrabGeral = new S2306LocalTrabGeral
///             {
///                 tpInsc = 1,
///                 nrInsc = "12345678000199",
///                 descComp = "Sala 12"
///             }
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S2306 : Evento
{
    private S2306EvtTSVAltContr evtTSVAltContrField;
    private SignatureType signatureField;

    public S2306()
    {
        evtTSVAltContrField = new S2306EvtTSVAltContr();
    }

    [XmlElement()]
    public S2306EvtTSVAltContr evtTSVAltContr
    {
        get => evtTSVAltContrField;
        set
        {
            evtTSVAltContrField = value;
            RaisePropertyChanged(nameof(evtTSVAltContr));
        }
    }

    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged(nameof(Signature));
        }
    }

    public override void GeraEventoID()
        => evtTSVAltContrField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtTSVAltContrField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtTSVAltContrField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    public override string ContribuinteCNPJ()
        => evtTSVAltContrField.ideEmpregador.nrInsc;

    public override string TagToSign => Evento.root;
    public override string TagId => nameof(evtTSVAltContr);
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2306EvtTSVAltContr : ESocialBindableObject
{
    private string idField;
    private S2306IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S2306IdeTrabSemVinculo ideTrabSemVinculoField;
    private S2306InfoTSVAlteracao infoTSVAlteracaoField;

    public S2306EvtTSVAltContr()
    {
        ideEventoField = new S2306IdeEvento();
        ideEmpregadorField = new Empregador();
        ideTrabSemVinculoField = new S2306IdeTrabSemVinculo();
        infoTSVAlteracaoField = new S2306InfoTSVAlteracao();
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(Id));
        }
    }

    [XmlElement()]
    public S2306IdeEvento ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    [XmlElement()]
    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    [XmlElement()]
    public S2306IdeTrabSemVinculo ideTrabSemVinculo
    {
        get => ideTrabSemVinculoField;
        set
        {
            ideTrabSemVinculoField = value;
            RaisePropertyChanged(nameof(ideTrabSemVinculo));
        }
    }

    [XmlElement()]
    public S2306InfoTSVAlteracao infoTSVAlteracao
    {
        get => infoTSVAlteracaoField;
        set
        {
            infoTSVAlteracaoField = value;
            RaisePropertyChanged(nameof(infoTSVAlteracao));
        }
    }
}

/// <exclude />
public partial class S2306IdeEvento : ESocialBindableObject
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    public IndicadorRetificacao indRetif
    {
        get => indRetifField;
        set
        {
            indRetifField = value;
            RaisePropertyChanged(nameof(indRetif));
        }
    }

    public string nrRecibo
    {
        get => nrReciboField;
        set
        {
            nrReciboField = value;
            RaisePropertyChanged(nameof(nrRecibo));
        }
    }

    public Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    public EmissorEvento procEmi
    {
        get => procEmiField;
        set
        {
            procEmiField = value;
            RaisePropertyChanged(nameof(procEmi));
        }
    }

    public string verProc
    {
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged(nameof(verProc));
        }
    }
}

/// <exclude />
public partial class S2306IdeTrabSemVinculo : ESocialBindableObject
{
    private string cpfTrabField;
    private string matriculaField;
    private string codCategField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }

    public string matricula
    {
        get => matriculaField;
        set
        {
            matriculaField = value;
            RaisePropertyChanged(nameof(matricula));
        }
    }

    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }
}

/// <exclude />
public partial class S2306InfoTSVAlteracao : ESocialBindableObject
{
    private DateTime dtAlteracaoField;
    private NaturezaAtividade? natAtividadeField;
    private S2306InfoComplementares infoComplementaresField;

    [XmlElement(DataType = "date")]
    public DateTime dtAlteracao
    {
        get => dtAlteracaoField;
        set
        {
            dtAlteracaoField = value;
            RaisePropertyChanged(nameof(dtAlteracao));
        }
    }

    public NaturezaAtividade? natAtividade
    {
        get => natAtividadeField;
        set
        {
            natAtividadeField = value;
            RaisePropertyChanged(nameof(natAtividade));
        }
    }

    public bool ShouldSerializenatAtividade() => natAtividade.HasValue;

    public S2306InfoComplementares infoComplementares
    {
        get => infoComplementaresField;
        set
        {
            infoComplementaresField = value;
            RaisePropertyChanged(nameof(infoComplementares));
        }
    }
}

/// <exclude />
public partial class S2306InfoComplementares : ESocialBindableObject
{
    private S2306CargoFuncao cargoFuncaoField;
    private S2306Remuneracao remuneracaoField;
    private S2306InfoDirigenteSindical infoDirigenteSindicalField;
    private S2306InfoTrabCedido infoTrabCedidoField;
    private S2306InfoMandElet infoMandEletField;
    private S2306InfoEstagiario infoEstagiarioField;
    private S2306LocalTrabGeral localTrabGeralField;

    public S2306CargoFuncao cargoFuncao
    {
        get => cargoFuncaoField;
        set
        {
            cargoFuncaoField = value;
            RaisePropertyChanged(nameof(cargoFuncao));
        }
    }

    public S2306Remuneracao remuneracao
    {
        get => remuneracaoField;
        set
        {
            remuneracaoField = value;
            RaisePropertyChanged(nameof(remuneracao));
        }
    }

    public S2306InfoDirigenteSindical infoDirigenteSindical
    {
        get => infoDirigenteSindicalField;
        set
        {
            infoDirigenteSindicalField = value;
            RaisePropertyChanged(nameof(infoDirigenteSindical));
        }
    }

    public S2306InfoTrabCedido infoTrabCedido
    {
        get => infoTrabCedidoField;
        set
        {
            infoTrabCedidoField = value;
            RaisePropertyChanged(nameof(infoTrabCedido));
        }
    }

    public S2306InfoMandElet infoMandElet
    {
        get => infoMandEletField;
        set
        {
            infoMandEletField = value;
            RaisePropertyChanged(nameof(infoMandElet));
        }
    }

    public S2306InfoEstagiario infoEstagiario
    {
        get => infoEstagiarioField;
        set
        {
            infoEstagiarioField = value;
            RaisePropertyChanged(nameof(infoEstagiario));
        }
    }

    public S2306LocalTrabGeral localTrabGeral
    {
        get => localTrabGeralField;
        set
        {
            localTrabGeralField = value;
            RaisePropertyChanged(nameof(localTrabGeral));
        }
    }
}

/// <exclude />
public partial class S2306CargoFuncao : ESocialBindableObject
{
    private string nmCargoField;
    private string cBOCargoField;
    private string nmFuncaoField;
    private string cBOFuncaoField;

    public string nmCargo
    {
        get => nmCargoField;
        set
        {
            nmCargoField = value;
            RaisePropertyChanged(nameof(nmCargo));
        }
    }

    public string CBOCargo
    {
        get => cBOCargoField;
        set
        {
            cBOCargoField = value;
            RaisePropertyChanged(nameof(CBOCargo));
        }
    }

    public string nmFuncao
    {
        get => nmFuncaoField;
        set
        {
            nmFuncaoField = value;
            RaisePropertyChanged(nameof(nmFuncao));
        }
    }

    public string CBOFuncao
    {
        get => cBOFuncaoField;
        set
        {
            cBOFuncaoField = value;
            RaisePropertyChanged(nameof(CBOFuncao));
        }
    }
}

/// <exclude />
public partial class S2306Remuneracao : ESocialBindableObject
{
    private decimal vrSalFxField;
    private sbyte undSalFixoField;
    private string dscSalVarField;

    public decimal vrSalFx
    {
        get => vrSalFxField;
        set
        {
            vrSalFxField = value;
            RaisePropertyChanged(nameof(vrSalFx));
        }
    }

    public sbyte undSalFixo
    {
        get => undSalFixoField;
        set
        {
            undSalFixoField = value;
            RaisePropertyChanged(nameof(undSalFixo));
        }
    }

    public string dscSalVar
    {
        get => dscSalVarField;
        set
        {
            dscSalVarField = value;
            RaisePropertyChanged(nameof(dscSalVar));
        }
    }
}

/// <exclude />
public partial class S2306InfoDirigenteSindical : ESocialBindableObject
{
    private RegimePrevidenciario tpRegPrevField;

    public RegimePrevidenciario tpRegPrev
    {
        get => tpRegPrevField;
        set
        {
            tpRegPrevField = value;
            RaisePropertyChanged(nameof(tpRegPrev));
        }
    }
}

/// <exclude />
public partial class S2306InfoTrabCedido : ESocialBindableObject
{
    private RegimePrevidenciario tpRegPrevField;

    public RegimePrevidenciario tpRegPrev
    {
        get => tpRegPrevField;
        set
        {
            tpRegPrevField = value;
            RaisePropertyChanged(nameof(tpRegPrev));
        }
    }
}

/// <exclude />
public partial class S2306InfoMandElet : ESocialBindableObject
{
    private SimNaoString? indRemunCargoField;
    private RegimePrevidenciario tpRegPrevField;

    public SimNaoString? indRemunCargo
    {
        get => indRemunCargoField;
        set
        {
            indRemunCargoField = value;
            RaisePropertyChanged(nameof(indRemunCargo));
        }
    }

    public bool ShouldSerializeindRemunCargo() => indRemunCargo.HasValue;

    public RegimePrevidenciario tpRegPrev
    {
        get => tpRegPrevField;
        set
        {
            tpRegPrevField = value;
            RaisePropertyChanged(nameof(tpRegPrev));
        }
    }
}

/// <exclude />
public partial class S2306InfoEstagiario : ESocialBindableObject
{
    private string natEstagioField;
    private sbyte? nivEstagioField;
    private string areaAtuacaoField;
    private string nrApolField;
    private DateTime dtPrevTermField;
    private S2306InstEnsino instEnsinoField;
    private S2306AgeIntegracao ageIntegracaoField;
    private S2306SupervisorEstagio supervisorEstagioField;

    public string natEstagio
    {
        get => natEstagioField;
        set
        {
            natEstagioField = value;
            RaisePropertyChanged(nameof(natEstagio));
        }
    }

    public sbyte? nivEstagio
    {
        get => nivEstagioField;
        set
        {
            nivEstagioField = value;
            RaisePropertyChanged(nameof(nivEstagio));
        }
    }

    public bool ShouldSerializenivEstagio() => nivEstagio.HasValue;

    public string areaAtuacao
    {
        get => areaAtuacaoField;
        set
        {
            areaAtuacaoField = value;
            RaisePropertyChanged(nameof(areaAtuacao));
        }
    }

    public string nrApol
    {
        get => nrApolField;
        set
        {
            nrApolField = value;
            RaisePropertyChanged(nameof(nrApol));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtPrevTerm
    {
        get => dtPrevTermField;
        set
        {
            dtPrevTermField = value;
            RaisePropertyChanged(nameof(dtPrevTerm));
        }
    }

    public S2306InstEnsino instEnsino
    {
        get => instEnsinoField;
        set
        {
            instEnsinoField = value;
            RaisePropertyChanged(nameof(instEnsino));
        }
    }

    public S2306AgeIntegracao ageIntegracao
    {
        get => ageIntegracaoField;
        set
        {
            ageIntegracaoField = value;
            RaisePropertyChanged(nameof(ageIntegracao));
        }
    }

    public S2306SupervisorEstagio supervisorEstagio
    {
        get => supervisorEstagioField;
        set
        {
            supervisorEstagioField = value;
            RaisePropertyChanged(nameof(supervisorEstagio));
        }
    }
}

/// <exclude />
public partial class S2306InstEnsino : ESocialBindableObject
{
    private string cnpjInstEnsinoField;
    private string nmRazaoField;
    private string dscLogradField;
    private string nrLogradField;
    private string bairroField;
    private string cepField;
    private string codMunicField;
    private string ufField;

    public string cnpjInstEnsino
    {
        get => cnpjInstEnsinoField;
        set
        {
            cnpjInstEnsinoField = value;
            RaisePropertyChanged(nameof(cnpjInstEnsino));
        }
    }

    public string nmRazao
    {
        get => nmRazaoField;
        set
        {
            nmRazaoField = value;
            RaisePropertyChanged(nameof(nmRazao));
        }
    }

    public string dscLograd
    {
        get => dscLogradField;
        set
        {
            dscLogradField = value;
            RaisePropertyChanged(nameof(dscLograd));
        }
    }

    public string nrLograd
    {
        get => nrLogradField;
        set
        {
            nrLogradField = value;
            RaisePropertyChanged(nameof(nrLograd));
        }
    }

    public string bairro
    {
        get => bairroField;
        set
        {
            bairroField = value;
            RaisePropertyChanged(nameof(bairro));
        }
    }

    public string cep
    {
        get => cepField;
        set
        {
            cepField = value;
            RaisePropertyChanged(nameof(cep));
        }
    }

    public string codMunic
    {
        get => codMunicField;
        set
        {
            codMunicField = value;
            RaisePropertyChanged(nameof(codMunic));
        }
    }

    public string uf
    {
        get => ufField;
        set
        {
            ufField = value;
            RaisePropertyChanged(nameof(uf));
        }
    }
}

/// <exclude />
public partial class S2306AgeIntegracao : ESocialBindableObject
{
    private string cnpjAgntIntegField;

    public string cnpjAgntInteg
    {
        get => cnpjAgntIntegField;
        set
        {
            cnpjAgntIntegField = value;
            RaisePropertyChanged(nameof(cnpjAgntInteg));
        }
    }
}

/// <exclude />
public partial class S2306SupervisorEstagio : ESocialBindableObject
{
    private string cpfSupervisorField;

    public string cpfSupervisor
    {
        get => cpfSupervisorField;
        set
        {
            cpfSupervisorField = value;
            RaisePropertyChanged(nameof(cpfSupervisor));
        }
    }
}

/// <exclude />
public partial class S2306LocalTrabGeral : ESocialBindableObject
{
    private sbyte tpInscField;
    private string nrInscField;
    private string descCompField;

    public sbyte tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    public string descComp
    {
        get => descCompField;
        set
        {
            descCompField = value;
            RaisePropertyChanged(nameof(descComp));
        }
    }
}
