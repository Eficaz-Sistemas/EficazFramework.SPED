namespace EficazFramework.SPED.Schemas.NFe;

[Serializable()]
[XmlType(TypeName = "consStatServ", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class PedidoConsultaStatusServicoNFe
{
    [XmlElement("tpAmb")]
    public Ambiente Ambiente { get; set; }

    [XmlElement("cUF")]
    public OrgaoIBGE UF { get; set; }

    [XmlElement("xServ")]
    public string Servico { get; set; } = "STATUS";


    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoConsSitNFe Versao {  get; set; }

    private static XmlSerializer Serializer { get; set; }

    /// <summary>
    /// Serializes current PedidoConsultaStatusServicoNFe object into an XML document
    /// </summary>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(PedidoConsultaStatusServicoNFe));
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

    public static PedidoConsultaStatusServicoNFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(PedidoConsultaStatusServicoNFe));
            return (PedidoConsultaStatusServicoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static PedidoConsultaStatusServicoNFe Deserialize(System.IO.Stream s)
        => (PedidoConsultaStatusServicoNFe) Serializer.Deserialize(s);
}


[Serializable()]
[XmlType(TypeName = "retConsStatServ", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class RetornoConsultaStatusServicoNFe
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

    [XmlElement("dhRecbto")]
    public DateTime? DataRecebimento {  get; set; }

    [XmlElement("tMed")]
    public int? TempoMedioResposta {  get; set; }

    [XmlElement("dhRetorno")]
    public DateTime? DataRetorno { get; set; }

    [XmlElement("xObs")]
    public string Observacoes { get; set; }

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
            Serializer ??= new XmlSerializer(typeof(RetornoConsultaStatusServicoNFe));
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

    public static RetornoConsultaStatusServicoNFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(RetornoConsultaStatusServicoNFe));
            return (RetornoConsultaStatusServicoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static RetornoConsultaStatusServicoNFe Deserialize(System.IO.Stream s)
        => (RetornoConsultaStatusServicoNFe) Serializer.Deserialize(s);
}