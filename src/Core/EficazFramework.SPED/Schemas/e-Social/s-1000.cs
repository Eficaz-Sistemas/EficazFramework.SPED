namespace EficazFramework.SPED.Schemas.eSocial;


[Serializable()]
public partial class S1000 : Evento
{
    private S1000InfoEmpregador evtInfoEmpregadorField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public S1000InfoEmpregador evtInfoEmpregador
    {
        get => evtInfoEmpregadorField;
        set
        {
            evtInfoEmpregadorField = value;
            RaisePropertyChanged(nameof(evtInfoEmpregador));
        }
    }

    /// <remarks/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
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
        => evtInfoEmpregadorField.Id = string.Format("ID{0}{1}{2}", (int)(evtInfoEmpregadorField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtInfoEmpregadorField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ() 
        => evtInfoEmpregadorField.ideEmpregador.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtInfoEmpregador";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(S1000), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtInfoEmpregador/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class S1000InfoEmpregador : ESocialBindableObject
{
    private IdentificacaoCadastro ideEventoField;
    private Empregador ideEmpregadorField;
    private S1000InfoEmpregadorAcao infoEmpregadorField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoCadastro ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged("ideEmpregador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public S1000InfoEmpregadorAcao infoEmpregador
    {
        get => infoEmpregadorField;
        set
        {
            infoEmpregadorField = value;
            RaisePropertyChanged("infoEmpregador");
        }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged("Id");
        }
    }
}

/// <exclude />
public partial class S1000InfoEmpregadorAcao : ESocialBindableObject
{
    private object itemField;

    /// <remarks/>
    [XmlElement("alteracao", typeof(S1000Alteracao), Order = 0)]
    [XmlElement("exclusao", typeof(S1000Exclusao), Order = 0)]
    [XmlElement("inclusao", typeof(S1000Inclusao), Order = 0)]
    public object Item
    {
        get => itemField;
        set
        {
            itemField = value;
            RaisePropertyChanged("Item");
        }
    }
}

/// <exclude />
public partial class S1000Inclusao : ESocialBindableObject
{
    private IdePeriodo idePeriodoField;
    private S1000InfoCadastro infoCadastroField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdePeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public S1000InfoCadastro infoCadastro
    {
        get => infoCadastroField;
        set
        {
            infoCadastroField = value;
            RaisePropertyChanged("infoCadastro");
        }
    }
}

/// <exclude />
public partial class S1000Alteracao : ESocialBindableObject
{
    private IdePeriodo idePeriodoField;
    private S1000InfoCadastro infoCadastroField;
    private IdePeriodo novaValidadeField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdePeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public S1000InfoCadastro infoCadastro
    {
        get => infoCadastroField;
        set
        {
            infoCadastroField = value;
            RaisePropertyChanged("infoCadastro");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IdePeriodo novaValidade
    {
        get => novaValidadeField;
        set
        {
            novaValidadeField = value;
            RaisePropertyChanged("novaValidade");
        }
    }
}

/// <exclude />
public partial class S1000Exclusao : ESocialBindableObject
{
    private IdePeriodo idePeriodoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdePeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }
}

/// <exclude />
public partial class S1000InfoCadastro : ESocialBindableObject
{
    private string classTribField;
    private IndicadorCooperativa indCoopField = IndicadorCooperativa.Nao;
    private bool indCoopFieldSpecified = false;
    private SimNaoByte indConstrField = SimNaoByte.Nao;
    private bool indConstrFieldSpecified = false;
    private SimNaoByte indDesFolhaField = SimNaoByte.Nao;
    private OpcaoTributacaoPrevidenciaria indOpcCPField = OpcaoTributacaoPrevidenciaria.Comercializacao;
    private bool indOpcCPFieldSpecified = false;
    private SimNaoString indPorteField = SimNaoString.Nao;
    private SimNaoByte indOptRegEletronField = SimNaoByte.Nao;
    private string cnpjEFTField;
    private DateTime? dtTrans11096Field;
    private SimNaoString indTribFolhaPisCofinsField = SimNaoString.Nao;
    private S1000DadosIsencao dadosIsencaoField;
    private S1000InfoOrgInternacional infoOrgInternacionalField;

    [XmlElement(Order = 0)]
    public string classTrib
    {
        get => classTribField;
        set
        {
            classTribField = value;
            RaisePropertyChanged(nameof(classTrib));
        }
    }

    [XmlElement(Order = 1)]
    public IndicadorCooperativa indCoop
    {
        get => indCoopField;
        set
        {
            indCoopField = value;
            RaisePropertyChanged(nameof(indCoop));
        }
    }

    [XmlIgnore()]
    public bool indCoopSpecified
    {
        get => indCoopFieldSpecified;
        set
        {
            indCoopFieldSpecified = value;
            RaisePropertyChanged(nameof(indCoopSpecified));
        }
    }

    [XmlElement(Order = 2)]
    public SimNaoByte indConstr
    {
        get => indConstrField;
        set
        {
            indConstrField = value;
            RaisePropertyChanged(nameof(indConstr));
        }
    }

    [XmlIgnore()]
    public bool indConstrSpecified
    {
        get => indConstrFieldSpecified;
        set
        {
            indConstrFieldSpecified = value;
            RaisePropertyChanged(nameof(indConstrSpecified));
        }
    }

    [XmlElement(Order = 3)]
    public SimNaoByte indDesFolha
    {
        get => indDesFolhaField;
        set
        {
            indDesFolhaField = value;
            RaisePropertyChanged(nameof(indDesFolha));
        }
    }

    /// <summary>
    /// Indicativo da opção pelo produtor rural pela forma de tributação da contribuição previdenciária
    /// </summary>
    [XmlElement(Order = 4)]
    public OpcaoTributacaoPrevidenciaria indOpcCP
    {
        get => indOpcCPField;
        set
        {
            indOpcCPField = value;
            RaisePropertyChanged(nameof(indOpcCP));
        }
    }

    [XmlIgnore()]
    public bool indOpcCPSpecified
    {
        get => indOpcCPFieldSpecified;
        set
        {
            indOpcCPFieldSpecified = value;
            RaisePropertyChanged(nameof(indOpcCPSpecified));
        }
    }

    /// <summary>
    /// Indicativo de microempresa - ME ou empresa de pequeno porte - EPP
    /// </summary>
    [XmlElement(Order = 5)]
    public SimNaoString indPorte
    {
        get => indPorteField;
        set
        {
            indPorteField = value;
            RaisePropertyChanged(nameof(indPorte));
        }
    }

    public bool ShouldSerializeindPorte()
        => indPorte == SimNaoString.Sim;

    [XmlElement(Order = 6)]
    public SimNaoByte indOptRegEletron
    {
        get => indOptRegEletronField;
        set
        {
            indOptRegEletronField = value;
            RaisePropertyChanged(nameof(indOptRegEletron));
        }
    }

    [XmlElement(Order = 7)]
    public string cnpjEFR
    {
        get => cnpjEFTField;
        set
        {
            cnpjEFTField = value;
            RaisePropertyChanged(nameof(cnpjEFR));
        }
    }

    [XmlElement(Order = 8)]
    public DateTime? dtTrans11096
    { 
        get => dtTrans11096Field;
        set
        {
            dtTrans11096Field = value;
            RaisePropertyChanged(nameof(dtTrans11096Field));
        }
    }

    public bool ShouldSerializedtTrans11096()
        => dtTrans11096.HasValue;

    [XmlElement(Order = 9)]
    public SimNaoString indTribFolhaPisCofins
    {
        get => indTribFolhaPisCofinsField;
        set
        {
            indTribFolhaPisCofinsField = value;
            RaisePropertyChanged(nameof(indTribFolhaPisCofins));
        }
    }

    public bool ShouldSerializeindTribFolhaPisCofins()
        => indTribFolhaPisCofins == SimNaoString.Sim;

    [XmlElement(Order = 10)]
    public S1000DadosIsencao dadosIsencao
    {
        get => dadosIsencaoField;
        set
        {
            dadosIsencaoField = value;
            RaisePropertyChanged(nameof(dadosIsencao));
        }
    }


    [XmlElement(Order = 11)]
    public S1000InfoOrgInternacional infoOrgInternacional
    {
        get => infoOrgInternacionalField;
        set
        {
            infoOrgInternacionalField = value;
            RaisePropertyChanged(nameof(infoOrgInternacional));
        }
    }
}

/// <exclude />
public partial class S1000DadosIsencao : ESocialBindableObject
{
    private string ideMinLeiField;
    private string nrCertifField;
    private DateTime dtEmisCertifField;
    private DateTime dtVencCertifField;
    private string nrProtRenovField;
    private DateTime? dtProtRenovField;
    private DateTime? dtDouField;
    private int? pagDouField;

    [XmlElement(Order = 0)]
    public string ideMinLei
    {
        get => ideMinLeiField;
        set
        {
            ideMinLeiField = value;
            RaisePropertyChanged(nameof(ideMinLei));
        }
    }

    [XmlElement(Order = 1)]
    public string nrCertif
    {
        get => nrCertifField;
        set
        {
            nrCertifField = value;
            RaisePropertyChanged(nameof(nrCertif));
        }
    }

    [XmlElement(DataType = "date", Order = 2)]
    public DateTime dtEmisCertif
    {
        get => dtEmisCertifField;
        set
        {
            dtEmisCertifField = value;
            RaisePropertyChanged(nameof(dtEmisCertif));
        }
    }

    [XmlElement(DataType = "date", Order = 3)]
    public DateTime dtVencCertif
    {
        get => dtVencCertifField;
        set
        {
            dtVencCertifField = value;
            RaisePropertyChanged(nameof(dtVencCertif));
        }
    }

    [XmlElement(Order = 4)]
    public string nrProtRenov
    {
        get => nrProtRenovField;
        set
        {
            nrProtRenovField = value;
            RaisePropertyChanged(nameof(nrProtRenov));
        }
    }

    [XmlElement(DataType = "date", Order = 5)]
    public DateTime? dtProtRenov
    {
        get => dtProtRenovField;
        set
        {
            dtProtRenovField = value;
            RaisePropertyChanged(nameof(dtProtRenov));
        }
    }

    public bool ShouldSerializedtProtRenov()
        => dtProtRenov.HasValue;

    [XmlElement(DataType = "date", Order = 6)]
    public DateTime? dtDou
    {
        get => dtDouField;
        set
        {
            dtDouField = value;
            RaisePropertyChanged(nameof(dtDou));
        }
    }

    public bool ShouldSerializedtDou()
        => dtDou.HasValue;

    [XmlElement(Order = 7)]
    public int? pagDou
    {
        get => pagDouField;
        set
        {
            pagDouField = value;
            RaisePropertyChanged(nameof(pagDou));
        }
    }

    public bool ShouldSerializepagDou()
        => pagDou.HasValue;
}

/// <exclude />
public partial class S1000InfoOrgInternacional : ESocialBindableObject
{
    private sbyte indAcordoIsenMultaField;

    [XmlElement(Order = 0)]
    public sbyte indAcordoIsenMulta
    {
        get => indAcordoIsenMultaField;
        set
        {
            indAcordoIsenMultaField = value;
            RaisePropertyChanged(nameof(indAcordoIsenMulta));
        }
    }
}
