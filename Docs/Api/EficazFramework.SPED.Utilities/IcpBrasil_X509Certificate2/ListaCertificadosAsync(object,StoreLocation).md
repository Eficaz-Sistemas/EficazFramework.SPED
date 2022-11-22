#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Utilities](EficazFramework.SPED.Utilities.md 'EficazFramework.SPED.Utilities').[IcpBrasil_X509Certificate2](EficazFramework.SPED.Utilities/IcpBrasil_X509Certificate2.md 'EficazFramework.SPED.Utilities.IcpBrasil_X509Certificate2')

## IcpBrasil_X509Certificate2.ListaCertificadosAsync(object, StoreLocation) Method

Obtém de forma assíncrona a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.

```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<EficazFramework.SPED.Utilities.IcpBrasil_X509Certificate2>> ListaCertificadosAsync(object filtro, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation);
```
#### Parameters

<a name='EficazFramework.SPED.Utilities.IcpBrasil_X509Certificate2.ListaCertificadosAsync(object,System.Security.Cryptography.X509Certificates.StoreLocation).filtro'></a>

`filtro` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Especifica algum critério para filtragem. Opcional.

<a name='EficazFramework.SPED.Utilities.IcpBrasil_X509Certificate2.ListaCertificadosAsync(object,System.Security.Cryptography.X509Certificates.StoreLocation).storeLocation'></a>

`storeLocation` [System.Security.Cryptography.X509Certificates.StoreLocation](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.StoreLocation 'System.Security.Cryptography.X509Certificates.StoreLocation')

Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[IcpBrasil_X509Certificate2](EficazFramework.SPED.Utilities/IcpBrasil_X509Certificate2.md 'EficazFramework.SPED.Utilities.IcpBrasil_X509Certificate2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')