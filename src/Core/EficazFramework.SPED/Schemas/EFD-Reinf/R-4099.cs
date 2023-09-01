namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Fechamento/reabertura dos eventos da série R-4000
/// </summary>
/// <example>
/// ```csharp
/// // Fechamento:
/// var evento = new R4099()
/// {
///     Versao = Versao.v2_01_02,
///     evtFech = new R4099EventoFechamReabertura()
///     {
///         ideEvento = new IdentificacaoEventoFechamento()
///         {
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "6.0"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "34785515000166",
///         },
///         ideRespInf = new IdentificacaoResponsavel()
///         {
///             nmResp = "Pierre de Fermat",
///             cpfResp = "47363361886",
///             telefone = "11999990000",
///             email = "contato@eficazcs.com.br",
///         },
///         infoFech = new R4099InformacaoFechamReabertura()
///         {
///             fechRet = IndicadorFechamentoReabertura.Fechamento // atenção!
///         }
///     }
/// };
///
/// // Reabertura:
/// var evento = new R4099()
/// {
///     Versao = Versao.v2_01_02,
///     evtFech = new R4099EventoFechamReabertura()
///     {
///         ideEvento = new IdentificacaoEventoFechamento()
///         {
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "6.0"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "34785515000166",
///         },
///         ideRespInf = new IdentificacaoResponsavel()
///         {
///             nmResp = "Pierre de Fermat",
///             cpfResp = "47363361886",
///             telefone = "11999990000",
///             email = "contato@eficazcs.com.br",
///         },
///         infoFech = new R4099InformacaoFechamReabertura()
///         {
///             fechRet = IndicadorFechamentoReabertura.Reabertura // atenção!
///         }
///     }
/// };
/// ```
/// </example>
[System.SerializableAttribute()]
public partial class R4099 : Evento
{

    private R4099EventoFechamReabertura evtFechField;
    private SignatureType signatureField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public R4099EventoFechamReabertura evtFech
    {
        get => evtFechField;
        set
        {
            evtFechField = value;
            RaisePropertyChanged(nameof(evtFech));
        }
    }

    /// <exclude/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged(nameof(Signature));
        }
    }


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtFechField";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Evento Members
    /// <exclude/>
    public override void GeraEventoID() =>
        evtFechField.id = $"ID{(int)(evtFechField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtFechField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtFechField.ideContri.nrInsc;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R4099), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4099FechamentoDirf/{Versao}", IsNullable = false });
}

/// <exclude />
public partial class R4099EventoFechamReabertura : EfdReinfBindableObject
{

    private IdentificacaoEventoFechamento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private IdentificacaoResponsavel ideRespInfField;
    private R4099InformacaoFechamReabertura infoFechField;
    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public IdentificacaoEventoFechamento ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public IdentificacaoContribuinte ideContri
    {
        get => ideContriField;
        set
        {
            ideContriField = value;
            RaisePropertyChanged(nameof(ideContri));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public IdentificacaoResponsavel ideRespInf
    {
        get => ideRespInfField;
        set
        {
            ideRespInfField = value;
            RaisePropertyChanged(nameof(ideRespInf));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public R4099InformacaoFechamReabertura infoFech
    {
        get => infoFechField;
        set
        {
            infoFechField = value;
            RaisePropertyChanged(nameof(infoFech));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
    public string id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(id));
        }
    }
}

/// <exclude />
public partial class R4099InformacaoFechamReabertura : EfdReinfBindableObject
{

    private IndicadorFechamentoReabertura fechRetField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public IndicadorFechamentoReabertura fechRet
    {
        get => fechRetField;
        set
        {
            fechRetField = value;
            RaisePropertyChanged(nameof(fechRet));
        }
    }
}
