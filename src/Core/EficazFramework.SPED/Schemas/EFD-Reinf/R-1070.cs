namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Tabela de processos administrativos/judiciais
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R1070()
/// {
///     Versao = Versao.v2_01_02,
///     evtTabProcesso = new R1070EventoTabProcesso()
///     {
///         ideEvento = new IdentificacaoEvento()
///         {
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "2.2"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678"
///         },
///         infoProcesso = new R1070InfoProcesso()
///         {
///             Item = new R1070Inclusao() // R1070Alteracao() ou R1070Exclusao()
///             {
///                 ideProcesso = new R1070IdentificacaoProcesso()
///                 {
///                     tpProc = TipoProcesso.Administrativo,
///                     nrProc = "123",
///                     iniValid = "2023-07",
///                     dadosProcJud = new R1070IdentificacaoProcessoDadosProcJud()
///                     {
///                         ufVara = "MG",
///                         codMunic = "3129707",
///                         idVara = "..."
///                     }
///                 }
///             }
///         }
///     }
/// }
/// ```
/// </example>
[Serializable()]
public partial class R1070 : Evento
{
    private R1070EventoTabProcesso evtTabProcessoField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R1070EventoTabProcesso evtTabProcesso
    {
        get => evtTabProcessoField;
        set
        {
            evtTabProcessoField = value;
            RaisePropertyChanged(nameof(evtTabProcesso));
        }
    }

    /// <exclude/>
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

    public override void GeraEventoID() =>
        evtTabProcessoField.id = $"ID{(int)(evtTabProcessoField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtTabProcessoField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";


    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtTabProcesso.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtTabProcesso";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R1070), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtTabProcesso/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R1070EventoTabProcesso : EfdReinfBindableObject
{
    private IdentificacaoEvento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R1070InfoProcesso infoProcessoField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEvento ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
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
    [XmlElement(Order = 2)]
    public R1070InfoProcesso infoProcesso
    {
        get => infoProcessoField;
        set
        {
            infoProcessoField = value;
            RaisePropertyChanged(nameof(infoProcesso));
        }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "ID")]
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


// Informação do Processo:
/// <exclude />
public partial class R1070InfoProcesso : EfdReinfBindableObject
{
    private object itemField;

    /// <remarks/>
    [XmlElement("alteracao", typeof(R1070Alteracao), Order = 0)]
    [XmlElement("exclusao", typeof(R1070Exclusao), Order = 0)]
    [XmlElement("inclusao", typeof(R1070Inclusao), Order = 0)]
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


// Alteração:
/// <exclude />
public partial class R1070Alteracao : EfdReinfBindableObject
{
    private R1070IdentificacaoProcesso ideProcessoField;
    private IdentificacaoPeriodo novaValidadeField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R1070IdentificacaoProcesso ideProcesso
    {
        get => ideProcessoField;
        set
        {
            ideProcessoField = value;
            RaisePropertyChanged(nameof(ideProcesso));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public IdentificacaoPeriodo novaValidade
    {
        get => novaValidadeField;
        set
        {
            novaValidadeField = value;
            RaisePropertyChanged(nameof(novaValidade));
        }
    }
}


// Exclusão:
/// <exclude />
public partial class R1070Exclusao : EfdReinfBindableObject
{
    private R1070IdentificacaoProcesso ideProcessoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R1070IdentificacaoProcesso ideProcesso
    {
        get => ideProcessoField;

        set
        {
            ideProcessoField = value;
            RaisePropertyChanged(nameof(ideProcesso));
        }
    }
}


// Inclusão:
/// <exclude />
public partial class R1070Inclusao : EfdReinfBindableObject
{
    private R1070IdentificacaoProcesso ideProcessoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R1070IdentificacaoProcesso ideProcesso
    {
        get => ideProcessoField;
        set
        {
            ideProcessoField = value;
            RaisePropertyChanged(nameof(ideProcesso));
        }
    }

}


/// <exclude />
public partial class R1070IdentificacaoProcesso : EfdReinfBindableObject
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string iniValidField;
    private string fimValidField;
    private IndicadorAuditoria indAutoriaField;
    private bool indAutoriaFieldSpecified = false;
    private R1070IdentificacaoProcessoInfoSusp[] infoSuspField;
    private R1070IdentificacaoProcessoDadosProcJud dadosProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProc
    {
        get => tpProcField;
        set
        {
            tpProcField = value;
            RaisePropertyChanged(nameof(tpProc));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 2)]
    public string iniValid
    {
        get => iniValidField;
        set
        {
            iniValidField = value;
            RaisePropertyChanged(nameof(iniValid));
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 3)]
    public string fimValid
    {
        get => fimValidField;
        set
        {
            fimValidField = value;
            RaisePropertyChanged(nameof(fimValid));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public IndicadorAuditoria indAutoria
    {
        get => indAutoriaField;
        set
        {
            indAutoriaField = value;
            RaisePropertyChanged(nameof(indAutoria));
        }
    }

    /// <summary>
    /// Indica se o campo <see cref="indAutoria"/>
    /// deve ser informado no XML gerado.
    /// </summary>
    /// <exclude/>
    [XmlIgnore()]
    public bool indAutoriaSpecified
    {
        get => indAutoriaFieldSpecified;
        set
        {
            indAutoriaFieldSpecified = value;
            RaisePropertyChanged(nameof(indAutoriaSpecified));
        }
    }


    /// <remarks/>
    [XmlElement("infoSusp", Order = 5)]
    public R1070IdentificacaoProcessoInfoSusp[] infoSusp
    {
        get => infoSuspField;
        set
        {
            infoSuspField = value;
            RaisePropertyChanged(nameof(infoSusp));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public R1070IdentificacaoProcessoDadosProcJud dadosProcJud
    {
        get => dadosProcJudField;
        set
        {
            dadosProcJudField = value;
            RaisePropertyChanged(nameof(dadosProcJud));
        }
    }
}

/// <exclude />
public partial class R1070IdentificacaoProcessoInfoSusp : EfdReinfBindableObject
{
    private string codSuspField;
    private string indSuspField;
    private DateTime dtDecisaoField;
    private string indDepositoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged(nameof(codSusp));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string indSusp
    {
        get => indSuspField;
        set
        {
            indSuspField = value;
            RaisePropertyChanged(nameof(indSusp));
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "date", Order = 2)]
    public DateTime dtDecisao
    {
        get => dtDecisaoField;
        set
        {
            dtDecisaoField = value;
            RaisePropertyChanged(nameof(dtDecisao));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string indDeposito
    {
        get => indDepositoField;
        set
        {
            indDepositoField = value;
            RaisePropertyChanged(nameof(indDeposito));
        }
    }
}


/// <exclude />
public partial class R1070IdentificacaoProcessoDadosProcJud : EfdReinfBindableObject
{
    private string ufVaraField;
    private string codMunicField;
    private string idVaraField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string ufVara
    {
        get => ufVaraField;
        set
        {
            ufVaraField = value;
            RaisePropertyChanged(nameof(ufVara));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string codMunic
    {
        get => codMunicField;
        set
        {
            codMunicField = value;
            RaisePropertyChanged(nameof(codMunic));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string idVara
    {
        get => idVaraField;
        set
        {
            idVaraField = value;
            RaisePropertyChanged(nameof(idVara));
        }
    }
}
