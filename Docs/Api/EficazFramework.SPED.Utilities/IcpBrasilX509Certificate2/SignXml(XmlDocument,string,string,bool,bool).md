#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Utilities](EficazFramework.SPED.Utilities.md 'EficazFramework.SPED.Utilities').[IcpBrasilX509Certificate2](EficazFramework.SPED.Utilities/IcpBrasilX509Certificate2.md 'EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2')

## IcpBrasilX509Certificate2.SignXml(XmlDocument, string, string, bool, bool) Method

Realiza a assinatura de um [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument') na tag especificada

```csharp
public void SignXml(System.Xml.XmlDocument xml, string tag, string id, bool signAsSHA256=false, bool emptyURI=false);
```
#### Parameters

<a name='EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.SignXml(System.Xml.XmlDocument,string,string,bool,bool).xml'></a>

`xml` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

Conteúdo do XML a ser assinado

<a name='EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.SignXml(System.Xml.XmlDocument,string,string,bool,bool).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Tag a ser assinada

<a name='EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.SignXml(System.Xml.XmlDocument,string,string,bool,bool).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.SignXml(System.Xml.XmlDocument,string,string,bool,bool).signAsSHA256'></a>

`signAsSHA256` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Usar criptografia SHA256 na assinatura

<a name='EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.SignXml(System.Xml.XmlDocument,string,string,bool,bool).emptyURI'></a>

`emptyURI` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')