namespace EficazFramework.SPED.Utilities.XML;

public static class NFe
{
    /// <summary>
    /// retorna o documento XML no schema <see cref="Schemas.NFe.ProcessoNFe"/> (tag raíz nfeProc), 
    /// contendo a <see cref="Schemas.NFe.NFe"/> e seu <see cref="Schemas.NFe.ProtocoloRecebimento"/>
    /// </summary>
    public static string GeraDocumentoAutorizado(string nfe, string protocoloAutorizacao, string versao = "4.00")
    {
        XmlDocument root = new();
        root.LoadXml(new Schemas.NFe.ProcessoNFe() { Versao = versao }.Serialize());
        root.AppendChild(root.ReadNode(XDocument.Parse(nfe).Root?.CreateReader()));
        root.AppendChild(root.ReadNode(XDocument.Parse(protocoloAutorizacao).Root?.CreateReader()));
        return root.OuterXml;
    }


    /// <summary>
    /// retorna o documento XML no schema <see cref="Schemas.NFe.ProcessoNFe"/> (tag raíz nfeProc), 
    /// contendo a <see cref="Schemas.NFe.NFe"/> e seu <see cref="Schemas.NFe.ProtocoloRecebimento"/>
    /// </summary>
    public static string GeraDocumentoAutorizado(this Schemas.NFe.RetornoAutorizacaoNFe retornoAutorizacao, string nfe, string versao = "4.00")
        => GeraDocumentoAutorizado(nfe, retornoAutorizacao?.ProtocoloRecebimento?.Serialize(), versao);

}
