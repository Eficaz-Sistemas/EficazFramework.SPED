using System.ServiceModel.Channels;
using System.ServiceModel;

namespace EficazFramework.SPED.Services;

internal interface ISoapClient
{
    internal abstract static ISoapClient Create(params string[] args);

    internal Task<XmlNode> ExecuteAsync(XmlNode request);

}
