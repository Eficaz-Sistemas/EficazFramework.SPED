using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// S-2210 - Comunicação de Acidente de Trabalho
/// </summary>
/// <example>
/// ```csharp
/// string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
/// <eSocial xmlns=""http://www.esocial.gov.br/schema/evt/evtCAT/v_S_01_03_00"">
///   <evtCAT Id=""ID1000000000000002024010100000000000"">
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
///     <cat>
///       <dtAcid>2024-01-01</dtAcid>
///       <tpAcid>1</tpAcid>
///       <hrAcid>1000</hrAcid>
///       <hrsTrabAntesAcid>0200</hrsTrabAntesAcid>
///       <tpCat>1</tpCat>
///       <indCatObito>N</indCatObito>
///       <dtObito>2024-01-01</dtObito>
///       <indComunPolicia>N</indComunPolicia>
///       <codSitGeradora>123456789</codSitGeradora>
///       <iniciatCAT>1</iniciatCAT>
///       <obsCAT>Observação teste</obsCAT>
///       <ultDiaTrab>2024-01-01</ultDiaTrab>
///       <houveAfast>S</houveAfast>
///       <localAcidente>
///         <tpLocal>1</tpLocal>
///         <dscLocal>Pátio</dscLocal>
///         <tpLograd>Rua</tpLograd>
///         <dscLograd>A</dscLograd>
///         <nrLograd>123</nrLograd>
///         <complemento>Sala 1</complemento>
///         <bairro>Centro</bairro>
///         <cep>12345678</cep>
///         <codMunic>1234567</codMunic>
///         <uf>MG</uf>
///         <pais>076</pais>
///         <codPostal>12345</codPostal>
///         <ideLocalAcid>
///           <tpInsc>1</tpInsc>
///           <nrInsc>12345678000123</nrInsc>
///         </ideLocalAcid>
///       </localAcidente>
///       <parteAtingida>
///         <codParteAting>123456789</codParteAting>
///         <lateralidade>1</lateralidade>
///       </parteAtingida>
///       <agenteCausador>
///         <codAgntCausador>123456789</codAgntCausador>
///       </agenteCausador>
///       <atestado>
///         <dtAtendimento>2024-01-01</dtAtendimento>
///         <hrAtendimento>1200</hrAtendimento>
///         <indInternacao>N</indInternacao>
///         <durTrat>10</durTrat>
///         <indAfast>S</indAfast>
///         <dscLesao>123456789</dscLesao>
///         <dscCompLesao>Corte</dscCompLesao>
///         <diagProvavel>Tétano</diagProvavel>
///         <codCID>A00</codCID>
///         <observacao>Nada a declarar</observacao>
///         <emitente>
///           <nmEmit>Medico da Silva</nmEmit>
///           <ideOC>1</ideOC>
///           <nrOC>12345</nrOC>
///           <ufOC>MG</ufOC>
///         </emitente>
///       </atestado>
///       <catOrigem>
///         <nrRecCatOrig>1.2.0000000000000000000</nrRecCatOrig>
///       </catOrigem>
///     </cat>
///   </evtCAT>
/// </eSocial>";
/// S2210 evento = EficazFramework.SPED.Utilities.XML.Read<S2210>(xml);
/// ```
/// </example>
[Serializable()]
public partial class S2210 : Evento
{
    private S2210EvtCAT evtCATField;
    private SignatureType signatureField;

