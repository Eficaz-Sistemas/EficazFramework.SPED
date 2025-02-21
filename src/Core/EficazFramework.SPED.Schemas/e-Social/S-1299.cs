namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public partial class S1299 : Evento
{
    private S1299EvPer evtFechaEvPerField;
    private SignatureType signatureField;

    public S1299EvPer evtFechaEvPer
    {
        get => evtFechaEvPerField;
        set
        {
            evtFechaEvPerField = value;
            RaisePropertyChanged(nameof(evtFechaEvPer));
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
        evtFechaEvPerField.Id = string.Format("ID{0}{1}{2}", (int)(evtFechaEvPerField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtFechaEvPerField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ() => 
        evtFechaEvPerField.ideEmpregador.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtFechaEvPer";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    //public override XmlSerializer DefineSerializer() =>
    //    new(typeof(S1299), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtFechaEvPer/{Versao}", IsNullable = false });
}

public partial class S1299EvPer : ESocialBindableObject
{
    private S1299IdentificacaoEvento ideEventoField;
    private Empregador ideEmpregadorField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private S1299InformacoesResponsavel ideRespInfField;
    private S1299InfoFechamento infoFechField;
    private string idField;

    public S1299IdentificacaoEvento ideEvento
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

    [Obsolete("Descontinuado na versão S-1.02")]
    public S1299InformacoesResponsavel ideRespInf
    {
        get => ideRespInfField;
        set
        {
            ideRespInfField = value;
            RaisePropertyChanged(nameof(ideRespInf));
        }
    }

    public S1299InfoFechamento infoFech
    {
        get => infoFechField;
        set
        {
            infoFechField = value;
            RaisePropertyChanged(nameof(infoFech));
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

public partial class S1299IdentificacaoEvento : ESocialBindableObject
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
        get => indGuiaField;
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

[Obsolete("Descontinuado na versão S-1.02")]
public partial class S1299InformacoesResponsavel : ESocialBindableObject
{
    private string nmRespField;
    private string cpfRespField;
    private string telefoneField;
    private string emailField;

    public string nmResp
    {
        get => nmRespField;
        set
        {
            nmRespField = value;
            RaisePropertyChanged(nameof(nmResp));
        }
    }

    public string cpfResp
    {
        get => cpfRespField;
        set
        {
            cpfRespField = value;
            RaisePropertyChanged(nameof(cpfResp));
        }
    }

    public string telefone
    {
        get => telefoneField;
        set
        {
            telefoneField = value;
            RaisePropertyChanged(nameof(telefone));
        }
    }

    public string email
    {
        get => emailField;
        set
        {
            emailField = value;
            RaisePropertyChanged(nameof(email));
        }
    }
}

public partial class S1299InfoFechamento : ESocialBindableObject
{
    private SimNaoString evtRemunField = SimNaoString.Nao;
    private SimNaoString evtPgtosField = SimNaoString.Nao;

    [Obsolete("Descontinuado na versão S-1.02")]
    private SimNaoString evtAqProdField = SimNaoString.Nao;

    private SimNaoString evtComProdField = SimNaoString.Nao;
    private SimNaoString evtContratAvNPField = SimNaoString.Nao;
    private SimNaoString evtInfoComplPerField = SimNaoString.Nao;

    private SimNaoString transDCTFWebField = SimNaoString.Sim;
    private SimNaoString naoValidField = SimNaoString.Sim;


    [Obsolete("Descontinuado na versão S-1.02")]
    private string compSemMovtoField;

    public SimNaoString evtRemun
    {
        get => evtRemunField;
        set
        {
            evtRemunField = value;
            RaisePropertyChanged(nameof(evtRemun));
        }
    }

    public SimNaoString evtPgtos
    {
        get => evtPgtosField;
        set
        {
            evtPgtosField = value;
            RaisePropertyChanged(nameof(evtPgtos));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public SimNaoString evtAqProd
    {
        get => evtAqProdField;
        set
        {
            evtAqProdField = value;
            RaisePropertyChanged(nameof(evtAqProd));
        }
    }

    public SimNaoString evtComProd
    {
        get => evtComProdField;
        set
        {
            evtComProdField = value;
            RaisePropertyChanged(nameof(evtComProd));
        }
    }

    public SimNaoString evtContratAvNP
    {
        get => evtContratAvNPField;
        set
        {
            evtContratAvNPField = value;
            RaisePropertyChanged(nameof(evtContratAvNP));
        }
    }

    public SimNaoString evtInfoComplPer
    {
        get => evtInfoComplPerField;
        set
        {
            evtInfoComplPerField = value;
            RaisePropertyChanged(nameof(evtInfoComplPer));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public string compSemMovto
    {
        get => compSemMovtoField;
        set
        {
            compSemMovtoField = value;
            RaisePropertyChanged(nameof(compSemMovto));
        }
    }

    public SimNaoString transDCTFWeb
    {
        get => transDCTFWebField;
        set
        {
            transDCTFWebField = value;
            RaisePropertyChanged(nameof(transDCTFWeb));
        }
    }

    public SimNaoString naoValid
    {
        get => naoValidField;
        set
        {
            naoValidField = value;
            RaisePropertyChanged(nameof(naoValid));
        }
    }
}