namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_1;

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
        algorithmField = "http://www.w3.org/2001/04/xmlenc#sha256"; // "http://www.w3.org/2000/09/xmldsig#sha1"
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
