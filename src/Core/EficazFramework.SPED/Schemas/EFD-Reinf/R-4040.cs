namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Pagamentos/créditos a beneficiários não identificados
/// </summary>
/// <example>
/// ```csharp
/// var eventoo = new R4040()
/// {
///     evtBenefNId = new R4040EventoBenefNaoIdentificado()
///     {
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = "2022-08",
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "6.0"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "34785515000166",
///         },
///         ideEstab = new R4040IdentificacaoEstabelecimento()
///         {
///             tpInscEstab = PersonalidadeJuridica.CNPJ,
///             nrInscEstab = "34785515000166",
///             ideNat = new()
///             {
///                 new R4040IdentificacaoNaturezaRend() //ideNat (1:N)
///                 {
///                     // Utilizar a tabela 01, do Anexo I do Manual
///                     natRend = 19009, // Remuneração de Serviços de auditoria;
/// 
///                     infoPgto = new ()
///                     {
///                         new R4040InfoPagamento()
///                         {
///                             DataFatoGerador = System.DateTime.Now,
///                             vlrLiq = 1000000.00.ToString("f2"),
///                             vlrBaseIR = 153846.15M.ToString("f2"),
///                             vlrIR = 2307.69M.ToString("f2"),
///                             descr = "Alguma prestação de serviço qualquer."
///                         },
///                     },
///                 }
///             }
///         }
///     }
/// };
/// ```
/// </example>
[System.SerializableAttribute()]
public partial class R4040 : Evento
{

    private R4040EventoBenefNaoIdentificado evtBenefNIdField;
    private SignatureType signatureField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public R4040EventoBenefNaoIdentificado evtBenefNId
    {
        get => evtBenefNIdField;
        set
        {
            evtBenefNIdField = value;
            RaisePropertyChanged("evtBenefNId");
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
            RaisePropertyChanged("Signature");
        }
    }


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "ReinfEvtBenefNId";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Evento Members
    /// <exclude/>
    public override void GeraEventoID() =>
        evtBenefNId.id = $"ID{(int)(evtBenefNId?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtBenefNId?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtBenefNId.ideContri.nrInsc;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R4040), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4040PagtoBenefNaoIdentificado/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R4040EventoBenefNaoIdentificado : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R4040IdentificacaoEstabelecimento ideEstabField;
    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public IdentificacaoEventoPeriodico ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
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
            RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public R4040IdentificacaoEstabelecimento ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
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
            RaisePropertyChanged("id");
        }
    }
}


/// <exclude />
public partial class R4040IdentificacaoEstabelecimento : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private List<R4040IdentificacaoNaturezaRend> ideNatField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlElementAttribute("ideNat", Order = 2)]
    public List<R4040IdentificacaoNaturezaRend> ideNat
    {
        get => ideNatField;
        set
        {
            ideNatField = value;
            RaisePropertyChanged("ideNat");
        }
    }
}


/// <exclude />
public partial class R4040IdentificacaoNaturezaRend : EfdReinfBindableObject
{
    private int natRendField;
    private List<R4040InfoPagamento> infoPgtoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlElementAttribute("infoPgto", Order = 1)]
    public List<R4040InfoPagamento> infoPgto
    {
        get => infoPgtoField;
        set
        {
            infoPgtoField = value;
            RaisePropertyChanged("infoPgto");
        }
    }
}


/// <exclude />
public partial class R4040InfoPagamento : EfdReinfBindableObject
{
    private System.DateTime dtFGField;
    private string vlrLiqField;
    private string vlrBaseIRField;
    private string vlrIRField;
    private string descrField;
    private List<R4040InfoProcessoRelacionado> infoProcRetField;

    /// <summary>
    /// Informar a data do fato gerador, no formato AAAA-MM-DD. <br/><br/>
    /// <b>Validação: </b>A data informada deve estar compreendida no período de apuração 
    /// ao qual se refere o arquivo, conforme informado em(perApur}, no formato AAAA-MM-DD.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType = "date", Order = 0)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
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
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order = 5)]
    public List<R4040InfoProcessoRelacionado> infoProcRet
    {
        get => infoProcRetField;
        set
        {
            infoProcRetField = value;
            RaisePropertyChanged("infoProcRet");
        }
    }
}


/// <exclude />
public partial class R4040InfoProcessoRelacionado : EfdReinfBindableObject
{
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private string vlrBaseSuspIRField;
    private string vlrNIRField;
    private string vlrDepIRField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    public string vlrDepIR
    {
        get => vlrDepIRField;
        set
        {
            vlrDepIRField = value;
            RaisePropertyChanged("vlrDepIR");
        }
    }
}
