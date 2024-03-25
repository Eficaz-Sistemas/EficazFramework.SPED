namespace EficazFramework.SPED.Utilities.XML;

public static class NFe
{
    /// <summary>
    /// Realiza o cálculo do dígito verificador da Chave da NFe.
    /// </summary>
    /// <param name="chave43"></param>
    /// <returns></returns>
    public static string CalculaDigitoVerificador(string chave43)
    {
        try
        {
            int index = 42;
            int soma = 0;
            int[] multiplicadores = [2, 3, 4, 5, 6, 7, 8, 9];

            while (index > 0)
            {
                for (int multiplicador = 0; multiplicador < multiplicadores.Length; multiplicador++)
                {
                    soma += int.Parse(chave43[index].ToString()) * multiplicadores[multiplicador];
                    index--;

                    if (index < 0)
                        break;
                }
            }

            int resto = soma % 11;
            return ((resto == 0 || resto == 1) ? 0 : 11 - resto).ToString();

        }
        catch
        {
            return string.Empty;
        }
    }


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
