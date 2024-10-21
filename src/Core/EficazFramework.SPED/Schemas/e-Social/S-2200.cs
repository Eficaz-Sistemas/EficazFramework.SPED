namespace EficazFramework.SPED.Schemas.eSocial;

[Serializable()]
public partial class S2200 : Evento
{
    private S2200Admissao evtAdmissaoField;
    private SignatureType signatureField;

    public S2200Admissao evtAdmissao
    {
        get => evtAdmissaoField;
        set
        {
            evtAdmissaoField = value;
            RaisePropertyChanged(nameof(evtAdmissao));
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


    // Evento Members
    /// <exclude/>
    public override void GeraEventoID()
        => evtAdmissaoField.Id = string.Format("ID{0}{1}{2}", (int)(evtAdmissaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAdmissaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtAdmissaoField.ideEmpregador.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => "evtAdmissao";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(S2200), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtAdmissao/{Versao}", IsNullable = false });

}

/// <exclude />
public partial class S2200Admissao : ESocialBindableObject
{
    private IdeEventoNaoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S2200Trabalhador trabalhadorField;
    private S2200Vinculo vinculoField;
    private string idField;

    public IdeEventoNaoPeriodico ideEvento
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

    public S2200Trabalhador trabalhador
    {
        get => trabalhadorField;
        set
        {
            trabalhadorField = value;
            RaisePropertyChanged(nameof(trabalhador));
        }
    }

    public S2200Vinculo vinculo
    {
        get => vinculoField;
        set
        {
            vinculoField = value;
            RaisePropertyChanged(nameof(vinculo));
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
public partial class S2200Trabalhador : ESocialBindableObject
{
    private string cpfTrabField;
    private string nisTrabField;
    private string nmTrabField;
    private string sexoField;
    private RacaCor racaCorField = RacaCor.NaoInformado;
    private EstadoCivil estCivField = EstadoCivil.Solteiro;
    private bool estCivFieldSpecified;
    private GrauInstrucao grauInstrField = GrauInstrucao.Analfabeto;
    private SimNaoString indPriEmprField = SimNaoString.Nao;
    private string nmSocField;
    private S2200TrabalhadorDadosNascimento nascimentoField;

    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200TrabalhadorDocumentos documentosField;

    private S2200TrabalhadorEndereco enderecoField;
    private S2200TrabalhadorImigrante trabImigField;

    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200TrabalhadorEstrangeiro trabEstrangeiroField;

    private S2200TrabalhadorInfoDeficiencia infoDeficienciaField;
    private List<S2200Dependente> dependenteField = [];

    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200TrabalhadorDadosAposentadoria aposentadoriaField;

    private S2200Contato contatoField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public string nisTrab
    {
        get => nisTrabField;
        set
        {
            nisTrabField = value;
            RaisePropertyChanged(nameof(nisTrab));
        }
    }

    /// <summary>
    /// Nome do Trabalhador
    /// </summary>
    public string nmTrab
    {
        get => nmTrabField;
        set
        {
            nmTrabField = value;
            RaisePropertyChanged(nameof(nmTrab));
        }
    }

    public string sexo
    {
        get => sexoField;
        set
        {
            sexoField = value;
            RaisePropertyChanged(nameof(sexo));
        }
    }

    public RacaCor racaCor
    {
        get => racaCorField;
        set
        {
            racaCorField = value;
            RaisePropertyChanged(nameof(racaCor));
        }
    }

    public EstadoCivil estCiv
    {
        get => estCivField;
        set
        {
            estCivField = value;
            RaisePropertyChanged(nameof(estCiv));
        }
    }

    [XmlIgnore()]
    public bool estCivSpecified
    {
        get => estCivFieldSpecified;
        set
        {
            estCivFieldSpecified = value;
            RaisePropertyChanged(nameof(estCivSpecified));
        }
    }

    public GrauInstrucao grauInstr
    {
        get => grauInstrField;
        set
        {
            grauInstrField = value;
            RaisePropertyChanged(nameof(grauInstr));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public SimNaoString indPriEmpr
    {
        get => indPriEmprField;
        set
        {
            indPriEmprField = value;
            RaisePropertyChanged(nameof(indPriEmpr));
        }
    }

    /// <summary>
    /// Nome Social
    /// </summary>
    public string nmSoc
    {
        get => nmSocField;
        set
        {
            nmSocField = value;
            RaisePropertyChanged(nameof(nmSoc));
        }
    }

    public S2200TrabalhadorDadosNascimento nascimento
    {
        get => nascimentoField;
        set
        {
            nascimentoField = value;
            RaisePropertyChanged(nameof(nascimento));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200TrabalhadorDocumentos documentos
    {
        get => documentosField;
        set
        {
            documentosField = value;
            RaisePropertyChanged(nameof(documentos));
        }
    }

    public S2200TrabalhadorEndereco endereco
    {
        get => enderecoField;
        set
        {
            enderecoField = value;
            RaisePropertyChanged(nameof(endereco));
        }
    }

    public S2200TrabalhadorImigrante trabImig
    {
        get => trabImigField;
        set
        {
            trabImigField = value;
            RaisePropertyChanged(nameof(trabImig));
        }
    }


    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200TrabalhadorEstrangeiro trabEstrangeiro
    {
        get => trabEstrangeiroField;
        set
        {
            trabEstrangeiroField = value;
            RaisePropertyChanged(nameof(trabEstrangeiro));
        }
    }

    public S2200TrabalhadorInfoDeficiencia infoDeficiencia
    {
        get => infoDeficienciaField;
        set
        {
            infoDeficienciaField = value;
            RaisePropertyChanged(nameof(infoDeficiencia));
        }
    }

    [XmlElement("dependente")]
    public List<S2200Dependente> dependente
    {
        get => dependenteField;
        set
        {
            dependenteField = value;
            RaisePropertyChanged(nameof(dependente));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200TrabalhadorDadosAposentadoria aposentadoria
    {
        get => aposentadoriaField;
        set
        {
            aposentadoriaField = value;
            RaisePropertyChanged(nameof(aposentadoria));
        }
    }

    public S2200Contato contato
    {
        get => contatoField;
        set
        {
            contatoField = value;
            RaisePropertyChanged(nameof(contato));
        }
    }
}

/// <exclude />
public partial class S2200TrabalhadorDadosNascimento : ESocialBindableObject
{
    private DateTime dtNasctoField;
    private string codMunicField;
    private UFCadastro ufField;
    private bool ufFieldSpecified;
    private string paisNasctoField;
    private string paisNacField;
    private string nmMaeField;
    private string nmPaiField;

    [XmlElement(DataType = "date")]
    public DateTime dtNascto
    {
        get => dtNasctoField;
        set
        {
            dtNasctoField = value;
            RaisePropertyChanged(nameof(dtNascto));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    [XmlElement(DataType = "integer")]
    public string codMunic
    {
        get => codMunicField;
        set
        {
            codMunicField = value;
            RaisePropertyChanged(nameof(codMunic));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public UFCadastro uf
    {
        get => ufField;
        set
        {
            ufField = value;
            RaisePropertyChanged(nameof(uf));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    [XmlIgnore()]
    public bool ufSpecified
    {
        get => ufFieldSpecified;
        set
        {
            ufFieldSpecified = value;
            RaisePropertyChanged(nameof(ufSpecified));
        }
    }

    public string paisNascto
    {
        get => paisNasctoField;
        set
        {
            paisNasctoField = value;
            RaisePropertyChanged(nameof(paisNascto));
        }
    }

    public string paisNac
    {
        get => paisNacField;
        set
        {
            paisNacField = value;
            RaisePropertyChanged(nameof(paisNac));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public string nmMae
    {
        get => nmMaeField;
        set
        {
            nmMaeField = value;
            RaisePropertyChanged(nameof(nmMae));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public string nmPai
    {
        get => nmPaiField;
        set
        {
            nmPaiField = value;
            RaisePropertyChanged(nameof(nmPai));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200TrabalhadorDocumentos : ESocialBindableObject
{
    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200DocumentoCtps cTPSField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200DocumentoRic rICField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200DocumentoRg rgField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200DocumentoRne rNEField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200DocumentoOc ocField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200DocumentoCnh cNHField;

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200DocumentoCtps CTPS
    {
        get => cTPSField;
        set
        {
            cTPSField = value;
            RaisePropertyChanged(nameof(CTPS));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200DocumentoRic RIC
    {
        get => rICField;
        set
        {
            rICField = value;
            RaisePropertyChanged(nameof(RIC));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200DocumentoRg RG
    {
        get => rgField;
        set
        {
            rgField = value;
            RaisePropertyChanged(nameof(RG));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200DocumentoRne RNE
    {
        get => rNEField;
        set
        {
            rNEField = value;
            RaisePropertyChanged(nameof(RNE));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200DocumentoOc OC
    {
        get => ocField;
        set
        {
            ocField = value;
            RaisePropertyChanged(nameof(OC));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200DocumentoCnh CNH
    {
        get => cNHField;
        set
        {
            cNHField = value;
            RaisePropertyChanged(nameof(CNH));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200DocumentoCtps : ESocialBindableObject
{
    private string nrCtpsField;
    private string serieCtpsField;
    private UFCadastro ufCtpsField;

    public string nrCtps
    {
        get => nrCtpsField;
        set
        {
            nrCtpsField = value;
            RaisePropertyChanged(nameof(nrCtps));
        }
    }

    public string serieCtps
    {
        get => serieCtpsField;
        set
        {
            serieCtpsField = value;
            RaisePropertyChanged(nameof(serieCtps));
        }
    }

    public UFCadastro ufCtps
    {
        get => ufCtpsField;
        set
        {
            ufCtpsField = value;
            RaisePropertyChanged(nameof(ufCtps));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200DocumentoRic : ESocialBindableObject
{
    private string nrRicField;
    private string orgaoEmissorField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;

    public string nrRic
    {
        get => nrRicField;
        set
        {
            nrRicField = value;
            RaisePropertyChanged(nameof(nrRic));
        }
    }

    public string orgaoEmissor
    {
        get => orgaoEmissorField;
        set
        {
            orgaoEmissorField = value;
            RaisePropertyChanged(nameof(orgaoEmissor));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200DocumentoRg : ESocialBindableObject
{
    private string nrRgField;
    private string orgaoEmissorField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;

    public string nrRg
    {
        get => nrRgField;
        set
        {
            nrRgField = value;
            RaisePropertyChanged(nameof(nrRg));
        }
    }

    public string orgaoEmissor
    {
        get => orgaoEmissorField;
        set
        {
            orgaoEmissorField = value;
            RaisePropertyChanged(nameof(orgaoEmissor));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200DocumentoRne : ESocialBindableObject
{
    private string nrRneField;
    private string orgaoEmissorField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;

    public string nrRne
    {
        get => nrRneField;
        set
        {
            nrRneField = value;
            RaisePropertyChanged(nameof(nrRne));
        }
    }

    public string orgaoEmissor
    {
        get => orgaoEmissorField;
        set
        {
            orgaoEmissorField = value;
            RaisePropertyChanged(nameof(orgaoEmissor));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200DocumentoOc : ESocialBindableObject
{
    private string nrOcField;
    private string orgaoEmissorField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;
    private DateTime dtValidField;
    private bool dtValidFieldSpecified;

    public string nrOc
    {
        get => nrOcField;
        set
        {
            nrOcField = value;
            RaisePropertyChanged(nameof(nrOc));
        }
    }

    public string orgaoEmissor
    {
        get => orgaoEmissorField;
        set
        {
            orgaoEmissorField = value;
            RaisePropertyChanged(nameof(orgaoEmissor));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtValid
    {
        get => dtValidField;
        set
        {
            dtValidField = value;
            RaisePropertyChanged(nameof(dtValid));
        }
    }

    [XmlIgnore()]
    public bool dtValidSpecified
    {
        get => dtValidFieldSpecified;
        set
        {
            dtValidFieldSpecified = value;
            RaisePropertyChanged(nameof(dtValidSpecified));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200DocumentoCnh : ESocialBindableObject
{
    private string nrRegCnhField;
    private DateTime dtExpedField;
    private bool dtExpedFieldSpecified;
    private UFCadastro ufCnhField;
    private DateTime dtValidField;
    private DateTime dtPriHabField;
    private bool dtPriHabFieldSpecified;
    private string categoriaCnhField;

    public string nrRegCnh
    {
        get => nrRegCnhField;
        set
        {
            nrRegCnhField = value;
            RaisePropertyChanged(nameof(nrRegCnh));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtExped
    {
        get => dtExpedField;
        set
        {
            dtExpedField = value;
            RaisePropertyChanged(nameof(dtExped));
        }
    }

    [XmlIgnore()]
    public bool dtExpedSpecified
    {
        get => dtExpedFieldSpecified;
        set
        {
            dtExpedFieldSpecified = value;
            RaisePropertyChanged(nameof(dtExpedSpecified));
        }
    }

    public UFCadastro ufCnh
    {
        get => ufCnhField;
        set
        {
            ufCnhField = value;
            RaisePropertyChanged(nameof(ufCnh));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtValid
    {
        get => dtValidField;
        set
        {
            dtValidField = value;
            RaisePropertyChanged(nameof(dtValid));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtPriHab
    {
        get => dtPriHabField;
        set
        {
            dtPriHabField = value;
            RaisePropertyChanged(nameof(dtPriHab));
        }
    }

    [XmlIgnore()]
    public bool dtPriHabSpecified
    {
        get => dtPriHabFieldSpecified;
        set
        {
            dtPriHabFieldSpecified = value;
            RaisePropertyChanged(nameof(dtPriHabSpecified));
        }
    }

    public string categoriaCnh
    {
        get => categoriaCnhField;
        set
        {
            categoriaCnhField = value;
            RaisePropertyChanged(nameof(categoriaCnh));
        }
    }
}

/// <exclude />
public partial class S2200TrabalhadorEndereco : ESocialBindableObject
{
    private object itemField;

[XmlElement("brasil", typeof(EnderecoBrasileiro))]
[XmlElement("exterior", typeof(S2200TrabalhadorEnderecoExterior))]
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

public partial class S2200TrabalhadorImigrante : ESocialBindableObject
{
    private ImigranteTempoResidencia tmpResidField = ImigranteTempoResidencia.NA;
    private ImigranteCondicao condIngField = ImigranteCondicao.NA;

    public ImigranteTempoResidencia tmpResid
    {
        get => tmpResidField;
        set
        {
            tmpResidField = value;
            RaisePropertyChanged(nameof(tmpResid));
        }
    }

    [XmlIgnore()]
    public bool tmpResidSpecified
    {
        get => tmpResidField != ImigranteTempoResidencia.NA;
        set { }
    }

    public ImigranteCondicao condIng
    {
        get => condIngField;
        set 
        {
            condIngField = value;
            RaisePropertyChanged(nameof(condIng));
        }
    }

    [XmlIgnore()]
    public bool condIngSpecified
    {
        get => condIngField != ImigranteCondicao.NA;
        set { }
    }

}

/// <exclude />
public partial class S2200TrabalhadorEnderecoExterior : ESocialBindableObject
{
    private string paisResidField;
    private string dscLogradField;
    private string nrLogradField;
    private string complementoField;
    private string bairroField;
    private string nmCidField;
    private string codPostalField;

    public string paisResid
    {
        get => paisResidField;
        set
        {
            paisResidField = value;
            RaisePropertyChanged(nameof(paisResid));
        }
    }

    public string dscLograd
    {
        get => dscLogradField;
        set
        {
            dscLogradField = value;
            RaisePropertyChanged(nameof(dscLograd));
        }
    }

    public string nrLograd
    {
        get => nrLogradField;
        set
        {
            nrLogradField = value;
            RaisePropertyChanged(nameof(nrLograd));
        }
    }

    public string complemento
    {
        get => complementoField;
        set
        {
            complementoField = value;
            RaisePropertyChanged(nameof(complemento));
        }
    }

    public string bairro
    {
        get => bairroField;
        set
        {
            bairroField = value;
            RaisePropertyChanged(nameof(bairro));
        }
    }

    public string nmCid
    {
        get => nmCidField;
        set
        {
            nmCidField = value;
            RaisePropertyChanged(nameof(nmCid));
        }
    }

    public string codPostal
    {
        get => codPostalField;
        set
        {
            codPostalField = value;
            RaisePropertyChanged(nameof(codPostal));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200TrabalhadorEstrangeiro : ESocialBindableObject
{
    private DateTime dtChegadaField;
    private bool dtChegadaFieldSpecified;
    private ClasseTrabEstrangeiro classTrabEstrangField = ClasseTrabEstrangeiro.VistoPermanente;
    private SimNaoString casadoBrField = SimNaoString.Nao;
    private SimNaoString filhosBrField = SimNaoString.Nao;

    [XmlElement(DataType = "date")]
    public DateTime dtChegada
    {
        get => dtChegadaField;
        set
        {
            dtChegadaField = value;
            RaisePropertyChanged(nameof(dtChegada));
        }
    }

    [XmlIgnore()]
    public bool dtChegadaSpecified
    {
        get => dtChegadaFieldSpecified;
        set
        {
            dtChegadaFieldSpecified = value;
            RaisePropertyChanged(nameof(dtChegadaSpecified));
        }
    }

    public ClasseTrabEstrangeiro classTrabEstrang
    {
        get => classTrabEstrangField;
        set
        {
            classTrabEstrangField = value;
            RaisePropertyChanged(nameof(classTrabEstrang));
        }
    }

    public SimNaoString casadoBr
    {
        get => casadoBrField;
        set
        {
            casadoBrField = value;
            RaisePropertyChanged(nameof(casadoBr));
        }
    }

    public SimNaoString filhosBr
    {
        get => filhosBrField;
        set
        {
            filhosBrField = value;
            RaisePropertyChanged(nameof(filhosBr));
        }
    }
}

/// <exclude />
public partial class S2200TrabalhadorInfoDeficiencia : ESocialBindableObject
{
    private SimNaoString defFisicaField = SimNaoString.Nao;
    private SimNaoString defVisualField = SimNaoString.Nao;
    private SimNaoString defAuditivaField = SimNaoString.Nao;
    private SimNaoString defMentalField = SimNaoString.Nao;
    private SimNaoString defIntelectualField = SimNaoString.Nao;
    private SimNaoString reabReadapField = SimNaoString.Nao;
    private SimNaoString infoCotaField = SimNaoString.Nao;
    private string observacaoField;

    public SimNaoString defFisica
    {
        get => defFisicaField;
        set
        {
            defFisicaField = value;
            RaisePropertyChanged(nameof(defFisica));
        }
    }

    public SimNaoString defVisual
    {
        get => defVisualField;
        set
        {
            defVisualField = value;
            RaisePropertyChanged(nameof(defVisual));
        }
    }

    public SimNaoString defAuditiva
    {
        get => defAuditivaField;
        set
        {
            defAuditivaField = value;
            RaisePropertyChanged(nameof(defAuditiva));
        }
    }

    public SimNaoString defMental
    {
        get => defMentalField;
        set
        {
            defMentalField = value;
            RaisePropertyChanged(nameof(defMental));
        }
    }

    public SimNaoString defIntelectual
    {
        get => defIntelectualField;
        set
        {
            defIntelectualField = value;
            RaisePropertyChanged(nameof(defIntelectual));
        }
    }

    public SimNaoString reabReadap
    {
        get => reabReadapField;
        set
        {
            reabReadapField = value;
            RaisePropertyChanged(nameof(reabReadap));
        }
    }

    public SimNaoString infoCota
    {
        get => infoCotaField;
        set
        {
            infoCotaField = value;
            RaisePropertyChanged(nameof(infoCota));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

/// <exclude />
public partial class S2200Dependente : ESocialBindableObject
{
    private string tpDepField;
    private string nmDepField;
    private DateTime dtNasctoField;
    private string cpfDepField;
    private SimNaoString depIRRFField = SimNaoString.Nao;
    private SimNaoString depSFField = SimNaoString.Nao;
    private SimNaoString incTrabField = SimNaoString.Nao;
    private string sexoDepField;
    private string descrDepField;

    public string tpDep
    {
        get => tpDepField;
        set
        {
            tpDepField = value;
            RaisePropertyChanged(nameof(tpDep));
        }
    }

    public string nmDep
    {
        get => nmDepField;
        set
        {
            nmDepField = value;
            RaisePropertyChanged(nameof(nmDep));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtNascto
    {
        get => dtNasctoField;
        set
        {
            dtNasctoField = value;
            RaisePropertyChanged(nameof(dtNascto));
        }
    }

    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(cpfDep));
        }
    }

    public string sexoDep
    {
        get => sexoDepField;
        set 
        {
            sexoDepField = value;
            RaisePropertyChanged(nameof(sexoDep));
        }
    }

    public SimNaoString depIRRF
    {
        get => depIRRFField;
        set
        {
            depIRRFField = value;
            RaisePropertyChanged(nameof(depIRRF));
        }
    }

    public SimNaoString depSF
    {
        get => depSFField;
        set
        {
            depSFField = value;
            RaisePropertyChanged(nameof(depSF));
        }
    }

    public SimNaoString incTrab
    {
        get => incTrabField;
        set
        {
            incTrabField = value;
            RaisePropertyChanged(nameof(incTrab));
        }
    }

    public string descrDep
    {
        get => descrDepField;
        set 
        {
            descrDepField = value;
            RaisePropertyChanged(nameof(descrDep));
        }
    }

}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200TrabalhadorDadosAposentadoria : ESocialBindableObject
{
    private SimNaoString trabAposentField = SimNaoString.Nao;

    public SimNaoString trabAposent
    {
        get => trabAposentField;
        set
        {
            trabAposentField = value;
            RaisePropertyChanged(nameof(trabAposent));
        }
    }
}

/// <exclude />
public partial class S2200Contato : ESocialBindableObject
{
    private string fonePrincField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private string foneAlternatField;
    private string emailPrincField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private string emailAlternatField;

    public string fonePrinc
    {
        get => fonePrincField;
        set
        {
            fonePrincField = value;
            RaisePropertyChanged(nameof(fonePrinc));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public string foneAlternat
    {
        get => foneAlternatField;
        set
        {
            foneAlternatField = value;
            RaisePropertyChanged(nameof(foneAlternat));
        }
    }

    public string emailPrinc
    {
        get => emailPrincField;
        set
        {
            emailPrincField = value;
            RaisePropertyChanged(nameof(emailPrinc));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public string emailAlternat
    {
        get => emailAlternatField;
        set
        {
            emailAlternatField = value;
            RaisePropertyChanged(nameof(emailAlternat));
        }
    }
}

/// <exclude />
public partial class S2200Vinculo : ESocialBindableObject
{
    private string matriculaField;
    private VinculoTrabalhista tpRegTrabField = VinculoTrabalhista.CLT;
    private RegimePrevidenciario tpRegPrevField = RegimePrevidenciario.RGPS;

    [Obsolete("Descontinuado na versão S-1.02")]
    private string nrRecInfPrelimField;

    private SimNaoString cadIniField = SimNaoString.Nao;
    private S2200VinculoInfoRegimeTrab infoRegimeTrabField;
    private S2200VinculoInfoContrato infoContratoField;
    private S2200VinculoSucessaoVinc sucessaoVincField;
    private S2200VinculoTransfDom transfDomField;
    private S2200VinculoMudancaCPF mudancaCPFField;
    private S2200VinculoAfastamento afastamentoField;
    private S2200VinculoDesligamento desligamentoField;

    public string matricula
    {
        get => matriculaField;
        set
        {
            matriculaField = value;
            RaisePropertyChanged(nameof(matricula));
        }
    }

    public VinculoTrabalhista tpRegTrab
    {
        get => tpRegTrabField;
        set
        {
            tpRegTrabField = value;
            RaisePropertyChanged(nameof(tpRegTrab));
        }
    }

    public RegimePrevidenciario tpRegPrev
    {
        get => tpRegPrevField;
        set
        {
            tpRegPrevField = value;
            RaisePropertyChanged(nameof(tpRegPrev));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public string nrRecInfPrelim
    {
        get => nrRecInfPrelimField;
        set
        {
            nrRecInfPrelimField = value;
            RaisePropertyChanged(nameof(nrRecInfPrelim));
        }
    }

    public SimNaoString cadIni
    {
        get => cadIniField;
        set
        {
            cadIniField = value;
            RaisePropertyChanged(nameof(cadIni));
        }
    }

    public S2200VinculoInfoRegimeTrab infoRegimeTrab
    {
        get => infoRegimeTrabField;
        set
        {
            infoRegimeTrabField = value;
            RaisePropertyChanged(nameof(infoRegimeTrab));
        }
    }

    public S2200VinculoInfoContrato infoContrato
    {
        get => infoContratoField;
        set
        {
            infoContratoField = value;
            RaisePropertyChanged(nameof(infoContrato));
        }
    }

    public S2200VinculoSucessaoVinc sucessaoVinc
    {
        get => sucessaoVincField;
        set
        {
            sucessaoVincField = value;
            RaisePropertyChanged(nameof(sucessaoVinc));
        }
    }

    public S2200VinculoTransfDom transfDom
    {
        get => transfDomField;
        set
        {
            transfDomField = value;
            RaisePropertyChanged(nameof(transfDom));
        }
    }

    public S2200VinculoMudancaCPF mudancaCPF
    {
        get => mudancaCPFField;
        set
        {
            mudancaCPFField = value;
            RaisePropertyChanged(nameof(mudancaCPF));
        }
    }

    public S2200VinculoAfastamento afastamento
    {
        get => afastamentoField;
        set
        {
            afastamentoField = value;
            RaisePropertyChanged(nameof(afastamento));
        }
    }

    public S2200VinculoDesligamento desligamento
    {
        get => desligamentoField;
        set
        {
            desligamentoField = value;
            RaisePropertyChanged(nameof(desligamento));
        }
    }
}

/// <exclude />
public partial class S2200VinculoInfoRegimeTrab : ESocialBindableObject
{
    private object itemField;

    [XmlElement("infoCeletista", typeof(S2200InfoRegimeTrabInfoCeletista))]
    [XmlElement("infoEstatutario", typeof(S2200InfoRegimeTrabInfoEstatutario))]
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
public partial class S2200InfoRegimeTrabInfoCeletista : ESocialBindableObject
{
    private DateTime dtAdmField;
    private TipoAdmissaoCLT tpAdmissaoField = TipoAdmissaoCLT.Admissao;
    private IndicadorAdmissao indAdmissaoField = IndicadorAdmissao.Normal;
    private string nrProcTrabField;
    private VinculoRegimeJornada tpRegJorField = VinculoRegimeJornada.SubHorarioTrabalho;
    private NaturezaAtividade natAtividadeField = NaturezaAtividade.Urbano;
    private int dtBaseField;
    private bool dtBaseFieldSpecified;
    private string cnpjSindCategProfField;
    private S2200Fgts fGTSField;
    private S2200InfoCeletistaTrabTemporario trabTemporarioField;
    private S2200InfoCeletistaAprend aprendField;

    [XmlElement(DataType = "date")]
    public DateTime dtAdm
    {
        get => dtAdmField;
        set
        {
            dtAdmField = value;
            RaisePropertyChanged(nameof(dtAdm));
        }
    }

    public TipoAdmissaoCLT tpAdmissao
    {
        get => tpAdmissaoField;
        set
        {
            tpAdmissaoField = value;
            RaisePropertyChanged(nameof(tpAdmissao));
        }
    }

    public IndicadorAdmissao indAdmissao
    {
        get => indAdmissaoField;
        set
        {
            indAdmissaoField = value;
            RaisePropertyChanged(nameof(indAdmissao));
        }
    }

    public string nrProcTrab
    {
        get => nrProcTrabField;
        set
        { 
            nrProcTrabField = value; 
            RaisePropertyChanged(nameof(nrProcTrab));
        }
    }

    public VinculoRegimeJornada tpRegJor
    {
        get => tpRegJorField;
        set
        {
            tpRegJorField = value;
            RaisePropertyChanged(nameof(tpRegJor));
        }
    }

    public NaturezaAtividade natAtividade
    {
        get => natAtividadeField;
        set
        {
            natAtividadeField = value;
            RaisePropertyChanged(nameof(natAtividade));
        }
    }

    public sbyte dtBase
    {
        get => (sbyte)dtBaseField;
        set
        {
            dtBaseField = value;
            RaisePropertyChanged(nameof(dtBase));
        }
    }

    [XmlIgnore()]
    public bool dtBaseSpecified
    {
        get => dtBaseFieldSpecified;
        set
        {
            dtBaseFieldSpecified = value;
            RaisePropertyChanged(nameof(dtBaseSpecified));
        }
    }

    public string cnpjSindCategProf
    {
        get => cnpjSindCategProfField;
        set
        {
            cnpjSindCategProfField = value;
            RaisePropertyChanged(nameof(cnpjSindCategProf));
        }
    }

    private string matAnotJudField;

    public string matAnotJud
    {
        get => matAnotJudField;
        set 
        {
            matAnotJudField = value;
            RaisePropertyChanged(nameof(matAnotJud));
        }
    }

    public S2200Fgts FGTS
    {
        get => fGTSField;
        set
        {
            fGTSField = value;
            RaisePropertyChanged(nameof(FGTS));
        }
    }

    public S2200InfoCeletistaTrabTemporario trabTemporario
    {
        get => trabTemporarioField;
        set
        {
            trabTemporarioField = value;
            RaisePropertyChanged(nameof(trabTemporario));
        }
    }

    public S2200InfoCeletistaAprend aprend
    {
        get => aprendField;
        set
        {
            aprendField = value;
            RaisePropertyChanged(nameof(aprend));
        }
    }
}

/// <exclude />
public partial class S2200Fgts : ESocialBindableObject
{

    private bool opcFGTSFieldSpecified = false;

    [Obsolete("Descontinuado na versão S-1.02")]
    private OpcaoFGTS opcFGTSField = OpcaoFGTS.Optante;

    private DateTime dtOpcFGTSField;
    private bool dtOpcFGTSFieldSpecified;

    [Obsolete("Descontinuado na versão S-1.02")]
    public OpcaoFGTS opcFGTS
    {
        get => opcFGTSField;
        set
        {
            opcFGTSField = value;
            RaisePropertyChanged(nameof(opcFGTS));
        }
    }

    [XmlIgnore()]
    public bool opcFGTSSpecified
    {
        get => opcFGTSFieldSpecified;
        set
        {
            opcFGTSFieldSpecified = value;
            RaisePropertyChanged(nameof(opcFGTSSpecified));
        }
    }


    [XmlElement(DataType = "date")]
    public DateTime dtOpcFGTS
    {
        get => dtOpcFGTSField;
        set
        {
            dtOpcFGTSField = value;
            RaisePropertyChanged(nameof(dtOpcFGTS));
        }
    }

    [XmlIgnore()]
    public bool dtOpcFGTSSpecified
    {
        get => dtOpcFGTSFieldSpecified;
        set
        {
            dtOpcFGTSFieldSpecified = value;
            RaisePropertyChanged(nameof(dtOpcFGTSSpecified));
        }
    }
}

/// <exclude />
public partial class S2200InfoCeletistaTrabTemporario : ESocialBindableObject
{
    private TrabTemporarioHipotese hipLegField = TrabTemporarioHipotese.DemandaComplementar;
    private string justContrField;

    [Obsolete("Descontinuado na versão S-1.02")]
    private TrabTemporarioTpInclusao tpInclContrField = TrabTemporarioTpInclusao.Superior3Meses;

    [Obsolete("Descontinuado na versão S-1.02")]
    private bool tpInclContrFieldSpecified;

    private S2200TrabTemporarioTomadorServ ideTomadorServField;
    private S2200TrabTemporarioTrabSubstituido[] ideTrabSubstituidoField;

    public TrabTemporarioHipotese hipLeg
    {
        get => hipLegField;
        set
        {
            hipLegField = value;
            RaisePropertyChanged(nameof(hipLeg));
        }
    }

    public string justContr
    {
        get => justContrField;
        set
        {
            justContrField = value;
            RaisePropertyChanged(nameof(justContr));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public TrabTemporarioTpInclusao tpInclContr
    {
        get => tpInclContrField;
        set
        {
            tpInclContrField = value;
            RaisePropertyChanged(nameof(tpInclContr));
        }
    }

    [XmlIgnore()]
    [Obsolete("Descontinuado na versão S-1.02")]
    public bool tpInclContrSpecified
    {
        get => tpInclContrFieldSpecified;
        set
        {
            tpInclContrFieldSpecified = value;
            RaisePropertyChanged(nameof(tpInclContrSpecified));
        }
    }

    public S2200TrabTemporarioTomadorServ ideEstabVinc
    {
        get => ideTomadorServField;
        set
        {
            ideTomadorServField = value;
            RaisePropertyChanged(nameof(ideEstabVinc));
        }
    }

    [XmlElement("ideTrabSubstituido")]
    public S2200TrabTemporarioTrabSubstituido[] ideTrabSubstituido
    {
        get => ideTrabSubstituidoField;
        set
        {
            ideTrabSubstituidoField = value;
            RaisePropertyChanged(nameof(ideTrabSubstituido));
        }
    }
}

/// <exclude />
public partial class S2200TrabTemporarioTomadorServ : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;

    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200IdentificacaoEstabelecimentoVinculoTemporario ideEstabVincField;

    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
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

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200IdentificacaoEstabelecimentoVinculoTemporario ideEstabVinc
    {
        get => ideEstabVincField;
        set
        {
            ideEstabVincField = value;
            RaisePropertyChanged(nameof(ideEstabVinc));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200IdentificacaoEstabelecimentoVinculoTemporario : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;

    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
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
}

/// <exclude />
public partial class S2200TrabTemporarioTrabSubstituido : ESocialBindableObject
{
    private string cpfTrabSubstField;

    public string cpfTrabSubst
    {
        get => cpfTrabSubstField;
        set
        {
            cpfTrabSubstField = value;
            RaisePropertyChanged(nameof(cpfTrabSubst));
        }
    }
}

/// <exclude />
public partial class S2200InfoCeletistaAprend : ESocialBindableObject
{
    private IndicadorAprendiz indAprendField = IndicadorAprendiz.NA;
    private string cnpjEntQualFIeld;
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

    public IndicadorAprendiz indAprend
    {
        get => indAprendField;
        set
        { 
            indAprendField = value; 
            RaisePropertyChanged(nameof(indAprend));
        }
    }

    /// <summary>
    /// Informar o número de inscrição no CNPJ da entidade qualificadora, no caso de contratação direta.
    /// </summary>
    public string cnpjEntQual
    {
        get =>cnpjEntQualFIeld;
        set 
        { 
            cnpjEntQualFIeld = value;
            RaisePropertyChanged(nameof(cnpjEntQual));
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

    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

    private string cnpjPratField;

    /// <summary>
    /// Informar o número de inscrição no CNPJ do estabelecimento onde estão sendo realizadas as atividades práticas, quando ocorrer uma das seguintes situações: </br>
    /// a) Modalidade alternativa de cumprimento de cota de aprendizagem (neste caso, informar o CNPJ da entidade concedente da parte prática); </br>
    /// b) Realização das atividades práticas na empresa contratante do serviço terceirizado; </br>
    /// ) Centralização das atividades práticas em estabelecimento da própria empresa, diverso do estabelecimento responsável pelo cumprimento da cota.
    /// </summary>
    public string cnpjPrat
    {
        get => cnpjPratField; 
        set 
        {
            cnpjPratField = value; 
            RaisePropertyChanged(nameof(cnpjPrat));
        }
    }
}

/// <exclude />
public partial class S2200InfoRegimeTrabInfoEstatutario : ESocialBindableObject
{
    [Obsolete("Descontinuado na versão S-1.02")]
    private IndicadorAdmissaoEstatutario indProvimField = IndicadorAdmissaoEstatutario.Normal;

    private TipoProvimentoEstatutario tpProvField = TipoProvimentoEstatutario.NomeacaoEfetivo;

    [Obsolete("Descontinuado na versão S-1.02")]
    private DateTime dtNomeacaoField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private DateTime dtPosseField;

    private DateTime dtExercicioField;
    private PlanoSegregacaoMassa tpPlanRPField = PlanoSegregacaoMassa.PrevUnico;
    private bool tpPlanRPFieldSpecified;
    private SimNaoString indTetoRGPSField;
    private SimNaoString indAbonoPermField;
    private DateTime dtIniAbonoField;

    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200bInfoEstatutarioInfoDecJud infoDecJudField;

    [Obsolete("Descontinuado na versão S-1.02")]
    public IndicadorAdmissaoEstatutario indProvim
    {
        get => indProvimField;
        set
        {
            indProvimField = value;
            RaisePropertyChanged(nameof(indProvim));
        }
    }

    public TipoProvimentoEstatutario tpProv
    {
        get => tpProvField;
        set
        {
            tpProvField = value;
            RaisePropertyChanged(nameof(tpProv));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    [XmlElement(DataType = "date")]
    public DateTime dtNomeacao
    {
        get => dtNomeacaoField;
        set
        {
            dtNomeacaoField = value;
            RaisePropertyChanged(nameof(dtNomeacao));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    [XmlElement(DataType = "date")]
    public DateTime dtPosse
    {
        get => dtPosseField;
        set
        {
            dtPosseField = value;
            RaisePropertyChanged(nameof(dtPosse));
        }
    }


    [XmlElement(DataType = "date")]
    public DateTime dtExercicio
    {
        get => dtExercicioField;
        set
        {
            dtExercicioField = value;
            RaisePropertyChanged(nameof(dtExercicio));
        }
    }

    public PlanoSegregacaoMassa tpPlanRP
    {
        get => tpPlanRPField;
        set
        {
            tpPlanRPField = value;
            RaisePropertyChanged(nameof(tpPlanRP));
        }
    }

    [XmlIgnore()]
    public bool tpPlanRPSpecified
    {
        get => tpPlanRPFieldSpecified;
        set
        {
            tpPlanRPFieldSpecified = value;
            RaisePropertyChanged(nameof(tpPlanRPSpecified));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public S2200bInfoEstatutarioInfoDecJud infoDecJud
    {
        get => infoDecJudField;
        set
        {
            infoDecJudField = value;
            RaisePropertyChanged(nameof(infoDecJud));
        }
    }

    public SimNaoString indTetoRGPS
    {
        get => indTetoRGPSField;
        set
        {
            indTetoRGPSField = value;
            RaisePropertyChanged(nameof(indTetoRGPS));
        }
    }

    public SimNaoString indAbonoPerm
    {
        get => indAbonoPermField;
        set
        {
            indAbonoPermField = value;
            RaisePropertyChanged(nameof(indAbonoPerm));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtIniAbono
    {
        get => dtIniAbonoField;
        set
        {
            dtIniAbonoField = value;
            RaisePropertyChanged(nameof(dtIniAbono));
        }
    }

    [XmlIgnore]
    public bool dtIniAbonoSpecified
    {
        get => indAbonoPerm == SimNaoString.Sim;
        set { }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200bInfoEstatutarioInfoDecJud : ESocialBindableObject
{
    private string nrProcJudField;

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

/// <exclude />
public partial class S2200VinculoInfoContrato : ESocialBindableObject
{
    [Obsolete("Descontinuado na versão S-1.02")]
    private string codCargoField;

    private string nmCargooField;

    private string CBOCargoField;

    [Obsolete("Descontinuado na versão S-1.02")]
    private string codFuncaoField;

    [Obsolete("Descontinuado na versão S-1.02")]
    private string codCarreiraField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private DateTime dtIngrCarrField;
    [Obsolete("Descontinuado na versão S-1.02")]
    private bool dtIngrCarrFieldSpecified;

    private DateTime dtIngrCargoField;
    private string nmFuncaoField;
    private string CBOFuncaoField;
    private SimNaoString acumCargoField;
    private string codCategField;

    private S2200Remuneracao remuneracaoField;
    private S2200InfoContratoDuracao duracaoField;
    private S2200InfoContratoLocalTrabalho localTrabalhoField;
    private S2200ContratoHorContratual horContratualField;
	[Obsolete("Descontinuado na versão S-1.02")]
	private S2200FiliacaoSindical[] filiacaoSindicalField;
    private S2200AlvaraJudicial alvaraJudicialField;
    private S2200InfoContratoObservacoes[] observacoesField;

    [Obsolete("Descontinuado na versão S-1.02")]
    public string codCargo
    {
        get => codCargoField;
        set
        {
            codCargoField = value;
            RaisePropertyChanged(nameof(codCargo));
        }
    }

    public string nmCargo
    {
        get => nmCargooField;
        set
        {
            nmCargooField = value;
            RaisePropertyChanged(nameof(nmCargo));
        }
    }

    public string CBOCargo
    {
        get => CBOCargoField;
        set
        {
            CBOCargoField = value;
            RaisePropertyChanged(nameof(CBOCargo));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    public string codFuncao
    {
        get => codFuncaoField;
        set
        {
            codFuncaoField = value;
            RaisePropertyChanged(nameof(codFuncao));
        }
    }


    [Obsolete("Descontinuado na versão S-1.02")]
    public string codCarreira
    {
        get => codCarreiraField;
        set
        {
            codCarreiraField = value;
            RaisePropertyChanged(nameof(codCarreira));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    [XmlElement(DataType = "date")]
    public DateTime dtIngrCarr
    {
        get => dtIngrCarrField;
        set
        {
            dtIngrCarrField = value;
            RaisePropertyChanged(nameof(dtIngrCarr));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    [XmlIgnore()]
    public bool dtIngrCarrSpecified
    {
        get => dtIngrCarrFieldSpecified;
        set
        {
            dtIngrCarrFieldSpecified = value;
            RaisePropertyChanged(nameof(dtIngrCarrSpecified));
        }
    }

    public DateTime dtIngrCargo
    {
        get => dtIngrCargoField;
        set
        {
            dtIngrCargoField = value;
            RaisePropertyChanged(nameof(dtIngrCargo));
        }
    }

    public string nmFuncao
    {
        get => nmFuncaoField;
        set
        {
            nmFuncaoField = value;
            RaisePropertyChanged(nameof(nmFuncao));
        }
    }

    public string CBOFuncao
    {
        get => CBOFuncaoField;
        set
        {
            CBOFuncaoField = value; 
            RaisePropertyChanged(nameof(CBOFuncao));
        }
    }

    public SimNaoString acumCargo
    {
        get => acumCargoField;
        set
        {
            acumCargoField = value;
            RaisePropertyChanged(nameof(acumCargo));
        }
    }

    [XmlElement(DataType = "integer")]
    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }

    public S2200Remuneracao remuneracao
    {
        get => remuneracaoField;
        set
        {
            remuneracaoField = value;
            RaisePropertyChanged(nameof(remuneracao));
        }
    }

    public S2200InfoContratoDuracao duracao
    {
        get => duracaoField;
        set
        {
            duracaoField = value;
            RaisePropertyChanged(nameof(duracao));
        }
    }

    public S2200InfoContratoLocalTrabalho localTrabalho
    {
        get => localTrabalhoField;
        set
        {
            localTrabalhoField = value;
            RaisePropertyChanged(nameof(localTrabalho));
        }
    }

    public S2200ContratoHorContratual horContratual
    {
        get => horContratualField;
        set
        {
            horContratualField = value;
            RaisePropertyChanged(nameof(horContratual));
        }
    }

    [XmlElement("filiacaoSindical")]
	[Obsolete("Descontinuado na versão S-1.02")]
	public S2200FiliacaoSindical[] filiacaoSindical
    {
        get => filiacaoSindicalField;
        set
        {
            filiacaoSindicalField = value;
            RaisePropertyChanged(nameof(filiacaoSindical));
        }
    }

    public S2200AlvaraJudicial alvaraJudicial
    {
        get => alvaraJudicialField;
        set
        {
            alvaraJudicialField = value;
            RaisePropertyChanged(nameof(alvaraJudicial));
        }
    }

    [XmlElement("observacoes")]
    public S2200InfoContratoObservacoes[] observacoes
    {
        get => observacoesField;
        set
        {
            observacoesField = value;
            RaisePropertyChanged(nameof(observacoes));
        }
    }
}

/// <exclude />
public partial class S2200Remuneracao : ESocialBindableObject
{
    private decimal vrSalFxField;
    private UnidadeSalarial undSalFixoField = UnidadeSalarial.Mes;
    private string dscSalVarField;

    public decimal vrSalFx
    {
        get => vrSalFxField;
        set
        {
            vrSalFxField = value;
            RaisePropertyChanged(nameof(vrSalFx));
        }
    }

    public UnidadeSalarial undSalFixo
    {
        get => undSalFixoField;
        set
        {
            undSalFixoField = value;
            RaisePropertyChanged(nameof(undSalFixo));
        }
    }

    public string dscSalVar
    {
        get => dscSalVarField;
        set
        {
            dscSalVarField = value;
            RaisePropertyChanged(nameof(dscSalVar));
        }
    }
}

/// <exclude />
public partial class S2200InfoContratoDuracao : ESocialBindableObject
{
    private TipoContrato tpContrField = TipoContrato.Indeterminado;
    private DateTime dtTermField;
    private bool dtTermFieldSpecified;
    private SimNaoString clauAssecField = SimNaoString.Nao;
    private bool clauAssecFieldSpecified = false;
    private string objDetField;

    public sbyte tpContr
    {
        get => (sbyte)tpContrField;
        set
        {
            tpContrField = (TipoContrato)value;
            RaisePropertyChanged(nameof(tpContr));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtTerm
    {
        get => dtTermField;
        set
        {
            dtTermField = value;
            RaisePropertyChanged(nameof(dtTerm));
        }
    }

    [XmlIgnore()]
    public bool dtTermSpecified
    {
        get => dtTermFieldSpecified;
        set
        {
            dtTermFieldSpecified = value;
            RaisePropertyChanged(nameof(dtTermSpecified));
        }
    }

    public SimNaoString clauAssec
    {
        get => clauAssecField;
        set
        {
            clauAssecField = value;
            RaisePropertyChanged(nameof(clauAssec));
        }
    }

    [XmlIgnore()]
    public bool clauAssecSpecified
    {
        get => clauAssecFieldSpecified;
        set
        {
            clauAssecFieldSpecified = value;
            RaisePropertyChanged(nameof(clauAssecSpecified));
        }
    }


    public string objDet
    {
        get => objDetField;
        set
        {
            objDetField = value;
            RaisePropertyChanged(nameof(objDet));
        }
    }
}

/// <exclude />
public partial class S2200InfoContratoLocalTrabalho : ESocialBindableObject
{
    private S2200LocalTrabalho localTrabGeralField;
    private EnderecoBrasileiro localTrabDomField;

    public S2200LocalTrabalho localTrabGeral
    {
        get => localTrabGeralField;
        set
        {
            localTrabGeralField = value;
            RaisePropertyChanged(nameof(localTrabGeral));
        }
    }

    public EnderecoBrasileiro localTrabDom
    {
        get => localTrabDomField;
        set
        {
            localTrabDomField = value;
            RaisePropertyChanged(nameof(localTrabDom));
        }
    }
}

/// <exclude />
public partial class S2200LocalTrabalho : ESocialBindableObject
{
    private TipoInscricao tpInscField = TipoInscricao.CNPJ;
    private string nrInscField;
    private string descCompField;

    public sbyte tpInsc
    {
        get => (sbyte)tpInscField;
        set
        {
            tpInscField = (TipoInscricao)value;
            RaisePropertyChanged(nameof(tpInsc));
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

    public string descComp
    {
        get => descCompField;
        set
        {
            descCompField = value;
            RaisePropertyChanged(nameof(descComp));
        }
    }
}

/// <exclude />
public partial class S2200ContratoHorContratual : ESocialBindableObject
{
    private decimal qtdHrsSemField;
    private bool qtdHrsSemFieldSpecified;
    private TipoJornada tpJornadaField = TipoJornada.HorarioFixoFolgaFixa_Dom;
    private string dscTpJornField;
    private short tmpParcField;
    private SimNaoString horNoturnoField = SimNaoString.Nao;

    [Obsolete("Descontinuado na versão S-1.02")]
    private S2200Horario[] horarioField;

    public decimal qtdHrsSem
    {
        get => qtdHrsSemField;
        set
        {
            qtdHrsSemField = value;
            RaisePropertyChanged(nameof(qtdHrsSem));
        }
    }

    [XmlIgnore()]
    public bool qtdHrsSemSpecified
    {
        get => qtdHrsSemFieldSpecified;
        set
        {
            qtdHrsSemFieldSpecified = value;
            RaisePropertyChanged(nameof(qtdHrsSemSpecified));
        }
    }

    public TipoJornada tpJornada
    {
        get => tpJornadaField;
        set
        {
            tpJornadaField = value;
            RaisePropertyChanged(nameof(tpJornada));
        }
    }

    public short tmpParc
    {
        get => tmpParcField;
        set
        {
            tmpParcField = value;
            RaisePropertyChanged(nameof(tmpParc));
        }
    }

    [Obsolete("Descontinuado na versão S-1.02")]
    [XmlElement("horario")]
    public S2200Horario[] horario
    {
        get => horarioField;
        set
        {
            horarioField = value;
            RaisePropertyChanged(nameof(horario));
        }
    }

    public SimNaoString horNoturno
    {
        get => horNoturnoField;
        set
        {
            horNoturnoField = value;
            RaisePropertyChanged(nameof(horNoturno));
        }
    }

    public string dscTpJorn
    {
        get => dscTpJornField;
        set
        {
            dscTpJornField = value;
            RaisePropertyChanged(nameof(dscTpJorn));
        }
    }

}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200Horario : ESocialBindableObject
{
    private sbyte diaField; 
    private string codHorContratField;

    public sbyte dia
    {
        get => diaField;
        set
        {
            diaField = value;
            RaisePropertyChanged(nameof(dia));
        }
    }

    public string codHorContrat
    {
        get => codHorContratField;
        set
        {
            codHorContratField = value;
            RaisePropertyChanged(nameof(codHorContrat));
        }
    }
}

/// <exclude />
[Obsolete("Descontinuado na versão S-1.02")]
public partial class S2200FiliacaoSindical : ESocialBindableObject
{
    private string cnpjSindTrabField;

    public string cnpjSindTrab
    {
        get => cnpjSindTrabField;
        set
        {
            cnpjSindTrabField = value;
            RaisePropertyChanged(nameof(cnpjSindTrab));
        }
    }
}

/// <exclude />
public partial class S2200AlvaraJudicial : ESocialBindableObject
{
    private string nrProcJudField;

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

/// <exclude />
public partial class S2200InfoContratoObservacoes : ESocialBindableObject
{
    private string observacaoField;

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

public partial class S2200TreiCap : ESocialBindableObject
{
	private string codTreiCapField;

	public string codTreiCap
	{
		get => codTreiCapField;
		set
		{
			codTreiCapField = value;
			RaisePropertyChanged(nameof(codTreiCapField));
		}
	}
}

/// <exclude />
public partial class S2200VinculoSucessaoVinc : ESocialBindableObject
{
    private VinculoSucecssaoAnteriorTipo tpInscAntField = VinculoSucecssaoAnteriorTipo.CNPJ;
    private string cnpjEmpregAntField;
	private string nlrInscField;
	private string matricAntField;
    private DateTime dtTransfField;
    private string observacaoField;

    public VinculoSucecssaoAnteriorTipo tpInscAnt
    {
        get => tpInscAntField;
        set
        {
            tpInscAntField = value;
            RaisePropertyChanged(nameof(tpInscAnt));
        }
    }
	[Obsolete("Descontinuado na versão S-1.02")]
	public string cnpjEmpregAnt
    {
        get => cnpjEmpregAntField;
        set
        {
            cnpjEmpregAntField = value;
            RaisePropertyChanged(nameof(cnpjEmpregAnt));
        }
    }

	

	public string nlrInsc
	{
		get => nlrInscField;
		set
		{
			nlrInscField = value;
			RaisePropertyChanged(nameof(nlrInsc));
		}
	}

	public string matricAnt
    {
        get => matricAntField;
        set
        {
            matricAntField = value;
            RaisePropertyChanged(nameof(matricAnt));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtTransf
    {
        get => dtTransfField;
        set
        {
            dtTransfField = value;
            RaisePropertyChanged(nameof(dtTransf));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

/// <exclude />
public partial class S2200VinculoTransfDom : ESocialBindableObject
{
    private string cpfSubstituidoField;
    private string matricAntField;
    private DateTime dtTransfField;

    public string cpfSubstituido
    {
        get => cpfSubstituidoField;
        set
        {
            cpfSubstituidoField = value;
            RaisePropertyChanged(nameof(cpfSubstituido));
        }
    }

    public string matricAnt
    {
        get => matricAntField;
        set
        {
            matricAntField = value;
            RaisePropertyChanged(nameof(matricAnt));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtTransf
    {
        get => dtTransfField;
        set
        {
            dtTransfField = value;
            RaisePropertyChanged(nameof(dtTransf));
        }
    }
}

/// <exclude />
public partial class S2200VinculoMudancaCPF : ESocialBindableObject
{
    private string cpfAntField;
    private string matricAntField;
    private DateTime dtAltCPFField;
    private string observacaoField;

    public string cpfAnt
    {
        get => cpfAntField;
        set
        {
            cpfAntField = value;
            RaisePropertyChanged(nameof(cpfAnt));
        }
    }

    public string matricAnt
    {
        get => matricAntField;
        set
        {
            matricAntField = value;
            RaisePropertyChanged(nameof(matricAnt));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtAltCPF
    {
        get => dtAltCPFField;
        set
        {
            dtAltCPFField = value;
            RaisePropertyChanged(nameof(dtAltCPF));
        }
    }

    public string observacao
    {
        get => observacaoField;
        set
        {
            observacaoField = value;
            RaisePropertyChanged(nameof(observacao));
        }
    }
}

/// <exclude />
public partial class S2200VinculoAfastamento : ESocialBindableObject
{
    private DateTime dtIniAfastField;
    private string codMotAfastField;

    [XmlElement(DataType = "date")]
    public DateTime dtIniAfast
    {
        get => dtIniAfastField;
        set
        {
            dtIniAfastField = value;
            RaisePropertyChanged(nameof(dtIniAfast));
        }
    }

    public string codMotAfast
    {
        get => codMotAfastField;
        set
        {
            codMotAfastField = value;
            RaisePropertyChanged(nameof(codMotAfast));
        }
    }
}

/// <exclude />
public partial class S2200VinculoDesligamento : ESocialBindableObject
{
    private DateTime dtDesligField;

    [XmlElement(DataType = "date")]
    public DateTime dtDeslig
    {
        get => dtDesligField;
        set
        {
            dtDesligField = value;
            RaisePropertyChanged(nameof(dtDeslig));
        }
    }
}

public partial class S2200Vinculocessao : ESocialBindableObject
{
	private DateTime dtIniCessaoField;

	[XmlElement(DataType = "date")]
	public DateTime dtIniCessao
	{
		get => dtIniCessaoField;
		set
		{
			dtIniCessaoField = value;
			RaisePropertyChanged(nameof(dtIniCessao));
		}
	}
}