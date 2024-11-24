using System.Diagnostics;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Informações do Empregador/Contribuinte/Órgão Público
/// </summary>
/// <example>
/// ```csharp
///  evento.evtInfoEmpregador = new S1000InfoEmpregador()
///  {
///      ideEvento = new IdentificacaoCadastro()
///      {
///          tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///          procEmi = EmissorEvento.AppEmpregador,
///          verProc = "2.2"
///      },
///      ideEmpregador = new ()
///      {
///          tpInsc = PersonalidadeJuridica.CNPJ,
///          nrInsc = cnpjCpf.Substring(0, 8)
///      },
///      infoEmpregador = new S1000InfoEmpregadorAcao()
///      {
///          Item = new S1000Inclusao() // S1000Alteracao() ou S1000Exclusao()
///          {
///              idePeriodo = new IdePeriodo()
///              {
///                  iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
///              },
///              infoCadastro = new S1000InfoCadastro()
///              {
///                  classTrib = "99",
///                  indCoop = IndicadorCooperativa.Nao,
///                  indCoopSpecified = true,
///                  indConstr = SimNaoByte.Nao,
///                  indConstrSpecified = true,
///                  indDesFolha = SimNaoByte.Nao,
///                  indOpcCP = OpcaoTributacaoPrevidenciaria.FolhaPagto,
///                  indOpcCPSpecified = true,
///                  indPorte = SimNaoString.Sim,
///                  indOptRegEletron = SimNaoByte.Nao,
///                  indTribFolhaPisCofins = SimNaoString.Nao,
///                  dadosIsencao = new S1000DadosIsencao()
///                  {
///                      ideMinLei = "MTE",
///                      nrCertif = "abc",
///                      dtEmisCertif = DateTime.Now.AddYears(-1),
///                      dtVencCertif = DateTime.Now.AddYears(5),
///                      dtDou = DateTime.Now.AddYears(-1),
///                      pagDou = 1234
///                  }
///              }
///          }
///      }
///  };
/// ```
/// </example>
[Serializable()]
public partial class S1000 : Evento
{
    private S1000InfoEmpregador evtInfoEmpregadorField;
    private SignatureType signatureField;

    /// <remarks/>
    public S1000InfoEmpregador evtInfoEmpregador
    {
        get => evtInfoEmpregadorField;
        set
        {
            evtInfoEmpregadorField = value;
            RaisePropertyChanged(nameof(evtInfoEmpregador));
        }
    }

    /// <remarks/>
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
        => evtInfoEmpregadorField.Id = string.Format("ID{0}{1}{2}", (int)(evtInfoEmpregadorField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtInfoEmpregadorField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ() 
        => evtInfoEmpregadorField.ideEmpregador.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
   /// <exclude/>
    public override string TagId => nameof(evtInfoEmpregador);
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    //public override XmlSerializer DefineSerializer(bool includeNamespace = true)
    //{
    //    if (includeNamespace)
    //        return new(typeof(S1000), new XmlRootAttribute(Evento.root) { Namespace = $"http://www.esocial.gov.br/schema/evt/evtInfoEmpregador/{Versao}", IsNullable = false });

    //    return new(typeof(S1000), new XmlRootAttribute(Evento.root) { IsNullable = false });
    //}
}


/// <exclude />
public partial class S1000InfoEmpregador : ESocialBindableObject
{
    private IdentificacaoCadastro ideEventoField;
    private Empregador ideEmpregadorField;
    private S1000InfoEmpregadorAcao infoEmpregadorField;
    private string idField;

    public IdentificacaoCadastro ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged("ideEmpregador");
        }
    }

    public S1000InfoEmpregadorAcao infoEmpregador
    {
        get => infoEmpregadorField;
        set
        {
            infoEmpregadorField = value;
            RaisePropertyChanged("infoEmpregador");
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged("Id");
        }
    }
}

/// <exclude />
public partial class S1000InfoEmpregadorAcao : ESocialBindableObject
{
    private object itemField;

    [XmlElement("alteracao", typeof(S1000Alteracao))]
    [XmlElement("exclusao", typeof(S1000Exclusao))]
    [XmlElement("inclusao", typeof(S1000Inclusao))]
    public object Item
    {
        get => itemField;
        set
        {
            itemField = value;
            RaisePropertyChanged("Item");
        }
    }
}

