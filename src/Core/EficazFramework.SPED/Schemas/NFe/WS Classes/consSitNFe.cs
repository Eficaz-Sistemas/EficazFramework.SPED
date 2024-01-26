using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.NFe;

[Serializable()]
[XmlType(TypeName = "consSitNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class PedidoConsultaSituacaoNFe
{
    [XmlElement("tpAmb")]
    public Ambiente Ambiente { get; set; }

    [XmlElement("xServ")]
    public string Servico { get; set; } = "CONSULTAR";

    [XmlElement("chNFe")]
    public string ChaveNFe {  get; set; }

    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoConsSitNFe Versao {  get; set; }

    private static XmlSerializer Serializer { get; set; }

    /// <summary>
    /// Serializes current PedidoConsultaSituacaoNFe object into an XML document
    /// </summary>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(PedidoConsultaSituacaoNFe));
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

    /// <summary>
    /// Semelhante À Function Serialize, porém já retorna o resultado
    /// em uma instância de XmlDocument, agilizando o processo de assinatura
    /// digital dos eventos.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public virtual XDocument SerializeToXMLDocument()
    {
        string str = Serialize();
        if (!string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str))
        {
            var doc = XDocument.Load(Serialize());
            return doc;
        }
        else
        {
            return null;
        }
    }

    public static PedidoConsultaSituacaoNFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(PedidoConsultaSituacaoNFe));
            return (PedidoConsultaSituacaoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static PedidoConsultaSituacaoNFe Deserialize(System.IO.Stream s)
        => (PedidoConsultaSituacaoNFe) Serializer.Deserialize(s);
}


[Serializable()]
[XmlType(TypeName = "retConsSitNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class RetornoConsultaSituacaoNFe
{
    [XmlElement("tpAmb")]
    public Ambiente Ambiente { get; set; }

    [XmlElement("verAplic")]
    public string VersaoAplicativo { get; set; }

    [XmlElement("cStat")]
    public string RetornoCodigo { get; set; }

    [XmlElement("xMotivo")]
    public string RetornoDescricao { get; set; }

    [XmlElement("cUF")]
    public OrgaoIBGE UF {  get; set; }

    [XmlElement("chNFe")]
    public string ChaveNFe {  get; set; }

    [XmlElement("protNFe")]
    public ProtocoloRecebimentoConsSitNFe ProtocoloNFe {  get; set; }

    [XmlElement("procEventoNFe")]
    public ObservableCollection<Evento> RetornoEventos {  get; set; }

    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoConsSitNFe Versao {  get; set; }

    private static XmlSerializer Serializer { get; set; }

    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(RetornoConsultaSituacaoNFe));
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

    public static RetornoConsultaSituacaoNFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(RetornoConsultaSituacaoNFe));
            return (RetornoConsultaSituacaoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static RetornoConsultaSituacaoNFe Deserialize(System.IO.Stream s)
        => (RetornoConsultaSituacaoNFe) Serializer.Deserialize(s);
}


public partial class ProtocoloRecebimentoConsSitNFe
{
    [XmlElement("infProt")]
    public InformacoesProtocoloConsSitNFe InformacoesProtocolo { get; set; }

    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature { get; set; }

    [XmlAttribute()]
    public string versao { get; set; }
}


public partial class InformacoesProtocoloConsSitNFe
{
    [XmlElement("tpAmb")]
    public Ambiente Ambiente { get; set; }

    [XmlElement("verAplic")]
    public string VersaoAplicativo { get; set; }

    [XmlElement("chNFe")]
    public string ChaveNFe { get; set; }

    [XmlElement("dhRecbto")]
    public DateTime DataHoraRecebimento { get; set; }

    [XmlElement("nProt")]
    public string Protocolo { get; set; }

    [XmlElement("digVal", DataType = "base64Binary")]
    public byte[] DigestValue { get; set; }

    [XmlElement("cStat")]
    public string StatusNFeCodigo { get; set; }

    [XmlElement("xMotivo")]
    public string StatusNfeMotivo { get; set; }

    [XmlAttribute(DataType = "ID")]
    public string Id { get; set; }
}