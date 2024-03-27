namespace EficazFramework.SPED.Schemas.NFe;

[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("ProcInutNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
public partial class ProcessoInutilizacaoNFe : INotifyPropertyChanged, IXmlSpedDocument
{
    private InutilizacaoNFe inutNFeField;
    private InutilizacaoRetorno retInutNFeField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    /// <remarks/>
    [XmlElement(ElementName = "inutNFe", Order = 0)]
    public InutilizacaoNFe Inutilizacao
    {
        get => inutNFeField;
        set
        {
            inutNFeField = value;
            RaisePropertyChanged(nameof(Inutilizacao));
        }
    }

    /// <remarks/>
    [XmlElement(ElementName = "retInutNFe", Order = 1)]
    public InutilizacaoRetorno RetornoInutilizacao
    {
        get => retInutNFeField;
        set
        {
            retInutNFeField = value;
            RaisePropertyChanged(nameof(RetornoInutilizacao));
        }
    }

    /// <remarks/>
    [XmlAttribute("token")]
    public string versao
    {
        get => versaoField;
        set
        {
            versaoField = value;
            RaisePropertyChanged(nameof(versao));
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(ProcessoInutilizacaoNFe));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.NFeInutilization;

    [XmlIgnore()]
    public DateTime? DataEmissao => RetornoInutilizacao.infInut.DataRecebimento;

    [System.Text.RegularExpressions.GeneratedRegex("[^0-9]")]
    private static partial System.Text.RegularExpressions.Regex ChaveRegex();

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            // Return Me.Inutilizacao.InformacoesInutilizacao.Id
            if (Inutilizacao.InformacoesInutilizacao.Id != null)
                return ChaveRegex().Replace(Inutilizacao.InformacoesInutilizacao.Id, "");
            else
                return string.Empty;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
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
    /// Deserializes workflow markup into an TNfeProc object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref ProcessoInutilizacaoNFe obj, ref Exception exception)
    {
        exception = null;
        obj = default;
        try
        {
            obj = Deserialize(xml);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanDeserialize(string xml, ref ProcessoInutilizacaoNFe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ProcessoInutilizacaoNFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (ProcessoInutilizacaoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), ProcessoInutilizacaoNFe)
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static ProcessoInutilizacaoNFe Deserialize(System.IO.Stream s) => (ProcessoInutilizacaoNFe)Serializer.Deserialize(s);


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveToFile(System.IO.Stream target, ref Exception exception)
    {
        exception = null;
        try
        {
            SaveTo(target);
            return true;
        }
        catch (Exception e)
        {
            exception = e;
            return false;
        }
    }

    public virtual void SaveTo(System.IO.Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new System.IO.StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            // Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
            // streamWriter = xmlFile.CreateText
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            streamWriter?.Dispose();
        }
    }

    public virtual async void SaveToAsync(System.IO.Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new System.IO.StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            await streamWriter.WriteLineAsync(xmlString);
            await streamWriter.FlushAsync();
        }
        finally
        {
            streamWriter?.Dispose();
        }
    }


    /// <summary>
    /// Deserializes xml markup from file into an TNfeProc object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoInutilizacaoNFe obj, ref Exception exception)
    {
        exception = null;
        obj = default;
        try
        {
            obj = LoadFrom(source);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoInutilizacaoNFe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ProcessoInutilizacaoNFe LoadFrom(System.IO.Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new System.IO.StreamReader(source);
            string xmlString = sr.ReadToEnd();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            source?.Dispose();

            sr?.Dispose();
        }
    }

    public static async Task<ProcessoInutilizacaoNFe> LoadFromAsync(System.IO.Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new System.IO.StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            source?.Dispose();

            sr?.Dispose();
        }
    }

    public static async Task<ProcessoInutilizacaoNFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new System.IO.StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }
}


[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("inutNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
public partial class InutilizacaoNFe : INotifyPropertyChanged
{
    private InformacoesInutilizacaoNFe infInutField;
    private SignatureType signatureField;
    private string versaoField;

    /// <remarks/>
    [XmlElement(ElementName = "infInut", Order = 0)]
    public InformacoesInutilizacaoNFe InformacoesInutilizacao
    {
        get => infInutField;
        set
        {
            infInutField = value;
            RaisePropertyChanged(nameof(InformacoesInutilizacao));
        }
    }

    /// <remarks/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged(nameof(Signature));
        }
    }

    /// <remarks/>
    [XmlAttribute("token")]
    public string versao
    {
        get => versaoField;
        set
        {
            versaoField = value;
            RaisePropertyChanged(nameof(versao));
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));

    private static XmlSerializer sSerializer;
    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(InutilizacaoNFe));
            return sSerializer;
        }
    }
    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
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
}


