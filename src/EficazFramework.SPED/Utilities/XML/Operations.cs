using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace EficazFrameworkCore.SPED.Utilities.XML
{
    public class Operations
    {
        private static readonly Regex DTCheck = new Regex(@"(\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2})([\+|-]\d{2}:\d{2})");

        public static IXmlSpedDocument Open(System.IO.Stream source)
        {
            return Task.Run(() => OpenAsync(source)).Result;
        }

        public static async Task<IXmlSpedDocument> OpenAsync(System.IO.Stream source)
        {
            string objString = null;
            XDocument xdoc;
            var reader = new System.IO.StreamReader(source);
            objString = await reader.ReadToEndAsync();
            ResetStreamOffset(source);
            var fixedstream = new System.IO.MemoryStream();
            try
            {
                // ## REMOVENDO vbNullChar
                string fixedstring = objString.Replace(Constants.vbNullChar, ""); // .Replace(">.<", "><")

                // ## REMOVENDO TIMEZONE
                if (DTCheck.IsMatch(fixedstring))
                    fixedstring = DTCheck.Replace(fixedstring, "$1");

                // ## CRIANDO NOVO STREAM
                var stringReader = new System.IO.StringReader(fixedstring);
                xdoc = XDocument.Load(System.Xml.XmlReader.Create(stringReader));
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
            xmlDocumentWithoutNs = null;
            return result;
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                var xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;
                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);
                return xElement;
            }

            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }
    }

    public enum XMLDocumentType
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */        /// <summary>
        /// EficazFramework.SPED.Schemas.NFe.ProcessoNFe
        /// </summary>
        NFeWithProtocol = 0,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFe.NFe
        /// </summary>
        NFeWithoutProtocol = 1,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFe.ProcessoEvento
        /// </summary>
        NFeEvent = 2,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe
        /// </summary>
        NFeInutilization = 3,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFe.ProcessoNFeBase
        /// </summary>
        NFeWithProtocol_Base = 4,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFe.ProcessoEvento
        /// </summary>
        NFeEvent_Resumo = 5,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFe.ProcessoEvento
        /// </summary>
        NFe_Resumo = 6,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento
        /// </summary>
        NFeRetEvent = 7,

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */        /// <summary>
        /// EficazFramework.SPED.CTe.Classes.ProcessoCTe
        /// </summary>
        CTeWithProtocol = 11,
        /// <summary>
        /// EficazFramework.SPED.CTe.Classes.CTe
        /// </summary>
        CTeWithoutProtocol = 12,
        /// <summary>
        /// EficazFramework.SPED.CTe.Classes.ProcessoEvento
        /// </summary>
        CTeEvent = 13,
        /// <summary>
        /// EficazFramework.SPED.CTe.Classes.LoteCte
        /// </summary>
        CTeLote = 14,
        /// <summary>
        /// EficazFramework.SPED.CTe.Classes.Evento
        /// </summary>
        CTeEvent2 = 13,

        /// <summary>
        /// EficazFramework.SPED.CTeOS.Classes.ProcessoCTeOS
        /// </summary>
        CTeOSWithProtocol = 16,
        /// <summary>
        /// EficazFramework.SPED.CTeOS.Classes.CTeOS
        /// </summary>
        CTeOSWithoutProtocol = 17,
        /// <summary>
        /// EficazFramework.SPED.CTe.Classes.EventoConfEntregaCTe
        /// </summary>
        CTeEvtConfirmacaoEntrega = 18,
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.Common.tcCompNfse
        /// </summary>
        NFSe_CommonSchema = 21,


        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.GINFES
        /// </summary>
        NFSe_GINFES_LoteRPS = 22,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.GINFES
        /// </summary>
        NFSe_GINFES_LoteRPS2 = 23,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.GINFES
        /// </summary>
        NFSe_GINFES_LoteRPS_Envio = 24,
        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse
        /// </summary>
        NFSe_GINFES_NFSeRPS_Consulta = 25,

        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.Common.tcCompNfse, EficazFramework.SPED.Schemas.NFSe.Common.tcComplNfse
        /// </summary>
        NFSe_CommonSchema2 = 26,

        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.Common.tcCompNfse
        /// </summary>
        NFSe_CommonSchema_SingleNFse = 27,


        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.BETHA
        /// </summary>
        NFSe_BETHA_LoteRPS = 32,



        /// <summary>
        /// EficazFramework.SPED.Schemas.NFSe.ABRASF
        /// </summary>
        NFSe_ABRASF_ConsultaLoteNFSe = 39,


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */        /// <summary>
        /// EficazFramework.SPED.Schemas.SAT_CFe.CFe
        /// </summary>
        SAT_CFe = 51,
        /// <summary>
        /// EficazFramework.SPED.Schemas.SAT_CFe.envCFe
        /// </summary>
        SAT_CFe_Lote = 52,
        /// <summary>
        /// EficazFramework.SPED.Schemas.SAT_CFe.cancCFe
        /// </summary>
        SAT_CFe_Cancelamento = 53,

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /// <summary>
        /// Not valid XML SPED Document
        /// </summary>
        Unknown = 999
    }

    public interface IXmlSpedDocument
    {
        XMLDocumentType DocumentType { get; }
        DateTime? DataEmissao { get; }
        string Chave { get; }
    }
}