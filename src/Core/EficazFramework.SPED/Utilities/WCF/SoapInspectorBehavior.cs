using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace EficazFramework.SPED.Utilities.WCF;
internal class SoapInspectorBehavior : IEndpointBehavior
{
    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        => clientRuntime.ClientMessageInspectors.Add(new SoapMessageInspector());

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }

    public void Validate(ServiceEndpoint endpoint) { }
}
