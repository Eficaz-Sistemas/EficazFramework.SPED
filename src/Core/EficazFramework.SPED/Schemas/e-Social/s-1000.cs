namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public partial class S1000 : Evento
{
    private eSocialEvtInfoEmpregador evtInfoEmpregadorField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public eSocialEvtInfoEmpregador evtInfoEmpregador
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
    public override string TagId { get; }
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
public partial class eSocialEvtInfoEmpregador : ESocialBindableObject
{
    private IdentificacaoCadastro ideEventoField;
    private Empregador ideEmpregadorField;
    private eSocialEvtInfoEmpregadorInfoEmpregador infoEmpregadorField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoCadastro ideEvento
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
    public Empregador ideEmpregador
    {
        get
        {
            return ideEmpregadorField;
        }

        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged("ideEmpregador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public eSocialEvtInfoEmpregadorInfoEmpregador infoEmpregador
    {
        get
        {
            return infoEmpregadorField;
        }

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
        get
        {
            return idField;
        }

        set
        {
            idField = value;
            RaisePropertyChanged("Id");
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