/// <exclude />
public partial class S1000Inclusao : ESocialBindableObject
{
    private IdePeriodo idePeriodoField;
    private S1000InfoCadastro infoCadastroField;

    public IdePeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    public S1000InfoCadastro infoCadastro
    {
        get => infoCadastroField;
        set
        {
            infoCadastroField = value;
            RaisePropertyChanged("infoCadastro");
        }
    }
}

/// <exclude />
public partial class S1000Alteracao : ESocialBindableObject
{
    private IdePeriodo idePeriodoField;
    private S1000InfoCadastro infoCadastroField;
    private IdePeriodo novaValidadeField;

    public IdePeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    public S1000InfoCadastro infoCadastro
    {
        get => infoCadastroField;
        set
        {
            infoCadastroField = value;
            RaisePropertyChanged("infoCadastro");
        }
    }

    public IdePeriodo novaValidade
    {
        get => novaValidadeField;
        set
        {
            novaValidadeField = value;
            RaisePropertyChanged("novaValidade");
        }
    }
}

/// <exclude />
public partial class S1000Exclusao : ESocialBindableObject
{
    private IdePeriodo idePeriodoField;

   public IdePeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }
}

/// <exclude />
public partial class S1000InfoCadastro : ESocialBindableObject
{
    private string classTribField;
    private IndicadorCooperativa indCoopField = IndicadorCooperativa.Nao;
    private bool indCoopFieldSpecified = false;
    private SimNaoByte indConstrField = SimNaoByte.Nao;
    private bool indConstrFieldSpecified = false;
    private SimNaoByte indDesFolhaField = SimNaoByte.Nao;
    private OpcaoTributacaoPrevidenciaria indOpcCPField = OpcaoTributacaoPrevidenciaria.Comercializacao;
    private bool indOpcCPFieldSpecified = false;
    private SimNaoString indPorteField = SimNaoString.Nao;
    private SimNaoByte indOptRegEletronField = SimNaoByte.Nao;
    private string cnpjEFTField;
    private DateTime? dtTrans11096Field;
    private SimNaoString indTribFolhaPisCofinsField = SimNaoString.Nao;
    private S1000DadosIsencao dadosIsencaoField;
    private S1000InfoOrgInternacional infoOrgInternacionalField;

    public string classTrib
    {
        get => classTribField;
        set
        {
            classTribField = value;
            RaisePropertyChanged(nameof(classTrib));
        }
    }

    public IndicadorCooperativa indCoop
    {
        get => indCoopField;
        set
        {
            indCoopField = value;
            RaisePropertyChanged(nameof(indCoop));
        }
    }

    [XmlIgnore()]
    public bool indCoopSpecified
    {
        get => indCoopFieldSpecified;
        set
        {
            indCoopFieldSpecified = value;
            RaisePropertyChanged(nameof(indCoopSpecified));
        }
    }

    public SimNaoByte indConstr
    {
        get => indConstrField;
        set
        {
            indConstrField = value;
            RaisePropertyChanged(nameof(indConstr));
        }
    }

    [XmlIgnore()]
    public bool indConstrSpecified
    {
        get => indConstrFieldSpecified;
        set
        {
            indConstrFieldSpecified = value;
            RaisePropertyChanged(nameof(indConstrSpecified));
        }
    }

    public SimNaoByte indDesFolha
    {
        get => indDesFolhaField;
        set
        {
            indDesFolhaField = value;
            RaisePropertyChanged(nameof(indDesFolha));
        }
    }

    /// <summary>
    /// Indicativo da opção pelo produtor rural pela forma de tributação da contribuição previdenciária
    /// </summary>
    public OpcaoTributacaoPrevidenciaria indOpcCP
    {
        get => indOpcCPField;
        set
        {
            indOpcCPField = value;
            RaisePropertyChanged(nameof(indOpcCP));
        }
    }

    [XmlIgnore()]
    public bool indOpcCPSpecified
    {
        get => indOpcCPFieldSpecified;
        set
        {
            indOpcCPFieldSpecified = value;
            RaisePropertyChanged(nameof(indOpcCPSpecified));
        }
    }

    /// <summary>
    /// Indicativo de microempresa - ME ou empresa de pequeno porte - EPP
    /// </summary>
    public SimNaoString indPorte
    {
        get => indPorteField;
        set
        {
            indPorteField = value;
            RaisePropertyChanged(nameof(indPorte));
        }
    }

