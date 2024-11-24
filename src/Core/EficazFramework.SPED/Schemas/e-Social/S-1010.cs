namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public partial class S1010 : Evento
{
    private S1010Rubrica evtTabRubricaField;
    private SignatureType signatureField;

    public S1010Rubrica evtTabRubrica
    {
        get => evtTabRubricaField;
        set
        {
            evtTabRubricaField = value;
            RaisePropertyChanged(nameof(evtTabRubrica));
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


    // Evento Members
    /// <exclude/>
    public override void GeraEventoID()
    {
        evtTabRubricaField.Id = string.Format("ID{0}{1}{2}", (int)(evtTabRubricaField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabRubricaField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
    }

    /// <exclude/>
    public override string ContribuinteCNPJ()
    {
        return evtTabRubricaField.ideEmpregador.nrInsc;
    }


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtTabRubrica";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    //public override XmlSerializer DefineSerializer(bool includeNamespace = true)
    //{
    //    if (includeNamespace)
    //        return new (typeof(S1010), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtTabRubrica/{Versao}", IsNullable = false });

    //    return new (typeof(S1010), new XmlRootAttribute(Evento.root) { IsNullable = false });
    //}        
}

/// <exclude />
public partial class S1010Rubrica : ESocialBindableObject
{
    private IdentificacaoCadastro ideEventoField;
    private Empregador ideEmpregadorField;
    private S1010InfoRubrica infoRubricaField;
    private string idField;

    public IdentificacaoCadastro ideEvento
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

    public S1010InfoRubrica infoRubrica
    {
        get => infoRubricaField;
        set
        {
            infoRubricaField = value;
            RaisePropertyChanged(nameof(infoRubrica));
        }
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
}

/// <exclude />
public partial class S1010InfoRubrica : ESocialBindableObject
{
    private object itemField;

    [XmlElement("alteracao", typeof(S1010Alteracao))]
    [XmlElement("exclusao", typeof(S1010Exclusao))]
    [XmlElement("inclusao", typeof(S1010Inclusao))]
    public object Item
    {
        get => itemField;
        set
        {
            itemField = value;
            RaisePropertyChanged(nameof(Item));
        }
    }
}

/// <exclude />
public partial class S1010Inclusao : ESocialBindableObject
{
    private S1010IdentificacaoRubrica ideRubricaField;
    private S1010DadosRubrica dadosRubricaField;

    public S1010IdentificacaoRubrica ideRubrica
    {
        get => ideRubricaField;
        set
        {
            ideRubricaField = value;
            RaisePropertyChanged(nameof(ideRubrica));
        }
    }

    public S1010DadosRubrica dadosRubrica
    {
        get => dadosRubricaField;
        set
        {
            dadosRubricaField = value;
            RaisePropertyChanged(nameof(dadosRubrica));
        }
    }
}

/// <exclude />
public partial class S1010Alteracao : ESocialBindableObject
{
    private S1010IdentificacaoRubrica ideRubricaField;
    private S1010DadosRubrica dadosRubricaField;
    private IdePeriodo novaValidadeField;

    public S1010IdentificacaoRubrica ideRubrica
    {
        get => ideRubricaField;
        set
        {
            ideRubricaField = value;
            RaisePropertyChanged(nameof(ideRubrica));
        }
    }

    public S1010DadosRubrica dadosRubrica
    {
        get => dadosRubricaField;
        set
        {
            dadosRubricaField = value;
            RaisePropertyChanged(nameof(dadosRubrica));
        }
    }

    public IdePeriodo novaValidade
    {
        get => novaValidadeField;
        set
        {
            novaValidadeField = value;
            RaisePropertyChanged(nameof(novaValidade));
        }
    }
}

/// <exclude />
public partial class S1010Exclusao : ESocialBindableObject
{
    private S1010IdentificacaoRubrica ideRubricaField;

    public S1010IdentificacaoRubrica ideRubrica
    {
        get => ideRubricaField;
        set
        {
            ideRubricaField = value;
            RaisePropertyChanged(nameof(ideRubrica));
        }
    }
}

/// <exclude />
public partial class S1010IdentificacaoRubrica : ESocialBindableObject
{
    private string codRubrField;
    private string ideTabRubrField;
    private string iniValidField;
    private string fimValidField;

    public string codRubr
    {
        get => codRubrField;
        set
        {
            codRubrField = value;
            RaisePropertyChanged(nameof(codRubr));
        }
    }

    public string ideTabRubr
    {
        get => ideTabRubrField;
        set
        {
            ideTabRubrField = value;
            RaisePropertyChanged(nameof(ideTabRubr));
        }
    }

    public string iniValid
    {
        get => iniValidField;
        set
        {
            iniValidField = value;
            RaisePropertyChanged(nameof(iniValid));
        }
    }

    public string fimValid
    {
        get => fimValidField;
        set
        {
            fimValidField = value;
            RaisePropertyChanged(nameof(fimValid));
        }
    }
}

/// <exclude />
public partial class S1010DadosRubrica : ESocialBindableObject
{
    private string dscRubrField;
    private int? natRubrField;
    private NaturezaRubrica tpRubrField = NaturezaRubrica.Outros;
    private string codIncCPField;
    private string codIncIRRFField;
    private string codIncFGTSField;
    private string codIncCPRPField;
    private SimNaoString tetoRemunField = SimNaoString.Nao;
    private string observacaoField;
    private List<S1010ProcessoCP> ideProcessoCPField;
    private List<ProcessoAdmOuJud> ideProcessoIRRFField;
    private List<ProcessoAdmOuJud> ideProcessoFGTSField;

    public string dscRubr
    {
        get => dscRubrField;
        set
        {
            dscRubrField = value;
            RaisePropertyChanged(nameof(dscRubr));
        }
    }

    [XmlElement()]
    public int? natRubr
    {
        get => natRubrField;
        set
        {
            natRubrField = value;
            RaisePropertyChanged(nameof(natRubr));
        }
    }

    public bool ShouldSerializenatRubr()
        => natRubr.HasValue;

    public NaturezaRubrica tpRubr
    {
        get => tpRubrField;
        set
        {
            tpRubrField = value;
            RaisePropertyChanged(nameof(tpRubr));
        }
    }

    public string codIncCP
    {
        get => codIncCPField;
        set
        {
            codIncCPField = value;
            RaisePropertyChanged(nameof(codIncCP));
        }
    }

    public string codIncIRRF
    {
        get => codIncIRRFField;
        set
        {
            codIncIRRFField = value;
            RaisePropertyChanged(nameof(codIncIRRF));
        }
    }

    public string codIncFGTS
    {
        get => codIncFGTSField;
        set
        {
            codIncFGTSField = value;
            RaisePropertyChanged(nameof(codIncFGTS));
        }
    }

    public string codIncCPRP
    {
        get => codIncCPRPField;
        set
        {
            codIncCPRPField = value;
            RaisePropertyChanged(nameof(codIncCPRP));
        }
    }

    public SimNaoString tetoRemun
    {
        get => tetoRemunField;
        set
        {
            tetoRemunField = value;
            RaisePropertyChanged(nameof(tetoRemun));
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

    [XmlElement("ideProcessoCP")]
    public List<S1010ProcessoCP> ideProcessoCP
    {
        get => ideProcessoCPField;
        set
        {
            ideProcessoCPField = value;
            RaisePropertyChanged(nameof(ideProcessoCP));
        }
    }

    [XmlElement("ideProcessoIRRF")]
    public List<ProcessoAdmOuJud> ideProcessoIRRF
    {
        get => ideProcessoIRRFField;
        set
        {
            ideProcessoIRRFField = value;
            RaisePropertyChanged(nameof(ideProcessoIRRF));
        }
    }

    [XmlElement("ideProcessoFGTS")]
    public List<ProcessoAdmOuJud> ideProcessoFGTS
    {
        get => ideProcessoFGTSField;
        set
        {
            ideProcessoFGTSField = value;
            RaisePropertyChanged(nameof(ideProcessoFGTS));
        }
    }
}

/// <exclude />
public partial class S1010ProcessoCP : ProcessoAdmOuJud
{
    private DescisaoSentencaCP extDecisaoField = DescisaoSentencaCP.CPP;

    [XmlElement(Order = 2)]
    public DescisaoSentencaCP extDecisao
    {
        get => extDecisaoField;
        set
        {
            extDecisaoField = value;
            RaisePropertyChanged(nameof(extDecisao));
        }
    }
}