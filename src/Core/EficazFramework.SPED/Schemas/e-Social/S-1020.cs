namespace EficazFramework.SPED.Schemas.eSocial;


[Serializable()]
public partial class S1020 : Evento
{
    private S1020TabelaLotacao evtTabLotacaoField;
    private SignatureType signatureField;

    public S1020TabelaLotacao evtTabLotacao
    {
        get => evtTabLotacaoField;
        set
        {
            evtTabLotacaoField = value;
            RaisePropertyChanged(nameof(evtTabLotacao));
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
        evtTabLotacaoField.Id = string.Format("ID{0}{1}{2}", (int)(evtTabLotacaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabLotacaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
    }

    /// <exclude/>
    public override string ContribuinteCNPJ()
    {
        return evtTabLotacaoField.ideEmpregador.nrInsc;
    }


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtTabLotacao";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    //// Serialization Members
    ///// <exclude/>
    //public override XmlSerializer DefineSerializer(bool includeNamespace = true)
    //{
    //    if (includeNamespace)
    //        return new(typeof(S1020), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtTabLotacao/{Versao}", IsNullable = false });

    //    return new(typeof(S1020), new XmlRootAttribute(Evento.root) { IsNullable = false });
    //}
}

/// <exclude/>
public partial class S1020TabelaLotacao : ESocialBindableObject
{
    private IdentificacaoCadastro ideEventoField;
    private Empregador ideEmpregadorField;
    private S1020InfoLotacao infoLotacaoField;
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

    public S1020InfoLotacao infoLotacao
    {
        get => infoLotacaoField;
        set
        {
            infoLotacaoField = value;
            RaisePropertyChanged(nameof(infoLotacao));
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

/// <exclude/>
public partial class S1020InfoLotacao : ESocialBindableObject
{
    private object itemField;

    [XmlElement("alteracao", typeof(S1020Alteracao))]
    [XmlElement("exclusao", typeof(S1020Exclusao))]
    [XmlElement("inclusao", typeof(S1020Inclusao))]
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

/// <exclude/>
public partial class S1020Inclusao : ESocialBindableObject
{
    private S1020IdentificacaoLotacao ideLotacaoField;
    private S1020DadosLotacao dadosLotacaoField;

    public S1020IdentificacaoLotacao ideLotacao
    {
        get => ideLotacaoField;
        set
        {
            ideLotacaoField = value;
            RaisePropertyChanged(nameof(ideLotacao));
        }
    }

    public S1020DadosLotacao dadosLotacao
    {
        get => dadosLotacaoField;
        set
        {
            dadosLotacaoField = value;
            RaisePropertyChanged(nameof(dadosLotacao));
        }
    }
}

/// <exclude/>
public partial class S1020Alteracao : ESocialBindableObject
{
    private S1020IdentificacaoLotacao ideLotacaoField;
    private S1020DadosLotacao dadosLotacaoField;
    private IdePeriodo novaValidadeField;

    public S1020IdentificacaoLotacao ideLotacao
    {
        get => ideLotacaoField;
        set
        {
            ideLotacaoField = value;
            RaisePropertyChanged(nameof(ideLotacao));
        }
    }

    public S1020DadosLotacao dadosLotacao
    {
        get => dadosLotacaoField;
        set
        {
            dadosLotacaoField = value;
            RaisePropertyChanged(nameof(dadosLotacao));
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

/// <exclude/>
public partial class S1020Exclusao : ESocialBindableObject
{
    private S1020IdentificacaoLotacao ideLotacaoField;

    public S1020IdentificacaoLotacao ideLotacao
    {
        get => ideLotacaoField;
        set
        {
            ideLotacaoField = value;
            RaisePropertyChanged(nameof(ideLotacao));
        }
    }
}

/// <exclude/>
public partial class S1020IdentificacaoLotacao : ESocialBindableObject
{
    private string codLotacaoField;
    private string iniValidField;
    private string fimValidField;

    public string codLotacao
    {
        get => codLotacaoField;
        set
        {
            codLotacaoField = value;
            RaisePropertyChanged(nameof(codLotacao));
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

/// <exclude/>
public partial class S1020DadosLotacao : ESocialBindableObject
{
    private string tpLotacaoField;
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private bool tpInscFieldSpecified;
    private string nrInscField;
    private S1020FpasLotacao fpasLotacaoField;
    private S1020InfoEmprParcial infoEmprParcialField;
    private S1020DadosOpPortuario dadosOpPortField;

    public string tpLotacao
    {
        get => tpLotacaoField;
        set
        {
            tpLotacaoField = value;
            RaisePropertyChanged(nameof(tpLotacao));
        }
    }

    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    [XmlIgnore()]
    public bool tpInscSpecified
    {
        get => tpInscFieldSpecified;
        set
        {
            tpInscFieldSpecified = value;
            RaisePropertyChanged(nameof(tpInscSpecified));
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

    public S1020FpasLotacao fpasLotacao
    {
        get => fpasLotacaoField;
        set
        {
            fpasLotacaoField = value;
            RaisePropertyChanged(nameof(fpasLotacao));
        }
    }

    public S1020InfoEmprParcial infoEmprParcial
    {
        get => infoEmprParcialField;
        set
        {
            infoEmprParcialField = value;
            RaisePropertyChanged(nameof(infoEmprParcial));
        }
    }

    public S1020DadosOpPortuario dadosOpPort
    {
        get => dadosOpPortField;
        set
        {
            dadosOpPortField = value;
            RaisePropertyChanged(nameof(dadosOpPort));
        }
    }
}

/// <exclude/>
public partial class S1020FpasLotacao : ESocialBindableObject
{
    private int fpasField;
    private string codTercsField;
    private string codTercsSuspField;
    private List<S1020FpasLotacaoProcJudTerceiro> infoProcJudTerceirosField;

    [XmlElement()]
    public int fpas
    {
        get => fpasField;
        set
        {
            fpasField = value;
            RaisePropertyChanged(nameof(fpas));
        }
    }

    public string codTercs
    {
        get => codTercsField;
        set
        {
            codTercsField = value;
            RaisePropertyChanged(nameof(codTercs));
        }
    }

    public string codTercsSusp
    {
        get => codTercsSuspField;
        set
        {
            codTercsSuspField = value;
            RaisePropertyChanged(nameof(codTercsSusp));
        }
    }

    [XmlArrayItem("procJudTerceiro", IsNullable = false)]
    public List<S1020FpasLotacaoProcJudTerceiro> infoProcJudTerceiros
    {
        get => infoProcJudTerceirosField;
        set
        {
            infoProcJudTerceirosField = value;
            RaisePropertyChanged(nameof(infoProcJudTerceiros));
        }
    }
}

/// <exclude/>
public partial class S1020FpasLotacaoProcJudTerceiro : ESocialBindableObject
{
    private string codTercField;
    private string nrProcJudField;
    private string codSuspField;

    public string codTerc
    {
        get => codTercField;
        set
        {
            codTercField = value;
            RaisePropertyChanged(nameof(codTerc));
        }
    }

    public string nrProcJud
    {
        get => nrProcJudField;
        set
        {
            nrProcJudField = value;
            RaisePropertyChanged(nameof(nrProcJud));
        }
    }

    [XmlElement(DataType = "integer")]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged(nameof(codSusp));
        }
    }
}

/// <exclude/>
public partial class S1020InfoEmprParcial : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscContratField = PersonalidadeJuridica.CNPJ;
    private string nrInscContratField;
    private PersonalidadeJuridica tpInscPropField = PersonalidadeJuridica.CNPJ;
    private string nrInscPropField;

    public PersonalidadeJuridica tpInscContrat
    {
        get => tpInscContratField;
        set
        {
            tpInscContratField = value;
            RaisePropertyChanged(nameof(tpInscContrat));
        }
    }

    public string nrInscContrat
    {
        get => nrInscContratField;
        set
        {
            nrInscContratField = value;
            RaisePropertyChanged(nameof(nrInscContrat));
        }
    }

    public PersonalidadeJuridica tpInscProp
    {
        get => tpInscPropField;
        set
        {
            tpInscPropField = value;
            RaisePropertyChanged(nameof(tpInscProp));
        }
    }

    public string nrInscProp
    {
        get => nrInscPropField;
        set
        {
            nrInscPropField = value;
            RaisePropertyChanged(nameof(nrInscProp));
        }
    }
}

/// <exclude/>
public partial class S1020DadosOpPortuario : ESocialBindableObject
{
    private int? aliqRatField;
    private decimal? fapField;

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
}