    public bool ShouldSerializeindPorte()
        => indPorte == SimNaoString.Sim;

    public SimNaoByte indOptRegEletron
    {
        get => indOptRegEletronField;
        set
        {
            indOptRegEletronField = value;
            RaisePropertyChanged(nameof(indOptRegEletron));
        }
    }

    public string cnpjEFR
    {
        get => cnpjEFTField;
        set
        {
            cnpjEFTField = value;
            RaisePropertyChanged(nameof(cnpjEFR));
        }
    }

    public DateTime? dtTrans11096
    { 
        get => dtTrans11096Field;
        set
        {
            dtTrans11096Field = value;
            RaisePropertyChanged(nameof(dtTrans11096Field));
        }
    }

    public bool ShouldSerializedtTrans11096()
        => dtTrans11096.HasValue;

    public SimNaoString indTribFolhaPisCofins
    {
        get => indTribFolhaPisCofinsField;
        set
        {
            indTribFolhaPisCofinsField = value;
            RaisePropertyChanged(nameof(indTribFolhaPisCofins));
        }
    }

    public bool ShouldSerializeindTribFolhaPisCofins()
        => indTribFolhaPisCofins == SimNaoString.Sim;

    public S1000DadosIsencao dadosIsencao
    {
        get => dadosIsencaoField;
        set
        {
            dadosIsencaoField = value;
            RaisePropertyChanged(nameof(dadosIsencao));
        }
    }

    public S1000InfoOrgInternacional infoOrgInternacional
    {
        get => infoOrgInternacionalField;
        set
        {
            infoOrgInternacionalField = value;
            RaisePropertyChanged(nameof(infoOrgInternacional));
        }
    }
}

/// <exclude />
public partial class S1000DadosIsencao : ESocialBindableObject
{
    private string ideMinLeiField;
    private string nrCertifField;
    private DateTime dtEmisCertifField;
    private DateTime dtVencCertifField;
    private string nrProtRenovField;
    private DateTime? dtProtRenovField;
    private DateTime? dtDouField;
    private int? pagDouField;

    public string ideMinLei
    {
        get => ideMinLeiField;
        set
        {
            ideMinLeiField = value;
            RaisePropertyChanged(nameof(ideMinLei));
        }
    }

    public string nrCertif
    {
        get => nrCertifField;
        set
        {
            nrCertifField = value;
            RaisePropertyChanged(nameof(nrCertif));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtEmisCertif
    {
        get => dtEmisCertifField;
        set
        {
            dtEmisCertifField = value;
            RaisePropertyChanged(nameof(dtEmisCertif));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime dtVencCertif
    {
        get => dtVencCertifField;
        set
        {
            dtVencCertifField = value;
            RaisePropertyChanged(nameof(dtVencCertif));
        }
    }

    public string nrProtRenov
    {
        get => nrProtRenovField;
        set
        {
            nrProtRenovField = value;
            RaisePropertyChanged(nameof(nrProtRenov));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? dtProtRenov
    {
        get => dtProtRenovField;
        set
        {
            dtProtRenovField = value;
            RaisePropertyChanged(nameof(dtProtRenov));
        }
    }

    public bool ShouldSerializedtProtRenov()
        => dtProtRenov.HasValue;

    [XmlElement(DataType = "date")]
    public DateTime? dtDou
    {
        get => dtDouField;
        set
        {
            dtDouField = value;
            RaisePropertyChanged(nameof(dtDou));
        }
    }

    public bool ShouldSerializedtDou()
        => dtDou.HasValue;

    public int? pagDou
    {
        get => pagDouField;
        set
        {
            pagDouField = value;
            RaisePropertyChanged(nameof(pagDou));
        }
    }

    public bool ShouldSerializepagDou()
        => pagDou.HasValue;
}

/// <exclude />
public partial class S1000InfoOrgInternacional : ESocialBindableObject
{
    private sbyte indAcordoIsenMultaField;

    public sbyte indAcordoIsenMulta
    {
        get => indAcordoIsenMultaField;
        set
        {
            indAcordoIsenMultaField = value;
            RaisePropertyChanged(nameof(indAcordoIsenMulta));
        }
    }
}
