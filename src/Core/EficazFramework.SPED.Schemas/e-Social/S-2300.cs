using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Evento S-2300 - Trabalhador Sem Vínculo de Emprego/Estatutário - Início
/// </summary>
/// <example>
/// ```csharp
/// var evento = new S2300();
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtTSVInicio = new S2300EvtTSVInicio()
/// {
///     ideEvento = new IdeEventoNaoPeriodico()
///     {
///         indRetif = IndicadorRetificacao.Original,
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "2.2"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "12345678"
///     },
///     trabalhador = new S2300Trabalhador()
///     {
///         cpfTrab = "12345678901",
///         nmTrab = "Fulano de Tal",
///         sexo = Sexo.Masculino,
///         racaCor = RacaCor.Branca,
///         estCiv = EstadoCivil.Solteiro,
///         grauInstr = GrauInstrucao.Analfabeto,
///         nmSoc = "Fulano",
///         nascimento = new S2300Nascimento()
///         {
///             dtNascto = new DateTime(1980, 1, 1),
///             paisNascto = "105",
///             paisNac = "105"
///         },
///         endereco = new S2300Endereco()
///         {
///             brasil = new EnderecoBrasileiro()
///             {
///                 tpLograd = "Rua",
///                 dscLograd = "Rua de Teste",
///                 nrLograd = "123",
///                 bairro = "Centro",
///                 cep = "12345678",
///                 codMunic = "1234567",
///                 uf = UFCadastro.SP
///             }
///         },
///         trabImig = new S2300TrabImig()
///         {
///             tmpResid = 1,
///             condIng = 2
///         },
///         infoDeficiencia = new S2300InfoDeficiencia()
///         {
///             defFisica = SimNaoString.Nao,
///             defVisual = SimNaoString.Nao,
///             defAuditiva = SimNaoString.Nao,
///             defMental = SimNaoString.Nao,
///             defIntelectual = SimNaoString.Nao,
///             reabReadap = SimNaoString.Nao,
///             observacao = "Obs"
///         },
///         dependente = new System.Collections.Generic.List<S2300Dependente>()
///         {
///             new S2300Dependente()
///             {
///                 tpDep = "01",
///                 nmDep = "Dependente 1",
///                 dtNascto = new DateTime(2010, 1, 1),
///                 cpfDep = "09876543210",
///                 depIRRF = SimNaoString.Sim,
///                 depSF = SimNaoString.Sim,
///                 incTrab = SimNaoString.Nao,
///                 descrDep = "Descricao"
///             }
///         },
///         contato = new S2300Contato()
///         {
///             fonePrinc = "11999999999",
///             emailPrinc = "teste@teste.com"
///         }
///     },
///     infoTSVInicio = new S2300InfoTSVInicio()
///     {
///         cadIni = SimNaoString.Sim,
///         matricula = "12345",
///         codCateg = "721",
///         dtInicio = new DateTime(2023, 1, 1),
///         nrProcTrab = "12345678901234567890",
///         natAtividade = NaturezaAtividade.Urbano,
///         infoComplementares = new S2300InfoComplementares()
///         {
///             cargoFuncao = new S2300CargoFuncao()
///             {
///                 nmCargo = "Diretor",
///                 CBOCargo = "123456",
///                 nmFuncao = "Diretor Financeiro",
///                 CBOFuncao = "123456"
///             },
///             remuneracao = new S2300Remuneracao()
///             {
///                 vrSalFx = 10000.00m,
///                 undSalFixo = 5,
///                 dscSalVar = "Bonus"
///             },
///             FGTS = new S2300FGTS()
///             {
///                 dtOpcFGTS = new DateTime(2023, 1, 1)
///             },
///             infoDirigenteSindical = new S2300InfoDirigenteSindical()
///             {
///                 categOrig = "101",
///                 tpInsc = 1,
///                 nrInsc = "12345678000123",
///                 dtAdmOrig = new DateTime(2020, 1, 1),
///                 matricOrig = "123",
///                 tpRegTrab = VinculoTrabalhista.CLT,
///                 tpRegPrev = RegimePrevidenciario.RGPS
///             },
///             infoTrabCedido = new S2300InfoTrabCedido()
///             {
///                 categOrig = "101",
///                 cnpjCednt = "12345678000123",
///                 matricCed = "123",
///                 dtAdmCed = new DateTime(2020, 1, 1),
///                 tpRegTrab = VinculoTrabalhista.CLT,
///                 tpRegPrev = RegimePrevidenciario.RGPS
///             },
///             infoMandElet = new S2300InfoMandElet()
///             {
///                 categOrig = "101",
///                 cnpjOrig = "12345678000123",
///                 matricOrig = "123",
///                 dtExercOrig = new DateTime(2020, 1, 1),
///                 indRemunCargo = SimNaoString.Sim,
///                 tpRegTrab = VinculoTrabalhista.CLT,
///                 tpRegPrev = RegimePrevidenciario.RGPS
///             },
///             infoEstagiario = new S2300InfoEstagiario()
///             {
///                 natEstagio = "O",
///                 nivEstagio = 1,
///                 areaAtuacao = "TI",
///                 nrApol = "12345",
///                 dtPrevTerm = new DateTime(2024, 1, 1),
///                 instEnsino = new S2300InstEnsino()
///                 {
///                     cnpjInstEnsino = "12345678000123",
///                     nmRazao = "Inst Ensino",
///                     dscLograd = "Rua",
///                     nrLograd = "123",
///                     bairro = "Centro",
///                     cep = "12345678",
///                     codMunic = "1234567",
///                     uf = "SP"
///                 },
///                 ageIntegracao = new S2300AgeIntegracao()
///                 {
///                     cnpjAgntInteg = "12345678000123"
///                 },
///                 supervisorEstagio = new S2300SupervisorEstagio()
///                 {
///                     cpfSupervisor = "12345678901"
///                 }
///             },
///             localTrabGeral = new S2300LocalTrabalho()
///             {
///                 tpInsc = 1,
///                 nrInsc = "12345678000123",
///                 descComp = "Local 1"
///             }
///         },
///         mudancaCPF = new S2300MudancaCPF()
///         {
///             cpfAnt = "12345678901",
///             matricAnt = "12345",
///             dtAltCPF = new DateTime(2023, 1, 1),
///             observacao = "Obs"
///         },
///         afastamento = new S2300Afastamento()
///         {
///             dtIniAfast = new DateTime(2023, 1, 1),
///             codMotAfast = "01"
///         },
///         termino = new S2300Termino()
///         {
///             dtTerm = new DateTime(2023, 12, 31)
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S2300 : Evento
{
    private S2300EvtTSVInicio evtTSVInicioField;
    private SignatureType signatureField;

    /// <remarks/>
    public S2300EvtTSVInicio evtTSVInicio
    {
        get => evtTSVInicioField;
        set
        {
            evtTSVInicioField = value;
            RaisePropertyChanged(nameof(evtTSVInicio));
        }
    }

    /// <remarks/>
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

    /// <exclude/>
    public override void GeraEventoID() 
        => evtTSVInicioField.Id = string.Format("ID{0}{1}{2}", 
            (int)(evtTSVInicioField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), 
            evtTSVInicioField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", 
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ() 
        => evtTSVInicioField.ideEmpregador.nrInsc;

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtTSVInicio);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2300EvtTSVInicio : ESocialBindableObject
{
    private string idField;
    private IdeEventoNaoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S2300Trabalhador trabalhadorField;
    private S2300InfoTSVInicio infoTSVInicioField;

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

    public IdeEventoNaoPeriodico ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    public S2300Trabalhador trabalhador
    {
        get => trabalhadorField;
        set
        {
            trabalhadorField = value;
            RaisePropertyChanged(nameof(trabalhador));
        }
    }

    public S2300InfoTSVInicio infoTSVInicio
    {
        get => infoTSVInicioField;
        set
        {
            infoTSVInicioField = value;
            RaisePropertyChanged(nameof(infoTSVInicio));
        }
    }
}

/// <exclude />
public partial class S2300Trabalhador : ESocialBindableObject
{
    private string cpfTrabField;
    private string nmTrabField;
    private Sexo sexoField;
    private RacaCor racaCorField;
    private EstadoCivil? estCivField;
    private GrauInstrucao grauInstrField;
    private string nmSocField;
    private S2300Nascimento nascimentoField;
    private S2300Endereco enderecoField;
    private S2300TrabImig trabImigField;
    private S2300InfoDeficiencia infoDeficienciaField;
    private System.Collections.Generic.List<S2300Dependente> dependenteField;
    private S2300Contato contatoField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }

    public string nmTrab
    {
        get => nmTrabField;
        set
        {
            nmTrabField = value;
            RaisePropertyChanged(nameof(nmTrab));
        }
    }

    public Sexo sexo
    {
        get => sexoField;
        set
        {
            sexoField = value;
            RaisePropertyChanged(nameof(sexo));
        }
    }

    public RacaCor racaCor
    {
        get => racaCorField;
        set
        {
            racaCorField = value;
            RaisePropertyChanged(nameof(racaCor));
        }
    }

    public EstadoCivil estCiv
    {
        get => estCivField.GetValueOrDefault();
        set
        {
            estCivField = value;
            RaisePropertyChanged(nameof(estCiv));
        }
    }

    public bool ShouldSerializeestCiv()
        => estCivField.HasValue;

    public GrauInstrucao grauInstr
    {
        get => grauInstrField;
        set
        {
            grauInstrField = value;
            RaisePropertyChanged(nameof(grauInstr));
        }
    }

    public string nmSoc
    {
        get => nmSocField;
        set
        {
            nmSocField = value;
            RaisePropertyChanged(nameof(nmSoc));
        }
    }

    public S2300Nascimento nascimento
    {
        get => nascimentoField;
        set
        {
            nascimentoField = value;
            RaisePropertyChanged(nameof(nascimento));
        }
    }

    public S2300Endereco endereco
    {
        get => enderecoField;
        set
        {
            enderecoField = value;
            RaisePropertyChanged(nameof(endereco));
        }
    }

    public S2300TrabImig trabImig
    {
        get => trabImigField;
        set
        {
            trabImigField = value;
            RaisePropertyChanged(nameof(trabImig));
        }
    }

    public S2300InfoDeficiencia infoDeficiencia
    {
        get => infoDeficienciaField;
        set
        {
            infoDeficienciaField = value;
            RaisePropertyChanged(nameof(infoDeficiencia));
        }
    }

    [XmlElement("dependente")]
    public System.Collections.Generic.List<S2300Dependente> dependente
    {
        get => dependenteField;
        set
        {
            dependenteField = value;
            RaisePropertyChanged(nameof(dependente));
        }
    }

    public S2300Contato contato
    {
        get => contatoField;
        set
        {
            contatoField = value;
            RaisePropertyChanged(nameof(contato));
        }
    }
}

