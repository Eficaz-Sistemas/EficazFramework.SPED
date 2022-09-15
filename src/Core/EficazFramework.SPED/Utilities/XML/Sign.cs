using System.Collections.Generic;

namespace EficazFramework.SPED.Utilities.XML;

public class Sign
{

    /// <summary>
    /// Realiza a assinatura digital de um documento XML.
    /// </summary>
    /// <param name="xml">O XMLDocument a ser assinado.</param>
    /// <param name="tag">A tag para localização do ponto de assinatura.</param>
    /// <param name="id">A tag a ser assinada.</param>
    /// <remarks></remarks>
    public static void SignXml(XmlDocument xml, string tag, string id, X509Certificate2 certificate, bool signAsSHA256 = false, bool emptyURI = false)
    {
        // ## Realiza ajustes necessários no XMLDocument e confere se a URI informada é válida
        if (certificate == null)
            throw new ArgumentNullException(Resources.Strings.Validation.iX509Certificate2NullReference);

        XmlNodeList tags = xml.GetElementsByTagName(tag);
        int count = tags.Count;
        if (count == 0)
            throw new ArgumentException(string.Format(Resources.Strings.Validation.XmlSign_TagNotFound, tag));
        else if (count > 1)
            throw new ArgumentException(string.Format(Resources.Strings.Validation.XmlSign_NonUniqueTag, tag));

        // ## Solicita as credenciais do certificado
        SignedXml sxml = new(xml);
        if (signAsSHA256 == true)
        {
            sxml.SigningKey = certificate.GetRSAPrivateKey();
            sxml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";
        }
        else
            sxml.SigningKey = certificate.PrivateKey;

        Reference @ref = new();
        if (emptyURI == false)
            @ref.Uri = "#" + xml.GetElementsByTagName(id).Item(0)!.Attributes.Cast<XmlAttribute>().Where(att => att.Name.ToLower() == "id").First().InnerText;
        else
            @ref.Uri = "";

        @ref.AddTransform(new XmlDsigEnvelopedSignatureTransform());
        @ref.AddTransform(new XmlDsigC14NTransform());

        if (signAsSHA256 == true)
            @ref.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";

        sxml.AddReference(@ref);

        // ## Inicia a assinatura
        KeyInfo ki = new();
        ki.AddClause(new KeyInfoX509Data(certificate));
        sxml.KeyInfo = ki;
        sxml.ComputeSignature();

        // ## Obtém a representação gráfica da assinatura e a salva em um objeto XMLElement
        Debug.WriteLine(string.Format("Signature: {0}", sxml.CheckSignature()));
        XmlElement xmle = sxml.GetXml();

        // ## Adiciona o XMLElement assinado ao XMLDocument e faz um clonning para evitar algum problema que eu não entendi
        tags[0].AppendChild(xml.ImportNode(xmle, true));
    }


    /// <summary>
    /// Realiza a assinatura digital de um documento XML.
    /// </summary>
    /// <param name="xdoc">O XMLDocument a ser assinado.</param>
    /// <param name="tag">A tag para localização do ponto de assinatura.</param>
    /// <param name="id">A tag a ser assinada.</param>
    /// <remarks></remarks>
    public static void SignXml(ref XDocument xdoc, string tag, string id, X509Certificate2 certificate, bool signAsSHA256 = false, bool emptyURI = false)
    {
        XmlDocument xml = ToXmlDocument(xdoc);
        SignXml(xml, tag, id, certificate, signAsSHA256, emptyURI);
        xdoc = ToXDocument(xml);
    }
}
