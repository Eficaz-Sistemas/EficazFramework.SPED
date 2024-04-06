#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Utilities](EficazFramework.SPED.Utilities.md 'EficazFramework.SPED.Utilities')

## IcpBrasilX509Certificate2 Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| AutoridadeCertificadora | `String` | Autoridade Certificadora, emissora do Certificado Digital |
| CNPJ_CPF | `String` | CNPJ ou CPF do Titular do Certificado Digital |
| DataEfetiva | `Nullable<DateTime>` | Data/Hora de Emissão do Certificado Digital |
| Tipo | `String` | Tipo de Certificado Digital. Exemplos:<br/><br/>            e-CNPJ A1<br/>            e-CNPJ A3<br/>            e-CPF A1<br/>            e-CPF A3<br/> |
| Titular | `String` | Nome ou Razão Social do Titular do Certificado Digital |
| Validade | `Nullable<DateTime>` | Data/Hora de Expiração da Validade do Certificado Digital |
| PrivateInstance | `X509Certificate2` | Instância privada de Certificado Digital, contendo as informações            sensíveis para assinatura de documentos. |

| Methods | |
| :--- | :--- |
| [ListaCertificados(object, StoreLocation)](EficazFramework.SPED.Utilities/IcpBrasilX509Certificate2/ListaCertificados(object,StoreLocation).md 'EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.ListaCertificados(object, System.Security.Cryptography.X509Certificates.StoreLocation)') | Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil. |
| [ListaCertificadosAsync(object, StoreLocation)](EficazFramework.SPED.Utilities/IcpBrasilX509Certificate2/ListaCertificadosAsync(object,StoreLocation).md 'EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.ListaCertificadosAsync(object, System.Security.Cryptography.X509Certificates.StoreLocation)') | Obtém de forma assíncrona a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil. |
| [SignXml(XDocument, string, string, bool, bool)](EficazFramework.SPED.Utilities/IcpBrasilX509Certificate2/SignXml(XDocument,string,string,bool,bool).md 'EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.SignXml(System.Xml.Linq.XDocument, string, string, bool, bool)') | Realiza a assinatura de um [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument') na tag especificada |
| [SignXml(XmlDocument, string, string, bool, bool)](EficazFramework.SPED.Utilities/IcpBrasilX509Certificate2/SignXml(XmlDocument,string,string,bool,bool).md 'EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.SignXml(System.Xml.XmlDocument, string, string, bool, bool)') | Realiza a assinatura de um [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument') na tag especificada |
| [ToString()](EficazFramework.SPED.Utilities/IcpBrasilX509Certificate2/ToString().md 'EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.ToString()') | |
