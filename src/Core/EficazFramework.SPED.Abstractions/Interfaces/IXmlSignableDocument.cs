namespace EficazFramework.SPED.Schemas;

public interface IXmlSignableDocument
{

    public string TagToSign { get; }

    public string TagId { get; }

    public bool EmptyURI { get; }


    public bool SignAsSHA256 { get; }
}