/// <exclude />
public partial class S2300Nascimento : ESocialBindableObject
{
    private DateTime dtNasctoField;
    private string paisNasctoField;
    private string paisNacField;

    [XmlElement(DataType = "date")]
    public DateTime dtNascto
    {
        get => dtNasctoField;
        set
        {
            dtNasctoField = value;
            RaisePropertyChanged(nameof(dtNascto));
        }
    }

    public string paisNascto
    {
        get => paisNasctoField;
        set
        {
            paisNasctoField = value;
            RaisePropertyChanged(nameof(paisNascto));
        }
    }

    public string paisNac
    {
        get => paisNacField;
        set
        {
            paisNacField = value;
            RaisePropertyChanged(nameof(paisNac));
        }
    }
}

/// <exclude />
public partial class S2300Endereco : ESocialBindableObject
{
    private EnderecoBrasileiro brasilField;
    private S2300EnderecoExterior exteriorField;

    public EnderecoBrasileiro brasil
    {
        get => brasilField;
        set
        {
            brasilField = value;
            RaisePropertyChanged(nameof(brasil));
        }
    }

    public S2300EnderecoExterior exterior
    {
        get => exteriorField;
        set
        {
            exteriorField = value;
            RaisePropertyChanged(nameof(exterior));
        }
    }
}


