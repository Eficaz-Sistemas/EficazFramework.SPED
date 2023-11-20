﻿using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.NFe
{
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlRoot("procNFe", IsNullable = false)]
    public partial class ProcessoNFeBase : INotifyPropertyChanged, IXmlSpedDocument
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public ProcessoNFeBase() : base()
        {
            nFeField = new ProcessoNFe();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private ProcessoNFe nFeField;
        private string versaoField;
        private static XmlSerializer sSerializer;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("nfeProc", Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public ProcessoNFe Processo
        {
            get
            {
                return nFeField;
            }

            set
            {
                if (nFeField is null || nFeField.Equals(value) != true)
                {
                    nFeField = value;
                    OnPropertyChanged("Processo");
                }
            }
        }

        [XmlAttribute(AttributeName = "schema")]
        public string Schema
        {
            get
            {
                return versaoField;
            }

            set
            {
                if (versaoField is null || versaoField.Equals(value) != true)
                {
                    versaoField = value;
                    OnPropertyChanged("Schema");
                }
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if (sSerializer is null)
                {
                    sSerializer = new XmlSerializer(typeof(ProcessoNFeBase));
                }

                return sSerializer;
            }
        }

        public XmlDocumentType DocumentType
        {
            get
            {
                return XmlDocumentType.NFeWithProtocol_Base;
            }
        }

        public DateTime? DataEmissao
        {
            get
            {
                return Processo.DataEmissao;
            }
        }

        public string Chave
        {
            get
            {
                // Return Me.Processo.Chave
                if (Processo.NFe.InformacoesNFe.Id != null)
                    return System.Text.RegularExpressions.Regex.Replace(Processo.NFe.InformacoesNFe.Id, "[^0-9]", "");
                else
                    return string.Empty;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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

        public override string ToString()
        {
            return base.ToString();
            // Return Me.NFe.InformacoesNFe.IdentificacaoOperacao.Chave
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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
        public static bool CanDeserialize(string xml, ref ProcessoNFeBase obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref ProcessoNFeBase obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static ProcessoNFeBase Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (ProcessoNFeBase)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), ProcessoNFeBase)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ProcessoNFeBase Deserialize(System.IO.Stream s)
        {
            return (ProcessoNFeBase)Serializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoNFeBase obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoNFeBase obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static ProcessoNFeBase LoadFrom(System.IO.Stream source, bool close_stream = true)
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
                if (source != null & close_stream == true)
                {
                    source.Dispose();
                }

                if (sr != null)
                {
                    sr.Dispose();
                }
            }
        }

        public static async Task<ProcessoNFeBase> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("nfeProc", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public partial class ProcessoNFe : INotifyPropertyChanged, IXmlSpedDocument
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public ProcessoNFe() : base()
        {
            protNFeField = new ProtocoloRecebimento();
            nFeField = new NFe();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private NFe nFeField;
        private ProtocoloRecebimento protNFeField;
        private string versaoField;
        private static XmlSerializer sSerializer;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public NFe NFe
        {
            get
            {
                return nFeField;
            }

            set
            {
                if (nFeField is null || nFeField.Equals(value) != true)
                {
                    nFeField = value;
                    OnPropertyChanged("NFe");
                }
            }
        }

        [XmlElement("protNFe")]
        public ProtocoloRecebimento ProtocoloAutorizacao
        {
            get
            {
                return protNFeField;
            }

            set
            {
                if (protNFeField is null || protNFeField.Equals(value) != true)
                {
                    protNFeField = value;
                    OnPropertyChanged("ProtocoloAutorizacao");
                }
            }
        }

        [XmlAttribute(AttributeName = "versao")]
        public string Versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                if (versaoField is null || versaoField.Equals(value) != true)
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
                    sSerializer = new XmlSerializer(typeof(ProcessoNFe));
                }

                return sSerializer;
            }
        }

        [XmlIgnore()]
        public XmlDocumentType DocumentType
        {
            get
            {
                return XmlDocumentType.NFeWithProtocol;
            }
        }

        [XmlIgnore()]
        public DateTime? DataEmissao
        {
            get
            {
                return NFe.InformacoesNFe.IdentificacaoOperacao.DataEmissao;
            }
        }

        [XmlIgnore()]
        public string Chave
        {
            get
            {
                // Return Me.NFe.InformacoesNFe.Id
                if (NFe.InformacoesNFe.Id != null)
                    return System.Text.RegularExpressions.Regex.Replace(NFe.InformacoesNFe.Id, "[^0-9]", "");
                else
                    return string.Empty;
            }
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static void RefreshSerializer()
        {
            sSerializer = null;
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return base.ToString();
            // Return Me.NFe.InformacoesNFe.IdentificacaoOperacao.Chave
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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
        public static bool CanDeserialize(string xml, ref ProcessoNFe obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref ProcessoNFe obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static ProcessoNFe Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (ProcessoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), ProcessoNFeBase)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ProcessoNFe Deserialize(System.IO.Stream s)
        {
            return (ProcessoNFe)Serializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoNFe obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoNFe obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static ProcessoNFe LoadFrom(System.IO.Stream source, bool close_stream = true)
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
                if (sr != null & close_stream == true)
                {
                    sr.Dispose();
                }
            }
        }

        public static async Task<ProcessoNFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(TypeName = "NFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("NFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public partial class NFe : INotifyPropertyChanged, IXmlSpedDocument
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public NFe() : base()
        {
            signatureField = new SignatureType();
            infNFeField = new InformacoesNFe();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private InformacoesNFe infNFeField;
        private SignatureType signatureField;
        private static XmlSerializer sSerializer;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("infNFe")]
        public InformacoesNFe InformacoesNFe
        {
            get
            {
                return infNFeField;
            }

            set
            {
                if (infNFeField is null || infNFeField.Equals(value) != true)
                {
                    infNFeField = value;
                    OnPropertyChanged("InformacoesNFe");
                }
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                if (signatureField is null || signatureField.Equals(value) != true)
                {
                    signatureField = value;
                    OnPropertyChanged("Signature");
                }
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if (sSerializer is null)
                {
                    sSerializer = new XmlSerializer(typeof(NFe));
                }

                return sSerializer;
            }
        }

        [XmlIgnore()]
        public XmlDocumentType DocumentType
        {
            get
            {
                return XmlDocumentType.NFeWithoutProtocol;
            }
        }

        [XmlIgnore()]
        public DateTime? DataEmissao
        {
            get
            {
                return InformacoesNFe.IdentificacaoOperacao.DataEmissao;
            }
        }

        [XmlIgnore()]
        public string Chave
        {
            get
            {
                // Return Me.InformacoesNFe.Id
                if (InformacoesNFe.Id != null)
                    return System.Text.RegularExpressions.Regex.Replace(InformacoesNFe.Id, "[^0-9]", "");
                else
                    return string.Empty;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
        public static bool CanDeserialize(string xml, ref NFe obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref NFe obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static NFe Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (NFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), ProcessoNFeBase)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static NFe Deserialize(System.IO.Stream s)
        {
            return (NFe)Serializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref NFe obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref NFe obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static NFe LoadFrom(System.IO.Stream source, bool close_stream = true)
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
                if (sr != null & close_stream == true)
                {
                    sr.Dispose();
                }
            }
        }

        public static async Task<NFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(TypeName = "TNFeInfNFe", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InformacoesNFe : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public InformacoesNFe() : base()
        {
            // Me.canaField = New TNFeInfNFeCana()
            // Me.compraField = New TNFeInfNFeCompra()
            // Me.exportaField = New TNFeInfNFeExporta()
            // Me.infAdicField = New TNFeInfNFeInfAdic()
            // Me.cobrField = New TNFeInfNFeCobr()
            // Me.transpField = New InformacoesTransporte()
            // Me.totalField = New Totais()
            detField = new List<Item>();
            // Me.entregaField = New Local()
            // Me.retiradaField = New Local()
            // Me.destField = New Destinatario()
            // Me.avulsaField = New Fisco()
            // Me.emitField = New Emitente()
            // Me.ideField = New IdentificacaoNFe()
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private IdentificacaoNFe ideField;
        private Emitente emitField;
        private Fisco avulsaField;
        private Destinatario destField;
        private Local retiradaField;
        private Local entregaField;
        private List<Item> detField;
        private Totais totalField;
        private InformacoesTransporte transpField;
        private Cobranca cobrField;
        private Pagamento pagField;
        private InformacoesAdicionais infAdicField;
        private Exportacao exportaField;
        private Compra compraField;
        private Cana canaField;
        private string versaoField;
        private string idField;
        private static XmlSerializer sSerializer;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("ide")]
        public IdentificacaoNFe IdentificacaoOperacao
        {
            get
            {
                return ideField;
            }

            set
            {
                if (ideField is null || ideField.Equals(value) != true)
                {
                    ideField = value;
                    OnPropertyChanged("IdentificacaoOperacao");
                }
            }
        }

        [XmlElement("emit")]
        public Emitente Emitente
        {
            get
            {
                return emitField;
            }

            set
            {
                if (emitField is null || emitField.Equals(value) != true)
                {
                    emitField = value;
                    OnPropertyChanged("Emitente");
                }
            }
        }

        [XmlElement("avulsa")]
        public Fisco Avulsa
        {
            get
            {
                return avulsaField;
            }

            set
            {
                if (avulsaField is null || avulsaField.Equals(value) != true)
                {
                    avulsaField = value;
                    OnPropertyChanged("Avulsa");
                }
            }
        }

        [XmlElement("dest")]
        public Destinatario Destinatario
        {
            get
            {
                return destField;
            }

            set
            {
                if (destField is null || destField.Equals(value) != true)
                {
                    destField = value;
                    OnPropertyChanged("Destinatario");
                }
            }
        }

        [XmlElement("retirada")]
        public Local LocalRetirada
        {
            get
            {
                return retiradaField;
            }

            set
            {
                if (retiradaField is null || retiradaField.Equals(value) != true)
                {
                    retiradaField = value;
                    OnPropertyChanged("LocalRetirada");
                }
            }
        }

        [XmlElement("entrega")]
        public Local LocalEntrega
        {
            get
            {
                return entregaField;
            }

            set
            {
                if (entregaField is null || entregaField.Equals(value) != true)
                {
                    entregaField = value;
                    OnPropertyChanged("LocalEntrega");
                }
            }
        }

        [XmlElement("det")]
        public List<Item> Items
        {
            get
            {
                return detField;
            }

            set
            {
                if (detField is null || detField.Equals(value) != true)
                {
                    detField = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        [XmlElement("total")]
        public Totais Totais
        {
            get
            {
                return totalField;
            }

            set
            {
                if (totalField is null || totalField.Equals(value) != true)
                {
                    totalField = value;
                    OnPropertyChanged("Totais");
                }
            }
        }

        [XmlElement("transp")]
        public InformacoesTransporte Transporte
        {
            get
            {
                return transpField;
            }

            set
            {
                if (transpField is null || transpField.Equals(value) != true)
                {
                    transpField = value;
                    OnPropertyChanged("Transporte");
                }
            }
        }

        [XmlElement("cobr")]
        public Cobranca Cobranca
        {
            get
            {
                return cobrField;
            }

            set
            {
                if (cobrField is null || cobrField.Equals(value) != true)
                {
                    cobrField = value;
                    OnPropertyChanged("Cobranca");
                }
            }
        }

        [XmlElement("pag")]
        public Pagamento Pagamento
        {
            get
            {
                return pagField;
            }

            set
            {
                if (pagField is null || pagField.Equals(value) != true)
                {
                    pagField = value;
                    OnPropertyChanged("Pagamento");
                }
            }
        }

        [XmlElement("infAdic")]
        public InformacoesAdicionais InformacoesAdicionais
        {
            get
            {
                return infAdicField;
            }

            set
            {
                if (infAdicField is null || infAdicField.Equals(value) != true)
                {
                    infAdicField = value;
                    OnPropertyChanged("InformacoesAdicionais");
                }
            }
        }

        [XmlElement("exporta")]
        public Exportacao Exportacao
        {
            get
            {
                return exportaField;
            }

            set
            {
                if (exportaField is null || exportaField.Equals(value) != true)
                {
                    exportaField = value;
                    OnPropertyChanged("Exportacao");
                }
            }
        }

        [XmlElement("compra")]
        public Compra InformacaoAdicionalCompra
        {
            get
            {
                return compraField;
            }

            set
            {
                if (compraField is null || compraField.Equals(value) != true)
                {
                    compraField = value;
                    OnPropertyChanged("InformacaoAdicionalCompra");
                }
            }
        }

        [XmlElement("cana")]
        public Cana Cana
        {
            get
            {
                return canaField;
            }

            set
            {
                if (canaField is null || canaField.Equals(value) != true)
                {
                    canaField = value;
                    OnPropertyChanged("Cana");
                }
            }
        }

        [XmlAttribute(AttributeName = "versao")]
        public string Versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                if (versaoField is null || versaoField.Equals(value) != true)
                {
                    versaoField = value;
                    OnPropertyChanged("Versao");
                }
            }
        }

        [XmlAttribute("Id")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if (sSerializer is null)
                {
                    sSerializer = new XmlSerializer(typeof(InformacoesNFe));
                }

                return sSerializer;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
        public static bool CanDeserialize(string xml, ref InformacoesNFe obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref InformacoesNFe obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static InformacoesNFe Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (InformacoesNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), ProcessoInformacoesNFeBase)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static InformacoesNFe Deserialize(System.IO.Stream s)
        {
            return (InformacoesNFe)Serializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref InformacoesNFe obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref InformacoesNFe obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static InformacoesNFe LoadFrom(System.IO.Stream source)
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

        public static async Task<InformacoesNFe> LoadFromAsync(System.IO.Stream source)
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(TypeName = "ide", AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class IdentificacaoNFe : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public IdentificacaoNFe() : base()
        {
            nFrefField = new List<ReferenciaDocFiscal>();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private OrgaoIBGE cUFField;
        private string cNFField;
        private string natOpField;
        private FormaDePagamento indPagField;
        private ModeloDocumento modField;
        private int serieField;
        private long nNFField;
        private DateTime? dEmiField;
        private DateTime? dhEmiField;
        private DateTime? dSaiEntField;
        private DateTime? dhSaiEntField;
        private TimeSpan? hSaiEntField;
        private OperacaoNFe tpNFField;
        private string cMunFGField;
        private List<ReferenciaDocFiscal> nFrefField;
        private TipoImpressao tpImpField;
        private FormaEmissao tpEmisField;
        private string cDVField;
        private Ambiente tpAmbField;
        private FinalidadeEmissao finNFeField;
        private ProcessoEmissao procEmiField;
        private string verProcField;
        private DateTime? dhContField;
        private string xJustField;
        private bool _conumidorFinalField = false; // NEW 15/12/2016
        private TipoAtendimento _tpAtendimentoField; // NEW 15/12/2016
        private DestinoOperacao _destOperacao; // NEW 15/12/2016

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("cUF")]
        public OrgaoIBGE UF
        {
            get
            {
                return cUFField;
            }

            set
            {
                if (cUFField.Equals(value) != true)
                {
                    cUFField = value;
                    OnPropertyChanged("UF");
                }
            }
        }

        [XmlElement("cNF")]
        public string Chave
        {
            get
            {
                return cNFField;
            }

            set
            {
                if (cNFField is null || cNFField.Equals(value) != true)
                {
                    cNFField = value;
                    OnPropertyChanged("Chave");
                }
            }
        }

        [XmlElement("natOp")]
        public string NaturezaOperacao
        {
            get
            {
                return natOpField;
            }

            set
            {
                if (natOpField is null || natOpField.Equals(value) != true)
                {
                    natOpField = value;
                    OnPropertyChanged("NaturezaOperacao");
                }
            }
        }

        [XmlElement("indPag")]
        public FormaDePagamento FormaDePagamento
        {
            get
            {
                return indPagField;
            }

            set
            {
                if (indPagField.Equals(value) != true)
                {
                    indPagField = value;
                    OnPropertyChanged("FormaDePagamento");
                }
            }
        }

        [XmlElement("mod")]
        public ModeloDocumento Modelo
        {
            get
            {
                return modField;
            }

            set
            {
                if (modField.Equals(value) != true)
                {
                    modField = value;
                    OnPropertyChanged("Modelo");
                }
            }
        }

        [XmlElement("serie")]
        public int Serie
        {
            get
            {
                return serieField;
            }

            set
            {
                if (serieField == default || serieField.Equals(value) != true)
                {
                    serieField = value;
                    OnPropertyChanged("Serie");
                }
            }
        }

        [XmlElement("nNF")]
        public long Numero
        {
            get
            {
                return nNFField;
            }

            set
            {
                if (nNFField == default || nNFField.Equals(value) != true)
                {
                    nNFField = value;
                    OnPropertyChanged("Numero");
                }
            }
        }

        /// <summary>
        /// Fornece valores válidos para NFe 2.00 e 3.10
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlIgnore()]
        public DateTime? DataEmissao
        {
            get
            {
                if (DataHoraEmissao.HasValue == true)
                {
                    return dhEmiField.Value.Date;
                }
                else
                {
                    return dEmiField;
                }
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

        /// <summary>
        /// Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00
        /// Utilize o campo 'DataEmissao' (Date?) para trabalho. Ambos estarão
        /// automaticamente em sincronia
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("dEmi")]
        public string DataEmissaoXML
        {
            get
            {
                if (DataEmissao.HasValue == true)
                {
                    return string.Format("{0:yyyy-MM-dd}", DataEmissao);
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (dEmiField is null || dEmiField.Equals(value) != true)
                {
                    if (value != null)
                    {
                        var dt = value.Split("-");
                        dEmiField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2)));
                    }
                    else
                    {
                        dEmiField = default;
                    }

                    OnPropertyChanged("DataEmissao");
                }
            }
        }

        public bool ShouldSerializeDataEmissaoXML()
        {
            return dEmiField.HasValue;
        }

        /// <summary>
        /// v3.10
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("dhEmi")]
        public DateTime? DataHoraEmissao
        {
            get
            {
                return dhEmiField;
            }

            set
            {
                if (dhEmiField is null || dhEmiField.Equals(value) != true)
                {
                    dhEmiField = value;
                    OnPropertyChanged("DataHoraEmissao");
                }
            }
        }

        public bool ShouldSerializeDataHoraEmissao()
        {
            return dhEmiField.HasValue;
        }

        /// <summary>
        /// Fornece valores válidos para NFe 2.00 e 3.10
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlIgnore()]
        public DateTime? DataSaidaEntrada
        {
            get
            {
                if (DataHoraSaidaEntrada.HasValue == true)
                {
                    return dhSaiEntField.Value.Date;
                }
                else
                {
                    return dSaiEntField;
                }
            }

            set
            {
                if (dSaiEntField is null || dSaiEntField.Equals(value) != true)
                {
                    dSaiEntField = value;
                    OnPropertyChanged("DataSaidaEntrada");
                }
            }
        }

        /// <summary>
        /// Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00
        /// Utilize o campo 'DataSaidaEntrada' (Date?) para trabalho. Ambos estarão
        /// automaticamente em sincronia
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("dSaiEnt")]
        public string DataSaidaEntradaXML
        {
            get
            {
                if (DataSaidaEntrada.HasValue == true)
                {
                    return string.Format("{0:yyyy-MM-dd}", DataSaidaEntrada);
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (dSaiEntField is null || dSaiEntField.Equals(value) != true)
                {
                    if (value != null)
                    {
                        var dt = value.Split("-");
                        if (dt.Length >= 3)
                        {
                            dSaiEntField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2)));
                        }
                        else
                        {
                            dSaiEntField = default;
                        }
                    }
                    else
                    {
                        dSaiEntField = default;
                    }

                    OnPropertyChanged("DataSaidaEntrada");
                }
            }
        }

        public bool ShouldSerializeDataSaidaEntradaXML()
        {
            return dSaiEntField.HasValue;
        }

        /// <summary>
        /// Fornece valores válidos para NFe 2.00 e 3.10
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlIgnore()]
        public TimeSpan? HoraSaidaEntrada
        {
            get
            {
                if (DataHoraSaidaEntrada.HasValue == true)
                {
                    if (dhSaiEntField.Value.Hour != 0 & dhSaiEntField.Value.Minute != 0 & dhSaiEntField.Value.Second != 0)
                    {
                        return dhSaiEntField.Value.TimeOfDay;
                    }
                    else
                    {
                        return default;
                    }
                }
                else
                {
                    return hSaiEntField;
                }
            }

            set
            {
                if (hSaiEntField is null || hSaiEntField.Equals(value) != true)
                {
                    hSaiEntField = value;
                    OnPropertyChanged("HoraSaidaEntrada");
                }
            }
        }

        public bool ShouldSerializeHoraSaidaEntrada()
        {
            return hSaiEntField.HasValue;
        }

        /// <summary>
        /// v3.10
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("dhSaiEnt")]
        public DateTime? DataHoraSaidaEntrada
        {
            get
            {
                return dhSaiEntField;
            }

            set
            {
                if (dhSaiEntField is null || dhSaiEntField.Equals(value) != true)
                {
                    dhSaiEntField = value;
                    OnPropertyChanged("DataHoraSaidaEntrada");
                }
            }
        }

        public bool ShouldSerializeDataHoraSaidaEntrada()
        {
            return dhSaiEntField.HasValue;
        }

        /// <summary>
        /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
        /// Utilize o campo 'HoraSaidaEntrada' (TimeSpan?) para trabalho. Ambos estarão
        /// automaticamente em sincronia
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("hSaiEnt")]
        public string HoraSaidaEntradaXML
        {
            get
            {
                if (HoraSaidaEntrada.HasValue == true)
                {
                    string str = string.Format("{0:00}", HoraSaidaEntrada.Value.Hours) + ":" + string.Format("{0:00}", HoraSaidaEntrada.Value.Minutes) + ":" + string.Format("{0:00}", HoraSaidaEntrada.Value.Seconds);
                    return str;
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (hSaiEntField is null || hSaiEntField.Equals(value) != true)
                {
                    if (value != null)
                    {
                        var dt = value.Split(":");
                        if (dt.Length >= 3)
                        {
                            hSaiEntField = new TimeSpan(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2]));
                        }
                        else
                        {
                            hSaiEntField = default;
                        }
                    }
                    else
                    {
                        hSaiEntField = default;
                    }

                    OnPropertyChanged("HoraSaidaEntrada");
                }
            }
        }

        public bool ShouldSerializeHoraSaidaEntradaXML()
        {
            return hSaiEntField.HasValue;
        }

        [XmlElement("tpNF")]
        public OperacaoNFe TipoOperacao
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
                    OnPropertyChanged("TipoOperacao");
                }
            }
        }

        [XmlElement("cMunFG")]
        public string CodigoMunicipio
        {
            get
            {
                return cMunFGField;
            }

            set
            {
                if (cMunFGField is null || cMunFGField.Equals(value) != true)
                {
                    cMunFGField = value;
                    OnPropertyChanged("CodigoMunicipio");
                }
            }
        }

        [XmlElement("NFref")]
        public List<ReferenciaDocFiscal> NotasFiscaisReferenciadas
        {
            get
            {
                return nFrefField;
            }

            set
            {
                if (nFrefField is null || nFrefField.Equals(value) != true)
                {
                    nFrefField = value;
                    OnPropertyChanged("NotasFiscaisReferenciadas");
                }
            }
        }

        [XmlElement("tpImp")]
        public TipoImpressao TipoImpressao
        {
            get
            {
                return tpImpField;
            }

            set
            {
                if (tpImpField.Equals(value) != true)
                {
                    tpImpField = value;
                    OnPropertyChanged("TipoImpressao");
                }
            }
        }

        [XmlElement("tpEmis")]
        public FormaEmissao FormaEmissao
        {
            get
            {
                return tpEmisField;
            }

            set
            {
                if (tpEmisField.Equals(value) != true)
                {
                    tpEmisField = value;
                    OnPropertyChanged("FormaEmissao");
                }
            }
        }

        [XmlElement("cDV")]
        public string ChaveDigitoVerificador
        {
            get
            {
                return cDVField;
            }

            set
            {
                if (cDVField is null || cDVField.Equals(value) != true)
                {
                    cDVField = value;
                    OnPropertyChanged("ChaveDigitoVerificador");
                }
            }
        }

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

        [XmlElement("finNFe")]
        public FinalidadeEmissao Finalidade
        {
            get
            {
                return finNFeField;
            }

            set
            {
                if (finNFeField.Equals(value) != true)
                {
                    finNFeField = value;
                    OnPropertyChanged("Finalidade");
                }
            }
        }

        [XmlElement("procEmi")]
        public ProcessoEmissao ProcessoDeEmissao
        {
            get
            {
                return procEmiField;
            }

            set
            {
                if (procEmiField.Equals(value) != true)
                {
                    procEmiField = value;
                    OnPropertyChanged("ProcessoDeEmissao");
                }
            }
        }

        [XmlElement("verProc")]
        public string VersaoProcessoEmissao
        {
            get
            {
                return verProcField;
            }

            set
            {
                if (verProcField is null || verProcField.Equals(value) != true)
                {
                    verProcField = value;
                    OnPropertyChanged("VersaoProcessoEmissao");
                }
            }
        }

        [XmlIgnore()]
        public DateTime? DataHoraContingencia
        {
            get
            {
                return dhContField;
            }

            set
            {
                if (dhContField is null || dhContField.Equals(value) != true)
                {
                    dhContField = value;
                    OnPropertyChanged("DataHoraContingencia");
                }
            }
        }

        [XmlElement("indFinal")]
        public bool ConsumidorFinal // NEW!!! 15/12/2016
        {
            get
            {
                return _conumidorFinalField;
            }

            set
            {
                if (value != _conumidorFinalField)
                {
                    _conumidorFinalField = value;
                    OnPropertyChanged("ConsumidorFinal");
                }
            }
        }

        [XmlElement("indPres")]
        public TipoAtendimento TipoAtendimento // NEW!!! 15/12/2016
        {
            get
            {
                return _tpAtendimentoField;
            }

            set
            {
                _tpAtendimentoField = value;
                OnPropertyChanged("TipoAtendimento");
            }
        }

        [XmlElement("idDest")]
        public DestinoOperacao DestinoOperacao // NEW!!! 15/12/2016
        {
            get
            {
                return _destOperacao;
            }

            set
            {
                _destOperacao = value;
                OnPropertyChanged("DestinoOperacao");
            }
        }

        /// <summary>
        /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
        /// Utilize o campo 'DataHoraContingencia' (Date?) para trabalho. Ambos estarão
        /// automaticamente em sincronia
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("dhCont")]
        public string DataHoraContingenciaXML
        {
            get
            {
                if (DataHoraContingencia.HasValue == true)
                {
                    return string.Format("{0:yyyy-MM-dd}", DataHoraContingencia);
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (dhContField is null || dhContField.Equals(value) != true)
                {
                    if (value != null)
                    {
                        var dt = value.Split("-");
                        if (dt.Length >= 3)
                        {
                            dhContField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2)));
                        }
                        else
                        {
                            dhContField = default;
                        }
                    }
                    else
                    {
                        dhContField = default;
                    }

                    OnPropertyChanged("DataHoraContingencia");
                }
            }
        }

        [XmlElement("xJust")]
        public string JustificativaContingencia
        {
            get
            {
                return xJustField;
            }

            set
            {
                if (xJustField is null || xJustField.Equals(value) != true)
                {
                    xJustField = value;
                    OnPropertyChanged("JustificativaContingencia");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class ProtocoloRecebimento : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public ProtocoloRecebimento() : base()
        {
            // Me.signatureField = New SignatureType()
            // Me.infProtField = New InformacoesProtocolo()
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private InformacoesProtocolo infProtField;
        private SignatureType signatureField;
        private string versaoField;
        private static XmlSerializer sSerializer;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("infProt")]
        public InformacoesProtocolo InformacoesProtocolo
        {
            get
            {
                return infProtField;
            }

            set
            {
                if (infProtField is null || infProtField.Equals(value) != true)
                {
                    infProtField = value;
                    OnPropertyChanged("InformacoesProtocolo");
                }
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                if (signatureField is null || signatureField.Equals(value) != true)
                {
                    signatureField = value;
                    OnPropertyChanged("Signature");
                }
            }
        }

        [XmlAttribute()]
        public string versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                if (versaoField is null || versaoField.Equals(value) != true)
                {
                    versaoField = value;
                    OnPropertyChanged("versao");
                }
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if (sSerializer is null)
                {
                    sSerializer = new XmlSerializer(typeof(ProtocoloRecebimento));
                }

                return sSerializer;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
        public static bool CanDeserialize(string xml, ref ProtocoloRecebimento obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref ProtocoloRecebimento obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static ProtocoloRecebimento Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (ProtocoloRecebimento)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), ProcessoInformacoesNFeBase)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ProtocoloRecebimento Deserialize(System.IO.Stream s)
        {
            return (ProtocoloRecebimento)Serializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref ProtocoloRecebimento obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref ProtocoloRecebimento obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static ProtocoloRecebimento LoadFrom(System.IO.Stream source)
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

        public static async Task<ProtocoloRecebimento> LoadFromAsync(System.IO.Stream source)
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InformacoesProtocolo : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Ambiente tpAmbField;
        private string verAplicField;
        private string chNFeField;
        private DateTime dhRecbtoField;
        private string nProtField;
        private byte[] digValField;
        private string cStatField;
        private string xMotivoField;
        private string idField;
        private static XmlSerializer sSerializer;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        private string chave_codificada = null;

        [XmlIgnore]
        public string ChaveNFeCodificada
        {
            get
            {
                return chave_codificada;
            }
        }

        private byte[] chaveArray;

        [XmlIgnore]
        public byte[] ChaveNFeCodificadaByte
        {
            get
            {
                return chaveArray;
            }
        }

        public string ChaveNFeFormatada
        {
            get
            {
                var builder = new System.Text.StringBuilder();
                for (int i = 0; i <= 10; i++)
                {
                    builder.Append(ChaveNFe.Substring(i * 4, 4));
                    if (i < 10)
                    {
                        builder.Append(" ");
                    }
                }

                return builder.ToString();
            }
        }

        [XmlElement("dhRecbto")]
        public DateTime DataHoraRecebimento
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
                    OnPropertyChanged("DataHoraRecebimento");
                }
            }
        }

        [XmlElement("nProt")]
        public string Protocolo
        {
            get
            {
                return nProtField;
            }

            set
            {
                if (nProtField is null || nProtField.Equals(value) != true)
                {
                    nProtField = value;
                    OnPropertyChanged("Protocolo");
                }
            }
        }

        [XmlElement("digVal", DataType = "base64Binary")]
        public byte[] DigestValue
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

        [XmlElement("cStat")]
        public string StatusNFeCodigo
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
                    OnPropertyChanged("StatusNFeCodigo");
                }
            }
        }

        [XmlElement("xMotivo")]
        public string StatusNfeMotivo
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
                    OnPropertyChanged("StatusNfeMotivo");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if (sSerializer is null)
                {
                    sSerializer = new XmlSerializer(typeof(InformacoesProtocolo));
                }

                return sSerializer;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetCodeBarRaw(string encodedString, byte[] encodedArray)
        {
            chave_codificada = encodedString;
            chaveArray = encodedArray;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
        public static bool CanDeserialize(string xml, ref InformacoesProtocolo obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref InformacoesProtocolo obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static InformacoesProtocolo Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (InformacoesProtocolo)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), ProcessoInformacoesNFeBase)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static InformacoesProtocolo Deserialize(System.IO.Stream s)
        {
            return (InformacoesProtocolo)Serializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref InformacoesProtocolo obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref InformacoesProtocolo obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static InformacoesProtocolo LoadFrom(System.IO.Stream source)
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

        public static async Task<InformacoesProtocolo> LoadFromAsync(System.IO.Stream source)
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    // DO NOT IMPLEMENTS SERIALIZATION FROM HERE...

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Local : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string itemField;
        private PersonalidadeJuridica itemElementNameField;
        private string xLgrField;
        private string nroField;
        private string xCplField;
        private string xBairroField;
        private string cMunField;
        private string xMunField;
        private Estado ufField;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("CNPJ", typeof(string))]
        [XmlElement("CPF", typeof(string))]
        [XmlChoiceIdentifier("PersonalidadeJuridica")]
        public string CNPJ_CPF
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
                    OnPropertyChanged("Item");
                }
            }
        }

        [XmlIgnore()]
        public PersonalidadeJuridica PersonalidadeJuridica
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
                    OnPropertyChanged("PersonalidadeJuridica");
                }
            }
        }

        [XmlElement("xLgr")]
        public string Logradouro
        {
            get
            {
                return xLgrField;
            }

            set
            {
                if (xLgrField is null || xLgrField.Equals(value) != true)
                {
                    xLgrField = value;
                    OnPropertyChanged("Logradouro");
                }
            }
        }

        [XmlElement("nro")]
        public string Numero
        {
            get
            {
                return nroField;
            }

            set
            {
                if (nroField is null || nroField.Equals(value) != true)
                {
                    nroField = value;
                    OnPropertyChanged("Numero");
                }
            }
        }

        [XmlElement("xCpl")]
        public string Complemento
        {
            get
            {
                return xCplField;
            }

            set
            {
                if (xCplField is null || xCplField.Equals(value) != true)
                {
                    xCplField = value;
                    OnPropertyChanged("Complemento");
                }
            }
        }

        [XmlElement("xBairro")]
        public string Bairro
        {
            get
            {
                return xBairroField;
            }

            set
            {
                if (xBairroField is null || xBairroField.Equals(value) != true)
                {
                    xBairroField = value;
                    OnPropertyChanged("Bairro");
                }
            }
        }

        [XmlElement("cMun")]
        public string MunicipioCodigo
        {
            get
            {
                return cMunField;
            }

            set
            {
                if (cMunField is null || cMunField.Equals(value) != true)
                {
                    cMunField = value;
                    OnPropertyChanged("MunicipioCodigo");
                }
            }
        }

        [XmlElement("xMun")]
        public string MunicipioNome
        {
            get
            {
                return xMunField;
            }

            set
            {
                if (xMunField is null || xMunField.Equals(value) != true)
                {
                    xMunField = value;
                    OnPropertyChanged("MunicipioNome");
                }
            }
        }

        [XmlElement("UF")]
        public Estado UF
        {
            get
            {
                return ufField;
            }

            set
            {
                if (ufField.Equals(value) != true)
                {
                    ufField = value;
                    OnPropertyChanged("UF");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Endereco : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string xLgrField;
        private string nroField;
        private string xCplField;
        private string xBairroField;
        private string cMunField;
        private string xMunField;
        private Estado ufField;
        private string cEPField;
        private string cPaisField;
        private string xPaisField;
        private string foneField;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("xLgr")]
        public string Logradouro
        {
            get
            {
                return xLgrField;
            }

            set
            {
                if (xLgrField is null || xLgrField.Equals(value) != true)
                {
                    xLgrField = value;
                    OnPropertyChanged("Logradouro");
                }
            }
        }

        [XmlElement("nro")]
        public string Numero
        {
            get
            {
                return nroField;
            }

            set
            {
                if (nroField is null || nroField.Equals(value) != true)
                {
                    nroField = value;
                    OnPropertyChanged("Numero");
                }
            }
        }

        [XmlElement("xCpl")]
        public string Complemento
        {
            get
            {
                return xCplField;
            }

            set
            {
                if (xCplField is null || xCplField.Equals(value) != true)
                {
                    xCplField = value;
                    OnPropertyChanged("Complemento");
                }
            }
        }

        [XmlElement("xBairro")]
        public string Bairro
        {
            get
            {
                return xBairroField;
            }

            set
            {
                if (xBairroField is null || xBairroField.Equals(value) != true)
                {
                    xBairroField = value;
                    OnPropertyChanged("Bairro");
                }
            }
        }

        [XmlElement("cMun")]
        public string MunicipioCodigo
        {
            get
            {
                return cMunField;
            }

            set
            {
                if (cMunField is null || cMunField.Equals(value) != true)
                {
                    cMunField = value;
                    OnPropertyChanged("MunicipioCodigo");
                }
            }
        }

        [XmlElement("xMun")]
        public string MunicipioNome
        {
            get
            {
                return xMunField;
            }

            set
            {
                if (xMunField is null || xMunField.Equals(value) != true)
                {
                    xMunField = value;
                    OnPropertyChanged("MunicipioNome");
                }
            }
        }

        public Estado UF
        {
            get
            {
                return ufField;
            }

            set
            {
                if (ufField.Equals(value) != true)
                {
                    ufField = value;
                    OnPropertyChanged("UF");
                }
            }
        }

        public string CEP
        {
            get
            {
                return cEPField;
            }

            set
            {
                if (cEPField is null || cEPField.Equals(value) != true)
                {
                    cEPField = value;
                    OnPropertyChanged("CEP");
                }
            }
        }

        [XmlIgnore()]
        public string CEPFormatado
        {
            get
            {
                if (CEP != null)
                {
                    return CEP.FormatCEP();
                }
                else
                {
                    return null;
                }
            }
        }

        [XmlElement("cPais")]
        public string PaisCodigo
        {
            get
            {
                return cPaisField;
            }

            set
            {
                if (cPaisField is null || cPaisField.Equals(value) != true)
                {
                    cPaisField = value;
                    OnPropertyChanged("PaisCodigo");
                }
            }
        }

        [XmlElement("xPais")]
        public string PaisNome
        {
            get
            {
                return xPaisField;
            }

            set
            {
                if (xPaisField is null || xPaisField.Equals(value) != true)
                {
                    xPaisField = value;
                    OnPropertyChanged("PaisNome");
                }
            }
        }

        [XmlElement("fone")]
        public string Fone
        {
            get
            {
                return foneField;
            }

            set
            {
                if (foneField is null || foneField.Equals(value) != true)
                {
                    foneField = value;
                    OnPropertyChanged("Fone");
                }
            }
        }

        public string FoneFormatado
        {
            get
            {
                try
                {
                    long @int = Conversions.ToLong(Fone);
                    return string.Format("{0:(00)0000-0000}", @int);
                }
                catch (Exception)
                {
                    return Fone;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Emitente : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Emitente() : base()
        {
            enderEmitField = new Endereco();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string itemField;
        private PersonalidadeJuridica itemElementNameField;
        private string xNomeField;
        private string xFantField;
        private Endereco enderEmitField;
        private string ieField;
        private string iESTField;
        private string imField;
        private string cNAEField;
        private RegimeTributario cRTField;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private byte[] _logo;

        [XmlIgnore()]
        public byte[] Logo
        {
            get
            {
                return _logo;
            }

            set
            {
                _logo = value;
                OnPropertyChanged("Logo");
            }
        }

        [XmlElement("CNPJ", typeof(string))]
        [XmlElement("CPF", typeof(string))]
        [XmlChoiceIdentifier("EmitentePersonalidadeJuridica")]
        public string CNPJ_CPF
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
                    OnPropertyChanged("CNPJ_CPF");
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
                    OnPropertyChanged("ItemElementName");
                }
            }
        }

        [XmlElement("xNome")]
        public string RazaoSocial
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
                    OnPropertyChanged("RazaoSocial");
                }
            }
        }

        [XmlIgnore()]
        public string CNPJ_CPFFormatado
        {
            get
            {
                if (CNPJ_CPF != null)
                {
                    return CNPJ_CPF.FormatRFBDocument();
                }
                else
                {
                    return null;
                }
            }
        }

        [XmlElement("xFant")]
        public string NomeFantasia
        {
            get
            {
                return xFantField;
            }

            set
            {
                if (xFantField is null || xFantField.Equals(value) != true)
                {
                    xFantField = value;
                    OnPropertyChanged("NomeFantasia");
                }
            }
        }

        [XmlElement("enderEmit")]
        public Endereco Endereco
        {
            get
            {
                return enderEmitField;
            }

            set
            {
                if (enderEmitField is null || enderEmitField.Equals(value) != true)
                {
                    enderEmitField = value;
                    OnPropertyChanged("Endereco");
                }
            }
        }

        [XmlElement("IE")]
        public string InscricaoEstadual
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
                    OnPropertyChanged("InscricaoEstadual");
                }
            }
        }

        [XmlIgnore()]
        public string IEFormatado
        {
            get
            {
                if (InscricaoEstadual != null)
                {
                    return InscricaoEstadual.FormatIE(Endereco.UF.ToString());
                }
                else
                {
                    return null;
                }
            }
        }

        [XmlElement("IEST")]
        public string InscricaoEstadualST
        {
            get
            {
                return iESTField;
            }

            set
            {
                if (iESTField is null || iESTField.Equals(value) != true)
                {
                    iESTField = value;
                    OnPropertyChanged("InscricaoEstadualST");
                }
            }
        }

        [XmlElement("IM")]
        public string InscricaoMunicipal
        {
            get
            {
                return imField;
            }

            set
            {
                if (imField is null || imField.Equals(value) != true)
                {
                    imField = value;
                    OnPropertyChanged("InscricaoMunicipal");
                }
            }
        }

        public string CNAE
        {
            get
            {
                return cNAEField;
            }

            set
            {
                if (cNAEField is null || cNAEField.Equals(value) != true)
                {
                    cNAEField = value;
                    OnPropertyChanged("CNAE");
                }
            }
        }

        [XmlElement("CRT")]
        public RegimeTributario RegimeTributario
        {
            get
            {
                return cRTField;
            }

            set
            {
                if (cRTField.Equals(value) != true)
                {
                    cRTField = value;
                    OnPropertyChanged("RegimeTributario");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
    }

    /// <summary>
    /// Informações do fisco emitente, grupo de uso exclusivo do fisco.
    /// </summary>
    /// <remarks></remarks>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Fisco : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string cNPJField;
        private string xOrgaoField;
        private string matrField;
        private string xAgenteField;
        private string foneField;
        private Estado ufField;
        private string nDARField;
        private string dEmiField;
        private string vDARField;
        private string repEmiField;
        private DateTime? dPagField;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string CNPJ
        {
            get
            {
                return cNPJField;
            }

            set
            {
                if (cNPJField is null || cNPJField.Equals(value) != true)
                {
                    cNPJField = value;
                    OnPropertyChanged("CNPJ");
                }
            }
        }

        [XmlElement("xOrgao")]
        public string Orgao
        {
            get
            {
                return xOrgaoField;
            }

            set
            {
                if (xOrgaoField is null || xOrgaoField.Equals(value) != true)
                {
                    xOrgaoField = value;
                    OnPropertyChanged("Orgao");
                }
            }
        }

        [XmlElement("matr")]
        public string AgenteMatricula
        {
            get
            {
                return matrField;
            }

            set
            {
                if (matrField is null || matrField.Equals(value) != true)
                {
                    matrField = value;
                    OnPropertyChanged("AgenteMatricula");
                }
            }
        }

        [XmlElement("xAgente")]
        public string AgenteNome
        {
            get
            {
                return xAgenteField;
            }

            set
            {
                if (xAgenteField is null || xAgenteField.Equals(value) != true)
                {
                    xAgenteField = value;
                    OnPropertyChanged("AgenteNome");
                }
            }
        }

        public string fone
        {
            get
            {
                return foneField;
            }

            set
            {
                if (foneField is null || foneField.Equals(value) != true)
                {
                    foneField = value;
                    OnPropertyChanged("fone");
                }
            }
        }

        public Estado UF
        {
            get
            {
                return ufField;
            }

            set
            {
                if (ufField.Equals(value) != true)
                {
                    ufField = value;
                    OnPropertyChanged("UF");
                }
            }
        }

        /// <summary>
        /// Número do Documento de Arrecadação Estadual
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("nDAR")]
        public string NumeroDAR
        {
            get
            {
                return nDARField;
            }

            set
            {
                if (nDARField is null || nDARField.Equals(value) != true)
                {
                    nDARField = value;
                    OnPropertyChanged("NumeroDAR");
                }
            }
        }

        /// <summary>
        /// Data de emissão do Documento de Arrecadação Estadual
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("dEmi")]
        public string DataEmissaoDAR
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
                    OnPropertyChanged("DataEmissaoDAR");
                }
            }
        }

        /// <summary>
        /// Valor Total do Documento de Arrecadação Estadual
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("vDAR")]
        public string ValorDAR
        {
            get
            {
                return vDARField;
            }

            set
            {
                if (vDARField is null || vDARField.Equals(value) != true)
                {
                    vDARField = value;
                    OnPropertyChanged("ValorDAR");
                }
            }
        }

        [XmlElement("repEmi")]
        public string ReparticaoFiscal
        {
            get
            {
                return repEmiField;
            }

            set
            {
                if (repEmiField is null || repEmiField.Equals(value) != true)
                {
                    repEmiField = value;
                    OnPropertyChanged("ReparticaoFiscal");
                }
            }
        }

        [XmlElement("dPag")]
        public DateTime? DataPagamentoDAR
        {
            get
            {
                return dPagField;
            }

            set
            {
                if (dPagField is null || dPagField.Equals(value) != true)
                {
                    dPagField = value;
                    OnPropertyChanged("DataPagamentoDAR");
                }
            }
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Destinatario : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Destinatario() : base()
        {
            enderDestField = new Endereco();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string itemField;
        private PersonalidadeJuridica itemElementNameField;
        private string _idEstrangeiroField;
        private string xNomeField;
        private Endereco enderDestField;
        private string ieField;
        private string iSUFField;
        private string emailField;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("CNPJ", typeof(string))]
        [XmlElement("CPF", typeof(string))]
        [XmlChoiceIdentifier("DestinatarioPersonalidadeJuridica")]
        public string CNPJ_CPF
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
                    OnPropertyChanged("CNPJ_CPF");
                }
            }
        }

        [XmlIgnore()]
        public string CNPJ_CPFFormatado
        {
            get
            {
                if (CNPJ_CPF != null)
                {
                    return CNPJ_CPF.FormatRFBDocument();
                }
                else
                {
                    return null;
                }
            }
        }

        [XmlIgnore()]
        public PersonalidadeJuridica DestinatarioPersonalidadeJuridica
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
                    OnPropertyChanged("DestinatarioPersonalidadeJuridica");
                }
            }
        }

        [XmlElement("idEstrangeiro")]
        public string idEstrangeiro
        {
            get
            {
                return _idEstrangeiroField;
            }

            set
            {
                if (_idEstrangeiroField is null || _idEstrangeiroField.Equals(value) != true)
                {
                    _idEstrangeiroField = value;
                    OnPropertyChanged("idEstrangeiro");
                }
            }
        }

        [XmlElement("xNome")]
        public string RazaoSocial
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
                    OnPropertyChanged("RazaoSocial");
                }
            }
        }

        [XmlElement("enderDest")]
        public Endereco Endereco
        {
            get
            {
                return enderDestField;
            }

            set
            {
                if (enderDestField is null || enderDestField.Equals(value) != true)
                {
                    enderDestField = value;
                    OnPropertyChanged("Endereco");
                }
            }
        }

        [XmlElement("IE")]
        public string InscricaoEstadual
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
                    OnPropertyChanged("InscricaoEstadual");
                }
            }
        }

        [XmlIgnore()]
        public string IEFormatado
        {
            get
            {
                if (InscricaoEstadual != null)
                {
                    return InscricaoEstadual.FormatIE(Endereco.UF.ToString());
                }
                else
                {
                    return null;
                }
            }
        }

        [XmlElement("ISUF")]
        public string InscricaoSuframa
        {
            get
            {
                return iSUFField;
            }

            set
            {
                if (iSUFField is null || iSUFField.Equals(value) != true)
                {
                    iSUFField = value;
                    OnPropertyChanged("InscricaoSuframa");
                }
            }
        }

        [XmlElement("email")]
        public string eMail
        {
            get
            {
                return emailField;
            }

            set
            {
                if (emailField is null || emailField.Equals(value) != true)
                {
                    emailField = value;
                    OnPropertyChanged("eMail");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DeclaracaoImportacao : INotifyPropertyChanged
    {
        private string nDIField;
        private DateTime? dDIField;
        private string xLocDesembField;
        private Estado uFDesembField;
        private DateTime? dDesembField;
        private TipoViaTransporteDI ctpViaTransp = TipoViaTransporteDI.EntradaSaidaFicticia;
        private double? cAFRMMField;
        private TipoIntermedioDI ctpIntermedio = TipoIntermedioDI.ContaPropria;
        private string cExportadorField;
        private List<ProdutoDeclaracaoImportacao> adiField;

        public DeclaracaoImportacao() : base()
        {
            adiField = new List<ProdutoDeclaracaoImportacao>();
        }

        public string nDI
        {
            get
            {
                return nDIField;
            }

            set
            {
                if (nDIField is null || nDIField.Equals(value) != true)
                {
                    nDIField = value;
                    OnPropertyChanged("nDI");
                }
            }
        }

        public DateTime? dDI
        {
            get
            {
                return dDIField;
            }

            set
            {
                if (dDIField is null || dDIField.Equals(value) != true)
                {
                    dDIField = value;
                    OnPropertyChanged("dDI");
                }
            }
        }

        public bool ShouldSerializedDI()
        {
            return dDIField.HasValue;
        }

        public string xLocDesemb
        {
            get
            {
                return xLocDesembField;
            }

            set
            {
                if (xLocDesembField is null || xLocDesembField.Equals(value) != true)
                {
                    xLocDesembField = value;
                    OnPropertyChanged("xLocDesemb");
                }
            }
        }

        public Estado UFDesemb
        {
            get
            {
                return uFDesembField;
            }

            set
            {
                if (uFDesembField.Equals(value) != true)
                {
                    uFDesembField = value;
                    OnPropertyChanged("UFDesemb");
                }
            }
        }

        public DateTime? dDesemb
        {
            get
            {
                return dDesembField;
            }

            set
            {
                if (dDesembField is null || dDesembField.Equals(value) != true)
                {
                    dDesembField = value;
                    OnPropertyChanged("dDesemb");
                }
            }
        }

        public bool ShouldSerializedDesemb()
        {
            return dDesembField.HasValue;
        }

        public TipoViaTransporteDI tpViaTransp
        {
            get
            {
                return ctpViaTransp;
            }

            set
            {
                if (ctpViaTransp.Equals(value) != true)
                {
                    ctpViaTransp = value;
                    OnPropertyChanged("tpViaTransp");
                }
            }
        }

        [XmlElement("vAFRMM")]
        public double? ValorAFRMM
        {
            get
            {
                return cAFRMMField;
            }

            set
            {
                if (cAFRMMField is null || cAFRMMField.Equals(value) != true)
                {
                    cAFRMMField = value;
                    OnPropertyChanged("ValorAFRMM");
                }
            }
        }

        public bool ShouldSerializedValorAFRMM()
        {
            return cAFRMMField.HasValue;
        }

        public TipoIntermedioDI tpIntermedio
        {
            get
            {
                return ctpIntermedio;
            }

            set
            {
                if (ctpIntermedio.Equals(value) != true)
                {
                    ctpIntermedio = value;
                    OnPropertyChanged("tpIntermedio");
                }
            }
        }

        public string cExportador
        {
            get
            {
                return cExportadorField;
            }

            set
            {
                if (cExportadorField is null || cExportadorField.Equals(value) != true)
                {
                    cExportadorField = value;
                    OnPropertyChanged("cExportador");
                }
            }
        }

        [XmlElement("adi")]
        public List<ProdutoDeclaracaoImportacao> adi
        {
            get
            {
                return adiField;
            }

            set
            {
                if (adiField is null || adiField.Equals(value) != true)
                {
                    adiField = value;
                    OnPropertyChanged("adi");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class ProdutoDeclaracaoImportacao : INotifyPropertyChanged
    {
        private string nAdicaoField;
        private string nSeqAdicField;
        private string cFabricanteField;
        private string vDescDIField;

        public string nAdicao
        {
            get
            {
                return nAdicaoField;
            }

            set
            {
                if (nAdicaoField is null || nAdicaoField.Equals(value) != true)
                {
                    nAdicaoField = value;
                    OnPropertyChanged("nAdicao");
                }
            }
        }

        public string nSeqAdic
        {
            get
            {
                return nSeqAdicField;
            }

            set
            {
                if (nSeqAdicField is null || nSeqAdicField.Equals(value) != true)
                {
                    nSeqAdicField = value;
                    OnPropertyChanged("nSeqAdic");
                }
            }
        }

        public string cFabricante
        {
            get
            {
                return cFabricanteField;
            }

            set
            {
                if (cFabricanteField is null || cFabricanteField.Equals(value) != true)
                {
                    cFabricanteField = value;
                    OnPropertyChanged("cFabricante");
                }
            }
        }

        public string vDescDI
        {
            get
            {
                return vDescDIField;
            }

            set
            {
                if (vDescDIField is null || vDescDIField.Equals(value) != true)
                {
                    vDescDIField = value;
                    OnPropertyChanged("vDescDI");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Totais : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Totais() : base()
        {
            // Me.retTribField = New TNFeInfNFeTotalRetTrib()
            // Me.iSSQNtotField = New TNFeInfNFeTotalISSQNtot()
            // Me.iCMSTotField = New TotalICMS()
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private TotalICMS iCMSTotField;
        private TotalISSQN iSSQNtotField;
        private TotalRetencaoTributos retTribField;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("ICMSTot")]
        public TotalICMS ICMS
        {
            get
            {
                return iCMSTotField;
            }

            set
            {
                if (iCMSTotField is null || iCMSTotField.Equals(value) != true)
                {
                    iCMSTotField = value;
                    OnPropertyChanged("ICMS");
                }
            }
        }

        [XmlElement("ISSQNtot")]
        public TotalISSQN ISSQN
        {
            get
            {
                return iSSQNtotField;
            }

            set
            {
                if (iSSQNtotField is null || iSSQNtotField.Equals(value) != true)
                {
                    iSSQNtotField = value;
                    OnPropertyChanged("ISSQN");
                }
            }
        }

        [XmlElement("retTrib")]
        public TotalRetencaoTributos Retencoes
        {
            get
            {
                return retTribField;
            }

            set
            {
                if (retTribField is null || retTribField.Equals(value) != true)
                {
                    retTribField = value;
                    OnPropertyChanged("Retencoes");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

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
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class TotalICMS : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? vBCField;
        private double? vICMSField;
        private double? vBCSTField;
        private double? vSTField;
        private double? vProdField;
        private double? vFreteField;
        private double? vSegField;
        private double? vDescField;
        private double? vIIField;
        private double? vIPIField;
        private double? vIPIDevolField;
        private double? vPISField;
        private double? vCOFINSField;
        private double? vOutroField;
        private double? vNFField;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("vBC")]
        public double? BaseDeCalculo
        {
            get
            {
                return vBCField;
            }

            set
            {
                if (vBCField is null || vBCField.Equals(value) != true)
                {
                    vBCField = value;
                    OnPropertyChanged("BaseDeCalculo");
                }
            }
        }

        public bool ShouldSerializeBaseDeCalculo()
        {
            return vBCField.HasValue;
        }

        [XmlElement("vICMS")]
        public double? ICMS
        {
            get
            {
                return vICMSField;
            }

            set
            {
                if (vICMSField is null || vICMSField.Equals(value) != true)
                {
                    vICMSField = value;
                    OnPropertyChanged("ICMS");
                }
            }
        }

        public bool ShouldSerializeICMS()
        {
            return vICMSField.HasValue;
        }

        [XmlElement("vBCST")]
        public double? BaseDeCalculoST
        {
            get
            {
                return vBCSTField;
            }

            set
            {
                if (vBCSTField is null || vBCSTField.Equals(value) != true)
                {
                    vBCSTField = value;
                    OnPropertyChanged("BaseDeCalculoST");
                }
            }
        }

        public bool ShouldSerializeBaseDeCalculoST()
        {
            return vBCSTField.HasValue;
        }

        [XmlElement("vST")]
        public double? ICMSST
        {
            get
            {
                return vSTField;
            }

            set
            {
                if (vSTField is null || vSTField.Equals(value) != true)
                {
                    vSTField = value;
                    OnPropertyChanged("ICMSST");
                }
            }
        }

        public bool ShouldSerializeICMSST()
        {
            return vSTField.HasValue;
        }

        [XmlElement("vProd")]
        public double? Produtos
        {
            get
            {
                return vProdField;
            }

            set
            {
                if (vProdField is null || vProdField.Equals(value) != true)
                {
                    vProdField = value;
                    OnPropertyChanged("Produtos");
                }
            }
        }

        public bool ShouldSerializeProdutos()
        {
            return vProdField.HasValue;
        }

        [XmlElement("vFrete")]
        public double? Frete
        {
            get
            {
                return vFreteField;
            }

            set
            {
                if (vFreteField is null || vFreteField.Equals(value) != true)
                {
                    vFreteField = value;
                    OnPropertyChanged("Frete");
                }
            }
        }

        public bool ShouldSerializeFrete()
        {
            return vFreteField.HasValue;
        }

        [XmlElement("vSeg")]
        public double? Seguros
        {
            get
            {
                return vSegField;
            }

            set
            {
                if (vSegField is null || vSegField.Equals(value) != true)
                {
                    vSegField = value;
                    OnPropertyChanged("Seguros");
                }
            }
        }

        public bool ShouldSerializeSeguros()
        {
            return vSegField.HasValue;
        }

        [XmlElement("vDesc")]
        public double? Desconto
        {
            get
            {
                return vDescField;
            }

            set
            {
                if (vDescField is null || vDescField.Equals(value) != true)
                {
                    vDescField = value;
                    OnPropertyChanged("Desconto");
                }
            }
        }

        public bool ShouldSerializeDesconto()
        {
            return vDescField.HasValue;
        }

        /// <summary>
        /// What the hell is that?
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("vII")]
        public double? II
        {
            get
            {
                return vIIField;
            }

            set
            {
                if (vIIField is null || vIIField.Equals(value) != true)
                {
                    vIIField = value;
                    OnPropertyChanged("II");
                }
            }
        }

        public bool ShouldSerializeII()
        {
            return vIIField.HasValue;
        }

        [XmlElement("vIPI")]
        public double? IPI
        {
            get
            {
                return vIPIField;
            }

            set
            {
                if (vIPIField is null || vIPIField.Equals(value) != true)
                {
                    vIPIField = value;
                    OnPropertyChanged("IPI");
                }
            }
        }

        public bool ShouldSerializeIPI()
        {
            return vIPIField.HasValue;
        }

        [XmlElement("vIPIDevol")]
        public double? vIPIDevol
        {
            get
            {
                return vIPIDevolField;
            }

            set
            {
                if (vIPIDevolField is null || vIPIDevolField.Equals(value) != true)
                {
                    vIPIDevolField = value;
                    OnPropertyChanged("vIPIDevol");
                }
            }
        }

        public bool ShouldSerializevIPIDevol()
        {
            return vIPIDevolField.HasValue;
        }

        [XmlElement("vPIS")]
        public double? PIS
        {
            get
            {
                return vPISField;
            }

            set
            {
                if (vPISField is null || vPISField.Equals(value) != true)
                {
                    vPISField = value;
                    OnPropertyChanged("PIS");
                }
            }
        }

        public bool ShouldSerializePIS()
        {
            return vPISField.HasValue;
        }

        [XmlElement("vCOFINS")]
        public double? COFINS
        {
            get
            {
                return vCOFINSField;
            }

            set
            {
                if (vCOFINSField is null || vCOFINSField.Equals(value) != true)
                {
                    vCOFINSField = value;
                    OnPropertyChanged("COFINS");
                }
            }
        }

        public bool ShouldSerializeCOFINS()
        {
            return vCOFINSField.HasValue;
        }

        [XmlElement("vOutro")]
        public double? Outros
        {
            get
            {
                return vOutroField;
            }

            set
            {
                if (vOutroField is null || vOutroField.Equals(value) != true)
                {
                    vOutroField = value;
                    OnPropertyChanged("Outros");
                }
            }
        }

        public bool ShouldSerializeOutros()
        {
            return vOutroField.HasValue;
        }

        [XmlElement("vNF")]
        public double? TotalNF
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
                    OnPropertyChanged("TotalNF");
                }
            }
        }

        public bool ShouldSerializeTotalNF()
        {
            return vNFField.HasValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class TotalISSQN : INotifyPropertyChanged
    {
        private double? vServField;
        private double? vBCField;
        private double? vISSField;
        private double? vPISField;
        private double? vCOFINSField;

        public double? vServ
        {
            get
            {
                return vServField;
            }

            set
            {
                if (vServField is null || vServField.Equals(value) != true)
                {
                    vServField = value;
                    OnPropertyChanged("vServ");
                }
            }
        }

        public double? vBC
        {
            get
            {
                return vBCField;
            }

            set
            {
                if (vBCField is null || vBCField.Equals(value) != true)
                {
                    vBCField = value;
                    OnPropertyChanged("vBC");
                }
            }
        }

        public double? vISS
        {
            get
            {
                return vISSField;
            }

            set
            {
                if (vISSField is null || vISSField.Equals(value) != true)
                {
                    vISSField = value;
                    OnPropertyChanged("vISS");
                }
            }
        }

        public double? vPIS
        {
            get
            {
                return vPISField;
            }

            set
            {
                if (vPISField is null || vPISField.Equals(value) != true)
                {
                    vPISField = value;
                    OnPropertyChanged("vPIS");
                }
            }
        }

        public double? vCOFINS
        {
            get
            {
                return vCOFINSField;
            }

            set
            {
                if (vCOFINSField is null || vCOFINSField.Equals(value) != true)
                {
                    vCOFINSField = value;
                    OnPropertyChanged("vCOFINS");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class TotalRetencaoTributos : INotifyPropertyChanged
    {
        private string vRetPISField;
        private string vRetCOFINSField;
        private string vRetCSLLField;
        private string vBCIRRFField;
        private string vIRRFField;
        private string vBCRetPrevField;
        private string vRetPrevField;

        public string vRetPIS
        {
            get
            {
                return vRetPISField;
            }

            set
            {
                if (vRetPISField is null || vRetPISField.Equals(value) != true)
                {
                    vRetPISField = value;
                    OnPropertyChanged("vRetPIS");
                }
            }
        }

        public string vRetCOFINS
        {
            get
            {
                return vRetCOFINSField;
            }

            set
            {
                if (vRetCOFINSField is null || vRetCOFINSField.Equals(value) != true)
                {
                    vRetCOFINSField = value;
                    OnPropertyChanged("vRetCOFINS");
                }
            }
        }

        public string vRetCSLL
        {
            get
            {
                return vRetCSLLField;
            }

            set
            {
                if (vRetCSLLField is null || vRetCSLLField.Equals(value) != true)
                {
                    vRetCSLLField = value;
                    OnPropertyChanged("vRetCSLL");
                }
            }
        }

        public string vBCIRRF
        {
            get
            {
                return vBCIRRFField;
            }

            set
            {
                if (vBCIRRFField is null || vBCIRRFField.Equals(value) != true)
                {
                    vBCIRRFField = value;
                    OnPropertyChanged("vBCIRRF");
                }
            }
        }

        public string vIRRF
        {
            get
            {
                return vIRRFField;
            }

            set
            {
                if (vIRRFField is null || vIRRFField.Equals(value) != true)
                {
                    vIRRFField = value;
                    OnPropertyChanged("vIRRF");
                }
            }
        }

        public string vBCRetPrev
        {
            get
            {
                return vBCRetPrevField;
            }

            set
            {
                if (vBCRetPrevField is null || vBCRetPrevField.Equals(value) != true)
                {
                    vBCRetPrevField = value;
                    OnPropertyChanged("vBCRetPrev");
                }
            }
        }

        public string vRetPrev
        {
            get
            {
                return vRetPrevField;
            }

            set
            {
                if (vRetPrevField is null || vRetPrevField.Equals(value) != true)
                {
                    vRetPrevField = value;
                    OnPropertyChanged("vRetPrev");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Cobranca : INotifyPropertyChanged
    {
        private CobrancaFatura fatField;
        private List<CobrancaDuplicata> dupField;

        public Cobranca() : base()
        {
            dupField = new List<CobrancaDuplicata>();
            // Me.fatField = New TNFeInfNFeCobrFat()
        }

        public CobrancaFatura fat
        {
            get
            {
                return fatField;
            }

            set
            {
                if (fatField is null || fatField.Equals(value) != true)
                {
                    fatField = value;
                    OnPropertyChanged("fat");
                }
            }
        }

        [XmlElement("dup")]
        public List<CobrancaDuplicata> dup
        {
            get
            {
                return dupField;
            }

            set
            {
                if (dupField is null || dupField.Equals(value) != true)
                {
                    dupField = value;
                    OnPropertyChanged("dup");
                }
            }
        }

        public bool MostraFatura
        {
            get
            {
                if (dup is null)
                {
                    return true;
                }
                else if (dup.Count <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class CobrancaFatura : INotifyPropertyChanged
    {
        private string nFatField;
        private double? vOrigField;
        private double? vDescField;
        private double? vLiqField;

        public string nFat
        {
            get
            {
                return nFatField;
            }

            set
            {
                if (nFatField is null || nFatField.Equals(value) != true)
                {
                    nFatField = value;
                    OnPropertyChanged("nFat");
                }
            }
        }

        public double? vOrig
        {
            get
            {
                return vOrigField;
            }

            set
            {
                if (vOrigField is null || vOrigField.Equals(value) != true)
                {
                    vOrigField = value;
                    OnPropertyChanged("vOrig");
                }
            }
        }

        public double? vDesc
        {
            get
            {
                return vDescField;
            }

            set
            {
                if (vDescField is null || vDescField.Equals(value) != true)
                {
                    vDescField = value;
                    OnPropertyChanged("vDesc");
                }
            }
        }

        public double? vLiq
        {
            get
            {
                return vLiqField;
            }

            set
            {
                if (vLiqField is null || vLiqField.Equals(value) != true)
                {
                    vLiqField = value;
                    OnPropertyChanged("vLiq");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return string.Format("FATURA: Valor original: {0:c2}" + '\r' + "Desconto: {1:c2}" + '\r' + "Valor Líquido: {2:c2}", vOrig, vDesc, vLiq);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class CobrancaDuplicata : INotifyPropertyChanged
    {
        private string nDupField;
        private DateTime? dVencField;
        private double? vDupField;

        public string nDup
        {
            get
            {
                return nDupField;
            }

            set
            {
                if (nDupField is null || nDupField.Equals(value) != true)
                {
                    nDupField = value;
                    OnPropertyChanged("nDup");
                }
            }
        }

        [XmlIgnore()]
        public DateTime? dVenc
        {
            get
            {
                return dVencField;
            }

            set
            {
                if (dVencField is null || dVencField.Equals(value) != true)
                {
                    dVencField = value;
                    OnPropertyChanged("dVenc");
                }
            }
        }

        /// <summary>
        /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
        /// Utilize o campo 'dVenc' (Date?) para trabalho. Ambos estarão
        /// automaticamente em sincronia
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("dVenc")]
        public string dVencXML
        {
            get
            {
                if (dVenc.HasValue == true)
                {
                    return string.Format("{0:yyyy-MM-dd}", dVenc);
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (dVencField is null || dVencField.Equals(value) != true)
                {
                    if (value != null)
                    {
                        var dt = value.Split("-");
                        dVencField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2]));
                    }
                    else
                    {
                        dVencField = default;
                    }

                    OnPropertyChanged("dVenc");
                }
            }
        }

        public double? vDup
        {
            get
            {
                return vDupField;
            }

            set
            {
                if (vDupField is null || vDupField.Equals(value) != true)
                {
                    vDupField = value;
                    OnPropertyChanged("vDup");
                }
            }
        }

        public bool ShouldSerializevDup()
        {
            return vDupField.HasValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return string.Format("Nº {0}, venc.: {1:dd/MM/yyyy}, valor: {2:c2}", nDup, dVenc, vDup);
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InformacoesAdicionais : INotifyPropertyChanged
    {
        private string infAdFiscoField;
        private string infCplField;
        private List<InformacoesAdicionaisObsContribuite> obsContField;
        private List<InformacoesAdicionaisObsFisco> obsFiscoField;
        private List<InformacoesAdicionaisProcRef> procRefField;

        public InformacoesAdicionais() : base()
        {
            procRefField = new List<InformacoesAdicionaisProcRef>();
            obsFiscoField = new List<InformacoesAdicionaisObsFisco>();
            obsContField = new List<InformacoesAdicionaisObsContribuite>();
        }

        public string infAdFisco
        {
            get
            {
                return infAdFiscoField;
            }

            set
            {
                if (infAdFiscoField is null || infAdFiscoField.Equals(value) != true)
                {
                    infAdFiscoField = value;
                    OnPropertyChanged("infAdFisco");
                }
            }
        }

        public string infCpl
        {
            get
            {
                return infCplField;
            }

            set
            {
                if (infCplField is null || infCplField.Equals(value) != true)
                {
                    infCplField = value;
                    OnPropertyChanged("infCpl");
                }
            }
        }

        [XmlElement("obsCont")]
        public List<InformacoesAdicionaisObsContribuite> obsCont
        {
            get
            {
                return obsContField;
            }

            set
            {
                if (obsContField is null || obsContField.Equals(value) != true)
                {
                    obsContField = value;
                    OnPropertyChanged("obsCont");
                }
            }
        }

        [XmlElement("obsFisco")]
        public List<InformacoesAdicionaisObsFisco> obsFisco
        {
            get
            {
                return obsFiscoField;
            }

            set
            {
                if (obsFiscoField is null || obsFiscoField.Equals(value) != true)
                {
                    obsFiscoField = value;
                    OnPropertyChanged("obsFisco");
                }
            }
        }

        [XmlElement("procRef")]
        public List<InformacoesAdicionaisProcRef> procRef
        {
            get
            {
                return procRefField;
            }

            set
            {
                if (procRefField is null || procRefField.Equals(value) != true)
                {
                    procRefField = value;
                    OnPropertyChanged("procRef");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InformacoesAdicionaisObsContribuite : INotifyPropertyChanged
    {
        private string xTextoField;
        private string xCampoField;

        public string xTexto
        {
            get
            {
                return xTextoField;
            }

            set
            {
                if (xTextoField is null || xTextoField.Equals(value) != true)
                {
                    xTextoField = value;
                    OnPropertyChanged("xTexto");
                }
            }
        }

        [XmlAttribute()]
        public string xCampo
        {
            get
            {
                return xCampoField;
            }

            set
            {
                if (xCampoField is null || xCampoField.Equals(value) != true)
                {
                    xCampoField = value;
                    OnPropertyChanged("xCampo");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InformacoesAdicionaisObsFisco : INotifyPropertyChanged
    {
        private string xTextoField;
        private string xCampoField;

        public string xTexto
        {
            get
            {
                return xTextoField;
            }

            set
            {
                if (xTextoField is null || xTextoField.Equals(value) != true)
                {
                    xTextoField = value;
                    OnPropertyChanged("xTexto");
                }
            }
        }

        [XmlAttribute()]
        public string xCampo
        {
            get
            {
                return xCampoField;
            }

            set
            {
                if (xCampoField is null || xCampoField.Equals(value) != true)
                {
                    xCampoField = value;
                    OnPropertyChanged("xCampo");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InformacoesAdicionaisProcRef : INotifyPropertyChanged
    {
        private string nProcField;
        private IndicadorProcessoReferenciado indProcField;

        public string nProc
        {
            get
            {
                return nProcField;
            }

            set
            {
                if (nProcField is null || nProcField.Equals(value) != true)
                {
                    nProcField = value;
                    OnPropertyChanged("nProc");
                }
            }
        }

        public IndicadorProcessoReferenciado indProc
        {
            get
            {
                return indProcField;
            }

            set
            {
                if (indProcField.Equals(value) != true)
                {
                    indProcField = value;
                    OnPropertyChanged("indProc");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Exportacao : INotifyPropertyChanged
    {
        private Estado uFEmbarqField;
        private string xLocEmbarqField;

        public Estado UFEmbarq
        {
            get
            {
                return uFEmbarqField;
            }

            set
            {
                if (uFEmbarqField.Equals(value) != true)
                {
                    uFEmbarqField = value;
                    OnPropertyChanged("UFEmbarq");
                }
            }
        }

        public string xLocEmbarq
        {
            get
            {
                return xLocEmbarqField;
            }

            set
            {
                if (xLocEmbarqField is null || xLocEmbarqField.Equals(value) != true)
                {
                    xLocEmbarqField = value;
                    OnPropertyChanged("xLocEmbarq");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Compra : INotifyPropertyChanged
    {
        private string xNEmpField;
        private string xPedField;
        private string xContField;

        public string xNEmp
        {
            get
            {
                return xNEmpField;
            }

            set
            {
                if (xNEmpField is null || xNEmpField.Equals(value) != true)
                {
                    xNEmpField = value;
                    OnPropertyChanged("xNEmp");
                }
            }
        }

        public string xPed
        {
            get
            {
                return xPedField;
            }

            set
            {
                if (xPedField is null || xPedField.Equals(value) != true)
                {
                    xPedField = value;
                    OnPropertyChanged("xPed");
                }
            }
        }

        public string xCont
        {
            get
            {
                return xContField;
            }

            set
            {
                if (xContField is null || xContField.Equals(value) != true)
                {
                    xContField = value;
                    OnPropertyChanged("xCont");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Cana : INotifyPropertyChanged
    {
        private string safraField;
        private string refField;
        private List<CanaDiario> forDiaField;
        private string qTotMesField;
        private string qTotAntField;
        private string qTotGerField;
        private List<CanaDeducao> deducField;
        private string vForField;
        private string vTotDedField;
        private string vLiqForField;

        public Cana() : base()
        {
            deducField = new List<CanaDeducao>();
            forDiaField = new List<CanaDiario>();
        }

        public string safra
        {
            get
            {
                return safraField;
            }

            set
            {
                if (safraField is null || safraField.Equals(value) != true)
                {
                    safraField = value;
                    OnPropertyChanged("safra");
                }
            }
        }

        public string @ref
        {
            get
            {
                return refField;
            }

            set
            {
                if (refField is null || refField.Equals(value) != true)
                {
                    refField = value;
                    OnPropertyChanged("ref");
                }
            }
        }

        [XmlElement("forDia")]
        public List<CanaDiario> forDia
        {
            get
            {
                return forDiaField;
            }

            set
            {
                if (forDiaField is null || forDiaField.Equals(value) != true)
                {
                    forDiaField = value;
                    OnPropertyChanged("forDia");
                }
            }
        }

        public string qTotMes
        {
            get
            {
                return qTotMesField;
            }

            set
            {
                if (qTotMesField is null || qTotMesField.Equals(value) != true)
                {
                    qTotMesField = value;
                    OnPropertyChanged("qTotMes");
                }
            }
        }

        public string qTotAnt
        {
            get
            {
                return qTotAntField;
            }

            set
            {
                if (qTotAntField is null || qTotAntField.Equals(value) != true)
                {
                    qTotAntField = value;
                    OnPropertyChanged("qTotAnt");
                }
            }
        }

        public string qTotGer
        {
            get
            {
                return qTotGerField;
            }

            set
            {
                if (qTotGerField is null || qTotGerField.Equals(value) != true)
                {
                    qTotGerField = value;
                    OnPropertyChanged("qTotGer");
                }
            }
        }

        [XmlElement("deduc")]
        public List<CanaDeducao> deduc
        {
            get
            {
                return deducField;
            }

            set
            {
                if (deducField is null || deducField.Equals(value) != true)
                {
                    deducField = value;
                    OnPropertyChanged("deduc");
                }
            }
        }

        public string vFor
        {
            get
            {
                return vForField;
            }

            set
            {
                if (vForField is null || vForField.Equals(value) != true)
                {
                    vForField = value;
                    OnPropertyChanged("vFor");
                }
            }
        }

        public string vTotDed
        {
            get
            {
                return vTotDedField;
            }

            set
            {
                if (vTotDedField is null || vTotDedField.Equals(value) != true)
                {
                    vTotDedField = value;
                    OnPropertyChanged("vTotDed");
                }
            }
        }

        public string vLiqFor
        {
            get
            {
                return vLiqForField;
            }

            set
            {
                if (vLiqForField is null || vLiqForField.Equals(value) != true)
                {
                    vLiqForField = value;
                    OnPropertyChanged("vLiqFor");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class CanaDiario : INotifyPropertyChanged
    {
        private string qtdeField;
        private string diaField;

        public string qtde
        {
            get
            {
                return qtdeField;
            }

            set
            {
                if (qtdeField is null || qtdeField.Equals(value) != true)
                {
                    qtdeField = value;
                    OnPropertyChanged("qtde");
                }
            }
        }

        [XmlAttribute()]
        public string dia
        {
            get
            {
                return diaField;
            }

            set
            {
                if (diaField is null || diaField.Equals(value) != true)
                {
                    diaField = value;
                    OnPropertyChanged("dia");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class CanaDeducao : INotifyPropertyChanged
    {
        private string xDedField;
        private string vDedField;

        public string xDed
        {
            get
            {
                return xDedField;
            }

            set
            {
                if (xDedField is null || xDedField.Equals(value) != true)
                {
                    xDedField = value;
                    OnPropertyChanged("xDed");
                }
            }
        }

        public string vDed
        {
            get
            {
                return vDedField;
            }

            set
            {
                if (vDedField is null || vDedField.Equals(value) != true)
                {
                    vDedField = value;
                    OnPropertyChanged("vDed");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <summary>
    /// NF-e 4.00
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Pagamento : INotifyPropertyChanged
    {
        private List<DetalhamentoPagamento> detPagField;

        public Pagamento() : base()
        {
            detPagField = new List<DetalhamentoPagamento>();
            // Me.fatField = New TNFeInfNFeCobrFat()
        }

        [XmlElement("detPag")]
        public List<DetalhamentoPagamento> DetalhamentoPagamentos
        {
            get
            {
                return detPagField;
            }

            set
            {
                if (detPagField is null || detPagField.Equals(value) != true)
                {
                    detPagField = value;
                    OnPropertyChanged("detPag");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DetalhamentoPagamento : INotifyPropertyChanged
    {
        private FormaDePagamento? indPagField; // = FormaDePagamento.Vista
        private FormaPagamento tPagField = FormaPagamento.SemPagto;
        private double? vPagField;
        private double? vTrocoField;
        private DetalhamentoPagamentoCartao card;

        public FormaDePagamento? indPag
        {
            get
            {
                return indPagField;
            }

            set
            {
                if (indPagField.Equals(value) != true)
                {
                    indPagField = value;
                    OnPropertyChanged("indPag");
                }
            }
        }

        public bool ShouldSerializeindPag()
        {
            return indPag.HasValue;
        }

        public FormaPagamento tPag
        {
            get
            {
                return tPagField;
            }

            set
            {
                if (tPagField.Equals(value) != true)
                {
                    tPagField = value;
                    OnPropertyChanged("tPag");
                }
            }
        }

        public double? vPag
        {
            get
            {
                return vPagField;
            }

            set
            {
                if (vPagField is null || vPagField.Equals(value) != true)
                {
                    vPagField = value;
                    OnPropertyChanged("vPag");
                }
            }
        }

        public bool ShouldSerializevPag()
        {
            return vPagField.HasValue;
        }

        [XmlElement("card")]
        public DetalhamentoPagamentoCartao DetalhamentoCartao
        {
            get
            {
                return card;
            }

            set
            {
                if (card is null || card.Equals(value) != true)
                {
                    card = value;
                    OnPropertyChanged("DetalhamentoCartao");
                }
            }
        }

        public double? vTroco
        {
            get
            {
                return vTrocoField;
            }

            set
            {
                if (vTrocoField is null || vTrocoField.Equals(value) != true)
                {
                    vTrocoField = value;
                    OnPropertyChanged("vTroco");
                }
            }
        }

        public bool ShouldSerializevTroco()
        {
            return vTrocoField.HasValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return string.Format("Indicador {0}, Forma: {1}, valor: {2:c2}", indPag, tPag, vPag);
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DetalhamentoPagamentoCartao : INotifyPropertyChanged
    {
        private TipoIntegracaoPgCartao tpIntegraField = TipoIntegracaoPgCartao.TEF_eCommerce;
        private string cnpjField;
        private BandeiraCartaoCredito tBandField = BandeiraCartaoCredito.Outros;
        private string cAutField;

        public TipoIntegracaoPgCartao tpIntegra
        {
            get
            {
                return tpIntegraField;
            }

            set
            {
                if (tpIntegraField.Equals(value) != true)
                {
                    tpIntegraField = value;
                    OnPropertyChanged("tpIntegra");
                }
            }
        }

        public string CNPJ
        {
            get
            {
                return cnpjField;
            }

            set
            {
                if (cnpjField is null || cnpjField.Equals(value) != true)
                {
                    cnpjField = value;
                    OnPropertyChanged("CNPJ");
                }
            }
        }

        public BandeiraCartaoCredito tBand
        {
            get
            {
                return tBandField;
            }

            set
            {
                if (tBandField.Equals(value) != true)
                {
                    tBandField = value;
                    OnPropertyChanged("tBand");
                }
            }
        }

        public string cAut
        {
            get
            {
                return cAutField;
            }

            set
            {
                if (cAutField is null || cAutField.Equals(value) != true)
                {
                    cAutField = value;
                    OnPropertyChanged("cAut");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureType : INotifyPropertyChanged
    {
        private SignedInfoType signedInfoField;
        private SignatureValueType signatureValueField;
        private KeyInfoType keyInfoField;
        private string idField;

        public SignatureType() : base()
        {
            keyInfoField = new KeyInfoType();
            signatureValueField = new SignatureValueType();
            signedInfoField = new SignedInfoType();
        }

        public SignedInfoType SignedInfo
        {
            get
            {
                return signedInfoField;
            }

            set
            {
                if (signedInfoField is null || signedInfoField.Equals(value) != true)
                {
                    signedInfoField = value;
                    OnPropertyChanged("SignedInfo");
                }
            }
        }

        public SignatureValueType SignatureValue
        {
            get
            {
                return signatureValueField;
            }

            set
            {
                if (signatureValueField is null || signatureValueField.Equals(value) != true)
                {
                    signatureValueField = value;
                    OnPropertyChanged("SignatureValue");
                }
            }
        }

        public KeyInfoType KeyInfo
        {
            get
            {
                return keyInfoField;
            }

            set
            {
                if (keyInfoField is null || keyInfoField.Equals(value) != true)
                {
                    keyInfoField = value;
                    OnPropertyChanged("KeyInfo");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignedInfoType : INotifyPropertyChanged
    {
        private SignedInfoTypeCanonicalizationMethod canonicalizationMethodField;
        private SignedInfoTypeSignatureMethod signatureMethodField;
        private ReferenceType referenceField;
        private string idField;

        public SignedInfoType() : base()
        {
            referenceField = new ReferenceType();
            signatureMethodField = new SignedInfoTypeSignatureMethod();
            canonicalizationMethodField = new SignedInfoTypeCanonicalizationMethod();
        }

        public SignedInfoTypeCanonicalizationMethod CanonicalizationMethod
        {
            get
            {
                return canonicalizationMethodField;
            }

            set
            {
                if (canonicalizationMethodField is null || canonicalizationMethodField.Equals(value) != true)
                {
                    canonicalizationMethodField = value;
                    OnPropertyChanged("CanonicalizationMethod");
                }
            }
        }

        public SignedInfoTypeSignatureMethod SignatureMethod
        {
            get
            {
                return signatureMethodField;
            }

            set
            {
                if (signatureMethodField is null || signatureMethodField.Equals(value) != true)
                {
                    signatureMethodField = value;
                    OnPropertyChanged("SignatureMethod");
                }
            }
        }

        public ReferenceType Reference
        {
            get
            {
                return referenceField;
            }

            set
            {
                if (referenceField is null || referenceField.Equals(value) != true)
                {
                    referenceField = value;
                    OnPropertyChanged("Reference");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignedInfoTypeCanonicalizationMethod : INotifyPropertyChanged
    {
        private string algorithmField;

        public SignedInfoTypeCanonicalizationMethod() : base()
        {
            algorithmField = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }

            set
            {
                if (algorithmField is null || algorithmField.Equals(value) != true)
                {
                    algorithmField = value;
                    OnPropertyChanged("Algorithm");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignedInfoTypeSignatureMethod : INotifyPropertyChanged
    {
        private string algorithmField;

        public SignedInfoTypeSignatureMethod() : base()
        {
            algorithmField = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }

            set
            {
                if (algorithmField is null || algorithmField.Equals(value) != true)
                {
                    algorithmField = value;
                    OnPropertyChanged("Algorithm");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class ReferenceType : INotifyPropertyChanged
    {
        private List<TransformType> transformsField;
        private ReferenceTypeDigestMethod digestMethodField;
        private byte[] digestValueField;
        private string idField;
        private string uRIField;
        private string typeField;

        public ReferenceType() : base()
        {
            digestMethodField = new ReferenceTypeDigestMethod();
            transformsField = new List<TransformType>();
        }

        [XmlArrayItem("Transform", IsNullable = false)]
        public List<TransformType> Transforms
        {
            get
            {
                return transformsField;
            }

            set
            {
                if (transformsField is null || transformsField.Equals(value) != true)
                {
                    transformsField = value;
                    OnPropertyChanged("Transforms");
                }
            }
        }

        public ReferenceTypeDigestMethod DigestMethod
        {
            get
            {
                return digestMethodField;
            }

            set
            {
                if (digestMethodField is null || digestMethodField.Equals(value) != true)
                {
                    digestMethodField = value;
                    OnPropertyChanged("DigestMethod");
                }
            }
        }

        [XmlElement(DataType = "base64Binary")]
        public byte[] DigestValue
        {
            get
            {
                return digestValueField;
            }

            set
            {
                if (digestValueField is null || digestValueField.Equals(value) != true)
                {
                    digestValueField = value;
                    OnPropertyChanged("DigestValue");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        [XmlAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return uRIField;
            }

            set
            {
                if (uRIField is null || uRIField.Equals(value) != true)
                {
                    uRIField = value;
                    OnPropertyChanged("URI");
                }
            }
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Type
        {
            get
            {
                return typeField;
            }

            set
            {
                if (typeField is null || typeField.Equals(value) != true)
                {
                    typeField = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class TransformType : INotifyPropertyChanged
    {
        private List<string> xPathField;
        private TTransformURI algorithmField;

        public TransformType() : base()
        {
            xPathField = new List<string>();
        }

        [XmlElement("XPath")]
        public List<string> XPath
        {
            get
            {
                return xPathField;
            }

            set
            {
                if (xPathField is null || xPathField.Equals(value) != true)
                {
                    xPathField = value;
                    OnPropertyChanged("XPath");
                }
            }
        }

        [XmlAttribute()]
        public TTransformURI Algorithm
        {
            get
            {
                return algorithmField;
            }

            set
            {
                if (algorithmField.Equals(value) != true)
                {
                    algorithmField = value;
                    OnPropertyChanged("Algorithm");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public enum TTransformURI
    {

        /// <remarks/>
        [XmlEnum("http://www.w3.org/2000/09/xmldsig#enveloped-signature")]
        httpwwww3org200009xmldsigenvelopedsignature,

        /// <remarks/>
        [XmlEnum("http://www.w3.org/TR/2001/REC-xml-c14n-20010315")]
        httpwwww3orgTR2001RECxmlc14n20010315
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class ReferenceTypeDigestMethod : INotifyPropertyChanged
    {
        private string algorithmField;

        public ReferenceTypeDigestMethod() : base()
        {
            algorithmField = "http://www.w3.org/2000/09/xmldsig#sha1";
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }

            set
            {
                if (algorithmField is null || algorithmField.Equals(value) != true)
                {
                    algorithmField = value;
                    OnPropertyChanged("Algorithm");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureValueType : INotifyPropertyChanged
    {
        private string idField;
        private byte[] valueField;

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        [XmlText(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return valueField;
            }

            set
            {
                if (valueField is null || valueField.Equals(value) != true)
                {
                    valueField = value;
                    OnPropertyChanged("Value");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class KeyInfoType : INotifyPropertyChanged
    {
        private X509DataType x509DataField;
        private string idField;

        public KeyInfoType() : base()
        {
            x509DataField = new X509DataType();
        }

        public X509DataType X509Data
        {
            get
            {
                return x509DataField;
            }

            set
            {
                if (x509DataField is null || x509DataField.Equals(value) != true)
                {
                    x509DataField = value;
                    OnPropertyChanged("X509Data");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class X509DataType : INotifyPropertyChanged
    {
        private byte[] x509CertificateField;

        [XmlElement(DataType = "base64Binary")]
        public byte[] X509Certificate
        {
            get
            {
                return x509CertificateField;
            }

            set
            {
                if (x509CertificateField is null || x509CertificateField.Equals(value) != true)
                {
                    x509CertificateField = value;
                    OnPropertyChanged("X509Certificate");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}