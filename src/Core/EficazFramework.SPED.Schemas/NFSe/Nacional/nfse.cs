using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.NFSe.Nacional;

/// <summary>
/// Classe base para tipos da NFSe Nacional que implementa INotifyPropertyChanged.
/// </summary>
public abstract class NFSeNacionalBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Dispara o evento PropertyChanged para a propriedade informada.
    /// </summary>
    /// <param name="propertyName">Nome da propriedade (preenchido automaticamente se omitido).</param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

/// <summary>
/// Tipo Versão da NFSe - 1.01 (conforme XSD `TVerNFSe`).
/// </summary>
public enum TVerNFSe
{
    [XmlEnum("1.01")]
    V1_01
}

/// <summary>
/// Tipos de ambiente do Sistema Nacional NFS-e: 1 - Produção; 2 - Homologação.
/// </summary>
public enum TSTipoAmbiente
{
    [XmlEnum("1")]
    Producao = 1,
    [XmlEnum("2")]
    Homologacao = 2
}

/// <summary>
/// Tipo Ambiente Gerador de NFS-e: 1 - Prefeitura; 2 - Sistema Nacional da NFS-e.
/// </summary>
public enum TSAmbGeradorNFSe
{
    [XmlEnum("1")]
    Prefeitura = 1,
    [XmlEnum("2")]
    SistemaNacional = 2
}

/// <summary>
/// Tipo de emissão da NFS-e: 1 - Emissão normal; 2 - Emissão original em leiaute próprio do município.
/// </summary>
public enum TSTipoEmissao
{
    [XmlEnum("1")]
    Normal = 1,
    [XmlEnum("2")]
    LeiauteMunicipal = 2
}

/// <summary>
/// Emitente da DPS: 1 - Prestador; 2 - Tomador; 3 - Intermediário.
/// </summary>
public enum TSEmitenteDPS
{
    [XmlEnum("1")]
    Prestador = 1,
    [XmlEnum("2")]
    Tomador = 2,
    [XmlEnum("3")]
    Intermediario = 3
}

