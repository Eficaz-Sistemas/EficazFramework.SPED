using EficazFramework.SPED.Schemas;
using System.Text.RegularExpressions;
namespace EficazFramework.SPED.Utilities.XML;

public partial class Operations
{
    /// <summary>
    /// Efetua a leitura e parsing de um documento <see cref="IXmlSpedDocument"/>
    /// </summary>
    public static IXmlSpedDocument Open(System.IO.Stream source) =>
        Task.Run(() => OpenAsync(source)).Result;


    /// <summary>
    /// Efetua a leitura e parsing de um documento <see cref="IXmlSpedDocument"/>
    /// </summary>
    public static async Task<IXmlSpedDocument> OpenAsync(System.IO.Stream source)
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
        IXmlSpedDocument resultobj = null;
        try
        {
            switch (xdoc.Root.Name.LocalName ?? "")
            {
                case "procNFe":
                    {
                        resultobj = await Schemas.NFe.ProcessoNFeBase.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "nfeProc":
                    {
                        resultobj = await Schemas.NFe.ProcessoNFe.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "NFe":
                    {
                        resultobj = await Schemas.NFe.NFe.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "cteProc":
                    {
                        resultobj = await Schemas.CTe.ProcessoCTe.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "cteOSProc":
                    {
                        resultobj = await Schemas.CTeOS.ProcessoCTeOS.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "CTeOS":
                    {
                        resultobj = await Schemas.CTeOS.CTeOS.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "CTe":
                    {
                        resultobj = await Schemas.CTe.CTe.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "procEventoNFe":
                    {
                        resultobj = await Schemas.NFe.ProcessoEvento.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "retEnvEvento":
                    {
                        resultobj = await Schemas.NFe.RetornoEnvioEvento.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "ProcInutNFe":
                    {
                        resultobj = await Schemas.NFe.ProcessoInutilizacaoNFe.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "procEventoCTe":
                    {
                        resultobj = await Schemas.CTe.ProcessoEvento.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "eventoCTe":
                    {
                        resultobj = await Schemas.CTe.Evento.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "enviCTe":
                    {
                        resultobj = await Schemas.CTe.LoteCte.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "resEvento":
                    {
                        resultobj = await Schemas.NFe.ResumoEvento.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "CompNfse":
                    {
                        resultobj = await Schemas.NFSe.Common.tcCompNfse.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "ComplNfse":
                    {
                        resultobj = await Schemas.NFSe.Common.tcComplNfse.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "ConsultarNfseRpsResposta":
                    {
                        if (objString.Contains("ginfes"))
                        {
                            resultobj = await Schemas.NFSe.GINFES.tcListaNfse.LoadFromAsync(fixedstream, false);
                        }

                        break;
                    }
                // TODO: tentar abrasf num futuro...


                case "ConsultarLoteRpsResposta": // GINFES 
                    {
                        // TODO: tentar abrasf num futuro...
                        resultobj = await Schemas.NFSe.GINFES.ConsultarLoteRpsResposta.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "NFSE": // GINFES 
                    {
                        resultobj = await Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "EnviarLoteRpsEnvio": // GINFES 
                    {
                        resultobj = await Schemas.NFSe.GINFES.EnviarLoteRpsEnvio.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "ConsultarNfseResposta": // BETHA 
                    {
                        resultobj = await Schemas.NFSe.BETHA.ConsultarRpsResposta.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "CFe": // SAT CF-e
                    {
                        resultobj = await Schemas.SAT_CFe.CFe.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "envCFe": // SAT CF-e Lote
                    {
                        resultobj = await Schemas.SAT_CFe.envCFe.LoadFromAsync(fixedstream, false);
                        break;
                    }

                case "cancCFe": // SAT CF-e Cancelamento
                    {
                        resultobj = await Schemas.SAT_CFe.CancelamentoCFe.LoadFromAsync(fixedstream, false);
                        break;
                    }

                default:
                    {
                        if (xdoc.Root.Name.LocalName.ToLower() == "nfse")
                        {
                            resultobj = await Schemas.NFSe.Common.NFSe.LoadFromAsync(fixedstream, false);
                        }
                        else if (xdoc.Root.Name.LocalName.ToLower().Contains("nfse"))
                        {
                            resultobj = await Schemas.NFSe.ABRASF.ConsultarNFseResposta.LoadFromAsync(fixedstream, false); // ABRASF
                        }

                        break;
                    }
            }
        }
        catch (Exception outer_ex)
        {
            Debug.WriteLine(outer_ex.ToString());
        }

        fixedstream.Dispose();
        reader.Dispose();
        return resultobj;
    }


    protected static void ResetStreamOffset(System.IO.Stream source)
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


    [GeneratedRegex("(\\d{4}-\\d{2}-\\d{2}T\\d{2}:\\d{2}:\\d{2})([\\+|-]\\d{2}:\\d{2})")]
    private static partial Regex DTCheck();



    /// <summary>
    /// Converte uma instância de <see cref="XmlElement"/> para <see cref="XElement"/>
    /// </summary>
    public static object ToXElement(XmlElement source) =>
        XElement.Parse(source.OuterXml);
}


