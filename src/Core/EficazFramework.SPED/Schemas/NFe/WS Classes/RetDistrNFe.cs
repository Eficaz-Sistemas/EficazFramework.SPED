using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Objeto retornado pelo serviço, no formato XML.
/// Limite: 50 NF-e
/// </summary>
/// <remarks></remarks>
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(TypeName = "retConsNFeDest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class RetornoConsulta : INotifyPropertyChanged
{
    public RetornoConsulta() : base()
    {
        retField = new List<NFeResultado>();
    }

    private Ambiente tpAmbField = Ambiente.Producao;
    private string verAplicField;
    private string cStatField;
    private string xMotivoField;
    private DateTime dhRespField;
    private IndicadorContinuacao? indContField;
    private string ultNSUField;
    private List<NFeResultado> retField;
    private VersaoServicoConsDestinatario versaoField = VersaoServicoConsDestinatario.Versao_1_01;
    private static XmlSerializer sSerializer;

    [XmlElement("tpAmb")]
    public Ambiente Ambiente
    {
        get
        {
            return tpAmbField;
        }

        set
        {
            if (tpAmbField.Equals(value) != true)
            {
                tpAmbField = value;
                OnPropertyChanged("Ambiente");
            }
        }
    }

    /// <summary>
    /// Versão do aplicativo que processou a consulta
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("verAplic")]
    public string VersaoAplicativo
    {
        get
        {
            return verAplicField;
        }

        set
        {
            if (verAplicField is null || verAplicField.Equals(value) != true)
            {
                verAplicField = value;
                OnPropertyChanged("VersaoAplicativo");
            }
        }
    }

    [XmlElement("cStat")]
    public string RespostaStatus
    {
        get
        {
            return cStatField;
        }

        set
        {
            if (cStatField is null || cStatField.Equals(value) != true)
            {
                cStatField = value;
                OnPropertyChanged("RespostaStatus");
            }
        }
    }

    [XmlElement("xMotivo")]
    public string RespostaDescricao
    {
        get
        {
            return xMotivoField;
        }

        set
        {
            if (xMotivoField is null || xMotivoField.Equals(value) != true)
            {
                xMotivoField = value;
                OnPropertyChanged("RespostaDescricao");
            }
        }
    }

    [XmlElement("dhResp")]
    public DateTime RespostaData
    {
        get
        {
            return dhRespField;
        }

        set
        {
            if (dhRespField.Equals(value) != true)
            {
                dhRespField = value;
                OnPropertyChanged("RespostaData");
            }
        }
    }

    [XmlElement("indCont")]
    public IndicadorContinuacao IndicadorContinuacao
    {
        get
        {
            if (indContField.HasValue)
            {
                return indContField.Value;
            }
            else
            {
                return (IndicadorContinuacao)Conversions.ToInteger(default);
            }
        }

        set
        {
            if (indContField.Equals(value) != true)
            {
                indContField = value;
                OnPropertyChanged("IndicadorContinuacao");
            }
        }
    }

    /// <summary>
    /// ??? Que raios é isso ???
    /// Vide XmlIgnore
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlIgnore()]
    public bool indContSpecified
    {
        get
        {
            return indContField.HasValue;
        }

        set
        {
            if (value == false)
            {
                indContField = default;
            }
        }
    }

    /// <summary>
    /// No caso do aplicativo não conhecer a última NSU ao requerer o serviço,
    /// à partir deste resultado ele pode controlar sua numeração para ser
    /// devidamente utilizada na próxima consulta.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("ultNSU")]
    public string UltimaNSUConsultada
    {
        get
        {
            return ultNSUField;
        }

        set
        {
            if (ultNSUField is null || ultNSUField.Equals(value) != true)
            {
                ultNSUField = value;
                OnPropertyChanged("UltimaNSUConsultada");
            }
        }
    }

    [XmlArray("ret")]
    [XmlArrayItem("resCCe", typeof(RetornoCartaCorrecaoEletronica))]
    [XmlArrayItem("resCanc", typeof(RetornoNFeCancelada))]
    [XmlArrayItem("resNFe", typeof(RetornoNFeNormal))]
    public List<NFeResultado> Resultados
    {
        get
        {
            return retField;
        }

        set
        {
            if (retField is null || retField.Equals(value) != true)
            {
                retField = value;
                OnPropertyChanged("Resultados");
            }
        }
    }

    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoConsDestinatario Versao
    {
        get
        {
            return versaoField;
        }

        set
        {
            if (versaoField.Equals(value) != true)
            {
                versaoField = value;
                OnPropertyChanged("Versao");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(RetornoConsulta));
            }

            return sSerializer;
        }
    }

    public override string ToString()
    {
        // Return MyBase.ToString()
        var b = new System.Text.StringBuilder();
        foreach (NFeResultado n in Resultados)
            b.AppendLine(n.ToString());
        return b.ToString();
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Serializes current TEnvEvento object into an XML document
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
            if (streamReader != null)
            {
                streamReader.Dispose();
            }

            if (memoryStream != null)
            {
                memoryStream.Dispose();
            }
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
            // doc.LoadXml(Me.Serialize)
            return doc;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Deserializes workflow markup into an TEnvEvento object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TEnvEvento object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref RetornoConsulta obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref RetornoConsulta obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static RetornoConsulta Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (RetornoConsulta)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static RetornoConsulta Deserialize(System.IO.Stream s)
    {
        return (RetornoConsulta)Serializer.Deserialize(s);
    }


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveTo(System.IO.Stream target, ref Exception exception)
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
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
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
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }
    }


    /// <summary>
    /// Deserializes xml markup from file into an TEnvEvento object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TEnvEvento object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(System.IO.Stream source, ref RetornoConsulta obj, ref Exception exception)
    {
        exception = null;
        obj = default;
        try
        {
            obj = LoadFrom(source, false);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanLoadFrom(System.IO.Stream source, ref RetornoConsulta obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static RetornoConsulta LoadFrom(System.IO.Stream source, bool close_stream = true)
    {
        // Dim file As System.IO.FileStream = Nothing
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
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<RetornoConsulta> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// <summary>
/// Objeto genérico que contém informações por NF-e, Cancelamento ou Carta de Correção.
/// Está listado na Propriedade 'Resultados' da clsse RetornoConsulta.
/// </summary>
/// <remarks></remarks>
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(TypeName = "RetConsNFeDestRet", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public partial class NFeResultado : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    //private object itemField;
    private static XmlSerializer sSerializer;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    // ''' <summary>
    // ''' Definido genericamente como 'Object' pois pode representar 03 tipos de classes em sua instância de
    // ''' resultado:
    // ''' 
    // ''' Resumo NF-e
    // ''' Cancelamento NF-e
    // ''' Carta de Correção Eletrônica
    // ''' </summary>
    // ''' <remarks></remarks>
    // Public Property Item() As Object
    // Get
    // Return Me.itemField
    // End Get
    // Set(value As Object)
    // If ((Me.itemField Is Nothing) _
    // OrElse (itemField.Equals(value) <> True)) Then
    // Me.itemField = value
    // Me.OnPropertyChanged("Item")
    // End If
    // End Set
    // End Property

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(NFeResultado));
            }

            return sSerializer;
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// System.Xml.Serialization.XmlTypeAttribute(typename:="TRetConsNFeDestRetResCCe", AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
/// <summary>
/// Objeto de retorno do tipo Carta de Correção Eletrônica.
/// </summary>
/// <remarks></remarks>
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public partial class RetornoCartaCorrecaoEletronica : NFeResultado, INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private string chNFeField;
    private DateTime? dhEventoField;
    private string tpEventoField = "110110"; // TRetConsNFeDestRetResCCeTpEvento
    private string nSeqEventoField;
    private string descEventoField = "Carta de Correção"; // TRetConsNFeDestRetResCCeDescEvento
    private string xCorrecaoField;
    private OperacaoNFe tpNFField = OperacaoNFe.Entrada;
    private DateTime? dhRecbtoField;
    private string nSUField;
    private static XmlSerializer sSerializer;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement(ElementName = "chNFe")]
    public string ChaveNFe
    {
        get
        {
            return chNFeField;
        }

        set
        {
            if (chNFeField is null || chNFeField.Equals(value) != true)
            {
                chNFeField = value;
                OnPropertyChanged("ChaveNFe");
            }
        }
    }

    [XmlElement(ElementName = "dhEvento")]
    public DateTime? EventoData
    {
        get
        {
            return dhEventoField;
        }

        set
        {
            if (dhEventoField is null || dhEventoField.Equals(value) != true)
            {
                dhEventoField = value;
                OnPropertyChanged("EventoData");
            }
        }
    }

    [XmlElement(ElementName = "tpEvento")]
    public string EventoCodigo // TRetConsNFeDestRetResCCeTpEvento (sempre 110110)
    {
        get
        {
            return tpEventoField;
        }

        set
        {
            if (tpEventoField.Equals(value) != true)
            {
                tpEventoField = value;
                OnPropertyChanged("EventoCodigo");
            }
        }
    }

    [XmlElement(ElementName = "nSeqEvento")]
    public string EventoNumeroSequencial
    {
        get
        {
            return nSeqEventoField;
        }

        set
        {
            if (nSeqEventoField is null || nSeqEventoField.Equals(value) != true)
            {
                nSeqEventoField = value;
                OnPropertyChanged("EventoNumeroSequencial");
            }
        }
    }

    [XmlElement(ElementName = "descEvento")]
    public string EventoDescricao // TRetConsNFeDestRetResCCeDescEvento (sempre 'Carta de Correção')
    {
        get
        {
            return descEventoField;
        }

        set
        {
            if (descEventoField.Equals(value) != true)
            {
                descEventoField = value;
                OnPropertyChanged("EventoDescricao");
            }
        }
    }

    [XmlElement(ElementName = "xCorrecao")]
    public string Correcao
    {
        get
        {
            return xCorrecaoField;
        }

        set
        {
            if (xCorrecaoField is null || xCorrecaoField.Equals(value) != true)
            {
                xCorrecaoField = value;
                OnPropertyChanged("Correcao");
            }
        }
    }

    [XmlElement(ElementName = "tpNF")]
    public OperacaoNFe Operacao
    {
        get
        {
            return tpNFField;
        }

        set
        {
            if (tpNFField.Equals(value) != true)
            {
                tpNFField = value;
                OnPropertyChanged("Operacao");
            }
        }
    }

    [XmlElement(ElementName = "dhRecbto")]
    public DateTime? DataAutorizacaoCorrecao
    {
        get
        {
            return dhRecbtoField;
        }

        set
        {
            if (dhRecbtoField.Equals(value) != true)
            {
                dhRecbtoField = value;
                OnPropertyChanged("DataAutorizacaoCorrecao");
            }
        }
    }

    [XmlAttribute()]
    public string NSU
    {
        get
        {
            return nSUField;
        }

        set
        {
            if (nSUField is null || nSUField.Equals(value) != true)
            {
                nSUField = value;
                OnPropertyChanged("NSU");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(RetornoCartaCorrecaoEletronica));
            }

            return sSerializer;
        }
    }

    public override string ToString()
    {
        var b = new System.Text.StringBuilder();
        b.AppendLine("Carta de Correção Eletrônica");
        b.Append("Chave: ");
        b.Append(ChaveNFe);
        return b.ToString();
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// System.Xml.Serialization.XmlTypeAttribute(typename:="TRetConsNFeDestRetResCanc", AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
/// <summary>
/// Objeto de retorno do tipo Cancelamento de Nota Fiscal Eletrônica.
/// </summary>
/// <remarks></remarks>
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
public partial class RetornoNFeCancelada : NFeResultado, INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private string chNFeField;
    private string itemField;
    private PersonalidadeJuridica itemElementNameField = PersonalidadeJuridica.CNPJ;
    private string xNomeField;
    private string ieField;
    private DateTime? dEmiField;
    private OperacaoNFe tpNFField = OperacaoNFe.Entrada;
    private double? vNFField;
    private string digValField;
    private DateTime? dhRecbtoField;
    private SituacaoNFe cSitNFeField = SituacaoNFe.Cancelada;
    private SituacaoManifestacaoDestinatario cSitConfField = SituacaoManifestacaoDestinatario.Desconhecida;
    private string nSUField;
    private static XmlSerializer sSerializer;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("chNFe")]
    public string ChaveNFe
    {
        get
        {
            return chNFeField;
        }

        set
        {
            if (chNFeField is null || chNFeField.Equals(value) != true)
            {
                chNFeField = value;
                OnPropertyChanged("ChaveNFe");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("EmitentePersonalidadeJuridica")]
    public string EmitenteCNPJ_CPF
    {
        get
        {
            return itemField;
        }

        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged("EmitenteCNPJ_CPF");
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica EmitentePersonalidadeJuridica
    {
        get
        {
            return itemElementNameField;
        }

        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("EmitentePersonalidadeJuridica");
            }
        }
    }

    [XmlElement(ElementName = "xNome")]
    public string EmitenteRazaoSocial
    {
        get
        {
            return xNomeField;
        }

        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged("EmitenteRazaoSocial");
            }
        }
    }

    [XmlElement(ElementName = "IE")]
    public string EmitenteIE
    {
        get
        {
            return ieField;
        }

        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged("EmitenteIE");
            }
        }
    }

    [XmlElement(ElementName = "dEmi")]
    public DateTime? DataEmissao
    {
        get
        {
            return dEmiField;
        }

        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged("DataEmissao");
            }
        }
    }

    [XmlElement(ElementName = "tpNF")]
    public OperacaoNFe Operacao
    {
        get
        {
            return tpNFField;
        }

        set
        {
            if (tpNFField.Equals(value) != true)
            {
                tpNFField = value;
                OnPropertyChanged("Operacao");
            }
        }
    }

    [XmlElement(ElementName = "vNF")]
    public double? ValorTotal
    {
        get
        {
            return vNFField;
        }

        set
        {
            if (vNFField is null || vNFField.Equals(value) != true)
            {
                vNFField = value;
                OnPropertyChanged("ValorTotal");
            }
        }
    }

    [XmlElement(ElementName = "digVal")]
    public string DigestValue
    {
        get
        {
            return digValField;
        }

        set
        {
            if (digValField is null || digValField.Equals(value) != true)
            {
                digValField = value;
                OnPropertyChanged("DigestValue");
            }
        }
    }

    [XmlElement(ElementName = "dhRecbto")]
    public DateTime? DataCancelamento
    {
        get
        {
            return dhRecbtoField;
        }

        set
        {
            if (dhRecbtoField.Equals(value) != true)
            {
                dhRecbtoField = value;
                OnPropertyChanged("DataCancelamento");
            }
        }
    }

    [XmlElement(ElementName = "cSitNFe")]
    public SituacaoNFe Situacao
    {
        get
        {
            return cSitNFeField;
        }

        set
        {
            if (cSitNFeField.Equals(value) != true)
            {
                cSitNFeField = value;
                OnPropertyChanged("Situacao");
            }
        }
    }

    [XmlElement(ElementName = "cSitConf")]
    public SituacaoManifestacaoDestinatario SituacaoManifestacao
    {
        get
        {
            return cSitConfField;
        }

        set
        {
            if (cSitConfField.Equals(value) != true)
            {
                cSitConfField = value;
                OnPropertyChanged("SituacaoManifestacao");
            }
        }
    }

    [XmlAttribute()]
    public string NSU
    {
        get
        {
            return nSUField;
        }

        set
        {
            if (nSUField is null || nSUField.Equals(value) != true)
            {
                nSUField = value;
                OnPropertyChanged("NSU");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(RetornoNFeCancelada));
            }

            return sSerializer;
        }
    }

    public override string ToString()
    {
        var b = new System.Text.StringBuilder();
        b.AppendLine("Cancelamento de NF-e");
        b.Append("Emitente: ");
        b.Append(EmitenteCNPJ_CPF.FormatRFBDocument());
        b.Append("; ");
        b.AppendLine(EmitenteRazaoSocial);
        b.Append("Chave: ");
        b.Append(ChaveNFe);
        return b.ToString();
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// System.Xml.Serialization.XmlTypeAttribute(typename:="TRetConsNFeDestRetResNFe", AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
/// <summary>
/// Objeto de retorno do tipo Cancelamento de Nota Fiscal (Autorizada ou Denegada).
/// </summary>
/// <remarks></remarks>
[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("resNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class RetornoNFeNormal : NFeResultado, INotifyPropertyChanged, IXmlSpedDocument
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private string chNFeField;
    private string itemField;
    private PersonalidadeJuridica itemElementNameField;
    private string xNomeField;
    private string ieField;
    private DateTime? dEmiField;
    private OperacaoNFe tpNFField = OperacaoNFe.Entrada;
    private string vNFField;
    private string digValField;
    private DateTime? dhRecbtoField;
    private SituacaoNFe cSitNFeField = SituacaoNFe.Autorizada;
    private SituacaoManifestacaoDestinatario cSitConfField = SituacaoManifestacaoDestinatario.Desconhecida;
    private string nSUField;
    private static XmlSerializer sSerializer;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("chNFe")]
    public string Chave
    {
        get
        {
            return chNFeField;
        }

        set
        {
            if (chNFeField is null || chNFeField.Equals(value) != true)
            {
                chNFeField = value;
                OnPropertyChanged("ChaveNFe");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("EmitentePersonalidadeJuridica")]
    public string EmitenteCNPJ_CPF
    {
        get
        {
            return itemField;
        }

        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged("EmitenteCNPJ_CPF");
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica EmitentePersonalidadeJuridica
    {
        get
        {
            return itemElementNameField;
        }

        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("EmitentePersonalidadeJuridica");
            }
        }
    }

    [XmlElement("xNome")]
    public string EmitenteRazaoSocial
    {
        get
        {
            return xNomeField;
        }

        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged("EmitenteRazaoSocial");
            }
        }
    }

    [XmlElement("IE")]
    public string EmitenteIE
    {
        get
        {
            return ieField;
        }

        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged("EmitenteIE");
            }
        }
    }

    [XmlElement("dEmi")]
    public DateTime? EmissaoData
    {
        get
        {
            return dEmiField;
        }

        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged("EmissaoData");
            }
        }
    }

    [XmlElement("dhEmi")]
    public DateTime? DataEmissao
    {
        get
        {
            return dEmiField;
        }

        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged("DataHoraEmissao");
            }
        }
    }

    [XmlElement("tpNF")]
    public OperacaoNFe Operacao
    {
        get
        {
            return tpNFField;
        }

        set
        {
            if (tpNFField.Equals(value) != true)
            {
                tpNFField = value;
                OnPropertyChanged("Operacao");
            }
        }
    }

    [XmlElement("vNF")]
    public string ValorTotal
    {
        get
        {
            return vNFField;
        }

        set
        {
            if (vNFField is null || vNFField.Equals(value) != true)
            {
                vNFField = value;
                OnPropertyChanged("ValorTotal");
            }
        }
    }

    [XmlElement("digVal")]
    public string DigestValue
    {
        get
        {
            return digValField;
        }

        set
        {
            if (digValField is null || digValField.Equals(value) != true)
            {
                digValField = value;
                OnPropertyChanged("DigestValue");
            }
        }
    }

    [XmlElement("dhRecbto")]
    public DateTime? DataAutorizacao
    {
        get
        {
            return dhRecbtoField;
        }

        set
        {
            if (dhRecbtoField.Equals(value) != true)
            {
                dhRecbtoField = value;
                OnPropertyChanged("DataAutorizacao");
            }
        }
    }

    [XmlElement("cSitNFe")]
    public SituacaoNFe Situacao
    {
        get
        {
            return cSitNFeField;
        }

        set
        {
            if (cSitNFeField.Equals(value) != true)
            {
                cSitNFeField = value;
                OnPropertyChanged("Situacao");
            }
        }
    }

    [XmlElement("cSitConf")]
    public SituacaoManifestacaoDestinatario SituacaoManifestacao
    {
        get
        {
            return cSitConfField;
        }

        set
        {
            if (cSitConfField.Equals(value) != true)
            {
                cSitConfField = value;
                OnPropertyChanged("SituacaoManifestacao");
            }
        }
    }

    [XmlAttribute()]
    public string NSU
    {
        get
        {
            return nSUField;
        }

        set
        {
            if (nSUField is null || nSUField.Equals(value) != true)
            {
                nSUField = value;
                OnPropertyChanged("NSU");
            }
        }
    }

    [XmlElement("nProt")]
    public string Protocolo
    {
        get
        {
            return nSUField;
        }

        set
        {
            if (nSUField is null || nSUField.Equals(value) != true)
            {
                nSUField = value;
                OnPropertyChanged("Protocolo");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(RetornoNFeNormal));
            }

            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType
    {
        get
        {
            return XmlDocumentType.NFe_Resumo;
        }
    }

    public override string ToString()
    {
        // Return MyBase.ToString()
        var b = new System.Text.StringBuilder();
        b.Append("Emitente: ");
        b.Append(EmitenteCNPJ_CPF.FormatRFBDocument());
        b.Append("  -   ");
        b.AppendLine(EmitenteRazaoSocial);
        switch (Situacao)
        {
            case SituacaoNFe.Autorizada:
                {
                    b.Append("Situação: NF-e Normal");
                    break;
                }

            case SituacaoNFe.Cancelada:
                {
                    b.Append("Situação: NF-e Cancelada");
                    break;
                }

            case SituacaoNFe.Denegada:
                {
                    b.Append("Situação: NF-e Denegada");
                    break;
                }

            default:
                {
                    b.AppendLine("Situação Inexistente");
                    break;
                }
        }

        b.Append("   ");
        b.Append("Valor da Nota: ");
        b.Append(ValorTotal);
        b.Append("   ");
        b.Append("Data Emissão: ");
        b.Append(dEmiField);
        b.Append("   ");
        b.Append("Chave: ");
        b.AppendLine(Chave);
        return b.ToString();
    }

    public static RetornoNFeNormal LoadFrom(System.IO.Stream source, bool close_stream = true)
    {
        // Dim file As System.IO.FileStream = Nothing
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
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<RetornoNFeNormal> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

    public static RetornoNFeNormal Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (RetornoNFeNormal)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}
