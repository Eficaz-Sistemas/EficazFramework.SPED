using System.ServiceModel.Channels;
using System.ServiceModel;

namespace EficazFramework.SPED.Services.NFe.SoapClients;

internal class NfeConsultaProtocolo4 : ClientBase<Contracts.INfeConsultaProtocolo4>, ISoapClient
{
    internal NfeConsultaProtocolo4(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

    static ISoapClient ISoapClient.Create(params string[] args)
        => new NfeConsultaProtocolo4(Contracts.INfeConsultaProtocolo4.ConfigureBinding(), new(Contracts.INfeConsultaProtocolo4.ConfigureUrl(args)));

    async Task<XmlNode> ISoapClient.ExecuteAsync([XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4")] XmlNode request)
        => await Channel.ExecuteAsync(request); 
}
