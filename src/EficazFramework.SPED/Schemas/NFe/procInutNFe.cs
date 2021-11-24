﻿// ------------------------------------------------------------------------------
// <auto-generated>
// O código foi gerado por uma ferramenta.
// Versão de Tempo de Execução:4.0.30319.42000
// 
// As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
// o código for gerado novamente.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EficazFrameworkCore.SPED.Utilities.XML;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace EficazFrameworkCore.SPED.Schemas.NFe
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("ProcInutNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public partial class ProcessoInutilizacaoNFe : object, System.ComponentModel.INotifyPropertyChanged, IXmlSpedDocument
    {
        private InutilizacaoNFe inutNFeField;
        private InutilizacaoRetorno retInutNFeField;
        private string versaoField;
        private static XmlSerializer sSerializer;

        /// <remarks/>
        [XmlElement(ElementName = "inutNFe", Order = 0)]
        public InutilizacaoNFe Inutilizacao
        {
            get
            {
                return inutNFeField;
            }

            set
            {
                inutNFeField = value;
                RaisePropertyChanged("inutNFe");
            }
        }

        /// <remarks/>
        [XmlElement(ElementName = "retInutNFe", Order = 1)]
        public InutilizacaoRetorno RetornoInutilizacao
        {
            get
            {
                return retInutNFeField;
            }

            set
            {
                retInutNFeField = value;
                RaisePropertyChanged("RetornoInutilizacao");
            }
        }

        /// <remarks/>
        [XmlAttribute("token")]
        public string versao
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
                    sSerializer = new XmlSerializer(typeof(ProcessoInutilizacaoNFe));
                }

                return sSerializer;
            }
        }

        public XMLDocumentType DocumentType
        {
            get
            {
                return XMLDocumentType.NFeInutilization;
            }
        }

        [XmlIgnore()]
        public DateTime? DataEmissao
        {
            get
            {
                return RetornoInutilizacao.infInut.DataRecebimento;
            }
        }

        [XmlIgnore()]
        public string Chave
        {
            get
            {
                // Return Me.Inutilizacao.InformacoesInutilizacao.Id
                if (Inutilizacao.InformacoesInutilizacao.Id != null)
                    return System.Text.RegularExpressions.Regex.Replace(Inutilizacao.InformacoesInutilizacao.Id, "[^0-9]", "");
                else
                    return string.Empty;
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
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ProcessoInutilizacaoNFe Deserialize(System.IO.Stream s)
        {
            return (ProcessoInutilizacaoNFe)Serializer.Deserialize(s);
        }


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
                if (source != null)
                {
                    source.Dispose();
                }

                if (sr != null)
                {
                    sr.Dispose();
                }
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
                if (source != null)
                {
                    source.Dispose();
                }

                if (sr != null)
                {
                    sr.Dispose();
                }
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("inutNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public partial class InutilizacaoNFe : object, System.ComponentModel.INotifyPropertyChanged
    {
        private InformacoesInutilizacaoNFe infInutField;
        private SignatureType signatureField;
        private string versaoField;

        /// <remarks/>
        [XmlElement(ElementName = "infInut", Order = 0)]
        public InformacoesInutilizacaoNFe InformacoesInutilizacao
        {
            get
            {
                return infInutField;
            }

            set
            {
                infInutField = value;
                RaisePropertyChanged("infInut");
            }
        }

        /// <remarks/>
        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
            }
        }

        /// <remarks/>
        [XmlAttribute("token")]
        public string versao
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
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InformacoesInutilizacaoNFe : object, System.ComponentModel.INotifyPropertyChanged
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
        [XmlElement(Order = 1)]
        public string xServ
        {
            get
            {
                return xServField;
            }

            set
            {
                xServField = value;
                RaisePropertyChanged("xServ");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public OrgaoIBGE cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string ano
        {
            get
            {
                return anoField;
            }

            set
            {
                anoField = value;
                RaisePropertyChanged("ano");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 4)]
        public string CNPJ
        {
            get
            {
                return cNPJField;
            }

            set
            {
                cNPJField = value;
                RaisePropertyChanged("CNPJ");
            }
        }

        /// <remarks/>
        [XmlElement(ElementName = "mod", Order = 5)]
        public ModeloDocumento Modelo
        {
            get
            {
                return modField;
            }

            set
            {
                modField = value;
                RaisePropertyChanged("Modelo");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string serie
        {
            get
            {
                return serieField;
            }

            set
            {
                serieField = value;
                RaisePropertyChanged("serie");
            }
        }

        /// <remarks/>
        [XmlElement(ElementName = "nNFIni", Order = 7)]
        public string NumeroNFInicial
        {
            get
            {
                return nNFIniField;
            }

            set
            {
                nNFIniField = value;
                RaisePropertyChanged("NumeroNFInicial");
            }
        }

        /// <remarks/>
        [XmlElement(ElementName = "nNFFin", Order = 8)]
        public string NumeroNFFinal
        {
            get
            {
                return nNFFinField;
            }

            set
            {
                nNFFinField = value;
                RaisePropertyChanged("NumeroNFFinal");
            }
        }

        /// <remarks/>
        [XmlElement(ElementName = "xJust", Order = 9)]
        public string Justificativa
        {
            get
            {
                return xJustField;
            }

            set
            {
                xJustField = value;
                RaisePropertyChanged("Justificativa");
            }
        }

        /// <remarks/>
        [XmlAttribute("Id")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InutilizacaoRetorno : object, System.ComponentModel.INotifyPropertyChanged
    {
        private TRetInutNFeInfInut infInutField;
        private SignatureType signatureField;
        private string versaoField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public TRetInutNFeInfInut infInut
        {
            get
            {
                return infInutField;
            }

            set
            {
                infInutField = value;
                RaisePropertyChanged("infInut");
            }
        }

        /// <remarks/>
        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
            }
        }

        /// <remarks/>
        [XmlAttribute("token")]
        public string versao
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
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class TRetInutNFeInfInut : object, System.ComponentModel.INotifyPropertyChanged
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
        public OrgaoIBGE cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string ano
        {
            get
            {
                return anoField;
            }

            set
            {
                anoField = value;
                RaisePropertyChanged("ano");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 6)]
        public string CNPJ
        {
            get
            {
                return cNPJField;
            }

            set
            {
                cNPJField = value;
                RaisePropertyChanged("CNPJ");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 7)]
        public ModeloDocumento mod
        {
            get
            {
                return modField;
            }

            set
            {
                modField = value;
                RaisePropertyChanged("mod");
            }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool modSpecified
        {
            get
            {
                return modFieldSpecified;
            }

            set
            {
                modFieldSpecified = value;
                RaisePropertyChanged("modSpecified");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 8)]
        public string serie
        {
            get
            {
                return serieField;
            }

            set
            {
                serieField = value;
                RaisePropertyChanged("serie");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 9)]
        public string nNFIni
        {
            get
            {
                return nNFIniField;
            }

            set
            {
                nNFIniField = value;
                RaisePropertyChanged("nNFIni");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 10)]
        public string nNFFin
        {
            get
            {
                return nNFFinField;
            }

            set
            {
                nNFFinField = value;
                RaisePropertyChanged("nNFFin");
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
            get
            {
                return dhRecbtoField;
            }

            set
            {
                if (dhRecbtoField is null || dhRecbtoField.Equals(value) != true)
                {
                    dhRecbtoField = value;
                    RaisePropertyChanged("DataRecebimento");
                }
            }
        }

        public bool ShouldSerializeDataEmissaoXML()
        {
            return dhRecbtoField.HasValue;
        }


        /// <remarks/>
        [XmlElement(Order = 12)]
        public string nProt
        {
            get
            {
                return nProtField;
            }

            set
            {
                nProtField = value;
                RaisePropertyChanged("nProt");
            }
        }

        /// <remarks/>
        [XmlAttribute("Id")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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
}