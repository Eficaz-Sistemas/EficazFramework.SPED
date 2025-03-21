using EficazFramework.SPED.Schemas;
using System.Text.RegularExpressions;
namespace EficazFramework.SPED.Utilities.XML;

public static partial class Operations
{
    /// <summary>
    /// Efetua a leitura e parsing de um documento <see cref="IXmlSpedDocument"/>
    /// </summary>
    public static IXmlSpedDocument? Open(System.IO.Stream source) =>
        Task.Run(() => OpenAsync(source)).Result;


    /// <summary>
    /// Efetua a leitura e parsing de um documento <see cref="IXmlSpedDocument"/>
    /// </summary>
    public static async Task<IXmlSpedDocument?> OpenAsync(System.IO.Stream source)
    {
        string objString;
        XDocument xdoc;
        var reader = new System.IO.StreamReader(source);
        objString = await reader.ReadToEndAsync();
        ResetStreamOffset(source);
        var fixedstream = new System.IO.MemoryStream();
        try
        {
            // ## REMOVENDO vbNullChar
            string fixedstring = objString.Replace("\0", ""); // .Replace(">.<", "><")

            // ## REMOVENDO TIMEZONE
            if (DTCheck.IsMatch(fixedstring))
                fixedstring = DTCheck.Replace(fixedstring, "$1");

            // ## CRIANDO NOVO STREAM
            var stringReader = new System.IO.StringReader(fixedstring);
            xdoc = XDocument.Load(XmlReader.Create(stringReader));
            stringReader.Dispose();
            xdoc.Save(fixedstream);
            ResetStreamOffset(fixedstream);
        }
        catch (Exception)
        {
            Debug.WriteLine(objString);
            return null;
        }
        // ResetStreamOffset(source)

        // ## Detecting root tag:
        try
        {
            IXmlSpedDocument? resultobj = (xdoc.Root?.Name.LocalName ?? "") switch
            {
                "procNFe" => await Schemas.NFe.ProcessoNFeBase.LoadFromAsync(fixedstream, false),
                "nfeProc" => await Schemas.NFe.ProcessoNFe.LoadFromAsync(fixedstream, false),
                "NFe" => await Schemas.NFe.NFe.LoadFromAsync(fixedstream, false),
                "cteProc" => await Schemas.CTe.ProcessoCTe.LoadFromAsync(fixedstream, false),
                "cteOSProc" => await Schemas.CTeOS.ProcessoCTeOS.LoadFromAsync(fixedstream, false),
                "CTeOS" => await Schemas.CTeOS.CTeOS.LoadFromAsync(fixedstream, false),
                "CTe" => await Schemas.CTe.CTe.LoadFromAsync(fixedstream, false),
                "procEventoNFe" => await Schemas.NFe.ProcessoEvento.LoadFromAsync(fixedstream, false),
                "retEnvEvento" => await Schemas.NFe.RetornoEnvioEvento.LoadFromAsync(fixedstream, false),
                "ProcInutNFe" => await Schemas.NFe.ProcessoInutilizacaoNFe.LoadFromAsync(fixedstream, false),
                "procEventoCTe" => await Schemas.CTe.ProcessoEvento.LoadFromAsync(fixedstream, false),
                "eventoCTe" => await Schemas.CTe.Evento.LoadFromAsync(fixedstream, false),
                "enviCTe" => await Schemas.CTe.LoteCte.LoadFromAsync(fixedstream, false),
                "resEvento" => await Schemas.NFe.ResumoEvento.LoadFromAsync(fixedstream, false),
                "CompNfse" => await Schemas.NFSe.ABRASF.tcCompNfse.LoadFromAsync(fixedstream, false),
                "CompNfe" => await Schemas.NFSe.Common.tcCompNfse.LoadFromAsync(fixedstream, false),
                "ComplNfse" => await Schemas.NFSe.Common.tcComplNfse.LoadFromAsync(fixedstream, false),
                "ConsultarNfseRpsResposta" => objString.Contains("ginfes") ? 
                    await Schemas.NFSe.GINFES.tcListaNfse.LoadFromAsync(fixedstream, false) : 
                    null,
                "ConsultarLoteRpsResposta" => await Schemas.NFSe.GINFES.ConsultarLoteRpsResposta.LoadFromAsync(fixedstream, false),
                "NFSE" => await Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2.LoadFromAsync(fixedstream, false),
                "EnviarLoteRpsEnvio" => await Schemas.NFSe.GINFES.EnviarLoteRpsEnvio.LoadFromAsync(fixedstream, false),
                "ConsultarNfseResposta" => xdoc.Root?.ToString().Contains("http://www.abrasf.org.br/nfse.xsd") ?? false ?
                    await Schemas.NFSe.ABRASF.ConsultarNFseResposta.LoadFromAsync(fixedstream, false, "http://www.abrasf.org.br/nfse.xsd") :
                    await Schemas.NFSe.ABRASF.ConsultarNFseResposta.LoadFromAsync(fixedstream, false),
                "ConsultarNfseServicoPrestadoResposta" => xdoc.Root?.ToString().Contains("http://www.abrasf.org.br/nfse.xsd") ?? false ?
                    await Schemas.NFSe.ABRASF.ConsultarNFseResposta.LoadFromAsync(fixedstream, false, "http://www.abrasf.org.br/nfse.xsd") :
                    await Schemas.NFSe.ABRASF.ConsultarNFseResposta.LoadFromAsync(fixedstream, false),
                "CFe" => await Schemas.SAT_CFe.CFe.LoadFromAsync(fixedstream, false),
                "envCFe" => await Schemas.SAT_CFe.envCFe.LoadFromAsync(fixedstream, false),
                "cancCFe" => await Schemas.SAT_CFe.CancelamentoCFe.LoadFromAsync(fixedstream, false),
                _ => xdoc.Root?.Name.LocalName.ToLower() == "nfse" ?
                        await Schemas.NFSe.Common.NFSe.LoadFromAsync(fixedstream, false) :
                        (xdoc.Root?.Name.LocalName.Contains("nfse", StringComparison.CurrentCultureIgnoreCase) ?? false) ?
                            await Schemas.NFSe.ABRASF.ConsultarNFseResposta.LoadFromAsync(fixedstream, false) : null,
            };
            return resultobj;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
        finally
        {
            fixedstream.Dispose();
            reader.Dispose();
        }
    }


    internal static void ResetStreamOffset(System.IO.Stream source)
    {
        if (source is null)
            return;
        try
        {
            source.Position = 0L;
            source.Seek(0L, System.IO.SeekOrigin.Begin);
        }
        catch
        {
        } // ex As Exception
    }


    public static string RemoveAllNamespaces(string xmlDocument)
    {
        var xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));
        string result = xmlDocumentWithoutNs.ToString();
        return result;
    }

    public static string RemoveW3CNamespaces(this string xmlDocument)
    {
        string final = xmlDocument.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema-instance\"", string.Empty);
        final = final.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", string.Empty);
        final = final.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", string.Empty);
        final = final.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema\"", string.Empty);
        return final;
    }


    private static XElement RemoveAllNamespaces(XElement xmlDocument)
    {
        if (!xmlDocument.HasElements)
        {
            var xElement = new XElement(xmlDocument.Name.LocalName)
            {
                Value = xmlDocument.Value
            };
            foreach (XAttribute attribute in xmlDocument.Attributes())
                xElement.Add(attribute);
            return xElement;
        }

        return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
    }


#if NET7_0_OR_GREATER
    private static readonly Regex DTCheck = DTCheckInternal();

    [GeneratedRegex("(\\d{4}-\\d{2}-\\d{2}T\\d{2}:\\d{2}:\\d{2})([\\+|-]\\d{2}:\\d{2})")]
    private static partial Regex DTCheckInternal();
#else
    private static readonly Regex DTCheck = new Regex(@"(\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2})([\+|-]\d{2}:\d{2})");
#endif



    /// <summary>
    /// Converte uma instância de <see cref="XmlElement"/> para <see cref="XElement"/>
    /// </summary>
    public static object ToXElement(XmlElement source) =>
        XElement.Parse(source.OuterXml);
}


