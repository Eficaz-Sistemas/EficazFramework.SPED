namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public partial class S1298 : Evento
{
    private S1298EventoPeriodico evtReabreEvPerField;
    private SignatureType signatureField;

    public S1298EventoPeriodico evtReabreEvPer
    {
        get => evtReabreEvPerField;
        set
        {
            evtReabreEvPerField = value;
            RaisePropertyChanged(nameof(evtReabreEvPer));
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
    public override void GeraEventoID() => 
        evtReabreEvPerField.Id = string.Format("ID{0}{1}{2}", (int)(evtReabreEvPerField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtReabreEvPerField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtReabreEvPerField.ideEmpregador.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtReabreEvPer";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    //public override XmlSerializer DefineSerializer() =>
    //    new(typeof(S1298), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtReabreEvPer/{Versao}", IsNullable = false });
}

public partial class S1298EventoPeriodico : ESocialBindableObject
{
    private S1298IdentificacaoEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private string idField;

    public S1298IdentificacaoEvento ideEvento
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

public partial class S1298IdentificacaoEvento : ESocialBindableObject
{
    private IndicadorApuracao indApuracaoField = IndicadorApuracao.Mensal;
    private string perApurField;
    private IndicadorGuia indGuiaField = IndicadorGuia.DAE;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    public IndicadorApuracao indApuracao
    {
        get => indApuracaoField;
        set
        {
            indApuracaoField = value;
            RaisePropertyChanged(nameof(indApuracao));
        }
    }

    public string perApur
    {
        get => perApurField;
        set
        {
            perApurField = value;
            RaisePropertyChanged(nameof(perApur));
        }
    }

    public IndicadorGuia indGuia
    {
        get =>indGuiaField;
        set
        {
            indGuiaField = value; 
            RaisePropertyChanged(nameof(indGuia));
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
