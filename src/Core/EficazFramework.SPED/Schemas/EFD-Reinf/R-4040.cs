namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Pagamentos/créditos a beneficiários não identificados
/// </summary>
[System.SerializableAttribute()]
public partial class R4040 : Evento, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtBenefNId evtBenefNIdField;
    private SignatureType signatureField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public ReinfEvtBenefNId evtBenefNId
    {
        get => evtBenefNIdField;
        set
        {
            evtBenefNIdField = value;
            RaisePropertyChanged("evtBenefNId");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.w3.org/2000/09/xmldsig#", Order=1)]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
        }
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "ReinfEvtBenefNId";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // Evento Members
    public override void GeraEventoID()
    {
        evtBenefNId.id = string.Format("ID{0}{1}{2}", (int)(evtBenefNId?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtBenefNId?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtBenefNId.ideContri.nrInsc;
    }


    // PropertyChanged Members
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R4040), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4040PagtoBenefNaoIdentificado/{Versao}", IsNullable = false });
    }
}

/// <exclude />
public partial class ReinfEvtBenefNId : object, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtIdeEvento_R40xx ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private ReinfEvtBenefNIdIdeEstab ideEstabField;
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public ReinfEvtIdeEvento_R40xx ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public IdentificacaoContribuinte ideContri
    {
        get => ideContriField;
        set
        {
            ideContriField = value;
            RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public ReinfEvtBenefNIdIdeEstab ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
    public string id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged("id");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtBenefNIdIdeEstab : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private List<ReinfEvtBenefNIdIdeEstabIdeNat> ideNatField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public PersonalidadeJuridica tpInscEstab
    {
        get => tpInscEstabField;
        set
        {
            tpInscEstabField = value;
            RaisePropertyChanged("tpInscEstab");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public string nrInscEstab
    {
        get => nrInscEstabField;
        set
        {
            nrInscEstabField = value;
            RaisePropertyChanged("nrInscEstab");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideNat", Order=2)]
    public List<ReinfEvtBenefNIdIdeEstabIdeNat> ideNat
    {
        get => ideNatField;
        set
        {
            ideNatField = value;
            RaisePropertyChanged("ideNat");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtBenefNIdIdeEstabIdeNat : object, System.ComponentModel.INotifyPropertyChanged {
    
    private int natRendField;
    private List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto> infoPgtoField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public int natRend
    {
        get => natRendField;
        set
        {
            natRendField = value;
            RaisePropertyChanged("natRend");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoPgto", Order=1)]
    public List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto> infoPgto
    {
        get => infoPgtoField;
        set
        {
            infoPgtoField = value;
            RaisePropertyChanged("infoPgto");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtBenefNIdIdeEstabIdeNatInfoPgto : object, System.ComponentModel.INotifyPropertyChanged {
    
    private System.DateTime dtFGField;
    private string vlrLiqField;
    private string vlrBaseIRField;
    private string vlrIRField;
    private string descrField;
    private List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgtoInfoProcRet> infoProcRetField;

    /// <summary>
    /// Informar a data do fato gerador, no formato AAAA-MM-DD. <br/><br/>
    /// <b>Validação: </b>A data informada deve estar compreendida no período de apuração 
    /// ao qual se refere o arquivo, conforme informado em(perApur}, no formato AAAA-MM-DD.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType ="date", Order=0)]
    public System.DateTime DataFatoGerador
    {
        get => dtFGField;
        set
        {
            dtFGField = value;
            RaisePropertyChanged("DataFatoGerador");
        }
    }

    /// <summary>
    /// Valor líquido do Pagamento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public string vlrLiq
    {
        get => vlrLiqField;
        set
        {
            vlrLiqField = value;
            RaisePropertyChanged("vlrLiq");
        }
    }

    /// <summary>
    /// Valor reajustado, considerado como valor da base de cálculo do IRRF.<br/><br/>
    /// <b>Validação: </b> Deve corresponder a (<see cref="vlrLiq"/> / 0,65).
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public string vlrBaseIR
    {
        get => vlrBaseIRField;
        set
        {
            vlrBaseIRField = value;
            RaisePropertyChanged("vlrBaseIR");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
    public string vlrIR
    {
        get => vlrIRField;
        set
        {
            vlrIRField = value;
            RaisePropertyChanged("vlrIR");
        }
    }

    /// <summary>
    /// Descrição do Pagamento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
    public string descr
    {
        get => descrField;
        set
        {
            descrField = value;
            RaisePropertyChanged("descr");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order=5)]
    public List<ReinfEvtBenefNIdIdeEstabIdeNatInfoPgtoInfoProcRet> infoProcRet
    {
        get => infoProcRetField;
        set
        {
            infoProcRetField = value;
            RaisePropertyChanged("infoProcRet");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtBenefNIdIdeEstabIdeNatInfoPgtoInfoProcRet : object, System.ComponentModel.INotifyPropertyChanged {
    
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private string vlrBaseSuspIRField;
    private string vlrNIRField;
    private string vlrDepIRField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public TipoProcesso tpProcRet
    {
        get => tpProcRetField;
        set
        {
            tpProcRetField = value;
            RaisePropertyChanged("tpProcRet");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public string nrProcRet
    {
        get => nrProcRetField;
        set
        {
            nrProcRetField = value;
            RaisePropertyChanged("nrProcRet");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged("codSusp");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
    public string vlrBaseSuspIR
    {
        get => vlrBaseSuspIRField;
        set
        {
            vlrBaseSuspIRField = value;
            RaisePropertyChanged("vlrBaseSuspIR");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
    public string vlrNIR
    {
        get => vlrNIRField;
        set
        {
            vlrNIRField = value;
            RaisePropertyChanged("vlrNIR");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=5)]
    public string vlrDepIR
    {
        get => vlrDepIRField;
        set
        {
            vlrDepIRField = value;
            RaisePropertyChanged("vlrDepIR");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
