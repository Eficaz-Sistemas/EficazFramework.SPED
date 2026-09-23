using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Alteração de Contrato de Trabalho/Relação Estatutária
/// </summary>
/// <example>
/// ```csharp
/// var evento = new S2206()
/// {
///     evtAltContratual = new S2206AltContratual()
///     {
///         ideEvento = new IdeEventoNaoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppEmpregador,
///             verProc = "2.0"
///         },
///         ideEmpregador = new Empregador()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678"
///         },
///         ideVinculo = new S2206IdeVinculo()
///         {
///             cpfTrab = "12345678901",
///             matricula = "123456"
///         },
///         altContratual = new S2206Alteracao()
///         {
///             dtAlteracao = new DateTime(2024, 5, 1),
///             dscAlt = "Alteração de cargo",
///             vinculo = new S2206Vinculo()
///             {
///                 tpRegPrev = RegimePrevidenciario.RGPS,
///                 infoRegimeTrab = new S2206InfoRegimeTrab()
///                 {
///                     infoCeletista = new S2206InfoCeletista()
///                     {
///                         tpRegJor = VinculoRegimeJornada.SubmetidoHorarioTrabalho,
///                         natAtividade = NaturezaAtividade.Urbano,
///                         dtBase = 5,
///                         cnpjSindCategProf = "11111111111111"
///                     }
///                 },
///                 infoContrato = new S2206InfoContrato()
///                 {
///                     codCateg = "101",
///                     nmCargo = "Desenvolvedor Pleno",
///                     CBOCargo = "212405",
///                     remuneracao = new S2206Remuneracao()
///                     {
///                         vrSalFx = 4500.00,
///                         undSalFixo = UnidadeSalarial.PorMes
///                     },
///                     duracao = new S2206Duracao()
///                     {
///                         tpContr = TipoContrato.PrazoIndeterminado
///                     },
///                     localTrabalho = new S2206LocalTrabalho()
///                     {
///                         localTrabGeral = new S2206LocalTrabGeral()
///                         {
///                             tpInsc = PersonalidadeJuridica.CNPJ,
///                             nrInsc = "12345678000100"
///                         }
///                     },
///                     horContratual = new S2206HorContratual()
///                     {
///                         qtdHrsSem = 44,
///                         tpJornada = TipoJornada.DemaisTipos,
///                         tmpParc = 0,
///                         horNoturno = SimNaoString.Nao,
///                         dscJorn = "08:00 as 12:00 e das 13:00 as 18:00"
///                     }
///                 }
///             }
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S2206 : Evento
{
    private S2206AltContratual evtAltContratualField;
    private SignatureType signatureField;

    public S2206AltContratual evtAltContratual
    {
        get => evtAltContratualField;
        set
        {
            evtAltContratualField = value;
            RaisePropertyChanged(nameof(evtAltContratual));
        }
    }

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
    {
        evtAltContratualField ??= new S2206AltContratual();
        evtAltContratualField.Id = string.Format("ID{0}{1}{2}", (int)(evtAltContratualField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAltContratualField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
        => evtAltContratualField?.ideEmpregador?.nrInsc;

    public override bool EmptyURI => true;

    public override bool SignAsSHA256 => true;

    public override string TagToSign => Evento.root;

    public override string TagId => "evtAltContratual";
}

/// <exclude/>
public partial class S2206AltContratual : ESocialBindableObject
{
    private IdeEventoNaoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S2206IdeVinculo ideVinculoField;
    private S2206Alteracao altContratualField;
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

    public S2206IdeVinculo ideVinculo
    {
        get => ideVinculoField;
        set
        {
            ideVinculoField = value;
            RaisePropertyChanged(nameof(ideVinculo));
        }
    }

    public S2206Alteracao altContratual
    {
        get => altContratualField;
        set
        {
            altContratualField = value;
            RaisePropertyChanged(nameof(altContratual));
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
public partial class S2206IdeVinculo : ESocialBindableObject
{
    private string cpfTrabField;
    private string matriculaField;

    public string cpfTrab
    {
        get => cpfTrabField;
        set
        {
            cpfTrabField = value;
            RaisePropertyChanged(nameof(cpfTrab));
        }
    }

    public string matricula
    {
        get => matriculaField;
        set
        {
            matriculaField = value;
            RaisePropertyChanged(nameof(matricula));
        }
    }
}

/// <exclude/>
public partial class S2206Alteracao : ESocialBindableObject
{
    private DateTime dtAlteracaoField;
    private DateTime? dtEfField;
    private string dscAltField;
    private S2206Vinculo vinculoField;

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

    [XmlElement(DataType = "date")]
    public DateTime? dtEf
    {
        get => dtEfField;
        set
        {
            dtEfField = value;
            RaisePropertyChanged(nameof(dtEf));
        }
    }
    public bool ShouldSerializedtEf() => dtEf.HasValue;

    public string dscAlt
    {
        get => dscAltField;
        set
        {
            dscAltField = value;
            RaisePropertyChanged(nameof(dscAlt));
        }
    }

    public S2206Vinculo vinculo
    {
        get => vinculoField;
        set
        {
            vinculoField = value;
            RaisePropertyChanged(nameof(vinculo));
        }
    }
}

/// <exclude/>
public partial class S2206Vinculo : ESocialBindableObject
{
    private RegimePrevidenciario tpRegPrevField;
    private S2206InfoRegimeTrab infoRegimeTrabField;
    private S2206InfoContrato infoContratoField;

    public RegimePrevidenciario tpRegPrev
    {
        get => tpRegPrevField;
        set
        {
            tpRegPrevField = value;
            RaisePropertyChanged(nameof(tpRegPrev));
        }
    }

    public S2206InfoRegimeTrab infoRegimeTrab
    {
        get => infoRegimeTrabField;
        set
        {
            infoRegimeTrabField = value;
            RaisePropertyChanged(nameof(infoRegimeTrab));
        }
    }

    public S2206InfoContrato infoContrato
    {
        get => infoContratoField;
        set
        {
            infoContratoField = value;
            RaisePropertyChanged(nameof(infoContrato));
        }
    }
}

/// <exclude/>
public partial class S2206InfoRegimeTrab : ESocialBindableObject
{
    private S2206InfoCeletista infoCeletistaField;
    private S2206InfoEstatutario infoEstatutarioField;

    public S2206InfoCeletista infoCeletista
    {
        get => infoCeletistaField;
        set
        {
            infoCeletistaField = value;
            RaisePropertyChanged(nameof(infoCeletista));
        }
    }

    public S2206InfoEstatutario infoEstatutario
    {
        get => infoEstatutarioField;
        set
        {
            infoEstatutarioField = value;
            RaisePropertyChanged(nameof(infoEstatutario));
        }
    }
}

/// <exclude/>
public partial class S2206InfoCeletista : ESocialBindableObject
{
    private VinculoRegimeJornada tpRegJorField;
    private NaturezaAtividade natAtividadeField;
    private byte? dtBaseField;
    private string cnpjSindCategProfField;
    private S2206TrabTemporario trabTemporarioField;
    private S2206Aprend aprendField;

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

    public byte? dtBase
    {
        get => dtBaseField;
        set
        {
            dtBaseField = value;
            RaisePropertyChanged(nameof(dtBase));
        }
    }
    public bool ShouldSerializedtBase() => dtBase.HasValue;

    public string cnpjSindCategProf
    {
        get => cnpjSindCategProfField;
        set
        {
            cnpjSindCategProfField = value;
            RaisePropertyChanged(nameof(cnpjSindCategProf));
        }
    }

    public S2206TrabTemporario trabTemporario
    {
        get => trabTemporarioField;
        set
        {
            trabTemporarioField = value;
            RaisePropertyChanged(nameof(trabTemporario));
        }
    }

    public S2206Aprend aprend
    {
        get => aprendField;
        set
        {
            aprendField = value;
            RaisePropertyChanged(nameof(aprend));
        }
    }
}

/// <exclude/>
public partial class S2206TrabTemporario : ESocialBindableObject
{
    private string justProrrField;

    public string justProrr
    {
        get => justProrrField;
        set
        {
            justProrrField = value;
            RaisePropertyChanged(nameof(justProrr));
        }
    }
}

/// <exclude/>
public partial class S2206Aprend : ESocialBindableObject
{
    private byte indAprendField;
    private string cnpjEntQualField;
    private TipoInscricao? tpInscField;
    private string nrInscField;
    private string cnpjPratField;

    public byte indAprend
    {
        get => indAprendField;
        set
        {
            indAprendField = value;
            RaisePropertyChanged(nameof(indAprend));
        }
    }

    public string cnpjEntQual
    {
        get => cnpjEntQualField;
        set
        {
            cnpjEntQualField = value;
            RaisePropertyChanged(nameof(cnpjEntQual));
        }
    }

    public TipoInscricao? tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }
    public bool ShouldSerializetpInsc() => tpInsc.HasValue;

    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }

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

/// <exclude/>
public partial class S2206InfoEstatutario : ESocialBindableObject
{
    private PlanoSegregacaoMassa tpPlanRPField;
    private SimNaoString indTetoRGPSField;
    private SimNaoString indAbonoPermField;

    public PlanoSegregacaoMassa tpPlanRP
    {
        get => tpPlanRPField;
        set
        {
            tpPlanRPField = value;
            RaisePropertyChanged(nameof(tpPlanRP));
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
}

/// <exclude/>
public partial class S2206InfoContrato : ESocialBindableObject
{
    private string nmCargoField;
    private string cboCargoField;
    private string nmFuncaoField;
    private string cboFuncaoField;
    private SimNaoString? acumCargoField;
    private string codCategField;
    private S2206Remuneracao remuneracaoField;
    private S2206Duracao duracaoField;
    private S2206LocalTrabalho localTrabalhoField;
    private S2206HorContratual horContratualField;
    private S2206AlvaraJudicial alvaraJudicialField;
    private List<S2206Observacao> observacoesField;
    private List<S2206TreiCap> treiCapField;

    public string nmCargo
    {
        get => nmCargoField;
        set
        {
            nmCargoField = value;
            RaisePropertyChanged(nameof(nmCargo));
        }
    }

    public string CBOCargo
    {
        get => cboCargoField;
        set
        {
            cboCargoField = value;
            RaisePropertyChanged(nameof(CBOCargo));
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
        get => cboFuncaoField;
        set
        {
            cboFuncaoField = value;
            RaisePropertyChanged(nameof(CBOFuncao));
        }
    }

    public SimNaoString? acumCargo
    {
        get => acumCargoField;
        set
        {
            acumCargoField = value;
            RaisePropertyChanged(nameof(acumCargo));
        }
    }
    public bool ShouldSerializeacumCargo() => acumCargo.HasValue;

    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }

    public S2206Remuneracao remuneracao
    {
        get => remuneracaoField;
        set
        {
            remuneracaoField = value;
            RaisePropertyChanged(nameof(remuneracao));
        }
    }

    public S2206Duracao duracao
    {
        get => duracaoField;
        set
        {
            duracaoField = value;
            RaisePropertyChanged(nameof(duracao));
        }
    }

    public S2206LocalTrabalho localTrabalho
    {
        get => localTrabalhoField;
        set
        {
            localTrabalhoField = value;
            RaisePropertyChanged(nameof(localTrabalho));
        }
    }

    public S2206HorContratual horContratual
    {
        get => horContratualField;
        set
        {
            horContratualField = value;
            RaisePropertyChanged(nameof(horContratual));
        }
    }

    public S2206AlvaraJudicial alvaraJudicial
    {
        get => alvaraJudicialField;
        set
        {
            alvaraJudicialField = value;
            RaisePropertyChanged(nameof(alvaraJudicial));
        }
    }

    [XmlElement("observacoes")]
    public List<S2206Observacao> observacoes
    {
        get => observacoesField;
        set
        {
            observacoesField = value;
            RaisePropertyChanged(nameof(observacoes));
        }
    }

    [XmlElement("treiCap")]
    public List<S2206TreiCap> treiCap
    {
        get => treiCapField;
        set
        {
            treiCapField = value;
            RaisePropertyChanged(nameof(treiCap));
        }
    }
}

/// <exclude/>
public partial class S2206Remuneracao : ESocialBindableObject
{
    private double vrSalFxField;
    private UnidadeSalarial undSalFixoField;
    private string dscSalVarField;

    public double vrSalFx
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

/// <exclude/>
public partial class S2206Duracao : ESocialBindableObject
{
    private TipoContrato tpContrField;
    private DateTime? dtTermField;
    private string objDetField;

    public TipoContrato tpContr
    {
        get => tpContrField;
        set
        {
            tpContrField = value;
            RaisePropertyChanged(nameof(tpContr));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? dtTerm
    {
        get => dtTermField;
        set
        {
            dtTermField = value;
            RaisePropertyChanged(nameof(dtTerm));
        }
    }
    public bool ShouldSerializedtTerm() => dtTerm.HasValue;

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

/// <exclude/>
public partial class S2206LocalTrabalho : ESocialBindableObject
{
    private S2206LocalTrabGeral localTrabGeralField;
    private EnderecoBrasileiro localTempDomField;

    public S2206LocalTrabGeral localTrabGeral
    {
        get => localTrabGeralField;
        set
        {
            localTrabGeralField = value;
            RaisePropertyChanged(nameof(localTrabGeral));
        }
    }

    public EnderecoBrasileiro localTempDom
    {
        get => localTempDomField;
        set
        {
            localTempDomField = value;
            RaisePropertyChanged(nameof(localTempDom));
        }
    }
}

/// <exclude/>
public partial class S2206LocalTrabGeral : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private string descCompField;

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

/// <exclude/>
public partial class S2206HorContratual : ESocialBindableObject
{
    private double? qtdHrsSemField;
    private TipoJornada tpJornadaField;
    private short tmpParcField;
    private SimNaoString horNoturnoField;
    private string dscJornField;
    private bool horNoturnoFieldSpecified;

    public double? qtdHrsSem
    {
        get => qtdHrsSemField;
        set
        {
            qtdHrsSemField = value;
            RaisePropertyChanged(nameof(qtdHrsSem));
        }
    }
    public bool ShouldSerializeqtdHrsSem() => qtdHrsSem.HasValue;

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

    public SimNaoString horNoturno
    {
        get => horNoturnoField;
        set
        {
            horNoturnoField = value;
            horNoturnoFieldSpecified = true;
            RaisePropertyChanged(nameof(horNoturno));
        }
    }
    [XmlIgnore]
    public bool horNoturnoSpecified
    {
        get => horNoturnoFieldSpecified;
        set
        {
            horNoturnoFieldSpecified = value;
            RaisePropertyChanged(nameof(horNoturnoSpecified));
        }
    }

    public string dscJorn
    {
        get => dscJornField;
        set
        {
            dscJornField = value;
            RaisePropertyChanged(nameof(dscJorn));
        }
    }
}

/// <exclude/>
public partial class S2206AlvaraJudicial : ESocialBindableObject
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

/// <exclude/>
public partial class S2206Observacao : ESocialBindableObject
{
    private string observacaoField;

    [XmlElement("observacao")]
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

/// <exclude/>
public partial class S2206TreiCap : ESocialBindableObject
{
    private string codTreiCapField;

    public string codTreiCap
    {
        get => codTreiCapField;
        set
        {
            codTreiCapField = value;
            RaisePropertyChanged(nameof(codTreiCap));
        }
    }
}
