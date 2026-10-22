namespace EficazFramework.SPED.Documents.Common;

/// <summary>QR Code em PNG usado nos documentos auxiliares.</summary>
internal static class QrCodePng
{
    internal static byte[] Gerar(string conteudo)
    {
        using var gerador = new QRCoder.QRCodeGenerator();
        using var dados = gerador.CreateQrCode(conteudo, QRCoder.QRCodeGenerator.ECCLevel.M);
        using var png = new QRCoder.PngByteQRCode(dados);
        return png.GetGraphic(10);
    }
}
