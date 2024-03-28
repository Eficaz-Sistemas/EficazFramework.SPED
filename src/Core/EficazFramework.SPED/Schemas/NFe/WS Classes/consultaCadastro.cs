using EficazFramework.SPED.Extensions;
using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.NFe;

[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum TipoPesquisaCadastro
{
    [System.ComponentModel.Description("CNPJ")] // , False)>
    CNPJ,
    [System.ComponentModel.Description("CPF")] // , False)>
    CPF,
    [System.ComponentModel.Description("Inscrição Estadual")] // , False)>
    IE
}

[XmlType("TRetConsCadInfConsInfCadCSit", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum Situacao
{
    [XmlEnum("0")]
    NaoHabilitado,
    [XmlEnum("1")]
    Habilitado
}

[XmlType("TRetConsCadInfConsInfCadIndCredNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CredenciamentoNFe
{
    [XmlEnum("0")]
    NaoCredenciado,
    [XmlEnum("1")]
    Credenciado,
    [XmlEnum("2")]
    ObrigacaoTotal,
    [XmlEnum("3")]
    ObrigacaoParcial,
    [XmlEnum("4")]
    SemInformacao
}

[Serializable()]
[XmlType("TRetConsCadInfConsInfCadIndCredCTe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public enum CredenciamentoCte
{
    [XmlEnum("0")]
    NaoCredenciado,
    [XmlEnum("1")]
    Credenciado,
    [XmlEnum("2")]
    ObrigacaoTotal,
    [XmlEnum("3")]
    ObrigacaoParcial,
    [XmlEnum("4")]
    SemInformacao
}


[Serializable()]
[XmlType("http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("ConsCad", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class PedidoConsultaCadastro
{
    [XmlElement("infCons", Order = 0)]
    public PedidoConsultaCadContribInfo Informacoes {  get; set; }

    [XmlAttribute("versao")]
    public VersaoServicoConsCadastro versao {  get; set; }

    private static XmlSerializer Serializer {  get; set; }

    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(PedidoConsultaCadastro));
            Serializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
            streamReader = new System.IO.StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
            memoryStream?.Dispose();
        }
    }

    public virtual XmlDocument SerializeToXMLDocument()
    {
        string str = Serialize();
        if (!string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str))
        {
            var doc = new XmlDocument();
            doc.LoadXml(str);
            return doc;
        }
        else
        {
            return null;
        }
    }


    public static PedidoConsultaCadastro Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(PedidoConsultaCadastro));
            return (PedidoConsultaCadastro)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static PedidoConsultaCadastro Deserialize(System.IO.Stream s)
         => (PedidoConsultaCadastro) Serializer.Deserialize(s);
}

public partial class PedidoConsultaCadContribInfo
{
    [XmlElement(Order = 0)]
    public string xServ { get; set; } = "CONS-CAD";

    [XmlElement(Order = 1)]
    public string UF {  get; set; }

    [XmlElement("CNPJ", typeof(string), Order = 2)]
    [XmlElement("CPF", typeof(string), Order = 2)]
    [XmlElement("IE", typeof(string), Order = 2)]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Item { get; set; }

    [XmlElement(Order = 3)]
    [XmlIgnore()]
    public TipoPesquisaCadastro ItemElementName { get; set; }
}


[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("retConsCad", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class RetornoConsultaCadastro
{
    [XmlElement("infCons")]
    public RetornoConsultaCadastroInfo Informacoes { get; set; }

    [XmlAttribute(DataType = "token")]
    public string versao {  get; set; }

    private static XmlSerializer Serializer { get; set; }

    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(RetornoConsultaCadastro));
            Serializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
            streamReader = new System.IO.StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
            memoryStream?.Dispose();
        }
    }

    public virtual XmlDocument SerializeToXMLDocument()
    {
        string str = Serialize();
        if (!string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str))
        {
            var doc = new XmlDocument();
            doc.LoadXml(str);
            return doc;
        }
        else
        {
            return null;
        }
    }

    public static RetornoConsultaCadastro Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(RetornoConsultaCadastro));
            return (RetornoConsultaCadastro)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            return null;
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static RetornoConsultaCadastro Deserialize(System.IO.Stream s)
        => (RetornoConsultaCadastro) Serializer.Deserialize(s);
}

public partial class RetornoConsultaCadastroInfo
{
    [XmlElement("verAplic")]
    public string verAplic { get; set; }

    [XmlElement("cStat")]
    public string Codigo { get; set; }

    [XmlElement("xMotivo")]
    public string Motivo { get; set; }

    [XmlElement()]
    public string UF {  get; set; }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlElement("IE", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Documento { get; set; }

    [XmlElement()]
    [XmlIgnore()]
    public TipoPesquisaCadastro ItemElementName { get; set; }

    [XmlElement("dhCons")]
    public DateTime DataHoraConsulta {  get; set; }

    [XmlElement("cUF")]
    public OrgaoIBGE Uf { get; set; }

    [XmlElement("infCad")]
    public ObservableCollection<RetornoConsultaCadastroInfoCadastro> CadastrosRetornados { get; set; }
}

public partial class RetornoConsultaCadastroInfoCadastro
{
    [XmlElement("IE")]
    public string InscricaoEstadual { get; set; }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string CnpjCpf { get ; set; }

    [XmlElement()]
    [XmlIgnore()]
    public PersonalidadeJuridica ItemElementName { get; set; }

    [XmlElement()]
    public string UF {  get; set; }

    [XmlIgnore()]
    public Estado? UfEnumerador
    {
        get
        {
            if (!(string.IsNullOrEmpty(UF) | string.IsNullOrWhiteSpace(UF)))
                return (Estado)int.Parse(UF);
            else
                return null;
        }
    }

    [XmlElement("cSit")]
    public Situacao Situacao { get; set; }

    [XmlElement()]
    public CredenciamentoNFe indCredNFe { get; set; }

    [XmlElement()]
    public CredenciamentoCte indCredCTe { get;  set; }

    [XmlElement("xNome")]
    public string RazaoSocialNome { get; set; }

    [XmlElement("xFant")]
    public string NomeFantasia { get; set; }

    [XmlElement("xRegApur", DataType = "token")]
    public string RegimeApuracao { get; set; }

    [XmlElement(DataType = "token")]
    public string CNAE { get; set; }

    [XmlElement("dIniAtiv")]
    public string DataInicioAtividades { get; set; }

    [XmlElement("dUltSit")]
    public string DataSituacaoCadastral {  get; set; }

    [XmlElement("dBaixa")]
    public string DataBaixa { get; set; }

    [XmlElement("IEUnica")]
    public string InscricaoEstadualUnica { get; set; }

    [XmlElement("IEAtual")]
    public string InscricaoEstadualAtual { get; set; }

    [XmlElement("ender")]
    public ConsultaCadastroEndereco Endereco { get; set; }

    public override string ToString()
        => $"Nome: {RazaoSocialNome}; CNPJ / CPF: {CnpjCpf.FormatRFBDocument()}; Inscrição Estadual: {InscricaoEstadual}; CNAE: {CNAE}";
}

public partial class ConsultaCadastroEndereco
{
    [XmlElement("xLgr")]
    public string Logradouro { get; set; }

    [XmlElement("nro")]
    public string Numero { get; set; }

    [XmlElement("xCpl")]
    public string Complemento { get; set; }

    [XmlElement("xBairro")]
    public string xBairro { get; set; }

    [XmlElement("cMun")]
    public string MunicipioCodigo { get; set; }

    [XmlElement("xMun")]
    public string MunicipioNome { get; set; }

    [XmlElement(DataType = "token")]
    public string CEP { get; set; }
}