/// <summary>
/// Elemento raiz NFSe (schema `NFSe`, namespace http://www.sped.fazenda.gov.br/nfse).
/// </summary>
[XmlRoot("NFSe", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class NFSe : NFSeNacionalBase
{
    private TCInfNFSe? _infNFSe;
    private XmlElement? _signature;
    private string? _versao;

    /// <summary>
    /// Grupo de informações da NFS-e.
    /// </summary>
    [XmlElement("infNFSe")]
    public TCInfNFSe? InfNFSe
    {
        get => _infNFSe;
        set { _infNFSe = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Assinatura XML (XML Digital Signature) no namespace ds.
    /// </summary>
    [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public XmlElement? Signature
    {
        get => _signature;
        set { _signature = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Versão do documento (atributo obrigatório).
    /// </summary>
    [XmlAttribute("versao")]
    public string? versao
    {
        get => _versao;
        set { _versao = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de informações da NFS-e (tipo `TCInfNFSe`).
/// </summary>
[XmlType("TCInfNFSe", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfNFSe : NFSeNacionalBase
{
    private string? _xLocEmi;
    private string? _xLocPrestacao;
    private string? _nNFSe;
    private string? _cLocIncid;
    private string? _xLocIncid;
    private string? _xTribNac;
    private string? _xTribMun;
    private string? _xNBS;
    private string? _verAplic;
    private TSAmbGeradorNFSe _ambGer;
    private TSTipoEmissao _tpEmis;
    private string? _procEmi;
    private string? _cStat;
    private string? _dhProc;
    private string? _nDFSe;
    private TCEmitente? _emit;
    private string? _xOutInf;
    private TCValoresNFSe? _valores;
    private TCRTCIBSCBS? _iBSCBS;
    private TCDPS? _dps;
    private string? _id;

    /// <summary>
    /// Descrição do código do IBGE do município emissor da NFS-e.
    /// </summary>
    [XmlElement("xLocEmi")]
    public string? xLocEmi
    {
        get => _xLocEmi;
        set { _xLocEmi = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Descrição do local da prestação do serviço.
    /// </summary>
    [XmlElement("xLocPrestacao")]
    public string? xLocPrestacao
    {
        get => _xLocPrestacao;
        set { _xLocPrestacao = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Número sequencial por tipo de emitente da NFS-e.
    /// </summary>
    [XmlElement("nNFSe")]
    public string? nNFSe
    {
        get => _nNFSe;
        set { _nNFSe = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Código do município de incidência (IBGE) - opcional.
    /// </summary>
    [XmlElement("cLocIncid")]
    public string? cLocIncid
    {
        get => _cLocIncid;
        set { _cLocIncid = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Descrição do município de incidência - opcional.
    /// </summary>
    [XmlElement("xLocIncid")]
    public string? xLocIncid
    {
        get => _xLocIncid;
        set { _xLocIncid = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Descrição do código de tributação nacional do ISSQN.
    /// </summary>
    [XmlElement("xTribNac")]
    public string? xTribNac
    {
        get => _xTribNac;
        set { _xTribNac = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Descrição do código de tributação municipal do ISSQN - opcional.
    /// </summary>
    [XmlElement("xTribMun")]
    public string? xTribMun
    {
        get => _xTribMun;
        set { _xTribMun = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Descrição do código da NBS - opcional.
    /// </summary>
    [XmlElement("xNBS")]
    public string? xNBS
    {
        get => _xNBS;
        set { _xNBS = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Versão do aplicativo que gerou a NFS-e.
    /// </summary>
    [XmlElement("verAplic")]
    public string? verAplic
    {
        get => _verAplic;
        set { _verAplic = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Ambiente gerador da NFS-e.
    /// </summary>
    [XmlElement("ambGer")]
    public TSAmbGeradorNFSe ambGer
    {
        get => _ambGer;
        set { _ambGer = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Processo de Emissão da DPS.
    /// </summary>
    [XmlElement("tpEmis")]
    public TSTipoEmissao tpEmis
    {
        get => _tpEmis;
        set { _tpEmis = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Processo de Emissão da DPS - opcional.
    /// </summary>
    [XmlElement("procEmi")]
    public string? procEmi
    {
        get => _procEmi;
        set { _procEmi = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Código do Status da mensagem.
    /// </summary>
    [XmlElement("cStat")]
    public string? cStat
    {
        get => _cStat;
        set { _cStat = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Data/Hora da validação da DPS e geração da NFS-e (UTC).
    /// </summary>
    [XmlElement("dhProc")]
    public string? dhProc
    {
        get => _dhProc;
        set { _dhProc = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Número sequencial do documento gerado por ambiente gerador de DFSe do município.
    /// </summary>
    [XmlElement("nDFSe")]
    public string? nDFSe
    {
        get => _nDFSe;
        set { _nDFSe = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações do emitente da NFS-e.
    /// </summary>
    [XmlElement("emit")]
    public TCEmitente? emit
    {
        get => _emit;
        set { _emit = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Uso da Administração Tributária Municipal - opcional.
    /// </summary>
    [XmlElement("xOutInf")]
    public string? xOutInf
    {
        get => _xOutInf;
        set { _xOutInf = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de valores referentes ao Serviço Prestado.
    /// </summary>
    [XmlElement("valores")]
    public TCValoresNFSe? valores
    {
        get => _valores;
        set { _valores = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações geradas pelo sistema referentes ao IBS e à CBS - opcional.
    /// </summary>
    [XmlElement("IBSCBS")]
    public TCRTCIBSCBS? IBSCBS
    {
        get => _iBSCBS;
        set { _iBSCBS = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações da DPS relativas ao serviço prestado.
    /// </summary>
    [XmlElement("DPS")]
    public TCDPS? DPS
    {
        get => _dps;
        set { _dps = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Identificador do elemento (atributo Id) - obrigatório.
    /// </summary>
    [XmlAttribute("Id")]
    public string? Id
    {
        get => _id;
        set { _id = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo do emitente da NFS-e (`TCEmitente`).
/// </summary>
[XmlType("TCEmitente", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCEmitente : NFSeNacionalBase
{
    private string? _cNPJ;
    private string? _cPF;
    private string? _iM;
    private string? _xNome;
    private string? _xFant;
    private TCEnderecoEmitente? _enderNac;
    private string? _fone;
    private string? _email;

    /// <summary>
    /// Número do CNPJ do emitente da NFS-e.
    /// </summary>
    [XmlElement("CNPJ")]
    public string? CNPJ
    {
        get => _cNPJ;
        set { _cNPJ = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Número do CPF do emitente da NFS-e.
    /// </summary>
    [XmlElement("CPF")]
    public string? CPF
    {
        get => _cPF;
        set { _cPF = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Número da inscrição municipal - opcional.
    /// </summary>
    [XmlElement("IM")]
    public string? IM
    {
        get => _iM;
        set { _iM = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Nome / Razão Social do emitente.
    /// </summary>
    [XmlElement("xNome")]
    public string? xNome
    {
        get => _xNome;
        set { _xNome = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Nome / Fantasia do emitente - opcional.
    /// </summary>
    [XmlElement("xFant")]
    public string? xFant
    {
        get => _xFant;
        set { _xFant = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações do endereço nacional do Emitente da NFS-e.
    /// </summary>
    [XmlElement("enderNac")]
    public TCEnderecoEmitente? enderNac
    {
        get => _enderNac;
        set { _enderNac = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Número do telefone do emitente - opcional.
    /// </summary>
    [XmlElement("fone")]
    public string? fone
    {
        get => _fone;
        set { _fone = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// E-mail do emitente - opcional.
    /// </summary>
    [XmlElement("email")]
    public string? email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo dos valores da NFS-e (`TCValoresNFSe`).
/// </summary>
[XmlType("TCValoresNFSe", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCValoresNFSe : NFSeNacionalBase
{
    private string? _vCalcDR;
    private string? _tpBM;
    private string? _vCalcBM;
    private string? _vBC;
    private string? _pAliqAplic;
    private string? _vISSQN;
    private string? _vTotalRet;
    private string? _vLiq;

    /// <summary>
    /// Valor monetário (R$) de dedução/redução da base de cálculo (BC) do ISSQN - opcional.
    /// </summary>
    [XmlElement("vCalcDR")]
    public string? vCalcDR
    {
        get => _vCalcDR;
        set { _vCalcDR = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Tipo Benefício Municipal (BM) - opcional.
    /// </summary>
    [XmlElement("tpBM")]
    public string? tpBM
    {
        get => _tpBM;
        set { _tpBM = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Valor monetário do percentual de redução da base de cálculo (BC) do ISSQN devido a um benefício municipal (BM) - opcional.
    /// </summary>
    [XmlElement("vCalcBM")]
    public string? vCalcBM
    {
        get => _vCalcBM;
        set { _vCalcBM = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Valor da Base de Cálculo do ISSQN (R$) - opcional.
    /// </summary>
    [XmlElement("vBC")]
    public string? vBC
    {
        get => _vBC;
        set { _vBC = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Alíquota aplicada sobre a base de cálculo para apuração do ISSQN - opcional.
    /// </summary>
    [XmlElement("pAliqAplic")]
    public string? pAliqAplic
    {
        get => _pAliqAplic;
        set { _pAliqAplic = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Valor do ISSQN (R$) - opcional.
    /// </summary>
    [XmlElement("vISSQN")]
    public string? vISSQN
    {
        get => _vISSQN;
        set { _vISSQN = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Valor total de retenções - opcional.
    /// </summary>
    [XmlElement("vTotalRet")]
    public string? vTotalRet
    {
        get => _vTotalRet;
        set { _vTotalRet = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Valor líquido = Valor do serviço - Desconto condicionado - Desconto incondicionado - Valores retidos.
    /// </summary>
    [XmlElement("vLiq")]
    public string? vLiq
    {
        get => _vLiq;
        set { _vLiq = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo DPS (`TCDPS`).
/// </summary>
[XmlType("TCDPS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCDPS : NFSeNacionalBase
{
    private TCInfDPS? _infDPS;
    private XmlElement? _signature;
    private string? _versao;

    /// <summary>
    /// Informações da DPS.
    /// </summary>
    [XmlElement("infDPS")]
    public TCInfDPS? infDPS
    {
        get => _infDPS;
        set { _infDPS = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Assinatura XML (opcional).
    /// </summary>
    [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public XmlElement? Signature
    {
        get => _signature;
        set { _signature = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Versão do documento (atributo obrigatório).
    /// </summary>
    [XmlAttribute("versao")]
    public string? versao
    {
        get => _versao;
        set { _versao = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações da DPS (`TCInfDPS`).
/// </summary>
[XmlType("TCInfDPS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfDPS : NFSeNacionalBase
{
    private TSTipoAmbiente _tpAmb;
    private string? _dhEmi;
    private string? _verAplic;
    private string? _serie;
    private string? _nDPS;
    private string? _dCompet;
    private TSEmitenteDPS _tpEmit;
    private string? _cMotivoEmisTI;
    private string? _chNFSeRej;
    private string? _cLocEmi;
    private TCSubstituicao? _subst;
    private TCInfoPrestador? _prest;
    private TCInfoPessoa? _toma;
    private TCInfoPessoa? _interm;
    private TCServ? _serv;
    private TCInfoValores? _valores;
    private TCRTCInfoIBSCBS? _iBSCBS;
    private string? _id;

    /// <summary>
    /// Identificação do Ambiente: 1 - Produção; 2 - Homologação.
    /// </summary>
    [XmlElement("tpAmb")]
    public TSTipoAmbiente tpAmb
    {
        get => _tpAmb;
        set { _tpAmb = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Data e hora da emissão do DPS (UTC).
    /// </summary>
    [XmlElement("dhEmi")]
    public string? dhEmi
    {
        get => _dhEmi;
        set { _dhEmi = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Versão do aplicativo que gerou o DPS.
    /// </summary>
    [XmlElement("verAplic")]
    public string? verAplic
    {
        get => _verAplic;
        set { _verAplic = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Número do equipamento emissor do DPS ou série do DPS.
    /// </summary>
    [XmlElement("serie")]
    public string? serie
    {
        get => _serie;
        set { _serie = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Número do DPS.
    /// </summary>
    [XmlElement("nDPS")]
    public string? nDPS
    {
        get => _nDPS;
        set { _nDPS = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Data em que se iniciou a prestação do serviço (AAAA-MM-DD).
    /// </summary>
    [XmlElement("dCompet")]
    public string? dCompet
    {
        get => _dCompet;
        set { _dCompet = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Emitente da DPS: 1 - Prestador; 2 - Tomador; 3 - Intermediário.
    /// </summary>
    [XmlElement("tpEmit")]
    public TSEmitenteDPS tpEmit
    {
        get => _tpEmit;
        set { _tpEmit = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Motivo da Emissão da DPS pelo Tomador/Intermediário - opcional.
    /// </summary>
    [XmlElement("cMotivoEmisTI")]
    public string? cMotivoEmisTI
    {
        get => _cMotivoEmisTI;
        set { _cMotivoEmisTI = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Chave de Acesso da NFS-e rejeitada pelo Tomador/Intermediário - opcional.
    /// </summary>
    [XmlElement("chNFSeRej")]
    public string? chNFSeRej
    {
        get => _chNFSeRej;
        set { _chNFSeRej = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Código do município emissor do DPS (IBGE).
    /// </summary>
    [XmlElement("cLocEmi")]
    public string? cLocEmi
    {
        get => _cLocEmi;
        set { _cLocEmi = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Dados da NFS-e a ser substituída - opcional.
    /// </summary>
    [XmlElement("subst")]
    public TCSubstituicao? subst
    {
        get => _subst;
        set { _subst = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações do DPS relativas ao Prestador de Serviços.
    /// </summary>
    [XmlElement("prest")]
    public TCInfoPrestador? prest
    {
        get => _prest;
        set { _prest = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações do DPS relativas ao Tomador de Serviços - opcional.
    /// </summary>
    [XmlElement("toma")]
    public TCInfoPessoa? toma
    {
        get => _toma;
        set { _toma = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações do DPS relativas ao Intermediário de Serviços - opcional.
    /// </summary>
    [XmlElement("interm")]
    public TCInfoPessoa? interm
    {
        get => _interm;
        set { _interm = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações do DPS relativas ao Serviço Prestado.
    /// </summary>
    [XmlElement("serv")]
    public TCServ? serv
    {
        get => _serv;
        set { _serv = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações relativas à valores do serviço prestado.
    /// </summary>
    [XmlElement("valores")]
    public TCInfoValores? valores
    {
        get => _valores;
        set { _valores = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Grupo de informações declaradas pelo emitente referentes ao IBS e à CBS - opcional.
    /// </summary>
    [XmlElement("IBSCBS")]
    public TCRTCInfoIBSCBS? IBSCBS
    {
        get => _iBSCBS;
        set { _iBSCBS = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Identificador do elemento (atributo Id) - obrigatório.
    /// </summary>
    [XmlAttribute("Id")]
    public string? Id
    {
        get => _id;
        set { _id = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de substituição de NFS-e (`TCSubstituicao`).
/// </summary>
[XmlType("TCSubstituicao", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCSubstituicao : NFSeNacionalBase
{
    private string? _chSubstda;
    private string? _cMotivo;
    private string? _xMotivo;

    /// <summary>
    /// Chave de acesso da NFS-e a ser substituída.
    /// </summary>
    [XmlElement("chSubstda")]
    public string? chSubstda
    {
        get => _chSubstda;
        set { _chSubstda = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Código de justificativa para substituição de NFS-e.
    /// </summary>
    [XmlElement("cMotivo")]
    public string? cMotivo
    {
        get => _cMotivo;
        set { _cMotivo = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// Descrição do motivo da substituição da NFS-e - opcional.
    /// </summary>
    [XmlElement("xMotivo")]
    public string? xMotivo
    {
        get => _xMotivo;
        set { _xMotivo = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações do Prestador da NFS-e (TCInfoPrestador).
/// </summary>
[XmlType("TCInfoPrestador", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoPrestador : NFSeNacionalBase
{
    private string? _cNPJ;
    private string? _cPF;
    private string? _nIF;
    private string? _cNaoNIF;
    private string? _cAEPF;
    private string? _iM;
    private string? _xNome;
    private TCEndereco? _end;
    private string? _fone;
    private string? _email;
    private TCRegTrib? _regTrib;

    [XmlElement("CNPJ")]
    public string? CNPJ
    {
        get => _cNPJ;
        set { _cNPJ = value; OnPropertyChanged(); }
    }

    [XmlElement("CPF")]
    public string? CPF
    {
        get => _cPF;
        set { _cPF = value; OnPropertyChanged(); }
    }

    [XmlElement("NIF")]
    public string? NIF
    {
        get => _nIF;
        set { _nIF = value; OnPropertyChanged(); }
    }

    [XmlElement("cNaoNIF")]
    public string? cNaoNIF
    {
        get => _cNaoNIF;
        set { _cNaoNIF = value; OnPropertyChanged(); }
    }

    [XmlElement("CAEPF")]
    public string? CAEPF
    {
        get => _cAEPF;
        set { _cAEPF = value; OnPropertyChanged(); }
    }

    [XmlElement("IM")]
    public string? IM
    {
        get => _iM;
        set { _iM = value; OnPropertyChanged(); }
    }

    [XmlElement("xNome")]
    public string? xNome
    {
        get => _xNome;
        set { _xNome = value; OnPropertyChanged(); }
    }

    [XmlElement("end")]
    public TCEndereco? end
    {
        get => _end;
        set { _end = value; OnPropertyChanged(); }
    }

    [XmlElement("fone")]
    public string? fone
    {
        get => _fone;
        set { _fone = value; OnPropertyChanged(); }
    }

    [XmlElement("email")]
    public string? email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); }
    }

    [XmlElement("regTrib")]
    public TCRegTrib? regTrib
    {
        get => _regTrib;
        set { _regTrib = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de regimes de tributação (`TCRegTrib`).
/// </summary>
[XmlType("TCRegTrib", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRegTrib : NFSeNacionalBase
{
    private string? _opSimpNac;
    private string? _regApTribSN;
    private string? _regEspTrib;

    [XmlElement("opSimpNac")]
    public string? opSimpNac
    {
        get => _opSimpNac;
        set { _opSimpNac = value; OnPropertyChanged(); }
    }

    [XmlElement("regApTribSN")]
    public string? regApTribSN
    {
        get => _regApTribSN;
        set { _regApTribSN = value; OnPropertyChanged(); }
    }

    [XmlElement("regEspTrib")]
    public string? regEspTrib
    {
        get => _regEspTrib;
        set { _regEspTrib = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de pessoa (`TCInfoPessoa`).
/// (Utilizado para tomador/intermediário)
/// </summary>
[XmlType("TCInfoPessoa", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoPessoa : NFSeNacionalBase
{
    private string? _cNPJ;
    private string? _cPF;
    private string? _nIF;
    private string? _cNaoNIF;
    private string? _cAEPF;
    private string? _iM;
    private string? _xNome;
    private TCEndereco? _end;
    private string? _fone;
    private string? _email;

    [XmlElement("CNPJ")]
    public string? CNPJ
    {
        get => _cNPJ;
        set { _cNPJ = value; OnPropertyChanged(); }
    }

    [XmlElement("CPF")]
    public string? CPF
    {
        get => _cPF;
        set { _cPF = value; OnPropertyChanged(); }
    }

    [XmlElement("NIF")]
    public string? NIF
    {
        get => _nIF;
        set { _nIF = value; OnPropertyChanged(); }
    }

    [XmlElement("cNaoNIF")]
    public string? cNaoNIF
    {
        get => _cNaoNIF;
        set { _cNaoNIF = value; OnPropertyChanged(); }
    }

    [XmlElement("CAEPF")]
    public string? CAEPF
    {
        get => _cAEPF;
        set { _cAEPF = value; OnPropertyChanged(); }
    }

    [XmlElement("IM")]
    public string? IM
    {
        get => _iM;
        set { _iM = value; OnPropertyChanged(); }
    }

    [XmlElement("xNome")]
    public string? xNome
    {
        get => _xNome;
        set { _xNome = value; OnPropertyChanged(); }
    }

    [XmlElement("end")]
    public TCEndereco? end
    {
        get => _end;
        set { _end = value; OnPropertyChanged(); }
    }

    [XmlElement("fone")]
    public string? fone
    {
        get => _fone;
        set { _fone = value; OnPropertyChanged(); }
    }

    [XmlElement("email")]
    public string? email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para endereço do emitente (`TCEnderecoEmitente`).
/// </summary>
[XmlType("TCEnderecoEmitente", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCEnderecoEmitente : NFSeNacionalBase
{
    private string? _xLgr;
    private string? _nro;
    private string? _xCpl;
    private string? _xBairro;
    private string? _cMun;
    private string? _uF;
    private string? _cEP;

    [XmlElement("xLgr")]
    public string? xLgr
    {
        get => _xLgr;
        set { _xLgr = value; OnPropertyChanged(); }
    }

    [XmlElement("nro")]
    public string? nro
    {
        get => _nro;
        set { _nro = value; OnPropertyChanged(); }
    }

    [XmlElement("xCpl")]
    public string? xCpl
    {
        get => _xCpl;
        set { _xCpl = value; OnPropertyChanged(); }
    }

    [XmlElement("xBairro")]
    public string? xBairro
    {
        get => _xBairro;
        set { _xBairro = value; OnPropertyChanged(); }
    }

    [XmlElement("cMun")]
    public string? cMun
    {
        get => _cMun;
        set { _cMun = value; OnPropertyChanged(); }
    }

    [XmlElement("UF")]
    public string? UF
    {
        get => _uF;
        set { _uF = value; OnPropertyChanged(); }
    }

    [XmlElement("CEP")]
    public string? CEP
    {
        get => _cEP;
        set { _cEP = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo simples de endereço (`TCEndereco`) utilizado em várias estruturas.
/// </summary>
[XmlType("TCEndereco", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCEndereco : NFSeNacionalBase
{
    private TCEnderNac? _endNac;
    private TCEnderExt? _endExt;
    private string? _xLgr;
    private string? _nro;
    private string? _xCpl;
    private string? _xBairro;

    [XmlElement("endNac")]
    public TCEnderNac? endNac
    {
        get => _endNac;
        set { _endNac = value; OnPropertyChanged(); }
    }

    [XmlElement("endExt")]
    public TCEnderExt? endExt
    {
        get => _endExt;
        set { _endExt = value; OnPropertyChanged(); }
    }

    [XmlElement("xLgr")]
    public string? xLgr
    {
        get => _xLgr;
        set { _xLgr = value; OnPropertyChanged(); }
    }

    [XmlElement("nro")]
    public string? nro
    {
        get => _nro;
        set { _nro = value; OnPropertyChanged(); }
    }

    [XmlElement("xCpl")]
    public string? xCpl
    {
        get => _xCpl;
        set { _xCpl = value; OnPropertyChanged(); }
    }

    [XmlElement("xBairro")]
    public string? xBairro
    {
        get => _xBairro;
        set { _xBairro = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo para campos específicos de endereço nacional (`TCEnderNac`).
/// </summary>
[XmlType("TCEnderNac", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCEnderNac : NFSeNacionalBase
{
    private string? _cMun;
    private string? _cEP;

    [XmlElement("cMun")]
    public string? cMun
    {
        get => _cMun;
        set { _cMun = value; OnPropertyChanged(); }
    }

    [XmlElement("CEP")]
    public string? CEP
    {
        get => _cEP;
        set { _cEP = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo para campos específicos de endereço no exterior (`TCEnderExt`).
/// </summary>
[XmlType("TCEnderExt", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCEnderExt : NFSeNacionalBase
{
    private string? _cPais;
    private string? _cEndPost;
    private string? _xCidade;
    private string? _xEstProvReg;

    [XmlElement("cPais")]
    public string? cPais
    {
        get => _cPais;
        set { _cPais = value; OnPropertyChanged(); }
    }

    [XmlElement("cEndPost")]
    public string? cEndPost
    {
        get => _cEndPost;
        set { _cEndPost = value; OnPropertyChanged(); }
    }

    [XmlElement("xCidade")]
    public string? xCidade
    {
        get => _xCidade;
        set { _xCidade = value; OnPropertyChanged(); }
    }

    [XmlElement("xEstProvReg")]
    public string? xEstProvReg
    {
        get => _xEstProvReg;
        set { _xEstProvReg = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de regimes de tributação (`TCRegTrib`).
/// </summary>
[XmlType("TCRegTrib", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRegTrib : NFSeNacionalBase
{
    private string? _opSimpNac;
    private string? _regApTribSN;
    private string? _regEspTrib;

    [XmlElement("opSimpNac")]
    public string? opSimpNac
    {
        get => _opSimpNac;
        set { _opSimpNac = value; OnPropertyChanged(); }
    }

    [XmlElement("regApTribSN")]
    public string? regApTribSN
    {
        get => _regApTribSN;
        set { _regApTribSN = value; OnPropertyChanged(); }
    }

    [XmlElement("regEspTrib")]
    public string? regEspTrib
    {
        get => _regEspTrib;
        set { _regEspTrib = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações do serviço prestado (`TCServ`).
/// </summary>
[XmlType("TCServ", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCServ : NFSeNacionalBase
{
    private TCLocPrest? _locPrest;
    private TCCServ? _cServ;
    private TCComExterior? _comExt;
    private TCInfoObra? _obra;
    private TCAtvEvento? _atvEvento;
    private TCExploracaoRodoviaria? _explRod;
    private TCInfoCompl? _infoCompl;

    [XmlElement("locPrest")]
    public TCLocPrest? locPrest
    {
        get => _locPrest;
        set { _locPrest = value; OnPropertyChanged(); }
    }

    [XmlElement("cServ")]
    public TCCServ? cServ
    {
        get => _cServ;
        set { _cServ = value; OnPropertyChanged(); }
    }

    [XmlElement("comExt")]
    public TCComExterior? comExt
    {
        get => _comExt;
        set { _comExt = value; OnPropertyChanged(); }
    }

    [XmlElement("obra")]
    public TCInfoObra? obra
    {
        get => _obra;
        set { _obra = value; OnPropertyChanged(); }
    }

    [XmlElement("atvEvento")]
    public TCAtvEvento? atvEvento
    {
        get => _atvEvento;
        set { _atvEvento = value; OnPropertyChanged(); }
    }

    [XmlElement("explRod")]
    public TCExploracaoRodoviaria? explRod
    {
        get => _explRod;
        set { _explRod = value; OnPropertyChanged(); }
    }

    [XmlElement("infoCompl")]
    public TCInfoCompl? infoCompl
    {
        get => _infoCompl;
        set { _infoCompl = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para o local da prestação (`TCLocPrest`).
/// </summary>
[XmlType("TCLocPrest", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCLocPrest : NFSeNacionalBase
{
    private string? _cLocPrestacao;
    private string? _cPaisPrestacao;

    [XmlElement("cLocPrestacao")]
    public string? cLocPrestacao
    {
        get => _cLocPrestacao;
        set { _cLocPrestacao = value; OnPropertyChanged(); }
    }

    [XmlElement("cPaisPrestacao")]
    public string? cPaisPrestacao
    {
        get => _cPaisPrestacao;
        set { _cPaisPrestacao = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para código do serviço (`TCCServ`).
/// </summary>
[XmlType("TCCServ", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCCServ : NFSeNacionalBase
{
    private string? _cTribNac;
    private string? _cTribMun;
    private string? _xDescServ;
    private string? _cNBS;
    private string? _cIntContrib;

    [XmlElement("cTribNac")]
    public string? cTribNac
    {
        get => _cTribNac;
        set { _cTribNac = value; OnPropertyChanged(); }
    }

    [XmlElement("cTribMun")]
    public string? cTribMun
    {
        get => _cTribMun;
        set { _cTribMun = value; OnPropertyChanged(); }
    }

    [XmlElement("xDescServ")]
    public string? xDescServ
    {
        get => _xDescServ;
        set { _xDescServ = value; OnPropertyChanged(); }
    }

    [XmlElement("cNBS")]
    public string? cNBS
    {
        get => _cNBS;
        set { _cNBS = value; OnPropertyChanged(); }
    }

    [XmlElement("cIntContrib")]
    public string? cIntContrib
    {
        get => _cIntContrib;
        set { _cIntContrib = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de comércio exterior (`TCComExterior`).
/// </summary>
[XmlType("TCComExterior", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCComExterior : NFSeNacionalBase
{
    private string? _mdPrestacao;
    private string? _vincPrest;
    private string? _tpMoeda;
    private string? _vServMoeda;
    private string? _mecAFComexP;
    private string? _mecAFComexT;
    private string? _movTempBens;
    private string? _nDI;
    private string? _nRE;
    private string? _mdic;

    [XmlElement("mdPrestacao")]
    public string? mdPrestacao
    {
        get => _mdPrestacao;
        set { _mdPrestacao = value; OnPropertyChanged(); }
    }

    [XmlElement("vincPrest")]
    public string? vincPrest
    {
        get => _vincPrest;
        set { _vincPrest = value; OnPropertyChanged(); }
    }

    [XmlElement("tpMoeda")]
    public string? tpMoeda
    {
        get => _tpMoeda;
        set { _tpMoeda = value; OnPropertyChanged(); }
    }

    [XmlElement("vServMoeda")]
    public string? vServMoeda
    {
        get => _vServMoeda;
        set { _vServMoeda = value; OnPropertyChanged(); }
    }

    [XmlElement("mecAFComexP")]
    public string? mecAFComexP
    {
        get => _mecAFComexP;
        set { _mecAFComexP = value; OnPropertyChanged(); }
    }

    [XmlElement("mecAFComexT")]
    public string? mecAFComexT
    {
        get => _mecAFComexT;
        set { _mecAFComexT = value; OnPropertyChanged(); }
    }

    [XmlElement("movTempBens")]
    public string? movTempBens
    {
        get => _movTempBens;
        set { _movTempBens = value; OnPropertyChanged(); }
    }

    [XmlElement("nDI")]
    public string? nDI
    {
        get => _nDI;
        set { _nDI = value; OnPropertyChanged(); }
    }

    [XmlElement("nRE")]
    public string? nRE
    {
        get => _nRE;
        set { _nRE = value; OnPropertyChanged(); }
    }

    [XmlElement("mdic")]
    public string? mdic
    {
        get => _mdic;
        set { _mdic = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de atividade de evento (`TCAtvEvento`).
/// </summary>
[XmlType("TCAtvEvento", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCAtvEvento : NFSeNacionalBase
{
    private string? _xNome;
    private string? _dtIni;
    private string? _dtFim;
    private string? _idAtvEvt;
    private TCEnderecoSimples? _end;

    [XmlElement("xNome")]
    public string? xNome
    {
        get => _xNome;
        set { _xNome = value; OnPropertyChanged(); }
    }

    [XmlElement("dtIni")]
    public string? dtIni
    {
        get => _dtIni;
        set { _dtIni = value; OnPropertyChanged(); }
    }

    [XmlElement("dtFim")]
    public string? dtFim
    {
        get => _dtFim;
        set { _dtFim = value; OnPropertyChanged(); }
    }

    [XmlElement("idAtvEvt")]
    public string? idAtvEvt
    {
        get => _idAtvEvt;
        set { _idAtvEvt = value; OnPropertyChanged(); }
    }

    [XmlElement("end")]
    public TCEnderecoSimples? end
    {
        get => _end;
        set { _end = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de obra (`TCInfoObra`).
/// </summary>
[XmlType("TCInfoObra", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoObra : NFSeNacionalBase
{
    private string? _inscImobFisc;
    private string? _cObra;
    private string? _cCIB;
    private TCEnderObraEvento? _end;

    [XmlElement("inscImobFisc")]
    public string? inscImobFisc
    {
        get => _inscImobFisc;
        set { _inscImobFisc = value; OnPropertyChanged(); }
    }

    [XmlElement("cObra")]
    public string? cObra
    {
        get => _cObra;
        set { _cObra = value; OnPropertyChanged(); }
    }

    [XmlElement("cCIB")]
    public string? cCIB
    {
        get => _cCIB;
        set { _cCIB = value; OnPropertyChanged(); }
    }

    [XmlElement("end")]
    public TCEnderObraEvento? end
    {
        get => _end;
        set { _end = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações complementares do serviço prestado (`TCInfoCompl`).
/// </summary>
[XmlType("TCInfoCompl", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoCompl : NFSeNacionalBase
{
    private string? _idDocTec;
    private string? _docRef;
    private string? _xPed;
    private TCInfoItemPed? _gItemPed;
    private string? _xInfComp;

    [XmlElement("idDocTec")]
    public string? idDocTec
    {
        get => _idDocTec;
        set { _idDocTec = value; OnPropertyChanged(); }
    }

    [XmlElement("docRef")]
    public string? docRef
    {
        get => _docRef;
        set { _docRef = value; OnPropertyChanged(); }
    }

    [XmlElement("xPed")]
    public string? xPed
    {
        get => _xPed;
        set { _xPed = value; OnPropertyChanged(); }
    }

    [XmlElement("gItemPed")]
    public TCInfoItemPed? gItemPed
    {
        get => _gItemPed;
        set { _gItemPed = value; OnPropertyChanged(); }
    }

    [XmlElement("xInfComp")]
    public string? xInfComp
    {
        get => _xInfComp;
        set { _xInfComp = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para lista de itens do pedido (`TCInfoItemPed`).
/// </summary>
[XmlType("TCInfoItemPed", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoItemPed : NFSeNacionalBase
{
    private string[]? _xItemPed;

    [XmlElement("xItemPed")]
    public string[]? xItemPed
    {
        get => _xItemPed;
        set { _xItemPed = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações relativas aos valores do serviço prestado (`TCInfoValores`).
/// </summary>
[XmlType("TCInfoValores", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoValores : NFSeNacionalBase
{
    private TCVServPrest? _vServPrest;
    private TCVDescCondIncond? _vDescCondIncond;
    private TCInfoDedRed? _vDedRed;
    private TCInfoTributacao? _trib;

    [XmlElement("vServPrest")]
    public TCVServPrest? vServPrest
    {
        get => _vServPrest;
        set { _vServPrest = value; OnPropertyChanged(); }
    }

    [XmlElement("vDescCondIncond")]
    public TCVDescCondIncond? vDescCondIncond
    {
        get => _vDescCondIncond;
        set { _vDescCondIncond = value; OnPropertyChanged(); }
    }

    [XmlElement("vDedRed")]
    public TCInfoDedRed? vDedRed
    {
        get => _vDedRed;
        set { _vDedRed = value; OnPropertyChanged(); }
    }

    [XmlElement("trib")]
    public TCInfoTributacao? trib
    {
        get => _trib;
        set { _trib = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de informações relativas aos valores do serviço prestado (`TCVServPrest`).
/// </summary>
[XmlType("TCVServPrest", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCVServPrest : NFSeNacionalBase
{
    private string? _vReceb;
    private string? _vServ;

    [XmlElement("vReceb")]
    public string? vReceb
    {
        get => _vReceb;
        set { _vReceb = value; OnPropertyChanged(); }
    }

    [XmlElement("vServ")]
    public string? vServ
    {
        get => _vServ;
        set { _vServ = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de informações relativas aos descontos (`TCVDescCondIncond`).
/// </summary>
[XmlType("TCVDescCondIncond", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCVDescCondIncond : NFSeNacionalBase
{
    private string? _vDescIncond;
    private string? _vDescCond;

    [XmlElement("vDescIncond")]
    public string? vDescIncond
    {
        get => _vDescIncond;
        set { _vDescIncond = value; OnPropertyChanged(); }
    }

    [XmlElement("vDescCond")]
    public string? vDescCond
    {
        get => _vDescCond;
        set { _vDescCond = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de dedução/redução (`TCInfoDedRed`).
/// </summary>
[XmlType("TCInfoDedRed", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoDedRed : NFSeNacionalBase
{
    private string? _pDR;
    private string? _vDR;
    private TCListaDocDedRed? _documentos;

    [XmlElement("pDR")]
    public string? pDR
    {
        get => _pDR;
        set { _pDR = value; OnPropertyChanged(); }
    }

    [XmlElement("vDR")]
    public string? vDR
    {
        get => _vDR;
        set { _vDR = value; OnPropertyChanged(); }
    }

    [XmlElement("documentos")]
    public TCListaDocDedRed? documentos
    {
        get => _documentos;
        set { _documentos = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Lista de documentos usados para dedução/redução (`TCListaDocDedRed`).
/// </summary>
[XmlType("TCListaDocDedRed", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCListaDocDedRed : NFSeNacionalBase
{
    private TCDocDedRed[]? _docDedRed;

    [XmlElement("docDedRed")]
    public TCDocDedRed[]? docDedRed
    {
        get => _docDedRed;
        set { _docDedRed = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Documento usado para dedução/redução (`TCDocDedRed`).
/// </summary>
[XmlType("TCDocDedRed", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCDocDedRed : NFSeNacionalBase
{
    private string? _chNFSe;
    private string? _chNFe;
    private TCDocOutNFSe? _nFSeMun;
    private TCDocNFNFS? _nFNFS;
    private string? _nDocFisc;
    private string? _nDoc;
    private string? _tpDedRed;
    private string? _xDescOutDed;
    private DateTime? _dtEmiDoc;
    private string? _vDedutivelRedutivel;
    private string? _vDeducaoReducao;
    private TCInfoPessoa? _fornec;

    [XmlElement("chNFSe")]
    public string? chNFSe
    {
        get => _chNFSe;
        set { _chNFSe = value; OnPropertyChanged(); }
    }

    [XmlElement("chNFe")]
    public string? chNFe
    {
        get => _chNFe;
        set { _chNFe = value; OnPropertyChanged(); }
    }

    [XmlElement("NFSeMun")]
    public TCDocOutNFSe? NFSeMun
    {
        get => _nFSeMun;
        set { _nFSeMun = value; OnPropertyChanged(); }
    }

    [XmlElement("NFNFS")]
    public TCDocNFNFS? NFNFS
    {
        get => _nFNFS;
        set { _nFNFS = value; OnPropertyChanged(); }
    }

    [XmlElement("nDocFisc")]
    public string? nDocFisc
    {
        get => _nDocFisc;
        set { _nDocFisc = value; OnPropertyChanged(); }
    }

    [XmlElement("nDoc")]
    public string? nDoc
    {
        get => _nDoc;
        set { _nDoc = value; OnPropertyChanged(); }
    }

    [XmlElement("tpDedRed")]
    public string? tpDedRed
    {
        get => _tpDedRed;
        set { _tpDedRed = value; OnPropertyChanged(); }
    }

    [XmlElement("xDescOutDed")]
    public string? xDescOutDed
    {
        get => _xDescOutDed;
        set { _xDescOutDed = value; OnPropertyChanged(); }
    }

    [XmlElement("dtEmiDoc", DataType = "date")]
    public DateTime? dtEmiDoc
    {
        get => _dtEmiDoc;
        set { _dtEmiDoc = value; OnPropertyChanged(); }
    }

    [XmlElement("vDedutivelRedutivel")]
    public string? vDedutivelRedutivel
    {
        get => _vDedutivelRedutivel;
        set { _vDedutivelRedutivel = value; OnPropertyChanged(); }
    }

    [XmlElement("vDeducaoReducao")]
    public string? vDeducaoReducao
    {
        get => _vDeducaoReducao;
        set { _vDeducaoReducao = value; OnPropertyChanged(); }
    }

    [XmlElement("fornec")]
    public TCInfoPessoa? fornec
    {
        get => _fornec;
        set { _fornec = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de informações de outras NFS-e (prévia municipal) (`TCDocOutNFSe`).
/// </summary>
[XmlType("TCDocOutNFSe", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCDocOutNFSe : NFSeNacionalBase
{
    private string? _cMunNFSeMun;
    private string? _nNFSeMun;
    private string? _cVerifNFSeMun;

    [XmlElement("cMunNFSeMun")]
    public string? cMunNFSeMun
    {
        get => _cMunNFSeMun;
        set { _cMunNFSeMun = value; OnPropertyChanged(); }
    }

    [XmlElement("nNFSeMun")]
    public string? nNFSeMun
    {
        get => _nNFSeMun;
        set { _nNFSeMun = value; OnPropertyChanged(); }
    }

    [XmlElement("cVerifNFSeMun")]
    public string? cVerifNFSeMun
    {
        get => _cVerifNFSeMun;
        set { _cVerifNFSeMun = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de informações de NF ou NFS (modelo não eletrônico) (`TCDocNFNFS`).
/// </summary>
[XmlType("TCDocNFNFS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCDocNFNFS : NFSeNacionalBase
{
    private string? _nNFS;
    private string? _modNFS;
    private string? _serieNFS;

    [XmlElement("nNFS")]
    public string? nNFS
    {
        get => _nNFS;
        set { _nNFS = value; OnPropertyChanged(); }
    }

    [XmlElement("modNFS")]
    public string? modNFS
    {
        get => _modNFS;
        set { _modNFS = value; OnPropertyChanged(); }
    }

    [XmlElement("serieNFS")]
    public string? serieNFS
    {
        get => _serieNFS;
        set { _serieNFS = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações de tributação (`TCInfoTributacao`).
/// </summary>
[XmlType("TCInfoTributacao", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoTributacao : NFSeNacionalBase
{
    private TCTribMunicipal? _tribMun;
    private TCTribFederal? _tribFed;
    private TCTribTotal? _totTrib;

    [XmlElement("tribMun")]
    public TCTribMunicipal? tribMun
    {
        get => _tribMun;
        set { _tribMun = value; OnPropertyChanged(); }
    }

    [XmlElement("tribFed")]
    public TCTribFederal? tribFed
    {
        get => _tribFed;
        set { _tribFed = value; OnPropertyChanged(); }
    }

    [XmlElement("totTrib")]
    public TCTribTotal? totTrib
    {
        get => _totTrib;
        set { _totTrib = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para tributação municipal (`TCTribMunicipal`).
/// </summary>
[XmlType("TCTribMunicipal", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCTribMunicipal : NFSeNacionalBase
{
    private string? _tribISSQN;
    private string? _cPaisResult;
    private string? _tpImunidade;
    private TCExigSuspensa? _exigSusp;
    private TCBeneficioMunicipal? _bM;
    private string? _tpRetISSQN;
    private string? _pAliq;

    [XmlElement("tribISSQN")]
    public string? tribISSQN
    {
        get => _tribISSQN;
        set { _tribISSQN = value; OnPropertyChanged(); }
    }

    [XmlElement("cPaisResult")]
    public string? cPaisResult
    {
        get => _cPaisResult;
        set { _cPaisResult = value; OnPropertyChanged(); }
    }

    [XmlElement("tpImunidade")]
    public string? tpImunidade
    {
        get => _tpImunidade;
        set { _tpImunidade = value; OnPropertyChanged(); }
    }

    [XmlElement("exigSusp")]
    public TCExigSuspensa? exigSusp
    {
        get => _exigSusp;
        set { _exigSusp = value; OnPropertyChanged(); }
    }

    [XmlElement("BM")]
    public TCBeneficioMunicipal? BM
    {
        get => _bM;
        set { _bM = value; OnPropertyChanged(); }
    }

    [XmlElement("tpRetISSQN")]
    public string? tpRetISSQN
    {
        get => _tpRetISSQN;
        set { _tpRetISSQN = value; OnPropertyChanged(); }
    }

    [XmlElement("pAliq")]
    public string? pAliq
    {
        get => _pAliq;
        set { _pAliq = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para benefício municipal (`TCBeneficioMunicipal`).
/// </summary>
[XmlType("TCBeneficioMunicipal", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCBeneficioMunicipal : NFSeNacionalBase
{
    private string? _nBM;
    private string? _vRedBCBM;
    private string? _pRedBCBM;

    [XmlElement("nBM")]
    public string? nBM
    {
        get => _nBM;
        set { _nBM = value; OnPropertyChanged(); }
    }

    [XmlElement("vRedBCBM")]
    public string? vRedBCBM
    {
        get => _vRedBCBM;
        set { _vRedBCBM = value; OnPropertyChanged(); }
    }

    [XmlElement("pRedBCBM")]
    public string? pRedBCBM
    {
        get => _pRedBCBM;
        set { _pRedBCBM = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para exigibilidade suspensa (`TCExigSuspensa`).
/// </summary>
[XmlType("TCExigSuspensa", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCExigSuspensa : NFSeNacionalBase
{
    private string? _tpSusp;
    private string? _nProcesso;

    [XmlElement("tpSusp")]
    public string? tpSusp
    {
        get => _tpSusp;
        set { _tpSusp = value; OnPropertyChanged(); }
    }

    [XmlElement("nProcesso")]
    public string? nProcesso
    {
        get => _nProcesso;
        set { _nProcesso = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para tributação federal (`TCTribFederal`).
/// </summary>
[XmlType("TCTribFederal", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCTribFederal : NFSeNacionalBase
{
    private TCTribOutrosPisCofins? _piscofins;
    private string? _vRetCP;
    private string? _vRetIRRF;
    private string? _vRetCSLL;

    [XmlElement("piscofins")]
    public TCTribOutrosPisCofins? piscofins
    {
        get => _piscofins;
        set { _piscofins = value; OnPropertyChanged(); }
    }

    [XmlElement("vRetCP")]
    public string? vRetCP
    {
        get => _vRetCP;
        set { _vRetCP = value; OnPropertyChanged(); }
    }

    [XmlElement("vRetIRRF")]
    public string? vRetIRRF
    {
        get => _vRetIRRF;
        set { _vRetIRRF = value; OnPropertyChanged(); }
    }

    [XmlElement("vRetCSLL")]
    public string? vRetCSLL
    {
        get => _vRetCSLL;
        set { _vRetCSLL = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações do PIS/COFINS (`TCTribOutrosPisCofins`).
/// </summary>
[XmlType("TCTribOutrosPisCofins", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCTribOutrosPisCofins : NFSeNacionalBase
{
    private string? _CST;
    private string? _vBCPisCofins;
    private string? _pAliqPis;
    private string? _pAliqCofins;
    private string? _vPis;
    private string? _vCofins;
    private string? _tpRetPisCofins;

    [XmlElement("CST")]
    public string? CST
    {
        get => _CST;
        set { _CST = value; OnPropertyChanged(); }
    }

    [XmlElement("vBCPisCofins")]
    public string? vBCPisCofins
    {
        get => _vBCPisCofins;
        set { _vBCPisCofins = value; OnPropertyChanged(); }
    }

    [XmlElement("pAliqPis")]
    public string? pAliqPis
    {
        get => _pAliqPis;
        set { _pAliqPis = value; OnPropertyChanged(); }
    }

    [XmlElement("pAliqCofins")]
    public string? pAliqCofins
    {
        get => _pAliqCofins;
        set { _pAliqCofins = value; OnPropertyChanged(); }
    }

    [XmlElement("vPis")]
    public string? vPis
    {
        get => _vPis;
        set { _vPis = value; OnPropertyChanged(); }
    }

    [XmlElement("vCofins")]
    public string? vCofins
    {
        get => _vCofins;
        set { _vCofins = value; OnPropertyChanged(); }
    }

    [XmlElement("tpRetPisCofins")]
    public string? tpRetPisCofins
    {
        get => _tpRetPisCofins;
        set { _tpRetPisCofins = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para total aproximado de tributos (`TCTribTotal`).
/// </summary>
[XmlType("TCTribTotal", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCTribTotal : NFSeNacionalBase
{
    private TCTribTotalMonet? _vTotTrib;
    private TCTribTotalPercent? _pTotTrib;
    private string? _indTotTrib;
    private string? _pTotTribSN;

    [XmlElement("vTotTrib")]
    public TCTribTotalMonet? vTotTrib
    {
        get => _vTotTrib;
        set { _vTotTrib = value; OnPropertyChanged(); }
    }

    [XmlElement("pTotTrib")]
    public TCTribTotalPercent? pTotTrib
    {
        get => _pTotTrib;
        set { _pTotTrib = value; OnPropertyChanged(); }
    }

    [XmlElement("indTotTrib")]
    public string? indTotTrib
    {
        get => _indTotTrib;
        set { _indTotTrib = value; OnPropertyChanged(); }
    }

    [XmlElement("pTotTribSN")]
    public string? pTotTribSN
    {
        get => _pTotTribSN;
        set { _pTotTribSN = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo para valores monetários totais dos tributos (`TCTribTotalMonet`).
/// </summary>
[XmlType("TCTribTotalMonet", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCTribTotalMonet : NFSeNacionalBase
{
    private string? _vTotTribFed;
    private string? _vTotTribEst;
    private string? _vTotTribMun;

    [XmlElement("vTotTribFed")]
    public string? vTotTribFed
    {
        get => _vTotTribFed;
        set { _vTotTribFed = value; OnPropertyChanged(); }
    }

    [XmlElement("vTotTribEst")]
    public string? vTotTribEst
    {
        get => _vTotTribEst;
        set { _vTotTribEst = value; OnPropertyChanged(); }
    }

    [XmlElement("vTotTribMun")]
    public string? vTotTribMun
    {
        get => _vTotTribMun;
        set { _vTotTribMun = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo para valores percentuais totais dos tributos (`TCTribTotalPercent`).
/// </summary>
[XmlType("TCTribTotalPercent", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCTribTotalPercent : NFSeNacionalBase
{
    private string? _pTotTribFed;
    private string? _pTotTribEst;
    private string? _pTotTribMun;

    [XmlElement("pTotTribFed")]
    public string? pTotTribFed
    {
        get => _pTotTribFed;
        set { _pTotTribFed = value; OnPropertyChanged(); }
    }

    [XmlElement("pTotTribEst")]
    public string? pTotTribEst
    {
        get => _pTotTribEst;
        set { _pTotTribEst = value; OnPropertyChanged(); }
    }

    [XmlElement("pTotTribMun")]
    public string? pTotTribMun
    {
        get => _pTotTribMun;
        set { _pTotTribMun = value; OnPropertyChanged(); }
    }
}

/* ----------------------------- TIPOS RELACIONADOS A IBS/CBS (TCRTC*) ----------------------------- */

/// <summary>
/// Tipo complexo IBSCBS (TCRTCIBSCBS).
/// </summary>
[XmlType("TCRTCIBSCBS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCIBSCBS : NFSeNacionalBase
{
    private string? _cLocalidadeIncid;
    private string? _xLocalidadeIncid;
    private string? _pRedutor;
    private TCRTCValoresIBSCBS? _valores;
    private TCRTCTotalCIBS? _totCIBS;

    [XmlElement("cLocalidadeIncid")]
    public string? cLocalidadeIncid
    {
        get => _cLocalidadeIncid;
        set { _cLocalidadeIncid = value; OnPropertyChanged(); }
    }

    [XmlElement("xLocalidadeIncid")]
    public string? xLocalidadeIncid
    {
        get => _xLocalidadeIncid;
        set { _xLocalidadeIncid = value; OnPropertyChanged(); }
    }

    [XmlElement("pRedutor")]
    public string? pRedutor
    {
        get => _pRedutor;
        set { _pRedutor = value; OnPropertyChanged(); }
    }

    [XmlElement("valores")]
    public TCRTCValoresIBSCBS? valores
    {
        get => _valores;
        set { _valores = value; OnPropertyChanged(); }
    }

    [XmlElement("totCIBS")]
    public TCRTCTotalCIBS? totCIBS
    {
        get => _totCIBS;
        set { _totCIBS = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Valores brutos IBSCBS (TCRTCValoresIBSCBS).
/// </summary>
[XmlType("TCRTCValoresIBSCBS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCValoresIBSCBS : NFSeNacionalBase
{
    private string? _vBC;
    private string? _vCalcReeRepRes;
    private TCRTCValoresIBSCBSUF? _uf;
    private TCRTCValoresIBSCBSMun? _mun;
    private TCRTCValoresIBSCBSFed? _fed;

    [XmlElement("vBC")]
    public string? vBC
    {
        get => _vBC;
        set { _vBC = value; OnPropertyChanged(); }
    }

    [XmlElement("vCalcReeRepRes")]
    public string? vCalcReeRepRes
    {
        get => _vCalcReeRepRes;
        set { _vCalcReeRepRes = value; OnPropertyChanged(); }
    }

    [XmlElement("uf")]
    public TCRTCValoresIBSCBSUF? uf
    {
        get => _uf;
        set { _uf = value; OnPropertyChanged(); }
    }

    [XmlElement("mun")]
    public TCRTCValoresIBSCBSMun? mun
    {
        get => _mun;
        set { _mun = value; OnPropertyChanged(); }
    }

    [XmlElement("fed")]
    public TCRTCValoresIBSCBSFed? fed
    {
        get => _fed;
        set { _fed = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCValoresIBSCBSUF", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCValoresIBSCBSUF : NFSeNacionalBase
{
    private string? _pIBSUF;
    private string? _pRedAliqUF;
    private string? _pAliqEfetUF;

    [XmlElement("pIBSUF")]
    public string? pIBSUF
    {
        get => _pIBSUF;
        set { _pIBSUF = value; OnPropertyChanged(); }
    }

    [XmlElement("pRedAliqUF")]
    public string? pRedAliqUF
    {
        get => _pRedAliqUF;
        set { _pRedAliqUF = value; OnPropertyChanged(); }
    }

    [XmlElement("pAliqEfetUF")]
    public string? pAliqEfetUF
    {
        get => _pAliqEfetUF;
        set { _pAliqEfetUF = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCValoresIBSCBSMun", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCValoresIBSCBSMun : NFSeNacionalBase
{
    private string? _pIBSMun;
    private string? _pRedAliqMun;
    private string? _pAliqEfetMun;

    [XmlElement("pIBSMun")]
    public string? pIBSMun
    {
        get => _pIBSMun;
        set { _pIBSMun = value; OnPropertyChanged(); }
    }

    [XmlElement("pRedAliqMun")]
    public string? pRedAliqMun
    {
        get => _pRedAliqMun;
        set { _pRedAliqMun = value; OnPropertyChanged(); }
    }

    [XmlElement("pAliqEfetMun")]
    public string? pAliqEfetMun
    {
        get => _pAliqEfetMun;
        set { _pAliqEfetMun = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCValoresIBSCBSFed", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCValoresIBSCBSFed : NFSeNacionalBase
{
    private string? _pCBS;
    private string? _pRedAliqCBS;
    private string? _pAliqEfetCBS;

    [XmlElement("pCBS")]
    public string? pCBS
    {
        get => _pCBS;
        set { _pCBS = value; OnPropertyChanged(); }
    }

    [XmlElement("pRedAliqCBS")]
    public string? pRedAliqCBS
    {
        get => _pRedAliqCBS;
        set { _pRedAliqCBS = value; OnPropertyChanged(); }
    }

    [XmlElement("pAliqEfetCBS")]
    public string? pAliqEfetCBS
    {
        get => _pAliqEfetCBS;
        set { _pAliqEfetCBS = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Totalizadores CIBS (`TCRTCTotalCIBS`).
/// </summary>
[XmlType("TCRTCTotalCIBS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalCIBS : NFSeNacionalBase
{
    private string? _vTotNF;
    private TCRTCTotalIBS? _gIBS;
    private TCRTCTotalCBS? _gCBS;
    private TCRTCTotalTribRegular? _gTribRegular;
    private TCRTCTotalTribCompraGov? _gTribCompraGov;

    [XmlElement("vTotNF")]
    public string? vTotNF
    {
        get => _vTotNF;
        set { _vTotNF = value; OnPropertyChanged(); }
    }

    [XmlElement("gIBS")]
    public TCRTCTotalIBS? gIBS
    {
        get => _gIBS;
        set { _gIBS = value; OnPropertyChanged(); }
    }

    [XmlElement("gCBS")]
    public TCRTCTotalCBS? gCBS
    {
        get => _gCBS;
        set { _gCBS = value; OnPropertyChanged(); }
    }

    [XmlElement("gTribRegular")]
    public TCRTCTotalTribRegular? gTribRegular
    {
        get => _gTribRegular;
        set { _gTribRegular = value; OnPropertyChanged(); }
    }

    [XmlElement("gTribCompraGov")]
    public TCRTCTotalTribCompraGov? gTribCompraGov
    {
        get => _gTribCompraGov;
        set { _gTribCompraGov = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCTotalIBS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalIBS : NFSeNacionalBase
{
    private string? _vIBSTot;
    private TCRTCTotalIBSCredPres? _gIBSCredPres;
    private TCRTCTotalIBSUF? _gIBSUFTot;
    private TCRTCTotalIBSMun? _gIBSMunTot;

    [XmlElement("vIBSTot")]
    public string? vIBSTot
    {
        get => _vIBSTot;
        set { _vIBSTot = value; OnPropertyChanged(); }
    }

    [XmlElement("gIBSCredPres")]
    public TCRTCTotalIBSCredPres? gIBSCredPres
    {
        get => _gIBSCredPres;
        set { _gIBSCredPres = value; OnPropertyChanged(); }
    }

    [XmlElement("gIBSUFTot")]
    public TCRTCTotalIBSUF? gIBSUFTot
    {
        get => _gIBSUFTot;
        set { _gIBSUFTot = value; OnPropertyChanged(); }
    }

    [XmlElement("gIBSMunTot")]
    public TCRTCTotalIBSMun? gIBSMunTot
    {
        get => _gIBSMunTot;
        set { _gIBSMunTot = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCTotalIBSCredPres", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalIBSCredPres : NFSeNacionalBase
{
    private string? _pCredPresIBS;
    private string? _vCredPresIBS;

    [XmlElement("pCredPresIBS")]
    public string? pCredPresIBS
    {
        get => _pCredPresIBS;
        set { _pCredPresIBS = value; OnPropertyChanged(); }
    }

    [XmlElement("vCredPresIBS")]
    public string? vCredPresIBS
    {
        get => _vCredPresIBS;
        set { _vCredPresIBS = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCTotalIBSUF", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalIBSUF : NFSeNacionalBase
{
    private string? _vDifUF;
    private string? _vIBSUF;

    [XmlElement("vDifUF")]
    public string? vDifUF
    {
        get => _vDifUF;
        set { _vDifUF = value; OnPropertyChanged(); }
    }

    [XmlElement("vIBSUF")]
    public string? vIBSUF
    {
        get => _vIBSUF;
        set { _vIBSUF = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCTotalIBSMun", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalIBSMun : NFSeNacionalBase
{
    private string? _vDifMun;
    private string? _vIBSMun;

    [XmlElement("vDifMun")]
    public string? vDifMun
    {
        get => _vDifMun;
        set { _vDifMun = value; OnPropertyChanged(); }
    }

    [XmlElement("vIBSMun")]
    public string? vIBSMun
    {
        get => _vIBSMun;
        set { _vIBSMun = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCTotalCBS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalCBS : NFSeNacionalBase
{
    private TCRTCTotalCBSCredPres? _gCBSCredPres;
    private string? _vDifCBS;
    private string? _vCBS;

    [XmlElement("gCBSCredPres")]
    public TCRTCTotalCBSCredPres? gCBSCredPres
    {
        get => _gCBSCredPres;
        set { _gCBSCredPres = value; OnPropertyChanged(); }
    }

    [XmlElement("vDifCBS")]
    public string? vDifCBS
    {
        get => _vDifCBS;
        set { _vDifCBS = value; OnPropertyChanged(); }
    }

    [XmlElement("vCBS")]
    public string? vCBS
    {
        get => _vCBS;
        set { _vCBS = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCTotalCBSCredPres", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalCBSCredPres : NFSeNacionalBase
{
    private string? _pCredPresCBS;
    private string? _vCredPresCBS;

    [XmlElement("pCredPresCBS")]
    public string? pCredPresCBS
    {
        get => _pCredPresCBS;
        set { _pCredPresCBS = value; OnPropertyChanged(); }
    }

    [XmlElement("vCredPresCBS")]
    public string? vCredPresCBS
    {
        get => _vCredPresCBS;
        set { _vCredPresCBS = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCTotalTribRegular", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalTribRegular : NFSeNacionalBase
{
    private string? _pAliqEfeRegIBSUF;
    private string? _vTribRegIBSUF;
    private string? _pAliqEfeRegIBSMun;
    private string? _vTribRegIBSMun;
    private string? _pAliqEfeRegCBS;
    private string? _vTribRegCBS;

    [XmlElement("pAliqEfeRegIBSUF")]
    public string? pAliqEfeRegIBSUF
    {
        get => _pAliqEfeRegIBSUF;
        set { _pAliqEfeRegIBSUF = value; OnPropertyChanged(); }
    }

    [XmlElement("vTribRegIBSUF")]
    public string? vTribRegIBSUF
    {
        get => _vTribRegIBSUF;
        set { _vTribRegIBSUF = value; OnPropertyChanged(); }
    }

    [XmlElement("pAliqEfeRegIBSMun")]
    public string? pAliqEfeRegIBSMun
    {
        get => _pAliqEfeRegIBSMun;
        set { _pAliqEfeRegIBSMun = value; OnPropertyChanged(); }
    }

    [XmlElement("vTribRegIBSMun")]
    public string? vTribRegIBSMun
    {
        get => _vTribRegIBSMun;
        set { _vTribRegIBSMun = value; OnPropertyChanged(); }
    }

    [XmlElement("pAliqEfeRegCBS")]
    public string? pAliqEfeRegCBS
    {
        get => _pAliqEfeRegCBS;
        set { _pAliqEfeRegCBS = value; OnPropertyChanged(); }
    }

    [XmlElement("vTribRegCBS")]
    public string? vTribRegCBS
    {
        get => _vTribRegCBS;
        set { _vTribRegCBS = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCTotalTribCompraGov", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCTotalTribCompraGov : NFSeNacionalBase
{
    private string? _pIBSUF;
    private string? _vIBSUF;
    private string? _pIBSMun;
    private string? _vIBSMun;
    private string? _pCBS;
    private string? _vCBS;

    [XmlElement("pIBSUF")]
    public string? pIBSUF
    {
        get => _pIBSUF;
        set { _pIBSUF = value; OnPropertyChanged(); }
    }

    [XmlElement("vIBSUF")]
    public string? vIBSUF
    {
        get => _vIBSUF;
        set { _vIBSUF = value; OnPropertyChanged(); }
    }

    [XmlElement("pIBSMun")]
    public string? pIBSMun
    {
        get => _pIBSMun;
        set { _pIBSMun = value; OnPropertyChanged(); }
    }

    [XmlElement("vIBSMun")]
    public string? vIBSMun
    {
        get => _vIBSMun;
        set { _vIBSMun = value; OnPropertyChanged(); }
    }

    [XmlElement("pCBS")]
    public string? pCBS
    {
        get => _pCBS;
        set { _pCBS = value; OnPropertyChanged(); }
    }

    [XmlElement("vCBS")]
    public string? vCBS
    {
        get => _vCBS;
        set { _vCBS = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Tipo complexo para informações declaradas referentes a IBS/CBS (`TCRTCInfoIBSCBS`).
/// </summary>
[XmlType("TCRTCInfoIBSCBS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoIBSCBS : NFSeNacionalBase
{
    private string? _finNFSe;
    private string? _indFinal;
    private string? _cIndOp;
    private string? _tpOper;
    private TCInfoRefNFSe? _gRefNFSe;
    private string? _tpEnteGov;
    private string? _indDest;
    private TCRTCInfoDest? _dest;
    private TCRTCInfoImovel? _imovel;
    private TCRTCInfoValoresIBSCBS? _valores;

    [XmlElement("finNFSe")]
    public string? finNFSe
    {
        get => _finNFSe;
        set { _finNFSe = value; OnPropertyChanged(); }
    }

    [XmlElement("indFinal")]
    public string? indFinal
    {
        get => _indFinal;
        set { _indFinal = value; OnPropertyChanged(); }
    }

    [XmlElement("cIndOp")]
    public string? cIndOp
    {
        get => _cIndOp;
        set { _cIndOp = value; OnPropertyChanged(); }
    }

    [XmlElement("tpOper")]
    public string? tpOper
    {
        get => _tpOper;
        set { _tpOper = value; OnPropertyChanged(); }
    }

    [XmlElement("gRefNFSe")]
    public TCInfoRefNFSe? gRefNFSe
    {
        get => _gRefNFSe;
        set { _gRefNFSe = value; OnPropertyChanged(); }
    }

    [XmlElement("tpEnteGov")]
    public string? tpEnteGov
    {
        get => _tpEnteGov;
        set { _tpEnteGov = value; OnPropertyChanged(); }
    }

    [XmlElement("indDest")]
    public string? indDest
    {
        get => _indDest;
        set { _indDest = value; OnPropertyChanged(); }
    }

    [XmlElement("dest")]
    public TCRTCInfoDest? dest
    {
        get => _dest;
        set { _dest = value; OnPropertyChanged(); }
    }

    [XmlElement("imovel")]
    public TCRTCInfoImovel? imovel
    {
        get => _imovel;
        set { _imovel = value; OnPropertyChanged(); }
    }

    [XmlElement("valores")]
    public TCRTCInfoValoresIBSCBS? valores
    {
        get => _valores;
        set { _valores = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de NFS-e referenciadas (`TCInfoRefNFSe`).
/// </summary>
[XmlType("TCInfoRefNFSe", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCInfoRefNFSe : NFSeNacionalBase
{
    private string[]? _refNFSe;

    [XmlElement("refNFSe")]
    public string[]? refNFSe
    {
        get => _refNFSe;
        set { _refNFSe = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Informações relativas ao destinatário do IBS/CBS (`TCRTCInfoDest`).
/// </summary>
[XmlType("TCRTCInfoDest", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoDest : NFSeNacionalBase
{
    private string? _cNPJ;
    private string? _cPF;
    private string? _nIF;
    private string? _cNaoNIF;
    private string? _xNome;
    private TCEndereco? _end;
    private string? _fone;
    private string? _email;

    [XmlElement("CNPJ")]
    public string? CNPJ
    {
        get => _cNPJ;
        set { _cNPJ = value; OnPropertyChanged(); }
    }

    [XmlElement("CPF")]
    public string? CPF
    {
        get => _cPF;
        set { _cPF = value; OnPropertyChanged(); }
    }

    [XmlElement("NIF")]
    public string? NIF
    {
        get => _nIF;
        set { _nIF = value; OnPropertyChanged(); }
    }

    [XmlElement("cNaoNIF")]
    public string? cNaoNIF
    {
        get => _cNaoNIF;
        set { _cNaoNIF = value; OnPropertyChanged(); }
    }

    [XmlElement("xNome")]
    public string? xNome
    {
        get => _xNome;
        set { _xNome = value; OnPropertyChanged(); }
    }

    [XmlElement("end")]
    public TCEndereco? end
    {
        get => _end;
        set { _end = value; OnPropertyChanged(); }
    }

    [XmlElement("fone")]
    public string? fone
    {
        get => _fone;
        set { _fone = value; OnPropertyChanged(); }
    }

    [XmlElement("email")]
    public string? email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Informações relativas a bens imóveis IBSCBS (`TCRTCInfoImovel`).
/// </summary>
[XmlType("TCRTCInfoImovel", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoImovel : NFSeNacionalBase
{
    private string? _inscImobFisc;
    private string? _cCIB;
    private TCEnderObraEvento? _end;

    [XmlElement("inscImobFisc")]
    public string? inscImobFisc
    {
        get => _inscImobFisc;
        set { _inscImobFisc = value; OnPropertyChanged(); }
    }

    [XmlElement("cCIB")]
    public string? cCIB
    {
        get => _cCIB;
        set { _cCIB = value; OnPropertyChanged(); }
    }

    [XmlElement("end")]
    public TCEnderObraEvento? end
    {
        get => _end;
        set { _end = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de valores do IBS/CBS (`TCRTCInfoValoresIBSCBS`).
/// </summary>
[XmlType("TCRTCInfoValoresIBSCBS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoValoresIBSCBS : NFSeNacionalBase
{
    private TCRTCInfoReeRepRes? _gReeRepRes;
    private TCRTCInfoTributosIBSCBS? _trib;

    [XmlElement("gReeRepRes")]
    public TCRTCInfoReeRepRes? gReeRepRes
    {
        get => _gReeRepRes;
        set { _gReeRepRes = value; OnPropertyChanged(); }
    }

    [XmlElement("trib")]
    public TCRTCInfoTributosIBSCBS? trib
    {
        get => _trib;
        set { _trib = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de documentos referenciados em reembolso/repasse/ressarcimento (`TCRTCInfoReeRepRes`).
/// </summary>
[XmlType("TCRTCInfoReeRepRes", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoReeRepRes : NFSeNacionalBase
{
    private TCRTCListaDoc[]? _documentos;

    [XmlElement("documentos")]
    public TCRTCListaDoc[]? documentos
    {
        get => _documentos;
        set { _documentos = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Grupo de tributos IBS/CBS (`TCRTCInfoTributosIBSCBS`).
/// </summary>
[XmlType("TCRTCInfoTributosIBSCBS", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoTributosIBSCBS : NFSeNacionalBase
{
    private TCRTCInfoTributosSitClas? _gIBSCBS;

    [XmlElement("gIBSCBS")]
    public TCRTCInfoTributosSitClas? gIBSCBS
    {
        get => _gIBSCBS;
        set { _gIBSCBS = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Lista genérica de documentos para reembolso/repasse (`TCRTCListaDoc`).
/// </summary>
[XmlType("TCRTCListaDoc", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCListaDoc : NFSeNacionalBase
{
    private TCRTCListaDocDFe? _dFeNacional;
    private TCRTCListaDocFiscalOutro? _docFiscalOutro;
    private TCRTCListaDocOutro? _docOutro;
    private TCRTCListaDocFornec? _fornec;
    private DateTime? _dtEmiDoc;
    private DateTime? _dtCompDoc;
    private string? _tpReeRepRes;
    private string? _xTpReeRepRes;
    private string? _vlrReeRepRes;

    [XmlElement("dFeNacional")]
    public TCRTCListaDocDFe? dFeNacional
    {
        get => _dFeNacional;
        set { _dFeNacional = value; OnPropertyChanged(); }
    }

    [XmlElement("docFiscalOutro")]
    public TCRTCListaDocFiscalOutro? docFiscalOutro
    {
        get => _docFiscalOutro;
        set { _docFiscalOutro = value; OnPropertyChanged(); }
    }

    [XmlElement("docOutro")]
    public TCRTCListaDocOutro? docOutro
    {
        get => _docOutro;
        set { _docOutro = value; OnPropertyChanged(); }
    }

    [XmlElement("fornec")]
    public TCRTCListaDocFornec? fornec
    {
        get => _fornec;
        set { _fornec = value; OnPropertyChanged(); }
    }

    [XmlElement("dtEmiDoc", DataType = "date")]
    public DateTime? dtEmiDoc
    {
        get => _dtEmiDoc;
        set { _dtEmiDoc = value; OnPropertyChanged(); }
    }

    [XmlElement("dtCompDoc", DataType = "date")]
    public DateTime? dtCompDoc
    {
        get => _dtCompDoc;
        set { _dtCompDoc = value; OnPropertyChanged(); }
    }

    [XmlElement("tpReeRepRes")]
    public string? tpReeRepRes
    {
        get => _tpReeRepRes;
        set { _tpReeRepRes = value; OnPropertyChanged(); }
    }

    [XmlElement("xTpReeRepRes")]
    public string? xTpReeRepRes
    {
        get => _xTpReeRepRes;
        set { _xTpReeRepRes = value; OnPropertyChanged(); }
    }

    [XmlElement("vlrReeRepRes")]
    public string? vlrReeRepRes
    {
        get => _vlrReeRepRes;
        set { _vlrReeRepRes = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Documento eletrônico no repositório nacional (`TCRTCListaDocDFe`).
/// </summary>
[XmlType("TCRTCListaDocDFe", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCListaDocDFe : NFSeNacionalBase
{
    private string? _tipoChaveDFe;
    private string? _xTipoChaveDFe;
    private string? _chaveDFe;

    [XmlElement("tipoChaveDFe")]
    public string? tipoChaveDFe
    {
        get => _tipoChaveDFe;
        set { _tipoChaveDFe = value; OnPropertyChanged(); }
    }

    [XmlElement("xTipoChaveDFe")]
    public string? xTipoChaveDFe
    {
        get => _xTipoChaveDFe;
        set { _xTipoChaveDFe = value; OnPropertyChanged(); }
    }

    [XmlElement("chaveDFe")]
    public string? chaveDFe
    {
        get => _chaveDFe;
        set { _chaveDFe = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Documento fiscal que não está no repositório nacional (`TCRTCListaDocFiscalOutro`).
/// </summary>
[XmlType("TCRTCListaDocFiscalOutro", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCListaDocFiscalOutro : NFSeNacionalBase
{
    private string? _cMunDocFiscal;
    private string? _nDocFiscal;
    private string? _xDocFiscal;

    [XmlElement("cMunDocFiscal")]
    public string? cMunDocFiscal
    {
        get => _cMunDocFiscal;
        set { _cMunDocFiscal = value; OnPropertyChanged(); }
    }

    [XmlElement("nDocFiscal")]
    public string? nDocFiscal
    {
        get => _nDocFiscal;
        set { _nDocFiscal = value; OnPropertyChanged(); }
    }

    [XmlElement("xDocFiscal")]
    public string? xDocFiscal
    {
        get => _xDocFiscal;
        set { _xDocFiscal = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Documento não fiscal (`TCRTCListaDocOutro`).
/// </summary>
[XmlType("TCRTCListaDocOutro", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCListaDocOutro : NFSeNacionalBase
{
    private string? _nDoc;
    private string? _xDoc;

    [XmlElement("nDoc")]
    public string? nDoc
    {
        get => _nDoc;
        set { _nDoc = value; OnPropertyChanged(); }
    }

    [XmlElement("xDoc")]
    public string? xDoc
    {
        get => _xDoc;
        set { _xDoc = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Fornecedor do documento referenciado (`TCRTCListaDocFornec`).
/// </summary>
[XmlType("TCRTCListaDocFornec", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCListaDocFornec : NFSeNacionalBase
{
    private string? _cNPJ;
    private string? _cPF;
    private string? _nIF;
    private string? _cNaoNIF;
    private string? _xNome;

    [XmlElement("CNPJ")]
    public string? CNPJ
    {
        get => _cNPJ;
        set { _cNPJ = value; OnPropertyChanged(); }
    }

    [XmlElement("CPF")]
    public string? CPF
    {
        get => _cPF;
        set { _cPF = value; OnPropertyChanged(); }
    }

    [XmlElement("NIF")]
    public string? NIF
    {
        get => _nIF;
        set { _nIF = value; OnPropertyChanged(); }
    }

    [XmlElement("cNaoNIF")]
    public string? cNaoNIF
    {
        get => _cNaoNIF;
        set { _cNaoNIF = value; OnPropertyChanged(); }
    }

    [XmlElement("xNome")]
    public string? xNome
    {
        get => _xNome;
        set { _xNome = value; OnPropertyChanged(); }
    }
}

/// <summary>
/// Informações de situação e classificação dos tributos IBS/CBS (`TCRTCInfoTributosSitClas`).
/// </summary>
[XmlType("TCRTCInfoTributosSitClas", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoTributosSitClas : NFSeNacionalBase
{
    private string? _CST;
    private string? _cClassTrib;
    private string? _cCredPres;
    private TCRTCInfoTributosTribRegular? _gTribRegular;
    private TCRTCInfoTributosDif? _gDif;

    [XmlElement("CST")]
    public string? CST
    {
        get => _CST;
        set { _CST = value; OnPropertyChanged(); }
    }

    [XmlElement("cClassTrib")]
    public string? cClassTrib
    {
        get => _cClassTrib;
        set { _cClassTrib = value; OnPropertyChanged(); }
    }

    [XmlElement("cCredPres")]
    public string? cCredPres
    {
        get => _cCredPres;
        set { _cCredPres = value; OnPropertyChanged(); }
    }

    [XmlElement("gTribRegular")]
    public TCRTCInfoTributosTribRegular? gTribRegular
    {
        get => _gTribRegular;
        set { _gTribRegular = value; OnPropertyChanged(); }
    }

    [XmlElement("gDif")]
    public TCRTCInfoTributosDif? gDif
    {
        get => _gDif;
        set { _gDif = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCInfoTributosTribRegular", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoTributosTribRegular : NFSeNacionalBase
{
    private string? _CSTReg;
    private string? _cClassTribReg;

    [XmlElement("CSTReg")]
    public string? CSTReg
    {
        get => _CSTReg;
        set { _CSTReg = value; OnPropertyChanged(); }
    }

    [XmlElement("cClassTribReg")]
    public string? cClassTribReg
    {
        get => _cClassTribReg;
        set { _cClassTribReg = value; OnPropertyChanged(); }
    }
}

[XmlType("TCRTCInfoTributosDif", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCRTCInfoTributosDif : NFSeNacionalBase
{
    private string? _pDifUF;
    private string? _pDifMun;
    private string? _pDifCBS;

    [XmlElement("pDifUF")]
    public string? pDifUF
    {
        get => _pDifUF;
        set { _pDifUF = value; OnPropertyChanged(); }
    }

    [XmlElement("pDifMun")]
    public string? pDifMun
    {
        get => _pDifMun;
        set { _pDifMun = value; OnPropertyChanged(); }
    }

    [XmlElement("pDifCBS")]
    public string? pDifCBS
    {
        get => _pDifCBS;
        set { _pDifCBS = value; OnPropertyChanged(); }
    }
}

/* ----------------------------- TIPOS DIVERSOS (END-RELATED/OBRA/EVENTO) ----------------------------- */

[XmlType("TCEnderObraEvento", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCEnderObraEvento : NFSeNacionalBase
{
    private string? _CEP;
    private TCEnderExtSimples? _endExt;
    private string? _xLgr;
    private string? _nro;
    private string? _xCpl;
    private string? _xBairro;

    [XmlElement("CEP")]
    public string? CEP
    {
        get => _CEP;
        set { _CEP = value; OnPropertyChanged(); }
    }

    [XmlElement("endExt")]
    public TCEnderExtSimples? endExt
    {
        get => _endExt;
        set { _endExt = value; OnPropertyChanged(); }
    }

    [XmlElement("xLgr")]
    public string? xLgr
    {
        get => _xLgr;
        set { _xLgr = value; OnPropertyChanged(); }
    }

    [XmlElement("nro")]
    public string? nro
    {
        get => _nro;
        set { _nro = value; OnPropertyChanged(); }
    }

    [XmlElement("xCpl")]
    public string? xCpl
    {
        get => _xCpl;
        set { _xCpl = value; OnPropertyChanged(); }
    }

    [XmlElement("xBairro")]
    public string? xBairro
    {
        get => _xBairro;
        set { _xBairro = value; OnPropertyChanged(); }
    }
}

[XmlType("TCEnderecoSimples", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCEnderecoSimples : NFSeNacionalBase
{
    private string? _CEP;
    private TCEnderExtSimples? _endExt;
    private string? _xLgr;
    private string? _nro;
    private string? _xCpl;
    private string? _xBairro;

    [XmlElement("CEP")]
    public string? CEP
    {
        get => _CEP;
        set { _CEP = value; OnPropertyChanged(); }
    }

    [XmlElement("endExt")]
    public TCEnderExtSimples? endExt
    {
        get => _endExt;
        set { _endExt = value; OnPropertyChanged(); }
    }

    [XmlElement("xLgr")]
    public string? xLgr
    {
        get => _xLgr;
        set { _xLgr = value; OnPropertyChanged(); }
    }

    [XmlElement("nro")]
    public string? nro
    {
        get => _nro;
        set { _nro = value; OnPropertyChanged(); }
    }

    [XmlElement("xCpl")]
    public string? xCpl
    {
        get => _xCpl;
        set { _xCpl = value; OnPropertyChanged(); }
    }

    [XmlElement("xBairro")]
    public string? xBairro
    {
        get => _xBairro;
        set { _xBairro = value; OnPropertyChanged(); }
    }
}

[XmlType("TCEnderExtSimples", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
public class TCEnderExtSimples : NFSeNacionalBase
{
    private string? _cEndPost;
    private string? _xCidade;
    private string? _xEstProvReg;

    [XmlElement("cEndPost")]
    public string? cEndPost
    {
        get => _cEndPost;
        set { _cEndPost = value; OnPropertyChanged(); }
    }

    [XmlElement("xCidade")]
    public string? xCidade
    {
        get => _xCidade;
        set { _xCidade = value; OnPropertyChanged(); }
    }

    [XmlElement("xEstProvReg")]
    public string? xEstProvReg
    {
        get => _xEstProvReg;
        set { _xEstProvReg = value; OnPropertyChanged(); }
    }
}

/* ----------------------------- OBSERVAÇÕES FINAIS -----------------------------
   - Cobri um conjunto abrangente de tipos complexos referenciados nos XSDs fornecidos.
   - Para preservar a legibilidade e manter compatibilidade XML, propriedades foram nomeadas conforme os elementos XSD.
   - Se desejar, posso:
     1) transformar simplesTypes específicos em enums com [XmlEnum] (atualmente mantive muitos como string para evitar ambiguidade);
     2) reduzir/expandir tipos gerados;
     3) executar validação de serialização/deserialize com exemplos XML.
-------------------------------------------------------------------------------- */