/// <exclude />
public partial class S2300EnderecoExterior : ESocialBindableObject
{
    private string paisResidField;
    private string dscLogradField;
    private string nrLogradField;
    private string complementoField;
    private string bairroField;
    private string nmCidField;
    private string codPostalField;

    public string paisResid
    {
        get => paisResidField;
        set
        {
            paisResidField = value;
            RaisePropertyChanged(nameof(paisResid));
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

    public string complemento
    {
        get => complementoField;
        set
        {
            complementoField = value;
            RaisePropertyChanged(nameof(complemento));
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

    public string nmCid
    {
        get => nmCidField;
        set
        {
            nmCidField = value;
            RaisePropertyChanged(nameof(nmCid));
        }
    }

    public string codPostal
    {
        get => codPostalField;
        set
        {
            codPostalField = value;
            RaisePropertyChanged(nameof(codPostal));
        }
    }
}

/// <exclude />
public partial class S2300TrabImig : ESocialBindableObject
{
    private sbyte? tmpResidField;
    private sbyte condIngField;

    public sbyte tmpResid
    {
        get => tmpResidField.GetValueOrDefault();
        set
        {
            tmpResidField = value;
            RaisePropertyChanged(nameof(tmpResid));
        }
    }
    
    public bool ShouldSerializetmpResid()
        => tmpResidField.HasValue;

    public sbyte condIng
    {
        get => condIngField;
        set
        {
            condIngField = value;
            RaisePropertyChanged(nameof(condIng));
        }
    }
}

/// <exclude />
public partial class S2300InfoDeficiencia : ESocialBindableObject
{
    private SimNaoString defFisicaField = SimNaoString.Nao;
    private SimNaoString defVisualField = SimNaoString.Nao;
    private SimNaoString defAuditivaField = SimNaoString.Nao;
    private SimNaoString defMentalField = SimNaoString.Nao;
    private SimNaoString defIntelectualField = SimNaoString.Nao;
    private SimNaoString reabReadapField = SimNaoString.Nao;
    private string observacaoField;

    public SimNaoString defFisica
    {
        get => defFisicaField;
        set
        {
            defFisicaField = value;
            RaisePropertyChanged(nameof(defFisica));
        }
    }

    public SimNaoString defVisual
    {
        get => defVisualField;
        set
        {
            defVisualField = value;
            RaisePropertyChanged(nameof(defVisual));
        }
    }

    public SimNaoString defAuditiva
    {
        get => defAuditivaField;
        set
        {
            defAuditivaField = value;
            RaisePropertyChanged(nameof(defAuditiva));
        }
    }

    public SimNaoString defMental
    {
        get => defMentalField;
        set
        {
            defMentalField = value;
            RaisePropertyChanged(nameof(defMental));
        }
    }

    public SimNaoString defIntelectual
    {
        get => defIntelectualField;
        set
        {
            defIntelectualField = value;
            RaisePropertyChanged(nameof(defIntelectual));
        }
    }

    public SimNaoString reabReadap
    {
        get => reabReadapField;
        set
        {
            reabReadapField = value;
            RaisePropertyChanged(nameof(reabReadap));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

/// <exclude />
public partial class S2300Dependente : ESocialBindableObject
{
    private string tpDepField;
    private string nmDepField;
    private DateTime dtNasctoField;
    private string cpfDepField;
    private SimNaoString depIRRFField = SimNaoString.Nao;
    private SimNaoString depSFField = SimNaoString.Nao;
    private SimNaoString incTrabField = SimNaoString.Nao;
    private string descrDepField;

    public string tpDep
    {
        get => tpDepField;
        set
        {
            tpDepField = value;
            RaisePropertyChanged(nameof(tpDep));
        }
    }

    public string nmDep
    {
        get => nmDepField;
        set
        {
            nmDepField = value;
            RaisePropertyChanged(nameof(nmDep));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtNascto
    {
        get => dtNasctoField;
        set
        {
            dtNasctoField = value;
            RaisePropertyChanged(nameof(dtNascto));
        }
    }

    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(cpfDep));
        }
    }

    public SimNaoString depIRRF
    {
        get => depIRRFField;
        set
        {
            depIRRFField = value;
            RaisePropertyChanged(nameof(depIRRF));
        }
    }

    public SimNaoString depSF
    {
        get => depSFField;
        set
        {
            depSFField = value;
            RaisePropertyChanged(nameof(depSF));
        }
    }

    public SimNaoString incTrab
    {
        get => incTrabField;
        set
        {
            incTrabField = value;
            RaisePropertyChanged(nameof(incTrab));
        }
    }

    public string descrDep
    {
        get => descrDepField;
        set
        {
            descrDepField = value;
            RaisePropertyChanged(nameof(descrDep));
        }
    }
}

/// <exclude />
public partial class S2300Contato : ESocialBindableObject
{
    private string fonePrincField;
    private string emailPrincField;

    public string fonePrinc
    {
        get => fonePrincField;
        set
        {
            fonePrincField = value;
            RaisePropertyChanged(nameof(fonePrinc));
        }
    }

    public string emailPrinc
    {
        get => emailPrincField;
        set
        {
            emailPrincField = value;
            RaisePropertyChanged(nameof(emailPrinc));
        }
    }
}

/// <exclude />
public partial class S2300InfoTSVInicio : ESocialBindableObject
{
    private SimNaoString cadIniField = SimNaoString.Nao;
    private string matriculaField;
    private string codCategField;
    private DateTime dtInicioField;
    private string nrProcTrabField;
    private NaturezaAtividade? natAtividadeField;
    private S2300InfoComplementares infoComplementaresField;
    private S2300MudancaCPF mudancaCPFField;
    private S2300Afastamento afastamentoField;
    private S2300Termino terminoField;

    public SimNaoString cadIni
    {
        get => cadIniField;
        set
        {
            cadIniField = value;
            RaisePropertyChanged(nameof(cadIni));
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

    [XmlElement(DataType = "date")]
    public DateTime dtInicio
    {
        get => dtInicioField;
        set
        {
            dtInicioField = value;
            RaisePropertyChanged(nameof(dtInicio));
        }
    }

    public string nrProcTrab
    {
        get => nrProcTrabField;
        set
        {
            nrProcTrabField = value;
            RaisePropertyChanged(nameof(nrProcTrab));
        }
    }

    public NaturezaAtividade natAtividade
    {
        get => natAtividadeField.GetValueOrDefault();
        set
        {
            natAtividadeField = value;
            RaisePropertyChanged(nameof(natAtividade));
        }
    }

    public bool ShouldSerializenatAtividade()
        => natAtividadeField.HasValue;

    public S2300InfoComplementares infoComplementares
    {
        get => infoComplementaresField;
        set
        {
            infoComplementaresField = value;
            RaisePropertyChanged(nameof(infoComplementares));
        }
    }

    public S2300MudancaCPF mudancaCPF
    {
        get => mudancaCPFField;
        set
        {
            mudancaCPFField = value;
            RaisePropertyChanged(nameof(mudancaCPF));
        }
    }

    public S2300Afastamento afastamento
    {
        get => afastamentoField;
        set
        {
            afastamentoField = value;
            RaisePropertyChanged(nameof(afastamento));
        }
    }

    public S2300Termino termino
    {
        get => terminoField;
        set
        {
            terminoField = value;
            RaisePropertyChanged(nameof(termino));
        }
    }
}

/// <exclude />
public partial class S2300InfoComplementares : ESocialBindableObject
{
    private S2300CargoFuncao cargoFuncaoField;
    private S2300Remuneracao remuneracaoField;
    private S2300FGTS fGTSField;
    private S2300InfoDirigenteSindical infoDirigenteSindicalField;
    private S2300InfoTrabCedido infoTrabCedidoField;
    private S2300InfoMandElet infoMandEletField;
    private S2300InfoEstagiario infoEstagiarioField;
    private S2300LocalTrabalho localTrabGeralField;

    public S2300CargoFuncao cargoFuncao
    {
        get => cargoFuncaoField;
        set
        {
            cargoFuncaoField = value;
            RaisePropertyChanged(nameof(cargoFuncao));
        }
    }

    public S2300Remuneracao remuneracao
    {
        get => remuneracaoField;
        set
        {
            remuneracaoField = value;
            RaisePropertyChanged(nameof(remuneracao));
        }
    }

    public S2300FGTS FGTS
    {
        get => fGTSField;
        set
        {
            fGTSField = value;
            RaisePropertyChanged(nameof(FGTS));
        }
    }

    public S2300InfoDirigenteSindical infoDirigenteSindical
    {
        get => infoDirigenteSindicalField;
        set
        {
            infoDirigenteSindicalField = value;
            RaisePropertyChanged(nameof(infoDirigenteSindical));
        }
    }

    public S2300InfoTrabCedido infoTrabCedido
    {
        get => infoTrabCedidoField;
        set
        {
            infoTrabCedidoField = value;
            RaisePropertyChanged(nameof(infoTrabCedido));
        }
    }

    public S2300InfoMandElet infoMandElet
    {
        get => infoMandEletField;
        set
        {
            infoMandEletField = value;
            RaisePropertyChanged(nameof(infoMandElet));
        }
    }

    public S2300InfoEstagiario infoEstagiario
    {
        get => infoEstagiarioField;
        set
        {
            infoEstagiarioField = value;
            RaisePropertyChanged(nameof(infoEstagiario));
        }
    }

    public S2300LocalTrabalho localTrabGeral
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
public partial class S2300CargoFuncao : ESocialBindableObject
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
public partial class S2300Remuneracao : ESocialBindableObject
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
public partial class S2300FGTS : ESocialBindableObject
{
    private DateTime dtOpcFGTSField;

    [XmlElement(DataType = "date")]
    public DateTime dtOpcFGTS
    {
        get => dtOpcFGTSField;
        set
        {
            dtOpcFGTSField = value;
            RaisePropertyChanged(nameof(dtOpcFGTS));
        }
    }
}

/// <exclude />
public partial class S2300InfoDirigenteSindical : ESocialBindableObject
{
    private string categOrigField;
    private sbyte? tpInscField;
    private string nrInscField;
    private DateTime? dtAdmOrigField;
    private string matricOrigField;
    private VinculoTrabalhista? tpRegTrabField;
    private RegimePrevidenciario tpRegPrevField;

    public string categOrig
    {
        get => categOrigField;
        set
        {
            categOrigField = value;
            RaisePropertyChanged(nameof(categOrig));
        }
    }

    public sbyte tpInsc
    {
        get => tpInscField.GetValueOrDefault();
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    public bool ShouldSerializetpInsc()
        => tpInscField.HasValue;

    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtAdmOrig
    {
        get => dtAdmOrigField.GetValueOrDefault();
        set
        {
            dtAdmOrigField = value;
            RaisePropertyChanged(nameof(dtAdmOrig));
        }
    }

    public bool ShouldSerializedtAdmOrig()
        => dtAdmOrigField.HasValue;

    public string matricOrig
    {
        get => matricOrigField;
        set
        {
            matricOrigField = value;
            RaisePropertyChanged(nameof(matricOrig));
        }
    }

    public VinculoTrabalhista tpRegTrab
    {
        get => tpRegTrabField.GetValueOrDefault();
        set
        {
            tpRegTrabField = value;
            RaisePropertyChanged(nameof(tpRegTrab));
        }
    }

    public bool ShouldSerializetpRegTrab()
        => tpRegTrabField.HasValue;

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
public partial class S2300InfoTrabCedido : ESocialBindableObject
{
    private string categOrigField;
    private string cnpjCedntField;
    private string matricCedField;
    private DateTime dtAdmCedField;
    private VinculoTrabalhista tpRegTrabField;
    private RegimePrevidenciario tpRegPrevField;

    public string categOrig
    {
        get => categOrigField;
        set
        {
            categOrigField = value;
            RaisePropertyChanged(nameof(categOrig));
        }
    }

    public string cnpjCednt
    {
        get => cnpjCedntField;
        set
        {
            cnpjCedntField = value;
            RaisePropertyChanged(nameof(cnpjCednt));
        }
    }

    public string matricCed
    {
        get => matricCedField;
        set
        {
            matricCedField = value;
            RaisePropertyChanged(nameof(matricCed));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtAdmCed
    {
        get => dtAdmCedField;
        set
        {
            dtAdmCedField = value;
            RaisePropertyChanged(nameof(dtAdmCed));
        }
    }

    public VinculoTrabalhista tpRegTrab
    {
        get => tpRegTrabField;
        set
        {
            tpRegTrabField = value;
            RaisePropertyChanged(nameof(tpRegTrab));
        }
    }

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
public partial class S2300InfoMandElet : ESocialBindableObject
{
    private string categOrigField;
    private string cnpjOrigField;
    private string matricOrigField;
    private DateTime dtExercOrigField;
    private SimNaoString indRemunCargoField = SimNaoString.Nao;
    private VinculoTrabalhista? tpRegTrabField;
    private RegimePrevidenciario tpRegPrevField;

    public string categOrig
    {
        get => categOrigField;
        set
        {
            categOrigField = value;
            RaisePropertyChanged(nameof(categOrig));
        }
    }

    public string cnpjOrig
    {
        get => cnpjOrigField;
        set
        {
            cnpjOrigField = value;
            RaisePropertyChanged(nameof(cnpjOrig));
        }
    }

    public string matricOrig
    {
        get => matricOrigField;
        set
        {
            matricOrigField = value;
            RaisePropertyChanged(nameof(matricOrig));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExercOrig
    {
        get => dtExercOrigField;
        set
        {
            dtExercOrigField = value;
            RaisePropertyChanged(nameof(dtExercOrig));
        }
    }

    public SimNaoString indRemunCargo
    {
        get => indRemunCargoField;
        set
        {
            indRemunCargoField = value;
            RaisePropertyChanged(nameof(indRemunCargo));
        }
    }

    public bool ShouldSerializeindRemunCargo()
        => true;

    public VinculoTrabalhista tpRegTrab
    {
        get => tpRegTrabField.GetValueOrDefault();
        set
        {
            tpRegTrabField = value;
            RaisePropertyChanged(nameof(tpRegTrab));
        }
    }

    public bool ShouldSerializetpRegTrab()
        => tpRegTrabField.HasValue;

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
public partial class S2300InfoEstagiario : ESocialBindableObject
{
    private string natEstagioField;
    private sbyte nivEstagioField;
    private string areaAtuacaoField;
    private string nrApolField;
    private DateTime dtPrevTermField;
    private S2300InstEnsino instEnsinoField;
    private S2300AgeIntegracao ageIntegracaoField;
    private S2300SupervisorEstagio supervisorEstagioField;

    public string natEstagio
    {
        get => natEstagioField;
        set
        {
            natEstagioField = value;
            RaisePropertyChanged(nameof(natEstagio));
        }
    }

    public sbyte nivEstagio
    {
        get => nivEstagioField;
        set
        {
            nivEstagioField = value;
            RaisePropertyChanged(nameof(nivEstagio));
        }
    }

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

    public S2300InstEnsino instEnsino
    {
        get => instEnsinoField;
        set
        {
            instEnsinoField = value;
            RaisePropertyChanged(nameof(instEnsino));
        }
    }

    public S2300AgeIntegracao ageIntegracao
    {
        get => ageIntegracaoField;
        set
        {
            ageIntegracaoField = value;
            RaisePropertyChanged(nameof(ageIntegracao));
        }
    }

    public S2300SupervisorEstagio supervisorEstagio
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
public partial class S2300InstEnsino : ESocialBindableObject
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
public partial class S2300AgeIntegracao : ESocialBindableObject
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
public partial class S2300SupervisorEstagio : ESocialBindableObject
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
public partial class S2300LocalTrabalho : ESocialBindableObject
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

/// <exclude />
public partial class S2300MudancaCPF : ESocialBindableObject
{
    private string cpfAntField;
    private string matricAntField;
    private DateTime dtAltCPFField;
    private string observacaoField;

    public string cpfAnt
    {
        get => cpfAntField;
        set
        {
            cpfAntField = value;
            RaisePropertyChanged(nameof(cpfAnt));
        }
    }

    public string matricAnt
    {
        get => matricAntField;
        set
        {
            matricAntField = value;
            RaisePropertyChanged(nameof(matricAnt));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtAltCPF
    {
        get => dtAltCPFField;
        set
        {
            dtAltCPFField = value;
            RaisePropertyChanged(nameof(dtAltCPF));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

/// <exclude />
public partial class S2300Afastamento : ESocialBindableObject
{
    private DateTime dtIniAfastField;
    private string codMotAfastField;

    [XmlElement(DataType = "date")]
    public DateTime dtIniAfast
    {
        get => dtIniAfastField;
        set
        {
            dtIniAfastField = value;
            RaisePropertyChanged(nameof(dtIniAfast));
        }
    }

    public string codMotAfast
    {
        get => codMotAfastField;
        set
        {
            codMotAfastField = value;
            RaisePropertyChanged(nameof(codMotAfast));
        }
    }
}

/// <exclude />
public partial class S2300Termino : ESocialBindableObject
{
    private DateTime dtTermField;

    [XmlElement(DataType = "date")]
    public DateTime dtTerm
    {
        get => dtTermField;
        set
        {
            dtTermField = value;
            RaisePropertyChanged(nameof(dtTerm));
        }
    }
}