    /// <remarks/>
    public S2210EvtCAT evtCAT
    {
        get => evtCATField;
        set
        {
            evtCATField = value;
            RaisePropertyChanged(nameof(evtCAT));
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
        => evtCATField.Id = string.Format("ID{0}{1}{2}", 
            (int)(evtCATField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), 
            evtCATField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", 
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ()
        => evtCATField?.ideEmpregador?.nrInsc;

    /// <exclude/>
    public override string TagToSign => Evento.root;
    
    /// <exclude/>
    public override string TagId => nameof(evtCAT);
    
    /// <exclude/>
    public override bool EmptyURI => true;
    
    /// <exclude/>
    public override bool SignAsSHA256 => true;
}

/// <exclude />
public partial class S2210EvtCAT : ESocialBindableObject
{
    private IdeEventoNaoPeriodico ideEventoField;
    private Empregador ideEmpregadorField;
    private S2210IdeVinculo ideVinculoField;
    private S2210Cat catField;
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

    public S2210IdeVinculo ideVinculo
    {
        get => ideVinculoField;
        set
        {
            ideVinculoField = value;
            RaisePropertyChanged(nameof(ideVinculo));
        }
    }

    public S2210Cat cat
    {
        get => catField;
        set
        {
            catField = value;
            RaisePropertyChanged(nameof(cat));
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
public partial class S2210IdeVinculo : ESocialBindableObject
{
    private string cpfTrabField;
    private string matriculaField;
    private int? codCategField;

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

    public int? codCateg
    {
        get => codCategField;
        set
        {
            codCategField = value;
            RaisePropertyChanged(nameof(codCateg));
        }
    }
    public bool ShouldSerializecodCateg() => codCateg.HasValue;
}

/// <exclude />
public partial class S2210Cat : ESocialBindableObject
{
    private DateTime dtAcidField;
    private TipoAcidenteTrabalho tpAcidField;
    private string hrAcidField;
    private string hrsTrabAntesAcidField;
    private TipoCAT tpCatField;
    private SimNaoString indCatObitoField;
    private DateTime? dtObitoField;
    private SimNaoString indComunPoliciaField;
    private string codSitGeradoraField;
    private IniciativaCAT iniciatCATField;
    private string obsCATField;
    private DateTime? ultDiaTrabField;
    private SimNaoString? houveAfastField;
    private S2210LocalAcidente localAcidenteField;
    private S2210ParteAtingida parteAtingidaField;
    private S2210AgenteCausador agenteCausadorField;
    private S2210Atestado atestadoField;
    private S2210CatOrigem catOrigemField;

    [XmlElement(DataType = "date")]
    public DateTime dtAcid
    {
        get => dtAcidField;
        set
        {
            dtAcidField = value;
            RaisePropertyChanged(nameof(dtAcid));
        }
    }

    public TipoAcidenteTrabalho tpAcid
    {
        get => tpAcidField;
        set
        {
            tpAcidField = value;
            RaisePropertyChanged(nameof(tpAcid));
        }
    }

    public string hrAcid
    {
        get => hrAcidField;
        set
        {
            hrAcidField = value;
            RaisePropertyChanged(nameof(hrAcid));
        }
    }

    public string hrsTrabAntesAcid
    {
        get => hrsTrabAntesAcidField;
        set
        {
            hrsTrabAntesAcidField = value;
            RaisePropertyChanged(nameof(hrsTrabAntesAcid));
        }
    }

    public TipoCAT tpCat
    {
        get => tpCatField;
        set
        {
            tpCatField = value;
            RaisePropertyChanged(nameof(tpCat));
        }
    }

    public SimNaoString indCatObito
    {
        get => indCatObitoField;
        set
        {
            indCatObitoField = value;
            RaisePropertyChanged(nameof(indCatObito));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? dtObito
    {
        get => dtObitoField;
        set
        {
            dtObitoField = value;
            RaisePropertyChanged(nameof(dtObito));
        }
    }
    public bool ShouldSerializedtObito() => dtObito.HasValue;

    public SimNaoString indComunPolicia
    {
        get => indComunPoliciaField;
        set
        {
            indComunPoliciaField = value;
            RaisePropertyChanged(nameof(indComunPolicia));
        }
    }

    public string codSitGeradora
    {
        get => codSitGeradoraField;
        set
        {
            codSitGeradoraField = value;
            RaisePropertyChanged(nameof(codSitGeradora));
        }
    }

    public IniciativaCAT iniciatCAT
    {
        get => iniciatCATField;
        set
        {
            iniciatCATField = value;
            RaisePropertyChanged(nameof(iniciatCAT));
        }
    }

    public string obsCAT
    {
        get => obsCATField;
        set
        {
            obsCATField = value;
            RaisePropertyChanged(nameof(obsCAT));
        }
    }

    [XmlElement(DataType = "date")]
    public DateTime? ultDiaTrab
    {
        get => ultDiaTrabField;
        set
        {
            ultDiaTrabField = value;
            RaisePropertyChanged(nameof(ultDiaTrab));
        }
    }
    public bool ShouldSerializeultDiaTrab() => ultDiaTrab.HasValue;

    public SimNaoString? houveAfast
    {
        get => houveAfastField;
        set
        {
            houveAfastField = value;
            RaisePropertyChanged(nameof(houveAfast));
        }
    }
    public bool ShouldSerializehouveAfast() => houveAfast.HasValue;

    public S2210LocalAcidente localAcidente
    {
        get => localAcidenteField;
        set
        {
            localAcidenteField = value;
            RaisePropertyChanged(nameof(localAcidente));
        }
    }

    public S2210ParteAtingida parteAtingida
    {
        get => parteAtingidaField;
        set
        {
            parteAtingidaField = value;
            RaisePropertyChanged(nameof(parteAtingida));
        }
    }

    public S2210AgenteCausador agenteCausador
    {
        get => agenteCausadorField;
        set
        {
            agenteCausadorField = value;
            RaisePropertyChanged(nameof(agenteCausador));
        }
    }

    public S2210Atestado atestado
    {
        get => atestadoField;
        set
        {
            atestadoField = value;
            RaisePropertyChanged(nameof(atestado));
        }
    }

    public S2210CatOrigem catOrigem
    {
        get => catOrigemField;
        set
        {
            catOrigemField = value;
            RaisePropertyChanged(nameof(catOrigem));
        }
    }
}

/// <exclude />
public partial class S2210LocalAcidente : ESocialBindableObject
{
    private TipoLocalAcidente tpLocalField;
    private string dscLocalField;
    private string tpLogradField;
    private string dscLogradField;
    private string nrLogradField;
    private string complementoField;
    private string bairroField;
    private string cepField;
    private string codMunicField;
    private string ufField;
    private string paisField;
    private string codPostalField;
    private S2210IdeLocalAcid ideLocalAcidField;

    public TipoLocalAcidente tpLocal
    {
        get => tpLocalField;
        set
        {
            tpLocalField = value;
            RaisePropertyChanged(nameof(tpLocal));
        }
    }

    public string dscLocal
    {
        get => dscLocalField;
        set
        {
            dscLocalField = value;
            RaisePropertyChanged(nameof(dscLocal));
        }
    }

    public string tpLograd
    {
        get => tpLogradField;
        set
        {
            tpLogradField = value;
            RaisePropertyChanged(nameof(tpLograd));
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

    public string cep
    {
        get => cepField;
        set
        {
            cepField = value;
            RaisePropertyChanged(nameof(cep));
        }
    }

    public string codMunic
    {
        get => codMunicField;
        set
        {
            codMunicField = value;
            RaisePropertyChanged(nameof(codMunic));
        }
    }

    public string uf
    {
        get => ufField;
        set
        {
            ufField = value;
            RaisePropertyChanged(nameof(uf));
        }
    }

    public string pais
    {
        get => paisField;
        set
        {
            paisField = value;
            RaisePropertyChanged(nameof(pais));
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

    public S2210IdeLocalAcid ideLocalAcid
    {
        get => ideLocalAcidField;
        set
        {
            ideLocalAcidField = value;
            RaisePropertyChanged(nameof(ideLocalAcid));
        }
    }
}

/// <exclude />
public partial class S2210IdeLocalAcid : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
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
public partial class S2210ParteAtingida : ESocialBindableObject
{
    private string codParteAtingField;
    private Lateralidade lateralidadeField;

    public string codParteAting
    {
        get => codParteAtingField;
        set
        {
            codParteAtingField = value;
            RaisePropertyChanged(nameof(codParteAting));
        }
    }

    public Lateralidade lateralidade
    {
        get => lateralidadeField;
        set
        {
            lateralidadeField = value;
            RaisePropertyChanged(nameof(lateralidade));
        }
    }
}

/// <exclude />
public partial class S2210AgenteCausador : ESocialBindableObject
{
    private string codAgntCausadorField;

    public string codAgntCausador
    {
        get => codAgntCausadorField;
        set
        {
            codAgntCausadorField = value;
            RaisePropertyChanged(nameof(codAgntCausador));
        }
    }
}

/// <exclude />
public partial class S2210Atestado : ESocialBindableObject
{
    private DateTime dtAtendimentoField;
    private string hrAtendimentoField;
    private SimNaoString indInternacaoField;
    private int durTratField;
    private SimNaoString indAfastField;
    private string dscLesaoField;
    private string dscCompLesaoField;
    private string diagProvavelField;
    private string codCIDField;
    private string observacaoField;
    private S2210Emitente emitenteField;

    [XmlElement(DataType = "date")]
    public DateTime dtAtendimento
    {
        get => dtAtendimentoField;
        set
        {
            dtAtendimentoField = value;
            RaisePropertyChanged(nameof(dtAtendimento));
        }
    }

    public string hrAtendimento
    {
        get => hrAtendimentoField;
        set
        {
            hrAtendimentoField = value;
            RaisePropertyChanged(nameof(hrAtendimento));
        }
    }

    public SimNaoString indInternacao
    {
        get => indInternacaoField;
        set
        {
            indInternacaoField = value;
            RaisePropertyChanged(nameof(indInternacao));
        }
    }

    public int durTrat
    {
        get => durTratField;
        set
        {
            durTratField = value;
            RaisePropertyChanged(nameof(durTrat));
        }
    }

    public SimNaoString indAfast
    {
        get => indAfastField;
        set
        {
            indAfastField = value;
            RaisePropertyChanged(nameof(indAfast));
        }
    }

    public string dscLesao
    {
        get => dscLesaoField;
        set
        {
            dscLesaoField = value;
            RaisePropertyChanged(nameof(dscLesao));
        }
    }

    public string dscCompLesao
    {
        get => dscCompLesaoField;
        set
        {
            dscCompLesaoField = value;
            RaisePropertyChanged(nameof(dscCompLesao));
        }
    }

    public string diagProvavel
    {
        get => diagProvavelField;
        set
        {
            diagProvavelField = value;
            RaisePropertyChanged(nameof(diagProvavel));
        }
    }

    public string codCID
    {
        get => codCIDField;
        set
        {
            codCIDField = value;
            RaisePropertyChanged(nameof(codCID));
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

    public S2210Emitente emitente
    {
        get => emitenteField;
        set
        {
            emitenteField = value;
            RaisePropertyChanged(nameof(emitente));
        }
    }
}

/// <exclude />
public partial class S2210Emitente : ESocialBindableObject
{
    private string nmEmitField;
    private OrgaoClasseSaude ideOCField;
    private string nrOCField;
    private string ufOCField;

    public string nmEmit
    {
        get => nmEmitField;
        set
        {
            nmEmitField = value;
            RaisePropertyChanged(nameof(nmEmit));
        }
    }

    public OrgaoClasseSaude ideOC
    {
        get => ideOCField;
        set
        {
            ideOCField = value;
            RaisePropertyChanged(nameof(ideOC));
        }
    }

    public string nrOC
    {
        get => nrOCField;
        set
        {
            nrOCField = value;
            RaisePropertyChanged(nameof(nrOC));
        }
    }

    public string ufOC
    {
        get => ufOCField;
        set
        {
            ufOCField = value;
            RaisePropertyChanged(nameof(ufOC));
        }
    }
}

/// <exclude />
public partial class S2210CatOrigem : ESocialBindableObject
{
    private string nrRecCatOrigField;

    public string nrRecCatOrig
    {
        get => nrRecCatOrigField;
        set
        {
            nrRecCatOrigField = value;
            RaisePropertyChanged(nameof(nrRecCatOrig));
        }
    }
}