[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("retInutNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
public partial class InutilizacaoRetorno
{
    [XmlElement(Order = 0)]
    public InutilizacaoRetornoInformacoes infInut { get; set; }

    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature { get; set; }

    [XmlAttribute("token")]
    public string versao { get; set; }


    private static XmlSerializer sSerializer;
    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(InutilizacaoRetorno));
            return sSerializer;
        }
    }

    public static InutilizacaoRetorno Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (InutilizacaoRetorno)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static InutilizacaoRetorno Deserialize(System.IO.Stream s) => (InutilizacaoRetorno)Serializer.Deserialize(s);

}


public partial class InformacoesInutilizacaoNFe
{
    [XmlElement(ElementName = "tpAmb", Order = 0)]
    public Ambiente Ambiente { get; set; }

    [XmlElement(Order = 1)]
    public string xServ { get; set; } = "INUTILIZAR";

    [XmlElement(Order = 2)]
    public OrgaoIBGE cUF { get; set; }

    [XmlElement(Order = 3)]
    public int ano { get; set; }

    [XmlElement(Order = 4)]
    public string CNPJ { get; set; }

    [XmlElement(ElementName = "mod", Order = 5)]
    public ModeloDocumento Modelo { get; set; }

    [XmlElement(Order = 6)]
    public string serie { get; set; }

    [XmlElement(ElementName = "nNFIni", Order = 7)]
    public long NumeroNFInicial { get; set; }

    [XmlElement(ElementName = "nNFFin", Order = 8)]
    public long NumeroNFFinal { get; set; }

    [XmlElement(ElementName = "xJust", Order = 9)]
    public string Justificativa { get; set; }

    [XmlAttribute("Id")]
    public string Id { get; set; }
}

public partial class InutilizacaoRetornoInformacoes
{
    [XmlElement(Order = 0)]
    public Ambiente tpAmb { get; set; }

    [XmlElement(Order = 1)]
    public string verAplic { get; set; }

    [XmlElement(Order = 2)]
    public string cStat { get; set; }

    [XmlElement(Order = 3)]
    public string xMotivo { get; set; }

    [XmlElement(Order = 4)]
    public OrgaoIBGE cUF { get; set; }

    [XmlElement(Order = 5)]
    public string ano { get; set; }

    [XmlElement(Order = 6)]
    public string CNPJ { get; set; }

    [XmlElement(Order = 7)]
    public ModeloDocumento mod { get; set; }

    [XmlIgnore()]
    public bool modSpecified { get; set; } = true;

    [XmlElement(Order = 8)]
    public string serie { get; set; }

    [XmlElement(Order = 9)]
    public string nNFIni { get; set; }

    [XmlElement(Order = 10)]
    public string nNFFin { get; set; }

    [XmlElement(ElementName = "dhRecbto", Order = 11)]
    public DateTime? DataRecebimento { get; set; }

    public bool ShouldSerializeDataRecebimento() => DataRecebimento.HasValue;

    [XmlElement(Order = 12)]
    public string nProt { get; set; }

    [XmlAttribute("Id")]
    public string Id { get; set; }
}