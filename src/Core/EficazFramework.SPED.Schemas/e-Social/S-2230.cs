using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-2230 - Afastamento Temporário
/// </summary>
/// <example>
/// ```csharp
/// string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
/// <eSocial xmlns=""http://www.esocial.gov.br/schema/evt/evtAfastTemp/v_S_01_03_00"">
///   <evtAfastTemp Id=""ID1000000000000002024010100000000000"">
///     <ideEvento>
///       <indRetif>1</indRetif>
///       <tpAmb>2</tpAmb>
///       <procEmi>1</procEmi>
///       <verProc>1.0</verProc>
///     </ideEvento>
///     <ideEmpregador>
///       <tpInsc>1</tpInsc>
///       <nrInsc>00000000</nrInsc>
///     </ideEmpregador>
///     <ideVinculo>
///       <cpfTrab>12345678901</cpfTrab>
///       <matricula>123456</matricula>
///       <codCateg>101</codCateg>
///     </ideVinculo>
///     <infoAfastamento>
///       <iniAfastamento>
///         <dtIniAfast>2024-01-01</dtIniAfast>
///         <codMotAfast>01</codMotAfast>
///         <infoMesmoMtv>S</infoMesmoMtv>
///         <tpAcidTransito>1</tpAcidTransito>
///         <observacao>Observação teste</observacao>
///         <perAquis>
///           <dtInicio>2023-01-01</dtInicio>
///           <dtFim>2023-12-31</dtFim>
///         </perAquis>
///         <infoCessao>
///           <cnpjCess>12345678000123</cnpjCess>
///           <infOnus>1</infOnus>
///         </infoCessao>
///         <infoMandSind>
///           <cnpjSind>12345678000123</cnpjSind>
///           <infOnusRemun>1</infOnusRemun>
///         </infoMandSind>
///         <infoMandElet>
///           <cnpjMandElet>12345678000123</cnpjMandElet>
///           <indRemunCargo>S</indRemunCargo>
///         </infoMandElet>
///       </iniAfastamento>
///       <infoRetif>
///         <origRetif>1</origRetif>
///         <tpProc>1</tpProc>
///         <nrProc>12345678901234567</nrProc>
///       </infoRetif>
///       <fimAfastamento>
///         <dtTermAfast>2024-01-31</dtTermAfast>
///       </fimAfastamento>
///     </infoAfastamento>
///   </evtAfastTemp>
/// </eSocial>";
/// S2230 evento = EficazFramework.SPED.Utilities.XML.Read<S2230>(xml);
/// ```
/// </example>
[Serializable()]
public partial class S2230 : Evento
{
    private S2230EvtAfastTemp evtAfastTempField;
    private SignatureType signatureField;

