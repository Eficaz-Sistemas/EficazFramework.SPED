namespace EficazFramework.SPED.Schemas;

public interface IXmlSpedDocument
{
    /// <summary>
    /// Retorna o tipo de Documento (NFe, CTe, etc) para permitir o cast correto.
    /// </summary>
    XmlDocumentType DocumentType { get; }

    /// <summary>
    /// Data de Emissão do Documento Fiscal
    /// </summary>
    DateTime? DataEmissao { get; }

    /// <summary>
    /// Chave única do Documento Fiscal
    /// </summary>
    string Chave { get; }

    string Serialize();
}
public enum XmlDocumentType
{

    /// <summary>
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

    /// <summary>
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


    /// <summary>
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
