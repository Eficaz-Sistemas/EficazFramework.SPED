namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public partial class S1005 : Evento
{
    private S1005TabelaEstabelecimento evtTabEstabField;
    private SignatureType signatureField;

    [XmlElement(Order = 0)]
    public S1005TabelaEstabelecimento evtTabEstab
    {
        get => evtTabEstabField;
        set
        {
            evtTabEstabField = value;
            RaisePropertyChanged(nameof(evtTabEstab));
        }
    }

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

    public override void GeraEventoID() 
        => evtTabEstabField.Id = string.Format("ID{0}{1}{2}", (int)(evtTabEstabField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabEstabField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    public override string ContribuinteCNPJ()
        => evtTabEstabField.ideEmpregador.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtTabEstab";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(S1005), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtTabEstab/{Versao}", IsNullable = false });
}

/// <exclude />
public partial class S1005TabelaEstabelecimento : ESocialBindableObject
{
    private IdentificacaoCadastro ideEventoField;
    private Empregador ideEmpregadorField;
    private S1005InfoEstabelecimento infoEstabField;
    private string idField;

    [XmlElement(Order = 0)]
    public IdentificacaoCadastro ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    [XmlElement(Order = 1)]
    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    [XmlElement(Order = 2)]
    public S1005InfoEstabelecimento infoEstab
    {
        get => infoEstabField;
        set
        {
            infoEstabField = value;
            RaisePropertyChanged(nameof(infoEstab));
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
public partial class S1005InfoEstabelecimento : ESocialBindableObject
{
    private object itemField;

    [XmlElement("alteracao", typeof(S1005Alteracao), Order = 0)]
    [XmlElement("exclusao", typeof(S1005Exclusao), Order = 0)]
    [XmlElement("inclusao", typeof(S1005Inclusao), Order = 0)]
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
public partial class S1005Inclusao : ESocialBindableObject
{
    private S1005IdentificacaoEstabelecimento ideEstabField;
    private S1005DadosEstabelecimento dadosEstabField;

    [XmlElement(Order = 0)]
    public S1005IdentificacaoEstabelecimento ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }

    [XmlElement(Order = 1)]
    public S1005DadosEstabelecimento dadosEstab
    {
        get => dadosEstabField;
        set
        {
            dadosEstabField = value;
            RaisePropertyChanged(nameof(dadosEstab));
        }
    }
}

/// <exclude />
public partial class S1005Alteracao : ESocialBindableObject
{
    private S1005IdentificacaoEstabelecimento ideEstabField;
    private S1005DadosEstabelecimento dadosEstabField;
    private IdePeriodo novaValidadeField;

    [XmlElement(Order = 0)]
    public S1005IdentificacaoEstabelecimento ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }

    [XmlElement(Order = 1)]
    public S1005DadosEstabelecimento dadosEstab
    {
        get => dadosEstabField;
        set
        {
            dadosEstabField = value;
            RaisePropertyChanged(nameof(dadosEstab));
        }
    }

    [XmlElement(Order = 2)]
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
public partial class S1005Exclusao : ESocialBindableObject
{
    private S1005IdentificacaoEstabelecimento ideEstabField;

    [XmlElement(Order = 0)]
    public S1005IdentificacaoEstabelecimento ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }
}


/// <exclude />
public partial class S1005IdentificacaoEstabelecimento : ESocialBindableObject
{
    private TipoInscricao tpInscField = TipoInscricao.CNPJ;
    private string nrInscField;
    private string iniValidField;
    private string fimValidField;

    [XmlElement(Order = 0)]
    public TipoInscricao tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    [XmlElement(Order = 2)]
    public string iniValid
    {
        get => iniValidField;
        set
        {
            iniValidField = value;
            RaisePropertyChanged(nameof(iniValid));
        }
    }

    [XmlElement(Order = 3)]
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
public partial class S1005DadosEstabelecimento : ESocialBindableObject
{
    private string cnaePrepField;
    private string cnpjRespField;
    private S1005AliquotaGilRat aliqGilratField;
    private S1005InfoCaePF infoCaepfField;
    private S1005InfoObra infoObraField;
    private S1005InfoTrabalhistas infoTrabField;

    [XmlElement(DataType = "integer", Order = 0)]
    public string cnaePrep
    {
        get => cnaePrepField;
        set
        {
            cnaePrepField = value;
            RaisePropertyChanged(nameof(cnaePrep));
        }
    }

    [XmlElement(Order = 1)]
    public string cnpjResp
    {
        get => cnpjRespField;
        set
        {
            cnpjRespField = value;
            RaisePropertyChanged(nameof(cnpjResp));
        }
    }

    [XmlElement(Order = 2)]
    public S1005AliquotaGilRat aliqGilrat
    {
        get => aliqGilratField;
        set
        {
            aliqGilratField = value;
            RaisePropertyChanged(nameof(aliqGilrat));
        }
    }

    [XmlElement(Order = 3)]
    public S1005InfoCaePF infoCaepf
    {
        get => infoCaepfField;
        set
        {
            infoCaepfField = value;
            RaisePropertyChanged(nameof(infoCaepf));
        }
    }

    [XmlElement(Order = 4)]
    public S1005InfoObra infoObra
    {
        get => infoObraField;
        set
        {
            infoObraField = value;
            RaisePropertyChanged(nameof(infoObra));
        }
    }

    [XmlElement(Order = 5)]
    public S1005InfoTrabalhistas infoTrab
    {
        get => infoTrabField;
        set
        {
            infoTrabField = value;
            RaisePropertyChanged(nameof(infoTrab));
        }
    }
}

/// <exclude />
public partial class S1005AliquotaGilRat : ESocialBindableObject
{
    private int? aliqRatField;
    private decimal? fapField;
    private ProcessoAdmOuJud procAdmJudRatField;
    private ProcessoAdmOuJud procAdmJudFapField;

    /// <summary>
    /// Valores válidos: 1, 2 ou 3
    /// </summary>
    [XmlElement(Order = 0)]
    public int? aliqRat
    {
        get => aliqRatField;
        set
        {
            aliqRatField = value;
            RaisePropertyChanged(nameof(aliqRat));
        }
    }

    public bool ShouldSerializealiqRat()
        => aliqRat.HasValue;

    /// <summary>
    /// Intervalo válido: de 0.5 a 2.0
    /// </summary>
    [XmlElement(Order = 1)]
    public decimal? fap
    {
        get => fapField;
        set
        {
            fapField = value;
            RaisePropertyChanged(nameof(fap));
        }
    }

    public bool ShouldSerializefap()
        => fap.HasValue;


    [XmlElement(Order = 3)]
    public ProcessoAdmOuJud procAdmJudRat
    {
        get => procAdmJudRatField;
        set
        {
            procAdmJudRatField = value;
            RaisePropertyChanged(nameof(procAdmJudRat));
        }
    }

    [XmlElement(Order = 4)]
    public ProcessoAdmOuJud procAdmJudFap
    {
        get => procAdmJudFapField;
        set
        {
            procAdmJudFapField = value;
            RaisePropertyChanged(nameof(procAdmJudFap));
        }
    }
}

/// <exclude />
public partial class S1005InfoCaePF : ESocialBindableObject
{
    private TipoCAEPF tpCaepfField = TipoCAEPF.ProdRural;

    [XmlElement(Order = 0)]
    public TipoCAEPF tpCaepf
    {
        get => tpCaepfField;
        set
        {
            tpCaepfField = value;
            RaisePropertyChanged(nameof(tpCaepf));
        }
    }
}

/// <exclude />
public partial class S1005InfoObra : ESocialBindableObject
{
    private IndicadorSubstPatronalObra indSubstPatrObraField = IndicadorSubstPatronalObra.NaoSubstituida;

    [XmlElement(Order = 0)]
    public IndicadorSubstPatronalObra indSubstPatrObra
    {
        get => indSubstPatrObraField;
        set
        {
            indSubstPatrObraField = value;
            RaisePropertyChanged(nameof(indSubstPatrObra));
        }
    }
}

/// <exclude />
public partial class S1005InfoTrabalhistas : ESocialBindableObject
{
    private S1005InfoAprendiz infoAprField;
    private S1005InfoPcd infoPCDField;

    [XmlElement(Order = 0)]
    public S1005InfoAprendiz infoApr
    {
        get => infoAprField;
        set
        {
            infoAprField = value;
            RaisePropertyChanged(nameof(infoApr));
        }
    }

    [XmlElement(Order = 1)]
    public S1005InfoPcd infoPCD
    {
        get => infoPCDField;
        set
        {
            infoPCDField = value;
            RaisePropertyChanged(nameof(infoPCD));
        }
    }
}

/// <exclude />
public partial class S1005InfoAprendiz : ESocialBindableObject
{
    private string nrProcJudField;
    private List<S1005InfoEntidadeEduc> infoEntEducField;

    [XmlElement(Order = 0)]
    public string nrProcJud
    {
        get => nrProcJudField;
        set
        {
            nrProcJudField = value;
            RaisePropertyChanged(nameof(nrProcJud));
        }
    }

    [XmlElement("infoEntEduc", Order = 1)]
    public List<S1005InfoEntidadeEduc> infoEntEduc
    {
        get => infoEntEducField;
        set
        {
            infoEntEducField = value;
            RaisePropertyChanged(nameof(infoEntEduc));
        }
    }
}

/// <exclude />
public partial class S1005InfoEntidadeEduc : ESocialBindableObject
{
    private string nrInscField;

    [XmlElement(Order = 0)]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }
}

/// <exclude />
public partial class S1005InfoPcd : ESocialBindableObject
{
    private string nrProcJudField;

    [XmlElement(Order = 0)]
    public string nrProcJud
    {
        get => nrProcJudField;
        set
        {
            nrProcJudField = value;
            RaisePropertyChanged(nameof(nrProcJud));
        }
    }
}
