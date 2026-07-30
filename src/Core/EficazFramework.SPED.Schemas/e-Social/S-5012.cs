using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-5012 - Imposto de Renda Retido na Fonte Consolidado por Contribuinte
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtIrrf = new S5012EvtIrrf()
/// {
///     ideEvento = new S5012IdeEvento()
///     {
///         perApur = "2025-02"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "34785515000166"
///     },
///     infoIRRF = new S5012InfoIRRF()
///     {
///         nrRecArqBase = "1.1.0000000000000000000",
///         indExistInfo = IndicadorExistenciaInfoIRRF.HaInformacoesIRRF,
///         infoCRMen =
///         [
///             new S5012InfoCRMen()
///             {
///                 CRMen = "056107",
///                 vrCRMen = 1500.50m
///             }
///         ],
///         infoCRDia =
///         [
///             new S5012InfoCRDia()
///             {
///                 perApurDia = 15,
///                 CRDia = "047301",
///                 vrCRDia = 500.00m
///             }
///         ]
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S5012 : Evento
{
    private S5012EvtIrrf evtIrrfField;
    private SignatureType signatureField;

    public S5012()
    {
        evtIrrfField = new S5012EvtIrrf();
    }

    [XmlElement()]
    public S5012EvtIrrf evtIrrf
    {
        get => evtIrrfField;
        set
        {
            evtIrrfField = value;
            RaisePropertyChanged(nameof(evtIrrf));
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

    // --- Overrides Obrigatórios do Evento ---

    /// <exclude/>
    public override void GeraEventoID()
        => evtIrrfField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtIrrfField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtIrrfField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtIrrfField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtIrrf);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S5012EvtIrrf : ESocialBindableObject
{
    private string idField;
    private S5012IdeEvento ideEventoField;
    private Empregador ideEmpregadorField;
    private S5012InfoIRRF infoIRRFField;

    public S5012IdeEvento ideEvento
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

    public S5012InfoIRRF infoIRRF
    {
        get => infoIRRFField;
        set
        {
            infoIRRFField = value;
            RaisePropertyChanged(nameof(infoIRRF));
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
public partial class S5012IdeEvento : ESocialBindableObject
{
    private string perApurField;

    public string perApur
    {
        get => perApurField;
        set
        {
            perApurField = value;
            RaisePropertyChanged(nameof(perApur));
        }
    }
}

/// <exclude />
public partial class S5012InfoIRRF : ESocialBindableObject
{
    private string nrRecArqBaseField;
    private IndicadorExistenciaInfoIRRF indExistInfoField;
    private List<S5012InfoCRMen> infoCRMenField;
    private List<S5012InfoCRDia> infoCRDiaField;

    public string nrRecArqBase
    {
        get => nrRecArqBaseField;
        set
        {
            nrRecArqBaseField = value;
            RaisePropertyChanged(nameof(nrRecArqBase));
        }
    }

    public IndicadorExistenciaInfoIRRF indExistInfo
    {
        get => indExistInfoField;
        set
        {
            indExistInfoField = value;
            RaisePropertyChanged(nameof(indExistInfo));
        }
    }

    [XmlElement("infoCRMen")]
    public List<S5012InfoCRMen> infoCRMen
    {
        get => infoCRMenField;
        set
        {
            infoCRMenField = value;
            RaisePropertyChanged(nameof(infoCRMen));
        }
    }

    [XmlElement("infoCRDia")]
    public List<S5012InfoCRDia> infoCRDia
    {
        get => infoCRDiaField;
        set
        {
            infoCRDiaField = value;
            RaisePropertyChanged(nameof(infoCRDia));
        }
    }
}

/// <exclude />
public partial class S5012InfoCRMen : ESocialBindableObject
{
    private string cRMenField;
    private decimal vrCRMenField;

    public string CRMen
    {
        get => cRMenField;
        set
        {
            cRMenField = value;
            RaisePropertyChanged(nameof(CRMen));
        }
    }

    public decimal vrCRMen
    {
        get => vrCRMenField;
        set
        {
            vrCRMenField = value;
            RaisePropertyChanged(nameof(vrCRMen));
        }
    }
}

/// <exclude />
public partial class S5012InfoCRDia : ESocialBindableObject
{
    private byte perApurDiaField;
    private string cRDiaField;
    private decimal vrCRDiaField;

    public byte perApurDia
    {
        get => perApurDiaField;
        set
        {
            perApurDiaField = value;
            RaisePropertyChanged(nameof(perApurDia));
        }
    }

    public string CRDia
    {
        get => cRDiaField;
        set
        {
            cRDiaField = value;
            RaisePropertyChanged(nameof(CRDia));
        }
    }

    public decimal vrCRDia
    {
        get => vrCRDiaField;
        set
        {
            vrCRDiaField = value;
            RaisePropertyChanged(nameof(vrCRDia));
        }
    }
}
