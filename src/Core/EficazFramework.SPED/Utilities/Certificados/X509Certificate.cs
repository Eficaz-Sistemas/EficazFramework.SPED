using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Utilities;

public class IcpBrasil_X509Certificate2 : X509Certificate2
{
    /// <summary>
    /// Autoridade Certificadora, emissora do Certificado Digital
    /// </summary>
    public string AutoridadeCertificadora { get; }

    /// <summary>
    /// CNPJ ou CPF do Titular do Certificado Digital
    /// </summary>
    public string CNPJ_CPF { get; }

    /// <summary>
    /// Data/Hora de Emissão do Certificado Digital
    /// </summary>
    public DateTime? DataEfetiva { get; }

    /// <summary>
    /// Tipo de Certificado Digital. Exemplos:<br/><br/>
    /// e-CNPJ A1<br/>
    /// e-CNPJ A3<br/>
    /// e-CPF A1<br/>
    /// e-CPF A3<br/>
    /// </summary>
    public string Tipo { get; }

    /// <summary>
    /// Nome ou Razão Social do Titular do Certificado Digital
    /// </summary>
    public string Titular { get; }

    /// <summary>
    /// Data/Hora de Expiração da Validade do Certificado Digital
    /// </summary>
    public DateTime? Validade { get; }

    /// <summary>
    /// Instância privada de Certificado Digital, contendo as informações
    /// sensíveis para assinatura de documentos.
    /// </summary>
    public X509Certificate PrivateInstance { get; }

    /// <summary>
    /// Inicia uma nova instância de <see cref="IcpBrasil_X509Certificate2"/> realizando a leitura
    /// do arquivo localizado em <paramref name="filename"/>, sendo exigida a senha no parâmetro
    /// <paramref name="password"/> para acesso à chave privada do mesmo.
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="password"></param>
    public IcpBrasil_X509Certificate2(string filename, string password) : base(filename, password)
    {
        string[] data = Subject.Split(",");
        string[] temp = data[0].Split(":");

        if (temp.Length >= 1)
            Titular = temp[0].Replace("CN=", "");

        if (temp.Length >= 2)
            CNPJ_CPF = temp[1].ToString().FormatRFBDocument();

        if (data.Length >= 2)
            AutoridadeCertificadora = data[1].Replace("OU=Autenticado por ", "");

        if (data.Length >= 3)
            Tipo = data[2].Replace("OU=", "");

        DataEfetiva = DateTime.Parse(GetEffectiveDateString());
        Validade = DateTime.Parse(GetExpirationDateString());
        PrivateInstance = this;
    }

    /// <summary>
    /// Inicia uma nova instância de <see cref="IcpBrasil_X509Certificate2"/>
    /// à partir de uma instância de certificado, cujo conteúdo foi serializado
    /// em array de bytes
    /// </summary>
    /// <param name="rawdata"></param>
    /// <param name="instance"></param>
    public IcpBrasil_X509Certificate2(byte[] rawdata, X509Certificate2 instance) : base(rawdata)
    {
        string[] data = Subject.Split(",");
        string[] temp = data[0].Split(":");

        if (temp.Length >= 1)
            Titular = temp[0].Replace("CN=", "");

        if (temp.Length >= 2)
            CNPJ_CPF = temp[1].ToString().FormatRFBDocument();

        if (data.Length >= 2)
            AutoridadeCertificadora = data[1].Replace("OU=Autenticado por ", "");

        if (data.Length >= 3)
            Tipo = data[2].Replace("OU=", "");

        DataEfetiva = DateTime.Parse(GetEffectiveDateString());
        Validade = DateTime.Parse(GetExpirationDateString());
        PrivateInstance = instance;
    }

    public override string ToString()
    {
        return string.Format("{0} | CNPJ / CPF: {1} | Validade: {2} a {3}", Titular, CNPJ_CPF, DataEfetiva, Validade);
    }




    /// <summary>
    /// Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador.
    /// </summary>
    /// <param name="filter">Especifica algum critério para filtragem. Opcional.</param>
    /// <param name="storeLocation">Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.</param>
    private static X509Certificate2Collection GetCertificatesStoreInternal(object filter, StoreLocation storeLocation)
    {
        X509Certificate2Collection certificates;
        X509Store store = new X509Store("MY", storeLocation);
        store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

        certificates = store.Certificates; // .Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, True)
        if (filter != null)
            certificates = store.Certificates.Find(X509FindType.FindBySubjectName, filter, true);

        store.Close();

        return certificates;
    }

    /// <summary>
    /// Transforma a listagem de certificados obtidos em <see cref="GetCertificatesStoreInternal(object, StoreLocation)"/>
    /// para uma lista de classes <see cref="IcpBrasil_X509Certificate2"/>, para exibição amigável das informações
    /// do padrão de Certificados Digitais ICP-Brasil.
    /// </summary>
    /// <param name="certificados"></param>
    private static List<IcpBrasil_X509Certificate2> FormatData(X509Certificate2Collection certificados)
    {
        List<IcpBrasil_X509Certificate2> final = new List<IcpBrasil_X509Certificate2>();

        foreach (X509Certificate2 cert in certificados)
        {
            if (!cert.Subject.ToLower().Contains("icp-brasil"))
                continue;
            final.Add(new IcpBrasil_X509Certificate2(cert.RawData, cert));
        }

        return final.OrderBy(f => f.Titular).ToList();
    }

    /// <summary>
    /// Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.
    /// </summary>
    /// <param name="filtro">Especifica algum critério para filtragem. Opcional.</param>
    /// <param name="storeLocation">Determina se será pesquisado no Rpositório Global ou no Repositório do Usuário Logado.</param>
    public static List<IcpBrasil_X509Certificate2> ListaCertificados(object filtro, StoreLocation storeLocation)
    {
        X509Certificate2Collection list = GetCertificatesStoreInternal(filtro, storeLocation);
        return FormatData(list);
    }

    /// <summary>
    /// Obtém de forma assíncrona a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.
    /// </summary>
    /// <param name="filtro">Especifica algum critério para filtragem. Opcional.</param>
    /// <param name="storeLocation">Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.</param>
    public static async Task<List<IcpBrasil_X509Certificate2>> ListaCertificadosAsync(object filtro, StoreLocation storeLocation)
    {
        X509Certificate2Collection list = await Task.Run(() =>
        {
            return GetCertificatesStoreInternal(filtro, storeLocation);
        });
        return FormatData(list);
    }



    //public void SignXml(XmlDocument xml, string tag, string id, bool signAsSHA256 = false, bool emptyURI = false)
    //{
    //    Utilities.XML.SignXml(xml, tag, id, PrivateInstance, signAsSHA256, emptyURI);
    //}

    //public void SignXml(XDocument xml, string tag, string id, bool signAsSHA256 = false, bool emptyURI = false)
    //{
    //    Utilities.XML.SignXml(xml, tag, id, PrivateInstance, signAsSHA256, emptyURI);
    //}

}
