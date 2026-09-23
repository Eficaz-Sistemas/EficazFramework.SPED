using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Alteração de Dados Cadastrais do Trabalhador
/// </summary>
/// <example>
/// ```csharp
/// evento.evtAltCadastral = new S2205AltCadastral()
/// {
///     ideEvento = new IdeEventoNaoPeriodico()
///     {
///         indRetif = IndicadorRetificacao.Original,
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "2.2"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = cnpjCpf.Substring(0, 8)
///     },
///     ideTrabalhador = new S2205IdeTrabalhador()
///     {
///         cpfTrab = "12345678901"
///     },
///     alteracao = new S2205Alteracao()
///     {
///         dtAlteracao = DateTime.Now.Date,
///         dadosTrabalhador = new S2205DadosTrabalhador()
///         {
///             nmTrab = "João da Silva",
///             sexo = Sexo.Masculino,
///             racaCor = RacaCor.NaoInformado,
///             estCiv = EstadoCivil.Solteiro,
///             estCivSpecified = true,
///             grauInstr = GrauInstrucao.MedioCompleto,
///             nmSoc = "João",
///             paisNac = "105",
///             endereco = new S2205Endereco()
///             {
///                 Item = new EnderecoBrasileiro()
///                 {
///                     tpLograd = "Rua",
///                     dscLograd = "1",
///                     nrLograd = "123",
///                     complemento = "Apt 1",
///                     bairro = "Centro",
///                     cep = "12345678",
///                     codMunic = "1234567",
///                     uf = UFCadastro.SP
///                 }
///             },
///             trabImig = new S2205TrabImig()
///             {
///                 tmpResid = ImigranteTempoResidencia.Indeterminado,
///                 condIng = ImigranteCondicao.Refugidao
///             },
///             infoDeficiencia = new S2205InfoDeficiencia()
///             {
///                 defFisica = SimNaoString.Nao,
///                 defVisual = SimNaoString.Nao,
///                 defAuditiva = SimNaoString.Nao,
///                 defMental = SimNaoString.Nao,
///                 defIntelectual = SimNaoString.Nao,
///                 reabReadap = SimNaoString.Nao,
///                 infoCota = SimNaoString.Nao,
///                 observacao = "Nenhuma"
///             },
///             dependente = new List<S2205Dependente>()
///             {
///                 new S2205Dependente()
///                 {
///                     tpDep = "01",
///                     nmDep = "Filho",
///                     dtNascto = DateTime.Now.AddYears(-10),
///                     cpfDep = "12345678901",
///                     sexoDep = Sexo.Masculino,
///                     sexoDepSpecified = true,
///                     depIRRF = SimNaoString.Sim,
///                     depSF = SimNaoString.Sim,
///                     incTrab = SimNaoString.Nao,
///                     descrDep = "Filho"
///                 }
///             },
///             contato = new S2205Contato()
///             {
///                 fonePrinc = "11999999999",
///                 emailPrinc = "joao@email.com"
///             }
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S2205 : Evento
{
    private S2205AltCadastral evtAltCadastralField;
    private SignatureType signatureField;

    [XmlElement()]
    public S2205AltCadastral evtAltCadastral
    {
        get => evtAltCadastralField;
        set
        {
            evtAltCadastralField = value;
            RaisePropertyChanged(nameof(evtAltCadastral));
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
        => evtAltCadastralField.Id = string.Format("ID{0}{1}{2}", (int)(evtAltCadastralField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAltCadastralField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtAltCadastralField.ideEmpregador.nrInsc;

    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => Evento.root;
    /// <exclude/>
    public override string TagId => nameof(evtAltCadastral);
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2205AltCadastral : ESocialBindableObject
{
    private IdeEventoNaoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S2205IdeTrabalhador ideTrabalhadorField;
    private S2205Alteracao alteracaoField;
    private string idField;

    [XmlElement()]
    public IdeEventoNaoPeriodico ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    [XmlElement()]
    public Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    [XmlElement()]
    public S2205IdeTrabalhador ideTrabalhador
    {
        get => ideTrabalhadorField;
        set
        {
            ideTrabalhadorField = value;
            RaisePropertyChanged(nameof(ideTrabalhador));
        }
    }

    [XmlElement()]
    public S2205Alteracao alteracao
    {
        get => alteracaoField;
        set
        {
            alteracaoField = value;
            RaisePropertyChanged(nameof(alteracao));
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
public partial class S2205IdeTrabalhador : ESocialBindableObject
{
    private string cpfTrabField;

    [XmlElement()]
    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }
}

/// <exclude />
public partial class S2205Alteracao : ESocialBindableObject
{
    private DateTime dtAlteracaoField;
    private S2205DadosTrabalhador dadosTrabalhadorField;

    [XmlElement(DataType = "date")]
    public DateTime dtAlteracao
    {
        get => dtAlteracaoField;
        set
        {
            dtAlteracaoField = value;
            RaisePropertyChanged(nameof(dtAlteracao));
        }
    }

    [XmlElement()]
    public S2205DadosTrabalhador dadosTrabalhador
    {
        get => dadosTrabalhadorField;
        set
        {
            dadosTrabalhadorField = value;
            RaisePropertyChanged(nameof(dadosTrabalhador));
        }
    }
}

/// <exclude />
public partial class S2205DadosTrabalhador : ESocialBindableObject
{
    private string nmTrabField;
    private Sexo sexoField;
    private RacaCor racaCorField;
    private EstadoCivil estCivField;
    private bool estCivFieldSpecified;
    private GrauInstrucao grauInstrField;
    private string nmSocField;
    private string paisNacField;
    private S2205Endereco enderecoField;
    private S2205TrabImig trabImigField;
    private S2205InfoDeficiencia infoDeficienciaField;
    private List<S2205Dependente> dependenteField;
    private S2205Contato contatoField;

    [XmlElement()]
    public string nmTrab
    {
        get => nmTrabField;
        set
        {
            nmTrabField = value;
            RaisePropertyChanged(nameof(nmTrab));
        }
    }

    [XmlElement()]
    public Sexo sexo
    {
        get => sexoField;
        set
        {
            sexoField = value;
            RaisePropertyChanged(nameof(sexo));
        }
    }

    [XmlElement()]
    public RacaCor racaCor
    {
        get => racaCorField;
        set
        {
            racaCorField = value;
            RaisePropertyChanged(nameof(racaCor));
        }
    }

    [XmlElement()]
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

    [XmlElement()]
    public GrauInstrucao grauInstr
    {
        get => grauInstrField;
        set
        {
            grauInstrField = value;
            RaisePropertyChanged(nameof(grauInstr));
        }
    }

    [XmlElement()]
    public string nmSoc
    {
        get => nmSocField;
        set
        {
            nmSocField = value;
            RaisePropertyChanged(nameof(nmSoc));
        }
    }

    [XmlElement()]
    public string paisNac
    {
        get => paisNacField;
        set
        {
            paisNacField = value;
            RaisePropertyChanged(nameof(paisNac));
        }
    }

    [XmlElement()]
    public S2205Endereco endereco
    {
        get => enderecoField;
        set
        {
            enderecoField = value;
            RaisePropertyChanged(nameof(endereco));
        }
    }

    [XmlElement()]
    public S2205TrabImig trabImig
    {
        get => trabImigField;
        set
        {
            trabImigField = value;
            RaisePropertyChanged(nameof(trabImig));
        }
    }

    [XmlElement()]
    public S2205InfoDeficiencia infoDeficiencia
    {
        get => infoDeficienciaField;
        set
        {
            infoDeficienciaField = value;
            RaisePropertyChanged(nameof(infoDeficiencia));
        }
    }

    [XmlElement("dependente")]
    public List<S2205Dependente> dependente
    {
        get => dependenteField;
        set
        {
            dependenteField = value;
            RaisePropertyChanged(nameof(dependente));
        }
    }

    [XmlElement()]
    public S2205Contato contato
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
public partial class S2205Endereco : ESocialBindableObject
{
    private object itemField;

    [XmlElement("brasil", typeof(EnderecoBrasileiro))]
    [XmlElement("exterior", typeof(S2205EnderecoExterior))]
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
public partial class S2205EnderecoExterior : ESocialBindableObject
{
    private string paisResidField;
    private string dscLogradField;
    private string nrLogradField;
    private string complementoField;
    private string bairroField;
    private string nmCidField;
    private string codPostalField;

    [XmlElement()]
    public string paisResid
    {
        get => paisResidField;
        set
        {
            paisResidField = value;
            RaisePropertyChanged(nameof(paisResid));
        }
    }

    [XmlElement()]
    public string dscLograd
    {
        get => dscLogradField;
        set
        {
            dscLogradField = value;
            RaisePropertyChanged(nameof(dscLograd));
        }
    }

    [XmlElement()]
    public string nrLograd
    {
        get => nrLogradField;
        set
        {
            nrLogradField = value;
            RaisePropertyChanged(nameof(nrLograd));
        }
    }

    [XmlElement()]
    public string complemento
    {
        get => complementoField;
        set
        {
            complementoField = value;
            RaisePropertyChanged(nameof(complemento));
        }
    }

    [XmlElement()]
    public string bairro
    {
        get => bairroField;
        set
        {
            bairroField = value;
            RaisePropertyChanged(nameof(bairro));
        }
    }

    [XmlElement()]
    public string nmCid
    {
        get => nmCidField;
        set
        {
            nmCidField = value;
            RaisePropertyChanged(nameof(nmCid));
        }
    }

    [XmlElement()]
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
public partial class S2205TrabImig : ESocialBindableObject
{
    private ImigranteTempoResidencia tmpResidField = ImigranteTempoResidencia.NA;
    private ImigranteCondicao condIngField = ImigranteCondicao.NA;

    [XmlElement()]
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
    public bool tmpResidSpecified => tmpResidField != ImigranteTempoResidencia.NA;

    [XmlElement()]
    public ImigranteCondicao condIng
    {
        get => condIngField;
        set
        {
            condIngField = value;
            RaisePropertyChanged(nameof(condIng));
        }
    }
}

/// <exclude />
public partial class S2205InfoDeficiencia : ESocialBindableObject
{
    private SimNaoString defFisicaField = SimNaoString.Nao;
    private SimNaoString defVisualField = SimNaoString.Nao;
    private SimNaoString defAuditivaField = SimNaoString.Nao;
    private SimNaoString defMentalField = SimNaoString.Nao;
    private SimNaoString defIntelectualField = SimNaoString.Nao;
    private SimNaoString reabReadapField = SimNaoString.Nao;
    private SimNaoString infoCotaField = SimNaoString.Nao;
    private string observacaoField;

    [XmlElement()]
    public SimNaoString defFisica
    {
        get => defFisicaField;
        set
        {
            defFisicaField = value;
            RaisePropertyChanged(nameof(defFisica));
        }
    }

    [XmlElement()]
    public SimNaoString defVisual
    {
        get => defVisualField;
        set
        {
            defVisualField = value;
            RaisePropertyChanged(nameof(defVisual));
        }
    }

    [XmlElement()]
    public SimNaoString defAuditiva
    {
        get => defAuditivaField;
        set
        {
            defAuditivaField = value;
            RaisePropertyChanged(nameof(defAuditiva));
        }
    }

    [XmlElement()]
    public SimNaoString defMental
    {
        get => defMentalField;
        set
        {
            defMentalField = value;
            RaisePropertyChanged(nameof(defMental));
        }
    }

    [XmlElement()]
    public SimNaoString defIntelectual
    {
        get => defIntelectualField;
        set
        {
            defIntelectualField = value;
            RaisePropertyChanged(nameof(defIntelectual));
        }
    }

    [XmlElement()]
    public SimNaoString reabReadap
    {
        get => reabReadapField;
        set
        {
            reabReadapField = value;
            RaisePropertyChanged(nameof(reabReadap));
        }
    }

    [XmlElement()]
    public SimNaoString infoCota
    {
        get => infoCotaField;
        set
        {
            infoCotaField = value;
            RaisePropertyChanged(nameof(infoCota));
        }
    }

    public bool ShouldSerializeinfoCota() => infoCota != SimNaoString.Nao;

    [XmlElement()]
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
public partial class S2205Dependente : ESocialBindableObject
{
    private string tpDepField;
    private string nmDepField;
    private DateTime dtNasctoField;
    private string cpfDepField;
    private Sexo sexoDepField;
    private bool sexoDepFieldSpecified;
    private SimNaoString depIRRFField = SimNaoString.Nao;
    private SimNaoString depSFField = SimNaoString.Nao;
    private SimNaoString incTrabField = SimNaoString.Nao;
    private string descrDepField;

    [XmlElement()]
    public string tpDep
    {
        get => tpDepField;
        set
        {
            tpDepField = value;
            RaisePropertyChanged(nameof(tpDep));
        }
    }

    [XmlElement()]
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

    [XmlElement()]
    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged(nameof(cpfDep));
        }
    }

    [XmlElement()]
    public Sexo sexoDep
    {
        get => sexoDepField;
        set
        {
            sexoDepField = value;
            RaisePropertyChanged(nameof(sexoDep));
        }
    }

    [XmlIgnore()]
    public bool sexoDepSpecified
    {
        get => sexoDepFieldSpecified;
        set
        {
            sexoDepFieldSpecified = value;
            RaisePropertyChanged(nameof(sexoDepSpecified));
        }
    }

    [XmlElement()]
    public SimNaoString depIRRF
    {
        get => depIRRFField;
        set
        {
            depIRRFField = value;
            RaisePropertyChanged(nameof(depIRRF));
        }
    }

    [XmlElement()]
    public SimNaoString depSF
    {
        get => depSFField;
        set
        {
            depSFField = value;
            RaisePropertyChanged(nameof(depSF));
        }
    }

    [XmlElement()]
    public SimNaoString incTrab
    {
        get => incTrabField;
        set
        {
            incTrabField = value;
            RaisePropertyChanged(nameof(incTrab));
        }
    }

    public bool ShouldSerializeincTrab() => incTrab != SimNaoString.Nao;

    [XmlElement()]
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
public partial class S2205Contato : ESocialBindableObject
{
    private string fonePrincField;
    private string emailPrincField;

    [XmlElement()]
    public string fonePrinc
    {
        get => fonePrincField;
        set
        {
            fonePrincField = value;
            RaisePropertyChanged(nameof(fonePrinc));
        }
    }

    [XmlElement()]
    public string emailPrinc
    {
        get => emailPrincField;
        set
        {
            emailPrincField = value;
            RaisePropertyChanged(nameof(emailPrinc));
        }
    }
}
