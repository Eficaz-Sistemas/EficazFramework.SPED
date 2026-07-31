using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-3000 - Exclusão de Eventos
/// </summary>
/// <example>
/// ```csharp
/// evento.Versao = Versao.v_S_01_03_00;
/// evento.evtExclusao = new S3000EvtExclusao()
/// {
///     ideEvento = new IdentificacaoCadastro()
///     {
///         tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///         procEmi = EmissorEvento.AppEmpregador,
///         verProc = "EficazFramework"
///     },
///     ideEmpregador = new Empregador()
///     {
///         tpInsc = PersonalidadeJuridica.CNPJ,
///         nrInsc = "34785515000166"
///     },
///     infoExclusao = new S3000InfoExclusao()
///     {
///         tpEvento = "S-1200",
///         nrRecEvt = "1.1.0000000000000000000",
///         ideTrabalhador = new S3000IdeTrabalhador()
///         {
///             cpfTrab = "12345678901"
///         },
///         ideFolhaPagto = new S3000IdeFolhaPagto()
///         {
///             indApuracao = IndicadorApuracao.Mensal,
///             perApur = "2023-05"
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class S3000 : Evento
{
    private S3000EvtExclusao evtExclusaoField;
    private SignatureType signatureField;

    public S3000()
    {
        evtExclusaoField = new S3000EvtExclusao();
    }

    [XmlElement()]
    public S3000EvtExclusao evtExclusao
    {
        get => evtExclusaoField;
        set
        {
            evtExclusaoField = value;
            RaisePropertyChanged(nameof(evtExclusao));
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
        => evtExclusaoField.Id = string.Format("ID{0}{1}{2}",
            (int)(evtExclusaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ),
            evtExclusaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000",
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtExclusaoField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtExclusao);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S3000EvtExclusao : ESocialBindableObject
{
    private IdentificacaoCadastro ideEventoField;
    private Empregador ideEmpregadorField;
    private S3000InfoExclusao infoExclusaoField;
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

    public S3000InfoExclusao infoExclusao
    {
        get => infoExclusaoField;
        set
        {
            infoExclusaoField = value;
            RaisePropertyChanged(nameof(infoExclusao));
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
public partial class S3000InfoExclusao : ESocialBindableObject
{
    private string tpEventoField;
    private string nrRecEvtField;
    private S3000IdeTrabalhador ideTrabalhadorField;
    private S3000IdeFolhaPagto ideFolhaPagtoField;

    public string tpEvento
    {
        get => tpEventoField;
        set
        {
            tpEventoField = value;
            RaisePropertyChanged(nameof(tpEvento));
        }
    }

    public string nrRecEvt
    {
        get => nrRecEvtField;
        set
        {
            nrRecEvtField = value;
            RaisePropertyChanged(nameof(nrRecEvt));
        }
    }

    public S3000IdeTrabalhador ideTrabalhador
    {
        get => ideTrabalhadorField;
        set
        {
            ideTrabalhadorField = value;
            RaisePropertyChanged(nameof(ideTrabalhador));
        }
    }

    public S3000IdeFolhaPagto ideFolhaPagto
    {
        get => ideFolhaPagtoField;
        set
        {
            ideFolhaPagtoField = value;
            RaisePropertyChanged(nameof(ideFolhaPagto));
        }
    }
}

/// <exclude />
public partial class S3000IdeTrabalhador : ESocialBindableObject
{
    private string cpfTrabField;

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
public partial class S3000IdeFolhaPagto : ESocialBindableObject
{
    private IndicadorApuracao? indApuracaoField;
    private string perApurField;

    public IndicadorApuracao? indApuracao
    {
        get => indApuracaoField;
        set
        {
            indApuracaoField = value;
            RaisePropertyChanged(nameof(indApuracao));
        }
    }

    public bool ShouldSerializeindApuracao()
        => indApuracao.HasValue;

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
