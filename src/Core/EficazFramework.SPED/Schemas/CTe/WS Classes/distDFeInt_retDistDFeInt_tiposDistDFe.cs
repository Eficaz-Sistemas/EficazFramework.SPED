﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
// ------------------------------------------------------------------------------
// <auto-generated>
// O código foi gerado por uma ferramenta.
// Versão de Tempo de Execução:4.0.30319.42000
// 
// As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
// o código for gerado novamente.
// </auto-generated>
// ------------------------------------------------------------------------------

using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace EficazFramework.SPED.Schemas.CTe;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("distDFeInt", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class PedidoDistribuicaoDFe : object, System.ComponentModel.INotifyPropertyChanged
{
    private NFe.Ambiente tpAmbField;
    private NFe.OrgaoIBGE cUFAutorField;
    private string cCnpj_cpf;
    private PersonalidadeJuridica7 itemElementNameField;
    private object item1Field;
    private VersaoServicoDistribuicaoDF versaoField;
    private static XmlSerializer sSerializer;

    /// <remarks/>
    [XmlElement("tpAmb", Namespace = null, Order = 0)]
    public NFe.Ambiente Ambiente
    {
        get
        {
            return tpAmbField;
        }

        set
        {
            tpAmbField = value;
            RaisePropertyChanged("Ambiente");
        }
    }

    /// <remarks/>
    [XmlElement("cUFAutor", Namespace = null, Order = 1)]
    public NFe.OrgaoIBGE UF_Autor
    {
        get
        {
            return cUFAutorField;
        }

        set
        {
            cUFAutorField = value;
            RaisePropertyChanged("UF_Autor");
        }
    }

    /// <remarks/>
    [XmlElement("CNPJ", typeof(string), Namespace = null, Order = 2)]
    [XmlElement("CPF", typeof(string), Namespace = null, Order = 2)]
    [XmlChoiceIdentifier("ItemElementName")]
    public string CNPJ_CPF
    {
        get
        {
            return cCnpj_cpf;
        }

        set
        {
            cCnpj_cpf = value;
            RaisePropertyChanged("CNPJ_CPF");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    [XmlIgnore()]
    public PersonalidadeJuridica7 ItemElementName
    {
        get
        {
            return itemElementNameField;
        }

        set
        {
            itemElementNameField = value;
            RaisePropertyChanged("ItemElementName");
        }
    }

    /// <remarks/>
    [XmlElement("consNSU", typeof(distDFeIntConsNSU), Namespace = null, Order = 4)]
    [XmlElement("distNSU", typeof(distDFeIntDistNSU), Namespace = null, Order = 4)]
    public object NSUObject
    {
        get
        {
            return item1Field;
        }

        set
        {
            item1Field = value;
            RaisePropertyChanged("Item1");
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public VersaoServicoDistribuicaoDF versao
    {
        get
        {
            return versaoField;
        }

        set
        {
            versaoField = value;
            RaisePropertyChanged("versao");
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(PedidoDistribuicaoDFe));
            }

            return sSerializer;
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

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
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.portalfiscal.inf.br/cte");
            Serializer.Serialize(memoryStream, this, ns);
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
    public static bool CanDeserialize(string xml, ref PedidoDistribuicaoDFe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref PedidoDistribuicaoDFe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static PedidoDistribuicaoDFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (PedidoDistribuicaoDFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static PedidoDistribuicaoDFe Deserialize(System.IO.Stream s)
    {
        return (PedidoDistribuicaoDFe)Serializer.Deserialize(s);
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
    public static bool CanLoadFrom(System.IO.Stream source, ref PedidoDistribuicaoDFe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref PedidoDistribuicaoDFe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static PedidoDistribuicaoDFe LoadFrom(System.IO.Stream source, bool close_stream = true)
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

    public static async Task<PedidoDistribuicaoDFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class distDFeIntConsNSU : object, System.ComponentModel.INotifyPropertyChanged
{
    private string nSUField;

    /// <remarks/>
    [XmlElement(DataType = "token", Order = 0)]
    public string NSU
    {
        get
        {
            return nSUField;
        }

        set
        {
            nSUField = value;
            RaisePropertyChanged("NSU");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class distDFeIntDistNSU : object, System.ComponentModel.INotifyPropertyChanged
{
    private string ultNSUField;

    /// <remarks/>
    [XmlElement(DataType = "token", Order = 0)]
    public string ultNSU
    {
        get
        {
            return ultNSUField;
        }

        set
        {
            ultNSUField = value;
            RaisePropertyChanged("ultNSU");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("retDistDFeInt", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class RetornoDistribuicaoDFe : object, System.ComponentModel.INotifyPropertyChanged
{
    private NFe.Ambiente tpAmbField;
    private string verAplicField;
    private string cStatField;
    private string xMotivoField;
    private string dhRespField;
    private string ultNSUField;
    private string maxNSUField;
    private retDistDFeIntLoteDistDFeInt loteDistDFeIntField;
    private VersaoServicoDistribuicaoDF versaoField;
    private static XmlSerializer sSerializer;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public NFe.Ambiente tpAmb
    {
        get
        {
            return tpAmbField;
        }

        set
        {
            tpAmbField = value;
            RaisePropertyChanged("tpAmb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string verAplic
    {
        get
        {
            return verAplicField;
        }

        set
        {
            verAplicField = value;
            RaisePropertyChanged("verAplic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string cStat
    {
        get
        {
            return cStatField;
        }

        set
        {
            cStatField = value;
            RaisePropertyChanged("cStat");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string xMotivo
    {
        get
        {
            return xMotivoField;
        }

        set
        {
            xMotivoField = value;
            RaisePropertyChanged("xMotivo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string dhResp
    {
        get
        {
            return dhRespField;
        }

        set
        {
            dhRespField = value;
            RaisePropertyChanged("dhResp");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "token", Order = 5)]
    public string ultNSU
    {
        get
        {
            return ultNSUField;
        }

        set
        {
            ultNSUField = value;
            RaisePropertyChanged("ultNSU");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "token", Order = 6)]
    public string maxNSU
    {
        get
        {
            return maxNSUField;
        }

        set
        {
            maxNSUField = value;
            RaisePropertyChanged("maxNSU");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public retDistDFeIntLoteDistDFeInt loteDistDFeInt
    {
        get
        {
            return loteDistDFeIntField;
        }

        set
        {
            loteDistDFeIntField = value;
            RaisePropertyChanged("loteDistDFeInt");
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public VersaoServicoDistribuicaoDF versao
    {
        get
        {
            return versaoField;
        }

        set
        {
            versaoField = value;
            RaisePropertyChanged("versao");
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(RetornoDistribuicaoDFe));
            }

            return sSerializer;
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

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
    public static bool CanDeserialize(string xml, ref RetornoDistribuicaoDFe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref RetornoDistribuicaoDFe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static RetornoDistribuicaoDFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (RetornoDistribuicaoDFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static RetornoDistribuicaoDFe Deserialize(System.IO.Stream s)
    {
        return (RetornoDistribuicaoDFe)Serializer.Deserialize(s);
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
    public static bool CanLoadFrom(System.IO.Stream source, ref RetornoDistribuicaoDFe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref RetornoDistribuicaoDFe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static RetornoDistribuicaoDFe LoadFrom(System.IO.Stream source, bool close_stream = true)
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

    public static async Task<RetornoDistribuicaoDFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class retDistDFeIntLoteDistDFeInt : object, System.ComponentModel.INotifyPropertyChanged
{
    private retDistDFeIntLoteDistDFeIntDocZip[] docZipField;

    /// <remarks/>
    [XmlElement("docZip", Order = 0)]
    public retDistDFeIntLoteDistDFeIntDocZip[] DocZip
    {
        get
        {
            return docZipField;
        }

        set
        {
            docZipField = value;
            RaisePropertyChanged("docZip");
        }
    }

    // Private _lista As ListaDFe
    // Public Property ListaDFe() As ListaDFe
    // Get
    // Return _lista
    // End Get
    // Set(ByVal value As ListaDFe)
    // _lista = value
    // End Set
    // End Property

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Frankson Fix
/// </summary>
public partial class ListaDFe
{
    private List<retDistDFeIntLoteDistDFeIntDocZip> DocZipfield = new List<retDistDFeIntLoteDistDFeIntDocZip>();

    [XmlElement("DocZip", Order = 0)]
    public List<retDistDFeIntLoteDistDFeIntDocZip> DocZip
    {
        get
        {
            return DocZipfield;
        }

        set
        {
            DocZipfield = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class retDistDFeIntLoteDistDFeIntDocZip : object, System.ComponentModel.INotifyPropertyChanged
{
    private string nSUField;
    private string schemaField;
    private byte[] valueField;

    /// <remarks/>
    [XmlAttribute(DataType = "token")]
    public string NSU
    {
        get
        {
            return nSUField;
        }

        set
        {
            nSUField = value;
            RaisePropertyChanged("NSU");
        }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string schema
    {
        get
        {
            return schemaField;
        }

        set
        {
            schemaField = value;
            RaisePropertyChanged("schema");
        }
    }

    // <System.Xml.Serialization.XmlElement("docZip", DataType:="base64Binary")>
    /// <remarks/>
    [XmlText(DataType = "base64Binary")]
    public byte[] Value
    {
        get
        {
            return valueField;
        }

        set
        {
            valueField = value;
            RaisePropertyChanged("Value");
        }
    }

    public async Task<byte[]> DescompactaAsync()
    {
        if (Value is null)
            return null;
        byte[] buffer = null;
        using (var compressedStream = new System.IO.MemoryStream(Value))
        {
            using (var deflatedStream = new System.IO.MemoryStream())
            {
                using (var decompressionStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    try
                    {
                        await decompressionStream.CopyToAsync(deflatedStream);
                        deflatedStream.Position = 0L;
                        // Await deflatedStream.ReadAsync(buffer, 0, buffer.Length)
                        buffer = deflatedStream.ToArray();
                    }
                    catch (Exception deflatEx)
                    {
                        Debug.WriteLine(deflatEx.Message);
                    }

                    decompressionStream.Dispose();
                }

                deflatedStream.Dispose();
            }

            compressedStream.Dispose();
        }
        // End Using
        // Dim buffer As Byte() = Nothing
        // If Me.Value Is Nothing Then Return Nothing
        // Dim gzBuffer As Byte() = Me.Value 'Convert.FromBase64String(Me.Value)
        // Using ms As New MemoryStream()
        // Dim msgLength As Integer = BitConverter.ToInt32(gzBuffer, 0)
        // Await ms.WriteAsync(gzBuffer, 0, gzBuffer.Length - 0)
        // buffer = New Byte(msgLength - 1) {}
        // ms.Position = 0
        // Using zip As New GZipStream(ms, CompressionMode.Decompress)
        // Await zip.ReadAsync(buffer, 0, buffer.Length)
        // zip.Dispose()
        // End Using
        // ms.Dispose()
        // End Using
        return buffer; // Encoding.UTF8.GetString(buffer, 0, msgLength)
    }

    public async Task<string> DecodedValueAsync()
    {
        var buffer = await DescompactaAsync();
        return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
    }

    public Utilities.XML.XMLDocumentType DocumentType
    {
        get
        {
            switch (schema ?? "")
            {
                case "procCTe_v2.00.xsd":
                case "procCTe_v3.00.xsd":
                    {
                        return Utilities.XML.XMLDocumentType.CTeWithProtocol;
                    }

                case "procEventoCTe_v3.00.xsd":
                    {
                        return Utilities.XML.XMLDocumentType.CTeEvent;
                    }

                default:
                    {
                        return Utilities.XML.XMLDocumentType.Unknown;
                    }
            }
        }
    }

    public async Task<Utilities.XML.IXmlSpedDocument> GetInstanceAsync()
    {
        var ms = new System.IO.MemoryStream(await DescompactaAsync());
        Utilities.XML.IXmlSpedDocument r = null;
        switch (DocumentType)
        {
            case Utilities.XML.XMLDocumentType.CTeWithProtocol:
                {
                    r = await ProcessoCTe.LoadFromAsync(ms, false);
                    break;
                }

            case Utilities.XML.XMLDocumentType.CTeEvent:
                {
                    r = await ProcessoEvento.LoadFromAsync(ms, false);
                    break;
                }
        }

        ms.Dispose();
        return r;
    }

    public async Task SaveAsync(System.IO.Stream target)
    {
        var buffer = await DescompactaAsync();
        await target.WriteAsync(buffer, 0, buffer.Length);
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

    public override string ToString()
    {
        return string.Format("Schema: {0} | NSU: {1}", schema, NSU);
    }
}