    /// <remarks/>
    public S2230EvtAfastTemp evtAfastTemp
    {
        get => evtAfastTempField;
        set
        {
            evtAfastTempField = value;
            RaisePropertyChanged(nameof(evtAfastTemp));
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

    /// <exclude/>
    public override void GeraEventoID()
        => evtAfastTempField.Id = string.Format("ID{0}{1}{2}", 
            (int)(evtAfastTempField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), 
            evtAfastTempField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", 
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtAfastTempField?.ideEmpregador?.nrInsc;

    /// <exclude/>
    public override string TagToSign => Evento.root;
    
    /// <exclude/>
    public override string TagId => nameof(evtAfastTemp);
    
    /// <exclude/>
    public override bool EmptyURI => true;
    
    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2230EvtAfastTemp : ESocialBindableObject
{
    private IdeEventoNaoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S2230IdeVinculo ideVinculoField;
    private S2230InfoAfastamento infoAfastamentoField;
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

    public S2230IdeVinculo ideVinculo
    {
        get => ideVinculoField;
        set
        {
            ideVinculoField = value;
            RaisePropertyChanged(nameof(ideVinculo));
        }
    }

    public S2230InfoAfastamento infoAfastamento
    {
        get => infoAfastamentoField;
        set
        {
            infoAfastamentoField = value;
            RaisePropertyChanged(nameof(infoAfastamento));
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
public partial class S2230IdeVinculo : ESocialBindableObject
{
    private string cpfTrabField;
    private string matriculaField;
    private string codCategField;

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

    public string codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }
}

/// <exclude />
public partial class S2230InfoAfastamento : ESocialBindableObject
{
    private S2230IniAfastamento iniAfastamentoField;
    private S2230InfoRetif infoRetifField;
    private S2230FimAfastamento fimAfastamentoField;

    public S2230IniAfastamento iniAfastamento
    {
        get => iniAfastamentoField;
        set
        {
            iniAfastamentoField = value;
            RaisePropertyChanged(nameof(iniAfastamento));
        }
    }

    public S2230InfoRetif infoRetif
    {
        get => infoRetifField;
        set
        {
            infoRetifField = value;
            RaisePropertyChanged(nameof(infoRetif));
        }
    }

    public S2230FimAfastamento fimAfastamento
    {
        get => fimAfastamentoField;
        set
        {
            fimAfastamentoField = value;
            RaisePropertyChanged(nameof(fimAfastamento));
        }
    }
}

/// <exclude />
public partial class S2230IniAfastamento : ESocialBindableObject
{
    private DateTime dtIniAfastField;
    private string codMotAfastField;
    private SimNaoString infoMesmoMtvField;
    private bool infoMesmoMtvFieldSpecified;
    private TipoAcidenteTransito tpAcidTransitoField;
    private bool tpAcidTransitoFieldSpecified;
    private string observacaoField;
    private S2230PerAquis perAquisField;
    private S2230InfoCessao infoCessaoField;
    private S2230InfoMandSind infoMandSindField;
    private S2230InfoMandElet infoMandEletField;

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

    public SimNaoString infoMesmoMtv
    {
        get => infoMesmoMtvField;
        set
        {
            infoMesmoMtvField = value;
            RaisePropertyChanged(nameof(infoMesmoMtv));
        }
    }

    [XmlIgnore()]
    public bool infoMesmoMtvSpecified
    {
        get => infoMesmoMtvFieldSpecified;
        set
        {
            infoMesmoMtvFieldSpecified = value;
            RaisePropertyChanged(nameof(infoMesmoMtvSpecified));
        }
    }

    public TipoAcidenteTransito tpAcidTransito
    {
        get => tpAcidTransitoField;
        set
        {
            tpAcidTransitoField = value;
            RaisePropertyChanged(nameof(tpAcidTransito));
        }
    }

    [XmlIgnore()]
    public bool tpAcidTransitoSpecified
    {
        get => tpAcidTransitoFieldSpecified;
        set
        {
            tpAcidTransitoFieldSpecified = value;
            RaisePropertyChanged(nameof(tpAcidTransitoSpecified));
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

    public S2230PerAquis perAquis
    {
        get => perAquisField;
        set
        {
            perAquisField = value;
            RaisePropertyChanged(nameof(perAquis));
        }
    }

    public S2230InfoCessao infoCessao
    {
        get => infoCessaoField;
        set
        {
            infoCessaoField = value;
            RaisePropertyChanged(nameof(infoCessao));
        }
    }

    public S2230InfoMandSind infoMandSind
    {
        get => infoMandSindField;
        set
        {
            infoMandSindField = value;
            RaisePropertyChanged(nameof(infoMandSind));
        }
    }

    public S2230InfoMandElet infoMandElet
    {
        get => infoMandEletField;
        set
        {
            infoMandEletField = value;
            RaisePropertyChanged(nameof(infoMandElet));
        }
    }
}

/// <exclude />
public partial class S2230PerAquis : ESocialBindableObject
{
    private DateTime dtInicioField;
    private DateTime? dtFimField;

    [XmlElement(DataType = "date")]
    public DateTime dtInicio
    {
        get => dtInicioField;
        set
        {
            dtInicioField = value;
            RaisePropertyChanged(nameof(dtInicio));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? dtFim
    {
        get => dtFimField;
        set
        {
            dtFimField = value;
            RaisePropertyChanged(nameof(dtFim));
        }
    }

    public bool ShouldSerializedtFim() => dtFim.HasValue;
}

/// <exclude />
public partial class S2230InfoCessao : ESocialBindableObject
{
    private string cnpjCessField;
    private OnusCessao infOnusField;

    public string cnpjCess
    {
        get => cnpjCessField;
        set
        {
            cnpjCessField = value;
            RaisePropertyChanged(nameof(cnpjCess));
        }
    }

    public OnusCessao infOnus
    {
        get => infOnusField;
        set
        {
            infOnusField = value;
            RaisePropertyChanged(nameof(infOnus));
        }
    }
}

/// <exclude />
public partial class S2230InfoMandSind : ESocialBindableObject
{
    private string cnpjSindField;
    private OnusRemuneracao infOnusRemunField;

    public string cnpjSind
    {
        get => cnpjSindField;
        set
        {
            cnpjSindField = value;
            RaisePropertyChanged(nameof(cnpjSind));
        }
    }

    public OnusRemuneracao infOnusRemun
    {
        get => infOnusRemunField;
        set
        {
            infOnusRemunField = value;
            RaisePropertyChanged(nameof(infOnusRemun));
        }
    }
}

/// <exclude />
public partial class S2230InfoMandElet : ESocialBindableObject
{
    private string cnpjMandEletField;
    private SimNaoString indRemunCargoField;
    private bool indRemunCargoFieldSpecified;

    public string cnpjMandElet
    {
        get => cnpjMandEletField;
        set
        {
            cnpjMandEletField = value;
            RaisePropertyChanged(nameof(cnpjMandElet));
        }
    }

    public SimNaoString indRemunCargo
    {
        get => indRemunCargoField;
        set
        {
            indRemunCargoField = value;
            RaisePropertyChanged(nameof(indRemunCargo));
        }
    }

    [XmlIgnore()]
    public bool indRemunCargoSpecified
    {
        get => indRemunCargoFieldSpecified;
        set
        {
            indRemunCargoFieldSpecified = value;
            RaisePropertyChanged(nameof(indRemunCargoSpecified));
        }
    }
}

/// <exclude />
public partial class S2230InfoRetif : ESocialBindableObject
{
    private OrigemRetificacao origRetifField;
    private TipoProcessoRetificacao tpProcField;
    private bool tpProcFieldSpecified;
    private string nrProcField;

    public OrigemRetificacao origRetif
    {
        get => origRetifField;
        set
        {
            origRetifField = value;
            RaisePropertyChanged(nameof(origRetif));
        }
    }

    public TipoProcessoRetificacao tpProc
    {
        get => tpProcField;
        set
        {
            tpProcField = value;
            RaisePropertyChanged(nameof(tpProc));
        }
    }

    [XmlIgnore()]
    public bool tpProcSpecified
    {
        get => tpProcFieldSpecified;
        set
        {
            tpProcFieldSpecified = value;
            RaisePropertyChanged(nameof(tpProcSpecified));
        }
    }

    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
        }
    }
}

/// <exclude />
public partial class S2230FimAfastamento : ESocialBindableObject
{
    private DateTime dtTermAfastField;

    [XmlElement(DataType = "date")]
    public DateTime dtTermAfast
    {
        get => dtTermAfastField;
        set
        {
            dtTermAfastField = value;
            RaisePropertyChanged(nameof(dtTermAfast));
        }
    }
}
