namespace EficazFramework.SPED.Schemas.NFe;

[Serializable()]
[XmlType(TypeName = "enviNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class PedidoAutorizacaoNFe
{
    [XmlElement("idLote")]
    public string IdentificadorLote { get; set; }

    [XmlElement("indSinc")]
    public IndicadorAutorizacao IndicadorAutorizacao { get; set; } = IndicadorAutorizacao.Sincrono;

    [XmlElement("NFe")]
    public List<NFe> NotasFiscais { get; set; } = [];

    [XmlAttribute("versao")]
    public string Versao { get; set; } = "4.00";


    private static XmlSerializer Serializer { get; set; }

    /// <summary>
    /// Serializes current PedidoAutorizacaoNFe object into an XML document
    /// </summary>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(PedidoAutorizacaoNFe));
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

    public static PedidoConsultaSituacaoNFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(PedidoAutorizacaoNFe));
            return (PedidoConsultaSituacaoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static PedidoConsultaSituacaoNFe Deserialize(System.IO.Stream s)
        => (PedidoConsultaSituacaoNFe)Serializer.Deserialize(s);
}

[Serializable()]
[XmlType(TypeName = "retEnviNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class RetornoAutorizacaoNFe
{
    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoConsSitNFe Versao { get; set; }

    [XmlElement("tpAmb")]
    public Ambiente Ambiente { get; set; }

    [XmlElement("cStat")]
    public string RetornoCodigo { get; set; }

    [XmlElement("xMotivo")]
    public string RetornoDescricao { get; set; }

    [XmlElement("cUF")]
    public OrgaoIBGE UF { get; set; }

    [XmlElement("infRec")]
    public OrgaoIBGE ReciboLote { get; set; }

    [XmlElement("protNFe")]
    public ProtocoloRecebimento ProtocoloRecebimento { get; set; }

    private static XmlSerializer Serializer { get; set; }

    /// <summary>
    /// Serializes current RetornoAutorizacaoNFe object into an XML document
    /// </summary>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(RetornoAutorizacaoNFe));
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

    public static RetornoAutorizacaoNFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(RetornoAutorizacaoNFe));
            return (RetornoAutorizacaoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static RetornoAutorizacaoNFe Deserialize(System.IO.Stream s)
        => (RetornoAutorizacaoNFe)Serializer.Deserialize(s);
}

public class InformacaoReciboLote
{
    [XmlElement("nRec")]
    public string NumeroRecibo { get; set; }

    [XmlElement("tMed")]
    public decimal TempoMedioResposta { get; set; }

}
