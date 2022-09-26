namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

[Serializable()]
public partial class R1000 : IEfdReinfEvt, INotifyPropertyChanged
{
    private R1000_EventoInfoContribuinte evtInfoContriField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R1000_EventoInfoContribuinte evtInfoContri
    {
        get
        {
            return evtInfoContriField;
        }

        set
        {
            evtInfoContriField = value;
            RaisePropertyChanged("evtInfoContri");
        }
    }

    /// <remarks/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }

        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
        }
    }


    // IEfdReinfEvt Members
    public override void GeraEventoID()
    {
        evtInfoContri.id = string.Format("ID{0}{1}{2}", (int)(evtInfoContriField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtInfoContriField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtInfoContri.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtInfoContri";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // PropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R1000), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/{Versao}", IsNullable = false});
    }

}


public partial class R1000_EventoInfoContribuinte : object, INotifyPropertyChanged
{
    private ReinfEvtIdeEvento ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private R1000_InfoContri infoContriField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtIdeEvento ideEvento
    {
        get
        {
            return ideEventoField;
        }

        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public ReinfEvtIdeContri ideContri
    {
        get
        {
            return ideContriField;
        }

        set
        {
            ideContriField = value;
            RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public R1000_InfoContri infoContri
    {
        get
        {
            return infoContriField;
        }

        set
        {
            infoContriField = value;
            RaisePropertyChanged("infoContri");
        }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "ID")]
    public string id
    {
        get
        {
            return idField;
        }

        set
        {
            idField = value;
            RaisePropertyChanged("id");
        }
    }


    // PropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


public partial class R1000_InfoContri : object, INotifyPropertyChanged
{
    private object itemField;

    /// <remarks/>
    [XmlElement("alteracao", typeof(R1000_Alteracao), Order = 0)]
    [XmlElement("exclusao", typeof(R1000_Exclusao), Order = 0)]
    [XmlElement("inclusao", typeof(R1000_Inclusao), Order = 0)]
    public object Item
    {
        get
        {
            return itemField;
        }

        set
        {
            itemField = value;
            RaisePropertyChanged("Item");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


// Alteração:
public partial class R1000_Alteracao : object, INotifyPropertyChanged
{
    private ReinfEvtIdePeriodo idePeriodoField;
    private R1000_InfoCadastro infoCadastroField;
    private ReinfEvtIdePeriodo novaValidadeField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtIdePeriodo idePeriodo
    {
        get
        {
            return idePeriodoField;
        }

        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public R1000_InfoCadastro infoCadastro
    {
        get
        {
            return infoCadastroField;
        }

        set
        {
            infoCadastroField = value;
            RaisePropertyChanged("infoCadastro");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtIdePeriodo novaValidade
    {
        get
        {
            return novaValidadeField;
        }

        set
        {
            novaValidadeField = value;
            RaisePropertyChanged("novaValidade");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


public partial class ReinfEvtInfoContriInfoContriAlteracaoInfoCadastroInfoEFR : object, INotifyPropertyChanged
{
    private string ideEFRField;
    private string cnpjEFRField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string ideEFR
    {
        get
        {
            return ideEFRField;
        }

        set
        {
            ideEFRField = value;
            RaisePropertyChanged("ideEFR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string cnpjEFR
    {
        get
        {
            return cnpjEFRField;
        }

        set
        {
            cnpjEFRField = value;
            RaisePropertyChanged("cnpjEFR");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


// Exclusão:
public partial class R1000_Exclusao : object, INotifyPropertyChanged
{
    private ReinfEvtIdePeriodo idePeriodoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtIdePeriodo idePeriodo
    {
        get
        {
            return idePeriodoField;
        }

        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


// Inclusão:
public partial class R1000_Inclusao : object, INotifyPropertyChanged
{
    private ReinfEvtIdePeriodo idePeriodoField;
    private R1000_InfoCadastro infoCadastroField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtIdePeriodo idePeriodo
    {
        get
        {
            return idePeriodoField;
        }

        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public R1000_InfoCadastro infoCadastro
    {
        get
        {
            return infoCadastroField;
        }

        set
        {
            infoCadastroField = value;
            RaisePropertyChanged("infoCadastro");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

public partial class ReinfEvtInfoContriInfoContriInclusaoInfoCadastroInfoEFR : object, INotifyPropertyChanged
{
    private string ideEFRField;
    private string cnpjEFRField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string ideEFR
    {
        get
        {
            return ideEFRField;
        }

        set
        {
            ideEFRField = value;
            RaisePropertyChanged("ideEFR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string cnpjEFR
    {
        get
        {
            return cnpjEFRField;
        }

        set
        {
            cnpjEFRField = value;
            RaisePropertyChanged("cnpjEFR");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


// R1000 Common:
public partial class R1000_InfoCadastro : object, INotifyPropertyChanged
{
    private string classTribField;
    private ObrigatoriedadeECD indEscrituracaoField;
    private DesoneracaoCPRB indDesoneracaoField;
    private AcordoInternacionalIsencaoMulta indAcordoIsenMultaField = AcordoInternacionalIsencaoMulta.SemAcordo;
    private SituacaoPessoaJuridica indSitPJField;
    private bool indSitPJFieldSpecified = false;
    private R1000_InfoCadastro_Contato contatoField;
    private R1000_InfoCadastro_SoftwareHouse softHouseField;
    private ReinfEvtInfoContriInfoContriInclusaoInfoCadastroInfoEFR infoEFRField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string classTrib
    {
        get
        {
            return classTribField;
        }

        set
        {
            classTribField = value;
            RaisePropertyChanged("classTrib");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public ObrigatoriedadeECD indEscrituracao
    {
        get
        {
            return indEscrituracaoField;
        }

        set
        {
            indEscrituracaoField = value;
            RaisePropertyChanged("indEscrituracao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public DesoneracaoCPRB indDesoneracao
    {
        get
        {
            return indDesoneracaoField;
        }

        set
        {
            indDesoneracaoField = value;
            RaisePropertyChanged("indDesoneracao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public AcordoInternacionalIsencaoMulta indAcordoIsenMulta
    {
        get
        {
            return indAcordoIsenMultaField;
        }

        set
        {
            indAcordoIsenMultaField = value;
            RaisePropertyChanged("indAcordoIsenMulta");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public SituacaoPessoaJuridica indSitPJ
    {
        get
        {
            return indSitPJField;
        }

        set
        {
            indSitPJField = value;
            RaisePropertyChanged("indSitPJ");
        }
    }

    /// <remarks/>
    [XmlIgnore()]
    public bool indSitPJSpecified
    {
        get
        {
            return indSitPJFieldSpecified;
        }

        set
        {
            indSitPJFieldSpecified = value;
            RaisePropertyChanged("indSitPJSpecified");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public R1000_InfoCadastro_Contato contato
    {
        get
        {
            return contatoField;
        }

        set
        {
            contatoField = value;
            RaisePropertyChanged("contato");
        }
    }

    /// <remarks/>
    [XmlElement("softHouse", Order = 6)]
    public R1000_InfoCadastro_SoftwareHouse softHouse
    {
        get
        {
            return softHouseField;
        }

        set
        {
            softHouseField = value;
            RaisePropertyChanged("softHouse");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public ReinfEvtInfoContriInfoContriInclusaoInfoCadastroInfoEFR infoEFR
    {
        get
        {
            return infoEFRField;
        }

        set
        {
            infoEFRField = value;
            RaisePropertyChanged("infoEFR");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


public partial class R1000_InfoCadastro_Contato : object, INotifyPropertyChanged
{
    private string nmCttField;
    private string cpfCttField;
    private string foneFixoField;
    private string foneCelField;
    private string emailField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nmCtt
    {
        get
        {
            return nmCttField;
        }

        set
        {
            nmCttField = value;
            RaisePropertyChanged("nmCtt");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string cpfCtt
    {
        get
        {
            return cpfCttField;
        }

        set
        {
            cpfCttField = value;
            RaisePropertyChanged("cpfCtt");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string foneFixo
    {
        get
        {
            return foneFixoField;
        }

        set
        {
            foneFixoField = value;
            RaisePropertyChanged("foneFixo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string foneCel
    {
        get
        {
            return foneCelField;
        }

        set
        {
            foneCelField = value;
            RaisePropertyChanged("foneCel");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string email
    {
        get
        {
            return emailField;
        }

        set
        {
            emailField = value;
            RaisePropertyChanged("email");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


public partial class R1000_InfoCadastro_SoftwareHouse : object, INotifyPropertyChanged
{
    private string cnpjSoftHouseField = "19574916000183";
    private string nmRazaoField = "EFICAZ SISTEMAS DE GESTÃO E INTELIGÊNCIA TRIBUTÁRIA LTDA - ME";
    private string nmContField = "DANIEL LUCINDO BASILIO";
    private string telefoneField = "16981282669";
    private string emailField = "contato@eficazcs.com.br";

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cnpjSoftHouse
    {
        get
        {
            return cnpjSoftHouseField;
        }

        set
        {
            cnpjSoftHouseField = value;
            RaisePropertyChanged("cnpjSoftHouse");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nmRazao
    {
        get
        {
            return nmRazaoField;
        }

        set
        {
            nmRazaoField = value;
            RaisePropertyChanged("nmRazao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string nmCont
    {
        get
        {
            return nmContField;
        }

        set
        {
            nmContField = value;
            RaisePropertyChanged("nmCont");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string telefone
    {
        get
        {
            return telefoneField;
        }

        set
        {
            telefoneField = value;
            RaisePropertyChanged("telefone");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string email
    {
        get
        {
            return emailField;
        }

        set
        {
            emailField = value;
            RaisePropertyChanged("email");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}