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
}

public partial class InformacoesInutilizacaoNFe : INotifyPropertyChanged
{
    private Ambiente tpAmbField;
    private string xServField = "INUTILIZAR";
    private OrgaoIBGE cUFField;
    private string anoField;
    private string cNPJField;
    private ModeloDocumento modField;
    private string serieField;
    private string nNFIniField;
    private string nNFFinField;
    private string xJustField;
    private string idField;

    /// <remarks/>
    [XmlElement(ElementName = "tpAmb", Order = 0)]
    public Ambiente Ambiente
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(Ambiente));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string xServ
    {
        get => xServField;
        set
        {
            xServField = value;
            RaisePropertyChanged(nameof(xServ));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public OrgaoIBGE cUF
    {
        get => cUFField;
        set
        {
            cUFField = value;
            RaisePropertyChanged(nameof(cUF));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string ano
    {
        get => anoField;
        set
        {
            anoField = value;
            RaisePropertyChanged(nameof(ano));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string CNPJ
    {
        get => cNPJField;
        set
        {
            cNPJField = value;
            RaisePropertyChanged(nameof(CNPJ));
        }
    }

    /// <remarks/>
    [XmlElement(ElementName = "mod", Order = 5)]
    public ModeloDocumento Modelo
    {
        get => modField;
        set
        {
            modField = value;
            RaisePropertyChanged(nameof(Modelo));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string serie
    {
        get => serieField;
        set
        {
            serieField = value;
            RaisePropertyChanged(nameof(serie));
        }
    }

    /// <remarks/>
    [XmlElement(ElementName = "nNFIni", Order = 7)]
    public string NumeroNFInicial
    {
        get => nNFIniField;
        set
        {
            nNFIniField = value;
            RaisePropertyChanged(nameof(NumeroNFInicial));
        }
    }

    /// <remarks/>
    [XmlElement(ElementName = "nNFFin", Order = 8)]
    public string NumeroNFFinal
    {
        get => nNFFinField;
        set
        {
            nNFFinField = value;
            RaisePropertyChanged(nameof(NumeroNFFinal));
        }
    }

    /// <remarks/>
    [XmlElement(ElementName = "xJust", Order = 9)]
    public string Justificativa
    {
        get => xJustField;
        set
        {
            xJustField = value;
            RaisePropertyChanged(nameof(Justificativa));
        }
    }

    /// <remarks/>
    [XmlAttribute("Id")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(Id));
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
}

public partial class InutilizacaoRetorno : INotifyPropertyChanged
{
    private TRetInutNFeInfInut infInutField;
    private SignatureType signatureField;
    private string versaoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TRetInutNFeInfInut infInut
    {
        get => infInutField;
        set
        {
            infInutField = value;
            RaisePropertyChanged(nameof(infInut));
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
}

public partial class TRetInutNFeInfInut : INotifyPropertyChanged
{
    private Ambiente tpAmbField;
    private string verAplicField;
    private string cStatField;
    private string xMotivoField;
    private OrgaoIBGE cUFField;
    private string anoField;
    private string cNPJField;
    private ModeloDocumento modField;
    private bool modFieldSpecified;
    private string serieField;
    private string nNFIniField;
    private string nNFFinField;
    private DateTime? dhRecbtoField;
    private string nProtField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string verAplic
    {
        get => verAplicField;
        set
        {
            verAplicField = value;
            RaisePropertyChanged(nameof(verAplic));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string cStat
    {
        get => cStatField;
        set
        {
            cStatField = value;
            RaisePropertyChanged(nameof(cStat));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string xMotivo
    {
        get => xMotivoField;
        set
        {
            xMotivoField = value;
            RaisePropertyChanged(nameof(xMotivo));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public OrgaoIBGE cUF
    {
        get => cUFField;
        set
        {
            cUFField = value;
            RaisePropertyChanged(nameof(cUF));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string ano
    {
        get => anoField;
        set
        {
            anoField = value;
            RaisePropertyChanged(nameof(ano));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string CNPJ
    {
        get => cNPJField;
        set
        {
            cNPJField = value;
            RaisePropertyChanged(nameof(CNPJ));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public ModeloDocumento mod
    {
        get => modField;
        set
        {
            modField = value;
            RaisePropertyChanged(nameof(mod));
        }
    }

    /// <remarks/>
    [XmlIgnore()]
    public bool modSpecified
    {
        get => modFieldSpecified;
        set
        {
            modFieldSpecified = value;
            RaisePropertyChanged(nameof(modSpecified));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string serie
    {
        get => serieField;
        set
        {
            serieField = value;
            RaisePropertyChanged(nameof(serie));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public string nNFIni
    {
        get => nNFIniField;
        set
        {
            nNFIniField = value;
            RaisePropertyChanged(nameof(nNFIni));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 10)]
    public string nNFFin
    {
        get => nNFFinField;
        set
        {
            nNFFinField = value;
            RaisePropertyChanged(nameof(nNFFin));
        }
    }

    // '''<remarks/>
    // <System.Xml.Serialization.XmlElementAttribute(Order:=11)>
    // Public Property dhRecbto() As String
    // Get
    // If Me.DataRecebimento.HasValue = True Then
    // Return String.Format("{0:yyyy-MM-dd}", Me.DataRecebimento)
    // Else
    // Return Me.dhRecbtoField
    // End If
    // 'Return Me.dhRecbtoField
    // End Get
    // Set(value As String)
    // If ((Me.dhRecbtoField Is Nothing) OrElse (dhRecbtoField.Equals(value) <> True)) Then
    // If value IsNot Nothing Then
    // Dim dt() As String = value.Split("-")
    // Me.dhEmiField = New Date(CInt(dt(0)), CInt(dt(1)), CInt(dt(2).Substring(0, 2)))
    // Else
    // Me.dhEmiField = Nothing
    // End If
    // Me.dhRecbtoField = value
    // End If
    // Me.RaisePropertyChanged("dhRecbto")
    // End Set
    // End Property

    [XmlElement(ElementName = "dhRecbto", Order = 11)]
    public DateTime? DataRecebimento
    {
        get => dhRecbtoField;
        set
        {
            if (dhRecbtoField is null || dhRecbtoField.Equals(value) != true)
            {
                dhRecbtoField = value;
                RaisePropertyChanged(nameof(DataRecebimento));
            }
        }
    }

    public bool ShouldSerializeDataEmissaoXML() => dhRecbtoField.HasValue;


    /// <remarks/>
    [XmlElement(Order = 12)]
    public string nProt
    {
        get => nProtField;
        set
        {
            nProtField = value;
            RaisePropertyChanged(nameof(nProt));
        }
    }

    /// <remarks/>
    [XmlAttribute("Id")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(Id));
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
}