#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Utilities.XML](EficazFramework.SPED.Utilities.XML.md 'EficazFramework.SPED.Utilities.XML').[Sign](EficazFramework.SPED.Utilities.XML/Sign.md 'EficazFramework.SPED.Utilities.XML.Sign')

## Sign.SignXml(XDocument, string, string, X509Certificate2, bool, bool) Method

Realiza a assinatura digital de um documento XML.

```csharp
public static void SignXml(ref System.Xml.Linq.XDocument xdoc, string tag, string id, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate, bool signAsSHA256=false, bool emptyURI=false);
```
#### Parameters

<a name='EficazFramework.SPED.Utilities.XML.Sign.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).xdoc'></a>

`xdoc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

O [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument') a ser assinado.

<a name='EficazFramework.SPED.Utilities.XML.Sign.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A tag para localização do ponto de assinatura.

<a name='EficazFramework.SPED.Utilities.XML.Sign.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A tag a ser assinada.

<a name='EficazFramework.SPED.Utilities.XML.Sign.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).certificate'></a>

`certificate` [System.Security.Cryptography.X509Certificates.X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2 'System.Security.Cryptography.X509Certificates.X509Certificate2')

<a name='EficazFramework.SPED.Utilities.XML.Sign.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).signAsSHA256'></a>

`signAsSHA256` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.SPED.Utilities.XML.Sign.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).emptyURI'></a>

`emptyURI` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks