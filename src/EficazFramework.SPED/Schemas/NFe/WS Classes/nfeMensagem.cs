using System;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Schemas.NFe
{
    public interface ICabecalhoMensagem
    {
        string Serialize();
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    public class CabecalhoMensagem : object, System.ComponentModel.INotifyPropertyChanged, ICabecalhoMensagem
    {
        private string cUFField;
        private string versaoDadosField;
        private string _rootNamespace;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string cUF
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
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string versaoDados
        {
            get
            {
                return versaoDadosField;
            }

            set
            {
                versaoDadosField = value;
                RaisePropertyChanged("versaoDados");
            }
        }

        [System.Xml.Serialization.XmlIgnore()]
        public string RootNamespace
        {
            get
            {
                return _rootNamespace;
            }

            set
            {
                _rootNamespace = value;
                sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(CabecalhoMensagem), new System.Xml.Serialization.XmlRootAttribute("nfeCabecMsg") { Namespace = RootNamespace });
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
        private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(CabecalhoMensagem));

        /// <summary>
        /// Serializes current TNfeProc object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                var ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                // If cUF = "41" Then ns.Add("tns", Me.RootNamespace) Else ns.Add("", Me.RootNamespace)
                ns.Add("", RootNamespace);
                sSerializer.Serialize(memoryStream, this, ns);
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
        public static bool CanDeserialize(string xml, ref CabecalhoMensagem obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref CabecalhoMensagem obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static CabecalhoMensagem Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (CabecalhoMensagem)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CabecalhoMensagem Deserialize(System.IO.Stream s)
        {
            return (CabecalhoMensagem)sSerializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref CabecalhoMensagem obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref CabecalhoMensagem obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static CabecalhoMensagem LoadFrom(System.IO.Stream source)
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

        public static async Task<CabecalhoMensagem> LoadFromAsync(System.IO.Stream source)
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


    // ## Non-Generic

    // <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18033"),
    // System.SerializableAttribute(),
    // System.ComponentModel.DesignerCategoryAttribute("code"),
    // System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsulta2"),
    // System.Xml.Serialization.XmlRootAttribute("nfeCabecMsg", [Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsulta2")>
    // Public Class CabecalhoMensagem_NfeConsulta
    // Inherits Object
    // Implements System.ComponentModel.INotifyPropertyChanged
    // Implements ICabecalhoMensagem

    // Private cUFField As String
    // Private versaoDadosField As String

    // '''<remarks/>
    // <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
    // Public Property cUF() As String
    // Get
    // Return Me.cUFField
    // End Get
    // Set(value As String)
    // Me.cUFField = value
    // Me.RaisePropertyChanged("cUF")
    // End Set
    // End Property

    // '''<remarks/>
    // <System.Xml.Serialization.XmlElementAttribute(Order:=1)>
    // Public Property versaoDados() As String
    // Get
    // Return Me.versaoDadosField
    // End Get
    // Set(value As String)
    // Me.versaoDadosField = value
    // Me.RaisePropertyChanged("versaoDados")
    // End Set
    // End Property

    // Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    // Protected Sub RaisePropertyChanged(ByVal propertyName As String)
    // Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
    // If (Not (propertyChanged) Is Nothing) Then
    // propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
    // End If
    // End Sub

    // #Region "Serialize/Deserialize"
    // Private Shared sSerializer As New System.Xml.Serialization.XmlSerializer(GetType(CabecalhoMensagem_NfeConsulta))

    // '''<summary>
    // '''Serializes current TNfeProc object into an XML document
    // '''</summary>
    // '''<returns>string XML value</returns>
    // Public Function Serialize() As String Implements ICabecalhoMensagem.Serialize
    // Dim streamReader As System.IO.StreamReader = Nothing
    // Dim memoryStream As System.IO.MemoryStream = Nothing
    // Try
    // memoryStream = New System.IO.MemoryStream()
    // sSerializer.Serialize(memoryStream, Me)
    // memoryStream.Seek(0, System.IO.SeekOrigin.Begin)
    // streamReader = New System.IO.StreamReader(memoryStream)
    // Return streamReader.ReadToEnd
    // Finally
    // If (Not (streamReader) Is Nothing) Then
    // streamReader.Dispose()
    // End If
    // If (Not (memoryStream) Is Nothing) Then
    // memoryStream.Dispose()
    // End If
    // End Try
    // End Function

    // '''<summary>
    // '''Deserializes workflow markup into an TNfeProc object
    // '''</summary>
    // '''<param name="xml">string workflow markup to deserialize</param>
    // '''<param name="obj">Output TNfeProc object</param>
    // '''<param name="exception">output Exception value if deserialize failed</param>
    // '''<returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    // Public Overloads Shared Function CanDeserialize(ByVal xml As String, ByRef obj As CabecalhoMensagem_NfeConsulta, ByRef exception As System.Exception) As Boolean
    // exception = Nothing
    // obj = CType(Nothing, CabecalhoMensagem_NfeConsulta)
    // Try
    // obj = Deserialize(xml)
    // Return True
    // Catch ex As System.Exception
    // exception = ex
    // Return False
    // End Try
    // End Function

    // Public Overloads Shared Function CanDeserialize(ByVal xml As String, ByRef obj As CabecalhoMensagem_NfeConsulta) As Boolean
    // Dim exception As System.Exception = Nothing
    // Return CanDeserialize(xml, obj, exception)
    // End Function

    // Public Overloads Shared Function Deserialize(ByVal xml As String) As CabecalhoMensagem_NfeConsulta
    // Dim stringReader As System.IO.StringReader = Nothing
    // Try
    // stringReader = New System.IO.StringReader(xml)
    // 'stringReader.ReadToEnd() 'TESTING...
    // Return CType(sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader)), CabecalhoMensagem_NfeConsulta)
    // 'Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
    // Finally
    // If (Not (stringReader) Is Nothing) Then
    // stringReader.Dispose()
    // End If
    // End Try
    // End Function

    // Public Overloads Shared Function Deserialize(ByVal s As System.IO.Stream) As CabecalhoMensagem_NfeConsulta
    // Return CType(sSerializer.Deserialize(s), CabecalhoMensagem_NfeConsulta)
    // End Function


    // '''<summary>
    // '''Serializes current TNfeProc object into file
    // '''</summary>
    // '''<param name="target">target stream of outupt xml file</param>
    // '''<param name="exception">output Exception value if failed</param>
    // '''<returns>true if can serialize and save into file; otherwise, false</returns>
    // Public Overridable Overloads Function CanSaveToFile(ByVal target As IO.Stream, ByRef exception As System.Exception) As Boolean
    // exception = Nothing
    // Try
    // SaveTo(target)
    // Return True
    // Catch e As System.Exception
    // exception = e
    // Return False
    // End Try
    // End Function

    // Public Overridable Overloads Sub SaveTo(ByVal target As IO.Stream)
    // If target Is Nothing Then Throw New ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage)
    // Dim streamWriter As New System.IO.StreamWriter(target)
    // Try
    // Dim xmlString As String = Serialize()
    // 'Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
    // 'streamWriter = xmlFile.CreateText
    // streamWriter.WriteLine(xmlString)
    // streamWriter.Flush()
    // Finally
    // If (Not (streamWriter) Is Nothing) Then
    // streamWriter.Dispose()
    // End If
    // End Try
    // End Sub

    // Public Overridable Overloads Async Sub SaveToAsync(ByVal target As IO.Stream)
    // If target Is Nothing Then Throw New ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage)
    // Dim streamWriter As New System.IO.StreamWriter(target)
    // Try
    // Dim xmlString As String = Serialize()
    // Await streamWriter.WriteLineAsync(xmlString)
    // Await streamWriter.FlushAsync
    // Finally
    // If (Not (streamWriter) Is Nothing) Then
    // streamWriter.Dispose()
    // End If
    // End Try
    // End Sub


    // '''<summary>
    // '''Deserializes xml markup from file into an TNfeProc object
    // '''</summary>
    // '''<param name="source">target stream of outupt xml file</param>
    // '''<param name="obj">Output TNfeProc object</param>
    // '''<param name="exception">output Exception value if deserialize failed</param>
    // '''<returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    // Public Overloads Shared Function CanLoadFrom(ByVal source As IO.Stream, ByRef obj As CabecalhoMensagem_NfeConsulta, ByRef exception As System.Exception) As Boolean
    // exception = Nothing
    // obj = CType(Nothing, CabecalhoMensagem_NfeConsulta)
    // Try
    // obj = LoadFrom(source)
    // Return True
    // Catch ex As System.Exception
    // exception = ex
    // Return False
    // End Try
    // End Function

    // Public Overloads Shared Function CanLoadFrom(ByVal source As IO.Stream, ByRef obj As CabecalhoMensagem_NfeConsulta) As Boolean
    // Dim exception As System.Exception = Nothing
    // Return CanLoadFrom(source, obj, exception)
    // End Function

    // Public Overloads Shared Function LoadFrom(ByVal source As IO.Stream) As CabecalhoMensagem_NfeConsulta
    // If source Is Nothing Then Throw New ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage)
    // Dim sr As System.IO.StreamReader = Nothing
    // Try
    // 'file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
    // sr = New System.IO.StreamReader(source)
    // Dim xmlString As String = sr.ReadToEnd
    // 'sr.Close()
    // 'file.Close()
    // Return Deserialize(xmlString)
    // Finally
    // If (Not (source) Is Nothing) Then
    // source.Dispose()
    // End If
    // If (Not (sr) Is Nothing) Then
    // sr.Dispose()
    // End If
    // End Try
    // End Function

    // Public Overloads Shared Async Function LoadFromAsync(ByVal source As IO.Stream) As Task(Of CabecalhoMensagem_NfeConsulta)
    // If source Is Nothing Then Throw New ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage)
    // Dim sr As System.IO.StreamReader = Nothing
    // Try
    // 'file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
    // sr = New System.IO.StreamReader(source)
    // Dim xmlString As String = Await sr.ReadToEndAsync
    // 'sr.Close()
    // 'file.Close()
    // Return Deserialize(xmlString)
    // Finally
    // If (Not (source) Is Nothing) Then
    // source.Dispose()
    // End If
    // If (Not (sr) Is Nothing) Then
    // sr.Dispose()
    // End If
    // End Try
    // End Function

    // #End Region

    // End Class

    // <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18033"),
    // System.SerializableAttribute(),
    // System.ComponentModel.DesignerCategoryAttribute("code"),
    // System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro2"),
    // System.Xml.Serialization.XmlRootAttribute("nfeCabecMsg", [Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/CadConsultaCadastro2")>
    // Public Class CabecalhoMensagem_ConsultaCadastro
    // Inherits Object
    // Implements System.ComponentModel.INotifyPropertyChanged
    // Implements ICabecalhoMensagem

    // Private cUFField As String
    // Private versaoDadosField As String

    // '''<remarks/>
    // <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
    // Public Property cUF() As String
    // Get
    // Return Me.cUFField
    // End Get
    // Set(value As String)
    // Me.cUFField = value
    // Me.RaisePropertyChanged("cUF")
    // End Set
    // End Property

    // '''<remarks/>
    // <System.Xml.Serialization.XmlElementAttribute(Order:=1)>
    // Public Property versaoDados() As String
    // Get
    // Return Me.versaoDadosField
    // End Get
    // Set(value As String)
    // Me.versaoDadosField = value
    // Me.RaisePropertyChanged("versaoDados")
    // End Set
    // End Property

    // Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    // Protected Sub RaisePropertyChanged(ByVal propertyName As String)
    // Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
    // If (Not (propertyChanged) Is Nothing) Then
    // propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
    // End If
    // End Sub

    // #Region "Serialize/Deserialize"
    // Private Shared sSerializer As New System.Xml.Serialization.XmlSerializer(GetType(CabecalhoMensagem_ConsultaCadastro))

    // '''<summary>
    // '''Serializes current TNfeProc object into an XML document
    // '''</summary>
    // '''<returns>string XML value</returns>
    // Public Function Serialize() As String Implements ICabecalhoMensagem.Serialize
    // Dim streamReader As System.IO.StreamReader = Nothing
    // Dim memoryStream As System.IO.MemoryStream = Nothing
    // Try
    // memoryStream = New System.IO.MemoryStream()
    // sSerializer.Serialize(memoryStream, Me)
    // memoryStream.Seek(0, System.IO.SeekOrigin.Begin)
    // streamReader = New System.IO.StreamReader(memoryStream)
    // Return streamReader.ReadToEnd
    // Finally
    // If (Not (streamReader) Is Nothing) Then
    // streamReader.Dispose()
    // End If
    // If (Not (memoryStream) Is Nothing) Then
    // memoryStream.Dispose()
    // End If
    // End Try
    // End Function

    // '''<summary>
    // '''Deserializes workflow markup into an TNfeProc object
    // '''</summary>
    // '''<param name="xml">string workflow markup to deserialize</param>
    // '''<param name="obj">Output TNfeProc object</param>
    // '''<param name="exception">output Exception value if deserialize failed</param>
    // '''<returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    // Public Overloads Shared Function CanDeserialize(ByVal xml As String, ByRef obj As CabecalhoMensagem_ConsultaCadastro, ByRef exception As System.Exception) As Boolean
    // exception = Nothing
    // obj = CType(Nothing, CabecalhoMensagem_ConsultaCadastro)
    // Try
    // obj = Deserialize(xml)
    // Return True
    // Catch ex As System.Exception
    // exception = ex
    // Return False
    // End Try
    // End Function

    // Public Overloads Shared Function CanDeserialize(ByVal xml As String, ByRef obj As CabecalhoMensagem_ConsultaCadastro) As Boolean
    // Dim exception As System.Exception = Nothing
    // Return CanDeserialize(xml, obj, exception)
    // End Function

    // Public Overloads Shared Function Deserialize(ByVal xml As String) As CabecalhoMensagem_ConsultaCadastro
    // Dim stringReader As System.IO.StringReader = Nothing
    // Try
    // stringReader = New System.IO.StringReader(xml)
    // 'stringReader.ReadToEnd() 'TESTING...
    // Return CType(sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader)), CabecalhoMensagem_ConsultaCadastro)
    // 'Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
    // Finally
    // If (Not (stringReader) Is Nothing) Then
    // stringReader.Dispose()
    // End If
    // End Try
    // End Function

    // Public Overloads Shared Function Deserialize(ByVal s As System.IO.Stream) As CabecalhoMensagem_ConsultaCadastro
    // Return CType(sSerializer.Deserialize(s), CabecalhoMensagem_ConsultaCadastro)
    // End Function


    // '''<summary>
    // '''Serializes current TNfeProc object into file
    // '''</summary>
    // '''<param name="target">target stream of outupt xml file</param>
    // '''<param name="exception">output Exception value if failed</param>
    // '''<returns>true if can serialize and save into file; otherwise, false</returns>
    // Public Overridable Overloads Function CanSaveToFile(ByVal target As IO.Stream, ByRef exception As System.Exception) As Boolean
    // exception = Nothing
    // Try
    // SaveTo(target)
    // Return True
    // Catch e As System.Exception
    // exception = e
    // Return False
    // End Try
    // End Function

    // Public Overridable Overloads Sub SaveTo(ByVal target As IO.Stream)
    // If target Is Nothing Then Throw New ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage)
    // Dim streamWriter As New System.IO.StreamWriter(target)
    // Try
    // Dim xmlString As String = Serialize()
    // 'Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
    // 'streamWriter = xmlFile.CreateText
    // streamWriter.WriteLine(xmlString)
    // streamWriter.Flush()
    // Finally
    // If (Not (streamWriter) Is Nothing) Then
    // streamWriter.Dispose()
    // End If
    // End Try
    // End Sub

    // Public Overridable Overloads Async Sub SaveToAsync(ByVal target As IO.Stream)
    // If target Is Nothing Then Throw New ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage)
    // Dim streamWriter As New System.IO.StreamWriter(target)
    // Try
    // Dim xmlString As String = Serialize()
    // Await streamWriter.WriteLineAsync(xmlString)
    // Await streamWriter.FlushAsync
    // Finally
    // If (Not (streamWriter) Is Nothing) Then
    // streamWriter.Dispose()
    // End If
    // End Try
    // End Sub


    // '''<summary>
    // '''Deserializes xml markup from file into an TNfeProc object
    // '''</summary>
    // '''<param name="source">target stream of outupt xml file</param>
    // '''<param name="obj">Output TNfeProc object</param>
    // '''<param name="exception">output Exception value if deserialize failed</param>
    // '''<returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    // Public Overloads Shared Function CanLoadFrom(ByVal source As IO.Stream, ByRef obj As CabecalhoMensagem_ConsultaCadastro, ByRef exception As System.Exception) As Boolean
    // exception = Nothing
    // obj = CType(Nothing, CabecalhoMensagem_ConsultaCadastro)
    // Try
    // obj = LoadFrom(source)
    // Return True
    // Catch ex As System.Exception
    // exception = ex
    // Return False
    // End Try
    // End Function

    // Public Overloads Shared Function CanLoadFrom(ByVal source As IO.Stream, ByRef obj As CabecalhoMensagem_ConsultaCadastro) As Boolean
    // Dim exception As System.Exception = Nothing
    // Return CanLoadFrom(source, obj, exception)
    // End Function

    // Public Overloads Shared Function LoadFrom(ByVal source As IO.Stream) As CabecalhoMensagem_ConsultaCadastro
    // If source Is Nothing Then Throw New ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage)
    // Dim sr As System.IO.StreamReader = Nothing
    // Try
    // 'file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
    // sr = New System.IO.StreamReader(source)
    // Dim xmlString As String = sr.ReadToEnd
    // 'sr.Close()
    // 'file.Close()
    // Return Deserialize(xmlString)
    // Finally
    // If (Not (source) Is Nothing) Then
    // source.Dispose()
    // End If
    // If (Not (sr) Is Nothing) Then
    // sr.Dispose()
    // End If
    // End Try
    // End Function

    // Public Overloads Shared Async Function LoadFromAsync(ByVal source As IO.Stream) As Task(Of CabecalhoMensagem_ConsultaCadastro)
    // If source Is Nothing Then Throw New ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage)
    // Dim sr As System.IO.StreamReader = Nothing
    // Try
    // 'file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
    // sr = New System.IO.StreamReader(source)
    // Dim xmlString As String = Await sr.ReadToEndAsync
    // 'sr.Close()
    // 'file.Close()
    // Return Deserialize(xmlString)
    // Finally
    // If (Not (source) Is Nothing) Then
    // source.Dispose()
    // End If
    // If (Not (sr) Is Nothing) Then
    // sr.Dispose()
    // End If
    // End Try
    // End Function

    // #End Region

    // End Class

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/RecepcaoEvento")]
    [System.Xml.Serialization.XmlRoot("nfeCabecMsg", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/RecepcaoEvento")]
    public class CabecalhoMensagem_RecepcaoEvento : object, System.ComponentModel.INotifyPropertyChanged, ICabecalhoMensagem
    {
        private string cUFField;
        private string versaoDadosField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string cUF
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
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string versaoDados
        {
            get
            {
                return versaoDadosField;
            }

            set
            {
                versaoDadosField = value;
                RaisePropertyChanged("versaoDados");
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
        private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(CabecalhoMensagem_RecepcaoEvento));

        /// <summary>
        /// Serializes current TNfeProc object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                sSerializer.Serialize(memoryStream, this);
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
        public static bool CanDeserialize(string xml, ref CabecalhoMensagem_RecepcaoEvento obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref CabecalhoMensagem_RecepcaoEvento obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static CabecalhoMensagem_RecepcaoEvento Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (CabecalhoMensagem_RecepcaoEvento)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CabecalhoMensagem_RecepcaoEvento Deserialize(System.IO.Stream s)
        {
            return (CabecalhoMensagem_RecepcaoEvento)sSerializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref CabecalhoMensagem_RecepcaoEvento obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref CabecalhoMensagem_RecepcaoEvento obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static CabecalhoMensagem_RecepcaoEvento LoadFrom(System.IO.Stream source)
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

        public static async Task<CabecalhoMensagem_RecepcaoEvento> LoadFromAsync(System.IO.Stream source)
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
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsultaDest")]
    [System.Xml.Serialization.XmlRoot("nfeCabecMsg", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeConsultaDest")]
    public class CabecalhoMensagem_ConsultaDestinatario : object, System.ComponentModel.INotifyPropertyChanged, ICabecalhoMensagem
    {
        private string cUFField;
        private string versaoDadosField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string cUF
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
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string versaoDados
        {
            get
            {
                return versaoDadosField;
            }

            set
            {
                versaoDadosField = value;
                RaisePropertyChanged("versaoDados");
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
        private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(CabecalhoMensagem_ConsultaDestinatario));

        /// <summary>
        /// Serializes current TNfeProc object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                sSerializer.Serialize(memoryStream, this);
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
        public static bool CanDeserialize(string xml, ref CabecalhoMensagem_ConsultaDestinatario obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref CabecalhoMensagem_ConsultaDestinatario obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static CabecalhoMensagem_ConsultaDestinatario Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (CabecalhoMensagem_ConsultaDestinatario)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CabecalhoMensagem_ConsultaDestinatario Deserialize(System.IO.Stream s)
        {
            return (CabecalhoMensagem_ConsultaDestinatario)sSerializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref CabecalhoMensagem_ConsultaDestinatario obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref CabecalhoMensagem_ConsultaDestinatario obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static CabecalhoMensagem_ConsultaDestinatario LoadFrom(System.IO.Stream source)
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

        public static async Task<CabecalhoMensagem_ConsultaDestinatario> LoadFromAsync(System.IO.Stream source)
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
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeDownloadNF")]
    [System.Xml.Serialization.XmlRoot("nfeCabecMsg", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeDownloadNF")]
    public class CabecalhoMensagem_DownloadNF : object, System.ComponentModel.INotifyPropertyChanged, ICabecalhoMensagem
    {
        private string cUFField;
        private string versaoDadosField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string cUF
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
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string versaoDados
        {
            get
            {
                return versaoDadosField;
            }

            set
            {
                versaoDadosField = value;
                RaisePropertyChanged("versaoDados");
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
        private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(CabecalhoMensagem_DownloadNF));

        /// <summary>
        /// Serializes current TNfeProc object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                sSerializer.Serialize(memoryStream, this);
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
        public static bool CanDeserialize(string xml, ref CabecalhoMensagem_DownloadNF obj, ref Exception exception)
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

        public static bool CanDeserialize(string xml, ref CabecalhoMensagem_DownloadNF obj)
        {
            Exception exception = null;
            return CanDeserialize(xml, ref obj, ref exception);
        }

        public static CabecalhoMensagem_DownloadNF Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                // stringReader.ReadToEnd() 'TESTING...
                return (CabecalhoMensagem_DownloadNF)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
            }
            // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CabecalhoMensagem_DownloadNF Deserialize(System.IO.Stream s)
        {
            return (CabecalhoMensagem_DownloadNF)sSerializer.Deserialize(s);
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
        public static bool CanLoadFrom(System.IO.Stream source, ref CabecalhoMensagem_DownloadNF obj, ref Exception exception)
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

        public static bool CanLoadFrom(System.IO.Stream source, ref CabecalhoMensagem_DownloadNF obj)
        {
            Exception exception = null;
            return CanLoadFrom(source, ref obj, ref exception);
        }

        public static CabecalhoMensagem_DownloadNF LoadFrom(System.IO.Stream source)
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

        public static async Task<CabecalhoMensagem_DownloadNF> LoadFromAsync(System.IO.Stream source)
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
}